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

using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness.OperatingSystemMadness;

[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
public static class OperatingSystem {
	/// <summary>
	///     Indicates whether the current application is running on FreeBSD.
	/// </summary>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsFreeBSD() => RuntimeInformation.IsOSPlatform(OSPlatform.Create("FREEBSD"));

	/// <summary>
	///     Check for the FreeBSD version (returned by 'uname') with a >= version comparison. Used to guard APIs that were added in the given FreeBSD release.
	/// </summary>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsFreeBSDVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0) => IsFreeBSD() && IsOSVersionAtLeast(major, minor, build, revision);

	/// <summary>
	///     Indicates whether the current application is running on Linux.
	/// </summary>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

	/// <summary>
	///     Indicates whether the current application is running on macOS.
	/// </summary>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

	/// <summary>
	///     Check for the macOS version (returned by 'libobjc.get_operatingSystemVersion') with a >= version comparison. Used to guard APIs that were added in the given macOS release.
	/// </summary>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsMacOSVersionAtLeast(int major, int minor = 0, int build = 0) => IsMacOS() && IsOSVersionAtLeast(major, minor, build, 0);

	/// <summary>
	///     Indicates whether the current application is running on the specified platform.
	/// </summary>
	/// <param name="platform">Case-insensitive platform name. Examples: Browser, Linux, FreeBSD, Android, iOS, macOS, tvOS, watchOS, Windows.</param>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsOSPlatform(string platform) {
		if (platform == null) {
			throw new ArgumentNullException(nameof(platform));
		}

		string platformUpperCase = platform.ToUpperInvariant();

		return platformUpperCase switch {
			"FREEBSD" => IsFreeBSD(),
			"LINUX" => IsLinux(),
			"MACOS" => IsMacOS(),
			"OSX" => IsMacOS(),
			"WINDOWS" => IsWindows(),
			_ => RuntimeInformation.IsOSPlatform(OSPlatform.Create(platformUpperCase))
		};
	}

	/// <summary>
	///     Indicates whether the current application is running on Windows.
	/// </summary>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

	/// <summary>
	///     Check for the Windows version (returned by 'RtlGetVersion') with a >= version comparison. Used to guard APIs that were added in the given Windows release.
	/// </summary>
	[MadnessType(EMadnessType.Implementation)]
	public static bool IsWindowsVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0) => IsWindows() && IsOSVersionAtLeast(major, minor, build, revision);

	private static bool IsOSVersionAtLeast(int major, int minor, int build, int revision) {
		Version current = Environment.OSVersion.Version;

		if (current.Major != major) {
			return current.Major > major;
		}

		if (current.Minor != minor) {
			return current.Minor > minor;
		}

		if (current.Build != build) {
			return current.Build > build;
		}

		return (current.Revision >= revision)
			|| ((current.Revision == -1) && (revision == 0)); // it is unavailable on OSX and Environment.OSVersion.Version.Revision returns -1
	}
}
