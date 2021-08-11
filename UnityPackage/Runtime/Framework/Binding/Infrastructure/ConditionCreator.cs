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
    /// Implements interface <see cref="IConditionCreator"/><br/>
    /// <inheritdoc cref="IConditionCreator"/>
    /// </summary>
    public abstract class ConditionCreator : IConditionCreator
    {
        /// <summary>Binder is used through the Binding Factory.</summary>
        protected IBinder m_Binder;
        /// <summary>Contains the definitions of the binding data.</summary>
        protected IBindingData m_BindingData;
        /// <summary>The instance of a class that implements <see cref="IBindingCondition"/>.</summary>
        protected IBindingCondition m_BindingCondition;

        /// <inheritdoc cref="IConditionCreator.Create(IBindingData, IBindingCondition)"/>
        public void Create(IBinder binder, IBindingData bindingData, IBindingCondition bindingCondition)
        {
            m_Binder = binder;
            m_BindingData = bindingData;
            m_BindingCondition = bindingCondition;
        }
    }
}