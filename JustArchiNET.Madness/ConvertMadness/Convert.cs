//                             _         __  __
//  ___  ___   ___  _ __    __| |  __ _ |  \/  |
// / __|/ __| / _ \| '_ \  / _` | / _` || |\/| |
// \__ \\__ \|  __/| | | || (_| || (_| || |  | |
// |___/|___/ \___||_| |_| \__,_| \__,_||_|  |_|
// |
// Copyright 2021-2021 Łukasz "JustArchi" Domeradzki
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

namespace JustArchiNET.Madness.ConvertMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public static class Convert {
	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static object ChangeType(object? value, Type conversionType, IFormatProvider? provider) => System.Convert.ChangeType(value, conversionType, provider);

	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static byte[] FromBase64String(string s) => System.Convert.FromBase64String(s);

	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static string ToBase64String(byte[] inArray) => System.Convert.ToBase64String(inArray);

	[MadnessType(EMadnessType.Implementation)]
	[Pure]
	public static string ToHexString(byte[] inArray) {
		if (inArray == null) {
			throw new ArgumentNullException(nameof(inArray));
		}

		return BitConverter.ToString(inArray).Replace("-", "", StringComparison.Ordinal);
	}
}
