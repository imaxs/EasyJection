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
    #region Delegates for Command Methods
    public delegate bool CanExecuteHandler(object argument);
    public delegate void ExecuteHandler(object argument);
    #endregion

    /// <summary>
    /// A command whose purpose is to pass its methods to other objects by invoking delegates.<br/>
    /// <inheritdoc cref="ICommand"/>
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>Occurs when changes occur that affect whether or not the command should execute.</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>The invoker of the command can check if the command can be executed.</summary>
#if UNITY_WINRT && !NET_LEGACY
        private readonly EventHandler m_RequerySuggested;
        public void InvokeCanExecuteChanged()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }), null);
        }
#else
        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
#endif

        private readonly CanExecuteHandler m_CanExecute;
        private readonly ExecuteHandler m_Execute;

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The delegate to be invoked for the <see cref="Execute(object)"/> method.</param>
        /// <param name="canExecute">The delegate to be invoked for the <see cref="CanExecute(object)"/> method.  If not provided <see cref="CanExecute(object)"/> will always return <c>true</c>.</param>
        public Command(ExecuteHandler execute, CanExecuteHandler canExecute = null)
        {
            m_Execute = execute;
            m_CanExecute = canExecute;
#if UNITY_WINRT && !NET_LEGACY
            m_RequerySuggested = (o, e) => InvokeCanExecuteChanged();
            CommandManager.RequerySuggested += m_RequerySuggested;
#endif
        }

        /// <inheritdoc cref="ICommand.CanExecute(object)"/>
        public bool CanExecute(object argument) => m_CanExecute == null || m_CanExecute.Invoke(argument);

        /// <inheritdoc cref="ICommand.Execute(object)"/>
        public void Execute(object argument) => m_Execute?.Invoke(argument);
    }
}