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
    public interface IBindingInjectionCondition
    {
        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T"/> type</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/>
        /// <typeparamref  name="T3"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2, T3>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/>
        /// <typeparamref  name="T3"/>, <typeparamref  name="T4"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2, T3, T4>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/>
        /// <typeparamref  name="T3"/>, <typeparamref  name="T4"/>, <typeparamref  name="T5"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/>
        /// <typeparamref  name="T3"/>, <typeparamref  name="T4"/>, <typeparamref  name="T5"/>
        /// <typeparamref  name="T6"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/>
        /// <typeparamref  name="T3"/>, <typeparamref  name="T4"/>, <typeparamref  name="T5"/>
        /// <typeparamref  name="T6"/>, <typeparamref  name="T7"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/>
        /// <typeparamref  name="T3"/>, <typeparamref  name="T4"/>, <typeparamref  name="T5"/>
        /// <typeparamref  name="T6"/>, <typeparamref  name="T7"/>, <typeparamref  name="T8"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// Specifies the constructor condition
        /// </summary>
        /// <remarks>The parameters correspond to the specified <typeparamref  name="T1"/>,  <typeparamref  name="T2"/>
        /// <typeparamref  name="T3"/>, <typeparamref  name="T4"/>, <typeparamref  name="T5"/>
        /// <typeparamref  name="T6"/>, <typeparamref  name="T7"/>, <typeparamref  name="T8"/>, <typeparamref  name="T9"/> types</remarks>
        /// <param name="UseForInstantiation">Specifies that this constructor will be used to create instances when resolving dependencies,</param>
        /// <returns>An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.</returns>
        #endregion
        IBindingMethodCondition Constructor<T1, T2, T3, T4, T5, T6, T7, T8, T9>(bool UseForInstantiation = false);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameter of <typeparamref  name="T"/> type is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2, T3>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2, T3, T4>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/>,
        /// <typeparamref  name="T7"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/>,
        /// <typeparamref  name="T7"/>, <typeparamref  name="T8"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/>,
        /// <typeparamref  name="T7"/>, <typeparamref  name="T8"/>, <typeparamref  name="T9"/> types is called.
        /// </summary>
        /// <remarks>The specified method should not return anything. </remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameter of <typeparamref  name="T"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, T3, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, T3, T4, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/>,
        /// <typeparamref  name="T7"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/>,
        /// <typeparamref  name="T7"/>, <typeparamref  name="T8"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string methodName);

        #region Comment
        /// <summary>
        /// The injection will be performed when the specified method with the name 
        /// and parameters <typeparamref  name="T1"/>, <typeparamref  name="T2"/>, <typeparamref  name="T3"/>,
        /// <typeparamref  name="T4"/>, <typeparamref  name="T5"/>, <typeparamref  name="T6"/>,
        /// <typeparamref  name="T7"/>, <typeparamref  name="T8"/>, <typeparamref  name="T9"/> types is called.
        /// </summary>
        /// <remarks>The specified method returns an instance of the <typeparamref  name="TResult"/> type.</remarks>
        /// <param name="methodName">The name of the existing method.</param>
        /// <returns>
        /// An instance of the implementation of the <see cref="IBindingMethodCondition"/> interface.
        /// </returns>
        #endregion
        IBindingMethodCondition MethodResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(string methodName);
    }
}
