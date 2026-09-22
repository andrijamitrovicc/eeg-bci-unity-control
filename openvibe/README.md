# OpenViBE BCI Pipeline

This folder contains the OpenViBE part of the EEG-based Brain-Computer Interface system used to control the Unity game in real time.

OpenViBE is responsible for EEG acquisition, CSP training, classifier training, online classification and sending the resulting control commands to Unity through Lab Streaming Layer (LSL).

## Pipeline

The BCI workflow is divided into four OpenViBE scenarios.

### 1. EEG Acquisition

File:

`scenarios/mi-csp-1-acquisition.xml`

This scenario is used to acquire and record EEG data for the motor imagery training process.

### 2. CSP Training

File:

`scenarios/mi-csp-2-train-CSP.xml`

This scenario trains a Common Spatial Pattern (CSP) spatial filter using the recorded EEG data.

The generated CSP configuration is stored in:

`config/csp-spatial-filter.cfg`

### 3. Classifier Training

File:

`scenarios/mi-csp-3-classifier-trainer.xml`

This scenario uses the extracted CSP features to train the classifier used to distinguish between motor imagery classes.

The trained classifier configuration is stored in:

`config/motor-imagery-bci-config-classifier.cfg`

### 4. Online Classification

File:

`scenarios/mi-csp-4-online.xml`

This scenario runs the trained BCI pipeline in real time.

The classification output is sent to the Unity application through Lab Streaming Layer (LSL).

The Unity application listens for the following LSL stream:

`NeuroDriveCommand`

## Data Flow

```text
EEG Signal
    ↓
OpenViBE Acquisition
    ↓
Signal Processing
    ↓
CSP Feature Extraction
    ↓
Classifier
    ↓
Online Classification
    ↓
LSL Stream
    ↓
NeuroDriveCommand
    ↓
Unity Game
```

## Additional Scripts

The `scripts` directory contains Lua scripts used by the OpenViBE scenarios:

- `motor-imagery-bci-epoch-selector.lua`
- `motor-imagery-bci-graz-stimulator.lua`

## Folder Structure

```text
openvibe/
├── scenarios/
│   ├── mi-csp-1-acquisition.xml
│   ├── mi-csp-2-train-CSP.xml
│   ├── mi-csp-3-classifier-trainer.xml
│   └── mi-csp-4-online.xml
│
├── config/
│   ├── csp-spatial-filter.cfg
│   └── motor-imagery-bci-config-classifier.cfg
│
├── scripts/
│   ├── motor-imagery-bci-epoch-selector.lua
│   └── motor-imagery-bci-graz-stimulator.lua
│
└── README.md
```

## Unity Integration

The online OpenViBE scenario generates the control output used by the Unity application.

The control commands are transmitted through LSL, and Unity receives them through the `NeuroDriveCommand` stream.

The Unity application then converts the received BCI commands into player movement inside the game.

## Technologies

- OpenViBE
- EEG
- Brain-Computer Interface
- Common Spatial Pattern (CSP)
- Motor Imagery
- Lab Streaming Layer (LSL)
- Unity
- C#
