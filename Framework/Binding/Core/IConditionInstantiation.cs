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

namespace EasyJection
{
    #region Comment
    /// <summary>
    /// Inherits <see cref="IConditionCreator"/><br/>
    /// <inheritdoc/>
    /// Contains the definitions of the binding condition for the binding.
    /// <list type="bullet">
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.ConstructionMethod(string)"/></term>
    ///         <description>The name of the method which is called to create / retrieve an instance or immediately after an instance is created.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments(object[])"/></term>
    ///         <description>Adds a list of objects to use when creating a new instance of the implementation type.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T}(T)"/></term>
    ///         <description>Adds to passing an argument of type <paramref name="T"/>.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2}(T1, T2)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/> and <paramref name="T2"/> types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2, T3}(T1, T2, T3)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/> and <paramref name="T3"/> types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4}(T1, T2, T3, T4)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/> and <paramref name="T4"/> types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5}(T1, T2, T3, T4, T5)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/> and <paramref name="T5"/> types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6}(T1, T2, T3, T4, T5, T6)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/> and <paramref name="T6"/> types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6, T7}(T1, T2, T3, T4, T5, T6, T7)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/> and <paramref name="T7"/> types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6, T7, T8}(T1, T2, T3, T4, T5, T6, T7, T8)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/> and <paramref name="T8"/> types.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="IConditionInstantiation.WithArguments{T1, T2, T3, T4, T5, T6, T7, T8, T9}(T1, T2, T3, T4, T5, T6, T7, T8, T9)"/></term>
    ///         <description>Adds to passing an arguments of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/>, <paramref name="T8"/> and <paramref name="T9"/> types.</description>
    ///     </item>
    /// </list>
    /// </summary>
    #endregion
    public interface IConditionInstantiation : IConditionCreator
    {
        #region Comment
        /// <summary>
        /// The name of the method which is called to create / retrieve an instance or immediately after an instance is created.
        /// Uses an instance constructor by default.
        /// </summary>
        #endregion
        IConditionInstantiation ConstructionMethod();

        #region Comment
        /// <summary>
        /// The name of the method which is called to create / retrieve an instance or immediately after an instance is created.
        /// Uses an instance constructor by default.
        /// </summary>
        /// <remarks>
        /// In Unity, gameObject instances don't have instance constructors, so any other method can be used for this purpose.
        /// </remarks>
        /// <param name="methodName">The name of the method that is called as a constructor.</param>
        /// <param name="autoInjection">If True, the injection will be done via hook.</param>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation ConstructionMethod(string methodName, bool autoInjection = true);

        #region Comment
        /// <summary>
        /// Adds a list of objects to use when creating a new instance of the implementation type.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="arguments">A list of objects to use when creating a new instance of the implementation type.</param>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments(Object[] arguments);

        #region Comment
        /// <summary>
        /// Adds to passing an argument of type <paramref name="T"/>
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param">Argument of type <paramref name="T"/></param>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T>(T param);

        #region Comment
        /// <summary>
        /// Adds to passing an arguments of <paramref name="T1"/> and <paramref name="T2"/> types.
        /// </summary>
        /// <remarks>
        /// It can also be used as an alternative to adding other bindings.
        /// </remarks>
        /// <param name="param1">Argument of type <paramref name="T1"/></param>
        /// <param name="param2">Argument of type <paramref name="T2"/></param>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2>(T1 param1, T2 param2);

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
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2, T3>(T1 param1, T2 param2, T3 param3);

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
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4);

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
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2, T3, T4, T5>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);

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
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6);

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
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6, T7>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7);

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
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6, T7, T8>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8);

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
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation WithArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9);

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameter of <paramref name="T"/>
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/> and <paramref name="T2"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/>, <paramref name="T2"/> and <paramref name="T3"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2, T3>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/> and <paramref name="T4"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2, T3, T4>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/> and <paramref name="T5"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2, T3, T4, T5>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/> and <paramref name="T6"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/> and <paramref name="T7"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6, T7>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/> and <paramref name="T8"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6, T7, T8>();

        #region Comment
        /// <summary>
        /// The constructor method will be called with the specified parameters of <paramref name="T1"/>, <paramref name="T2"/>, <paramref name="T3"/>, <paramref name="T4"/>, <paramref name="T5"/>, <paramref name="T6"/>, <paramref name="T7"/>, <paramref name="T8"/> and <paramref name="T9"/> types.
        /// </summary>
        /// <returns>An instance of the implementation of the <see cref="IConditionInstantiation"/> interface.</returns>
        #endregion
        IConditionInstantiation Signature<T1, T2, T3, T4, T5, T6, T7, T8, T9>();

    }
}