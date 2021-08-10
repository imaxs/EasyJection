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

namespace EasyJection
{
    /// <summary>
    /// Implements interface <see cref="IReflectedId"/><br/>
    /// <inheritdoc cref="IReflectedId"/>
    /// Represents the identifier of the reflected data.
    /// </summary>
    public readonly struct ReflectedId : IReflectedId
    {
        private readonly int m_NamespaceId;
        /// <inheritdoc cref="IReflectedId.NamespaceId"/>
        public int NamespaceId { get => m_NamespaceId; }

        private readonly int m_TypeNameId;
        /// <inheritdoc cref="IReflectedId.TypeNameId"/>
        public int TypeNameId { get => m_TypeNameId; }

        public ReflectedId(int namespaceId, int typeNameId)
        {
            this.m_IsNotEmpty = true;
            this.m_NamespaceId = namespaceId;
            this.m_TypeNameId = typeNameId;
        }

        /// <inheritdoc cref="IReflectedId.Equals(in ReflectedId)"/>
        public bool Equals(in ReflectedId reflectedId) =>
            (this.m_NamespaceId == reflectedId.m_NamespaceId && this.m_TypeNameId == reflectedId.m_TypeNameId);

        private readonly bool m_IsNotEmpty;
        /// <inheritdoc cref="IReflectedId.IsEmpty"/>
        public bool IsEmpty { get => !m_IsNotEmpty; }

        public override string ToString() => 
            "[NamespaceId: " + NamespaceId + "; TypeNameId: " + TypeNameId + "]";
    }
}