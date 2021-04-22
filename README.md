# iSensor FX3 Evaluation GUI

## Overview

The EVAL-ADIS-FX3 is the latest addition to the iSensor evaluation portfolio and was designed from the ground up to provide users with an easy-to-use solution for capturing reliable inertial data in lab and characterization environments. The EVAL-ADIS-FX3 incorporates the ability to capture inertial sensor data at maximum throughput while interfacing with external test equipment and reacting to external triggers.

In addition to launching a redesigned hardware platform, we’ve also developed a robust API that allows users to quickly build custom applications that capture reliable sensor data. We’ve included many useful features into the API that enable designers to characterize sensor performance in any .NET compatible environment.

## The iSensor FX3 Evaluation GUI documentation has been moved to the official Analog Devices Wiki: https://wiki.analog.com/resources/eval/user-guides/inertial-mems/evaluation-systems/eval-adis-fx3



# Building the iSensor FX3 Eval GUI

The iSensor FX3 Eval GUI can be easily compiled and modified without purchasing any software or IDE.

## Prerequisites

Before attempting to compile the iSensor FX3 Eval GUI, ensure that the FX3 Driver is installed. This can be downloaded from the wiki (linked above)

The iSensor FX3 Eval GUI is currently Windows only. It requires Microsoft .NET framework 4.5 or newer to be installed.

## Development Environment

The iSensor FX3 Eval GUI can be compiled and modified using the Visual Studio IDE. Visual studio community is fully featured and available for free use on open source projects

https://visualstudio.microsoft.com/vs/community/

License: https://visualstudio.microsoft.com/license-terms/mlt031819/

## Building

1. Clone the iSensor FX3 Eval repository using the git client of your choice
   - git clone https://github.com/analogdevicesinc/iSensor-FX3-Eval.git
2. Open the project file within Visual Studio. File -> Open -> Project/Solution -> Browse for iSensorFX3Eval.vbproj within the src/ folder of the repository
3. Build the project by right clicking on the iSensorFX3Eval project within the visual studio solution explorer and clicking "Build"

That's it! Now you can run and debug within the iSensor FX3 GUI. To make modifications to any forms included within the GUI, simply right click on the form in the solution explorer, and select "View Designer". This will open the GUI designer tool for that form. The startup form is set to "TopGUI.vb"