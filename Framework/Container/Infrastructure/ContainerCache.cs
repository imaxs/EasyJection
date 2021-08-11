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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace EasyJection
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ContainerCache : IContainerCache
    {
        public const int DefaultCapacity = 8;

        private KeyValuePair<Type, Object>[] m_Сache;

        private int m_Length;
        public int Length { get => m_Length; }

        private readonly object _rpl;

        public Object this[Type type] { 
            get 
            {
                lock (_rpl)
                {
                    for (int i = 0; i < m_Length; i++)
                    {
                        KeyValuePair<Type, Object> cache = m_Сache[i];
                        if (type.IsAssignableFrom(cache.Key))
                            return cache.Value;
                    }
                }
                return null;
            } 
        }

        public ContainerCache(int capacity)
        {
            m_Length = 0;
            m_Сache = new KeyValuePair<Type, Object>[capacity];
            _rpl = new object();
        }

        public void Add(Type type, Object instance)
        {
            lock (_rpl)
                m_Сache[m_Length++] = new KeyValuePair<Type, Object>(type, instance);
        }

        public void Add(Object instance) => Add(instance.GetType(), instance);

        public void Clear() => m_Length = 0;

        public void Reset() => this = new ContainerCache(m_Сache.Length);
    }
}