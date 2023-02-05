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
using System.Collections.Generic;
using System.Reflection;

namespace EasyJection.Binding
{
    using EasyJection.Utils;
    using Extensions;
    using Hooking;
    public class BindingMethodCondition : IBindingMethodCondition
    {
        protected IBindingInjectionCondition injectionCondition;
        protected IMethodInvokeData invokeData;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingMethodCondition"/> class.
        /// </summary>
        public BindingMethodCondition(IBindingInjectionCondition injectionCondition,
                                      IMethodInvokeData invokeData)
        {
            this.injectionCondition = injectionCondition;
            this.invokeData = invokeData;
        }

        public IBindingMethodCondition Constructor(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2, T3>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2, T3>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2, T3, T4>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2, T3, T4>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2, T3, T4, T5>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2, T3, T4, T5, T6>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2, T3, T4, T5, T6, T7>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2, T3, T4, T5, T6, T7, T8>(UseForInstantiation);
        }

        public IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(bool UseForInstantiation = false)
        {
            return this.injectionCondition.Constructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(UseForInstantiation);
        }

        public IBindingMethodCondition MethodResult<TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, T3, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, T3, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, T3, T4, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, T3, T4, T5, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, T3, T4, T5, T6, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(methodName);
        }

        public IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(string methodName)
        {
            return this.injectionCondition.MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(methodName);
        }

        public IBindingMethodCondition MethodVoid(string methodName)
        {
            return this.injectionCondition.MethodVoid(methodName);
        }

        public IBindingMethodCondition MethodVoid<T>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2, T3>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2, T3>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2, T3, T4>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2, T3, T4, T5>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2, T3, T4, T5, T6>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2, T3, T4, T5, T6, T7>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>(methodName);
        }

        public IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName)
        {
            return this.injectionCondition.MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>(methodName);
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T}(T)"/>
        public IBindingInjectionCondition WithArguments<T>(T param)
        {
            this.invokeData.ArgumentsObjects = new object[] { param };
            if(!Helpers.CheckEquality(new Type[] { typeof(T) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2}(T1, T2)"/>
        public IBindingInjectionCondition WithArguments<T1, T2>(T1 param1, T2 param2)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2, T3}(T1, T2, T3)"/>
        public IBindingInjectionCondition WithArguments<T1, T2, T3>(T1 param1, T2 param2, T3 param3)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2, param3 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2), typeof(T3) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2, T3, T4}(T1, T2, T3, T4)"/>
        public IBindingInjectionCondition WithArguments<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2, param3, param4 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2, T3, T4, T5}(T1, T2, T3, T4, T5)"/>
        public IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2, param3, param4, param5 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2, T3, T4, T5, T6}(T1, T2, T3, T4, T5, T6)"/>
        public IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2, param3, param4, param5, param6 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2, T3, T4, T5, T6, T7}(T1, T2, T3, T4, T5, T6, T7)"/>
        public IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6, T7>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2, param3, param4, param5, param6, param7 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2, T3, T4, T5, T6, T7, T8}(T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6, T7, T8>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2, param3, param4, param5, param6, param7, param8 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }

        /// <inheritdoc cref="IBindingMethodCondition.WithArguments{T1, T2, T3, T4, T5, T6, T7, T8, T9}(T1, T2, T3, T4, T5, T6, T7, T8, T9)"/>
        public IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
        {
            this.invokeData.ArgumentsObjects = new object[] { param1, param2, param3, param4, param5, param6, param7, param8, param9 };
            if(!Helpers.CheckEquality(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) }, this.invokeData.ArgumentTypes))
                throw new Exception(Causes.ARGUMENTS_NOT_MATCH);

            return this.injectionCondition;
        }
    }
}
