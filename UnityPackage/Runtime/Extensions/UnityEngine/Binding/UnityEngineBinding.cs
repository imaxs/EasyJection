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
        public static Type TYPE_MONOBEHAVIOUR;
        public static Type TYPE_GAMEOBJECT;
        public static Type TYPE_COMPONENT;

        private static IFactory GameObjectFactory;

        static UnityEngineBinding()
        {
            TYPE_MONOBEHAVIOUR = typeof(MonoBehaviour);
            TYPE_COMPONENT = typeof(Component);
            TYPE_GAMEOBJECT = typeof(GameObject);
            GameObjectFactory = new UnityEngineGameObjectInstantiateFactory();
        }

        public static IBindingInjection ToGameObject<T>(this IBindingFactory bindingFactory)
        {
            var type = typeof(T);
            return bindingFactory.ToGameObject(type, type.Name);
        }

        public static IBindingInjection ToGameObject<T>(this IBindingFactory bindingFactory, string prefabKeyName)
        {
            return bindingFactory.ToGameObject(typeof(T), prefabKeyName);
        }

        public static IBindingInjection ToGameObject(this IBindingFactory bindingFactory, Type type, string gameobjectKey)
        {
            if (!Helper.IsAssignable(bindingFactory.BindingType, type))
                throw new Exception(Causes.TYPE_NOT_ASSIGNABLE);
            if (type.IsInterface || type.IsAbstract)
                throw new Exception(Causes.TYPE_NOT_IMPLEMENTED);

            return bindingFactory.AddFactoryInstance(type, GameObjectFactory, new PrefabBinding(gameobjectKey, type));
        }
    }
#endif
}
