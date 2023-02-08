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

namespace EasyJection.Resolving
{
    using Types;
    public class MultikeysCollection<TKey, TValue> : IMultikeysCollection<TKey, TValue> where TValue : class
    {
        protected IList<KeyValuePair<HashSet<TKey>, TValue>> container;

        public MultikeysCollection(int capacity = 8) 
        {
            container = new List<KeyValuePair<HashSet<TKey>, TValue>>(capacity);
        }

        public int Count { get => container.Count; }

        public bool Contains(TKey key) 
        {
            foreach(var keyval in this.container)
                if (keyval.Key.Contains(key))
                    return true;

            return false;
        }

        public bool Contains(TValue factory)
        {
            for (int i = 0; i < this.container.Count; i++)
                if (container[i].Value.Equals(factory))
                    return true;

            return false;
        }

        public TValue this[TKey key] 
        {
            get
            {
                foreach (var keyval in this.container)
                    if (keyval.Key.Contains(key))
                        return keyval.Value;

                return null;
            }
        }

        public KeyValuePair<HashSet<TKey>, TValue> this[TValue value] 
        {
            get 
            {
                for(int i = 0; i < this.container.Count; i++)
                    if (container[i].Value.Equals(value))
                        return container[i];

                var keyval = new KeyValuePair<HashSet<TKey>, TValue>( new HashSet<TKey>(capacity: 32), value);
                container.Add(keyval);

                return keyval;
            }
        }

        public void AddKey<T>(T value, TKey key) where T : TValue
        {
            this[value].Key.Add(key);
        }

        public void AddKey(TValue value, TKey key) 
        {
            this[value].Key.Add(key);
        }

        public void RemoveValue(TValue factory)
        {
            for (int i = 0; i < this.container.Count; i++)
                if (container[i].Value.Equals(factory))
                     container.RemoveAt(i);
        }

        public void RemoveKey(TKey key)
        {
            foreach (var keyval in this.container)
                if (keyval.Key.Contains(key))
                    keyval.Key.Remove(key);
        }
    }
}
