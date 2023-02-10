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

namespace EasyJection.Reflection
{
    using Types;
    /// <summary>
    /// Implements interface <see cref="IConstructorsData"/><br/>
    /// <inheritdoc cref="IConstructorsData"/>
    /// Represents the cached methods data of the reflected class.
    /// </summary>
    public class ConstructorsData : Disposable, IConstructorsData
    {
        private ConstructorInfo[] m_ConstructorsInfo;
        /// <inheritdoc cref="IConstructorsData.ConstructorsInfo"/>
        public ConstructorInfo[] ConstructorsInfo { get => m_ConstructorsInfo; }

        private ParameterInfo[][] m_ConstructorsParsInfo;
        /// <inheritdoc cref="IConstructorsData.ConstructorsParsInfo"/>
        public ParameterInfo[][] ConstructorsParsInfo { get => m_ConstructorsParsInfo; }

        public ConstructorsData((ConstructorInfo[] ctors, ParameterInfo[][] pars) infos)
        {
            this.m_ConstructorsInfo = infos.ctors;
            this.m_ConstructorsParsInfo = infos.pars;
        }

        protected override void Remove()
        {
            this.m_ConstructorsInfo = null;
            this.m_ConstructorsParsInfo = null;
        }
    }
}