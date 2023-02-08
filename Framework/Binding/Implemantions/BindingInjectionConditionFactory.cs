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

namespace EasyJection.Binding
{
    using EasyJection.Reflection.Utils;
    using Extensions;
    using Hooking;

    /// <summary>
    /// Implementation of the <see cref="IBindingInjectionCondition"/> interface
    /// </summary>
    public class BindingInjectionConditionFactory : IBindingInjectionCondition
    {
        /// <summary>The binding containing its conditions.</summary>
        protected IBindingData binding;
        /// <summary>The hook container containing all the hooks needed for this binding.</summary>
        protected IHookContainer hookContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingInjectionConditionFactory"/> class.
        /// </summary>
        /// <param name="binding">The binding data.</param>
        public BindingInjectionConditionFactory(IBindingData binding)
        {
            this.binding = binding;
            this.hookContainer = binding.HookContainer;
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor(bool)"/>
        public IBindingMethodCondition Constructor(bool UseForInstantiation = false)
        {
            var methodBase = (binding.Value as Type).FindDefaultConstructor();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid(this.hookContainer, methodBase);
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T}(bool)"/>
        public IBindingMethodCondition Constructor<T>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2, T3>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2, T3>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2, T3, T4>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2, T3, T4, T5>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2, T3, T4, T5, T6>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2, T3, T4, T5, T6, T7>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7, T8}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2, T3, T4, T5, T6, T7, T8>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.Constructor{T1, T2, T3, T4, T5, T6, T7, T8, T9}(bool)"/>
        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(bool UseForInstantiation = false)
        {
            var methodBase = (this.binding.Value as Type).FindConstructorWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>();
            if (UseForInstantiation)
                this.binding.InstantiationConstructor = new Reflection.ConstructorInfo(methodBase, MethodMaker.CreateParameterizedConstructor(methodBase));

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{TResult}(string)"/>
        public IBindingMethodCondition MethodResult<TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByName<TResult>(methodName);

            var hookedMethod = new HookedMethodResult<TResult>(this.hookContainer, methodBase);
            
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, T3, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, T3, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, T3, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, T3, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, T3, T4, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, T3, T4, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, T3, T4, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, T3, T4, T5, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, T3, T4, T5, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, T3, T4, T5, T6, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, T3, T4, T5, T6, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, T3, T4, T5, T6, T7, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, T3, T4, T5, T6, T7, T8, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodResult{T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult}(string)"/>
        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(methodName);

            var hookedMethod = new HookedMethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid(string)"/>
        public IBindingMethodCondition MethodVoid(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByName(methodName);

            var hookedMethod = new HookedMethodVoid(this.hookContainer, methodBase);
            
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T}(string)"/>
        public IBindingMethodCondition MethodVoid<T>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T>(methodName);

            var hookedMethod = new HookedMethodVoid<T>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2, T3}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2, T3>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2, T3>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2, T3>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2, T3, T4}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2, T3, T4>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2, T3, T4, T5}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2, T3, T4, T5>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2, T3, T4, T5, T6}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2, T3, T4, T5, T6, T7}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6, T7>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2, T3, T4, T5, T6, T7, T8}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        /// <inheritdoc cref="IBindingInjectionCondition.MethodVoid{T1, T2, T3, T4, T5, T6, T7, T8, T9}(string)"/>
        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName)
        {
            var methodBase = (this.binding.Value as Type).FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(methodName);

            var hookedMethod = new HookedMethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this.hookContainer, methodBase);
            
            hookedMethod.HookManager.InvokeData.ArgumentTypes = new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) };
            
            return CreateBindingMethodConditionProvider(methodBase, hookedMethod);
        }

        protected virtual IBindingMethodCondition CreateBindingMethodConditionProvider(System.Reflection.MethodBase methodBase,
                                                                                       IHookedMethod hookedMethod)
        {
            this.binding.HookedMethods.Add(methodBase, hookedMethod);
            return new BindingMethodCondition(this, hookedMethod.HookManager.InvokeData);
        }
    }
}
