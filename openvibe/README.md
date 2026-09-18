## OpenViBE Pipeline

OpenViBE was used as the real-time BCI processing environment.

The pipeline handles EEG input, signal processing and classification before sending the resulting control command to Unity through Lab Streaming Layer (LSL).

The Unity application listens for the LSL stream:

```text
NeuroDriveCommand
