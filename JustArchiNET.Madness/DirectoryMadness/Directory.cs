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

using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;
using DirectoryInfo = JustArchiNET.Madness.DirectoryInfoMadness.DirectoryInfo;

namespace JustArchiNET.Madness.DirectoryMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public static class Directory {
	[MadnessType(EMadnessType.Replacement)]
	public static DirectoryInfo CreateDirectory(string path) {
		System.IO.DirectoryInfo directoryInfo = System.IO.Directory.CreateDirectory(path);

		return new DirectoryInfo(directoryInfo);
	}

	[MadnessType(EMadnessType.Proxy)]
	public static void Delete(string path) => System.IO.Directory.Delete(path);

	[MadnessType(EMadnessType.Proxy)]
	public static void Delete(string path, bool recursive) => System.IO.Directory.Delete(path, recursive);

	[MadnessType(EMadnessType.Proxy)]
	public static IEnumerable<string> EnumerateDirectories(string path) => System.IO.Directory.EnumerateDirectories(path);

	[MadnessType(EMadnessType.Proxy)]
	public static IEnumerable<string> EnumerateFiles(string path, string searchPattern) => System.IO.Directory.EnumerateFiles(path, searchPattern);

	[MadnessType(EMadnessType.Proxy)]
	public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption) => System.IO.Directory.EnumerateFiles(path, searchPattern, searchOption);

	[MadnessType(EMadnessType.Proxy)]
	public static IEnumerable<string> EnumerateFileSystemEntries(string path) => System.IO.Directory.EnumerateFileSystemEntries(path);

	[MadnessType(EMadnessType.Proxy)]
	public static bool Exists(string path) => System.IO.Directory.Exists(path);

	[MadnessType(EMadnessType.Proxy)]
	public static string GetCurrentDirectory() => System.IO.Directory.GetCurrentDirectory();

	[MadnessType(EMadnessType.Proxy)]
	public static void SetCurrentDirectory(string path) => System.IO.Directory.SetCurrentDirectory(path);
}
