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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action)(() =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this);
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T>)((T value) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { value });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2>)((T1 val1, T2 val2) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2 });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2, T3>)((T1 val1, T2 val2, T3 val3) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3 });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2, T3, T4>)((T1 val1, T2 val2, T3 val3, T4 val4) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4 });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2, T3, T4, T5>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5 });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6 });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7 });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8 });
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
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][0];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 1:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][1];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 2:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][2];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 3:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][3];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 4:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][4];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 5:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][5];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 6:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][6];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 7:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][7];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 8:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][8];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
                case 9:
                    {
                        info = ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)((T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6, T7 val7, T8 val8, T9 val9) =>
                        {
                            var instanceType = this.GetType(); var data = EasyJection.Containers.Get(instanceType);
                            var hookedMethod = data.Value.binding[typeof(HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>)][9];
                            hookedMethod.HookManager.InvokeOriginalMethodVoid(data, this, new object[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
                        })).Method;
                    }
                    break;
            }
            container.AddHook(type, this);
            hookManager = new HookManager(new MethodInvokeData(this), info, original);
        }
    }
}
