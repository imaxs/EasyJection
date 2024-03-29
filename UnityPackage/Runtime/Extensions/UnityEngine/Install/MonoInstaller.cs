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

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WII || UNITY_IOS || UNITY_ANDROID || UNITY_PS4 || UNITY_XBOXONE || UNITY_TIZEN || UNITY_TVOS || UNITY_WSA || UNITY_WEBGL || UNITY_FACEBOOK
    #define UNITY_ENGINE_AVAILABLE
#endif

using System;

namespace EasyJection
{
    using EasyJection.Extensions;
    using System.Collections.Generic;
#if UNITY_ENGINE_AVAILABLE
    using UnityEngine;

    [DisallowMultipleComponent]
    public abstract class MonoInstaller : MonoBehaviour
    {
        [SerializeField]
        protected StringGameObjectPair[] gameObjects;
        
        protected IContainer Container;

        protected abstract void InstallBindings();

        protected MonoInstaller() 
        {
            if (Container == null)
                Container = new Container();

            this.InstallBindings();
        }

        protected void Awake()
        {
            if (gameObjects != null && gameObjects.Length > 0)
            {
                var dict = new Dictionary<string, GameObject>();

                foreach (var pair in gameObjects)
                    dict.Add(pair.Key, pair.Object);

                Mono.SetDictionary(dict);
            }
        }

        protected void OnDestroy()
        {
            if (Container != null)
                Container.Dispose();
        }
    }
#endif
}
