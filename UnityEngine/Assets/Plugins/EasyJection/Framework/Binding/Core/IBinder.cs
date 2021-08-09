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

namespace EasyJection
{
    #region Comment
    /// <summary>
    /// Inherits <see cref="IBindCreator"/><br/>
    /// <inheritdoc/>
    /// Contains the definitions of a binder that binds a type to an implementation type or instance.
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBinder.AddBinding(Type, IBindingData)"/></term>
    ///         <description>Add type binding to data.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBinder.GetAllBindings"/></term>
    ///         <description>Gets all bindings.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBinder.Get(Type)"/></term>
    ///         <description>Gets <see cref="IBindingData"/> of a specific <see cref="Type"/>.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IBinder : IBindCreator
    {
        #region Comment
        /// <summary>
        /// The container containing a binding.
        /// </summary>
        #endregion
        IContainer Container { get; }

        #region Comment
        /// <summary>
        /// Add type binding to data.
        /// </summary>
        /// <param name="type">The type to be bound.</param>
        /// <param name="bindingData">Binding data to be added.</param>
        #endregion
        void AddBinding(Type type, IBindingData bindingData);

        #region Comment
        /// <summary>
        /// Gets all <see cref="IBindingData"/> 
        /// </summary>
        /// <returns><see cref="IList"/> of <see cref="IBindingData"/>.</returns>
        #endregion
        IList<IBindingData> GetAllBindings();

        #region Comment
        /// <summary>
        /// Gets <see cref="IBindingData"/> of a specific <see cref="Type"/>
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IBindingData"/> interface.</returns>
        #endregion
        IBindingData Get(Type type);
    }
}