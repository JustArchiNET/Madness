//                             _         __  __
//  ___  ___   ___  _ __    __| |  __ _ |  \/  |
// / __|/ __| / _ \| '_ \  / _` | / _` || |\/| |
// \__ \\__ \|  __/| | | || (_| || (_| || |  | |
// |___/|___/ \___||_| |_| \__,_| \__,_||_|  |_|
// |
// Copyright 2021-2022 Łukasz "JustArchi" Domeradzki
// Contact: JustArchi@JustArchi.net
// |
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// |
// http://www.apache.org/licenses/LICENSE-2.0
// |
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;
using JustArchiNET.Madness.Internal;

namespace JustArchiNET.Madness.ArgumentExceptionMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public class ArgumentException : System.ArgumentException {
	[MadnessType(EMadnessType.Proxy)]
	public ArgumentException(string message, string paramName) : base(message, paramName) { }

	[MadnessType(EMadnessType.Proxy)]
	public ArgumentException(string message, string paramName, Exception innerException) : base(message, paramName, innerException) { }

	[MadnessType(EMadnessType.Proxy)]
	public ArgumentException(string message, Exception innerException) : base(message, innerException) { }

	[MadnessType(EMadnessType.Proxy)]
	public ArgumentException(string message) : base(message) { }

	[MadnessType(EMadnessType.Proxy)]
	public ArgumentException() { }

	[MadnessType(EMadnessType.Implementation)]
	public static void ThrowIfNullOrEmpty(
		[ValidatedNotNull]

#if NETSTANDARD2_1_OR_GREATER
		[System.Diagnostics.CodeAnalysis.NotNull]
#endif

		string? argument, 
		[CallerArgumentExpression("argument")]
		string? paramName = null
	) {
		if (string.IsNullOrEmpty(argument)) {
			ArgumentNullException.ThrowIfNull(argument, paramName);
			throw new ArgumentException(string.Empty, paramName);
		}
	}
}
