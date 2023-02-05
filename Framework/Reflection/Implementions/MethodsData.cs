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

using System.Runtime.InteropServices;

namespace EasyJection.Reflection
{
    /// <summary>
    /// Implements interface <see cref="IMethodsData"/><br/>
    /// <inheritdoc cref="IMethodsData"/>
    /// Represents the cached methods data of the reflected class.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class MethodsData : IMethodsData
    {
        private MethodInfo[] m_MethodsInfo;
        /// <inheritdoc cref="IMethodsData.MethodsInfo"/>
        public MethodInfo[] MethodsInfo { get => m_MethodsInfo; }

        private ParameterInfo[][] m_MethodsParsInfo;
        /// <inheritdoc cref="IMethodsData.MethodsParsInfo"/>
        public ParameterInfo[][] MethodsParsInfo { get => m_MethodsParsInfo; }

        public MethodsData((MethodInfo[] methods, ParameterInfo[][] pars) methodsData)
        {
            this.m_MethodsInfo = methodsData.methods;
            this.m_MethodsParsInfo = methodsData.pars;
        }

        public bool IsEmpty { get => m_MethodsInfo == null || m_MethodsInfo.Length == 0; }
    }
}