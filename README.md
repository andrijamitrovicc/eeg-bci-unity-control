# EEG BCI Unity Control

A brain-computer interface project that connects EEG-based input with a Unity game for real-time player control.

The project combines EEG signal processing, machine learning, real-time communication and game development.

## Project Overview

The goal of the project is to control a Unity game using commands generated from EEG signals.

The system consists of:

- EEG signal acquisition and processing
- Brain-computer interface classification
- Real-time communication using Lab Streaming Layer (LSL)
- Unity game receiving and processing external commands
- Keyboard control as an alternative input method

## System Architecture

```text
EEG Signal
    ↓
Signal Processing / Classification
    ↓
LSL Stream
    ↓
Unity
    ↓
Player Control
