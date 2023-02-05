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
using System.Collections.Generic;

namespace EasyJection.Hooking
{
    using Binding;
    public class HookedMethodResult<TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this);
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this);
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { value });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, T3, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, T3, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, T3, T4, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, T3, T4, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, T3, T4, T5, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }

    public class HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : HookedMethodBase
    {
        public HookedMethodResult(IHookContainer container, MethodBase original)
        {
            var type = typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>);
            System.Reflection.MethodInfo info = null;
            switch (container[type] == null ? 0 : container[type].Count)
            {
                case 0:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var binding = EasyJection.Container.Instance[this.GetType()];
                            var hookedMethod = binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
            }
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
            container.AddHook(type, this);
        }
    }
}
