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
    /// Contains the definitions of the <see cref="IConstructorsData"/> interface.
    /// <para>Properties:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IConstructorsData.ConstructorsInfo"/></term>
    ///         <description>The array of objects representing information about constructors.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConstructorsData.ConstructorsParsInfo"/></term>
    ///         <description>The array of objects representing information about the parameters passed to constructors.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IConstructorsData
    {
        /// <summary>The array of objects representing information about constructors.</summary>
        ConstructorInfo[] ConstructorsInfo { get; }
        /// <summary>The array of objects representing information about the parameters passed to constructors.</summary>
        /// <remarks>The index of <see cref="ParameterInfo"/> in the <see cref="ConstructorsParsInfo"/> array is identical to the index at which the <see cref="ConstructorInfo"/> is located in the <see cref="ConstructorsInfo"/> array.</remarks>
        ParameterInfo[][] ConstructorsParsInfo { get; }
    }
}