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

namespace JustArchiNET.Madness.FileInfoMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public sealed class FileInfo {
	private readonly System.IO.FileInfo UnderlyingFileInfo;

	[MadnessType(EMadnessType.Implementation)]
	public UnixFileMode UnixFileMode {
		get => UnixFileMode.None;
		set => NativeMethods.Chmod(UnderlyingFileInfo.FullName, value);
	}

	[MadnessType(EMadnessType.Proxy)]
	public FileInfo(string path) : this(new System.IO.FileInfo(path)) { }

	internal FileInfo(System.IO.FileInfo fileInfo) => UnderlyingFileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));

	[MadnessType(EMadnessType.Proxy)]
	public void SetAccessControl(FileSecurity fileSecurity) => UnderlyingFileInfo.SetAccessControl(fileSecurity);
}
