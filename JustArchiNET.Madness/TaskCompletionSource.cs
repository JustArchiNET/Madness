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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JustArchiNET.Madness.Helpers;

namespace JustArchiNET.Madness;

/// <summary>
///     Represents the producer side of a <see cref="Task" /> unbound to a
///     delegate, providing access to the consumer side through the <see cref="Task" /> property.
/// </summary>
/// <remarks>
///     <para>
///         It is often the case that a <see cref="Task" /> is desired to
///         represent another asynchronous operation.
///         <see cref="TaskCompletionSource">TaskCompletionSource</see> is provided for this purpose. It enables
///         the creation of a task that can be handed out to consumers, and those consumers can use the members
///         of the task as they would any other. However, unlike most tasks, the state of a task created by a
///         TaskCompletionSource is controlled explicitly by the methods on TaskCompletionSource. This enables the
///         completion of the external asynchronous operation to be propagated to the underlying Task. The
///         separation also ensures that consumers are not able to transition the state without access to the
///         corresponding TaskCompletionSource.
///     </para>
///     <para>
///         All members of <see cref="TaskCompletionSource" /> are thread-safe
///         and may be used from multiple threads concurrently.
///     </para>
/// </remarks>
[MadnessType(EMadnessType.Implementation)]
[PublicAPI]
public class TaskCompletionSource {
	/// <summary>
	///     Gets the <see cref="Task" /> created
	///     by this <see cref="TaskCompletionSource" />.
	/// </summary>
	/// <remarks>
	///     This property enables a consumer access to the <see cref="Task" /> that is controlled by this instance.
	///     The <see cref="SetResult" />, <see cref="SetException(Exception)" />, <see cref="SetException(System.Collections.Generic.IEnumerable{System.Exception})" />,
	///     and <see cref="SetCanceled" /> methods (and their "Try" variants) on this instance all result in the relevant state
	///     transitions on this underlying Task.
	/// </remarks>
	[MadnessType(EMadnessType.Proxy)]
	public Task Task => BackingTaskCompletionSource.Task;

	private readonly TaskCompletionSource<bool> BackingTaskCompletionSource;

	/// <summary>Creates a <see cref="TaskCompletionSource" />.</summary>
	[MadnessType(EMadnessType.Proxy)]
	public TaskCompletionSource() => BackingTaskCompletionSource = new TaskCompletionSource<bool>();

	/// <summary>Creates a <see cref="TaskCompletionSource" /> with the specified state.</summary>
	/// <param name="state">
	///     The state to use as the underlying
	///     <see cref="Task" />'s AsyncState.
	/// </param>
	[MadnessType(EMadnessType.Proxy)]
	public TaskCompletionSource(object? state) => BackingTaskCompletionSource = new TaskCompletionSource<bool>(state);

	/// <summary>Creates a <see cref="TaskCompletionSource" /> with the specified state and options.</summary>
	/// <param name="creationOptions">The options to use when creating the underlying <see cref="Task" />.</param>
	/// <param name="state">The state to use as the underlying <see cref="Task" />'s AsyncState.</param>
	/// <exception cref="ArgumentOutOfRangeException">The <paramref name="creationOptions" /> represent options invalid for use with a <see cref="TaskCompletionSource" />.</exception>
	[MadnessType(EMadnessType.Proxy)]
	public TaskCompletionSource(object? state, TaskCreationOptions creationOptions) => BackingTaskCompletionSource = new TaskCompletionSource<bool>(state, creationOptions);

	/// <summary>Creates a <see cref="TaskCompletionSource" /> with the specified options.</summary>
	/// <remarks>
	///     The <see cref="Task" /> created by this instance and accessible through its <see cref="Task" /> property
	///     will be instantiated using the specified <paramref name="creationOptions" />.
	/// </remarks>
	/// <param name="creationOptions">The options to use when creating the underlying <see cref="Task" />.</param>
	/// <exception cref="ArgumentOutOfRangeException">
	///     The <paramref name="creationOptions" /> represent options invalid for use
	///     with a <see cref="TaskCompletionSource" />.
	/// </exception>
	[MadnessType(EMadnessType.Proxy)]
	public TaskCompletionSource(TaskCreationOptions creationOptions) => BackingTaskCompletionSource = new TaskCompletionSource<bool>(creationOptions);

	/// <summary>
	///     Transitions the underlying <see cref="Task" /> into the <see cref="TaskStatus.Canceled" /> state.
	/// </summary>
	/// <exception cref="InvalidOperationException">
	///     The underlying <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </exception>
	[MadnessType(EMadnessType.Proxy)]
	public void SetCanceled() => BackingTaskCompletionSource.SetCanceled();

	/// <summary>Transitions the underlying <see cref="Task" /> into the <see cref="TaskStatus.Faulted" /> state.</summary>
	/// <param name="exceptions">The collection of exceptions to bind to this <see cref="Task" />.</param>
	/// <exception cref="ArgumentNullException">The <paramref name="exceptions" /> argument is null.</exception>
	/// <exception cref="ArgumentException">There are one or more null elements in <paramref name="exceptions" />.</exception>
	/// <exception cref="InvalidOperationException">
	///     The underlying <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </exception>
	[MadnessType(EMadnessType.Proxy)]
	public void SetException(IEnumerable<Exception> exceptions) => BackingTaskCompletionSource.SetException(exceptions);

	/// <summary>Transitions the underlying <see cref="Task" /> into the <see cref="TaskStatus.Faulted" /> state.</summary>
	/// <param name="exception">The exception to bind to this <see cref="Task" />.</param>
	/// <exception cref="ArgumentNullException">The <paramref name="exception" /> argument is null.</exception>
	/// <exception cref="InvalidOperationException">
	///     The underlying <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </exception>
	[MadnessType(EMadnessType.Proxy)]
	public void SetException(Exception exception) => BackingTaskCompletionSource.SetException(exception);

	/// <summary>
	///     Transitions the underlying <see cref="Task" /> into the <see cref="TaskStatus.RanToCompletion" /> state.
	/// </summary>
	/// <exception cref="InvalidOperationException">
	///     The underlying <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </exception>
	[MadnessType(EMadnessType.Proxy)]
	public void SetResult() => BackingTaskCompletionSource.SetResult(true);

	/// <summary>
	///     Attempts to transition the underlying <see cref="Task" /> into the <see cref="TaskStatus.Canceled" /> state.
	/// </summary>
	/// <returns>True if the operation was successful; otherwise, false.</returns>
	/// <remarks>
	///     This operation will return false if the <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </remarks>
	[MadnessType(EMadnessType.Proxy)]
	public bool TrySetCanceled() => BackingTaskCompletionSource.TrySetCanceled();

	/// <summary>
	///     Attempts to transition the underlying <see cref="Task" /> into the <see cref="TaskStatus.Canceled" /> state.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token with which to cancel the <see cref="Task" />.</param>
	/// <returns>True if the operation was successful; otherwise, false.</returns>
	/// <remarks>
	///     This operation will return false if the <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </remarks>
	[MadnessType(EMadnessType.Proxy)]
	public bool TrySetCanceled(CancellationToken cancellationToken) => BackingTaskCompletionSource.TrySetCanceled(cancellationToken);

	/// <summary>
	///     Attempts to transition the underlying <see cref="Task" /> into the <see cref="TaskStatus.Faulted" /> state.
	/// </summary>
	/// <param name="exception">The exception to bind to this <see cref="Task" />.</param>
	/// <returns>True if the operation was successful; otherwise, false.</returns>
	/// <remarks>
	///     This operation will return false if the <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </remarks>
	[MadnessType(EMadnessType.Proxy)]
	public bool TrySetException(Exception exception) => BackingTaskCompletionSource.TrySetException(exception);

	/// <summary>
	///     Attempts to transition the underlying <see cref="Task" /> into the <see cref="TaskStatus.Faulted" /> state.
	/// </summary>
	/// <param name="exceptions">The collection of exceptions to bind to this <see cref="Task" />.</param>
	/// <returns>True if the operation was successful; otherwise, false.</returns>
	/// <remarks>
	///     This operation will return false if the <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </remarks>
	/// <exception cref="ArgumentNullException">The <paramref name="exceptions" /> argument is null.</exception>
	/// <exception cref="ArgumentException">There are one or more null elements in <paramref name="exceptions" />.</exception>
	/// <exception cref="ArgumentException">The <paramref name="exceptions" /> collection is empty.</exception>
	[MadnessType(EMadnessType.Proxy)]
	public bool TrySetException(IEnumerable<Exception> exceptions) => BackingTaskCompletionSource.TrySetException(exceptions);

	/// <summary>
	///     Attempts to transition the underlying <see cref="Task" /> into the <see cref="TaskStatus.RanToCompletion" /> state.
	/// </summary>
	/// <returns>True if the operation was successful; otherwise, false.</returns>
	/// <remarks>
	///     This operation will return false if the <see cref="Task" /> is already in one of the three final states:
	///     <see cref="TaskStatus.RanToCompletion" />,
	///     <see cref="TaskStatus.Faulted" />, or
	///     <see cref="TaskStatus.Canceled" />.
	/// </remarks>
	[MadnessType(EMadnessType.Proxy)]
	public bool TrySetResult() => BackingTaskCompletionSource.TrySetResult(true);
}
