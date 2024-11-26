%Copyright (c) 2024 Analog Devices, Inc. All Rights Reserved.
%This software is proprietary to Analog Devices, Inc. and its licensors.
%
%Authors: Alex Nolan

clear;

%How many levels up is root dir of repo?
root_dir = '../../../../';

%Get path to wrapper DLL, ADIS1657x register definition, and FX3 firmware
wrapperPath = fullfile(strcat(pwd, root_dir, 'resources/FX3ApiWrapper.dll'));
regMapPath = fullfile(strcat(pwd, root_dir, 'regmaps/ADIS1657x_Regmap.csv'));
resourcePath = fullfile(strcat(pwd, root_dir, 'resources/'));

%Load wrapper DLL
NET.addAssembly(wrapperPath);
%Check if the FX3 object is already instantiated (and connected)
if(exist('Dut','var') ~= 1)
    %Create FX3 wrapper, with provided regmap
    Dut = FX3ApiWrapper.Wrapper(resourcePath,regMapPath,FX3ApiWrapper.SensorType.StandardImu);
end

%disable data ready sample triggering during config
Dut.SetDrActive(false);

%configure for 10MHz SPI clock, 5us stall
Dut.SetSCLKFreq(10000000);
Dut.SetSpiStallTime(5);

%reset DUT
Dut.ResetDut();
pause(0.5);

%print product ID
fprintf('Product ID: ADIS%d\n',uint32(Dut.ReadUnsigned('PROD_ID')));
%Disable decimation filter
Dut.WriteUnsigned('DEC_RATE', 0);

%Internal sync, 2KHz, 32-bit TS
Dut.WriteUnsigned('MSC_CTRL', 0x0401);
pause(0.1);
plotTitle = sprintf('Internal Sync, 2KHz. MSC_CTRL: 0x%x\n', uint16(Dut.ReadUnsigned('MSC_CTRL')));
disp(plotTitle);
fprintf('Sample Rate: %fHz\n', Dut.MeasurePinFreq(1)); %DR on DIO1
PlotDUTData(Dut, plotTitle, 2);

%Internal sync, 4KHz, 32-bit TS
Dut.WriteUnsigned('MSC_CTRL', 0x0C01);
pause(0.1);
plotTitle = sprintf('Internal Sync, 4KHz. MSC_CTRL: 0x%x\n', uint16(Dut.ReadUnsigned('MSC_CTRL')));
disp(plotTitle);
fprintf('Sample Rate: %fHz\n', Dut.MeasurePinFreq(1)); %DR on DIO1
PlotDUTData(Dut, plotTitle, 2);

%External sync, programmable freq
ext_sync_freq_hz = 4500;
%Apply sync clock to IMU DIO2
Dut.StartPWM(ext_sync_freq_hz, 0.5, 2);
Dut.WriteUnsigned('MSC_CTRL', 0x0405);
pause(0.1);
plotTitle = sprintf('External Sync, %dHz. MSC_CTRL: 0x%x\n', ext_sync_freq_hz, uint16(Dut.ReadUnsigned('MSC_CTRL')));
disp(plotTitle);
fprintf('Sample Rate: %fHz\n', Dut.MeasurePinFreq(1)); %DR on DIO1
PlotDUTData(Dut, plotTitle, 2);

%Scaled sync, programmable freq
scaled_sync_freq_hz = 3500;
sync_freq_hz = 1;
%Apply low freq sync clock to IMU DIO2
Dut.StartPWM(sync_freq_hz, 0.5, 2);
%Find UPSCALE value which gives us the target scaled sync sample clock
upscale = scaled_sync_freq_hz / sync_freq_hz;
Dut.WriteUnsigned('UP_SCALE', upscale);
%Enable scaled sync mode
Dut.WriteUnsigned('MSC_CTRL', 0x0409);
pause(0.1);
plotTitle = sprintf('Scaled Sync, %dHz. MSC_CTRL: 0x%x\n', scaled_sync_freq_hz, uint16(Dut.ReadUnsigned('MSC_CTRL')));
disp(plotTitle);
fprintf('Sample Rate: %fHz\n', Dut.MeasurePinFreq(1)); %DR on DIO1
PlotDUTData(Dut, plotTitle, 2);

%Turn off user LED
Dut.UserLEDOff;

%Clean up FX3
Dut.Disconnect;

function PlotDUTData(Dut, plot_title, plot_time_sec)
    %Create reglist
    regs = NET.createArray('System.String',9);
    regs(1) = 'DIAG_STAT';
    regs(2) = 'TIME_STAMP_LWR';
    regs(3) = 'DATA_CNTR';
    regs(4) = 'X_GYRO_UPR';
    regs(5) = 'Y_GYRO_UPR';
    regs(6) = 'Z_GYRO_UPR';
    regs(7) = 'X_ACCL_UPR';
    regs(8) = 'Y_ACCL_UPR';
    regs(9) = 'Z_ACCL_UPR';
    %Get fs from data ready
    fs = Dut.MeasurePinFreq(1);
    num_samples = uint32(plot_time_sec * fs);
    %Capture data for plot_time_sec seconds
    Dut.SetDrActive(true);
    rawData = int32(Dut.ReadSigned(regs, 1, num_samples));
    Dut.SetDrActive(false);
    %Extract channel values
    names = string(regs);
    dataSorted = zeros(num_samples, length(names), 'int32');
    sample = 1;
    for i = 1:length(names):length(rawData)
        for j = 1:1:length(names)
            dataSorted(sample, j) = rawData(i + j - 1);
        end
        sample = sample + 1;
    end
    %Convert to timetable for plotting
    dataTable = table2timetable(array2table(dataSorted, 'VariableNames', names), 'SampleRate', fs);
    %Plot data
    figure;
    sgtitle(plot_title, 'Interpreter', 'none');
    subplot(4, 1, 1);
    hold on;
    yyaxis right;
    plot(dataTable.Time, dataTable.TIME_STAMP_LWR, 'DisplayName', 'TIME_STAMP_LWR');
    yyaxis left;
    plot(dataTable.Time, dataTable.DATA_CNTR, 'DisplayName', 'DATA_CNTR');
    hold off;
    xlabel('Time (s)');
    ylabel('LSBs');
    legend('Interpreter', 'none')
    % DIAG_STS plot
    subplot(4, 1, 2);
    hold on;
    plot(dataTable.Time, dataTable.DIAG_STAT, 'DisplayName', 'DIAG_STAT');
    hold off;
    xlabel('Time (s)');
    ylabel('LSBs');
    legend('Interpreter', 'none')
    % accel plot
    subplot(4, 1, 3);
    hold on;
    plot(dataTable.Time, dataTable.X_ACCL_UPR, 'DisplayName', 'X_ACCL_UPR');
    plot(dataTable.Time, dataTable.Y_ACCL_UPR, 'DisplayName', 'Y_ACCL_UPR');
    plot(dataTable.Time, dataTable.Z_ACCL_UPR, 'DisplayName', 'Z_ACCL_UPR');
    hold off;
    xlabel('Time (s)');
    ylabel('LSBs');
    legend('Interpreter', 'none')
    %gyro plot
    subplot(4, 1, 4);
    hold on;
    plot(dataTable.Time, dataTable.X_GYRO_UPR, 'DisplayName', 'X_GYRO_UPR');
    plot(dataTable.Time, dataTable.Y_GYRO_UPR, 'DisplayName', 'Y_GYRO_UPR');
    plot(dataTable.Time, dataTable.Z_GYRO_UPR, 'DisplayName', 'Z_GYRO_UPR');
    hold off;
    xlabel('Time (s)');
    ylabel('LSBs');
    legend('Interpreter', 'none')
end