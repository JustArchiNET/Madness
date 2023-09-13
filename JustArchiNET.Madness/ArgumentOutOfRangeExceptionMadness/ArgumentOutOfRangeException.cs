//                             _         __  __
//  ___  ___   ___  _ __    __| |  __ _ |  \/  |
// / __|/ __| / _ \| '_ \  / _` | / _` || |\/| |
// \__ \\__ \|  __/| | | || (_| || (_| || |  | |
// |___/|___/ \___||_| |_| \__,_| \__,_||_|  |_|
// |
// Copyright 2021-2023 Łukasz "JustArchi" Domeradzki
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
using System.Collections.Generic;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness.ArgumentOutOfRangeExceptionMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public class ArgumentOutOfRangeException : System.ArgumentOutOfRangeException {
	[MadnessType(EMadnessType.Proxy)]
	public ArgumentOutOfRangeException([InvokerParameterName] string paramName, string message) : base(paramName, message) { }

	[MadnessType(EMadnessType.Proxy)]
	public ArgumentOutOfRangeException(string message, Exception innerException) : base(message, innerException) { }

	[MadnessType(EMadnessType.Proxy)]
	public ArgumentOutOfRangeException([InvokerParameterName] string paramName) : base(paramName) { }

	[MadnessType(EMadnessType.Proxy)]
	public ArgumentOutOfRangeException() { }

	[MadnessType(EMadnessType.Implementation)]
	public static void ThrowIfEqual<T>(T value, T other, [InvokerParameterName] string? paramName = null) where T : IEquatable<T>? {
		if (EqualityComparer<T>.Default.Equals(value, other)) {
			throw new ArgumentOutOfRangeException(paramName ?? typeof(T).ToString());
		}
	}

	[MadnessType(EMadnessType.Implementation)]
	public static void ThrowIfLessThan<T>(T value, T other, [InvokerParameterName] string? paramName = null) where T : IComparable<T> {
		if (value.CompareTo(other) < 0) {
			throw new ArgumentOutOfRangeException(paramName ?? typeof(T).ToString());
		}
	}

	[MadnessType(EMadnessType.Implementation)]
	public static void ThrowIfNegative<T>(T value, [InvokerParameterName] string? paramName = null) {
		if (value is < 0) {
			throw new ArgumentOutOfRangeException(paramName ?? typeof(T).ToString());
		}
	}

	[MadnessType(EMadnessType.Implementation)]
	public static void ThrowIfNegativeOrZero<T>(T value, [InvokerParameterName] string? paramName = null) {
		if (value is <= 0) {
			throw new ArgumentOutOfRangeException(paramName ?? typeof(T).ToString());
		}
	}

	[MadnessType(EMadnessType.Implementation)]
	public static void ThrowIfZero<T>(T value, [InvokerParameterName] string? paramName = null) {
		if (value is 0) {
			throw new ArgumentOutOfRangeException(paramName ?? typeof(T).ToString());
		}
	}
}
