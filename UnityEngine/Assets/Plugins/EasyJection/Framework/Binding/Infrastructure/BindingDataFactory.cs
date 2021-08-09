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
    /// Implements interface <see cref="IBindingDataFactory"/><br/>
    /// <inheritdoc cref="IBindingDataFactory"/>
    /// </summary>
    public class BindingDataFactory : IBindingDataFactory
    {
        /// <summary>The default value for the type of the binding instance.</summary>
        protected const BindingInstanceType defaultBindingInstanceType = BindingInstanceType.Transient;

        private readonly IBindingFactory m_BindingFactory;
        /// <summary>The instance of a class that implements <see cref="IBindingFactory"/>.</summary>
        public IBindingFactory BindingFactory { get => m_BindingFactory; }

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="BindingDataFactory"/> class.
        /// </summary>
        /// <param name="bindingFactory">The instance of a class that implements <see cref="IBindingFactory"/>.</param>
        #endregion
        public BindingDataFactory(IBindingFactory bindingFactory)
        {
            m_BindingFactory = bindingFactory;
        }

        /// <inheritdoc cref="IBindingDataFactory.CreateInstance(Type)"/>
        public IBindingData CreateInstance(Type type)
        {
            return new BindingData(type, defaultBindingInstanceType);
        }
    }
}