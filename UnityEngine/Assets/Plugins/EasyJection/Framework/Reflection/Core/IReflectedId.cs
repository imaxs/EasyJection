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
    /// Contains the definitions of the <see cref="IReflectedId"/> interface.
    /// <para>Properties:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IReflectedId.NamespaceId"/></term>
    ///         <description>The namespace index value of the parent element in the list of cached reflection data.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IReflectedId.TypeNameId"/></term>
    ///         <description>The type index value of the parent element in the list of cached reflection data.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IReflectedId.IsEmpty"/></term>
    ///         <description>Determine if it's equal to empty value.</description>
    ///     </item>
    /// </list>
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IReflectedId.Equals(in ReflectedId)"/></term>
    ///         <description>Determines whether two <see cref="IReflectedId"/> instances are equal.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IReflectedId
    {
        /// <summary>The namespace index value of the parent element in the list of cached reflection data.</summary>
        int NamespaceId { get; }
        /// <summary>The type index value of the parent element in the list of cached reflection data.</summary>
        int TypeNameId { get; }
        /// <summary>Returns true if it's empty value.</summary>
        bool IsEmpty { get; }

        #region Comment
        /// <summary>
        /// Determines whether two <see cref="IReflectedId"/> instances are equal.
        /// </summary>
        /// <param name="reflectedId">An instance of the implementation of the <see cref="IReflectedId"/> interface.</param>
        /// <returns>True or False Value.</returns>
        #endregion
        bool Equals(in ReflectedId reflectedId);
    }
}