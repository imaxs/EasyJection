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
 
namespace EasyJection
{
    public sealed class Container : IContainer
    {
        public const int DefaultCacheCapacity = 16;

        private IBinder m_Binder;
        /// <inheritdoc cref="IContainer.Binder"/>
        public IBinder Binder { get => m_Binder; }

        private readonly IContainerCache m_ContainerCache;

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="IContainer"/> implementation class.
        /// </summary>
        #endregion
        public Container()
        {
            this.m_Binder = new Binder(this);
            this.m_ContainerCache = new ContainerCache(DefaultCacheCapacity);
        }

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="IContainer"/> implementation class.
        /// </summary>
        #endregion
        public Container(int capacityCache)
        {
            this.m_Binder = new Binder(this);
            this.m_ContainerCache = new ContainerCache(capacityCache);
        }

        #region Comment
        /// <summary>
        /// Creates a new instance of the <see cref="IContainer"/> implementation class.
        /// </summary>
        /// <param name="binder">The instance of a class that implements <see cref="IBinder"/>.</param>
        #endregion
        public Container(IBinder binder, IContainerCache cache)
        {
            this.m_Binder = binder;
            this.m_ContainerCache = cache;
        }

        public void InjectToMethod<T>(string methodName, Object[] arguments = null)
        {
            InjectToMethod(typeof(T), methodName, arguments);
        }

        public void InjectToMethod(Type type, string methodName, Object[] arguments = null)
        {
            ReflectedId reflectedId = type.Reflect();
            ReflectedData data = reflectedId.GetData();
            MethodData methodData = data.GetMethod(methodName);
            if (!methodData.IsEmpty)
                Hook.Cache.Add(reflectedId, new Hook(this, methodData.Info, HookMethod.InjectedMethod, arguments));
        }

        public void Inject(Object instance)
        {
            Type type = instance.GetType();
            Inject(type, instance);
        }

        private void Inject(Type type, Object instance)
        {
            m_ContainerCache.Clear();
            m_ContainerCache.Add(type, instance);
            ReflectedData reflectedData = type.Reflect().GetData();
            Injecting(reflectedData, instance);
        }

        private void Injecting(in ReflectedData data, Object instance)
        {
            if (!data.ParentId.IsEmpty)
                Injecting(data.ParentId.GetData(), instance);

            // UnityEngine.Debug.Log("---- " + data.TypeName + " ----");
            // UnityEngine.Debug.Log("\tCtors.: " + data.ConstructorsData.ConstructorsInfo?.Length);
            // UnityEngine.Debug.Log("\tMethods: " + data.MethodsData.MethodsInfo?.Length);
            // UnityEngine.Debug.Log("\tFields: " + data.FieldsInfo?.Length);
            // UnityEngine.Debug.Log("\tProperties: " + data.PropertiesInfo?.Length);

            if (data.FieldsInfo != null)
                InjectFields(data.FieldsInfo, instance);

            if (data.PropertiesInfo != null) {}
        }

        #region Comment
        /// <summary>
        /// Injection into the fields.
        /// </summary>
        /// <remarks>
        /// The value is set only if the value has not yet been set in the field.
        /// </remarks>
        /// <param name="fields">Fields that can receive injections.</param>
        /// <param name="instance">The instance to have its dependencies resolved.</param>
        #endregion
        private void InjectFields(FieldInfo[] fields, Object instance)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo fieldInfo = fields[i];
                Type fieldType = fieldInfo.FieldType;
                Object value = Implementation(fieldType);
                if (value != null)
                    fieldInfo.SetValue(instance, value);
            }
        }

        private Object[] GetArguments(IBindingData bindData, int length)
        {
            Object[] arguments = new Object[length];
            if (bindData.Arguments != null)
            {
                for (int i = 0; i < length; i++)
                {
                    Object argInstance = bindData.Arguments[i];

                    if (argInstance == null)
                        argInstance = Implementation(bindData.ArgumentTypes[i]);

                    arguments[i] = argInstance;
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                    arguments[i] = Implementation(bindData.ArgumentTypes[i]);
            }
            return arguments;
        }

        private Object Implementation(Type type)
        {
            Object instance = m_ContainerCache[type];
            if (instance == null)
            {
                IBindingData bindData = m_Binder.Get(type);
                if (bindData != null)
                {
                    ReflectedId reflectedId = bindData.Type.Reflect();
                    ReflectedData reflectedData = reflectedId.GetData();

                    if (bindData.ConstructorName == null)
                    {
                        ConstructorData constructorData = reflectedData.GetConstructor(bindData.ArgumentTypes);
                        if (constructorData.IsEmpty)
                            throw new ArgumentException(
                                String.Format(
                                    "{0}.{1} Number of parameters specified does not match the expected number: {2}",
                                    type.Namespace, type.Name, bindData.ArgumentTypes.Length));

                        if (bindData.ArgumentTypes != null)
                            instance = bindData.InstancesFactory.GetInstance(
                                            type, 
                                            constructorData.Info, 
                                            GetArguments(bindData, bindData.ArgumentTypes.Length));
                        else
                            instance = bindData.InstancesFactory.GetInstance(type, constructorData.Info, null);
                    }
                    else
                    {
                        instance = bindData.InstancesFactory.GetInstance(type);  
                        // MethodData customCtorData = reflectedData.GetMethod(bindData.ConstructorName);
                        // if (customCtorData.IsEmpty || 
                        //     customCtorData.Parameters.Length != bindData.ArgumentTypes.Length)
                        // {
                        //     throw new ArgumentException(
                        //         String.Format(
                        //             "{0}.{1} Number of parameters specified does not match the expected number: {2}",
                        //             type.Namespace, type.Name, bindData.ArgumentTypes.Length));
                        // }
                        // if (bindData.ArgumentTypes == null)
                        //     customCtorData.Info.Invoke(instance, null);
                        // else
                        //     customCtorData.Info.Invoke(instance, GetArguments(bindData, bindData.ArgumentTypes.Length));
                    }
                    m_ContainerCache.Add(type, instance);
                    Injecting(reflectedData, instance);
                }
            }
            return instance;
        }
    }
}