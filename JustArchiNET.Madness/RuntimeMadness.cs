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
using System.Diagnostics;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness;

/// <summary>
///     Static Madness-specific class used for basic runtime-related operations.
/// </summary>
[MadnessType(EMadnessType.Extension)]
[PublicAPI]
public static class RuntimeMadness {
	/// <summary>
	///     Boolean value that can be used for determining whether or not the assembly is being executed by the Mono runtime.
	/// </summary>
	/// <remarks>
	///     This is implemented based on the existence of Mono.Runtime type, which might result in false-positives if there is any dependency declaring that type.
	/// </remarks>
	/// <returns>
	///     True if the assembly is executed on Mono runtime (as opposed to Windows-specific .NET Framework one), otherwise false.
	/// </returns>
	[MadnessType(EMadnessType.Extension)]
	public static bool IsRunningOnMono => Type.GetType("Mono.Runtime") != null;

	/// <summary>
	///     <see cref="Process.StartTime" /> of current process, patched for compatibility with Mono.
	/// </summary>
	/// <returns>
	///     <see cref="DateTime" /> containing current process starting time.
	/// </returns>
	[MadnessType(EMadnessType.Extension)]
	public static DateTime ProcessStartTime {
		get {
			if (!UseSavedProcessStartTime) {
				try {
					using Process process = Process.GetCurrentProcess();

					return process.StartTime;
				} catch {
					UseSavedProcessStartTime = true;
				}
			}

			return SavedProcessStartTime;
		}
	}

	private static bool UseSavedProcessStartTime;
	private static readonly DateTime SavedProcessStartTime = DateTime.UtcNow;
}
