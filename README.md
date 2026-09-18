# EEG BCI Unity Control

A Unity game controlled through a Brain-Computer Interface (BCI) using EEG-based input and Lab Streaming Layer (LSL) communication.

The project combines **EEG signal processing, BCI classification, real-time data streaming and Unity game development** into a single interactive system.

## Overview

The main goal of this project was to create a Unity game that can be controlled using commands generated from EEG signals.

The system processes EEG-based input outside Unity and sends the resulting command through an **LSL stream**. Unity receives the stream in real time and converts the incoming values into player movement.

Keyboard controls are also available as an alternative input method, allowing the game to be tested without an active EEG/BCI connection.

## System Architecture

```text
EEG Signal
    |
    v
BCI Processing / Classification
    |
    v
Lab Streaming Layer (LSL)
    |
    v
Unity LSL Input
    |
    v
Player Movement
```

## BCI and EEG Integration

The BCI part of the project is responsible for processing EEG-based input and converting it into control commands.

The project involved:

- EEG-based input
- Brain-Computer Interface processing
- CSP-based classification experiments
- OpenViBE
- Real-time communication using Lab Streaming Layer
- Integration of BCI output with Unity

Unity listens for an LSL stream named:

```text
NeuroDriveCommand
```

The received values are interpreted as movement commands for the player.

## Unity Game

The Unity side of the project was developed as a complete playable game.

Main features include:

- Player movement
- Automatic forward movement
- Left and right movement
- Obstacles
- Collectibles
- Score system
- Win condition
- Bonus objects
- Pause functionality
- Game restart
- Keyboard input
- BCI / LSL input
- Runtime switching between input modes

The player is represented by a rolling ball and must move through the level while avoiding obstacles and collecting items.

## Controls

### Keyboard Mode

The game can be controlled normally using the keyboard.

Keyboard mode is useful for testing the game without connecting the BCI system.

### BCI / LSL Mode

The game can also receive movement commands from an external LSL stream.

The input mode can be switched during gameplay.

Additional controls:

- `P` - Pause / Resume
- `R` - Restart
- `L` - Switch between keyboard and LSL input

## Technologies

### Game Development

- Unity
- C#
- Unity Physics
- Unity UI

### BCI / EEG

- OpenViBE
- EEG
- Brain-Computer Interface
- Common Spatial Patterns (CSP)

### Communication

- Lab Streaming Layer (LSL)
- Real-time data streaming

## Repository Structure

```text
eeg-bci-unity-control/
|
├── Assets/
│   ├── Scripts/
│   ├── Scenes/
│   ├── Materials/
│   ├── Prefabs/
│   └── ...
│
├── Packages/
├── ProjectSettings/
├── .gitignore
└── README.md
```

Unity-generated files and folders are excluded from the repository.

These include:

```text
Library/
Temp/
Logs/
Obj/
UserSettings/
Build/
Builds/
```

## External Assets

The Unity project uses some third-party visual assets.

A large cartoon texture pack used for environment visuals is intentionally not included in this repository because of its file size and licensing considerations.

Because of this, some materials or textures may appear differently or be missing when the project is opened without the original asset package.

The source code, scenes, project configuration and original project logic are included in the repository.

## Running the Unity Project

1. Clone or download this repository.
2. Open Unity Hub.
3. Select **Add project from disk**.
4. Select the project folder.
5. Open the project using a compatible Unity version.
6. Allow Unity to regenerate the `Library` folder.
7. Open the main game scene.
8. Press **Play**.

The game can be tested using keyboard controls without the BCI system.

For BCI control, a compatible LSL stream must be running.

## BCI Input

For real-time BCI control, Unity expects an external LSL stream containing movement commands.

```text
Stream: NeuroDriveCommand
```

If no compatible stream is available, keyboard mode can be used instead.

## Project Goals

This project was created to explore how multiple technologies can be integrated into a single real-time system.

The project combines:

- Brain-computer interfaces
- EEG processing
- Machine learning concepts
- Real-time communication
- Game development
- External hardware/software integration

One of the main challenges was creating reliable communication between the external BCI system and Unity while keeping the game playable using standard controls.

## Future Improvements

Possible future improvements include:

- Improving EEG classification accuracy
- Adding more BCI commands
- Supporting additional player actions
- Improving LSL connection handling
- Adding automatic stream discovery and reconnection
- Improving game visuals
- Adding additional levels
- Recording BCI performance statistics

## Author

**Andrija Mitrović**

Computer Engineering student at  
**Računarski fakultet (RAF), Belgrade**

Interested in:

- Artificial Intelligence
- Brain-Computer Interfaces
- Automation
- Embedded Systems
- Software Development
- Hardware-Software Integration
