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
    /// Inherits <see cref="IConditionCreator"/><br/>
    /// <inheritdoc/>
    /// Contains the definitions of the binding condition for the binding.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IConditionBase.As(BindingInstanceType)"/></term>
    ///         <description>Specifies the type of the binding instance.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IConditionBase : IConditionInstantiation
    {
        #region Comment
        /// <summary>
        /// Specifies the type of the binding instance.
        /// </summary>
        /// <param name="bindingInstanceType">The type of the binding instance.</param>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation As(BindingInstanceType bindingInstanceType);

        #region Comment
        /// <summary>
        /// Defines the binding instance type as <see cref="BindingInstanceType.Single"/>
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation AsSingle();
    }
}