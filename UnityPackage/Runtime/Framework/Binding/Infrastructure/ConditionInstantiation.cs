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
    /// Implements interface <see cref="IConditionInstantiation"/><br/>
    /// <inheritdoc cref="IConditionInstantiation"/>
    /// </summary>
    public class ConditionInstantiation : ConditionCreator, IConditionInstantiation
    {
        private void HookConstructor()
        {
            if (m_BindingData.IsAutoInjectionEnabled)
                m_Binder.Container.InjectToMethod(m_BindingData.Type, m_BindingData.ConstructorName, m_BindingData.Arguments);
        }

        /// <inheritdoc cref="IConditionInstantiation.ConstructionMethod()"/>
        public IConditionInstantiation ConstructionMethod()
        {
            // Nothing at all...
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.ConstructionMethod(string)"/>
        public IConditionInstantiation ConstructionMethod(string methodName, bool autoInjection = true)
        {
            if (methodName != null)
            {
                m_BindingData.IsAutoInjectionEnabled = autoInjection;
                m_BindingData.SetConstructorName(methodName);
                HookConstructor();
            }
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments(object[])"/>
        public IConditionInstantiation WithArguments(Object[] arguments)
        {
            m_BindingData.SetArguments(arguments);
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T}(T)"/>
        public IConditionInstantiation WithArguments<T>(T param)
        {
            m_BindingData.SetArguments(
                new object[] { param },
                new Type[] { typeof(T) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2}(T1, T2)"/>
        public IConditionInstantiation WithArguments<T1, T2>(T1 param1, T2 param2)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2 },
                new Type[] { typeof(T1), typeof(T2) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2, T3}(T1, T2, T3)"/>
        public IConditionInstantiation WithArguments<T1, T2, T3>(T1 param1, T2 param2, T3 param3)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2, param3 },
                new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4}(T1, T2, T3, T4)"/>
        public IConditionInstantiation WithArguments<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2, param3, param4 },
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5}(T1, T2, T3, T4, T5)"/>
        public IConditionInstantiation WithArguments<T1, T2, T3, T4, T5>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2, param3, param4, param5 },
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6}(T1, T2, T3, T4, T5, T6)"/>
        public IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2, param3, param4, param5, param6 },
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6, T7}(T1, T2, T3, T4, T5, T6, T7)"/>
        public IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6, T7>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2, param3, param4, param5, param6, param7 },
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6, T7, T8}(T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6, T7, T8>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2, param3, param4, param5, param6, param7, param8 },
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6, T7, T8, T9}(T1, T2, T3, T4, T5, T6, T7, T8, T9)"/>
        public IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
        {
            m_BindingData.SetArguments(
                new object[] { param1, param2, param3, param4, param5, param6, param7, param8, param9 },
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
            HookConstructor();
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T}"/>
        public IConditionInstantiation Signature<T>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2}"/>
        public IConditionInstantiation Signature<T1, T2>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2, T3}"/>
        public IConditionInstantiation Signature<T1, T2, T3>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2, T3, T4}"/>
        public IConditionInstantiation Signature<T1, T2, T3, T4>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2, T3, T4, T5}"/>
        public IConditionInstantiation Signature<T1, T2, T3, T4, T5>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2, T3, T4, T5, T6}"/>
        public IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2, T3, T4, T5, T6, T7}"/>
        public IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6, T7>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2, T3, T4, T5, T6, T7, T8}"/>
        public IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) });
            return this;
        }

        /// <inheritdoc cref="IConditionInstantiation.Signature{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/>
        public IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
        {
            m_BindingData.SetArgumentTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
            return this;
        }
    }
}