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
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness.SHA512Madness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class SHA512 {
	/// <summary>
	///     Computes the hash of data using the SHA512 algorithm.
	/// </summary>
	/// <param name="source">The data to hash.</param>
	/// <returns>The hash of the data.</returns>
	/// <exception cref="ArgumentNullException">
	///     <paramref name="source" /> is <see langword="null" />.
	/// </exception>
	public static byte[] HashData(byte[] source) {
		if (source == null) {
			throw new ArgumentNullException(nameof(source));
		}

		using System.Security.Cryptography.SHA512 hashAlgorithm = System.Security.Cryptography.SHA512.Create();

		return hashAlgorithm.ComputeHash(source);
	}
}
