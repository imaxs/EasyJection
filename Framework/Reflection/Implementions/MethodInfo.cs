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

namespace EasyJection.Reflection
{
    using Utils;

    /// <summary>
    /// Method info.
    /// </summary>
    public class MethodInfo
    {
        /// <summary>Method name.</summary>
        public string Name { get; private set; }
        /// <summary>The parameterless method.</summary>
        public MethodCall Method;
        /// <summary>The method with parameters/arguments.</summary>
        public ParamsMethodCall MethodWithArguments;

        #region Comment
        /// <summary>
        /// Initializes a new instance of the <see cref="EasyJection.Reflection.MethodInfo"/> class.
        /// </summary>
        /// <param name="name">Method name.</param>
        /// <param name="parameters">Method parameters' infos.</param>
        #endregion
        public MethodInfo(System.Reflection.MethodInfo methodInfo)
        {
            this.Name = methodInfo.Name;
            if (methodInfo.GetParameters().Length > 0) 
            {
                this.Method = null;
                this.MethodWithArguments = MethodMaker.CreateParameterizedMethod(methodInfo);
            }
            else
            {
                MethodWithArguments = null;
                this.Method = MethodMaker.CreateParameterlessMethod(methodInfo);
            }
        }
    }
}
