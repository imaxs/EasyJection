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

namespace EasyJection.Binding
{
    public interface IBindingInjection
    {
        /// <summary>
        /// The injection will be performed when the specified method is called.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        IBindingInjectionCondition InjectionTo();

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor(bool)"/>
        IBindingMethodCondition Constructor(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T}(bool)"/>
        IBindingMethodCondition Constructor<T>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2, T3>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2, T3, T4>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7, T8}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8>(bool UseForInstantiation = false);

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7, T8, T9}(bool)"/>
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(bool UseForInstantiation = false);
    }
}
