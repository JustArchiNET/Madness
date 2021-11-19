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
using System.Text;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;
using JustArchiNET.Madness.Internal;

namespace JustArchiNET.Madness.PathMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public static class Path {
	[MadnessType(EMadnessType.Proxy)]
	public static char AltDirectorySeparatorChar => System.IO.Path.AltDirectorySeparatorChar;

	[MadnessType(EMadnessType.Proxy)]
	public static char DirectorySeparatorChar => System.IO.Path.DirectorySeparatorChar;

	[MadnessType(EMadnessType.Proxy)]
	public static string Combine(params string[] paths) => System.IO.Path.Combine(paths);

	[ContractAnnotation("null=>null")]
	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static string? GetDirectoryName(string? path) => System.IO.Path.GetDirectoryName(path);

	[ContractAnnotation("null=>null;notnull=>notnull")]
	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static string GetExtension(string? path) => System.IO.Path.GetExtension(path)!;

	[ContractAnnotation("null=>null;notnull=>notnull")]
	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static string GetFileName(string? path) => System.IO.Path.GetFileName(path)!;

	[ContractAnnotation("null=>null;notnull=>notnull")]
	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static string GetFileNameWithoutExtension(string? path) => System.IO.Path.GetFileNameWithoutExtension(path)!;

	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static string GetFullPath(string path) => System.IO.Path.GetFullPath(path);

	[MadnessType(EMadnessType.Implementation)]
	public static string GetRelativePath(string relativeTo, string path) {
		if (string.IsNullOrEmpty(relativeTo)) {
			throw new ArgumentNullException(nameof(relativeTo));
		}

		if (string.IsNullOrEmpty(path)) {
			throw new ArgumentNullException(nameof(path));
		}

		StringComparison comparisonType = PathInternalNetCore.StringComparison;

		relativeTo = GetFullPath(relativeTo);
		path = GetFullPath(path);

		// Need to check if the roots are different- if they are we need to return the "to" path.
		if (!PathInternalNetCore.AreRootsEqual(relativeTo, path, comparisonType)) {
			return path;
		}

		int commonLength = PathInternalNetCore.GetCommonPathLength(
			relativeTo, path,
			comparisonType == StringComparison.OrdinalIgnoreCase
		);

		// If there is nothing in common they can't share the same root, return the "to" path as is.
		if (commonLength == 0) {
			return path;
		}

		// Trailing separators aren't significant for comparison
		int relativeToLength = relativeTo.Length;

		if (PathInternalNetCore.EndsInDirectorySeparator(relativeTo)) {
			relativeToLength--;
		}

		bool pathEndsInSeparator = PathInternalNetCore.EndsInDirectorySeparator(path);
		int pathLength = path.Length;

		if (pathEndsInSeparator) {
			pathLength--;
		}

		// If we have effectively the same path, return "."
		if ((relativeToLength == pathLength) && (commonLength >= relativeToLength)) {
			return ".";
		}

		// We have the same root, we need to calculate the difference now using the
		// common Length and Segment count past the length.
		//
		// Some examples:
		//
		//  C:\Foo C:\Bar L3, S1 -> ..\Bar
		//  C:\Foo C:\Foo\Bar L6, S0 -> Bar
		//  C:\Foo\Bar C:\Bar\Bar L3, S2 -> ..\..\Bar\Bar
		//  C:\Foo\Foo C:\Foo\Bar L7, S1 -> ..\Bar

		StringBuilder sb = new(); //StringBuilderCache.Acquire(Math.Max(relativeTo.Length, path.Length));

		// Add parent segments for segments past the common on the "from" path
		if (commonLength < relativeToLength) {
			sb.Append("..");

			for (int i = commonLength + 1; i < relativeToLength; i++) {
				if (PathInternalNetCore.IsDirectorySeparator(relativeTo[i])) {
					sb.Append(DirectorySeparatorChar);
					sb.Append("..");
				}
			}
		} else if (PathInternalNetCore.IsDirectorySeparator(path[commonLength])) {
			// No parent segments and we need to eat the initial separator
			//  (C:\Foo C:\Foo\Bar case)
			commonLength++;
		}

		// Now add the rest of the "to" path, adding back the trailing separator
		int differenceLength = pathLength - commonLength;

		if (pathEndsInSeparator) {
			differenceLength++;
		}

		if (differenceLength > 0) {
			if (sb.Length > 0) {
				sb.Append(DirectorySeparatorChar);
			}

			sb.Append(path, commonLength, differenceLength);
		}

		return sb.ToString(); //StringBuilderCache.GetStringAndRelease(sb);
	}

	[MadnessType(EMadnessType.Proxy)]
	public static string GetTempPath() => System.IO.Path.GetTempPath();
}
