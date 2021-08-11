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

namespace EasyJection.Architecture
{
    #region Comment
    /// <summary>
    /// Provides data for the PropertyChanged event.
    /// <inheritdoc cref="IPropertyChangedEventArgs"/>
    /// </summary>
    #endregion
    public class PropertyChangedEventArgs : EventArgs, IPropertyChangedEventArgs
    {
        private readonly string propertyName;

        /// <summary>Initializes a new instance of the <see cref='PropertyChangedEventArgs'/> class.</summary>
        public PropertyChangedEventArgs(string propertyName) => this.propertyName = propertyName;

        /// <inheritdoc cref="IPropertyChangedEventArgs.PropertyName"/>
        public virtual string PropertyName { get => propertyName; }
    }
}