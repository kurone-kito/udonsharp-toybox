<!-- markdownlint-disable MD024 -->

# ⚙️ UdonSharp Toybox by Kuroné Kito

![U# Toybox by Kuroné Kito](https://repository-images.githubusercontent.com/751466292/e693662b-cc02-4d99-ae74-636ae9563300)

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
- Unity 2022.3.6f1
- 🏝 Project of your world

## How to use

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

## API

All library components are in the `black.kit.toybox` namespace.

```csharp
using black.kit.toybox;
```

---

### `Doorbell` class / extends `UdonSharpBehaviour`

The component plays the notify sound when the player joins the world.

For this component to work correctly, please follow these steps:

1. place it on the same object as the `AudioSource` component or manually
   tie it.

#### Inspector fields

- `AudioSource source`: The audio source component to play the notify
  sound.

---

### `GlobalScroll` class / extends `SyncBehaviour`

The component synchronizes the scroll position of the `ScrollRect` uGUI
component.

For this component to work correctly, please follow these steps:

1. place it on the same object as the `ScrollRect` component or manually
   tie it.
2. Set the following to `OnValueChanged (Vector2)` of the `ScrollRect`
   component.
   - Timing: `Runtime Only`
   - Reference: the `GlobalScroll` component, which is placed on GameObject
   - Call: `UdonBehaviour.SendCustomEvent (string)`
   - Argument: `OnScroll`

#### Synchronically fields

Avoid modifying these variables by users who do not have ownership rights,
as this may cause malfunctions. Also, if a user with ownership rights
changes these variables, please perform synchronization immediately.

- `Vector2 position = Vector2.up`: The scroll position to synchronize.
- `Vector2 velocity = Vector2.zero`: The scroll velocity to synchronize.

#### `public void OnScroll()`

The callback when the scroll position is changed.

#### `public void Reset()`

Reset the scroll position to the top.

#### `protected override void UpdateView()`

The callback to update the view, e.g. the synchronized scroll position.

---

### `GlobalSlider` class / extends `SyncBehaviour`

The component synchronizes the value of the `Slider` uGUI component.

For this component to work correctly, please follow these steps:

1. place it on the same object as the `Slider` component or manually tie it.
2. Set the following to `OnValueChanged (Single)` of the `Slider`
   component.
   - Timing: `Runtime Only`
   - Reference: the `GlobalToggle` component, which is placed on GameObject
   - Call: `UdonBehaviour.SendCustomEvent (string)`
   - Argument: `OnValueChanged`

#### Synchronically fields

Avoid modifying these variables by users who do not have ownership rights,
as this may cause malfunctions. Also, if a user with ownership rights
changes these variables, please perform synchronization immediately.

- `public float value`: The scroll position to synchronize.

#### `public void OnValueChanged()`

The callback when the value is changed.

#### `public void SetValue(float value)`

Set the value to the slider.

#### `protected override void UpdateView()`

The callback to update the view, e.g. on synchronized the value.

---

### `GlobalToggle` class / extends `SyncBehaviour`

The component synchronizes the scroll position of the `Toggle` uGUI
component.

For this component to work correctly, please follow these steps:

1. place it on the same object as the `Toggle` component or manually tie it.
2. Set the following to `OnValueChanged (Boolean)` of the `Toggle`
   component.
   - Timing: `Runtime Only`
   - Reference: the `GlobalToggle` component, which is placed on GameObject
   - Call: `UdonBehaviour.SendCustomEvent (string)`
   - Argument: `OnToggle`

#### Synchronically fields

Avoid modifying these variables by users who do not have ownership rights,
as this may cause malfunctions. Also, if a user with ownership rights
changes these variables, please perform synchronization immediately.

- `public bool value`: The value to synchronize.

#### `public void OnToggle()`

The callback when the value is changed.

#### `public void SetValue(bool value)`

Set the value to the toggle.

#### `protected override void UpdateView()`

The callback to update the view, e.g. on synchronized the value.

---

### `Observer` _abstract_ class / extends `UdonSharpBehaviour`

The class of the observer side in the publish-subscribe model.

#### `public abstract void OnNotify(Subject subject)`

Implement a callback when a call is received from the subject.

---

### `ObserverHub` class / extends `Observer`

The hub class of the observer side in the publish-subscribe model.

Use this ObserverHub when you have many Observers registered in a Subject
and it isn't easy to manage them. ObserverHub can be nested infinitely,
but be careful of circular references.

#### Inspector fields

- `Observer[] children`: The list of the children observers.

#### `public override void OnNotify(Subject subject)`

The callback is when a call is received from the subject.

---

### `PositionAnchor` class / extends `UdonSharpBehaviour`

The component maintains coordinate information when active and inactive and
switches coordinate information the moment the active state changes.

#### Inspector fields

- `Transform target`: The target transform is to be updated.
- `Transform transformOnActive`: The coordinate information when active.
- `Transform transformOnDeactive`: The coordinate information when inactive.

---

### `Subject` class / extends `UdonSharpBehaviour`

The class of the subject side in the publish-subscribe model.

#### Inspector fields

- `Observer[] observers`: The list of observers.

#### `public virtual string ClassName { get; }`

Gets the class name of the subject. The default value is `Subject`.
It can be overridden, so please use it as a hint for casting with observers.

#### `public virtual void Notify()`

Notify all observers.

---

### `SyncBehaviour` _abstract_ class / extends `UdonSharpBehaviour`

Abstract class with helper methods for synchronization.

You can extend this class to implement synchronization classes.

#### `public virtual void ChangeOwner()`

Change the object owner to the local player.

#### `public virtual void Sync()`

Starts the syncing.

#### `public virtual bool IsOwner()`

Determines if the local player is the owner.

True if the local player is the owner.

#### `protected abstract void UpdateView()`

Implement to update the view.

The OnDeserialization method cannot be called explicitly.
Therefore, instead, override this method to update the view.

---

### `TickingDown` class / extends `UdonSharpBehaviour`

The component updates the date and time to the `Text` or `TextMeshProUGUI`
uGUI component.

For this component to work correctly, please follow these steps:

1. place it on the same object as the `Text` or `TextMeshProUGUI` component
   or manually tie it.

#### `public void Tick()`

The callback to update the date and time.

This method is automatically called from within. _DO NOT CALL IT DIRECTLY_;
it'll duplicate the calling cycle and can result in overloading.

---

### `Whitelist` class / extends `UdonSharpBehaviour`

The allowlist to enable or disable the colliders and game objects.

If local users are included in the allowlist, this component toggles
between enabled and disabled states.

#### Inspector fields

- `string[] displayNames`: The display names of the allowlist.  
  It doesn't match the empty or null.
- `Collider[] colliders`: Specify the colliders to flip the enabled state.
- `GameObject[] objects`: Specify the game objects to flip the enabled state.

---

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
