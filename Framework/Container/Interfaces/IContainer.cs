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

using EasyJection.Binding;
using EasyJection.Resolving;
using System;

namespace EasyJection
{
    /// <summary>
    /// Defines a container for dependency injection.
    /// </summary>
    /// <remarks>A container holds binding references, resolves types and injects dependencies.</remarks>
    public interface IContainer : IBindCreator, IResolver, IDisposable
    {
        /// <summary>
        /// Initializes the container.
        /// </summary>
        /// <remarks>
        /// Should be called after adding all extensions and bindings.
        /// </remarks>
        void Init();

        IBindingData this[Type type] { get; }
    }
}
