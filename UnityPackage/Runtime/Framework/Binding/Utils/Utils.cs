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

namespace EasyJection.Binding.Utils
{
    /// <summary>
    /// Utility class for types.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Determines whether <paramref name="descendant"/> is the same
        /// or a subclass of <paramref name="baseType"/>.
        /// </summary>
        /// <param name="baseType">Potential base type.</param>
        /// <param name="descendant">Potential descendant type.</param>
        /// <returns>Boolean.</returns>
        public static bool IsAssignable(Type baseType, Type descendant)
        {
            return baseType.Equals(descendant) || baseType.IsAssignableFrom(descendant);
        }
    }
}
