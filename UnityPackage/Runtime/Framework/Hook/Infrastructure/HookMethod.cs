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

namespace EasyJection
{
    public class HookMethod
    {
        public static MethodInfo InjectedMethod;
        static HookMethod()
        {
            Type type = typeof(HookMethod);
            ReflectedId reflectedId = type.Reflect();
            ReflectedData reflectedData = reflectedId.GetData();
            MethodData injectedMethodData = reflectedData.GetMethod(0);
            InjectedMethod = injectedMethodData.Info;
        }

        private void Method()
        {
            HookData hookData = EasyJection.Hook.Cache.Get(this.GetType());
            if (!hookData.IsEmpty)
            {
                // Call original method
                hookData.Hook.Unhooked();
                hookData.Hook.OriginalMethod.Invoke(this, hookData.Hook.Arguments);

                // Injected code
                hookData.Hook.Container.Inject(this);
                hookData.Hook.Hooked();
            }
        }
    }
}