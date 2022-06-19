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
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;
using JustArchiNET.Madness.Internal;

namespace JustArchiNET.Madness;

[MadnessType(EMadnessType.Extension)]
[PublicAPI]
public static class StaticExtensions20 {
	[MadnessType(EMadnessType.Implementation)]
	public static IAsyncDisposable ConfigureAwait(this Stream source, bool continueOnCapturedContext) => ConfigureAwait<Stream>(source, continueOnCapturedContext);

	[MadnessType(EMadnessType.Implementation)]
	public static IAsyncDisposable ConfigureAwait(this TextWriter source, bool continueOnCapturedContext) => ConfigureAwait<TextWriter>(source, continueOnCapturedContext);

	[MadnessType(EMadnessType.Implementation)]
	public static IAsyncDisposable ConfigureAwait(this Timer source, bool continueOnCapturedContext) => ConfigureAwait<Timer>(source, continueOnCapturedContext);

	[MadnessType(EMadnessType.Implementation)]
	public static bool Contains(this string input, char value) {
		if (input == null) {
			throw new ArgumentNullException(nameof(input));
		}

		return input.IndexOf(value) >= 0;
	}

	[MadnessType(EMadnessType.Implementation)]
	public static bool Contains(this string input, char value, StringComparison comparisonType) {
		if (input == null) {
			throw new ArgumentNullException(nameof(input));
		}

		return input.IndexOf(value, comparisonType) >= 0;
	}

	[MadnessType(EMadnessType.Implementation)]
	public static bool Contains(this string input, string value, StringComparison comparisonType) {
		if (input == null) {
			throw new ArgumentNullException(nameof(input));
		}

		return input.IndexOf(value, comparisonType) >= 0;
	}

	// ReSharper disable once UseDeconstructionOnParameter - we actually implement deconstruction here
	[MadnessType(EMadnessType.Implementation)]
	public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kv, out TKey key, out TValue value) {
		key = kv.Key;
		value = kv.Value;
	}

	[MadnessType(EMadnessType.Implementation)]
	public static ValueTask DisposeAsync(this Stream disposable) => FakeDisposeAsync(disposable);

	[MadnessType(EMadnessType.Implementation)]
	public static ValueTask DisposeAsync(this TextWriter disposable) => FakeDisposeAsync(disposable);

	[MadnessType(EMadnessType.Implementation)]
	public static ValueTask DisposeAsync(this Timer disposable) => FakeDisposeAsync(disposable);

	[MadnessType(EMadnessType.Implementation)]
	public static int IndexOf(this string source, char value, StringComparison comparisonType) {
		if (source == null) {
			throw new ArgumentNullException(nameof(source));
		}

		return source.IndexOf(value.ToString(), comparisonType);
	}

	[MadnessType(EMadnessType.Implementation)]
	public static async Task<int> ReadAsync(this Stream stream, Memory<byte> buffer) {
		if (stream == null) {
			throw new ArgumentNullException(nameof(stream));
		}

		byte[] byteArray = new byte[buffer.Length];

		int result = await stream.ReadAsync(byteArray, 0, byteArray.Length).ConfigureAwait(false);

		// Since byteArray.Length == buffer.Length, we can do it like this
		byteArray.CopyTo(buffer);

		return result;
	}

	[MadnessType(EMadnessType.Implementation)]
	public static async Task<WebSocketReceiveResult> ReceiveAsync(this WebSocket webSocket, byte[] buffer, CancellationToken cancellationToken) {
		if (webSocket == null) {
			throw new ArgumentNullException(nameof(webSocket));
		}

		return await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);
	}

	[MadnessType(EMadnessType.Implementation)]
	public static string Replace(this string source, string oldValue, string? newValue, StringComparison comparisonType) {
		if (source == null) {
			throw new ArgumentNullException(nameof(source));
		}

		if (oldValue == null) {
			throw new ArgumentNullException(nameof(oldValue));
		}

		if (oldValue.Length == 0) {
			throw new ArgumentOutOfRangeException(nameof(oldValue));
		}

		int startIndex = 0;

		while (true) {
			if (startIndex >= source.Length) {
				return source;
			}

			int index = source.IndexOf(oldValue, startIndex, comparisonType);

			if (index < 0) {
				return source;
			}

			startIndex = index;

			source = source.Remove(index, oldValue.Length);

			if (!string.IsNullOrEmpty(newValue)) {
				source = source.Insert(index, newValue!);
				startIndex += newValue!.Length;
			}
		}
	}

	[MadnessType(EMadnessType.Implementation)]
	public static async Task SendAsync(this WebSocket webSocket, byte[] buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken) {
		if (webSocket == null) {
			throw new ArgumentNullException(nameof(webSocket));
		}

		await webSocket.SendAsync(new ArraySegment<byte>(buffer), messageType, endOfMessage, cancellationToken).ConfigureAwait(false);
	}

	[MadnessType(EMadnessType.Implementation)]
	public static string[] Split(this string text, char separator, StringSplitOptions options = StringSplitOptions.None) {
		if (text == null) {
			throw new ArgumentNullException(nameof(text));
		}

		return text.Split(new[] { separator }, options);
	}

	[MadnessType(EMadnessType.Implementation)]
	public static void TrimExcess<TKey, TValue>(this Dictionary<TKey, TValue> _) { } // no-op

	[MadnessType(EMadnessType.Implementation)]
	public static async Task WriteAsync(this Stream stream, ReadOnlyMemory<byte> buffer) {
		if (stream == null) {
			throw new ArgumentNullException(nameof(stream));
		}

		byte[] byteArray = buffer.ToArray();

		await stream.WriteAsync(byteArray, 0, byteArray.Length).ConfigureAwait(false);
	}

	private static IAsyncDisposable ConfigureAwait<T>(T source, bool continueOnCapturedContext) where T : IDisposable {
		if (source is null) {
			throw new ArgumentNullException(nameof(source));
		}

		return new AsyncDisposableWrapper(source, continueOnCapturedContext);
	}

	private static ValueTask FakeDisposeAsync(IDisposable? disposable) {
		if (disposable == null) {
			throw new ArgumentNullException(nameof(disposable));
		}

		disposable.Dispose();

		return default(ValueTask);
	}
}
#endif
