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

namespace JustArchiNET.Madness.ArrayMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public static class Array {
	[MadnessType(EMadnessType.Implementation)]
	public static int MaxLength => 0X7FFFFFC7;

	[MadnessType(EMadnessType.Proxy)]
	public static void Copy(System.Array sourceArray, System.Array destinationArray, int length) => System.Array.Copy(sourceArray, destinationArray, length);

	[MadnessType(EMadnessType.Proxy)]
	public static void Copy(System.Array sourceArray, int sourceIndex, System.Array destinationArray, int destinationIndex, int length) => System.Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);

	[MadnessType(EMadnessType.Proxy)]
	public static T[] Empty<T>() => System.Array.Empty<T>();

	[MadnessType(EMadnessType.Proxy)]
	public static void Reverse<T>(T[] array) => System.Array.Reverse(array);
}
