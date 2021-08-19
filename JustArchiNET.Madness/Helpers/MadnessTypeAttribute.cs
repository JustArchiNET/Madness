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
using System.ComponentModel;
using JetBrains.Annotations;

namespace JustArchiNET.Madness.Helpers {
	/// <inheritdoc />
	/// <summary>
	///     Madness type attribute, which annotates what kind of the functionality is provided.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property)]
	[PublicAPI]
	public sealed class MadnessTypeAttribute : Attribute {
		/// <summary>
		///     Type of the provided functionality.
		/// </summary>
		public EMadnessType Type { get; }

		internal MadnessTypeAttribute(EMadnessType type) {
			if ((type == EMadnessType.Unknown) || !Enum.IsDefined(typeof(EMadnessType), type)) {
				throw new InvalidEnumArgumentException(nameof(type), (int) type, typeof(EMadnessType));
			}

			Type = type;
		}
	}
}
