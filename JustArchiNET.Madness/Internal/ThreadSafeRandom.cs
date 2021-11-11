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

namespace JustArchiNET.Madness.Internal;

internal sealed class ThreadSafeRandom : Random {
	private readonly object LockObject = new();

#pragma warning disable CA5394 // The caller decides to call this, not us
	public override int Next() {
		lock (LockObject) {
			return base.Next();
		}
	}

	public override int Next(int maxValue) {
		lock (LockObject) {
			return base.Next(maxValue);
		}
	}

	public override int Next(int minValue, int maxValue) {
		lock (LockObject) {
			return base.Next(minValue, maxValue);
		}
	}

	public override void NextBytes(byte[] buffer) {
		lock (LockObject) {
			base.NextBytes(buffer);
		}
	}

	public override double NextDouble() {
		lock (LockObject) {
			return base.NextDouble();
		}
	}

	protected override double Sample() {
		lock (LockObject) {
			return base.Sample();
		}
	}
#pragma warning restore CA5394 // The caller decides to call this, not us
}
