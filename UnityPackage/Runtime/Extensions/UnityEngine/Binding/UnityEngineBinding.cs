/*
 * This file is part of the EasyJection Framework.
 * Author: Max Karepin (http://github.com/imaxs/)
 *
 * Copyright © 2022 Max Karepin
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

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WII || UNITY_IOS || UNITY_ANDROID || UNITY_PS4 || UNITY_XBOXONE || UNITY_TIZEN || UNITY_TVOS || UNITY_WSA || UNITY_WEBGL || UNITY_FACEBOOK
    #define UNITY_ENGINE_AVAILABLE
#endif

using System;

namespace EasyJection.Extensions
{
#if UNITY_ENGINE_AVAILABLE

    using UnityEngine;
    using Binding;
    using Binding.Utils;
    using Types;

    /// <summary>
    /// Provides binding capabilities to Unity Engine objects.
    /// </summary>
    public static class UnityEngineBinding
    {
        private static IFactory GameObjectFactory;
        private static IFactory ComponentFactory;
        private static Type TYPE_GAMEOBJECT;
        private static Type TYPE_COMPONENT;

        static UnityEngineBinding()
        {
            TYPE_COMPONENT = typeof(Component);
            TYPE_GAMEOBJECT = typeof(GameObject);
            GameObjectFactory = new UnityEngineGameObjectInstantiateFactory();
            ComponentFactory = new UnityEngineComponentInstantiateFactory();
        }

        #region Comment
        /// <summary>
        /// Creates a binding of the key type to the <paramref name="type"/> on a GameObject of a given <paramref name="objectName"/> as a singleton.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Recommend binding only to <see cref="UnityEngine.GameObject"/> that will not be destroyed in the scene to prevent references to destroyed objects.
        /// </para>
        /// <para>
        /// 1️⃣ If the GameObject with the specified  <paramref name="objectName"/> is not found on the game scene, it will be added.
        /// </para>
        /// <para>
        /// 2️⃣ If the GameObject with the specified  <paramref name="objectName"/> is not found on the GameObject, it will be added.
        /// </para>
        /// <para>
        /// 3️⃣ If the <paramref name="type"/> is <see cref="UnityEngine.GameObject"/> binds the key to the GameObject itself.
        /// </para>
        /// <para>
        /// 4️⃣ If the <paramref name="type"/> is <see cref="UnityEngine.Component"/> binds the key to an instance.
        /// </para>
        /// </remarks>
        /// <param name="bindingFactory">The original binding factory.</param>
        /// <param name="type">The component type.</param>
        /// <param name="objectName">The GameObject name.</param>
        /// <returns>The binding condition object related to this binding.</returns>
        #endregion
        public static IBindingInjection ToGameObject(this IBindingFactory bindingFactory, Type type)
        {
            if (!Helper.IsAssignable(bindingFactory.BindingType, type))
                throw new Exception(Causes.TYPE_NOT_ASSIGNABLE);
            if (type.IsInterface || type.IsAbstract)
                throw new Exception(Causes.TYPE_NOT_IMPLEMENTED);
            if (!Helper.IsAssignable(TYPE_GAMEOBJECT, type))
                throw new Exception(string.Format("The \"{0}\" type must be derived from UnityEngine.GameObject.", type.Name));

            return bindingFactory.AddFactoryInstance(type, GameObjectFactory);
        }

        public static IBindingInjection ToGameObject(this IBindingFactory bindingFactory) 
        {
            return bindingFactory.ToGameObject(bindingFactory.BindingType);
        }

        public static IBindingInjection ToComponent(this IBindingFactory bindingFactory, Type type)
        {
            if (!Helper.IsAssignable(bindingFactory.BindingType, type))
                throw new Exception(Causes.TYPE_NOT_ASSIGNABLE);
            if (type.IsInterface || type.IsAbstract)
                throw new Exception(Causes.TYPE_NOT_IMPLEMENTED);
            if (!Helper.IsAssignable(TYPE_COMPONENT, type))
                throw new Exception(string.Format("The \"{0}\" type must be derived from UnityEngine.Component.", type.Name));

            return bindingFactory.AddFactoryInstance(type, ComponentFactory);
        }

        //public static IBindingInjection ToGameObject(this IBindingFactory bindingFactory, Type type, string objectName = null)
        //{

        //    GameObject instance = null;

        //    if (string.IsNullOrEmpty(objectName))
        //        instance = new GameObject(type.Name);
        //    else
        //        instance = GameObject.Find(objectName) ?? new GameObject(type.Name);

        //    return CreateSingletonProvider(bindingFactory, instance, type, objectType);
        //}
        /*
        #region Comment
        /// <summary>
        /// Creates a binding of the key type to the <typeparamref name="T"/> type on a GameObject of a given <paramref name="objectName"/> as a singleton.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the GameObject with the specified  <paramref name="objectName"/> is not found on the GameObject, it will be added.
        /// </para>
        /// </remarks>
        /// <typeparam name="T">The component type.</typeparam>
        /// <param name="bindingFactory">The original binding factory.</param>
        /// <param name="objectName">The GameObject name.</param>
        /// <returns>The binding condition object related to this binding.</returns>
        #endregion
        public static IBindingInjection ToGameObject<T>(this IBindingFactory bindingFactory, string objectName) where T : Component
        {
            return bindingFactory.ToGameObject(typeof(T), objectName);
        }

        #region Comment
        /// <summary>
        /// Creates a binding of the key type to the <typeparamref name="T"/> type on a new GameObject as a singleton.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <typeparam name="T">The component type.</typeparam>
        /// <param name="bindingFactory">The original binding factory.</param>
        /// <returns>The binding condition object related to this binding.</returns>
        #endregion
        public static IBindingInjection ToGameObject<T>(this IBindingFactory bindingFactory) where T : Component
        {
            return bindingFactory.ToGameObject(typeof(T));
        }

        #region Comment
        /// <summary>
        /// Creates a binding of the key type to itself on a new GameObject as a singleton.
        /// ⚠ The key type must be derived either from <see cref="UnityEngine.GameObject"/> or <see cref="UnityEngine.Component"/>.
        /// </summary>
        /// <remarks>
        /// Recommend binding only to <see cref="UnityEngine.GameObject"/> that will not be destroyed in the scene to prevent references to destroyed objects.
        /// </remarks>
        /// <param name="bindingFactory">The original binding factory.</param>
        /// <returns>The binding condition object related to this binding.</returns>
        #endregion
        public static IBindingInjection ToGameObject(this IBindingFactory bindingFactory)
        {
            return bindingFactory.ToGameObject(bindingFactory.BindingType);
        }

        private static UnityEngineBindingCondition CreateSingletonProvider(IBindingFactory bindingFactory, GameObject gameObject, Type type, UnityEngineObjectType objectType)
        {
            if (gameObject == null)
                throw new ArgumentNullException("The argument named 'gameObject' is null");

            if (objectType == UnityEngineObjectType.GameObject)
                return new UnityEngineBindingCondition(bindingFactory.AddBinding(gameObject, BindingInstanceType.Instance, false), gameObject.name);

            var component = gameObject.GetComponent(type) ?? gameObject.AddComponent(type);

            return new UnityEngineBindingCondition(bindingFactory.AddBinding(component, BindingInstanceType.Instance, false), gameObject.name);
        }
        */
    }
#endif
}
