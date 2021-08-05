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

using System.Threading.Tasks;
using JetBrains.Annotations;

namespace JustArchiNET.Madness {
	[PublicAPI]
	public static class File {
		public static Task AppendAllTextAsync(string path, string contents) {
			System.IO.File.AppendAllText(path, contents);

			return Task.CompletedTask;
		}

		public static void Move(string sourceFileName, string destFileName, bool overwrite) {
			if (overwrite && System.IO.File.Exists(destFileName)) {
				System.IO.File.Delete(destFileName);
			}

			System.IO.File.Move(sourceFileName, destFileName);
		}

		public static Task<byte[]> ReadAllBytesAsync(string path) => Task.FromResult(System.IO.File.ReadAllBytes(path));

		public static Task<string> ReadAllTextAsync(string path) => Task.FromResult(System.IO.File.ReadAllText(path));

		public static Task WriteAllTextAsync(string path, string contents) {
			System.IO.File.WriteAllText(path, contents);

			return Task.CompletedTask;
		}
	}
}
