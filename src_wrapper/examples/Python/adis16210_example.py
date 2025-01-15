#Copyright (c) 2025 Analog Devices, Inc. All Rights Reserved.
#This software is proprietary to Analog Devices, Inc. and its licensors.
#
#Author: Alex Nolan

#requires pythonnet to be installed (pip install pythonnet)

import clr
from time import sleep
import os

#get path to resources folder and dll
topDir = os.path.join(os.getcwd(), '..\..\..')

#Load FX3 API Wrapper DLL
clr.AddReference(topDir + '\\resources\\FX3ApiWrapper.dll')

#Allows wrapper to be treated like standard python library
from FX3ApiWrapper import *
from System import Array
from System import String

#Create FX3 Wrapper and load ADIS16210 regmap

Dut = Wrapper(topDir + '\\resources\\', topDir + '\\regmaps\\ADIS16210_RegMap.csv',SensorType.StandardImu)
#Set SPI parameters per datasheet (830KHz sclk, 40us stall)
print("Configuring SPI settings")
Dut.SetSpiStallTime(40)
Dut.SetSCLKFreq(830000)

print("DUT reset")
Dut.ResetDut()

print(Dut.FX3.GetFirmwareVersion)
print("PROD_ID: " + str(Dut.ReadUnsigned("PROD_ID")))
Dut.UserLEDBlink(2.0)

#61ug per LSB
accel_scale = 61.0 / 10**6

#Create reg list
regs_py = ['XACCL_OUT','YACCL_OUT','ZACCL_OUT','TEMP_OUT']
regs = Array[String](regs_py)
data = []

while True:
    data = Dut.ReadSigned(regs)
    temp_c = (data[3] - 1331.0) * -0.47 #Zero C at 1331, -0.47C/LSB
    print("XA: " + str(data[0] * accel_scale) + " YA: " + str(data[1] * accel_scale) + " ZA: " + str(data[2] * accel_scale) + " TEMP: " + str(temp_c))
    sleep(0.5)



