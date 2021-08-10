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
#if UNITY_WINRT && !NET_LEGACY
        using System.Windows;
        using System.Windows.Input;
#else
    #region Comment
    /// <summary>
    /// The ICommand interface is the code contract for commands.
    /// <para>Methods:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="ICommand.Execute(object)"/></term>
    ///         <description>Defines the method to be called when the command is invoked.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="ICommand.CanExecute(object)"/></term>
    ///         <description>Defines the method that determines whether the command can execute in its current state.</description>
    ///     </item>
    /// </list>
    /// <para>Events:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="ICommand.CanExecuteChanged"/></term>
    ///         <description>Occurs when changes occur that affect whether or not the command should execute.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface ICommand
    {
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="argument">Data used by the command. If the command does not require data to be passed, this object can be set to NULL.</param>
        void Execute(object argument);

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="argument">Data used by the command. If the command does not require data to be passed, this object can be set to NULL.</param>
        /// <returns>True if this command can be executed; otherwise, False.</returns>
        bool CanExecute(object argument);

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        event EventHandler CanExecuteChanged;
    }
#endif
}