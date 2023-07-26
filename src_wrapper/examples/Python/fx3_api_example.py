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
Dut = Wrapper(topDir + '\\resources\\', topDir + '\\src_wrapper\\regmaps\\ADIS1650x_Regmap.csv',0)

print(Dut.FX3.GetFirmwareVersion)
Dut.UserLEDBlink(2.0)

#Create reg list

regs_py = ['DIAG_STAT','DATA_CNTR','X_GYRO_OUT','Y_GYRO_OUT','Z_GYRO_OUT','X_ACCL_OUT','Y_ACCL_OUT','Z_ACCL_OUT']
regs = Array[String](regs_py)
data = []

while True:
    data = Dut.ReadSigned(regs)
    for i in (data): 
        print(i, end =" ") 
    print()
    sleep(0.5)



