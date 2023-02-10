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
    /// <summary>
    /// Parameter info.
    /// </summary>
    public class ParameterInfo : IParameterInfo
    {
        /// <summary>Setter type.</summary>
        public Type Type { get; private set; }
        /// <summary>Parameter name.</summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasyJection.Reflection.ParameterInfo"/> class.
        /// </summary>
        /// <param name="type">Setter type.</param>
        /// <param name="name">Parameter name.</param>
        public ParameterInfo(Type type, string name)
        {
            this.Type = type;
            this.Name = name;
        }
    }
}
