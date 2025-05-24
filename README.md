<!-- markdownlint-disable MD024 -->

# ⚙️ UdonSharp Toybox by Kuroné Kito

![U# Toybox by Kuroné Kito](https://kurone-kito.github.io/udonsharp-toybox/docs/images/banner.png)

My utilities library for the UdonSharp / VRChat

## 💻 System Requirements

- [VRChat Creator Companion](https://vrchat.com/home/download)
- Unity 2022.3.22f1
- 🏝 Project of your world

## ▶ Getting Started

[See the documentation](https://kurone-kito.github.io/udonsharp-toybox/docs/)

## 💡 Features

- 📱 **Architecture free! (Windows, Android / Quest, iOS)**
- 🖱 UI parts with global sync
- 🫥 Object teleporter by turning the object on or off
- ⌛ Long-press interaction
- 🛎 Notify sound playing gimmick on player joined
- 🌈 Logger with vivid colors
- ⚙️ Other features...

## Contributing

Welcome to contribute to this repository! For more details,
please refer to [CONTRIBUTING.md](.github/CONTRIBUTING.md).

### 🛠 Using `git vrc` Filter

This project uses a custom git filter named `git vrc` to normalize Unity
files such as `.asset`, `.prefab`, and `.unity`. The filter removes
unstable data so diffs stay readable and merges remain smooth.

#### 1. Install the `git-vrc` package

```sh
cargo install --locked --git 'https://github.com/anatawa12/git-vrc.git'
git vrc install --config --global
```

#### 2. Make the `.gitconfig` file available for referencing from local `.git/config`

```sh
git config include.path '../.gitconfig'
```

The `.gitattributes` file in this repository already applies the filter to
Unity YAML files.

## License

This repository is licensed under the [MIT License](LICENSE).
