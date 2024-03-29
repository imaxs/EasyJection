﻿/*
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<TResult>)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this);
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T, TResult>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, TResult>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, T3, TResult>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, T3, T4, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][0];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][1];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][2];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][3];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][4];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][5];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][6];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][7];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][8];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)][9];
                            return (TResult)hookedMethod.HookManager.InvokeOriginalMethodResult(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }
}
