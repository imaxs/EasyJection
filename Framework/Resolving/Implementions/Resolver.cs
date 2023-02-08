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

namespace EasyJection.Resolving
{
    using Binding;
    using EasyJection.Hooking;
    using EasyJection.Types;
    using Reflection;

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

        /// <inheritdoc cref="IResolver.Inject(object)"/>
        public void Inject(object instance)
        {
            var reflectedData = this.cache[instance.GetType()];
            this.Inject(instance, reflectedData);
        }

        /// <inheritdoc cref="IResolver.Resolve{T}"/>
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        /// <inheritdoc cref="IResolver.Resolve(Type)"/>
        public object Resolve(Type type)
        {
            var bindingData = this.binder.GetBindingFor(type);

            if (bindingData == null)
                return null;

            if (bindingData.InstanceType.HasFlag(BindingInstanceType.Instance))
            {
                if (bindingData.InstanceType.HasFlag(BindingInstanceType.Factory))
                    return bindingData.Factory.CreateInstance(bindingData);
                else
                    return bindingData.Value;
            }

            object instance = this.Instantiate(bindingData.Value as Type, bindingData);

            if (bindingData.InstanceType.HasFlag(BindingInstanceType.Singleton))
            {
                bindingData.InstanceType = BindingInstanceType.Instance;
                bindingData.Value = instance;
            }
            else if (bindingData.InstanceType.HasFlag(BindingInstanceType.Factory))
            {
                bindingData.InstanceType = BindingInstanceType.Factory | BindingInstanceType.Instance;
                bindingData.Factory = instance as IFactory;
                return bindingData.Factory.CreateInstance(bindingData);
            }

            return instance;
        }

        /// <inheritdoc cref="IResolver.Resolve(object[], Type[])"/>
        public object[] Resolve(object[] objects, Type[] types)
        {
            if (objects == null)
                return null;

            int length = objects.Length;
            var resolvedObjects = new object[length];
            for (int i = 0; i < length; i++)
                resolvedObjects[i] = objects[i] ?? this.Resolve(types[i]);

            return resolvedObjects;
        }

        /// <summary>
        /// Instantiate and resolve dependencies for the specified type.
        /// </summary>
        /// <param name="type">The type to be instantiated.</param>
        protected object Instantiate(Type instanceType, IBindingData bindingData)
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
                                       this.Resolve(invokeData.ArgumentTypes[i]);

                    // Use the specified parameterized constructor
                    instance = constructorInfo.ctorArgsInvoke(arguments);
                }

                // Restoring the hook
                hookManager.Hook();
            }

            // Dependency Injection
            this.Inject(instance, this.cache[instanceType]);

            return instance;
        }

        /// <summary>
        /// Injects dependencies on an instance of an object.
        /// </summary>
        /// <param name="instance">The instance to have its dependencies resolved.</param>
        /// <param name="reflectedData">The reflected class related to the <paramref name="instance"/>.</param>
        protected void Inject(object instance, IReflectedData reflectedData)
        {
            if (reflectedData.FieldsInfo.Length > 0)
                this.InjectFields(instance, reflectedData.FieldsInfo);

            if (reflectedData.PropertiesInfo.Length > 0)
                this.InjectProperties(instance, reflectedData.PropertiesInfo);
        }

        /// <summary>
        /// Injects on fields.
        /// </summary>
        /// <remarks>
        /// The value is set only if the field does not have a set value yet.
        /// </remarks>
        /// <param name="instance">The instance to have its dependencies resolved.</param>
        /// <param name="fields">Public fields of the type that can receive injection.</param>
        protected void InjectFields(object instance, AccessoriesInfo[] fields)
        {
            for (int fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
            {
                var field = fields[fieldIndex];

                var value = field.InvokeGetter(instance);

                // The Equals(null) comparison is used to ensure that null is evaluated correctly due to the null trick
                if (value == null || value.Equals(null))
                {
                    try
                    {
                        var valueToSet = this.Resolve(field.Type);
                        field.InvokeSetter(instance, valueToSet);
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
        protected void InjectProperties(object instance, AccessoriesInfo[] properties)
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
                        var valueToSet = this.Resolve(property.Type);
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
