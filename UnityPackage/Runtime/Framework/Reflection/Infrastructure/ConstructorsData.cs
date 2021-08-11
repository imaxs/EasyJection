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

using System.Reflection;
using System.Runtime.InteropServices;

namespace EasyJection
{
    /// <summary>
    /// Implements interface <see cref="IConstructorsData"/><br/>
    /// <inheritdoc cref="IConstructorsData"/>
    /// Represents the cached methods data of the reflected class.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct ConstructorsData : IConstructorsData
    {
        private readonly ConstructorInfo[] m_ConstructorsInfo;
        /// <inheritdoc cref="IConstructorsData.ConstructorsInfo"/>
        public ConstructorInfo[] ConstructorsInfo { get => m_ConstructorsInfo; }

        private readonly ParameterInfo[][] m_ConstructorsParsInfo;
        /// <inheritdoc cref="IConstructorsData.ConstructorsParsInfo"/>
        public ParameterInfo[][] ConstructorsParsInfo { get => m_ConstructorsParsInfo; }

        public ConstructorsData(ConstructorInfo[] constructorsInfo, ParameterInfo[][] constructorsParsInfo)
        {
            this.m_ConstructorsInfo = constructorsInfo;
            this.m_ConstructorsParsInfo = constructorsParsInfo;
        }
    }
}