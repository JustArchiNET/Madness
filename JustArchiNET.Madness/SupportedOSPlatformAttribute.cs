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
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness;

/// <inheritdoc />
/// <summary>
///     Records the operating system (and minimum version) that supports an API. Multiple attributes can be
///     applied to indicate support on multiple operating systems.
/// </summary>
/// <remarks>
///     Callers can apply a System.Runtime.Versioning.SupportedOSPlatformAttribute
///     or use guards to prevent calls to APIs on unsupported operating systems.
///     A given platform should only be specified once.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Enum | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Module | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
public sealed class SupportedOSPlatformAttribute : Attribute {
	[MadnessType(EMadnessType.Implementation)]
	public string PlatformName { get; }

	[MadnessType(EMadnessType.Implementation)]
	public SupportedOSPlatformAttribute(string platformName) => PlatformName = platformName;
}
