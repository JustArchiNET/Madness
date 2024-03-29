# ☠️ Madness

[![Build status (GitHub)](https://img.shields.io/github/actions/workflow/status/JustArchiNET/Madness/ci.yml?branch=main&label=GitHub&logo=github&cacheSeconds=600)](https://github.com/JustArchiNET/Madness/actions?query=workflow%3AMadness-ci+branch%3Amain)
[![Github last commit date](https://img.shields.io/github/last-commit/JustArchiNET/Madness.svg?label=Updated&logo=github&cacheSeconds=600)](https://github.com/JustArchiNET/Madness/commits)
[![NuGet Total downloads](https://img.shields.io/nuget/dt/JustArchiNET.Madness.svg?label=Downloads&logo=nuget&cacheSeconds=600)](https://www.nuget.org/packages/JustArchiNET.Madness)
[![License](https://img.shields.io/github/license/JustArchiNET/Madness.svg?label=License&logo=apache&cacheSeconds=2592000)](https://github.com/JustArchiNET/Madness/blob/main/LICENSE.txt)

[![GitHub stable release version](https://img.shields.io/github/v/release/JustArchiNET/Madness.svg?label=Stable&logo=github&cacheSeconds=600)](https://github.com/JustArchiNET/Madness/releases/latest)
[![NuGet stable release version](https://img.shields.io/nuget/v/JustArchiNET.Madness?label=Stable&logo=nuget&cacheSeconds=600)](https://www.nuget.org/packages/JustArchiNET.Madness/latest)
[![GitHub stable release date](https://img.shields.io/github/release-date/JustArchiNET/Madness.svg?label=Released&logo=github&cacheSeconds=600)](https://github.com/JustArchiNET/Madness/releases/latest)

[![GitHub experimental release version](https://img.shields.io/github/v/release/JustArchiNET/Madness?include_prereleases&label=Experimental&logo=github&cacheSeconds=600)](https://github.com/JustArchiNET/Madness/releases)
[![NuGet experimental release version](https://img.shields.io/nuget/vpre/JustArchiNET.Madness?label=Experimental&logo=nuget&cacheSeconds=600)](https://www.nuget.org/packages/JustArchiNET.Madness)
[![GitHub experimental release date](https://img.shields.io/github/release-date-pre/JustArchiNET/Madness.svg?label=Released&logo=github&cacheSeconds=600)](https://github.com/JustArchiNET/Madness/releases)

[![GitHub sponsor](https://img.shields.io/badge/GitHub-sponsor-ea4aaa.svg?logo=github-sponsors)](https://github.com/sponsors/JustArchi)
[![Crypto donate](https://img.shields.io/badge/Crypto-donate-f7931a.svg?logo=bitcoin)](https://commerce.coinbase.com/checkout/0c23b844-c51b-45f4-9135-8db7c6fcf98e)
[![PayPal.me donate](https://img.shields.io/badge/PayPal.me-donate-00457c.svg?logo=paypal)](https://paypal.me/JustArchi)
[![PayPal donate](https://img.shields.io/badge/PayPal-donate-00457c.svg?logo=paypal)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=HD2P2P3WGS5Y4)
[![Revolut donate](https://img.shields.io/badge/Revolut-donate-0075eb.svg?logo=revolut)](https://pay.revolut.com/justarchi)
[![Steam donate](https://img.shields.io/badge/Steam-donate-000000.svg?logo=steam)](https://steamcommunity.com/tradeoffer/new/?partner=46697991&token=0ix2Ruv_)

---

[![Repobeats analytics image](https://repobeats.axiom.co/api/embed/505fe2dc194a0219138dfc2e3c2076f0d4e64a5b.svg "Repobeats analytics image")](https://github.com/JustArchiNET/Madness/pulse)

---

## Deprecation notice

Due to the fact that we've dropped support for .NET Framework in our other projects, we don't intend to develop Madness further. You're free to fork or re-use Madness components if you find them useful!

---

## Description

Madness embraces your project by including compatibility layer for selected APIs normally not available on .NET Framework (and alike) platforms.

## Installation

We support `netstandard2.0`, so .NET Framework 4.6.1 and newer. There is also a `netstandard2.1` package that can be used e.g. on Xamarin.

```
dotnet add package JustArchiNET.Madness
```

If you're targetting multiple frameworks out of which only one is .NET Framework (e.g. `net8.0` and `net481`), it's *usually* a good idea to not pull it for the others.

```csproj
<ItemGroup Condition="'$(TargetFramework)' == 'net481'">
	<PackageReference Include="JustArchiNET.Madness" />
</ItemGroup>
```

## Usage

Usage depends on where you need to go *mad*. It'll require from you to add appropriate `using` clause in the affected source files.

## Hint

Instead of adding `using` clause to each file, you can instead decide to do it once in the `csproj` (or appropriate project declaration) file. This way you won't need to add `#if NETFRAMEWORK` only for `using JustArchiNET.Madness(...)` clauses.

Example:

```csproj
<ItemGroup Condition="'$(TargetFramework)' == 'net481'">
	<PackageReference Include="JustArchiNET.Madness" />

	<Using Include="JustArchiNET.Madness" />
	<Using Include="JustArchiNET.Madness.ArgumentExceptionMadness.ArgumentException" Alias="ArgumentException" />
	<Using Include="JustArchiNET.Madness.ArgumentNullExceptionMadness.ArgumentNullException" Alias="ArgumentNullException" />
	<Using Include="JustArchiNET.Madness.ArgumentOutOfRangeExceptionMadness.ArgumentOutOfRangeException" Alias="ArgumentOutOfRangeException" />
	<Using Include="JustArchiNET.Madness.ArrayMadness.Array" Alias="Array" />
	<Using Include="JustArchiNET.Madness.CancellationTokenSourceMadness.CancellationTokenSource" Alias="CancellationTokenSource" />
	<Using Include="JustArchiNET.Madness.ConvertMadness.Convert" Alias="Convert" />
	<Using Include="JustArchiNET.Madness.DirectoryInfoMadness.DirectoryInfo" Alias="DirectoryInfo" />
	<Using Include="JustArchiNET.Madness.DirectoryMadness.Directory" Alias="Directory" />
	<Using Include="JustArchiNET.Madness.EnumMadness.Enum" Alias="Enum" />
	<Using Include="JustArchiNET.Madness.EnvironmentMadness.Environment" Alias="Environment" />
	<Using Include="JustArchiNET.Madness.FileInfoMadness.FileInfo" Alias="FileInfo" />
	<Using Include="JustArchiNET.Madness.FileMadness.File" Alias="File" />
	<Using Include="JustArchiNET.Madness.FileMadness.UnixFileMode" Alias="UnixFileMode" />
	<Using Include="JustArchiNET.Madness.HashCodeMadness.HashCode" Alias="HashCode" />
	<Using Include="JustArchiNET.Madness.HMACSHA1Madness.HMACSHA1" Alias="HMACSHA1" />
	<Using Include="JustArchiNET.Madness.HttpRequestExceptionMadness.HttpRequestException" Alias="HttpRequestException" />
	<Using Include="JustArchiNET.Madness.MemberNotNullWhenAttributeMadness.MemberNotNullWhenAttribute" Alias="MemberNotNullWhenAttribute" />
	<Using Include="JustArchiNET.Madness.NewtonsoftJsonMadness.JsonTextReader" Alias="JsonTextReader" />
	<Using Include="JustArchiNET.Madness.NewtonsoftJsonMadness.JsonTextWriter" Alias="JsonTextWriter" />
	<Using Include="JustArchiNET.Madness.OperatingSystemMadness.OperatingSystem" Alias="OperatingSystem" />
	<Using Include="JustArchiNET.Madness.PathMadness.Path" Alias="Path" />
	<Using Include="JustArchiNET.Madness.QuicExceptionMadness.QuicException" Alias="QuicException" />
	<Using Include="JustArchiNET.Madness.RandomMadness.Random" Alias="Random" />
	<Using Include="JustArchiNET.Madness.SHA256Madness.SHA256" Alias="SHA256" />
	<Using Include="JustArchiNET.Madness.SHA512Madness.SHA512" Alias="SHA512" />
	<Using Include="JustArchiNET.Madness.StringMadness.String" Alias="String" />
</ItemGroup>
```

We recommend to add `<Using>` clauses only for parts that you actually require/want to use from Madness.

Because of the `File` using declared above, you're now able to write this very nice ifdef-free code for both `net481` and newer platform target:

```csharp
using System.IO;
using System.Threading.Tasks;

namespace ThisIsMadness {
	public static class ThisIsSparta {
		public static async Task Scream() {
			// This compiles for both .NET Framework and other targets without any #if clauses, nice
			await File.WriteAllTextAsync("example.txt", "example").ConfigureAwait(false);
		}
	}
}
```

### Static extensions

Static extensions include useful stuff that you'll usually stumble upon with newer language syntax and/or .NET platform.

Examples include native deconstruction (for all types), `DisposeAsync()` as well as support for `await using { }` blocks, or methods working with `ReadOnlyMemory`.

```csharp
#if NETFRAMEWORK
using JustArchiNET.Madness;
#endif
using System.IO;
using System.Threading.Tasks;

namespace ThisIsMadness {
	public static class ThisIsSparta {
		public static async Task Scream() {
			MemoryStream stream = new MemoryStream();

			// Wow, this compiles now, but .NET Framework can't into `IAsyncDisposable`!
			// HOW IS THIS POSSIBLE, THIS IS MADNESS ☠️
			await stream.DisposeAsync().ConfigureAwait(false);
		}
	}
}
```

### IndexRange

This library includes a dependency on awesome **[IndexRange](https://www.nuget.org/packages/IndexRange)** project, which allows you to use `System.Index` and `System.Range` on .NET Framework.

```csharp
namespace ThisIsMadness {
	public static class ThisIsSparta {
		public static void Scream() {
			const string text = "Madness?";

			string? subString = text[1..^1];
		}
	}
}
```

Check **[IndexRange](https://github.com/bgrainger/IndexRange)** project for more details.

### File extensions

File extensions include mostly `Async` overloads for selected methods.

```csharp
#if NETFRAMEWORK
using File = JustArchiNET.Madness.FileMadness.File;
#else
using System.IO;
#endif
using System.Threading.Tasks;

namespace ThisIsMadness {
	public static class ThisIsSparta {
		public static async Task Scream() {
			// This compiles for both .NET Framework and other targets without more #if clauses, nice
			await File.WriteAllTextAsync("example.txt", "example").ConfigureAwait(false);
		}
	}
}
```

### HashCode extensions

HashCode extensions include implementation of `Combine<T1, T2...>()`.

```csharp
#if NETFRAMEWORK
using HashCode = JustArchiNET.Madness.HashCodeMadness.HashCode;
#else
using System;
#endif

namespace ThisIsMadness {
	public static class ThisIsSparta {
		public static void Scream() {
			int example = HashCode.Combine("test", "test2", "test3");
		}
	}
}
```

### Path extensions

Path extensions include fully backported implementation of `Path.GetRelativePath()`, including more complex scenarios than below.

```csharp
#if NETFRAMEWORK
using Path = JustArchiNET.Madness.PathMadness.Path;
#else
using System.IO;
#endif

namespace ThisIsMadness {
	public static class ThisIsSparta {
		public static void Scream() {
			// This compiles for both .NET Framework and other targets without more #if clauses, nice
			string example = Path.GetRelativePath("/tmp", "/tmp/example/example.txt");
		}
	}
}
```

### OperatingSystem extensions

OperatingSystem extensions include implementation of `IsFreeBSD()`, `IsLinux()`, `IsMacOS()`, `IsOSPlatform()`, `IsWindows()` and alike.

Those functions *should* be compatible with platforms supported by **[Mono](https://www.mono-project.com/docs/about-mono/supported-platforms)**, for checking against Mono-specific platforms use `IsOSPlatform(string platform)`, the exact names to check against can be found **[here](https://github.com/mono/mono/blob/a65055dbdf280004c56036a5d6dde6bec9e42436/mcs/class/corlib/System.Runtime.InteropServices.RuntimeInformation/RuntimeInformation.cs#L82-L121)**.

```csharp
#if NETFRAMEWORK
using OperatingSystem = JustArchiNET.Madness.OperatingSystemMadness.OperatingSystem;
#endif
using System;

namespace ThisIsMadness {
	public static class ThisIsSparta {
		public static void Scream() {
			if (OperatingSystem.IsWindows()) {
				// Windows logic
			} else {
				// Non-windows logic
			}
		}
	}
}
```

### Other

Root `JustArchiNET.Madness` namespace also includes selected classes normally not available on .NET Framework, for example `SupportedOSPlatform` or non-generic `TaskCompletionSource`.

```csharp
#if NETFRAMEWORK
using JustArchiNET.Madness;
#else
using System.Runtime.Versioning;
#endif

namespace ThisIsMadness {
	public static class ThisIsSparta {
		[SupportedOSPlatform("Windows")]
		public static void Scream() {
			// Obviously this doesn't have the effect you expect from your IDE, but at least you don't have to hide it behind #if
			// Besides, if you're targetting something else like net5.0 then it'll work as designed warning you about calls from other platforms.
		}
	}
}
```

---

## FAQ

### Do I need that `#if NETFRAMEWORK` clause?

If you're building only for .NET Framework exclusively, no, it's not required and actually quite useless code verbosity for you.

However, if you're targetting multiple frameworks out of which only one is .NET Framework (e.g. `net8.0` and `net481`), then `#if` clause guarantees that madness won't embrace your other targets.

You don't want madness to embrace your other targets, do you?

It also becomes mandatory if you're building for multiple targets and you've followed our advice and conditionally included `<PackageReference>` only for .NET Framework. Other targets won't know about this namespace, so hiding the usage behind `#if` becomes obligatory. On the other hand, it's perfect, because it ensures you don't use our `using` where you don't intend to.

At the same time check out our **[hint](#hint)** above, as it's possible to add `using` clauses globally to the whole project, which won't require from you to pollute every file with a potential `#if`.

### And what happens if I use Madness for other frameworks?

Nothing bad, if you ignore increased likelihood for compatibility issues, degraded performance, potential source code conflicts with original classes and all other mess that you really don't want to get into. Don't go deeper than you have to. We've been there before you, it's not pleasant. It's best to keep it sane for other targets, but we don't judge you, `Madness` supports `netstandard2.0` and above, include it wherever you want to.

### What if I need to combine Madness parts with .NET ones?

We've hidden our static classes deeper in our namespace for a reason - to decrease chance that you run into this issue. Usually it's enough for one `#if` on the top, as in our **[file extensions](#file-extensions)** example above.

However, sometimes you can't help it, and you'll have to `#if` all the way through for those cases, still better than writing it yourself, right?

```csharp
#if NETFRAMEWORK
using JustArchiNET.Madness;
#else
using System.Diagnostics;
#endif
using System;

namespace ThisIsMadness {
	public static class ThisIsSparta {
		internal static DateTime ProcessStartTime {
#if NETFRAMEWORK
			get => RuntimeMadness.ProcessStartTime.ToUniversalTime();
#else
			get {
				using Process process = Process.GetCurrentProcess();

				return process.StartTime.ToUniversalTime();
			}
#endif
		}
	}
}
```

If all else fails, you **can** in theory call `Madness` parts exclusively (since it's based on .NET Standard, not Framework per-se), so the above is rather a "perfect" example for not affecting your other targets negatively. You have to decide yourself between affecting code readability or compatibility and performance. Choose your poison. We recommend to keep `Madness` contained in .NET Framework exclusively, like in all our examples.

### All of this is cool, but I'm missing `XYZ` for my needs...

Send a **[PR](https://github.com/JustArchiNET/Madness/pulls)**, `Madness` by default includes parts that we require ourselves in **[ArchiSteamFarm](https://github.com/JustArchiNET/ArchiSteamFarm)** project and as you can guess, we can't rewrite everything that was made by thousands of developers in newer versions of .NET just to satisfy .NET Framework on its last leg.

For best results you should include exact classes, methods, properties and everything else, so source code requirements to make use of it are close to minimum and hopefully only initial `using` clause will be required to embrace the `Madness`.

We're also open for so-called "proxy" features in static classes that we already provide, to decrease burden of putting `#if` clauses everywhere. We've included all of those we require ourselves, such as:

```csharp
public static class File {
	public static bool Exists(string? path) => System.IO.File.Exists(path);
}
```

This allows consumers to alias `File` to our implementation without additional burden - feel free to send a PR for those as well. If it helps you in any way to increase code quality and sanity for your original projects, `Madness` doesn't mind to take a hit for justified reason ☠️.

---

## Attribution

Skull icon made by **[Freepik](https://www.freepik.com)** from **[Flaticon](https://www.flaticon.com)**.
