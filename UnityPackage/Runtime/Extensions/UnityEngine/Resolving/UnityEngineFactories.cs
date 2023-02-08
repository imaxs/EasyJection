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
    using EasyJection.Binding;
    using EasyJection.Types;
    using Resolving;
    using UnityEngine;

    public class UnityEngineGameObjectInstantiateFactory : IFactory
    {
        public object CreateInstance(IBindingData bindingData = null)
        {
            return new GameObject((bindingData.Value as Type).Name);
        }
    }

    public class UnityEngineComponentInstantiateFactory : IFactory
    {
        public object CreateInstance(IBindingData bindingData = null)
        {
            return new GameObject((bindingData.Value as Type).Name);
        }
    }
#endif
}
