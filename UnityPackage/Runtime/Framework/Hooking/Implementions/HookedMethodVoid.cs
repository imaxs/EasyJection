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

namespace EasyJection.Hooking
{
    using Binding;
    public class HookedMethodVoid : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this);
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this);
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { value });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2, T3> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2, T3>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2, T3, T4> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2, T3, T4>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2, T3, T4, T5> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2, T3, T4, T5>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2, T3, T4, T5, T6> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }

    public class HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9> : HookedMethodBase
    {
        public HookedMethodVoid(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var binding = EasyJection.Container.Instance[instanceType];
                            var hookedMethod = binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(binding, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }
}
