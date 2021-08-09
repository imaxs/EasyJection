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
 
namespace EasyJection
{
    #region Comment
    /// <summary>
    /// Contains the definitions of the <see cref="IAssemblyReflectedData"/> interface.
    /// <para>Properties:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IAssemblyReflectedData.Namespace"/></term>
    ///         <description>The Namespace name.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IAssemblyReflectedData.Length"/></term>
    ///         <description>Gets the number of <see cref="IReflectedData"/> elements contained in the array.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IAssemblyReflectedData.ref ReflectedData"/></term>
    ///         <description>Gets the <see cref="IReflectedData"/> at the specified index.</description>
    ///     </item>
    /// </list>
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IAssemblyReflectedData.Add(in ReflectedData)"/></term>
    ///         <description>Adds <see cref="IReflectedData"/> to the <see cref="IAssemblyReflectedData"/>'s internal array.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IAssemblyReflectedData.GetIndex(string)"/></term>
    ///         <description>Gets the index by type name.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IAssemblyReflectedData
    {
        /// <summary>The Namespace name.</summary>
        string Namespace { get; }
        /// <summary>Gets the number of <see cref="IReflectedData"/> elements contained in the array.</summary>
        int Length { get; }
        /// <summary>Gets the <see cref="IReflectedData"/> at the specified index.</summary>
        ref ReflectedData this[int index] { get; }

        #region Comment
        /// <summary>
        /// Adds <see cref="IReflectedData"/> to the <see cref="IAssemblyReflectedData"/>'s internal array.
        /// </summary>
        /// <param name="reflectedData">An instance of the implementation of the <see cref="IReflectedData"/> interface.</param>
        /// <returns>An index of the added instance in the internal array.</returns>
        #endregion
        int Add(in ReflectedData reflectedData);

        #region Comment
        /// <summary>
        /// Sets / updates the type value of the <see cref="BindingInstanceType"/>.
        /// </summary>
        /// <param name="typeName">The string containing the name of the required type.</param>
        /// <returns>Gets the index by type name.</returns>
        #endregion
        int GetIndex(string typeName);
    }
}