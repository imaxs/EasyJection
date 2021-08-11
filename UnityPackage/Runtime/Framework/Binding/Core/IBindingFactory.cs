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
    /// Contains the definitions of the binding factory.
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBindingFactory.Initialize(Type, IBinder)"/></term>
    ///         <description>Initializes a new instance of the interface implementation.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.To(Type)"/></term>
    ///         <description>Binding to an implementing type.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.To{T}()"/></term>
    ///         <description>Binding to an implementing type.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToSelf"/></term>
    ///         <description>Creates an instance of itself.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IBindingFactory
    {
        #region Comment
        /// <summary>
        /// Initializes a new instance of the class that implements the IBindingFactory interface.
        /// </summary>
        /// <param name="bindingType">The type to be bound.</param>
        /// <param name="binder">The instance of the implementation IBinder interface that will bind this binding.</param>
        /// <returns>An instance of the implementation of the IBindingFactory interface.</returns>
        #endregion
        IBindingFactory Initialize(Type bindingType, IBinder binder);

        #region Comment
        /// <summary>
        /// Binding to an Implementing Type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of implementation to bind to.</typeparam>
        /// <returns>An instance of the implementation of the <see cref="IConditionBase"/> interface.</returns>
        #endregion
        IConditionBase To<T>();

        #region Comment
        /// <summary>
        /// Binding to an Implementing Type <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of implementation to bind to.</param>
        /// <returns>An instance of the implementation of the <see cref="IConditionBase"/> interface.</returns>
        #endregion
        IConditionBase To(Type type);

        #region Comment
        /// <summary>
        /// Creates an instance of itself.
        /// </summary>
        /// <remarks>
        /// The type that initializes the binding must be a class (reference type).
        /// </remarks>
        /// <returns>An instance of the implementation of the IConditionBase interface.</returns>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the type that initialized the binding is not a class (reference type).
        /// </exception>
        #endregion
        IConditionInstantiation ToSelf();
    }
}