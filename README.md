# ☠️ Madness 

Madness embraces your project by including compatibility layer for selected APIs normally not available on .NET Framework target.

---

## How to use it

Add **[nuget package](https://www.nuget.org/packages/protobuf-net/)** to .NET Framework project of your choice. We support `netstandard2.0`, so .NET Framework 4.6.1 and newer.

Afterwards, in all files where you require assistance, include the reference:

```csharp
#if NETFRAMEWORK
using JustArchiNET.Madness;
#endif
```

Voila, madness has embraced your project.

```csharp
#if NETFRAMEWORK
using JustArchiNET.Madness;
#endif
using System.IO;
using System.Threading.Tasks;

namespace ArchiSteamFarm.Web.Responses {
	public static class Madness {
		public static async Task Test() {
			MemoryStream stream = new MemoryStream();

			// Wow, this compiles now, but .NET Framework doesn't even know crap about `IAsyncDisposable`!
			// HOW IS THIS POSSIBLE, IS THIS MADNESS ☠️
			await stream.DisposeAsync().ConfigureAwait(false);
		}
	}
}
```

## FAQ

### Do I need that `#if NETFRAMEWORK` clause?

If you're building only for .NET Framework exclusively, no, it's not required and actually useless for you.

However, if you're targetting multiple frameworks out of which only one is .NET Framework (e.g. `net5.0` and `net48`), then `#if` clause guarantees that madness won't embrace your other targets.

You don't want madness to embrace your other targets, do you?

### Including madness embraced stuff I didn't want to, like `File` or `Path`, what to do?

If you don't require madness in those aspects, tell C# compiler to use built-in classes in those places.

```csharp
using File = System.IO.File;
```

### And what if I do?

```csharp
using File = JustArchiNET.Madness.File;
```

### And if I need to combine both?

Sometimes, in particular when you refer only to selected methods and properties, you can simply point to `Madness` for .NET Framework, and built-in classes for the rest.

```csharp
#if NETFRAMEWORK
using JustArchiNET.Madness;
#else
using File = System.IO.File;
#endif

public static async Task Example() {
	// This will nicely use Madness for .NET Framework and System.IO.File for other targets, nice!
	await File.WriteAllTextAsync("example.txt", "example").ConfigureAwait(false);
}
```

And sometimes you can't, just `#if` all the way through for those cases, still better than writing it yourself, right?

```csharp
public static TimeSpan GetProcessUptime() {
#if NETFRAMEWORK
	return DateTime.UtcNow.Subtract(StaticHelpers.ProcessStartTime.ToUniversalTime());
#else
	using Process process = Process.GetCurrentProcess();

	return DateTime.UtcNow.Subtract(process.StartTime.ToUniversalTime());
#endif
}
```

You **can** in theory call `Madness` parts exclusively (since it's based on .NET Standard, not Framework per-se), so the above is rather a "perfect" example for not affecting your other targets negatively. If you don't mind, you can call madness on both, but chances are you don't want to pollute your runtime performance more than necessary. Choose your poison.

### All of this is cool, but I'm missing `XYZ` for my needs...

Send a **[PR](https://github.com/JustArchiNET/Madness/pulls)**, `Madness` by default includes parts that I require myself in **[ArchiSteamFarm](https://github.com/JustArchiNET/ArchiSteamFarm)** project and as you can guess, one-man army like me can't rewrite what thousands of developers did in .NET just to satisfy .NET Framework on its last leg. For best results include exact classes, methods, properties and everything else, so source code requirements to make use of it are close to minimum and hopefully only `using` clause will be required to embrace the `Madness`!