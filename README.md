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

---

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

### And if I need both?

Pick the one you use more often and ifdef the rest.

```csharp
using File = System.IO.File;

public static async Task Example() {
#if NETFRAMEWORK
	await JustArchiNET.Madness.File.WriteAllTextAsync("example.txt", "example").ConfigureAwait(false);
#else
	await File.WriteAllTextAsync("example.txt", "example").ConfigureAwait(false);
#endif
}
```

You **can** in theory call `Madness` parts exclusively, so the above is rather a "perfect" example for not affecting your other targets negatively. If you don't mind, you can call madness on both.