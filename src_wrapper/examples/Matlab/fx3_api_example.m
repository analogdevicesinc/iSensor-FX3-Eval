%Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
%This software is proprietary to Analog Devices, Inc. and its licensors.
%
%Authors: Alex Nolan, Juan Chong

clear

%Watch for user inputs to exit code execution
H = uicontrol('Style', 'PushButton', ...
                    'String', 'Break', ...
                    'Callback', 'delete(gcbf)');
                

%How many levels up is root dir of repo?
root_dir = '../../../../';

%Get paths
wrapperPath = fullfile(strcat(pwd, root_dir, 'resources/FX3ApiWrapper.dll'));
regMapPath = fullfile(strcat(pwd, root_dir, 'regmaps/ADIS1650x_Regmap.csv'));
resourcePath = fullfile(strcat(pwd, root_dir, 'resources/'));

%Load wrapper DLL
NET.addAssembly(wrapperPath);
%Check if the FX3 object is already instantiated (and connected)
if(exist('Dut','var') ~= 1)
    %Create FX3 wrapper, with ADIS1650x regmap
    Dut = FX3ApiWrapper.Wrapper(resourcePath,regMapPath,FX3ApiWrapper.SensorType.StandardImu);
end

%Blink user LED at 5Hz
Dut.UserLEDBlink(5.0);

%print product ID
fprintf('Product ID 0x%x',uint32(Dut.ReadUnsigned('PROD_ID')));

%enable dr active
Dut.SetDrActive(true);

%Create reglist
regs = NET.createArray('System.String',3);
regs(1) = 'X_ACCL_OUT';
regs(2) = 'Y_ACCL_OUT';
regs(3) = 'Z_ACCL_OUT';

%Enable pausing
pause on
%sample freq
Fs = 2000;
%sample period
T = 1/Fs;
% NFFT
L = 4096;
%fft frequency vector
f = Fs*(0:(L/2 - 1))/L;

%array to hold raw DUT data
rawData = [];

%data for each accel axis
x = zeros(1,L);
y = zeros(1,L);
z = zeros(1,L);

x_fft = [];
y_fft = [];
z_fft = [];

%index in raw data
i = 1;

while(ishandle(H))
    rawData = int32(Dut.ReadSigned(regs, 1, L));
    i = 1;
    for n = 1:3:length(rawData)
        x(i) = rawData(n);
        y(i) = rawData(n + 1);
        z(i) = rawData(n + 2);
        i = i + 1;
    end
    
    %calc FFT
    x_fft = fft(x);
    y_fft = fft(y);
    z_fft = fft(z);
    
    %remove back half
    x_fft = x_fft(1:(L/2));
    y_fft = y_fft(1:(L/2));
    z_fft = z_fft(1:(L/2));
    
    %Scale to magnitude
    x_fft = abs(x_fft);
    y_fft = abs(y_fft);
    z_fft = abs(z_fft);
    
    %divide by fft length
    x_fft = x_fft / L;
    y_fft = y_fft / L;
    z_fft = z_fft / L;
    
    loglog(f, x_fft);
    hold on;
    loglog(f, y_fft);
    loglog(f, z_fft);
    hold off;
    
    xlabel('Frequency (in hertz)');
    title('ADIS1650x XL FFT');
    pause(0.1)
end

%Turn off user LED
Dut.UserLEDOff;

%Clean up FX3
Dut.Disconnect;