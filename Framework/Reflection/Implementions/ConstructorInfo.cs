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

namespace EasyJection.Reflection
{
    using Utils;
    public class ConstructorInfo
    {
        public MethodBase MethodBase { get; private set; }

        /// <summary>The parameterless constructor of the type.</summary>
        public ConstructorCall ctorInvoke { get; private set; }

        /// <summary>The constructor with parameters of the type.</summary>
        public ParamsConstructorCall ctorArgsInvoke { get; private set; }

        public ConstructorInfo(System.Reflection.ConstructorInfo constructorInfo) 
        {
            this.MethodBase = constructorInfo;
            if (constructorInfo.GetParameters().Length > 0)
            {
                this.ctorInvoke = null;
                this.ctorArgsInvoke = MethodMaker.CreateParameterizedConstructor(constructorInfo);
            }
            else
            {
                this.ctorArgsInvoke = null;
                this.ctorInvoke = MethodMaker.CreateConstructor(constructorInfo);
            }
        }

        public ConstructorInfo(System.Reflection.ConstructorInfo constructorInfo, ConstructorCall constructorWithoutParameters) 
        {
            this.MethodBase = constructorInfo;
            this.ctorArgsInvoke = null;
            this.ctorInvoke = constructorWithoutParameters;
        }
        public ConstructorInfo(System.Reflection.ConstructorInfo constructorInfo, ParamsConstructorCall constructorParameterized)
        {
            this.MethodBase = constructorInfo;
            this.ctorInvoke = null;
            this.ctorArgsInvoke = constructorParameterized;
        }
    }
}
