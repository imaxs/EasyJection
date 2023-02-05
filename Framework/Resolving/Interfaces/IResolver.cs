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

namespace EasyJection.Resolving
{
    public interface IResolver
    {
        /// <summary>
        /// Resolves an instance for the specified type.
        /// </summary>
        /// <typeparam name="T">The type to be resolved.</typeparam>
        /// <returns>The instance or NULL.</returns>
        T Resolve<T>();

        /// <summary>
        /// Resolves an instance for the specified type.
        /// </summary>
        /// <param name="type">The type to be resolved.</param>
        /// <returns>The instance or NULL.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolves an array of objects, this occurs for each item if it has a null value
        /// </summary>
        /// <param name="objects">Array of objects requiring resolving.</param>
        /// /// <param name="types">Array of types of these objects.</param>
        /// <returns>The array of resolved items</returns>
        object[] Resolve(object[] objects, Type[] types);

        /// <summary>
        /// Injects  dependencies to an instance of an object.
        /// </summary>
        /// <param name="instance">Instance to receive injection.</param>
        void Inject(object instance);
    }
}
