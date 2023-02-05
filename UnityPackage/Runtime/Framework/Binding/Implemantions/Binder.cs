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
using System.Collections.Generic;
using System.Linq;

namespace EasyJection.Binding
{
    /// <summary>
    /// Binds a type to another type or instance.
    /// </summary>
    public class Binder : IBinder
    {
        /// <summary>Type bindings of the binder.</summary>
        protected Dictionary<Type, IBindingData> typeBindings = new Dictionary<Type, IBindingData>();

        /// <inheritdoc cref="IBinder.AddBinding"/>
        public void AddBinding(IBindingData bindingData)
        {
            this.AddOrUpdate(bindingData);
        }

        /// <inheritdoc cref="IBindCreator.Bind{T}"/>
        public IBindingFactory Bind<T>()
        {
            return this.Bind(typeof(T));
        }

        /// <inheritdoc cref="IBindCreator.Bind"/>
        public IBindingFactory Bind(Type type)
        {
            return this.BindingFactoryProvider(type);
        }

        /// <inheritdoc cref="IBinder.ContainsBindingFor{T}"/>
        public bool ContainsBindingFor<T>()
        {
            return this.ContainsBindingFor(typeof(T));
        }

        /// <inheritdoc cref="IBinder.ContainsBindingFor"/>
        public bool ContainsBindingFor(Type type)
        {
            return this.typeBindings.ContainsKey(type);
        }

        /// <inheritdoc cref="IBinder.GetBindingFor{T}"/>
        public IBindingData GetBindingFor<T>()
        {
            return this.GetBindingFor(typeof(T));
        }

        /// <inheritdoc cref="IBinder.GetBindingFor"/>
        public IBindingData GetBindingFor(Type type)
        {
            if (this.typeBindings.ContainsKey(type))
                return this.typeBindings[type];
            else
                return null;
        }

        /// <inheritdoc cref="IBinder.GetBindings"/>
        public IList<IBindingData> GetBindings()
        {
            return typeBindings.Values.ToList();
        }

        protected void AddOrUpdate(IBindingData bindingData)
        {
            if (this.typeBindings.ContainsKey(bindingData.Type))
                this.typeBindings[bindingData.Type] = bindingData;
            else
                this.typeBindings.Add(bindingData.Type, bindingData);
        }

        /// <summary>
        /// Resolves the binding provider.
        /// </summary>
        /// <param name="type">The type being bound.</param>
        /// <returns>The binding provider.</returns>
        protected virtual IBindingFactory BindingFactoryProvider(Type type)
        {
            return new BindingFactory(type, this);
        }
    }
}
