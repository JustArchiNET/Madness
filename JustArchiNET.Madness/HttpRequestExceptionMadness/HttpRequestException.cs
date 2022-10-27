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
using System.Net;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness.HttpRequestExceptionMadness;

[MadnessType(EMadnessType.Replacement)]
[PublicAPI]
public class HttpRequestException : System.Net.Http.HttpRequestException {
	/// <summary>
	/// Gets the HTTP status code to be returned with the exception.
	/// </summary>
	/// <value>
	/// An HTTP status code if the exception represents a non-successful result, otherwise <c>null</c>.
	/// </value>
	public HttpStatusCode? StatusCode { get; }

	public HttpRequestException() { }

	public HttpRequestException(string? message) : base(message) { }

	public HttpRequestException(string? message, Exception? inner) : base(message, inner) { }

	public HttpRequestException(string? message, Exception? inner, HttpStatusCode? statusCode) : this(message, inner) => StatusCode = statusCode;
}
