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

using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness.HashCodeMadness;

[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
public static class HashCode {
#if NETSTANDARD2_1_OR_GREATER
	[MadnessType(EMadnessType.Proxy)]
	public static int Combine<T1, T2>(T1 value1, T2 value2) => System.HashCode.Combine(value1, value2);

	[MadnessType(EMadnessType.Proxy)]
	public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3) => System.HashCode.Combine(value1, value2, value3);

	[MadnessType(EMadnessType.Proxy)]
	public static int Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4) => System.HashCode.Combine(value1, value2, value3, value4);
#else
	[MadnessType(EMadnessType.Implementation)]
	public static int Combine<T1, T2>(T1 value1, T2 value2) => (value1, value2).GetHashCode();

	[MadnessType(EMadnessType.Implementation)]
	public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3) => (value1, value2, value3).GetHashCode();

	[MadnessType(EMadnessType.Implementation)]
	public static int Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4) => (value1, value2, value3, value4).GetHashCode();
#endif
}
