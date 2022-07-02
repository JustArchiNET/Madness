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

#if !NETSTANDARD2_1_OR_GREATER
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

// ReSharper disable once CheckNamespace - we intentionally declare this namespace
namespace System.Runtime.CompilerServices;

[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
public static class RuntimeHelpers {
	public static int OffsetToStringData {
		get {
			switch (RuntimeInformation.ProcessArchitecture) {
				case Architecture.Arm:
				case Architecture.X86:
					return 8;
				default:
					return 12;
			}
		}
	}

	/// <summary>
	///     Slices the specified array using the specified range.
	/// </summary>
	public static T[] GetSubArray<T>(T[] array, Range range) {
		if (array == null) {
			throw new ArgumentNullException(nameof(array));
		}

		(int offset, int length) = range.GetOffsetAndLength(array.Length);

		T[] dest;

		if (typeof(T).IsValueType || (typeof(T[]) == array.GetType())) {
			// We know the type of the array to be exactly T[].

			if (length == 0) {
				return Array.Empty<T>();
			}

			dest = new T[length];
			Array.Copy(array, offset, dest, 0, length);
		} else {
			// The array is actually a U[] where U:T.
			dest = (T[]) Array.CreateInstance(array.GetType().GetElementType()!, length);
			Array.Copy(array, offset, dest, 0, length);
		}

		return dest;
	}
}
#endif
