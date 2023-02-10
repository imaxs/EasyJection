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

namespace EasyJection.Resolving.Extensions
{
    using Reflection;
    using Reflection.Utils;
    
    public static class Extensions
    {
        public static ConstructorCall DefaultConstructor(this IReflectedData reflectedData)
        {
            var ctors = reflectedData.ConstructorsData.ConstructorsInfo;
            var _params = reflectedData.ConstructorsData.ConstructorsParsInfo;

            for (int index = 0; index < ctors.Length; index++)
            {
                if (_params[index] == null)
                {
                    return ctors[index].ctorInvoke;
                }
            }

            return null;
        }
        
        public static ParamsConstructorCall FindConstructorWithArguments(this IReflectedData reflectedData, Type[] argumentTypes)
        {
            var ctors = reflectedData.ConstructorsData.ConstructorsInfo;
            var _params = reflectedData.ConstructorsData.ConstructorsParsInfo;

            for (int index = 0; index < ctors.Length; index++)
            {
                var args = _params[index];

                if (args == null || args.Length != argumentTypes.Length)
                    continue;

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].Type != argumentTypes[i])
                        goto CONTINUE_SEARCH;
                }

                return ctors[index].ctorArgsInvoke;

            CONTINUE_SEARCH:;
            }

            return null;
        }

        public static MethodCall FindMethodByName(this IReflectedData reflectedData, string methodName)
        {
            var methods = reflectedData.MethodsData.MethodsInfo;
            var _params = reflectedData.MethodsData.MethodsParsInfo;

            for (int i = 0; i < methods.Length; i++) 
            {
                if (String.CompareOrdinal(methods[i].Name, methodName) == 0)
                {
                    if (_params[i] == null)
                        return methods[i].Method;
                }
            }

            return null;
        }

        public static ParamsMethodCall FindMethodByNameWithArguments(this IReflectedData reflectedData, string methodName, Type[] argumentTypes)
        {
            var methods = reflectedData.MethodsData.MethodsInfo;
            var _params = reflectedData.MethodsData.MethodsParsInfo;

            for (int index = 0; index < methods.Length; index++)
            {
                if (String.CompareOrdinal(methods[index].Name, methodName) == 0)
                {
                    var args = _params[index];
                    if (args != null && args.Length == argumentTypes.Length)
                    {
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i].Type != argumentTypes[i])
                                goto CONTINUE_SEARCH;
                        }
                        return methods[index].MethodWithArguments;
                    }
                }
            CONTINUE_SEARCH:;
            }

            return null;
        }
    }
}
