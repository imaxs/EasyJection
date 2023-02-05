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
using System.Reflection;

namespace EasyJection.Reflection
{
    #region Comment
    /// <summary>
    /// Contains the definitions of the <see cref="IReflectedData"/> interface.
    /// <para>Properties:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IReflectedData.Type"/></term>
    ///         <description>Gets the current <see cref="System.Type"/> of the current instance.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IReflectedData.ConstructorsData"/></term>
    ///         <description>The instance of representing information about constructors.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IReflectedData.PropertiesInfo"/></term>
    ///         <description>The array of objects representing information about properties.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IReflectedData.FieldsInfo"/></term>
    ///         <description>The array of objects representing information about fields.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IReflectedData.MethodsData"/></term>
    ///         <description>The instance of representing information about methods.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IReflectedData
    {
        /// <summary>Gets the current <see cref="System.Type"/> of the current instance.</summary>     
        Type Type { get; }

        /// <summary>The instance of representing information about constructors.</summary>
        IConstructorsData ConstructorsData { get; }

        /// <summary>The array of objects representing information about properties.</summary>
        AccessoriesInfo[] PropertiesInfo { get; }

        /// <summary>The array of objects representing information about fields.</summary>
        AccessoriesInfo[] FieldsInfo { get; }

        /// <summary>The instance of representing information about methods.</summary>
        IMethodsData MethodsData { get; }
    }
}