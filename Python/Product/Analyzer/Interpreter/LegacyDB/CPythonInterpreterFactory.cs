// Python Tools for Visual Studio
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using System.Collections.Generic;

namespace Microsoft.PythonTools.Interpreter.LegacyDB {
    sealed class CPythonInterpreterFactory : PythonInterpreterFactoryWithDatabase, ICustomInterpreterSerialization {
        public CPythonInterpreterFactory(InterpreterConfiguration configuration, InterpreterFactoryCreationOptions options) :
            base(configuration, options) { }

        bool ICustomInterpreterSerialization.GetSerializationInfo(out string assembly, out string typeName, out Dictionary<string, object> properties) {
            assembly = GetType().Assembly.Location;
            typeName = GetType().FullName;
            properties = CreationOptions.ToDictionary();
            Configuration.WriteToDictionary(properties);
            return true;
        }

        internal CPythonInterpreterFactory(Dictionary<string, object> properties) :
            base(InterpreterConfiguration.FromDictionary(properties), InterpreterFactoryCreationOptions.FromDictionary(properties)) { }
    }
}
