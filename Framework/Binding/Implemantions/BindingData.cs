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

namespace EasyJection.Binding
{
    using Hooking;
    using Reflection;

    public class BindingData : IBindingData
    {
        /// <inheritdoc cref="IBindingData.Type"/>
        public Type Type { get; }

        /// <inheritdoc cref="IBindingData.Value"/>
        public object Value { get; set; }

        /// <inheritdoc cref="IBindingData.InstantiationConstructor"/>
        public ConstructorInfo InstantiationConstructor { get; set; }

        /// <inheritdoc cref="IBindingData.InstanceType"/>
        public BindingInstanceType InstanceType { get; set; }

        /// <inheritdoc cref="IBindingData.HookedMethods"/>
        public IDictionary<System.Reflection.MethodBase, IHookedMethod> HookedMethods { get; set; }

        public IHookContainer HookContainer { get; set; }

        public IList<IHookedMethod> this[Type hookedMethodType] { get => HookContainer[hookedMethodType]; }

        public IHookedMethod this[System.Reflection.MethodBase methodBase] { get => HookedMethods[methodBase]; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Binding.BindingData"/> class.
        /// </summary>
        /// <param name="type">Type from which the binding is bound to.</param>
        /// <param name="value">Value to which the binding is bound to.</param>
        /// <param name="instanceType">Binding instance type.</param>
        public BindingData(Type type, object value, BindingInstanceType instanceType)
        {
            this.Type = type;
            this.Value = value;
            this.InstanceType = instanceType;
        }
    }
}
