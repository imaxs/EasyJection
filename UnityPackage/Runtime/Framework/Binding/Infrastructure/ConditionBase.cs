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
    /// Implements interface <see cref="IConditionBase"/><br/>
    /// <inheritdoc cref="IConditionBase"/>
    /// </summary>
    public class ConditionBase : ConditionInstantiation, IConditionBase
    {
        /// <inheritdoc cref="IConditionBase.As(BindingInstanceType)"/>
        public IConditionInstantiation As(BindingInstanceType bindingInstanceType)
        {
            m_BindingData.SetInstanceType(bindingInstanceType);
            return m_BindingCondition.Initialize<ConditionInstantiation>(m_Binder, m_BindingData);
        }

        /// <inheritdoc cref="IConditionBase.AsSingle()"/>
        public IConditionInstantiation AsSingle()
        {
            return this.As(BindingInstanceType.Single);
        }
    }
}