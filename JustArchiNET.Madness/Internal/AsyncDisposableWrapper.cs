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
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace JustArchiNET.Madness.Internal;

internal sealed class AsyncDisposableWrapper : IAsyncDisposable {
	private readonly IDisposable Disposable;

	[SuppressMessage("ReSharper", "UnusedParameter.Local")]
	internal AsyncDisposableWrapper(IDisposable disposable, bool _) => Disposable = disposable ?? throw new ArgumentNullException(nameof(disposable));

	public ValueTask DisposeAsync() {
		Disposable.Dispose();

		return default(ValueTask);
	}
}
#endif
