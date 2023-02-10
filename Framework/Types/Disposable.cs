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
using System.Runtime.CompilerServices;

namespace EasyJection.Types
{
    public abstract class Disposable : IDisposable
    {
        private bool isDisposed;

        public void Dispose()
        {
            Dispose(isDisposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (this.isDisposed)
                return;

            if (isDisposing)
                this.Remove();

            this.isDisposed = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void CheckDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }

        protected abstract void Remove();

        ~Disposable()
        {
            Dispose(isDisposing: false);
        }
    }
}
