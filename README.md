# iSensor FX3 Evaluation GUI

## Overview

The EVAL-ADIS-FX3 is the latest addition to the iSensor evaluation portfolio and was designed from the ground up to provide users with an easy-to-use solution for capturing reliable inertial data in lab and characterization environments. The EVAL-ADIS-FX3 incorporates the ability to capture inertial sensor data at maximum throughput while interfacing with external test equipment and reacting to external triggers.

In addition to launching a redesigned hardware platform, we’ve also developed a robust API that allows users to quickly build custom applications that capture reliable sensor data. We’ve included many useful features into the API that enable designers to characterize sensor performance in any .NET compatible environment.

## Getting Started

### The iSensor FX3 Evaluation GUI documentation has been moved to the official Analog Devices Wiki: https://wiki.analog.com/resources/eval/user-guides/inertial-mems/evaluation-systems/eval-adis-fx3

## EVAL-ADIS-FX3

The EVAL-ADIS-FX3 hardware includes many improvements learned from the previous generations of evaluation systems and is designed to be small, flexible, and reliable. Some of the board’s features include:

 * A dedicated, onboard 3.3V, 2A linear regulator designed for high-transient applications
 * A USB-C connector (USB 2.0 compatible only)
 * An onboard, field-upgradable EEPROM with USB bootloader fallback
 * A software-selectable OFF / 3.3V / 5V IMU supply output with overcurrent and short protection
 * A JST-XH-2 external supply connector
 * Selectable USB and external supply selection
 * Onboard status LEDs for each IMU GPIO pin
 * An iSensor standard, 16-pin, 2mm connector for compatibility with existing iSensor breakout boards and adapters
 * An additional 10-pin, 2mm connector for feature expansion. As of writing, the firmware and API include support for:
 * FX3 UART debugging
 * Four additional GPIO pins for external test equipment triggering and sensing (separate from the IMU GPIOs)
 * Separate 3.3V and 5V supplies from the DUT supply meant to power external level shifters, drivers, interface ICs, etc.
 * An extra, “bit-banged” SPI port to allow for “non-standard” SPI configurations and communication with external hardware (ADCs, DACs, protocol interface ICs, etc.)
 * An I2C port meant for interfacing with I2C-compatible inertial sensors
 * Concurrent, multi-board data capture capability. Multiple EVAL-ADIS-FX3 boards can be connected to the same PC and can concurrently capture data independently of each other
 * Very low CPU usage while capturing data, even on older Windows machines
 * Windows 7, 8, and 10 compatibility
 * 1.5" x 1.75" PCB footprint

![iSensor FX3 Evaluation Board](https://wiki.analog.com/_media/resources/eval/user-guides/inertial-mems/evaluation-systems/fx3/43893_50034.jpg)

Design files for the breakout board is available in the [hardware](https://github.com/juchong/iSensor-FX3-Firmware/tree/master/hardware) folder of this repository. 

## Legacy Hardware: SuperSpeed Explorer Kit Breakout Board

A breakout board designed for interfacing iSensor devices with the Cypress SuperSpeed Explorer Kit (CYUSB3KIT-003) was introduced as a temporary solution while a more feature-rich offering was developed.  Both boards will continue to be supported in future firmware revisions. 

![CYUSB3KIT-003 and Breakout Board](https://raw.githubusercontent.com/juchong/iSensor-FX3-Firmware/master//hardware/pictures/img2.jpg)

Design files for both breakout boards are available in the [hardware](https://github.com/juchong/iSensor-FX3-Firmware/tree/master/hardware) folder of this repository. 

## SuperSpeed Explorer Kit Jumper Configuration

The Explorer Kit requires **three** jumpers to be installed to operate correctly as shown in the image below. **Jumpers J2, J3, and J5 must be installed** when using the SuperSpeed Explorer Kit. **Jumper J4 must be open** to allow booting from the onboard EEPROM. 

 ![FX3 Jumper Locations](https://raw.githubusercontent.com/juchong/iSensor-FX3-Firmware/master//hardware/pictures/JumperLocations.jpg)

## Additional Repositories

Two additional repositories are required for this example to operate. The FX3 API, where all FX3-related functions are implemented, and the FX3 firmware are both essential for managing the USB -> SPI bridge the FX3 offers and should serve as a good starting point for your application.

1. [FX3 Firmware](https://github.com/juchong/iSensor-FX3-Firmware)

2. [FX3API](https://github.com/juchong/iSensor-FX3-API)
