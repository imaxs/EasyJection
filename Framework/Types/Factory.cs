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

namespace EasyJection.Types
{
    using Binding;
    using Reflection.Utils;

    public interface IFectorySetter
    {
        void SetFactoryinstance(object factoryInstance);
    }

    public class Factory : IFactory, IFectorySetter
    {
        protected object factoryInstance;
        protected InstantiatorCall createInstance;
        public Factory(System.Reflection.MethodInfo methodInfo) 
        {
            this.createInstance = MethodMaker.CreateInstantinateMethod(methodInfo);
            this.factoryInstance = null;
        }

        public void SetFactoryinstance(object factoryInstance) 
        {
            this.factoryInstance = factoryInstance;
        }

        public object CreateInstance(IBindingData bindingData = null)
        {
            return this.createInstance(this.factoryInstance);
        }
    }
}
