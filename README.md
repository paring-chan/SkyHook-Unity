# SkyHook-Unity

SkyHook for Unity.

## Installation

1. Open package manager with `Window -> Package Manager`.
2. Click `+` button and find `Add package from git URL...`.
![Add package from git URL](images/tuto1.png)
3. Paste `git+https://git.pikokr.dev/SkyHook/SkyHook-Unity.git` and click `Add` button.

## Usage

### Starting and stopping the hook

```cs
SkyHookManager.StartHook(); // Starts the hook

SkyHookManager.StopHook(); // Stops the hook, this is automatically called on exit
```

### Receiving key events

> NOTE:
> - `Label` field for labelling keys' names such as F11
> - `Key` field is the raw key code from native module.

```cs
SkyHookManager.KeyUpdated.AddListener(ev => {
    // Your code
});
```
