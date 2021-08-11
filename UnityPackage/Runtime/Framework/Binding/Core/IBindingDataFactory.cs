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
    /// <para>Properties:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBindingDataFactory.BindingFactory"/></term>
    ///         <description>The instance of the implementation <see cref="IBindingFactory"/> interface.</description>
    ///     </item>
    /// </list>
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IBindingDataFactory.CreateInstance(Type)"/></term>
    ///         <description>Create a new instance of the <see cref="IBindingData"/> interface implementation.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IBindingDataFactory
    {
        /// <summary>The instance of the implementation <see cref="IBindingFactory"/> interface.</summary>
        IBindingFactory BindingFactory { get; }

        #region Comment
        /// <summary>
        /// Create a new instance of the <see cref="IBindingData"/> interface implementation.
        /// </summary>
        /// <param name="type">The type to which the binding will be bound.</param>
        /// <returns>An instance of the <see cref="IBindingData"/> interface implementation.</returns>
        #endregion
        IBindingData CreateInstance(Type type);
    }
}