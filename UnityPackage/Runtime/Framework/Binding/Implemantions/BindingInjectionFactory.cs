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

using EasyJection.Hooking;
using System;
using System.Collections.Generic;

namespace EasyJection.Binding
{
    public class BindingInjectionFactory : IBindingInjection
    {
        /// <summary>Binding to have its conditions defined.</summary>
        protected IBindingData binding;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingInjectionFactory"/> class.
        /// </summary>
        /// <param name="binding">The binding to have its conditions settled.</param>
        public BindingInjectionFactory(IBindingData binding)
        {
            this.binding = binding;
        }

        /// <inheritdoc cref="IBindingInjection.InjectionTo()"/>
        public IBindingInjectionCondition InjectionTo()
        {
            return CreateBindingInjectionConditionFactoryProvider(this.binding);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor(bool)"/>
        public IBindingMethodCondition Constructor(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T}(bool)"/>
        public IBindingMethodCondition Constructor<T>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2, T3>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2, T3, T4>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2, T3, T4, T5>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2, T3, T4, T5, T6>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2, T3, T4, T5, T6, T7>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7, T8}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2, T3, T4, T5, T6, T7, T8>(UseForInstantiation);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7, T8, T9}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(bool UseForInstantiation = false)
        {
            return this.InjectionTo().Constructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(UseForInstantiation);
        }

        protected virtual IBindingInjectionCondition CreateBindingInjectionConditionFactoryProvider(IBindingData binding)
        {
            this.binding.HookContainer = new HookContainer();
            this.binding.HookedMethods = new Dictionary<System.Reflection.MethodBase, IHookedMethod>();
            return new BindingInjectionConditionFactory(binding);
        }
    }
}
