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
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness;

/// <inheritdoc />
/// <summary>
///     Suppresses reporting of a specific rule violation, allowing multiple suppressions on a
///     single code artifact.
/// </summary>
/// <remarks>
///     <see cref="UnconditionalSuppressMessageAttribute" /> is different than
///     <see cref="SuppressMessageAttribute" /> in that it doesn't have a
///     <see cref="ConditionalAttribute" />. So it is always preserved in the compiled assembly.
/// </remarks>
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
public sealed class UnconditionalSuppressMessageAttribute : Attribute {
	/// <summary>
	///     Gets the category identifying the classification of the attribute.
	/// </summary>
	/// <remarks>
	///     The <see cref="Category" /> property describes the tool or tool analysis category
	///     for which a message suppression attribute applies.
	/// </remarks>
	public string Category { get; }

	/// <summary>
	///     Gets the identifier of the analysis tool rule to be suppressed.
	/// </summary>
	/// <remarks>
	///     Concatenated together, the <see cref="Category" /> and <see cref="CheckId" />
	///     properties form a unique check identifier.
	/// </remarks>
	public string CheckId { get; }

	/// <summary>
	///     Gets or sets the justification for suppressing the code analysis message.
	/// </summary>
	public string? Justification { get; set; }

	/// <summary>
	///     Gets or sets an optional argument expanding on exclusion criteria.
	/// </summary>
	/// <remarks>
	///     The <see cref="MessageId " /> property is an optional argument that specifies additional
	///     exclusion where the literal metadata target is not sufficiently precise. For example,
	///     the <see cref="UnconditionalSuppressMessageAttribute" /> cannot be applied within a method,
	///     and it may be desirable to suppress a violation against a statement in the method that will
	///     give a rule violation, but not against all statements in the method.
	/// </remarks>
	public string? MessageId { get; set; }

	/// <summary>
	///     Gets or sets the scope of the code that is relevant for the attribute.
	/// </summary>
	/// <remarks>
	///     The Scope property is an optional argument that specifies the metadata scope for which
	///     the attribute is relevant.
	/// </remarks>
	public string? Scope { get; set; }

	/// <summary>
	///     Gets or sets a fully qualified path that represents the target of the attribute.
	/// </summary>
	/// <remarks>
	///     The <see cref="Target" /> property is an optional argument identifying the analysis target
	///     of the attribute. An example value is "System.IO.Stream.ctor():System.Void".
	///     Because it is fully qualified, it can be long, particularly for targets such as parameters.
	///     The analysis tool user interface should be capable of automatically formatting the parameter.
	/// </remarks>
	public string? Target { get; set; }

	/// <inheritdoc />
	/// <summary>
	///     Initializes a new instance of the <see cref="UnconditionalSuppressMessageAttribute" />
	///     class, specifying the category of the tool and the identifier for an analysis rule.
	/// </summary>
	/// <param name="category">The category for the attribute.</param>
	/// <param name="checkId">The identifier of the analysis rule the attribute applies to.</param>
	public UnconditionalSuppressMessageAttribute(string category, string checkId) {
		Category = category;
		CheckId = checkId;
	}
}
