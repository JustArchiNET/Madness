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

// ReSharper disable once CheckNamespace - we intentionally declare this namespace
namespace System.Runtime.CompilerServices;

/// <inheritdoc />
/// <summary>
///     Allows capturing of the expression passed to a method
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
public sealed class CallerArgumentExpressionAttribute : Attribute {
	/// <summary>
	///     Gets the target parameter name of the CallerArgumentExpression.
	/// </summary>
	/// <returns>The name of the targeted parameter of the CallerArgumentExpression</returns>
	public string ParameterName { get; }

	/// <inheritdoc />
	/// <summary>
	///     Initializes a new instance of the <see cref="CallerArgumentExpressionAttribute" /> class.
	/// </summary>
	/// <param name="parameterName">The name of the targeted parameter.</param>
	public CallerArgumentExpressionAttribute(string parameterName) => ParameterName = parameterName;
}
