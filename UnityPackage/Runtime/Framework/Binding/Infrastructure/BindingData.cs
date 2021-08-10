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
    /// Implements interface <see cref="IBindingData"/><br/>
    /// <inheritdoc cref="IBindingData"/>
    /// Represents a binding data.
    /// </summary>
    public class BindingData : IBindingData
    {
        private readonly Type m_Type;
        /// <summary>The type to which the binding will be bound.</summary>
        public Type Type { get => m_Type; }

        private string m_ConstructorName;
        /// <summary>The name of the method that is called as a constructor.</summary>
        public string ConstructorName { get => m_ConstructorName; }

        private Object[] m_Arguments;
        /// <summary>Arguments to be passed to a constructor when the implementor instance is initialized.</summary>
        public Object[] Arguments { get => m_Arguments; }

        private Type[] m_ArgumentTypes;
        /// <summary>Argument types.</summary>
        public Type[] ArgumentTypes { get => m_ArgumentTypes; }

        private BindingInstanceType m_InstanceType;
        /// <summary>Arguments to be passed to a constructor when the implementor instance is initialized.</summary>
        public BindingInstanceType InstanceType { get => m_InstanceType; }

        private IInstancesFactory m_InstancesFactory;
        /// <summary>An instance that implements IInstancesFactory interface for creating instances of a specific type.</summary>
        public IInstancesFactory InstancesFactory { get => m_InstancesFactory; }

        private bool m_IsAutoInjectionEnabled;
        /// <summary>If True, the injection will be done via hook.</summary>
        public bool IsAutoInjectionEnabled 
        { 
            get => m_IsAutoInjectionEnabled; 
            set => m_IsAutoInjectionEnabled = value; 
        }

        public BindingData(
            Type type,
            BindingInstanceType instanceType,
            string constructorName = null,
            Object[] arguments = null,
            Type[] types = null)
        {
            m_Type = type;
            m_InstanceType = instanceType;
            m_InstancesFactory = Instantinator.GetFactory(instanceType);
            m_ConstructorName = constructorName;
            m_Arguments = arguments;
            m_ArgumentTypes = types;
        }

        /// <inheritdoc cref="IBindingData.SetInstanceType(BindingInstanceType)"/>
        public IBindingData SetInstanceType(BindingInstanceType instanceType)
        {
            m_InstanceType = instanceType;
            m_InstancesFactory = Instantinator.GetFactory(instanceType);
            return this;
        }

        /// <inheritdoc cref="IBindingData.SetConstructorName(string)"/>
        public IBindingData SetConstructorName(string methodName)
        {
            m_ConstructorName = methodName;
            return this;
        }

        /// <inheritdoc cref="IBindingData.SetArguments(object[], Type[])"/>
        public IBindingData SetArguments(Object[] arguments, Type[] types = null)
        {
            m_Arguments = arguments;
            if (types == null)
            {
                types = new Type[arguments.Length];
                for (int i = 0; i < arguments.Length; i++)
                    types[i] = arguments[i].GetType();
            }
            m_ArgumentTypes = types;
            return this;
        }

        /// <inheritdoc cref="IBindingData.SetArgumentTypes(Type[])"/>
        public IBindingData SetArgumentTypes(Type[] types)
        {
            m_ArgumentTypes = types;
            return this;
        }
    }
}