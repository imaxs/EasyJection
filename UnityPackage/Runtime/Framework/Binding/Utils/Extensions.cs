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

namespace EasyJection.Binding.Extensions
{
    public static class Extensions
    {
        public static string TypesString(Type[] types)
        {
            string value = "";
            int lastIndex = types.Length - 1;
            for (int i = 0; i < lastIndex; i++)
                value += types[i].Name + ", ";
            return value + types[lastIndex];
        }

        #region Comment
        /// <summary>
        /// Gets the type from which the given <see cref="Type"/> directly inherits.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to evaluate.</param>
        /// <returns>The <see cref="Type"/> from which the current <see cref="Type"/> directly inherits, 
        /// or NULL if the current <see cref="Type"/> does not inherit (e.g. an <see cref="object"/> or interface).
        /// </returns>
        #endregion
        public static Type BaseType(this Type type)
        {
#if UNITY_WINRT && ENABLE_DOTNET && !UNITY_EDITOR
            return type.GetTypeInfo().BaseType;
#else
            return type.BaseType;
#endif
        }

        #region Comment
        /// <summary>
        /// Determines if the given <see cref="Type"/> is a <see cref="ValueType"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to evaluate.</param>
        /// <returns>True if type is a <see cref="ValueType"/>, otherwise False.</returns>
        #endregion
        public static bool IsValueType(this Type type)
        {
#if UNITY_WINRT && ENABLE_DOTNET && !UNITY_EDITOR
            return type.GetTypeInfo().IsValueType;
#else
            return type.IsValueType;
#endif
        }

        public static ConstructorInfo FindDefaultConstructor(this Type type)
        {
            var ctors = type.GetConstructors(   BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Instance);

            

            for (int index = 0; index < ctors.Length; index++)
            {
                UnityEngine.Debug.Log("[" + ctors[index].DeclaringType.Name + "]: ");
                if (ctors[index].GetParameters().Length == 0)
                    return ctors[index];
            }

            throw new Exception(string.Format(Causes.CONSTRUCTOR_NOT_FOUND, type.Name));
        }

        public static ConstructorInfo FindConstructorWithArguments(this Type type, Type[] types)
        {
            var ctors = type.GetConstructors(   BindingFlags.FlattenHierarchy |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Instance);

            for (int index = 0; index < ctors.Length; index++)
            {
                var args = ctors[index].GetParameters();
                if (args.Length == types.Length)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i].ParameterType != types[i])
                            goto CONTINUE_SEARCH;
                    }
                    return ctors[index];
                }
            CONTINUE_SEARCH:;
            }

            throw new Exception(string.Format(Causes.CONSTRUCTOR_WITH_ARGUMENTS_NOT_FOUND, TypesString(types), type.Name));
        }

        public static ConstructorInfo FindConstructorWithArguments<T>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2, T3>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2), typeof(T3) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2, T3, T4>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2, T3, T4, T5>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2, T3, T4, T5, T6>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2, T3, T4, T5, T6, T7>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2, T3, T4, T5, T6, T7, T8>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) });
        }

        public static ConstructorInfo FindConstructorWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Type type)
        {
            return FindConstructorWithArguments(type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
        }

        public static MethodInfo FindMethodByName(this Type type, string methodName)
        {
            var methods = type.GetMethods(BindingFlags.FlattenHierarchy |
                                          BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Static |
                                          BindingFlags.Instance);

            for (int i = 0; i < methods.Length; i++)
            {
                if (String.CompareOrdinal(methods[i].Name, methodName) == 0)
                {
                    if (methods[i].GetParameters().Length == 0)
                        return methods[i];
                }
            }

            throw new Exception(string.Format(Causes.METHOD_NOT_FOUND, methodName, type.Name));
        }

        public static MethodInfo FindMethodByNameWithArguments<T>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2, T3>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2), typeof(T3) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2, T3, T4>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2, T3, T4, T5>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6, T7>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) });
        }

        public static MethodInfo FindMethodByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Type type, string methodName)
        {
            return FindMethodByNameWithArguments(type, methodName, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
        }

        public static MethodInfo FindMethodByNameWithArguments(this Type type, string methodName, Type[] types) 
        {
            var methods = type.GetMethods(BindingFlags.FlattenHierarchy |
                                          BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Static |
                                          BindingFlags.Instance);

            for (int index = 0; index < methods.Length; index++)
            {
                if (methods[index].DeclaringType == typeof(object) || methods[index].IsSpecialName)
                    continue;

                if (String.CompareOrdinal(methodName, methods[index].Name) == 0)
                {
                    var args = methods[index].GetParameters();
                    if (args.Length == types.Length)
                    {
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i].ParameterType != types[i])
                                goto CONTINUE_SEARCH;
                        }
                        return methods[index];
                    }
                }
            CONTINUE_SEARCH:;
            }

            throw new Exception(string.Format(Causes.METHOD_WITH_ARGUMENTS_NOT_FOUND, methodName, TypesString(types), type.Name));
        }

        public static MethodInfo FindMethodResultByName<TResult>(this Type type, string methodName)
        {
            var methods = type.GetMethods(BindingFlags.FlattenHierarchy |
                                          BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Static |
                                          BindingFlags.Instance);

            for (int index = 0; index < methods.Length; index++)
            {
                if (methods[index].DeclaringType == typeof(object) || methods[index].IsSpecialName)
                    continue;

                if (String.CompareOrdinal(methodName, methods[index].Name) == 0)
                {
                    if(methods[index].ReturnType.Equals(typeof(TResult)))
                        return methods[index];
                }
            }

            throw new Exception(string.Format(Causes.METHOD_NOT_FOUND, methodName, type.Name));
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, T3, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, T3, T4, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Type type, string methodName)
        {
            return FindMethodResultByNameWithArguments(type, methodName, typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
        }

        public static MethodInfo FindMethodResultByNameWithArguments(this Type type, string methodName, Type returnType, Type[] types)
        {
            var methods = type.GetMethods(BindingFlags.FlattenHierarchy |
                                          BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Static |
                                          BindingFlags.Instance);

            for (int index = 0; index < methods.Length; index++)
            {
                if (methods[index].DeclaringType == typeof(object) || methods[index].IsSpecialName)
                    continue;

                if (String.CompareOrdinal(methodName, methods[index].Name) == 0)
                {
                    var args = methods[index].GetParameters();
                    if (args.Length == types.Length && 
                        methods[index].ReturnType.Equals(returnType))
                    {
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i].ParameterType != types[i])
                                goto CONTINUE_SEARCH;
                        }
                        return methods[index];
                    }
                }
            CONTINUE_SEARCH:;
            }

            throw new Exception(string.Format(Causes.METHOD_WITH_ARGUMENTS_NOT_FOUND, methodName, TypesString(types), type.Name));
        }
    }
}
