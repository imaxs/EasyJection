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
using System.Collections.Generic;

namespace EasyJection
{
    public static class Instantinator
    {
        /// <summary>The array containing a binding of an instance type with an implementation factory.</summary>
        private static readonly IInstancesFactory[] m_ImplementationFactory;

        static Instantinator()
        {
            m_ImplementationFactory = new IInstancesFactory[3];
        }

        public static IInstancesFactory GetFactory(BindingInstanceType type)
        {
            int index = (int)type;
            if (m_ImplementationFactory[index] == null)
            {
                switch(type)
                {
                    case BindingInstanceType.Transient:
                        m_ImplementationFactory[index] = new TransientFactory();
                        break;
                    case BindingInstanceType.Single:
                        m_ImplementationFactory[index] = new SingleFactory();
                        break;
                    case BindingInstanceType.Itself:
                        m_ImplementationFactory[index] = new ItselfFactory();
                        break;
                }
            }
            return m_ImplementationFactory[index];
        }
    }

    /***********************
        TransientFactory
    ************************/
    public class TransientFactory : IInstancesFactory
    {
        public Object GetInstance(Type type) 
            => Activator.CreateInstance(type);

        public Object GetInstance(Type type, ConstructorInfo constructor, Object[] arguments)
            => constructor.Invoke(arguments);
    }

    /***********************
        ItselfFactory
    ************************/
    public class ItselfFactory : IInstancesFactory
    {
        /// <summary>The default initial capacity of the dictionary.</summary>
        private const int c_DictionaryCapacity = 16;

        /// <summary>The dictionary containing implementations.</summary>
        private readonly Dictionary<Type, Object> m_Implementations;

        public ItselfFactory(int capacity = c_DictionaryCapacity)
        {
            m_Implementations = new Dictionary<Type, Object>(capacity);
        }

        public Object GetInstance(Type type)
        {
            Object result = null;
            if (!m_Implementations.TryGetValue(type, out result))
            {
                result = Activator.CreateInstance(type);
                m_Implementations.Add(type, result);
            }
            return result;
        }

        public Object GetInstance(Type type, ConstructorInfo constructor, Object[] arguments)
        {
            Object result = null;
            if (!m_Implementations.TryGetValue(type, out result))
            {
                result = constructor.Invoke(arguments);
                m_Implementations.Add(type, result);
            }                
            return result;
        }
    }

    /***********************
        SingleFactory
    ************************/
    public class SingleFactory : IInstancesFactory
    {
        public Object GetInstance(Type type)
            => null;

        public Object GetInstance(Type type, ConstructorInfo constructor, Object[] arguments)
        {
            return null;
        }
    }
}