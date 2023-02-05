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

namespace EasyJection.Binding
{
    public interface IBindingMethodCondition : IBindingInjectionCondition
    {
        IBindingInjectionCondition WithArguments<T>(T param);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/> and <paramref name="T2"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2>(T1 param1, T2 param2);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/> and <paramref name="T3"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <param name="param3">Argument of type <paramref name="T3"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2, T3>(T1 param1, T2 param2, T3 param3);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/> and <paramref name="T4"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <param name="param3">Argument of type <paramref name="T3"/></param>
        /// <param name="param4">Argument of type <paramref name="T4"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/> and <paramref name="T5"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <param name="param3">Argument of type <paramref name="T3"/></param>
        /// <param name="param4">Argument of type <paramref name="T4"/></param>
        /// <param name="param5">Argument of type <paramref name="T5"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/> and <paramref name="T6"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <param name="param3">Argument of type <paramref name="T3"/></param>
        /// <param name="param4">Argument of type <paramref name="T4"/></param>
        /// <param name="param5">Argument of type <paramref name="T5"/></param>
        /// <param name="param6">Argument of type <paramref name="T6"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/> and <paramref name="T7"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <param name="param3">Argument of type <paramref name="T3"/></param>
        /// <param name="param4">Argument of type <paramref name="T4"/></param>
        /// <param name="param5">Argument of type <paramref name="T5"/></param>
        /// <param name="param6">Argument of type <paramref name="T6"/></param>
        /// <param name="param7">Argument of type <paramref name="T7"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6, T7>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/> and <paramref name="T8"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <param name="param3">Argument of type <paramref name="T3"/></param>
        /// <param name="param4">Argument of type <paramref name="T4"/></param>
        /// <param name="param5">Argument of type <paramref name="T5"/></param>
        /// <param name="param6">Argument of type <paramref name="T6"/></param>
        /// <param name="param7">Argument of type <paramref name="T7"/></param>
        /// <param name="param8">Argument of type <paramref name="T8"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6, T7, T8>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/>, <paramref name="T8"/> and <paramref name="T9"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <param name="param3">Argument of type <paramref name="T3"/></param>
        /// <param name="param4">Argument of type <paramref name="T4"/></param>
        /// <param name="param5">Argument of type <paramref name="T5"/></param>
        /// <param name="param6">Argument of type <paramref name="T6"/></param>
        /// <param name="param7">Argument of type <paramref name="T7"/></param>
        /// <param name="param8">Argument of type <paramref name="T8"/></param>
        /// <param name="param9">Argument of type <paramref name="T9"/></param>
        /// <returns>An instance of the implementation of the <see cref="IBindingInjectionCondition"/> interface.</returns>
        #endregion
        IBindingInjectionCondition WithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9);
    }
}
