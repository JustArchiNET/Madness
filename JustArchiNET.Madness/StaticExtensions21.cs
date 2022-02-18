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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace JustArchiNET.Madness;

[MadnessType(EMadnessType.Extension)]
[PublicAPI]
public static class StaticExtensions21 {
	[MadnessType(EMadnessType.Implementation)]
	public static StringBuilder Append(this StringBuilder stringBuilder, IFormatProvider? provider, string text) {
		if (stringBuilder == null) {
			throw new ArgumentNullException(nameof(stringBuilder));
		}

		if (text == null) {
			throw new ArgumentNullException(nameof(text));
		}

		return stringBuilder.Append(text.ToString(provider));
	}

	[MadnessType(EMadnessType.Implementation)]
	public static Task<byte[]> ComputeHashAsync(this HashAlgorithm hashAlgorithm, Stream inputStream) {
		if (hashAlgorithm == null) {
			throw new ArgumentNullException(nameof(hashAlgorithm));
		}

		return Task.FromResult(hashAlgorithm.ComputeHash(inputStream));
	}

	[MadnessType(EMadnessType.Implementation)]
	public static IWebHostBuilder ConfigureWebHostDefaults(this IWebHostBuilder builder, Action<IWebHostBuilder> configure) {
		if (configure == null) {
			throw new ArgumentNullException(nameof(configure));
		}

		configure(builder);

		return builder;
	}

	[MadnessType(EMadnessType.Implementation)]
	public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer = null) {
		if (source == null) {
			throw new ArgumentNullException(nameof(source));
		}

		if (keySelector == null) {
			throw new ArgumentNullException(nameof(keySelector));
		}

		return source.OrderByDescending(keySelector, comparer).FirstOrDefault();
	}

	[MadnessType(EMadnessType.Implementation)]
	public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer = null) {
		if (source == null) {
			throw new ArgumentNullException(nameof(source));
		}

		if (keySelector == null) {
			throw new ArgumentNullException(nameof(keySelector));
		}

		return source.OrderBy(keySelector, comparer).FirstOrDefault();
	}
}
