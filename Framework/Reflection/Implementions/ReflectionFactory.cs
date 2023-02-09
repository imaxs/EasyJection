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

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WII || UNITY_IOS || UNITY_ANDROID || UNITY_PS4 || UNITY_XBOXONE || UNITY_TIZEN || UNITY_TVOS || UNITY_WSA || UNITY_WEBGL || UNITY_FACEBOOK
#define UNITY_ENGINE_AVAILABLE
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EasyJection.Reflection
{
    using Binding.Extensions;
#pragma warning disable 0618
    public class ReflectionFactory : IReflectionFactory
    {
        /// <inheritdoc cref="IReflectionFactory.Create(Type)"/>
        public IReflectedData Create(Type type)
        {
            return new ReflectedData(type,
                                     this.GetConstructors(type),
                                     this.GetProperties(type),
                                     this.GetFields(type),
                                     this.GetMethods(type));
        }

        #region Private Methods
        private ParameterInfo[][] GetParameters(_MethodBase[] methods)
        {
            ParameterInfo[][] args = new ParameterInfo[methods.Length][];

            for (int i = 0; i < args.Length; i++)
                args[i] = GetParameters(methods[i]);

            return args;
        }

        private ParameterInfo[] GetParameters(_MethodBase method)
        {
            var _params = method.GetParameters();
            if (_params == null || _params.Length == 0)
                return null;

            var methodParameters = new ParameterInfo[_params.Length];

            for (int i = 0; i < _params.Length; i++)
            {
                var parameter = _params[i];
                methodParameters[i] = new ParameterInfo(parameter.ParameterType, parameter.Name);
            }

            return methodParameters;
        }

        private ConstructorInfo[] GetConstructors(System.Reflection.ConstructorInfo[] constructors)
        {
            var ctors = new ConstructorInfo[constructors.Length];

            for (int i = 0; i < ctors.Length; i++)
                ctors[i] = new ConstructorInfo(constructors[i]);

            return ctors;
        }
        #endregion

        #region Comment
        /// <summary>
        /// Get information about the constructors.
        /// </summary>
        /// <param name="type">Type from which reflection will be resolved.</param>
        /// <returns>A tuple containing information about constructors and their parameters.</returns>
        #endregion
        private (ConstructorInfo[] ctors, ParameterInfo[][] pars) GetConstructors(Type type)
        {
            return GetConstructors(type, new List<System.Reflection.ConstructorInfo>(capacity: 16));
        }

        private (ConstructorInfo[] ctors, ParameterInfo[][] pars) GetConstructors(Type type, List<System.Reflection.ConstructorInfo> list)
        {
            var ctors = type.GetConstructors(   BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Instance);

            list.AddRange(ctors);

            //var baseType = type.BaseType();
            //if (baseType != null && baseType != typeof(Object))
            //    return GetConstructors(baseType, list);

            var arr = list.ToArray();

            return (ctors: GetConstructors(arr),
                    pars: GetParameters(arr));
        }

        #region Comment
        /// <summary>
        /// Get information about the methods.
        /// </summary>
        /// <returns>A tuple containing information about methods and their parameters.</returns>
        #endregion
        private (MethodInfo[] methods, ParameterInfo[][] pars) GetMethods(Type type)
        {
            var methods = type.GetMethods(BindingFlags.FlattenHierarchy |
                                            BindingFlags.Public |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Instance);

            var methodsList = new List<MethodInfo>(capacity: methods.Length);
            var argumentsList = new List<ParameterInfo[]>(capacity: methods.Length);

            for (int i = 0; i < methods.Length; i++)
            {
                if (methods[i].DeclaringType == typeof(Object) || methods[i].IsSpecialName)
                    continue;

                methodsList.Add(new MethodInfo(methods[i]));
                argumentsList.Add(GetParameters(methods[i]));
            }

            return (methods: methodsList.ToArray(),
                    pars: argumentsList.ToArray());
        }

        //private (ConstructorInfo[] ctors, ParameterInfo[][] pars) GetMethods(Type type, List<System.Reflection.MethodInfo> list)
        //{

        //}

        #region Comment
        /// <summary>
        /// Get information about the fields.
        /// </summary>
        /// <returns>The array of fields.</returns>
        #endregion
        private AccessoriesInfo[] GetFields(Type type)
        {
            return GetFields(type, new List<AccessoriesInfo>(capacity: 16));
        }

        private AccessoriesInfo[] GetFields(Type type, IList<AccessoriesInfo> list)
        {
            var fields = type.GetFields(BindingFlags.Public |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Instance |
                                        BindingFlags.DeclaredOnly);

            for (int i = 0; i < fields.Length; i++)
                list.Add(new AccessoriesInfo(fields[i]));

            var baseType = type.BaseType();
            if  (baseType != null && baseType != typeof(Object)
#if UNITY_ENGINE_AVAILABLE
                && baseType != EasyJection.Extensions.UnityEngineBinding.TYPE_MONOBEHAVIOUR
                && baseType != EasyJection.Extensions.UnityEngineBinding.TYPE_GAMEOBJECT
                && baseType != EasyJection.Extensions.UnityEngineBinding.TYPE_COMPONENT
#endif
             )
            {
                return GetFields(baseType, list);
            }

            return list.ToArray();
        }

        #region Comment
        /// <summary>
        /// Get information about the properties.
        /// </summary>
        /// <returns>The array of properties.</returns>
        #endregion
        private AccessoriesInfo[] GetProperties(Type type)
        {
            return GetProperties(type, new List<AccessoriesInfo>(capacity: 16));
        }

        private AccessoriesInfo[] GetProperties(Type type, IList<AccessoriesInfo> list)
        {
            var props = type.GetProperties(BindingFlags.Public |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Instance |
                                            BindingFlags.DeclaredOnly);

            for (int i = 0; i < props.Length; i++)
                list.Add(new AccessoriesInfo(props[i]));

            var baseType = type.BaseType();
            if (baseType != null && baseType != typeof(Object)
#if UNITY_ENGINE_AVAILABLE
                && baseType != EasyJection.Extensions.UnityEngineBinding.TYPE_MONOBEHAVIOUR
                && baseType != EasyJection.Extensions.UnityEngineBinding.TYPE_GAMEOBJECT
                && baseType != EasyJection.Extensions.UnityEngineBinding.TYPE_COMPONENT
#endif
             )
            {
                return GetProperties(baseType, list);
            }

            return list.ToArray();
        }
    }
}
