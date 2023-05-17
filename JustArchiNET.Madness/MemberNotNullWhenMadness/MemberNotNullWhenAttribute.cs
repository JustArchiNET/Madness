//							 _		 __  __
//  ___  ___   ___  _ __	__| |  __ _ |  \/  |
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

namespace JustArchiNET.Madness.MemberNotNullWhenMadness;

[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
public sealed class MemberNotNullWhenAttribute : Attribute {
	/// <summary>Gets the return value condition.</summary>
	[MadnessType(EMadnessType.Implementation)]
	public bool ReturnValue { get; }

	/// <summary>Gets field or property member names.</summary>
	[MadnessType(EMadnessType.Implementation)]
	public string[] Members { get; }

	/// <summary>Initializes the attribute with the specified return value condition and a field or property member.</summary>
	/// <param name="returnValue">
	/// The return value condition. If the method returns this value, the associated parameter will not be null.
	/// </param>
	/// <param name="member">
	/// The field or property member that is promised to be not-null.
	/// </param>
	[MadnessType(EMadnessType.Implementation)]
	public MemberNotNullWhenAttribute(bool returnValue, string member)
	{
		ReturnValue = returnValue;
		Members = new[] { member };
	}

	/// <summary>Initializes the attribute with the specified return value condition and list of field and property members.</summary>
	/// <param name="returnValue">
	/// The return value condition. If the method returns this value, the associated parameter will not be null.
	/// </param>
	/// <param name="members">
	/// The list of field and property members that are promised to be not-null.
	/// </param>
	[MadnessType(EMadnessType.Implementation)]
	public MemberNotNullWhenAttribute(bool returnValue, params string[] members)
	{
		ReturnValue = returnValue;
		Members = members;
	}
}
