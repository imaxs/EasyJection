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
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct MethodData
    {
        public readonly MethodInfo Info;
        public readonly ParameterInfo[] Parameters;

        public MethodData(MethodInfo methodInfo, ParameterInfo[] parameterInfo)
        {
            this.m_IsNotEmpty = methodInfo != null & parameterInfo != null;
            this.Info = methodInfo;
            this.Parameters = parameterInfo;
        }

        private readonly bool m_IsNotEmpty;
        public bool IsEmpty { get => !m_IsNotEmpty; }
    }
}