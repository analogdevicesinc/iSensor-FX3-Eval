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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DRDIO = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CaptureProgressStreaming = New System.Windows.Forms.ProgressBar()
        Me.DrActiveBox = New System.Windows.Forms.CheckBox()
        Me.linesPerFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SamplesPerWrite = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Registers"
        '
        'AddRegisterButton
        '
        Me.AddRegisterButton.Location = New System.Drawing.Point(12, 59)
        Me.AddRegisterButton.Name = "AddRegisterButton"
        Me.AddRegisterButton.Size = New System.Drawing.Size(85, 40)
        Me.AddRegisterButton.TabIndex = 2
        Me.AddRegisterButton.Text = "Add Register"
        Me.AddRegisterButton.UseVisualStyleBackColor = True
        '
        'RemoveRegisterButton
        '
        Me.RemoveRegisterButton.Location = New System.Drawing.Point(107, 59)
        Me.RemoveRegisterButton.Name = "RemoveRegisterButton"
        Me.RemoveRegisterButton.Size = New System.Drawing.Size(85, 40)
        Me.RemoveRegisterButton.TabIndex = 3
        Me.RemoveRegisterButton.Text = "Remove Register"
        Me.RemoveRegisterButton.UseVisualStyleBackColor = True
        '
        'selectedRegview
        '
        Me.selectedRegview.Location = New System.Drawing.Point(204, 32)
        Me.selectedRegview.Name = "selectedRegview"
        Me.selectedRegview.Size = New System.Drawing.Size(227, 408)
        Me.selectedRegview.TabIndex = 7
        Me.selectedRegview.UseCompatibleStateImageBehavior = False
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(11, 349)
        Me.MainButton.Name = "MainButton"
        Me.MainButton.Size = New System.Drawing.Size(77, 61)
        Me.MainButton.TabIndex = 9
        Me.MainButton.Text = "Start"
        Me.MainButton.UseVisualStyleBackColor = True
        '
        'RegisterList
        '
        Me.RegisterList.FormattingEnabled = True
        Me.RegisterList.Location = New System.Drawing.Point(11, 32)
        Me.RegisterList.Name = "RegisterList"
        Me.RegisterList.Size = New System.Drawing.Size(181, 21)
        Me.RegisterList.TabIndex = 10
        '
        'ClearAllButton
        '
        Me.ClearAllButton.Location = New System.Drawing.Point(11, 105)
        Me.ClearAllButton.Name = "ClearAllButton"
        Me.ClearAllButton.Size = New System.Drawing.Size(179, 28)
        Me.ClearAllButton.TabIndex = 11
        Me.ClearAllButton.Text = "Clear All"
        Me.ClearAllButton.UseVisualStyleBackColor = True
        '
        'StreamingAVARCancelButton
        '
        Me.StreamingAVARCancelButton.Location = New System.Drawing.Point(121, 349)
        Me.StreamingAVARCancelButton.Name = "StreamingAVARCancelButton"
        Me.StreamingAVARCancelButton.Size = New System.Drawing.Size(77, 61)
        Me.StreamingAVARCancelButton.TabIndex = 12
        Me.StreamingAVARCancelButton.Text = "Cancel"
        Me.StreamingAVARCancelButton.UseVisualStyleBackColor = True
        '
        'NumberDRToCapture
        '
        Me.NumberDRToCapture.Location = New System.Drawing.Point(11, 236)
        Me.NumberDRToCapture.Name = "NumberDRToCapture"
        Me.NumberDRToCapture.Size = New System.Drawing.Size(111, 20)
        Me.NumberDRToCapture.TabIndex = 14
        Me.NumberDRToCapture.Text = "10000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "# Samples To Capture:"
        '
        'MeasureDR
        '
        Me.MeasureDR.Location = New System.Drawing.Point(11, 158)
        Me.MeasureDR.Name = "MeasureDR"
        Me.MeasureDR.Size = New System.Drawing.Size(59, 59)
        Me.MeasureDR.TabIndex = 16
        Me.MeasureDR.Text = "Measure DR"
        Me.MeasureDR.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Label4"
        '
        'DRDIO
        '
        Me.DRDIO.FormattingEnabled = True
        Me.DRDIO.Location = New System.Drawing.Point(79, 196)
        Me.DRDIO.Name = "DRDIO"
        Me.DRDIO.Size = New System.Drawing.Size(111, 21)
        Me.DRDIO.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(76, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "DR DIO:"
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.statusLabel.Location = New System.Drawing.Point(53, 420)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(145, 20)
        Me.statusLabel.TabIndex = 28
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 424)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Status: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 448)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Capture Progress:"
        '
        'CaptureProgressStreaming
        '
        Me.CaptureProgressStreaming.Location = New System.Drawing.Point(107, 446)
        Me.CaptureProgressStreaming.Name = "CaptureProgressStreaming"
        Me.CaptureProgressStreaming.Size = New System.Drawing.Size(326, 18)
        Me.CaptureProgressStreaming.TabIndex = 29
        '
        'DrActiveBox
        '
        Me.DrActiveBox.AutoSize = True
        Me.DrActiveBox.Location = New System.Drawing.Point(11, 139)
        Me.DrActiveBox.Name = "DrActiveBox"
        Me.DrActiveBox.Size = New System.Drawing.Size(75, 17)
        Me.DrActiveBox.TabIndex = 31
        Me.DrActiveBox.Text = "DR Active"
        Me.DrActiveBox.UseVisualStyleBackColor = True
        '
        'linesPerFile
        '
        Me.linesPerFile.Location = New System.Drawing.Point(12, 320)
        Me.linesPerFile.Name = "linesPerFile"
        Me.linesPerFile.Size = New System.Drawing.Size(111, 20)
        Me.linesPerFile.TabIndex = 32
        Me.linesPerFile.Text = "1000000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 304)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "# Lines Per File:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "# Samples Per Write:"
        '
        'SamplesPerWrite
        '
        Me.SamplesPerWrite.Location = New System.Drawing.Point(11, 278)
        Me.SamplesPerWrite.Name = "SamplesPerWrite"
        Me.SamplesPerWrite.Size = New System.Drawing.Size(111, 20)
        Me.SamplesPerWrite.TabIndex = 35
        Me.SamplesPerWrite.Text = "10000"
        '
        'RegisterBulkReadGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 476)
        Me.Controls.Add(Me.SamplesPerWrite)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.linesPerFile)
        Me.Controls.Add(Me.DrActiveBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CaptureProgressStreaming)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DRDIO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MeasureDR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumberDRToCapture)
        Me.Controls.Add(Me.StreamingAVARCancelButton)
        Me.Controls.Add(Me.ClearAllButton)
        Me.Controls.Add(Me.RegisterList)
        Me.Controls.Add(Me.MainButton)
        Me.Controls.Add(Me.selectedRegview)
        Me.Controls.Add(Me.RemoveRegisterButton)
        Me.Controls.Add(Me.AddRegisterButton)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RegisterBulkReadGUI"
        Me.Text = "Bulk Register Streaming"
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
    Friend WithEvents Label4 As Label
    Friend WithEvents DRDIO As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents statusLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CaptureProgressStreaming As ProgressBar
    Friend WithEvents DrActiveBox As CheckBox
    Friend WithEvents linesPerFile As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents SamplesPerWrite As TextBox
End Class
