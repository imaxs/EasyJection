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
using System.Collections.Generic;
using System.Reflection;

namespace EasyJection
{
    /// <summary>
    /// Static class Reflector provides reflection of objects (of type Type).
    /// </summary>
    public static class Reflector
    {
        private const int DefaultInitialCapacity = 16;

        private static ReflectedCache s_Cache;
        /// <summary>The cache contains previously reflected data.</summary>
        public static ref readonly ReflectedCache Cache => ref s_Cache;

        private static readonly Type s_ObjectType;
        private static readonly List<ConstructorInfo> s_ReusableCtorsInfoList;
        private static readonly List<ParameterInfo[]> s_ReusableCtorsParsInfoList;
        private static readonly List<PropertyInfo> s_ReusablePropsInfoList;
        private static readonly List<FieldInfo> s_ReusableFieldList;
        private static readonly List<MethodInfo> s_ReusableMethodList;
        private static readonly List<ParameterInfo[]> s_ReusableMethodsParsInfoList;
        private static object _rpl;

        static Reflector()
        {
            s_Cache = new ReflectedCache(capacity: ReflectedCache.DefaultCapacity);
            s_ObjectType = typeof(object);
            s_ReusableCtorsInfoList = new List<ConstructorInfo>(capacity: DefaultInitialCapacity);
            s_ReusableCtorsParsInfoList = new List<ParameterInfo[]>(capacity: DefaultInitialCapacity);
            s_ReusablePropsInfoList = new List<PropertyInfo>(capacity: DefaultInitialCapacity);
            s_ReusableFieldList = new List<FieldInfo>(capacity: DefaultInitialCapacity);
            s_ReusableMethodList = new List<MethodInfo>(capacity: DefaultInitialCapacity);
            s_ReusableMethodsParsInfoList = new List<ParameterInfo[]>(capacity: DefaultInitialCapacity);
            _rpl = new object();
        }

        public static void Clear()
        {
            s_Cache.Reset();
            s_ReusableCtorsInfoList.Clear();
            s_ReusableCtorsParsInfoList.Clear();
            s_ReusablePropsInfoList.Clear();
            s_ReusableFieldList.Clear();
            s_ReusableMethodList.Clear();
            s_ReusableMethodsParsInfoList.Clear();
        }

        private static ParameterInfo[][] GetConstructorsParameters()
        {
            ParameterInfo[][] resultAsArray = s_ReusableCtorsParsInfoList.ToArray();
            s_ReusableCtorsParsInfoList.Clear();

            return resultAsArray;
        }

        private static ParameterInfo[][] GetMethodsParameters()
        {
            ParameterInfo[][] resultAsArray = s_ReusableMethodsParsInfoList.ToArray();
            s_ReusableMethodsParsInfoList.Clear();

            return resultAsArray;
        }

        /// Helper methods for performing additional operations on Type, ReflectedId and ReflectedData values.
        #region Extension methods

        /// <summary>Retrieves reflected data by id (<see cref="ReflectedId"/>).</summary>
        /// <returns>Read-only reference to <see cref="ReflectedData"/>.</returns>
        public static ref readonly ReflectedData GetData(this ReflectedId id) => ref s_Cache[id];

        #region Comment
        /// <summary>
        /// Gets a specific method by name.
        /// </summary>
        /// <param name="methodName">The string containing the name of the required method.</param>
        /// <returns><see cref="MethodData"/> instance.</returns>
        #endregion
        public static MethodData GetMethod(in this ReflectedData data, string methodName)
        {
            MethodsData methodsData = data.MethodsData;

            if (!methodsData.IsEmpty)
            {
                int length = methodsData.MethodsInfo.Length;
                for (int i = 0; i < length; i++)
                {
                    MethodInfo methodInfo = methodsData.MethodsInfo[i];
                    if (String.CompareOrdinal(methodInfo.Name, methodName) == 0)
                        return new MethodData(methodInfo, methodsData.MethodsParsInfo[i]);
                }
            }

            return data.ParentId.IsEmpty ? default(MethodData) : data.ParentId.GetData().GetMethod(methodName);
        }

        #region Comment
        /// <summary>
        /// Gets a specific method by index.
        /// </summary>
        /// <param name="methodIndex">The number containing the index of the required method.</param>
        /// <returns><see cref="MethodData"/> instance.</returns>
        #endregion
        public static MethodData GetMethod(in this ReflectedData data, int methodIndex)
        {
            MethodsData methodsData = data.MethodsData;

            if (!methodsData.IsEmpty && methodIndex < methodsData.MethodsInfo.Length)
                return new MethodData(methodsData.MethodsInfo[methodIndex], methodsData.MethodsParsInfo[methodIndex]);

            return data.ParentId.IsEmpty ? default(MethodData) : data.ParentId.GetData().GetMethod(methodIndex);
        }

        #region Comment
        /// <summary>
        /// Gets parameterless constructor.
        /// </summary>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor(in this ReflectedData data)
        {
            ConstructorsData ctorsData = data.ConstructorsData;

            int length = ctorsData.ConstructorsInfo.Length;
            for (int i = 0; i < length; i++)
            {
                ParameterInfo[] parameters = ctorsData.ConstructorsParsInfo[i];
                if (parameters.Length == 0)
                    return new ConstructorData(ctorsData.ConstructorsInfo[i], parameters);
            }

            return data.ParentId.IsEmpty ? default(ConstructorData) : data.ParentId.GetData().GetConstructor();
        }

        #region Comment
        /// <summary>
        /// Gets a constructor with a parameter of specific type <paramref name="T"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/> and <paramref name="T2"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/>, <paramref name="T2"/> and <paramref name="T3"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2, T3>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>  and <paramref name="T4"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2, T3, T4>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>  and <paramref name="T5"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2, T3, T4, T5>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>  and <paramref name="T6"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2, T3, T4, T5, T6>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>  and <paramref name="T7"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2, T3, T4, T5, T6, T7>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/>  and <paramref name="T8"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2, T3, T4, T5, T6, T7, T8>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/>, <paramref name="T8"/>  and <paramref name="T9"/>.
        /// </summary>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(in this ReflectedData data, bool includeBase = true)
            => data.GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) }, includeBase);

        #region Comment
        /// <summary>
        /// Gets a constructor with parameters of specific types.
        /// </summary>
        /// <param name="types">The array contains specific types.</param>
        /// <param name="includeBase">If True, includes base classes.</param>
        /// <returns><see cref="ConstructorData"/> instance.</returns>
        #endregion
        public static ConstructorData GetConstructor(in this ReflectedData data, Type[] types, bool includeBase = true)
        {
            ConstructorsData ctorsData = data.ConstructorsData;

            int length = ctorsData.ConstructorsInfo.Length;
            int lengthTypes = types == null ? 0 : types.Length;

            for (int i = 0; i < length; i++)
            {
                ParameterInfo[] parameters = ctorsData.ConstructorsParsInfo[i];
                int lengthParams = parameters.Length;

                if (lengthParams == lengthTypes)
                {
                    for(int l = 0; l < lengthParams; l++)
                        if(parameters[l].ParameterType != types[l])
                            goto CONTINUE_SEARCH;

                    return new ConstructorData(ctorsData.ConstructorsInfo[i], parameters);
                }
                CONTINUE_SEARCH:;
            }

            return (!includeBase || data.ParentId.IsEmpty) ? default(ConstructorData) : data.ParentId.GetData().GetConstructor(types, includeBase);
        }

        #region Comment
        /// <summary>
        /// Gets a specific field by name.
        /// </summary>
        /// <param name="fieldName">The string containing the name of the required field.</param>
        /// <returns><see cref="FieldInfo"/> instance or Null if field is not found.</returns>
        #endregion
        public static FieldInfo GetField(in this ReflectedData data, string fieldName)
        {
            FieldInfo[] fieldsInfo = data.FieldsInfo;

            if (fieldsInfo != null)
            {
                for (int i = 0; i < fieldsInfo.Length; i++)
                {
                    FieldInfo fieldInfo = fieldsInfo[i];
                    if (String.CompareOrdinal(fieldInfo.Name, fieldName) == 0)
                        return fieldInfo;
                }
            }

            return data.ParentId.IsEmpty ? null : data.ParentId.GetData().GetField(fieldName);
        }

        #region Comment
        /// <summary>
        /// Gets a specific property by name.
        /// </summary>
        /// <param name="propertyName">The string containing the name of the required property.</param>
        /// <returns><see cref="PropertyInfo"/> instance or Null if property is not found.</returns>
        #endregion
        public static PropertyInfo GetProperty(in this ReflectedData data, string propertyName)
        {
            PropertyInfo[] propertiesInfo = data.PropertiesInfo;

            if (propertiesInfo != null)
            {
                for (int i = 0; i < propertiesInfo.Length; i++)
                {
                    PropertyInfo propertyInfo = propertiesInfo[i];
                    if (String.CompareOrdinal(propertyInfo.Name, propertyName) == 0)
                        return propertyInfo;
                }
            }

            return data.ParentId.IsEmpty ? null : data.ParentId.GetData().GetProperty(propertyName);
        }

        #region Comment
        /// <summary>
        /// Retrieves metadata of type.
        /// </summary>
        /// <remarks>
        /// When requesting data of a specific type,
        /// if it doesn't exist in the cache, it's automatically added to the cache.
        /// </remarks>
        /// <param name="type">The Type object representing the given type.</param>
        /// <returns><see cref="ReflectedId"/> instance.</returns>
        #endregion
        public static ReflectedId Reflect(this Type type)
        {
            int casmIndex = s_Cache.GetIndex(type.Namespace);
            if (casmIndex > -1)
            {
                int typeIndex = s_Cache[casmIndex].GetIndex(type.Name);
                if (typeIndex == -1)
                {
                    lock (_rpl)
                    {
                        typeIndex = s_Cache[casmIndex].Add(
                            new ReflectedData(
                                Reflector.GetParentId(type),
                                type.Name,
                                type.IsValueType(),
                                Reflector.GetCtors(type),
                                Reflector.GetConstructorsParameters(),
                                Reflector.GetProperties(type),
                                Reflector.GetFields(type),
                                Reflector.GetMethods(type),
                                Reflector.GetMethodsParameters())
                            );
                    }
                }
                return new ReflectedId(casmIndex, typeIndex);
            }

            lock (_rpl)
            {
                return s_Cache.Add(
                    type.Namespace,
                    new ReflectedData(
                        Reflector.GetParentId(type),
                        type.Name,
                        type.IsValueType(),
                        Reflector.GetCtors(type),
                        Reflector.GetConstructorsParameters(),
                        Reflector.GetProperties(type),
                        Reflector.GetFields(type),
                        Reflector.GetMethods(type),
                        Reflector.GetMethodsParameters())
                    );
            }
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

        #endregion // Extension methods

        private static ReflectedId GetParentId(Type type)
        {
            Type baseType = type.BaseType();
            return baseType == s_ObjectType ? default(ReflectedId) : baseType.Reflect();
        }

        private static MethodInfo[] GetMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            for (int index = 0; index < methods.Length; index++)
            {
                MethodInfo method = methods[index];

                s_ReusableMethodList.Add(method);
                s_ReusableMethodsParsInfoList.Add(method.GetParameters());
            }

            MethodInfo[] resultAsArray = s_ReusableMethodList.ToArray();
            s_ReusableMethodList.Clear();

            return resultAsArray;
        }

        private static FieldInfo[] GetFields(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            for (int index = 0; index < fields.Length; index++)
            {
                FieldInfo field = fields[index];
                s_ReusableFieldList.Add(field);
            }

            FieldInfo[] resultAsArray = s_ReusableFieldList.ToArray();
            s_ReusableFieldList.Clear();

            return resultAsArray;
        }

        private static ConstructorInfo[] GetCtors(Type type)
        {
            ConstructorInfo[] ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            for (int index = 0; index < ctors.Length; index++)
            {
                ConstructorInfo ctor = ctors[index];
                s_ReusableCtorsInfoList.Add(ctor);
                s_ReusableCtorsParsInfoList.Add(ctor.GetParameters());
            }

            ConstructorInfo[] resultAsArray = s_ReusableCtorsInfoList.ToArray();
            s_ReusableCtorsInfoList.Clear();

            return resultAsArray;
        }

        private static PropertyInfo[] GetProperties(Type type)
        {
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            for (int index = 0; index < props.Length; index++)
            {
                PropertyInfo prop = props[index];
                s_ReusablePropsInfoList.Add(prop);
            }

            PropertyInfo[] resultAsArray = s_ReusablePropsInfoList.ToArray();
            s_ReusablePropsInfoList.Clear();

            return resultAsArray;
        }
    }
}