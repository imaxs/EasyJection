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

namespace EasyJection.Reflection
{
    /// <summary>
    /// Defines a cache for reflection data.
    /// 
    /// The idea of this cache is to reduce the execution of reflection by caching data about types.
    /// 
    /// The cache should always look for constructors and Inject attributes.
    /// </summary>
    public interface IReflectionCache
    {
        /// <summary>Gets the <see cref="IReflectedData"/> with the specified type.</summary>
        IReflectedData this[Type type] { get; }

        /// <summary>Reflection factory used to generate items on the cache.</summary>
        IReflectionFactory reflectionFactory { get; set; }

        /// <summary>
        /// Adds a type to the cache.
        /// </summary>
        /// <param name="type">Type to be added.</param>
        void Add(Type type);

        /// <summary>
        /// Removes a type from the cache.
        /// </summary>
        /// <param name="type">Type to be removed.</param>
        void Remove(Type type);

        /// <summary>
        /// Gets an<see cref="IReflectedData"/> for a certain type.
        /// </summary>
        /// <remarks>If the type being getted doesn't exist, it'll be created.</remarks>
        /// <param name="type">Type to look for.</param>
        /// <returns>Reflected type data.</returns>
        IReflectedData GetClass(Type type);

        /// <summary>
        /// Checks whether a cache exists for a certain type.
        /// </summary>
        /// <param name="type">Type to be removed.</param>
        /// <returns>True or False</returns>
        bool Contains(Type type);
    }
}
