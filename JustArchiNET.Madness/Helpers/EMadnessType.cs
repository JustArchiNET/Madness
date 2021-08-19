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

namespace JustArchiNET.Madness.Helpers {
	/// <summary>
	///     Madness type specifying provided functionality.
	/// </summary>
	public enum EMadnessType : byte {
		/// <summary>
		///     Unknown functionality, a default value that isn't normally used.
		/// </summary>
		Unknown = 0,

		/// <summary>
		///     Proxy functionality that executes original code with no changes in the logic.
		/// </summary>
		Proxy = 1,

		/// <summary>
		///     Replacement functionality that provides drop-in replacement of the original code.
		/// </summary>
		Replacement = 2,

		/// <summary>
		///     Implementation functionality that provides features missing in the original code.
		/// </summary>
		Implementation = 3,

		/// <summary>
		///     Extension functionality, that Madness provides as a helper for you on its own.
		/// </summary>
		Extension = 4
	}
}
