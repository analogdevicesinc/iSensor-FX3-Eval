#Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
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

#Create FX3 Wrapper and load ADIS1650x regmap

Dut = Wrapper(topDir + '\\resources\\', topDir + '\\regmaps\\ADIS1650x_Regmap.csv',SensorType.StandardImu)

print(Dut.FX3.GetFirmwareVersion)
Dut.UserLEDBlink(2.0)

# Synchronizes register reads with Data Ready signal on given DIO pin
# Note that if Data Ready is not toggling, register read operations will hang
Dut.SetDrPin(1)
Dut.SetDrActive(True)

#Create reg list

regs_py = ['DIAG_STAT','DATA_CNTR','X_GYRO_OUT','Y_GYRO_OUT','Z_GYRO_OUT','X_ACCL_OUT','Y_ACCL_OUT','Z_ACCL_OUT']
regs = Array[String](regs_py)
data = []

N = 10

while True:
    # Read registers on N consecutive Data Ready pulses
    data = Dut.ReadSigned(regs, 1, N)
    for i in range(N):
        for j in range(len(regs_py)):
            print(f"{regs_py[j]}={data[j+i*len(regs_py)]}", end =" ") 
        print()
    print()
    sleep(0.5)




