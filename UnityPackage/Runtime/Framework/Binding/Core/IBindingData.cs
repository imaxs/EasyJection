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
    /// The type of the binding instance. 
    /// <para>Enums:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="BindingInstanceType.Transient"/></term>
    ///         <description>Doesn't re-use the instance. Each time during instantiation, the construction method will execute again.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="BindingInstanceType.Single"/></term>
    ///         <description>Reuses the instance. The same instance is given during dependency injection.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="BindingInstanceType.Itself"/></term>
    ///         <description>The type of the binding instance.</description>
    ///     </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <c>This value determines how often the created instance is reused across multiple injections.</c>
    /// <br/>Default: <see cref="BindingInstanceType.Transient"/>
    /// </remarks>
    #endregion
    [Flags]
    public enum BindingInstanceType
    {
        #region Comment
        /// <summary>Doesn't re-use the instance. Each time during instantiation, the construction method will execute again.</summary>
        /// <remarks><c>This value is used by default when creating bindings.</c></remarks>
        #endregion
        Transient = 0,

        #region Comment
        /// <summary>Reuses the instance. The same instance is given during dependency injection.</summary>
        /// <remarks><c>Used as a singleton.</c></remarks>
        #endregion
        Single = 1,

        #region Comment
        /// <summary>
        /// The instance to which the injection is applied is added to the binding using this type.
        /// <example>
        /// <para>Example:</para>
        /// <br/>var binder = new Binder();
        /// <br/>binder.Bind&lt;'SomeClass'&gt;().To &lt;'SomeClass'&gt;().As(<see cref="BindingInstanceType.Itself"/>);
        /// <br/>Or
        /// <br/>binder.Bind&lt;'SomeClass'&gt;().ToSelf();
        /// </example>
        /// </summary>
        /// <remarks>
        /// <c>Even if the instance type was not previously added to the binding manually.</c>
        /// </remarks>
        #endregion
        Itself = 2
    }

    #region Comment
    /// <summary>
    /// Contains the definitions of the binding data
    /// <para>Properties:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBindingData.Type"/></term>
    ///         <description>The type to which the binding will be bound.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.Arguments"/></term>
    ///         <description>Arguments that can be passed to the constructor when initializing the implementor instance.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.ArgumentTypes"/></term>
    ///         <description>Argument types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.InstanceType"/></term>
    ///         <description>The type of the binding instance.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.InstancesFactory"/></term>
    ///         <description>An instance that implements IInstancesFactory interface for creating instances of a specific type.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.ConstructorName"/></term>
    ///         <description>The name of the method that is called as a constructor.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.IsAutoInjectionEnabled"/></term>
    ///         <description>If True, the injection will be done via hook.</description>
    ///     </item>
    /// </list>
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBindingData.SetInstanceType(BindingInstanceType)"/></term>
    ///         <description>Sets / updates the type value of the <see cref="BindingInstanceType"/>.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.SetConstructorName(string)"/></term>
    ///         <description>Sets / updates the name of the method that is called as a constructor.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.SetArguments(object[])"/></term>
    ///         <description>Sets / updates the arguments to be passed to create / retrieve an instance.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.SetArgumentTypes(Type[])"/></term>
    ///         <description>Sets / updates the argument types to be passed to constructor method of an instance.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IBindingData
    {
        /// <summary>The type to which the binding will be bound.</summary>
        Type Type{ get; }
        /// <summary>Arguments that can be passed to the constructor when initializing the implementor instance.</summary>
        Object[] Arguments { get; }
        /// <summary>Argument types.</summary>
        Type[] ArgumentTypes { get; }
        /// <summary>The type of the binding instance.</summary>
        BindingInstanceType InstanceType { get; }
        /// <summary>An instance that implements IInstancesFactory interface for creating instances of a specific type.</summary>
        IInstancesFactory InstancesFactory { get; } 
        /// <summary>The name of the method that is called as a constructor.</summary>
        String ConstructorName { get; }
        /// <summary>If True, the injection will be done via hook.</summary>
        bool IsAutoInjectionEnabled { get; set; }

        #region Comment
        /// <summary>
        /// Sets / updates the type value of the <see cref="BindingInstanceType"/>.
        /// </summary>
        /// <param name="instanceType">The type of the binding instance.</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingData"/> interface.</returns>
        #endregion
        IBindingData SetInstanceType(BindingInstanceType instanceType);

        #region Comment
        /// <summary>
        /// Sets / updates the name of the method that is called as a constructor.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingData"/> interface.</returns>
        #endregion
        IBindingData SetConstructorName(string methodName);

        #region Comment
        /// <summary>
        /// Sets / updates the arguments to be passed to create / retrieve an instance.
        /// </summary>
        /// <param name="arguments">Arguments that can be passed to the constructor when initializing the implementor instance.</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingData"/> interface.</returns>
        #endregion
        IBindingData SetArguments(Object[] arguments, Type[] types = null);

        #region Comment
        /// <summary>
        /// Sets / updates the argument types to be passed to constructor method of an instance.
        /// </summary>
        /// <param name="types">Array of argument types.</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingData"/> interface.</returns>
        #endregion
        IBindingData SetArgumentTypes(Type[] types);
    }
}