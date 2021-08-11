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

namespace EasyJection
{
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
        // #if UNITY_IPHONE || UNITY_XBOX360
            private const string DllImport = "__Internal";
        // #else
            // private const string DllImport = "Native";
        // #endif

        [DllImport(DllImport, EntryPoint = "__IL2CPP_HOOK")]
        public unsafe static extern void __IL2CPP_HOOK(IntPtr* ptr); // pointer to the first element in the structure

        [DllImport(DllImport, EntryPoint = "__IL2CPP_UNHOOK")]
        public unsafe static extern void __IL2CPP_UNHOOK(IntPtr* ptr); // pointer to the first element in the structure

        [DllImport(DllImport, EntryPoint = "__IL2CPP_LOG")]
        public static extern void __IL2CPP_LOG(string logText);
#endif
    }

    public sealed class Hook //: IDisposable
    {
        private const uint SIZE_X64 = 12;
        private const uint SIZE_X86 = 7;

        public static HookContainer Cache;
        static Hook() => Cache = new HookContainer();

        private enum BITS { X86, X64 }
        
#if ENABLE_IL2CPP
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        private unsafe struct __IL2CPP
        {
            public IntPtr originalMethodPointer;    // OUTPUT (Il2CppMethodPointer::methodPointer;)
            public MethodInfo originalMethodInfo;   // INPUT (typedef struct MethodInfo -> il2cpp-class-internals.h)
            public MethodInfo injectMethodInfo;     // INPUT (typedef struct MethodInfo -> il2cpp-class-internals.h)
        }
        private __IL2CPP m_Il2CPPStruct;
#else
        private byte[] m_original;
#endif

        private readonly BITS m_Architecture;

        private IContainer m_Container;
        public IContainer Container { get => m_Container; }

        private MethodInfo m_OriginalMethod;
        public MethodInfo OriginalMethod { get => m_OriginalMethod; }

        private MethodInfo m_InjectMethod;
        public MethodInfo InjectMethod { get => m_InjectMethod; }

        private object[] m_Arguments;
        public object[] Arguments { get => m_Arguments; }

        private Hook()
        {
#if !ENABLE_IL2CPP
            m_original = null;
#endif
            // m_IsDisposed = false;
            m_OriginalMethod = null;
            m_InjectMethod = null;
            m_Architecture = IntPtr.Size == 4 ? BITS.X86 : BITS.X64;
        }

        public Hook(IContainer container, MethodInfo originalMethod, MethodInfo injectMethod, object[] args = null) : this()
        {
            if (originalMethod == null || injectMethod == null)
                throw new NullReferenceException(
                                String.Format(
                                    "NullReferenceException: originalMethod({0}), injectMethod({1})",
                                    (originalMethod == null ? "Null" : "Not Null"),
                                    (injectMethod == null ? "Null" : "Not Null")));
#if !ENABLE_IL2CPP
            RuntimeHelpers.PrepareMethod(originalMethod.MethodHandle);
            RuntimeHelpers.PrepareMethod(injectMethod.MethodHandle);
#endif
            m_Container = container;
            m_OriginalMethod = originalMethod;
            m_InjectMethod = injectMethod;
            m_Arguments = args;
            Hooked();
        }

        public void Hooked()
        {
#if ENABLE_IL2CPP
            //IL2CPP.__IL2CPP_LOG("Hooked");
            m_Il2CPPStruct = new __IL2CPP() { originalMethodInfo = m_OriginalMethod, injectMethodInfo = m_InjectMethod };
            unsafe
            {
                fixed (IntPtr* ptr = &m_Il2CPPStruct.originalMethodPointer){
                    IL2CPP.__IL2CPP_HOOK(ptr);
                }
            }
#else
            // Check if method is already hooked
            if (m_original == null)
            {
                IntPtr methodToReplace = m_OriginalMethod.MethodHandle.GetFunctionPointer();
                IntPtr methodToIneject = m_InjectMethod.MethodHandle.GetFunctionPointer();

                if (m_Architecture == BITS.X64)
                {
                    m_original = new byte[SIZE_X64];
                    unsafe
                    {
                        byte* ptr = (byte*)methodToReplace;

                        m_original[0] = ptr[0];
                        m_original[1] = ptr[1];
                        m_original[2] = ptr[2];
                        m_original[3] = ptr[3];
                        m_original[4] = ptr[4];
                        m_original[5] = ptr[5];
                        m_original[6] = ptr[6];
                        m_original[7] = ptr[7];
                        m_original[8] = ptr[8];
                        m_original[9] = ptr[9];
                        m_original[10] = ptr[10];
                        m_original[11] = ptr[11];

                        *(ptr) = 0x48;
                        *(ptr + 1) = 0xb8;
                        *(IntPtr*)(ptr + 2) = methodToIneject;
                        *(ptr + 10) = 0xff;
                        *(ptr + 11) = 0xe0;
                    }
                }
                else // if (m_Architecture == BITS.X86)
                {
                    m_original = new byte[SIZE_X86];
                    unsafe
                    {
                        byte* ptr = (byte*)methodToReplace;

                        m_original[0] = ptr[0];
                        m_original[1] = ptr[1];
                        m_original[2] = ptr[2];
                        m_original[3] = ptr[3];
                        m_original[4] = ptr[4];
                        m_original[5] = ptr[5];
                        m_original[6] = ptr[6];

                        *(ptr) = 0xb8;
                        *(IntPtr*)(ptr + 1) = methodToIneject;
                        *(ptr + 5) = 0xff;
                        *(ptr + 6) = 0xe0;
                    }
                }
            }
#endif
        }

        public void Unhooked()
        {
#if ENABLE_IL2CPP
            //IL2CPP.__IL2CPP_LOG("m_Il2CPPStruct: " + m_Il2CPPStruct.originalMethodPointer);
            unsafe
            {
                fixed (IntPtr* ptr = &m_Il2CPPStruct.originalMethodPointer){
                    IL2CPP.__IL2CPP_UNHOOK(ptr);
                }
            }
#else
            // Check if method is hooked
            if (m_original == null)
                return;

            // Restore original
            IntPtr origPtr = m_OriginalMethod.MethodHandle.GetFunctionPointer();

            if (m_Architecture == BITS.X64)
            {
                unsafe
                {
                    byte* ptr = (byte*)origPtr;
                    ptr[0] = m_original[0];
                    ptr[1] = m_original[1];
                    ptr[2] = m_original[2];
                    ptr[3] = m_original[3];
                    ptr[4] = m_original[4];
                    ptr[5] = m_original[5];
                    ptr[6] = m_original[6];
                    ptr[7] = m_original[7];
                    ptr[8] = m_original[8];
                    ptr[9] = m_original[9];
                    ptr[10] = m_original[10];
                    ptr[11] = m_original[11];
                }
            }
            else // if (m_Architecture == BITS.X86)
            {
                unsafe
                {
                    byte* ptr = (byte*)origPtr;
                    ptr[0] = m_original[0];
                    ptr[1] = m_original[1];
                    ptr[2] = m_original[2];
                    ptr[3] = m_original[3];
                    ptr[4] = m_original[4];
                    ptr[5] = m_original[5];
                    ptr[6] = m_original[6];
                }
            }

            m_original = null;
#endif
        }
    }
}