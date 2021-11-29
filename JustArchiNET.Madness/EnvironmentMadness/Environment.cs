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

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness.EnvironmentMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public static class Environment {
	[MadnessType(EMadnessType.Proxy)]
	public static string NewLine => System.Environment.NewLine;

	[MadnessType(EMadnessType.Implementation)]
	public static string? ProcessPath {
		get {
			using Process process = Process.GetCurrentProcess();

			return process.MainModule?.FileName;
		}
	}

	[ContractAnnotation("=>halt")]
	[MadnessType(EMadnessType.Proxy)]
	public static void Exit(int exitCode) => System.Environment.Exit(exitCode);

	[MadnessType(EMadnessType.Proxy)]
	[Pure]
	public static string[] GetCommandLineArgs() => System.Environment.GetCommandLineArgs();

	[MadnessType(EMadnessType.Proxy)]
	public static string? GetEnvironmentVariable(string variable) => System.Environment.GetEnvironmentVariable(variable);

	[MadnessType(EMadnessType.Proxy)]
	public static string GetFolderPath(SpecialFolder folder) => System.Environment.GetFolderPath((System.Environment.SpecialFolder) folder);

	[MadnessType(EMadnessType.Proxy)]
	public static string GetFolderPath(SpecialFolder folder, SpecialFolderOption option) => System.Environment.GetFolderPath((System.Environment.SpecialFolder) folder, (System.Environment.SpecialFolderOption) option);

#pragma warning disable CA1069 // Proxy attributes should not change original signatures
	[MadnessType(EMadnessType.Proxy)]
	[PublicAPI]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum SpecialFolder {
		Desktop = 0,
		Programs = 2,
		MyDocuments = 5,
		Personal = 5,
		Favorites = 6,
		Startup = 7,
		Recent = 8,
		SendTo = 9,
		StartMenu = 11, // 0x0000000B
		MyMusic = 13, // 0x0000000D
		MyVideos = 14, // 0x0000000E
		DesktopDirectory = 16, // 0x00000010
		MyComputer = 17, // 0x00000011
		NetworkShortcuts = 19, // 0x00000013
		Fonts = 20, // 0x00000014
		Templates = 21, // 0x00000015
		CommonStartMenu = 22, // 0x00000016
		CommonPrograms = 23, // 0x00000017
		CommonStartup = 24, // 0x00000018
		CommonDesktopDirectory = 25, // 0x00000019
		ApplicationData = 26, // 0x0000001A
		PrinterShortcuts = 27, // 0x0000001B
		LocalApplicationData = 28, // 0x0000001C
		InternetCache = 32, // 0x00000020
		Cookies = 33, // 0x00000021
		History = 34, // 0x00000022
		CommonApplicationData = 35, // 0x00000023
		Windows = 36, // 0x00000024
		System = 37, // 0x00000025
		ProgramFiles = 38, // 0x00000026
		MyPictures = 39, // 0x00000027
		UserProfile = 40, // 0x00000028
		SystemX86 = 41, // 0x00000029
		ProgramFilesX86 = 42, // 0x0000002A
		CommonProgramFiles = 43, // 0x0000002B
		CommonProgramFilesX86 = 44, // 0x0000002C
		CommonTemplates = 45, // 0x0000002D
		CommonDocuments = 46, // 0x0000002E
		CommonAdminTools = 47, // 0x0000002F
		AdminTools = 48, // 0x00000030
		CommonMusic = 53, // 0x00000035
		CommonPictures = 54, // 0x00000036
		CommonVideos = 55, // 0x00000037
		Resources = 56, // 0x00000038
		LocalizedResources = 57, // 0x00000039
		CommonOemLinks = 58, // 0x0000003A
		CDBurning = 59 // 0x0000003B
	}
#pragma warning restore CA1069 // Proxy attributes should not change original signatures

#pragma warning disable CA1027 // Proxy attributes should not change original signatures
	[MadnessType(EMadnessType.Proxy)]
	[PublicAPI]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum SpecialFolderOption {
		None = 0,
		DoNotVerify = 16384,
		Create = 32768
	}
#pragma warning restore CA1027 // Proxy attributes should not change original signatures
}
