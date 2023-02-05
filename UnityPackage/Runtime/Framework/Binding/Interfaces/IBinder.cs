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
using System.ComponentModel;

namespace EasyJection.Binding
{
    #region Comment
    /// <summary>
    /// Inherits <see cref="IBindCreator"/><br/>
    /// <inheritdoc/>
    /// Contains the definitions of a binder that binds a type to an implementation type or instance.
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBinder.AddBinding(IBindingData)"/></term>
    ///         <description>Add type binding to data.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBinder.GetBindings"/></term>
    ///         <description>Gets all bindings.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBinder.GetBindingFor(Type)"/></term>
    ///         <description>Gets the bindings for a given <see cref="Type"/>.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBinder.GetBindingFor{T}"/></term>
    ///         <description>Gets the bindings for a given <see cref="{T}"/>.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBinder.ContainsBindingFor(Type)"/></term>
    ///         <description>Checks whether this binder contains a binding for a given <see cref="Type"/>.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBinder.ContainsBindingFor{T}"/></term>
    ///         <description>Checks whether this binder contains a binding for a given <see cref="{T}"/>.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IBinder : IBindCreator
    {
        #region Comment
        /// <summary>
        ///  Add type binding to data.
        /// </summary>
        /// <param name="bindingData">The <see cref="IBindingData"/> instance to be added.</param>
        #endregion
        void AddBinding(IBindingData bindingData);

        #region Comment
        /// <summary>
        /// Gets all <see cref="IBindingData"/> 
        /// </summary>
        /// <returns><see cref="System.Collections.Generic.IList"/> of <see cref="IBindingData"/>.</returns>
        #endregion
        IList<IBindingData> GetBindings();

        #region Comment
        /// <summary>
        /// Gets the bindings for a given <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to get the bindings from.</typeparam>
        /// <returns>The binding for the desired type.</returns>
        #endregion
        IBindingData GetBindingFor<T>();

        #region Comment
        /// <summary>
        /// Gets the bindings for a given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type to get the bindings from.</param>
        /// <returns>The binding for the desired type.</returns>
        #endregion
        IBindingData GetBindingFor(Type type);

        #region Comment
        /// <summary>
        /// Checks whether this binder contains a binding for a given <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="type">The type to be checked.</typeparam>
        /// <returns><c>true</c>, if binding was contained, <c>false</c> otherwise.</returns>
        #endregion
        bool ContainsBindingFor<T>();

        #region Comment
        /// <summary>
        /// Checks whether this binder contains a binding for a given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type to be checked.</param>
        /// <returns><c>true</c>, if binding was contained, <c>false</c> otherwise.</returns>
        #endregion
        bool ContainsBindingFor(Type type);
    }
}
