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

namespace EasyJection.Reflection
{
    /// <inheritdoc cref="IReflectionCache"/>
    public class ReflectionCache : IReflectionCache
    {
        /// <summary>Gets the <see cref="IReflectedData"/> with the specified type.</summary>
        public IReflectedData this[Type type] { get { return this.GetClass(type); } }

        /// <inheritdoc cref="IReflectionCache.reflectionFactory"/>
        public IReflectionFactory reflectionFactory { get; set; }

        /// <summary>Reflected objects on the cache.</summary>
        private Dictionary<Type, IReflectedData> reflects;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionCache"/> class.
        /// </summary>
        public ReflectionCache()
        {
            this.reflects = new Dictionary<Type, IReflectedData>();
            this.reflectionFactory = this.ReflectionFactoryProvider();
        }

        /// <inheritdoc cref="IReflectionCache.Add(Type)"/>
        public void Add(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!this.Contains(type))
                AddUnique(type);
        }

        private IReflectedData AddUnique(Type type)
        {
            IReflectedData reflectedData = this.reflectionFactory.Create(type);
            this.reflects.Add(type, reflectedData);

            return reflectedData;
        }

        /// <inheritdoc cref="IReflectionCache.Remove(Type)"/>
        public void Remove(Type type)
        {
            if (this.Contains(type))
                this.reflects.Remove(type);
        }

        /// <inheritdoc cref="IReflectionCache.GetClass(Type)"/>
        public IReflectedData GetClass(Type type)
        {
            if (!this.Contains(type))
                return this.AddUnique(type);

            return this.reflects[type];
        }

        /// <inheritdoc cref="IReflectionCache.Contains(Type)"/>
        public bool Contains(Type type)
        {
            return this.reflects.ContainsKey(type);
        }

        /// <summary>
        /// Resolves the reflection factory provider.
        /// </summary>
        /// <returns>The reflection factory provider.</returns>
        protected virtual IReflectionFactory ReflectionFactoryProvider()
        {
            return new ReflectionFactory();
        }

        public void Clear()
        {
            foreach(var d in this.reflects)
                d.Value.Dispose();

            this.reflects.Clear();
        }
    }
}
