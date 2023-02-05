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

namespace EasyJection.Binding
{
    using Hooking;
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
        /// <summary>Binder used by the Binding Factory.</summary>
        IBinder Binder { get; }

        /// <summary>The type being bound.</summary>
        Type BindingType { get; }

        /// <summary>
        /// Binds the key type to a transient of itself. ⚠️ The key must be a class. 
        /// </summary>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding constructor object related to this binding.</returns>
        IBindingInjection ToSelf(bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to a transient of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The related type.</typeparam>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding constructor object related to this binding.</returns>
        IBindingInjection ToSelf<T>(bool UseDefaultConstructor = false) where T : class;

        /// <summary>
        /// Binds the key type to a singleton of itself. ⚠️ The key must be a class.
        /// </summary>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding constructor object related to this binding.</returns>
        IBindingInjection ToSingleton(bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to a singleton of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The related type.</typeparam>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding constructor object related to this binding.</returns>
        IBindingInjection ToSingleton<T>(bool UseDefaultConstructor = false) where T : class;

        /// <summary>
        /// Binds the key type to a singleton of type <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The related type.</param>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding constructor object related to this binding.</returns>
        IBindingInjection ToSingleton(Type type, bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to a transient of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to bind to.</typeparam>
        /// <returns>The binding condition object related to this binding.</returns>
        IBindingCondition To<T>() where T : class;

        /// <summary>
        /// Binds the key type to a transient of type <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The related type.</param>
        /// <returns>The binding condition object related to this binding.</returns>
        IBindingCondition To(Type type);

        /// <summary>
        /// Binds the key type to an <paramref name="instance"/>.
        /// </summary>
        /// <typeparam name="T">The related type.</typeparam>
        /// <param name="instance">The instance to bind the type to.</param>
        void ToInstance<T>(T instance);

        /// <summary>
        /// Binds the key type to an <paramref name="instance"/>.
        /// </summary>
        /// <param name="type">The related type.</param>
        /// <param name="instance">The instance to bind the type to.</param>
        /// <returns>The binding constructor object related to this binding.</returns>
        IBindingInjection To(Type type, object instance);

        /// <summary>
        /// Binds the key type to a <typeparamref name="T"/> factory.
        /// </summary>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <typeparam name="T">The type which has implemented <see cref="Types.IFactory"/> interface.</typeparam>
        IBindingInjection ToFactory<T>(bool UseDefaultConstructor = false) where T : Types.IFactory;

        /// <summary>
        /// Binds the key type to a factory of a certain <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type which has implemented <see cref="Types.IFactory"/> interface.</param>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        IBindingInjection ToFactory(Type type, bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to a <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">The instance of a type which has implemented <see cref="Types.IFactory"/> interface.</param>
        void ToFactory(Types.IFactory instance);

        /// <summary>
        /// Creates a binding.
        /// </summary>
        /// <returns>The binding condition object related to this binding.</returns>
        /// <param name="value">Binding value.</param>
        IBindingCondition AddBinding(object value);

        /// <summary>
        /// Creates a binding.
        /// </summary>
        /// <returns>The binding constructor object related to this binding.</returns>
        /// <param name="value">Binding value.</param>
        /// <param name="instanceType">Binding instance type.</param>
        /// /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        IBindingInjection AddBinding(object value, BindingInstanceType instanceType, bool UseDefaultConstructor);
    }
}
