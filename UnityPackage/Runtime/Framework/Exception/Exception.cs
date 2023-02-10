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
    public class Causes
    {
        public const string ARGUMENTS_NOT_MATCH = "The specified types do not match the specified types of the argument set";
        public const string INSTANCE_NOT_OBJECT = "An instance shouldn't be a type, be abstract, or an interface.";
        public const string TYPE_NOT_ASSIGNABLE = "The related type is not assignable from the source type.";
        public const string INSTANCE_NOT_ASSIGNABLE = "The instance is not of the given type.";
        public const string TYPE_NOT_IFACTORY = "The type doesn't implement 'EasyJection.Binding.Utils.IFactory'.";
        public const string TYPE_NOT_IMPLEMENTED = "The type cannot be abstract or an interface.";
        public const string CANNOT_INSTANTIATE_INTERFACE = "Interface \"{0}\" cannot be instantiated.";
        public const string UNABLE_TO_INJECT_ON_FIELD = "Unable to inject on field {0} at object {1}.\nCaused by: {2}";
        public const string UNABLE_TO_INJECT_ON_PROPERTY = "Unable to inject on property {0} at object {1}.\nCaused by: {2}";
        public const string CONSTRUCTOR_NOT_FOUND = "The specified constructor does not exist for the {0} type.";
        public const string CONSTRUCTOR_WITH_ARGUMENTS_NOT_FOUND = "The specified constructor with {0} parameter(s) for the {1} type does not exist.";
        public const string METHOD_NOT_FOUND = "The specified method named '{0}' does not exist for the {1} type.";
        public const string METHOD_WITH_ARGUMENTS_NOT_FOUND = "The specified method named '{0}' with {1} parameter(s) for the {2} type does not exist.";
    }
}
