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

namespace EasyJection
{
    /// <summary>
    /// Implements interface <see cref="IBinder"/><br/>
    /// <inheritdoc cref="IBinder"/>
    /// </summary>
    public sealed class Binder : IBinder
    {
        /// <summary>The default dictionary capacity value.</summary>
        private const int c_DictionaryCapacity = 64;

        /// <summary>Dependency on binding factory implementations.</summary>
        private IBindingFactory m_BindingFactory;

        /// <summary>The dictionary containing a binding of a type with an implementation data.</summary>
        private readonly Dictionary<Type, IBindingData> m_Dependencies;

        /// <summary>The container containing a binding.</summary>
        private IContainer m_Container;
        public IContainer Container { get => m_Container; }

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="IBinder"/> implementation class.
        /// </summary>
        /// <param name="capacity">The capacity of the dictionary.</param>
        #endregion
        public Binder(IContainer container, int capacity = c_DictionaryCapacity) : 
            this(container, new BindingFactory(), capacity) 
        { }

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="IBinder"/> implementation class.
        /// </summary>
        /// <param name="bindingFactory">The instance of a class that implements <see cref="IBindingFactory"/>.</param>
        /// <param name="capacity">The capacity of the dictionary.</param>
        #endregion
        public Binder(IContainer container, IBindingFactory bindingFactory, int capacity = c_DictionaryCapacity)
        {
            m_Container = container;
            m_BindingFactory = bindingFactory;
            m_Dependencies = new Dictionary<Type, IBindingData>(capacity);
        }

        /// <inheritdoc cref="IBindCreator.Bind{T}"/>
        public IBindingFactory Bind<T>()// where T : class
        {
            return this.Bind(typeof(T));
        }

        /// <inheritdoc cref="IBindCreator.Bind(Type)"/>
        public IBindingFactory Bind(Type type)
        {
            return m_BindingFactory.Initialize(type, this);
        }

        /// <inheritdoc cref="IBinder.AddBinding(Type, IBindingData)"/>
        public void AddBinding(Type type, IBindingData bindingData)
        {
            if (!m_Dependencies.ContainsKey(type))
                m_Dependencies.Add(type, bindingData);
        }

        /// <inheritdoc cref="IBinder.GetAllBindings"/>
        public IList<IBindingData> GetAllBindings()
        {
            var bindings = new List<IBindingData>(m_Dependencies.Count);

            foreach (BindingData data in m_Dependencies.Values)
            {
                bindings.Add(data);
            }

            return bindings;
        }

        public IBindingData Get(Type type)
        {
            IBindingData result = null;
            if(!m_Dependencies.TryGetValue(type, out result))
            {
                IBindingData tmp = null;
                foreach (Type key in m_Dependencies.Keys)
                {
                    tmp = m_Dependencies[key];
                    if (tmp.Type == type)
                    {
                        result = tmp;
                        break;
                    }
                }
            }
            return result;
        }
    }
}