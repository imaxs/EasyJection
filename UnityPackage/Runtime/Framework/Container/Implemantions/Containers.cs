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
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace EasyJection
{
    using Binding;

    public static class Containers
    {
        private static object _lock = new object();
        private static IList<IContainer> containers = null;

        static Containers()
        {
            containers = new List<IContainer>(capacity: 8);
        }

        public static void Add(IContainer container)
        {
            lock (_lock)
            {
                containers.Add(container);
            }
        }

        public static void Remove(IContainer container)
        {
            lock (_lock)
            {
                containers.Remove(container);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static (IContainer container, IBindingData binding)? Get(Type type)
        {
            lock (_lock)
            {
                for (int i = 0; i < containers.Count; i++)
                {
                    var container = containers[i];
                    var binding = container[type];
                    if (binding != null)
                        return (container, binding);
                }
                return null;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Reset()
        {
            lock (_lock)
            {
                for (int i = 0; i < containers.Count; i++)
                    containers[i].Dispose();

                containers.Clear();
            }
        }
    }
}
