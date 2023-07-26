# Overview

The FX3ApiWrapper library presents the target application with a simplified subset of the FX3 API and interfacing libraries.

This library is intended to make using the FX3 API and adisInterface easier in non-dot-NET languages capable of consuming(wrapping) .NET DLLs. 

The FX3ApiWrapper library translates all the interfacing functions such that they only use numeric or string primitives instead of .NET class objects. This greatly simplifies the interface for the caller (LabVIEW, Python, etc.) and boosts wrapper compatibility.

## LabVIEW

The example project illustrates setting up and configuring an ADIS1650x IMU using a command message-based structure and includes examples for reading, writing, and streaming registers ([link](examples/LabVIEW)).

This example was tested and developed using LabVIEW 2015 running on Windows 10 using an EVAL-ADIS-FX3.

## Matlab

The example script connects to an FX3 board, blinks the user-addressable LED, and continuously reads accelerometer output registers from an ADIS1650x IMU ([link](examples/Matlab)).

This example was tested and developed using Matlab R2017B (64-bit) running on Windows 10 using an EVAL-ADIS-FX3.

## Python

The example script connects to an FX3 board, blinks the user-addressable LED, and continuously reads the primary output registers from an ADIS1650x IMU ([link](examples/Python)).

This example was tested using Python 3.7 (32-bit) running on Windows 10 using an EVAL-ADIS-FX3.

## Debugging

The underlying FX3 libraries can be debugged even while running in other platforms (Matlab, LabVIEW, Python, etc.) using the Visual Studio "Attach to Process" functionality. This feature allows for stepping through the .NET source code as it is invoked by the base (calling) language.