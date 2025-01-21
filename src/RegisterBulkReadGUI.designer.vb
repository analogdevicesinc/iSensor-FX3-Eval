<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegisterBulkReadGUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AddRegisterButton = New System.Windows.Forms.Button()
        Me.RemoveRegisterButton = New System.Windows.Forms.Button()
        Me.selectedRegview = New System.Windows.Forms.ListView()
        Me.MainButton = New System.Windows.Forms.Button()
        Me.RegisterList = New System.Windows.Forms.ComboBox()
        Me.ClearAllButton = New System.Windows.Forms.Button()
        Me.StreamingAVARCancelButton = New System.Windows.Forms.Button()
        Me.NumberDRToCapture = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MeasureDR = New System.Windows.Forms.Button()
        Me.DrFreq = New System.Windows.Forms.Label()
        Me.DRDIO = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CaptureProgressStreaming = New System.Windows.Forms.ProgressBar()
        Me.DrActiveBox = New System.Windows.Forms.CheckBox()
        Me.linesPerFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.regStreamingList = New System.Windows.Forms.Label()
        Me.btn_saveregs = New System.Windows.Forms.Button()
        Me.btn_loadregs = New System.Windows.Forms.Button()
        Me.ValidateDR = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fileBaseName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.text_recTime = New System.Windows.Forms.TextBox()
        Me.check_ScaleData = New System.Windows.Forms.CheckBox()
        Me.check_LogTimestamps = New System.Windows.Forms.CheckBox()
        Me.group_SampleConfig = New System.Windows.Forms.GroupBox()
        Me.group_LogConfig = New System.Windows.Forms.GroupBox()
        Me.group_SampleConfig.SuspendLayout()
        Me.group_LogConfig.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Registers"
        '
        'AddRegisterButton
        '
        Me.AddRegisterButton.Location = New System.Drawing.Point(11, 59)
        Me.AddRegisterButton.Name = "AddRegisterButton"
        Me.AddRegisterButton.Size = New System.Drawing.Size(85, 40)
        Me.AddRegisterButton.TabIndex = 1
        Me.AddRegisterButton.Text = "Add Register"
        Me.AddRegisterButton.UseVisualStyleBackColor = True
        '
        'RemoveRegisterButton
        '
        Me.RemoveRegisterButton.Location = New System.Drawing.Point(107, 59)
        Me.RemoveRegisterButton.Name = "RemoveRegisterButton"
        Me.RemoveRegisterButton.Size = New System.Drawing.Size(85, 40)
        Me.RemoveRegisterButton.TabIndex = 2
        Me.RemoveRegisterButton.Text = "Remove Register"
        Me.RemoveRegisterButton.UseVisualStyleBackColor = True
        '
        'selectedRegview
        '
        Me.selectedRegview.Location = New System.Drawing.Point(201, 32)
        Me.selectedRegview.Name = "selectedRegview"
        Me.selectedRegview.Size = New System.Drawing.Size(235, 520)
        Me.selectedRegview.TabIndex = 99
        Me.selectedRegview.UseCompatibleStateImageBehavior = False
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(11, 559)
        Me.MainButton.Name = "MainButton"
        Me.MainButton.Size = New System.Drawing.Size(85, 40)
        Me.MainButton.TabIndex = 12
        Me.MainButton.Text = "Start Capture"
        Me.MainButton.UseVisualStyleBackColor = True
        '
        'RegisterList
        '
        Me.RegisterList.FormattingEnabled = True
        Me.RegisterList.Location = New System.Drawing.Point(11, 32)
        Me.RegisterList.Name = "RegisterList"
        Me.RegisterList.Size = New System.Drawing.Size(181, 21)
        Me.RegisterList.TabIndex = 0
        '
        'ClearAllButton
        '
        Me.ClearAllButton.Location = New System.Drawing.Point(11, 105)
        Me.ClearAllButton.Name = "ClearAllButton"
        Me.ClearAllButton.Size = New System.Drawing.Size(181, 28)
        Me.ClearAllButton.TabIndex = 3
        Me.ClearAllButton.Text = "Clear All"
        Me.ClearAllButton.UseVisualStyleBackColor = True
        '
        'StreamingAVARCancelButton
        '
        Me.StreamingAVARCancelButton.Location = New System.Drawing.Point(107, 559)
        Me.StreamingAVARCancelButton.Name = "StreamingAVARCancelButton"
        Me.StreamingAVARCancelButton.Size = New System.Drawing.Size(85, 40)
        Me.StreamingAVARCancelButton.TabIndex = 13
        Me.StreamingAVARCancelButton.Text = "Cancel"
        Me.StreamingAVARCancelButton.UseVisualStyleBackColor = True
        '
        'NumberDRToCapture
        '
        Me.NumberDRToCapture.Location = New System.Drawing.Point(6, 146)
        Me.NumberDRToCapture.Name = "NumberDRToCapture"
        Me.NumberDRToCapture.Size = New System.Drawing.Size(111, 20)
        Me.NumberDRToCapture.TabIndex = 9
        Me.NumberDRToCapture.Text = "10000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "# Samples To Capture:"
        '
        'MeasureDR
        '
        Me.MeasureDR.Location = New System.Drawing.Point(6, 60)
        Me.MeasureDR.Name = "MeasureDR"
        Me.MeasureDR.Size = New System.Drawing.Size(85, 40)
        Me.MeasureDR.TabIndex = 8
        Me.MeasureDR.Text = "Measure Data Ready"
        Me.MeasureDR.UseVisualStyleBackColor = True
        '
        'DrFreq
        '
        Me.DrFreq.AutoSize = True
        Me.DrFreq.Location = New System.Drawing.Point(107, 74)
        Me.DrFreq.Name = "DrFreq"
        Me.DrFreq.Size = New System.Drawing.Size(39, 13)
        Me.DrFreq.TabIndex = 17
        Me.DrFreq.Text = "Label4"
        '
        'DRDIO
        '
        Me.DRDIO.FormattingEnabled = True
        Me.DRDIO.Location = New System.Drawing.Point(6, 32)
        Me.DRDIO.Name = "DRDIO"
        Me.DRDIO.Size = New System.Drawing.Size(111, 21)
        Me.DRDIO.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Data Ready DIO:"
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.statusLabel.Location = New System.Drawing.Point(244, 569)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(189, 20)
        Me.statusLabel.TabIndex = 28
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(200, 573)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Status: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 607)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Capture Progress:"
        '
        'CaptureProgressStreaming
        '
        Me.CaptureProgressStreaming.Location = New System.Drawing.Point(107, 605)
        Me.CaptureProgressStreaming.Name = "CaptureProgressStreaming"
        Me.CaptureProgressStreaming.Size = New System.Drawing.Size(326, 18)
        Me.CaptureProgressStreaming.TabIndex = 29
        '
        'DrActiveBox
        '
        Me.DrActiveBox.Location = New System.Drawing.Point(123, 18)
        Me.DrActiveBox.Name = "DrActiveBox"
        Me.DrActiveBox.Size = New System.Drawing.Size(56, 42)
        Me.DrActiveBox.TabIndex = 7
        Me.DrActiveBox.Text = "DR Active"
        Me.DrActiveBox.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.DrActiveBox.UseVisualStyleBackColor = True
        '
        'linesPerFile
        '
        Me.linesPerFile.Location = New System.Drawing.Point(4, 75)
        Me.linesPerFile.Name = "linesPerFile"
        Me.linesPerFile.Size = New System.Drawing.Size(115, 20)
        Me.linesPerFile.TabIndex = 11
        Me.linesPerFile.Text = "1000000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "# Lines Per File:"
        '
        'regStreamingList
        '
        Me.regStreamingList.AutoSize = True
        Me.regStreamingList.Location = New System.Drawing.Point(198, 16)
        Me.regStreamingList.Name = "regStreamingList"
        Me.regStreamingList.Size = New System.Drawing.Size(130, 13)
        Me.regStreamingList.TabIndex = 100
        Me.regStreamingList.Text = "Register Streaming List (0)"
        '
        'btn_saveregs
        '
        Me.btn_saveregs.Location = New System.Drawing.Point(107, 139)
        Me.btn_saveregs.Name = "btn_saveregs"
        Me.btn_saveregs.Size = New System.Drawing.Size(85, 40)
        Me.btn_saveregs.TabIndex = 5
        Me.btn_saveregs.Text = "Save Register List"
        Me.btn_saveregs.UseVisualStyleBackColor = True
        '
        'btn_loadregs
        '
        Me.btn_loadregs.Location = New System.Drawing.Point(11, 139)
        Me.btn_loadregs.Name = "btn_loadregs"
        Me.btn_loadregs.Size = New System.Drawing.Size(85, 40)
        Me.btn_loadregs.TabIndex = 4
        Me.btn_loadregs.Text = "Load Register List"
        Me.btn_loadregs.UseVisualStyleBackColor = True
        '
        'ValidateDR
        '
        Me.ValidateDR.Checked = True
        Me.ValidateDR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ValidateDR.Location = New System.Drawing.Point(6, 106)
        Me.ValidateDR.Name = "ValidateDR"
        Me.ValidateDR.Size = New System.Drawing.Size(140, 21)
        Me.ValidateDR.TabIndex = 9
        Me.ValidateDR.Text = "Validate DR Period"
        Me.ValidateDR.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Base File Name:"
        '
        'fileBaseName
        '
        Me.fileBaseName.Location = New System.Drawing.Point(5, 33)
        Me.fileBaseName.Name = "fileBaseName"
        Me.fileBaseName.Size = New System.Drawing.Size(174, 20)
        Me.fileBaseName.TabIndex = 101
        Me.fileBaseName.Text = "RegStream"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "# Record Time (est):"
        '
        'text_recTime
        '
        Me.text_recTime.Location = New System.Drawing.Point(6, 189)
        Me.text_recTime.Name = "text_recTime"
        Me.text_recTime.Size = New System.Drawing.Size(111, 20)
        Me.text_recTime.TabIndex = 104
        Me.text_recTime.Text = "10000"
        '
        'check_ScaleData
        '
        Me.check_ScaleData.Checked = True
        Me.check_ScaleData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.check_ScaleData.Location = New System.Drawing.Point(4, 100)
        Me.check_ScaleData.Name = "check_ScaleData"
        Me.check_ScaleData.Size = New System.Drawing.Size(140, 21)
        Me.check_ScaleData.TabIndex = 105
        Me.check_ScaleData.Text = "Scale Sensor Data"
        Me.check_ScaleData.UseVisualStyleBackColor = True
        '
        'check_LogTimestamps
        '
        Me.check_LogTimestamps.Checked = True
        Me.check_LogTimestamps.CheckState = System.Windows.Forms.CheckState.Checked
        Me.check_LogTimestamps.Location = New System.Drawing.Point(4, 121)
        Me.check_LogTimestamps.Name = "check_LogTimestamps"
        Me.check_LogTimestamps.Size = New System.Drawing.Size(105, 21)
        Me.check_LogTimestamps.TabIndex = 106
        Me.check_LogTimestamps.Text = "Log Timestamps"
        Me.check_LogTimestamps.UseVisualStyleBackColor = True
        '
        'group_SampleConfig
        '
        Me.group_SampleConfig.Controls.Add(Me.MeasureDR)
        Me.group_SampleConfig.Controls.Add(Me.DrFreq)
        Me.group_SampleConfig.Controls.Add(Me.DRDIO)
        Me.group_SampleConfig.Controls.Add(Me.text_recTime)
        Me.group_SampleConfig.Controls.Add(Me.Label8)
        Me.group_SampleConfig.Controls.Add(Me.Label5)
        Me.group_SampleConfig.Controls.Add(Me.DrActiveBox)
        Me.group_SampleConfig.Controls.Add(Me.ValidateDR)
        Me.group_SampleConfig.Controls.Add(Me.NumberDRToCapture)
        Me.group_SampleConfig.Controls.Add(Me.Label3)
        Me.group_SampleConfig.Location = New System.Drawing.Point(7, 185)
        Me.group_SampleConfig.Name = "group_SampleConfig"
        Me.group_SampleConfig.Size = New System.Drawing.Size(185, 216)
        Me.group_SampleConfig.TabIndex = 107
        Me.group_SampleConfig.TabStop = False
        Me.group_SampleConfig.Text = "Sampling Configuration"
        '
        'group_LogConfig
        '
        Me.group_LogConfig.Controls.Add(Me.fileBaseName)
        Me.group_LogConfig.Controls.Add(Me.Label4)
        Me.group_LogConfig.Controls.Add(Me.check_LogTimestamps)
        Me.group_LogConfig.Controls.Add(Me.Label2)
        Me.group_LogConfig.Controls.Add(Me.check_ScaleData)
        Me.group_LogConfig.Controls.Add(Me.linesPerFile)
        Me.group_LogConfig.Location = New System.Drawing.Point(7, 407)
        Me.group_LogConfig.Name = "group_LogConfig"
        Me.group_LogConfig.Size = New System.Drawing.Size(185, 145)
        Me.group_LogConfig.TabIndex = 108
        Me.group_LogConfig.TabStop = False
        Me.group_LogConfig.Text = "Log File Options"
        '
        'RegisterBulkReadGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 632)
        Me.Controls.Add(Me.group_LogConfig)
        Me.Controls.Add(Me.group_SampleConfig)
        Me.Controls.Add(Me.btn_loadregs)
        Me.Controls.Add(Me.btn_saveregs)
        Me.Controls.Add(Me.regStreamingList)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CaptureProgressStreaming)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.StreamingAVARCancelButton)
        Me.Controls.Add(Me.ClearAllButton)
        Me.Controls.Add(Me.RegisterList)
        Me.Controls.Add(Me.MainButton)
        Me.Controls.Add(Me.selectedRegview)
        Me.Controls.Add(Me.RemoveRegisterButton)
        Me.Controls.Add(Me.AddRegisterButton)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RegisterBulkReadGUI"
        Me.Text = "Register Logging"
        Me.group_SampleConfig.ResumeLayout(False)
        Me.group_SampleConfig.PerformLayout()
        Me.group_LogConfig.ResumeLayout(False)
        Me.group_LogConfig.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents AddRegisterButton As Button
    Friend WithEvents RemoveRegisterButton As Button
    Friend WithEvents selectedRegview As ListView
    Friend WithEvents MainButton As Button
    Friend WithEvents RegisterList As ComboBox
    Friend WithEvents ClearAllButton As Button
    Friend WithEvents StreamingAVARCancelButton As Button
    Friend WithEvents NumberDRToCapture As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents MeasureDR As Button
    Friend WithEvents DrFreq As Label
    Friend WithEvents DRDIO As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents statusLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CaptureProgressStreaming As ProgressBar
    Friend WithEvents DrActiveBox As CheckBox
    Friend WithEvents linesPerFile As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents regStreamingList As Label
    Friend WithEvents btn_saveregs As Button
    Friend WithEvents btn_loadregs As Button
    Friend WithEvents ValidateDR As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents fileBaseName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents text_recTime As TextBox
    Friend WithEvents check_ScaleData As CheckBox
    Friend WithEvents check_LogTimestamps As CheckBox
    Friend WithEvents group_SampleConfig As GroupBox
    Friend WithEvents group_LogConfig As GroupBox
End Class
