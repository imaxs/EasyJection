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
using System.Runtime.InteropServices;

namespace EasyJection
{
    /// <summary>
    /// Implements interface <see cref="IAssemblyReflectedData"/><br/>
    /// <inheritdoc cref="IAssemblyReflectedData"/>
    /// Represents a cache of reflected classes by specific namespace.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AssemblyReflectedData : IAssemblyReflectedData
    {
        public const int DefaultCapacity = 16;

        private readonly string m_Namespace;
        /// <inheritdoc cref="IAssemblyReflectedData.Namespace"/>
        public string Namespace { get => m_Namespace; }

        private int m_Length;
        /// <inheritdoc cref="IAssemblyReflectedData.Length"/>
        public int Length { get => m_Length; }

        private int m_CustomCapacity;
        private ReflectedData[] m_ReflectedData;
        private object _rpl;

        /// <summary>
        /// Initializes a new instance of the <see cref="IAssemblyReflectedData"/> class.
        /// </summary>
        /// <param name="nameSpace">The Namespace name.</param>
        /// <param name="capacity">The initial capacity of the internal array.</param>
        public AssemblyReflectedData(string nameSpace, int capacity)
        {
            m_Length = 0;
            m_Namespace = nameSpace;
            m_CustomCapacity = capacity;
            m_ReflectedData = new ReflectedData[capacity];
            _rpl = new object();
        }

        /// <summary>Gets the <see cref="IReflectedData"/> at the specified index.</summary>
        public ref ReflectedData this[int index]
        {
            get => ref m_ReflectedData[index];
        }

        /// <inheritdoc cref="IAssemblyReflectedData.Add(in ReflectedData)"/>
        public int Add(in ReflectedData reflectedData)
        {
            lock (_rpl)
            {
                m_ReflectedData[m_Length] = reflectedData;
                return m_Length++;
            }
        }

        /// <inheritdoc cref="IAssemblyReflectedData.GetIndex(string)"/>
        public int GetIndex(string typeName)
        {
            for (int i = 0; i < m_Length; i++)
                if (String.CompareOrdinal(this[i].TypeName, typeName) == 0)
                    return i;
            return -1;
        }
    }
}