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

namespace EasyJection
{
    /// <summary>
    /// Implements interface <see cref="IReflectedData"/><br/>
    /// <inheritdoc cref="IReflectedData"/>
    /// Represents the cached data of the reflected class.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct ReflectedData : IReflectedData
    {
        private readonly ReflectedId m_ParentId;
        /// <inheritdoc cref="IReflectedData.ParentId"/>
        public ReflectedId ParentId { get => m_ParentId; }

        private readonly string m_TypeName;
        /// <inheritdoc cref="IReflectedData.TypeName"/>
        public string TypeName { get => m_TypeName; }

        private readonly bool m_IsValueType;
        /// <inheritdoc cref="IReflectedData.IsValueType"/>
        public bool IsValueType { get => m_IsValueType; }

        private readonly ConstructorsData m_ConstructorsData;
        /// <inheritdoc cref="IReflectedData.ConstructorsData"/>
        public ConstructorsData ConstructorsData { get => m_ConstructorsData; }

        private readonly PropertyInfo[] m_PropertiesInfo;
        /// <inheritdoc cref="IReflectedData.PropertiesInfo"/>
        public PropertyInfo[] PropertiesInfo { get => m_PropertiesInfo; }

        private readonly FieldInfo[] m_FieldsInfo;
        /// <inheritdoc cref="IReflectedData.FieldsInfo"/>
        public FieldInfo[] FieldsInfo { get => m_FieldsInfo; }

        private readonly MethodsData m_MethodsData;
        /// <inheritdoc cref="IReflectedData.MethodsData"/>
        public MethodsData MethodsData { get => m_MethodsData; }

        public ReflectedData(
            ReflectedId parentId,
            string typeName,
            bool isValueType,
            ConstructorInfo[] constructorInfo,
            ParameterInfo[][] constructorsParsInfo,
            PropertyInfo[] propertiesInfo,
            FieldInfo[] fieldsInfo,
            MethodInfo[] methodsInfo,
            ParameterInfo[][] methodsParsInfo)
        {
            this.m_ParentId = parentId;
            this.m_TypeName = typeName;
            this.m_IsValueType = isValueType;
            this.m_ConstructorsData = new ConstructorsData(constructorInfo, constructorsParsInfo);
            this.m_PropertiesInfo = propertiesInfo;
            this.m_FieldsInfo = fieldsInfo;
            this.m_MethodsData = new MethodsData(methodsInfo, methodsParsInfo);
        }
    }
}