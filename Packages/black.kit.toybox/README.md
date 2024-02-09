<!-- markdownlint-disable MD024 -->

# ⚙️ UdonSharp Toybox by Kuroné Kito

![U# Toybox by Kuroné Kito](https://repository-images.githubusercontent.com/751466292/e693662b-cc02-4d99-ae74-636ae9563300)

My utilities library for the UdonSharp / VRChat

## 💡 Features

- 🌈 Logger with vivid colors
- ⚙️ Some extended methods for the arrays, strings, and VRCPlayerApi

## 💻 System Requirements

- [VRChat Creator Companion](https://vrchat.com/home/download)
- Unity 2022.3.6f1
- 🏝 Project of your world

## How to use

### 1. Import the registry via the VRChat Creator Companion (VCC)

(To be added)

### 2. Import the UdonSharp Toybox package to your project

(To be added)

### 3. Use the utilities, enjoy :D

Example:

```csharp
using black.kit.toybox;

public class Example : UdonSharpBehaviour
{
    public void Start()
    {
      // Example of using the Contains extension method
      var array = new[] { 1, 2, 3, 4, 5 };
      Debug.Log($"Contains(3): {array.Contains(3)}");
      Debug.Log($"Contains(6): {array.Contains(6)}");
    }
}
```

## API

All library components are in the `black.kit.toybox` namespace.

```csharp
using black.kit.toybox;
```

### Extension methods

#### `bool string.AreAllCharsContained(string chars)`

Determine whether the string contains all the characters in the specified
string.

```csharp
"abc".AreAllCharsContained("abcde"); // true
"abc".AreAllCharsContained("abd"); // false
"abc".AreAllCharsContained(null); // false

string nullString = null;
// true (always true if the string is null)
nullString.AreAllCharsContained("abc");
```

#### `bool T[].Contains<T>(T value)`

Determines whether the specified array contains the specified value.

```csharp
int[] array = new[] { 1, 2, 3, 4, 5 };
array.Contains(3); // true
array.Contains(6); // false

int[] nullArray = null;
nullArray.Contains(3); // false (always false if the array is null)
```

#### `string VRCPlayerApi.GetPlayerName(string fallback = null)`

When the player is valid, return the player's name. Otherwise, it returns
the specified fallback string.

```csharp
Networking.LocalPlayer.GetPlayerName("Unknown"); // "Kuroné Kito"
```

#### `string VRCPlayerApi.GetSafePlayerName(string safeCharset, string fallback = null)`

When the player is valid, return the player's name with only the specified
characters. Otherwise, it returns the specified fallback string.

Note: The fallback string returns **WITHOUT** validation.

```csharp
Networking.LocalPlayer.GetSafePlayerName("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "UNKNOWN") // "KURONEKITO"
```

#### `void GameObject[].SetActive(bool active)`

Batch setting of game object activation status.
  
```csharp
// null elements are ignored automatically
GameObject[] objects = new[] { object1, object2, null };
objects.SetActive(true); // Activate all objects
objects.SetActive(false); // Deactivate all objects
```

## License

This repository is licensed under the [MIT License](LICENSE).
