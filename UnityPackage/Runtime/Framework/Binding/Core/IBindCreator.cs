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

namespace EasyJection
{
    #region Comment
    /// <summary>
    /// Contains the definitions of the binding creator.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBindCreator.Bind{T}"/></term>
    ///         <description>Binds a type to an implementation type or instance.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindCreator.Bind(Type)"/></term>
    ///         <description>Binds a type to an implementation type or instance</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IBindCreator
    {
        #region Comment
        /// <summary>
        /// Binds a type to an implementation type or instance
        /// </summary>
        /// <typeparam name="T">The type to be bound.</typeparam>
        /// <returns>An instance of the implementation of the <see cref="IBindingFactory"/> interface.</returns>
        #endregion
        IBindingFactory Bind<T>();// where T : class;

        #region Comment
        /// <summary>
        /// Binds a type to an implementation type or instance
        /// </summary>
        /// <param name="type">The type to be bound.</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingFactory"/> interface.</returns>
        #endregion
        IBindingFactory Bind(Type type);
    }
}