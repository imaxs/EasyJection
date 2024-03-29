﻿/*
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

namespace EasyJection.Resolving
{
    using Binding;
    using EasyJection.Types;
    using Reflection;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of the <see cref="IResolver"/> interface
    /// </summary>
    public class Resolver : IResolver
    {
        /// <summary>Binder used to resolved bindings.</summary>
        protected IBinder binder;

        /// <summary>Reflection cache used to get type info.</summary>
        protected IReflectionCache cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resolver"/> class.
        /// </summary>
        /// <param name="cache">Reflection cache used to get type info.</param>
        /// <param name="binder">Binder used to resolved bindings.</param>
        public Resolver(IReflectionCache cache, IBinder binder)
        {
            this.cache = cache;
            this.binder = binder;
        }

        /// <inheritdoc cref="IResolver.Inject(IBindingData, object, IDictionary{Type, object})"/>
        public void Inject(IBindingData bindingData, object instance, IDictionary<Type, object> scopedInstances)
        {
            this.Inject(bindingData.Type, instance, scopedInstances);
        }

        /// <inheritdoc cref="IResolver.Inject(Type, object, IDictionary{Type, object})"/>
        public void Inject(Type instanceType, object instance, IDictionary<Type, object> scopedInstances)
        {
            // Add the first item to it.
            if (!scopedInstances.ContainsKey(instanceType))
                scopedInstances.Add(instanceType, instance);

            var reflectedData = this.cache[instanceType];
            this.Inject(instance, reflectedData, scopedInstances);

            scopedInstances.Clear();
        }

        /// <inheritdoc cref="IResolver.Inject(object, IDictionary{Type, object})"/>
        public void Inject(object instance, IDictionary<Type, object> scopedInstances)
        {
            // Get instance type
            var instanceType = instance.GetType();

            this.Inject(instanceType, instance, scopedInstances);
        }

        /// <inheritdoc cref="IResolver.Inject(object)"/>
        public void Inject(object instance)
        {
            // Get instance type
            var instanceType = instance.GetType();

            // Create a scoped dictionary of instances
            var scopedInstances = new Dictionary<Type, object>();

            this.Inject(instanceType, instance, scopedInstances);
        }

        /// <inheritdoc cref="IResolver.Resolve{T}"/>
        public T Resolve<T>(IDictionary<Type, object> scopedInstances)
        {
            return (T)Resolve(typeof(T), scopedInstances);
        }

        /// <inheritdoc cref="IResolver.Resolve(Type)"/>
        public object Resolve(Type type, IDictionary<Type, object> scopedInstances)
        {
            var bindingData = this.binder.GetBindingFor(type);

            if (bindingData == null)
                return null;

            if (bindingData.InstanceType.HasFlag(BindingInstanceType.Instance))
            {
                if (bindingData.InstanceType.HasFlag(BindingInstanceType.Factory))
                {
                    var instValue = bindingData.Factory.CreateInstance(bindingData);
                    this.Inject(instValue);
                    return instValue;
                }
                else
                    return bindingData.Value;
            }

            object instance = this.Instantiate(bindingData.Value as Type, bindingData, scopedInstances);

            if (bindingData.InstanceType.HasFlag(BindingInstanceType.Singleton))
            {
                bindingData.InstanceType = BindingInstanceType.Instance;
                bindingData.Value = instance;
            }
            else if (bindingData.InstanceType.HasFlag(BindingInstanceType.Factory))
            {
                bindingData.InstanceType = BindingInstanceType.Factory | BindingInstanceType.Instance;

                if (bindingData.Factory == null)
                    bindingData.Factory = instance as IFactory;
                else
                    (bindingData.Factory as IFectorySetter).SetFactoryinstance(instance);

                return bindingData.Factory.CreateInstance(bindingData);
            }

            return instance;
        }

        protected object Resolve(Type type)
        {
            return this.Resolve(type, null);
        }

        /// <inheritdoc cref="IResolver.Resolve(object[], Type[])"/>
        public object[] Resolve(object[] objects, Type[] types, IDictionary<Type, object> scopedInstances)
        {
            if (objects == null)
                return null;

            int length = objects.Length;
            var resolvedObjects = new object[length];
            for (int i = 0; i < length; i++)
                resolvedObjects[i] = objects[i] ?? this.Resolve(types[i], scopedInstances);

            return resolvedObjects;
        }

        /// <summary>
        /// Instantiate and resolve dependencies for the specified type.
        /// </summary>
        /// <param name="type">The type to be instantiated.</param>
        protected object Instantiate(Type instanceType, IBindingData bindingData, IDictionary<Type, object> scopedInstances)
        {
            if (instanceType.IsInterface)
                throw new Exception(
                    string.Format(Causes.CANNOT_INSTANTIATE_INTERFACE,
                                  instanceType.ToString()));

            object instance = null;

            if (bindingData.InstantiationConstructor == null)
            {
                // Use the default constructor (without hook)
                instance = Activator.CreateInstance(instanceType);
            }
            else
            {
                // Constructor method for creating an instance
                var constructorInfo = bindingData.InstantiationConstructor;
                // Getting an instance of the 'HookManager' class for the constructor method.
                var hookManager = bindingData[constructorInfo.MethodBase].HookManager;
                // InvokeData
                var invokeData = hookManager.InvokeData;

                // The method must be unhook before calling
                hookManager.Unhook();

                if (invokeData.ArgumentsObjects == null)
                    // Use the specified constructor without parameters
                    instance = constructorInfo.ctorInvoke();
                else
                {
                    // Resolve dependency for each parameter specified in the binding if its value is null
                    int length = invokeData.ArgumentsObjects.Length;
                    var arguments = new object[length];
                    for (int i = 0; i < length; i++)
                        arguments[i] = invokeData.ArgumentsObjects[i] ?? 
                                       this.Resolve(invokeData.ArgumentTypes[i], scopedInstances);

                    // Use the specified parameterized constructor
                    instance = constructorInfo.ctorArgsInvoke(arguments);
                }

                // Restoring the hook
                hookManager.Hook();
            }

            if (scopedInstances != null)
            {
                // Add an item to the scoped dictionary
                scopedInstances.Add(bindingData.Type, instance);
                // Dependency Injection
                this.Inject(instance, this.cache[instanceType], scopedInstances);
            }
            else
            {
                this.Inject(instance);
            }

            return instance;
        }

        /// <summary>
        /// Injects dependencies on an instance of an object.
        /// </summary>
        /// <param name="instance">The instance to have its dependencies resolved.</param>
        /// <param name="reflectedData">The reflected class related to the <paramref name="instance"/>.</param>
        protected void Inject(object instance, IReflectedData reflectedData, IDictionary<Type, object> scopedInstances)
        {
            if (reflectedData.FieldsInfo.Length > 0)
                this.InjectFields(instance, reflectedData.FieldsInfo, scopedInstances);

            if (reflectedData.PropertiesInfo.Length > 0)
                this.InjectProperties(instance, reflectedData.PropertiesInfo, scopedInstances);
        }

        /// <summary>
        /// Injects on fields.
        /// </summary>
        /// <remarks>
        /// The value is set only if the field does not have a set value yet.
        /// </remarks>
        /// <param name="instance">The instance to have its dependencies resolved.</param>
        /// <param name="fields">Public fields of the type that can receive injection.</param>
        protected void InjectFields(object instance, AccessoriesInfo[] fields, IDictionary<Type, object> scopedInstances)
        {
            for (int fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
            {
                var field = fields[fieldIndex];
                var fieldType = field.Type;
                var value = field.InvokeGetter(instance);

                // The Equals(null) comparison is used to ensure that null is evaluated correctly due to the null trick
                if (value == null || value.Equals(null))
                {
                    try
                    {
                        var valueToSet = scopedInstances.ContainsKey(fieldType) ? scopedInstances[fieldType] : this.Resolve(fieldType, scopedInstances);
                        field.InvokeSetter(instance, valueToSet);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(
                            string.Format(Causes.UNABLE_TO_INJECT_ON_FIELD, field.Name, instance.GetType(), exception.Message), exception);
                    }
                }
                else if (fieldType.IsArray) 
                {
                    try
                    {
                        var elemType = fieldType.GetElementType();
                        var array = (field.InvokeGetter(instance) as object[]);
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] == null)
                                array[i] = this.Resolve(elemType);
                        }
                        scopedInstances.Add(fieldType, array);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(
                            string.Format(Causes.UNABLE_TO_INJECT_ON_FIELD, field.Name, instance.GetType(), exception.Message), exception);
                    }
                }
            }
        }

        /// <summary>
        /// Injects on properties.
        /// </summary>
        /// <remarks>
        /// The value is set only if the property does not have a set value yet.
        /// </remarks>
        /// <param name="instance">The instance to have its dependencies resolved.</param>
        /// <param name="properties">Public properties of the type that can receive injection.</param>
        protected void InjectProperties(object instance, AccessoriesInfo[] properties, IDictionary<Type, object> scopedInstances)
        {
            for (int propertyIndex = 0; propertyIndex < properties.Length; propertyIndex++)
            {
                var property = properties[propertyIndex];

                var value = property.InvokeGetter == null ?
                    null : property.InvokeGetter(instance);

                // The Equals(null) comparison is used to ensure that null is evaluated correctly due to the null trick
                if (value == null || value.Equals(null))
                {
                    try
                    {
                        var valueToSet = scopedInstances.ContainsKey(property.Type) ? scopedInstances[property.Type] : this.Resolve(property.Type, scopedInstances);
                        property.InvokeSetter(instance, valueToSet);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(
                            string.Format(Causes.UNABLE_TO_INJECT_ON_PROPERTY, property.Name, instance.GetType(), exception.Message), exception);
                    }
                }
            }
        }
    }
}
