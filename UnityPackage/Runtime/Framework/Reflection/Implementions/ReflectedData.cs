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
using System.Reflection;
using System.Runtime.InteropServices;

namespace EasyJection.Reflection
{
    /// <summary>
    /// Implements interface <see cref="IReflectedData"/><br/>
    /// <inheritdoc cref="IReflectedData"/>
    /// Represents the cached data of the reflected type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ReflectedData : IReflectedData
    {
        private Type m_Type;
        /// <inheritdoc cref="IReflectedData.Type"/>
        public Type Type { get => m_Type; }

        private IConstructorsData m_ConstructorsData;
        /// <inheritdoc cref="IReflectedData.ConstructorsData"/>
        public IConstructorsData ConstructorsData { get => m_ConstructorsData; }

        private AccessoriesInfo[] m_PropertiesInfo;
        /// <inheritdoc cref="IReflectedData.PropertiesInfo"/>
        public AccessoriesInfo[] PropertiesInfo { get => m_PropertiesInfo; }

        private AccessoriesInfo[] m_FieldsInfo;
        /// <inheritdoc cref="IReflectedData.FieldsInfo"/>
        public AccessoriesInfo[] FieldsInfo { get => m_FieldsInfo; }

        private IMethodsData m_MethodsData;
        /// <inheritdoc cref="IReflectedData.MethodsData"/>
        public IMethodsData MethodsData { get => m_MethodsData; }

        public ReflectedData(
            Type type,
            (ConstructorInfo[] ctors, ParameterInfo[][] pars) ctorsData,
            AccessoriesInfo[] propertiesInfo,
            AccessoriesInfo[] fieldsInfo,
            (MethodInfo[] methods, ParameterInfo[][] pars) methodsData)
        {
            this.m_Type = type;
            this.m_ConstructorsData = new ConstructorsData(ctorsData);
            this.m_PropertiesInfo = propertiesInfo;
            this.m_FieldsInfo = fieldsInfo;
            this.m_MethodsData = new MethodsData(methodsData);
        }
    }
}