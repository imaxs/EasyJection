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
    /// <summary>
    /// Represents the method that will handle the PropertyChanged event raised when a property is changed on a component.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="IPropertyChangedEventArgs"/> implementation that contains the event data.</param>
    public delegate void PropertyChangedEventHandler(object sender, IPropertyChangedEventArgs e);

    #region Comment
    /// <summary>
    /// The INotifyPropertyChanged interface is widely used in .NET applications to send notifications when a property has changed its value. 
    /// <para>Events:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="INotifyPropertyChanged.PropertyChanged"/></term>
    ///         <description>Occurs when a property value changes.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
    }
}