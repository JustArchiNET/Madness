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

using System.IO;
using System.Security.AccessControl;
using JetBrains.Annotations;
using JustArchiNET.Madness.ArgumentNullExceptionMadness;
using JustArchiNET.Madness.FileMadness;
using JustArchiNET.Madness.Helpers;
using JustArchiNET.Madness.Internal;

namespace JustArchiNET.Madness.DirectoryInfoMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public sealed class DirectoryInfo {
	private readonly System.IO.DirectoryInfo UnderlyingDirectoryInfo;

	[MadnessType(EMadnessType.Implementation)]
	public UnixFileMode UnixFileMode {
		get => UnixFileMode.None; // TODO
		set => NativeMethods.Chmod(UnderlyingDirectoryInfo.FullName, value);
	}

	[MadnessType(EMadnessType.Proxy)]
	public DirectoryInfo(string path) : this(new System.IO.DirectoryInfo(path)) { }

	internal DirectoryInfo(System.IO.DirectoryInfo directoryInfo) => UnderlyingDirectoryInfo = directoryInfo ?? throw new ArgumentNullException(nameof(directoryInfo));

	[MadnessType(EMadnessType.Proxy)]
	public void SetAccessControl(DirectorySecurity directorySecurity) => UnderlyingDirectoryInfo.SetAccessControl(directorySecurity);
}
