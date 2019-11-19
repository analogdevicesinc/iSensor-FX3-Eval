# iSensor FX3 Example GUI (ADcmXL/IMU)

## Overview

The iSensor FX3 firmware and API provide you with a means of acquiring sensor data over a high-speed USB connection in any application that supports .NET libraries. This application shows how to implement both the firmware and the interface in a VB.NET environment. This application was designed around the FX3 SuperSpeed Explorer Kit and relied on the open-source libraries provided by Cypress to operate. 

Using both the FX3 firmware and the FX3API libraries enables you to acquire sensor data quickly while this application gives you a starting point from which to build your custom solution. 

## Hardware Requirements

The firmware is designed to be built and run on a Cypress SuperSpeed Explorer Kit (CYUSB3KIT-003). A breakout board designed to convert the Explorer Kit's pins to a standard, 16-pin, 2mm connector used on most iSensor evaluation platforms should be available for purchase soon. A schematic showing how to connect iSensor products to the Explorer Kit is located in the Documentation folder of the iSensor FX3 firmware repository [here](https://github.com/juchong/iSensor-FX3-Firmware/tree/master/Documentation). 

The Explorer Kit requires two jumpers to be installed for the library to communicate. The image below shows where the jumpers must be installed before connecting via the USB port. The other two jumpers must be left open.

 ![FX3 Jumper Locations](https://raw.githubusercontent.com/juchong/iSensor-FX3-Firmware/master/hardware/pictures/JumperLocations.jpg)

## Getting Started

Ensure that you have the [Analog Devices FX3 driver](https://github.com/juchong/iSensor-FX3-API/raw/master/drivers/FX3DriverSetup.exe) installed.

Ensure that you've plugged the FX3 board into a USB 2.0 or better port on your PC and that the FX3 jumpers are correctly installed, as described in the Hardware Requirements section above. 

Open the FX3 GUI and wait for a new "Analog Devices iSensor FX3 Bootloader" device to be detected by Windows. If this is the first time you've connected the Explorer Kit evaluation board to the PC, there may be a small delay the custom bootloader is flashed onto the onboard EEPROM. 

## Connecting to an FX3

The iSensor FX3 Demonstration Platform supports connecting to multiple FX3 boards concurrently. If multiple boards are detected, the application asks which board should be connected. 

When you first load the Example GUI and click the "Connect" button, a window listing the unique ID of each FX3 board should appear. Selecting a serial number causes the corresponding board's onboard LED to blink rapidly. If there is only a single FX3 board connected to your PC, that board is selected by default.

![FX3 Board Select](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/board_select.JPG)

After the desired FX3 board is selected, the iSensor FX3 Demonstration Platform application loads the application firmware into the FX3 RAM. Clicking the "Connect to FX3" button in the main GUI attempts to push the firmware into the FX3 board. If successful, it also communicates with the FX3 hardware and the connected ADI sensor to verify that everything was correctly initialized. Communication with the ADI sensor is checked by writing a random value to one of the user scratch registers and attempting to read it back. If successful, all buttons in the GUI are enabled, allowing you to exercise additional features built into the interface and firmware. 

![FX3Gui Successfully Connected](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/main_window.JPG)

## FX3 and SPI Configuration

The FX3 offers the flexibility to configure SPI and other board parameters on-the-fly. We've implemented a simple GUI to make adjustments to the SPI configuration easy. The SPI configuration window includes many settings specific to the FX3, so please refer to the firmware library documentation for additional details. By default, the FX3 is configured with settings that should work with the selected device type (ADcmXL or IMU).

![FX3Gui SPI Configuration Window](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/spi_configuration.JPG)

## DUT Selection

The FX3 firmware and Example GUI are designed to communicate with different ADI sensor families. Clicking the "Select DUT Type" button allows you to switch between different device families, unlocking features unique to each.  This setting is persistent throughout the Example GUI application. 

![DUT Selection](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/select_dut.JPG)

## Register Access

The register access window allows you to read and write registers as you would in any embedded application. The register locations, default values, and properties are loaded from the register map file selected when the program loads.

![FX3Gui Register Access Window](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/register_access.JPG)

## IMU Register Logging

The IMU Register Logging form allows you to capture individual registers and stream the data to the PC. This form changes based upon the sensor family and DUT type selected in the "DUT Selection" form, and this version of the form will only be visible when "IMU" is selected. 

This version of the form captures data with or without synchronizing to data ready pulses and makes it easy to read multiple registers at once. 

![ADcmXL Stream Manager Window](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/register_logging.JPG)

## ADcmXL (Burst) Real-Time Streaming

The FX3 Example GUI provides a means of streaming register data to the PC and recording it in .csv format. This form changes based upon the sensor family and DUT type selected in the "DUT Selection" form. 

The ADcmXL version of the form allows you to stream real-time data from the ADcmXL series of parts. This form supports external triggering (such as when connected to a shaker table), or timer-based triggering. 

![ADcmXL Stream Manager Window](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/adcmxl_capture.JPG)

## IMU Burst Streaming

The FX3 Example GUI provides a form to stream burst data from IMU products using IMU burst mode. As with other data capture forms, all data is logged to a .csv file. 

![IMU Stream Manager Window](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/imu_burst.JPG)

## Data Plotting

The FX3 Example GUI provides a form to stream individual registers from a sensor and plot it in near real-time. Plot data can be logged to a CSV file and played back at any time.

![Data Plotting](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/data_plot.JPG)

## FFT Data Plotting

The FX3 Example GUI provides a form to stream data from a DUT and plot the spectral results in near real-time. The plot scale, FFT size, and FFT averages can be adjusted using the form controls. Clicking on the plot window places a data marker on the plot for easy review. Plot data can be logged to a CSV file.

![Data Plotting](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/fft_plot_gui.JPG)

# PWM Setup and Pin Access

The FX3 Example GUI provides a form to read or set pin values on the FX3 Explorer board. 

![Pin Access](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/pin_access.JPG)

The FX3 is also capable of generating a PWM signal onto any of the output pins. The PWM setup GUI allows you to configure the PWM frequency and duty cycle as needed for each pin.

![PWM Setup](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/pwm_setup.JPG)

# FX3 API Information

The FX3 Example GUI allows you to load information about the current version of the FX3 API being used. This includes a link to the source code commit on GitHub.

![API Info](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/fx3_api_info.JPG)

The FX3 Example GUI allows you to load information about the currently connected FX3 board.

![Board Info](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/board_info.JPG)

# FX3-Related Utilities

Additional functions such as resetting the FX3, resetting the DUT (using the hardware reset pin), reading a pin value, reading the FX3 firmware ID, and checking the DUT connection are all available for use in your application. 

# Troubleshooting

## Issues installing FX3 Driver

If you encounter issues installing the FX3 driver, try running the installer with Administrator privileges.

## Issues with connecting to FX3

If you're having issues connecting to the FX3 initially (first-time setup), the best place to start is by checking whether the Analog Devices FX3 bootloader was correctly loaded into the onboard EEPROM. The Cypress SuperSpeed Explorer Kit ships with a default EEPROM image, which does not include bootloader capabilities. The easiest way to check this is by looking for a device named "Analog Devices FX3 Bootloader" in the Windows Device Manager. 

![Board Info](https://raw.githubusercontent.com/juchong/iSensor-FX3-ExampleGui/master/Documentation/device_manager.JPG)

If you're unable to find the device, try the following in order:

1. Install a jumper on the J4 connector to disable the FX3's flash boot function.
2. Open the FX3 Example GUI and wait approximately 5 seconds for the bootloader to load onto flash memory. You should hear your PC disconnect and reconnect an external device several times. 
3. Remove the jumper on J4.
4. Reset the FX3 by either unplugging the USB cable or by pressing the reset button on the FX3 Explorer board. 

The bootloader should now be flashed into flash memory.

## Issues with communicating with the FX3 during long operations

Certain FX3 API functions can take a very long time to execute. Depending on how the function was called, it may even be possible to force the FX3 to become unresponsive. 

If the board becomes unresponsive, pressing the reset button on the FX3 or unplugging/plugging the USB cable should return the FX3 into bootloader mode. 

## Additional Repositories

Two additional repositories are required for this example to operate. The FX3 API, where all FX3-related functions are implemented, and the FX3 firmware are both essential for managing the USB -> SPI bridge the FX3 offers and should serve as a good starting point for your application.

1. [FX3 Firmware](https://github.com/juchong/iSensor-FX3-Firmware)

2. [FX3API](https://github.com/juchong/iSensor-FX3-API)
