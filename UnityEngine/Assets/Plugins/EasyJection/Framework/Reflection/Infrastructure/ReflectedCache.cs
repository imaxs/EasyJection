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
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ReflectedCache : IReflectedCache
    {
        public const int DefaultCapacity = 8;

        private int m_Length;
        public int Length { get => m_Length; }

        private AssemblyReflectedData[] m_CachedData;

        private object _rpl;

        public ReflectedCache(int capacity)
        {
            m_Length = 0;
            m_CachedData = new AssemblyReflectedData[capacity];
            _rpl = new object();
        }

        public ref AssemblyReflectedData this[int index] 
        {
            get => ref m_CachedData[index];
        }

        public ref ReflectedData this[ReflectedId index]
        {
            get => ref m_CachedData[index.NamespaceId][index.TypeNameId];
        }

        public ReflectedId Add(string Namespace, in ReflectedData ReflectedData)
        {
            int index = GetIndex(Namespace);
            if (index == -1)
                return AddNew(Namespace, ReflectedData);

            return new ReflectedId(index, m_CachedData[index].Add(ReflectedData));
        }

        private ReflectedId AddNew(string Namespace, in ReflectedData ReflectedData)
        {
            lock (_rpl)
            {
                m_CachedData[m_Length] = new AssemblyReflectedData(Namespace, AssemblyReflectedData.DefaultCapacity);
                int typeNameId = m_CachedData[m_Length].Add(ReflectedData);
                return new ReflectedId(m_Length++, typeNameId);
            }
        }

        public int GetIndex(string Namespace)
        {
            for (int i = 0; i < m_Length; i++)
                if (String.CompareOrdinal(this[i].Namespace, Namespace) == 0)
                    return i;
            return -1;
        }

        public void Reset()
        {
            this = new ReflectedCache(m_CachedData.Length);
        }
    }
}