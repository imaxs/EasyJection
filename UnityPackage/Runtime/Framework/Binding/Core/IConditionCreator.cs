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
    /// Contains the definitions of the condition creator.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IConditionCreator.Create(IBindingData, IBindingCondition)"/></term>
    ///         <description>Creates an instance of a specific binding condition.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IConditionCreator
    {
        #region Comment
        /// <summary>
        /// Creates an instance of a specific binding condition.
        /// </summary>
        /// <param name="bindingData">The binding data to which the conditions will apply.</param>
        /// <param name="bindingCondition">The instance of a class that implements <see cref="IBindingCondition"/>.</param>
        #endregion
        void Create(IBinder binder, IBindingData bindingData, IBindingCondition bindingCondition);
    }
}