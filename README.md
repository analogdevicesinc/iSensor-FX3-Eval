# EVAL-ADIS-FX3 Evaluation Software

This repository contains all evaluation software for the EVAL-ADIS-FX3 iSensor evaluation board. The EVAL-ADIS-FX3 is the latest addition to the iSensor evaluation portfolio and was designed from the ground up to provide users with an easy-to-use solution for capturing reliable inertial data in lab and characterization environments. The EVAL-ADIS-FX3 incorporates the ability to capture inertial sensor data at maximum throughput while interfacing with external test equipment and reacting to external triggers.

See the [Quick Start Guide](/src/guide/guide.md) for an overview of eval software functionality, or download the latest [Release](https://github.com/analogdevicesinc/iSensor-FX3-Eval/releases/) installer.

In addition to the dedicated hardware platform, a .NET API and interop wrapper are provided which allow for simple development of custom applications. We’ve included many useful features into the API that enable designers to characterize sensor performance in any .NET compatible environment.

The API documentation for the iSensor FX3Api can be accessed here:

https://analogdevicesinc.github.io/iSensor-FX3-Eval/

The iSensor FX3 Evaluation GUI documentation and user guide has been moved to the official Analog Devices Wiki: 

https://wiki.analog.com/resources/eval/user-guides/inertial-mems/evaluation-systems/eval-adis-fx3

Analog Devices product page:

https://www.analog.com/en/resources/evaluation-hardware-and-software/evaluation-boards-kits/eval-adis-fx3.html

## Supporting Documentation

Hardware design files for the evaluation board are provided in the /hardware directory.

The custom windows driver installer is provided in the /drivers directory

Register map definition files for all supported iSensor products are provided in the /RegMaps directory

# iSensor FX3Api Wrapper [src_wrapper](/src_wrapper)

The wrapper library provides a simplified interface to configure and capture data from an ADI IMU. This interface can be used in the .NET ecosystem, or with languages which support .NET interop, such as Python, Matlab, and Labview.

# iSensor FX3 Evaluation GUI [src](/src)

Source code for the iSensor-FX3-Eval IMU evaluation GUI. This is a Winforms application, built on the iSensor-FX3-API. Developed for minumum .NET framework 4.5

## iSensor FX3 Eval GUI - Developer Setup Guide

The iSensor FX3 Eval GUI can be easily compiled and modified without purchasing any software or IDE.

### Prerequisites

Before attempting to compile the iSensor FX3 Eval GUI, ensure that the FX3 Driver is installed. This can be downloaded from the wiki (linked above)

The iSensor FX3 Eval GUI is currently Windows only. It requires Microsoft .NET framework 4.5 or newer to be installed.

### Development Environment

The iSensor FX3 Eval GUI can be compiled and modified using the Visual Studio IDE. Visual studio community is fully featured and available for free use on open source projects

https://visualstudio.microsoft.com/vs/community/

License: https://visualstudio.microsoft.com/license-terms/mlt031819/

### Building

1. Clone the iSensor FX3 Eval repository using the git client of your choice. Note, this repo has the iSensor FX3 API as a submodule dependency, which must be initialized as well. This can be done from Git bash using the following single command:
   - git clone --recurse-submodules https://github.com/analogdevicesinc/iSensor-FX3-Eval.git
2. Open the project file within Visual Studio. File -> Open -> Project/Solution -> Browse for iSensorFX3Eval.vbproj within the src/ folder of the repository
3. Build the project by right clicking on the iSensorFX3Eval project within the visual studio solution explorer and clicking "Build"

That's it! Now you can run and debug within the iSensor FX3 GUI. To make modifications to any forms included within the GUI, simply right click on the form in the solution explorer, and select "View Designer". This will open the GUI designer tool for that form. The startup form is set to "TopGUI.vb"