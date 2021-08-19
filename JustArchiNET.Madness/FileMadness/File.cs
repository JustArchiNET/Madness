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

using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace JustArchiNET.Madness.FileMadness {
	[PublicAPI]
	public static class File {
		public static void AppendAllText(string path, string? contents) => System.IO.File.AppendAllText(path, contents);

		public static Task AppendAllTextAsync(string path, string? contents) {
			AppendAllText(path, contents);

			return Task.CompletedTask;
		}

		public static void Delete(string path) => System.IO.File.Delete(path);

		public static bool Exists(string? path) => System.IO.File.Exists(path);

		public static void Move(string sourceFileName, string destFileName) => System.IO.File.Move(sourceFileName, destFileName);

		public static void Move(string sourceFileName, string destFileName, bool overwrite) {
			if (overwrite && Exists(destFileName)) {
				Delete(destFileName);
			}

			Move(sourceFileName, destFileName);
		}

		public static FileStream Open(string path, FileMode mode, FileAccess access) => System.IO.File.Open(path, mode, access);

		public static byte[] ReadAllBytes(string path) => System.IO.File.ReadAllBytes(path);

		public static Task<byte[]> ReadAllBytesAsync(string path) => Task.FromResult(ReadAllBytes(path));

		public static string ReadAllText(string path) => System.IO.File.ReadAllText(path);

		public static Task<string> ReadAllTextAsync(string path) => Task.FromResult(ReadAllText(path));

		public static void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName) => System.IO.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);

		public static void WriteAllText(string path, string? contents) => System.IO.File.WriteAllText(path, contents);

		public static Task WriteAllTextAsync(string path, string? contents) {
			WriteAllText(path, contents);

			return Task.CompletedTask;
		}
	}
}
