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
    /// <summary>
    /// Implements interface <see cref="IBindingFactory"/><br/>
    /// <inheritdoc cref="IBindingFactory"/>
    /// </summary>
    public class BindingFactory : IBindingFactory
    {
        /// <summary>Dependency on the implementation of the binding data factory.</summary>
        protected IBindingDataFactory m_DataFactory;
        /// <summary>Dependency on the implementation of the binding condition factory.</summary>
        protected IBindingCondition m_BindingCondition;

        /// <summary>The type to be bound.</summary>
        protected Type m_BindingType;
        /// <summary>Binder is used through the Binding Factory.</summary>
        protected IBinder m_Binder;

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="BindingFactory"/> class.
        /// </summary>
        #endregion
        public BindingFactory()
        {
            m_DataFactory = new BindingDataFactory(this);
            m_BindingCondition = new BindingCondition(this);
        }

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="BindingFactory"/> class.
        /// </summary>
        /// <param name="dataFactory">The instance of the <see cref="IBindingDataFactory"/> interface implementation.</param>
        /// <param name="conditionFactory">The instance of the <see cref="IBindingCondition"/> interface implementation.</param>
        #endregion
        internal BindingFactory(IBindingDataFactory dataFactory, IBindingCondition conditionFactory)
        {
            m_DataFactory = dataFactory;
            m_BindingCondition = conditionFactory;
        }

        /// <inheritdoc cref="IBindingFactory.Initialize(Type, IBinder)"/>
        public IBindingFactory Initialize(Type bindingType, IBinder binder)
        {
            m_BindingType = bindingType;
            m_Binder = binder;
            return this;
        }

        /// <inheritdoc cref="IBindingFactory.To{T}"/>
        public IConditionBase To<T>()
        {
            return this.To(typeof(T));
        }

        /// <inheritdoc cref="IBindingFactory.To(Type)"/>
        public IConditionBase To(Type type)
        {
            IBindingData bindingData = m_DataFactory.CreateInstance(type);
            m_Binder.AddBinding(m_BindingType, bindingData);

            IConditionBase condition = m_BindingCondition.Initialize<ConditionBase>(m_Binder, bindingData);
            return condition;
        }

        /// <inheritdoc cref="IBindingFactory.ToSelf"/>
        public IConditionInstantiation ToSelf()
        {
            if (m_BindingType.IsInterface)
                throw new NotSupportedException("The type that initializes the binding must be a class (reference type).");

            return this.To(m_BindingType).As(BindingInstanceType.Itself);
        }
    }
}