/*
 * This file is part of the EasyJection Framework.
 * Author: Max Karepin (http://github.com/imaxs/)
 *
 * Copyright © 2021 Max Karepin
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EasyJection.Hooking
{
    using EasyJection.Binding;
    using System.Collections.Generic;
    using Types;
    using static UnityEngine.UI.Image;

    public sealed class HookManager : Disposable, IHookManager
    {
        private static class Architecture
        {
            public const uint SIZE_X64 = 13;
            public const uint SIZE_X86 = 7;

            private enum BITS { X86, X64 }
            private static readonly BITS Bits;

            static Architecture()
            {
                Bits = (IntPtr.Size == 4) ? BITS.X86 : BITS.X64;
            }

            public static bool IsX64
            {
                get => Bits == BITS.X64;
            }

            public static bool IsX86
            {
                get => Bits == BITS.X86;
            }
        }

#if ENABLE_IL2CPP
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        private unsafe struct __IL2CPP
        {
            public IntPtr originalMethodPointer;    // OUTPUT (Il2CppMethodPointer::methodPointer;)
            public MethodBase originalMethodBase;   // INPUT (typedef struct MethodBase -> il2cpp-class-internals.h)
            public MethodBase hookedMethodBase;     // INPUT (typedef struct MethodBase -> il2cpp-class-internals.h)
        }
        private __IL2CPP m_Il2CPPStruct;
#else
        private byte[] bytes;
#endif
        private bool isHooked;
        private IMethodInvokeData invokeData;

        public IMethodInvokeData InvokeData { get => invokeData; }

        private MethodBase hookedMethod;

        private MethodBase originalMethod;

        public HookManager(IMethodInvokeData invokeData, MethodBase hooked, MethodBase original, bool HookImmediately = true)
        {
            this.isHooked = false;
            this.bytes = new byte[Architecture.SIZE_X64];
            this.hookedMethod = hooked;
            this.originalMethod = original;
            this.invokeData = invokeData;
#if !ENABLE_IL2CPP
            RuntimeHelpers.PrepareMethod(originalMethod.MethodHandle);
            RuntimeHelpers.PrepareMethod(hookedMethod.MethodHandle);
#endif
            if (HookImmediately)
                this.Hook();
        }

        /// NOTE: If the values of the arguments for a method were specified on binding,
        /// they will replace the original arguments passed to the method when it was called.
        public object InvokeOriginalMethodResult(IBindingData bindingData, object instance, object[] originalArguments = null)
        {
            var scopedInstances = new Dictionary<System.Type, object>()
            {
                { bindingData.Type, instance }
            };

            // Resolve dependency for each parameter specified if its value is null
            var arguments = Container.Instance.Resolve(
                invokeData.ArgumentsObjects ?? originalArguments,
                invokeData.ArgumentTypes,
                scopedInstances);

            // Disabling a hook before calling the original method
            this.Unhook();

            // Call the original method and get its return value. 
            object returnValue = this.originalMethod.Invoke(instance, arguments);

            // Dependencies Injection
            Container.Instance.Inject(returnValue, scopedInstances);

            // Enable the hook
            this.Hook();

            return returnValue;
        }

        /// NOTE: If the values of the arguments for a method were specified on binding,
        /// they will replace the original arguments passed to the method when it was called.
        public void InvokeOriginalMethodVoid(IBindingData bindingData, object instance, object[] originalArguments = null)
        {
            var scopedInstances = new Dictionary<System.Type, object>()
            {
                {  bindingData.Type, instance }
            };

            // Resolve dependency for each parameter specified if its value is null
            var arguments = Container.Instance.Resolve(
                invokeData.ArgumentsObjects ?? originalArguments,
                invokeData.ArgumentTypes,
                scopedInstances);

            // Disabling a hook before calling the original method
            this.Unhook();

            // Call the original method and get its return value. 
            this.originalMethod.Invoke(instance, arguments);

            // Dependencies Injection
            Container.Instance.Inject(bindingData, instance, scopedInstances);

            // Enable the hook
            this.Hook();
        }

        public void Hook()
        {
            if (this.isHooked)
                return;
#if ENABLE_IL2CPP
            IL2CPP.__IL2CPP_LOG("Hooked: InjectMethod: " + hookedMethod.Name + " | Original: " + originalMethod.Name);
            m_Il2CPPStruct = new __IL2CPP() { originalMethodBase = originalMethod, 
                                              hookedMethodBase = hookedMethod };
            unsafe
            {
                fixed (IntPtr* ptr = &m_Il2CPPStruct.originalMethodPointer){
                    IL2CPP.__IL2CPP_HOOK(ptr);
                }
            }
#else
            IntPtr methodTarget = originalMethod.MethodHandle.GetFunctionPointer();
            IntPtr methodInject = hookedMethod.MethodHandle.GetFunctionPointer();

            unsafe
            {
                if (Architecture.IsX64)
                {
                    byte* ptr = (byte*)methodTarget.ToPointer();
                    for (int p = 0; p < bytes.Length; p++)
                        bytes[p] = ptr[p];

                    int inject = (int)methodInject.ToPointer();
                    int target = (int)methodTarget.ToPointer();

                    *(ptr) = 0xE9;
                    *(int*)(ptr + 1) = inject - (target + 5);
                }
            }
#endif
            this.isHooked = true;
        }

        public void Unhook()
        {
            if (!this.isHooked)
                return;
#if ENABLE_IL2CPP
            // IL2CPP.__IL2CPP_LOG("m_Il2CPPStruct: " + m_Il2CPPStruct.originalMethodPointer);
            unsafe
            {
                fixed (IntPtr* ptr = &m_Il2CPPStruct.originalMethodPointer){
                    IL2CPP.__IL2CPP_UNHOOK(ptr);
                }
            }
#else
            // Restore original
            IntPtr origPtr = originalMethod.MethodHandle.GetFunctionPointer();
            unsafe
            {
                byte* ptr = (byte*)origPtr;
                for (int i = 0; i < bytes.Length; i++)
                    *(ptr + i) = bytes[i];
            }
#endif
            this.isHooked = false;
        }

        protected override void Remove()
        {
            this.Unhook();
        }
    }

    public sealed class IL2CPP
    {
        public static bool IsEnabled
        {
            get
            {
#if ENABLE_IL2CPP
                return true;
#else
                return false;
#endif
            }
        }

#if ENABLE_IL2CPP

    //#if UNITY_IPHONE || UNITY_XBOX360
        private const string PluginName = "__Internal";
    //#else
    //  private const string PluginName = "Native";
    //#endif

        [DllImport(PluginName, EntryPoint = "__IL2CPP_HOOK")]
        public unsafe static extern void __IL2CPP_HOOK(IntPtr* ptr); // pointer to the first element in the structure

        [DllImport(PluginName, EntryPoint = "__IL2CPP_UNHOOK")]
        public unsafe static extern void __IL2CPP_UNHOOK(IntPtr* ptr); // pointer to the first element in the structure

        [DllImport(PluginName, EntryPoint = "__IL2CPP_LOG")]
        public static extern void __IL2CPP_LOG(string logText);
#endif
    }
}
