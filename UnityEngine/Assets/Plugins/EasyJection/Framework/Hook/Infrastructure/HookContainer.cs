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

namespace EasyJection
{
    public readonly struct HookData
    {
        public readonly ReflectedId Id;
        public readonly Hook Hook;

        public HookData(in ReflectedId reflectedId, Hook hook)
        {
            this.Id = reflectedId;
            this.Hook = hook;
        }

        public bool IsEmpty { get => Hook == null; }
    }

    public class HookContainer
    {
        private readonly Type s_ObjectType;
        private List<HookData> m_HooksList;

        public HookContainer()
        {
            s_ObjectType = typeof(object);
            m_HooksList = new List<HookData>();
        }

        private int AddNew(in ReflectedId reflectedId, Hook hook)
        {
            int index = m_HooksList.Count;
            m_HooksList.Add(new HookData(reflectedId, hook));
            return index;
        }

        private int GetIndex(in ReflectedId reflectedId)
        {
            for (int i = 0; i < m_HooksList.Count; i++)
                if (m_HooksList[i].Id.Equals(reflectedId))
                    return i;
            return -1;
        }

        public int Add(in ReflectedId reflectedId, Hook hook)
        {
            int index = GetIndex(reflectedId);
            if (index > -1)
                m_HooksList[index] = new HookData(reflectedId, hook);
            else
                index = AddNew(reflectedId, hook);

            return index;
        }

        public HookData Get(Type type) => Get(type.Reflect());

        public HookData Get(in ReflectedId reflectedId)
        {
            int index = GetIndex(reflectedId);
            if (index > -1)
                return m_HooksList[0];

            ReflectedId parentId = reflectedId.GetData().ParentId;
            if (!parentId.IsEmpty)
                return Get(parentId);

            return default(HookData);
        }

        public void Destroy() => m_HooksList.Clear();
    }
}