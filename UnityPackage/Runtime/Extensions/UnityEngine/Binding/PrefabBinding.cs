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

namespace EasyJection.Extensions
{
#if UNITY_ENGINE_AVAILABLE

    using UnityEngine;
    /// <summary>
    /// Represents a prefab's binding.
    /// </summary>
    public class PrefabBinding
    {
        public string KeyName { get; private set; }
        /// <summary>
        /// The prefab to instantiate.
        /// </summary>
        public Object Prefab { get; set; }

        /// <summary>
        /// The type that will be resolved from the prefab.
        /// </summary>
        public System.Type Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefabBinding"/> class.
        /// </summary>
        /// <param name="prefab">The prefab to be instantiated.</param>
        /// <param name="type">The type that will be resolved from the prefab.</param>
        public PrefabBinding(string key, Object prefab, System.Type type)
        {
            this.KeyName = key;
            this.Prefab = prefab;
            this.Type = type;
        }

        public PrefabBinding(string key, System.Type type)
            : this(key, null, type)
        { }
    }
#endif
}
