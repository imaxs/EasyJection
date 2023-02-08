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

namespace EasyJection.Binding
{
    using Utils;
    using Types;
    using Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Implementation of the <see cref="IBindingFactory"/> interface
    /// </summary>
    public class BindingFactory : IBindingFactory
    {
        protected IReflectionCache cache;

        public IBinder Binder { get; private set; }

        public Type BindingType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingFactory"/> class.
        /// </summary>
        /// <param name="bindingType">The type being bound.</param>
        /// <param name="binder">The binder that will bind this binding.</param>
        public BindingFactory(IBinder binder, Type bindingType, IReflectionCache cache)
        {
            this.BindingType = bindingType;
            this.Binder = binder;
            this.cache = cache;
        }

        /// <inheritdoc cref="IBindingFactory.AddBinding(object)"/>
        public IBindingCondition AddBinding(object value) 
        {
            var binding = new BindingData(this.BindingType, value, BindingInstanceType.Transient);
            this.Binder.AddBinding(binding);

            // Precaching
            if (value != null)
                this.PreCaching(value as Type ?? value.GetType());

            return this.CreateBindingConditionFactoryProvider(binding);
        }

        /// <inheritdoc cref="IBindingFactory.AddFactoryInstance(Type, IFactory)"/>
        public IBindingInjection AddFactoryInstance(Type type, IFactory factory) 
        {
            var binding = new BindingData(this.BindingType, factory, type, BindingInstanceType.Factory | BindingInstanceType.Instance);
            this.Binder.AddBinding(binding);

            return this.CreateBindingInjectionFactoryProvider(binding);
        }

        /// <inheritdoc cref="IBindingFactory.AddBinding(object, BindingInstanceType, bool)"/>
        public IBindingInjection AddBinding(object value, BindingInstanceType instanceType, bool UseDefaultConstructor)
        {
            var binding = new BindingData(this.BindingType, value, instanceType);
            this.Binder.AddBinding(binding);

            // Precaching
            if (value != null)
                this.PreCaching(value as Type ?? value.GetType());

            var bindInjection = this.CreateBindingInjectionFactoryProvider(binding);

            if (UseDefaultConstructor)
                bindInjection.Constructor(true);

            return bindInjection;
        }

        /// <inheritdoc cref="IBindingFactory.To{T}()"/>
        public IBindingCondition To<T>() where T : class
        {
            return this.To(typeof(T));
        }

        /// <inheritdoc cref="IBindingFactory.To(Type)"/>
        public IBindingCondition To(Type type)
        {
            if (!Helper.IsAssignable(this.BindingType, type))
                throw new Exception(Causes.TYPE_NOT_ASSIGNABLE);

            return this.AddBinding(type);
        }

        /// <inheritdoc cref="IBindingFactory.ToInstance{T}(T)"/>
        public IBindingInjection ToInstance<T>(T instance)
        {
            return this.To(typeof(T), instance);
        }

        /// <inheritdoc cref="IBindingFactory.To(Type, object)"/>
        public IBindingInjection To(Type type, object instance)
        {
            var instanceType = instance.GetType();
            if (instance is Type || instanceType.IsInterface || instanceType.IsAbstract)
                throw new Exception(Causes.INSTANCE_NOT_OBJECT);
            else if (!Helper.IsAssignable(this.BindingType, type))
                throw new Exception(Causes.TYPE_NOT_ASSIGNABLE);
            else if (!Helper.IsAssignable(type, instanceType))
                throw new Exception(Causes.INSTANCE_NOT_ASSIGNABLE);

            return this.AddBinding(instance, BindingInstanceType.Instance, false);
        }

        /// <inheritdoc cref="IBindingFactory.ToFactory{T}(bool)"/>
        public IBindingInjection ToFactory<T>(bool UseDefaultConstructor = false) where T : Types.IFactory
        {
            return this.ToFactory(typeof(T), UseDefaultConstructor);
        }

        /// <inheritdoc cref="IBindingFactory.ToFactory{T}(bool)"/>
        public IBindingInjection ToFactory(Type type, bool UseDefaultConstructor = false)
        {
            if (!Helper.IsAssignable(typeof(Types.IFactory), type))
                throw new Exception(Causes.TYPE_NOT_IFACTORY);

            return this.AddBinding(type, BindingInstanceType.Factory, UseDefaultConstructor);
        }

        /// <inheritdoc cref="IBindingFactory.ToFactory{T}(Types.IFactory)"/>
        public void ToFactory<T>(Types.IFactory instance) where T : class
        {
            this.AddFactoryInstance(typeof(T), instance);
        }

        /// <inheritdoc cref="IBindingFactory.ToFactory(Types.IFactory)"/>
        public void ToFactory(Types.IFactory instance)
        {
            this.AddFactoryInstance(null, instance);
        }

        /// <inheritdoc cref="IBindingFactory.ToSelf(bool)"/>
        public IBindingInjection ToSelf(bool UseDefaultConstructor = false)
        {
            if (this.BindingType.IsInterface || this.BindingType.IsAbstract)
                throw new Exception(Causes.TYPE_NOT_IMPLEMENTED);

            return this.AddBinding(this.BindingType, BindingInstanceType.Transient, UseDefaultConstructor);
        }

        /// <inheritdoc cref="IBindingFactory.ToSelf{T}(bool)"/>
        public IBindingInjection ToSelf<T>(bool UseDefaultConstructor = false) where T : class
        {
            return this.AddBinding(typeof(T), BindingInstanceType.Transient, UseDefaultConstructor);
        }

        /// <inheritdoc cref="IBindingFactory.ToSingleton(bool)"/>
        public IBindingInjection ToSingleton(bool UseDefaultConstructor = false)
        {
            if (this.BindingType.IsInterface || this.BindingType.IsAbstract)
                throw new Exception(Causes.TYPE_NOT_IMPLEMENTED);

            return this.AddBinding(this.BindingType, BindingInstanceType.Singleton, UseDefaultConstructor);
        }

        /// <inheritdoc cref="IBindingFactory.ToSingleton{T}(bool)"/>
        public IBindingInjection ToSingleton<T>(bool UseDefaultConstructor = false) where T : class
        {
            return this.ToSingleton(typeof(T), UseDefaultConstructor);
        }

        /// <inheritdoc cref="IBindingFactory.ToSingleton(Type, bool)"/>
        public IBindingInjection ToSingleton(Type type, bool UseDefaultConstructor = false)
        {
            if (!Helper.IsAssignable(this.BindingType, type))
                throw new Exception(Causes.TYPE_NOT_ASSIGNABLE);

            return this.AddBinding(type, BindingInstanceType.Singleton, UseDefaultConstructor);
        }

        /// <summary>
        /// Resolves the binding provider.
        /// </summary>
        /// <param name="binding">Informatiion about the binding.</param>
        /// <returns>The binding provider.</returns>
        protected virtual IBindingCondition CreateBindingConditionFactoryProvider(IBindingData binding)
        {
            return new BindingConditionFactory(binding);
        }

        /// <summary>
        /// Resolves the binding provider.
        /// </summary>
        /// <param name="binding">Informatiion about the binding.</param>
        /// <returns>The binding provider.</returns>
        protected virtual IBindingInjection CreateBindingInjectionFactoryProvider(IBindingData binding)
        {
            return new BindingInjectionFactory(binding);
        }

        /// <summary>
        /// Adding reflected data of a type to the cache
        /// </summary>
        /// <param name="type">The type to be reflected</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void PreCaching(Type type) 
        {
            if (type == null)
                return;

            this.cache.Add(type as Type);
        }
    }
}
