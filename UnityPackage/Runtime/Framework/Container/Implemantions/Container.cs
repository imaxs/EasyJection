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

namespace EasyJection
{
    using Resolving;
    using Binding;
    using Reflection;
    using Hooking;

    public class Container : IContainer
    {
        private static object _lock = new object();
        private static Container _instance = null;

        public static Container Instance
        {
            get
            {
                if (_instance is null)
                {
                    lock (_lock)
                    {
                        _instance = _instance ?? new Container();
                    }
                }
                return _instance;
            }
        }

        protected IBinder binder;
        protected IReflectionCache cache;
        protected IResolver resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        /// <remarks>
        /// When passing no parameters to the constructor, default internal objects are created.
        /// </remarks>
        public Container()
            : this(new Binder(), new ReflectionCache())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        /// <remarks>
        /// <remarks>
        /// Default binder and injector objects are created.
        /// </remarks>
        /// <param name="cache">Reflection cache used to get type info.</param>
        protected Container(IBinder binder, IReflectionCache cache)
        {
            this.binder = binder;
            this.cache = cache;
            this.resolver = new Resolver(this.cache, this.binder);
        }

        /// <inheritdoc cref="IBindCreator.Bind{T}"/>
        public IBindingFactory Bind<T>()
        {
            return this.binder.Bind<T>();
        }

        /// <inheritdoc cref="IBindCreator.Bind(Type)"/>
        public IBindingFactory Bind(Type type)
        {
            return this.binder.Bind(type);
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IResolver.Inject(object)"/>
        public void Inject(object instance)
        {
            this.resolver.Inject(instance);
        }

        public IBindingData this[Type type]
        {
            get => this.binder.GetBindingFor(type);
        }

        /// <inheritdoc cref="IResolver.Resolve{T}"/>
        public T Resolve<T>()
        {
            return (T)this.resolver.Resolve(typeof(T));
        }

        /// <inheritdoc cref="IResolver.Resolve(Type)"/>
        public object Resolve(Type type)
        {
            return this.resolver.Resolve(type);
        }

        /// <inheritdoc cref="IResolver.Resolve(object[], Type[])"/>
        public object[] Resolve(object[] objects, Type[] types)
        {
            return this.resolver.Resolve(objects, types);
        }
    }
}
