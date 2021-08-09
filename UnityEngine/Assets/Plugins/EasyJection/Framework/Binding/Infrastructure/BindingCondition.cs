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
    /// <summary>
    /// Implements interface <see cref="IBindingCondition"/><br/>
    /// <inheritdoc cref="IBindingCondition"/>
    /// </summary>
    public class BindingCondition : IBindingCondition
    {
        private readonly IBindingFactory m_BindingFactory;
        /// <summary>The instance of a class that implements <see cref="IBindingFactory"/>.</summary>
        public IBindingFactory BindingFactory { get => m_BindingFactory; }

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="BindingCondition"/> class.
        /// </summary>
        /// <param name="bindingFactory">The instance of a class that implements <see cref="IBindingFactory"/>.</param>
        #endregion
        public BindingCondition(IBindingFactory bindingFactory)
        {
            m_BindingFactory = bindingFactory;
        }

        /// <inheritdoc cref="IBindingCondition.Initialize{T}(IBindingData)"/>
        public T Initialize<T>(IBinder binder, IBindingData bindingData) where T : IConditionCreator, new()
        {
            T condition = new T();
            condition.Create(binder, bindingData, this);
            return condition;
        }
    }
}