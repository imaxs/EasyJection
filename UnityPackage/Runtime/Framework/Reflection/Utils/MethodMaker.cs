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

namespace EasyJection.Reflection.Utils
{
    public static class MethodMaker
    {
        #region Comment
        /// <summary>
        /// Creates a constructor method with no parameters for an object.
        /// </summary>
        /// <param name="constructor">Constructor info used to create the function.</param>
        /// <returns>The object constructor.</returns>
        #endregion
        public static ConstructorCall CreateConstructor(System.Reflection.ConstructorInfo constructor)
        {
            return () => {
                return constructor.Invoke(null);
            };
        }

        #region Comment
        /// <summary>
        /// Creates a constructor method with parameters for an object of types.
        /// </summary>
        /// <param name="constructor">Constructor info used to create the function.</param>
        /// <returns>The object constructor.</returns>
        #endregion
        public static ParamsConstructorCall CreateParameterizedConstructor(System.Reflection.ConstructorInfo constructor)
        {
            return (object[] parameters) => {
                return constructor.Invoke(parameters);
            };
        }

        #region Comment
        /// <summary>
        /// Creates a field setter method.
        /// </summary>
        /// <param name="fieldInfo">Field info object.</param>
        /// <returns>The field setter.</returns>
        #endregion
        public static SetterCall CreateFieldSetter(System.Reflection.FieldInfo fieldInfo)
        {
            return (object instance, object value) => fieldInfo.SetValue(instance, value);
        }

        #region Comment
        /// <summary>
        /// Creates a field getter method.
        /// </summary>
        /// <param name="fieldInfo">Field info object.</param>
        /// <returns>The field getter.</returns>
        #endregion
        public static GetterCall CreateFieldGetter(System.Reflection.FieldInfo fieldInfo)
        {
            return (object instance) => fieldInfo.GetValue(instance);
        }

        #region Comment
        /// <summary>
        /// Creates a property setter method.
        /// </summary>
        /// <param name="propertyInfo">Property info object.</param>
        /// <returns>The property setter.</returns>
        #endregion
        public static SetterCall CreatePropertySetter(System.Reflection.PropertyInfo propertyInfo)
        {
            return (object instance, object value) => propertyInfo.SetValue(instance, value, null);
        }

        #region Comment
        /// <summary>
        /// Creates a property getter method.
        /// </summary>
        /// <param name="propertyInfo">Property info object.</param>
        /// <returns>The property getter or null if the property can't be read.</returns>
        #endregion
        public static GetterCall CreatePropertyGetter(System.Reflection.PropertyInfo propertyInfo)
        {
            if (propertyInfo.CanRead)
            {
                return (object instance) => propertyInfo.GetValue(instance, null);
            }
            else
            {
                return null;
            }
        }

        #region Comment
        /// <summary>
        /// Creates method call without parameters.
        /// </summary>
        /// <param name="methodInfo">Method info object.</param>
        /// <returns>The method caller.</returns>
        #endregion
        public static MethodCall CreateParameterlessMethod(System.Reflection.MethodInfo methodInfo)
        {
            return (object instance) => methodInfo.Invoke(instance, null);
        }

        #region Comment
        /// <summary>
        /// Creates method call with parameters.
        /// </summary>
        /// <param name="methodInfo">Method info object.</param>
        /// <returns>The method caller.</returns>
        #endregion
        public static ParamsMethodCall CreateParameterizedMethod(System.Reflection.MethodInfo methodInfo)
        {
            return (object instance, object[] parameters) => methodInfo.Invoke(instance, parameters);
        }

        public static InstantiatorCall CreateInstantinateMethod(System.Reflection.MethodInfo methodInfo)
        {
            return (object instance) => methodInfo.Invoke(instance, null);
        }
    }
}
