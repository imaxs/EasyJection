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

using System.Reflection;

namespace EasyJection.Reflection
{
    #region Comment
    /// <summary>
    /// Contains the definitions of the <see cref="IMethodsData"/> interface.
    /// <para>Properties:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IMethodsData.MethodsInfo"/></term>
    ///         <description>The array of objects representing information about methods.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IMethodsData.MethodsParsInfo"/></term>
    ///         <description>The array of objects representing information about the parameters passed to methods.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IMethodsData.IsEmpty"/></term>
    ///         <description>Returns True if there is no data.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IMethodsData
    {
        /// <summary>The array of objects representing information about methods.</summary>
        MethodInfo[] MethodsInfo { get; }

        /// <summary>The array of objects representing information about the parameters passed to methods.</summary>
        /// <remarks>The index of <see cref="ParameterInfo"/> in the <see cref="MethodsParsInfo"/> array is identical to the index at which the <see cref="MethodInfo"/> is located in the <see cref="MethodsInfo"/> array.</remarks>
        ParameterInfo[][] MethodsParsInfo { get; }

        /// <summary>Returns True if there is no data.</summary>
        bool IsEmpty { get; }
    }
}