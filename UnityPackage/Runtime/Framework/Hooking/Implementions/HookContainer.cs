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
using System.Collections.Generic;

namespace EasyJection.Hooking
{  
    public class HookContainer : IHookContainer
    {
        protected IDictionary<Type, IList<IHookedMethod>> dict;

        public HookContainer()
        {
            dict = new Dictionary<Type, IList<IHookedMethod>>();
        }

        public IList<IHookedMethod> this[Type type]
        {
            get => dict.ContainsKey(type) ? dict[type] : null;
        }

        public void AddHook(Type key, IHookedMethod hookMethod)
        {
            var list = this[key];

            if (list == null)
                dict.Add(key, new List<IHookedMethod>() { hookMethod });
            else
                list.Add(hookMethod);
        }
    }
}