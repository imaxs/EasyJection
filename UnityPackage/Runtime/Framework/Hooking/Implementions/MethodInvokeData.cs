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

namespace EasyJection.Hooking
{
    public class MethodInvokeData : IMethodInvokeData
    {
        protected IHookedMethod hookedMethod;
        public object[] ArgumentsObjects { get; set; }

        public Type[] ArgumentTypes { get; set; }

        public IHookedMethod HookedMethod { get => hookedMethod; }

        public MethodInvokeData(IHookedMethod hookedMethod) 
        {
            this.hookedMethod = hookedMethod;
        }
    }
}
