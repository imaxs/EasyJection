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
    using EasyJection.Types;
    using Hooking;
    #region Comment
    /// <summary>
    /// Contains the definitions of the binding factory.
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBindingFactory.Binder"/></term>
    ///         <description>Binder used by the binding factory.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.BindingType"/></term>
    ///         <description>The type being bound.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToSelf(bool)"/></term>
    ///         <description>Binds the key type to itself as a transient.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToSelf{T}(bool)"/></term>
    ///         <description>Binds the key type to a type of <typeparamref name="T"/> as a transient.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToSingleton(bool)"/></term>
    ///         <description>Binds the key type to itself as a singleton.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToSingleton{T}(bool)"/></term>
    ///         <description>Binds the key type to a type of <typeparamref name="T"/> as a singleton.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToSingleton(Type, bool)"/></term>
    ///         <description>Binds the key type to a <paramref name="type"/> as a singleton.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.To(Type)"/></term>
    ///         <description>Binds the key type to a <paramref name="type"/> as a transient.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.To{T}()"/></term>
    ///         <description>Binds the key type to a type of <typeparamref name="T"/> as a transient.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.To(Type, object)"/></term>
    ///         <description>Binds the key type to an <paramref name="instance"/> of a <paramref name="type"/> type.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToFactory{T}(bool)"/></term>
    ///         <description>Binds the key type to a <typeparamref name="T"/> factory.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToFactory(Type, bool)"/></term>
    ///         <description>Binds the key type to a factory of a certain <paramref name="type"/>.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.ToFactory(Types.IFactory)"/></term>
    ///         <description>Binds the key type to an <paramref name="instance"/> of a type which has implemented <see cref="Types.IFactory"/> interface.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.AddBinding(object)"/></term>
    ///         <description>Creates a binding.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingFactory.AddBinding(object, BindingInstanceType, bool)"/></term>
    ///         <description>Creates a binding.</description>
    ///     </item>
    /// </list>
    /// </summary>
    /// <remarks>Binding the key type to a type of its implementation or instance.</remarks>
    #endregion
    public interface IBindingFactory
    {
        /// <summary>Binder used by the binding factory.</summary>
        IBinder Binder { get; }

        /// <summary>The type being bound.</summary>
        Type BindingType { get; }

        /// <summary>
        /// Binds the key type to itself as a transient. 
        /// </summary>
        /// <remarks>⚠️ The key must be a class.</remarks>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToSelf(bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to a type of <typeparamref name="T"/> as a transient.
        /// </summary>
        /// <typeparam name="T">The related type.</typeparam>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToSelf<T>(bool UseDefaultConstructor = false) where T : class;

        /// <summary>
        /// Binds the key type to itself as a singleton.
        /// </summary>
        /// <remarks>⚠️ The key must be a class.</remarks>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToSingleton(bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to a type of <typeparamref name="T"/> as a singleton.
        /// </summary>
        /// <typeparam name="T">The related type.</typeparam>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToSingleton<T>(bool UseDefaultConstructor = false) where T : class;

        /// <summary>
        /// Binds the key type to a <paramref name="type"/> as a singleton.
        /// </summary>
        /// <param name="type">The related type.</param>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToSingleton(Type type, bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to a type of <typeparamref name="T"/> as a transient.
        /// </summary>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <typeparam name="T">The type to bind to.</typeparam>
        /// <returns>The binding condition object related to this binding.</returns>
        IBindingCondition To<T>(bool UseDefaultConstructor = false) where T : class;

        /// <summary>
        /// Binds the key type to a <paramref name="type"/> as a transient.
        /// </summary>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <param name="type">The related type.</param>
        /// <returns>The binding condition object related to this binding.</returns>
        IBindingCondition To(Type type, bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to an <paramref name="instance"/> of a <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">The related type.</typeparam>
        /// <param name="instance">The instance to bind the type to.</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToInstance<T>(T instance);

        /// <summary>
        /// Binds the key type to an <paramref name="instance"/> of a <paramref name="type"/> type.
        /// </summary>
        /// <param name="type">The related type.</param>
        /// <param name="instance">The instance to bind the type to.</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection To(Type type, object instance);

        /// <summary>
        /// Binds the key type to a <typeparamref name="T"/> factory.
        /// </summary>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <typeparam name="T">The type which has implemented <see cref="Types.IFactory"/> interface.</typeparam>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToFactory<T>(bool UseDefaultConstructor = false) where T : Types.IFactory;

        /// <summary>
        /// Binds the key type to a factory of a certain <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type which has implemented <see cref="Types.IFactory"/> interface.</param>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToFactory(Type type, bool UseDefaultConstructor = false);

        /// <summary>
        /// Binds the key type to an <paramref name="instance"/> of a type which has implemented <see cref="Types.IFactory"/> interface.
        /// </summary>
        /// <remarks><typeparamref name="T"/> - the type of instance that will be created by the factory.</remarks>
        /// <typeparam name="T">The type of instance that will be created by the <see cref="Types.IFactory"/> factory.</typeparam>
        /// <param name="instance">The instance of a type which has implemented <see cref="Types.IFactory"/> interface.</param>
        void ToFactory<T>(Types.IFactory instance) where T : class;

        /// <summary>
        /// Binds the key type to an <paramref name="instance"/> of a type which has implemented <see cref="Types.IFactory"/> interface.
        /// </summary>
        /// <param name="instance">The instance of a type which has implemented <see cref="Types.IFactory"/> interface.</param>
        void ToFactory(Types.IFactory instance);

        /// <summary>
        /// Binds the key type to a <typeparamref name="T"/> factory.
        /// </summary>
        /// <param name="methodName">The name of the method of your  <typeparamref name="T"/> factory that will create an instance.</param>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance of <typeparamref name="T"/> factory.</param>
        /// <typeparam name="T">The type of your factory.</typeparam>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection ToFactory<T>(string methodName, bool UseDefaultConstructor = false) where T : class;

        /// <summary>
        /// Creates a binding.
        /// </summary>
        /// <param name="value">Binding value.</param>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingCondition AddBinding(object value, bool UseDefaultConstructor);

        /// <summary>
        /// Creates a binding.
        /// </summary>
        /// <param name="value">Binding value.</param>
        /// <param name="instanceType">Binding instance type.</param>
        /// <param name="UseDefaultConstructor">Specifying the use of the default constructor to create an instance</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection AddBinding(object value, BindingInstanceType instanceType, bool UseDefaultConstructor);

        /// <summary>
        /// Creates a binding.
        /// </summary>
        /// <param name="type">The type of instance that will be created by the <see cref="Types.IFactory"/> factory.</param>
        /// <param name="factoryInstance">Factory creating instances</param>
        /// <returns>The binding injection object related to this binding.</returns>
        IBindingInjection AddFactoryInstance(Type type, IFactory factoryInstance);
    }
}
