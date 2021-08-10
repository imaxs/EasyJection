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

namespace EasyJection.Architecture
{
    #region Comment
    /// <summary>
    /// Provides data for the PropertyChanged event.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IPropertyChangedEventArgs.PropertyName"/></term>
    ///         <description>Contains the name of the property that changed.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IPropertyChangedEventArgs
    {
        /// <summary>Contains the name of the property that changed.</summary>
        string PropertyName { get; }
    }
}