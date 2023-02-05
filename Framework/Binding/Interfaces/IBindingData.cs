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

namespace EasyJection.Binding
{
    using Hooking;
    using Reflection;
    using System.Collections;

    #region Comment
    /// <summary>
    /// The type of the binding instance. 
    /// <para>Enums:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="BindingInstanceType.Transient"/></term>
    ///         <description>A new instance is given during dependency resolution.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="BindingInstanceType.Singleton"/></term>
    ///         <description>The same instance is given during dependency injection.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="BindingInstanceType.Factory"/></term>
    ///         <description>The instance to which the injection is applied is added to the binding using this type..</description>
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
        /// <summary>A new instance is given during dependency resolution.</summary>
        /// <remarks><c>This value is used by default when creating bindings.</c></remarks>
        #endregion
        Transient = 1 << 0,

        #region Comment
        /// <summary>The same instance is given during dependency injection.</summary>
        /// <remarks><c>Used as a singleton.</c></remarks>
        #endregion
        Singleton = 1 << 1,

        #region Comment
        /// <summary>The instance to which the injection is applied is added to the binding using this type.</summary>
        #endregion
        Factory = 1 << 2,

        Instance = 1 << 3
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
    ///         <term><see cref="IBindingData.Value"/></term>
    ///         <description>Value to which the binding is bound to.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IBindingData.InstanceType"/></term>
    ///         <description>The type of the binding instance.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IBindingData
    {
        /// <summary>Type from which the binding is bound to.</summary>
        Type Type { get; }

        /// <summary>Value to which the binding is bound to.</summary>
        object Value { get; set; }

        /// <summary>The constructor that is used to create an instance of the specified type.</summary>
        ConstructorInfo InstantiationConstructor { get; set;  }

        /// <summary>The type of the binding instance.</summary>
        BindingInstanceType InstanceType { get; set; }

        /// <summary>The dictionary contains instances of the 'IHookedMethod' implementation</summary>
        IDictionary<System.Reflection.MethodBase, IHookedMethod> HookedMethods { get; set; }

        IHookContainer HookContainer { get; set; }

        IList<IHookedMethod> this[Type hookedMethodType] { get; }

        IHookedMethod this[System.Reflection.MethodBase methodBase] { get; }
    }
}