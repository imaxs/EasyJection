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

namespace EasyJection.Reflection.Utils
{
    #region Comment
    /// <summary>
    /// Delegate for a constructor call without parameters.
    /// </summary>
    #endregion
    public delegate object ConstructorCall();

    #region Comment
    /// <summary>
    /// Delegate for a constructor call with parameters.
    /// </summary>
    /// <typeparam name="T">Constructor's object type.</typeparam>
    /// <param name="parameters">Constructor parameters.</param>
	#endregion
    public delegate object ParamsConstructorCall(object[] parameters);

    #region Comment
    /// <summary>
    /// Delegate for a method call without parameters.
    /// </summary>
    /// <param name="instance">Instance to call the post constructor.</param>
	#endregion
    public delegate void MethodCall(object instance);

    #region Comment
    /// <summary>
    /// Delegate for a method call with parameters.
    /// </summary>
    /// <param name="instance">Instance to call the post constructor.</param>
    /// <param name="parameters">Post constructor parameters.</param>
    #endregion
    public delegate void ParamsMethodCall(object instance, object[] parameters);

    #region Comment
    /// <summary>
    /// Calls a getter method for a field or property.
    /// </summary>
    /// <param name="instance">Instance to have the field/property gotten.</param>
    /// <returns>Getter value.</returns>
    #endregion
    public delegate object GetterCall(object instance);

    #region Comment
    /// <summary>
    /// Calls a setter method for a field or property.
    /// </summary>
    /// <param name="instance">Instance to have the field/property settled.</param>
    /// <param name="value">Value to set.</param>
    #endregion
    public delegate void SetterCall(object instance, object value);
}
