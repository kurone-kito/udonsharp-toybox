# ![U# Toybox by Kuroné Kito](images/banner.png)

My utilities library for the UdonSharp / VRChat

## 💡 Features

- 🖱 UI parts with global sync
- 🫥 Object teleporter by turning the object on or off
- 🔓 (Statically) whitelist gimmick
- 🛎 Notify sound playing gimmick on player joined
- 🗞 Publish-Subscribe pattern component
- 🌈 Logger with vivid colors
- ⚙️ Other features...

## 💻 System Requirements

- [VRChat Creator Companion](https://vrchat.com/home/download)
- Unity 2022.3.22f1
- 🏝 Project of your world

## ▶ Getting Started

### 1. Import the registry via the VRChat Creator Companion (VCC)

**[Add to VCC](vcc://vpm/addRepo?url=https%3A%2F%2Fkurone-kito.github.io%2Fvpm%2Findex.json)**

### 2. Import the UdonSharp Toybox package to your project

1. Click on the "Manage Project" button in the VCC
2. Find the "UdonSharp Toybox" package and click on the "(+) Add package" button

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

## License

This repository is licensed under the **MIT License**.
