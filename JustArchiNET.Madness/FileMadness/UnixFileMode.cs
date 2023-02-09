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

using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness.FileMadness;

[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum UnixFileMode {
	None = 0,
	OtherExecute = 1,
	OtherWrite = 2,
	OtherRead = 4,
	GroupExecute = 8,
	GroupWrite = 16,
	GroupRead = 32,
	UserExecute = 64,
	UserWrite = 128,
	UserRead = 256,
	StickyBit = 512,
	SetGroup = 1024,
	SetUser = 2048
}
