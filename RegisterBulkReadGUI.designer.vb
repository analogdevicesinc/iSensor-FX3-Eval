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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.MainButton = New System.Windows.Forms.Button()
        Me.RegisterList = New System.Windows.Forms.ComboBox()
        Me.ClearAllButton = New System.Windows.Forms.Button()
        Me.StreamingAVARCancelButton = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
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
        Me.AddRegisterButton.Location = New System.Drawing.Point(23, 59)
        Me.AddRegisterButton.Name = "AddRegisterButton"
        Me.AddRegisterButton.Size = New System.Drawing.Size(66, 40)
        Me.AddRegisterButton.TabIndex = 2
        Me.AddRegisterButton.Text = "Add Register"
        Me.AddRegisterButton.UseVisualStyleBackColor = True
        '
        'RemoveRegisterButton
        '
        Me.RemoveRegisterButton.Location = New System.Drawing.Point(95, 59)
        Me.RemoveRegisterButton.Name = "RemoveRegisterButton"
        Me.RemoveRegisterButton.Size = New System.Drawing.Size(66, 40)
        Me.RemoveRegisterButton.TabIndex = 3
        Me.RemoveRegisterButton.Text = "Remove Register"
        Me.RemoveRegisterButton.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(239, 32)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(192, 346)
        Me.ListView1.TabIndex = 7
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(9, 285)
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
        Me.ClearAllButton.Location = New System.Drawing.Point(23, 105)
        Me.ClearAllButton.Name = "ClearAllButton"
        Me.ClearAllButton.Size = New System.Drawing.Size(138, 28)
        Me.ClearAllButton.TabIndex = 11
        Me.ClearAllButton.Text = "Clear All"
        Me.ClearAllButton.UseVisualStyleBackColor = True
        '
        'StreamingAVARCancelButton
        '
        Me.StreamingAVARCancelButton.Location = New System.Drawing.Point(112, 285)
        Me.StreamingAVARCancelButton.Name = "StreamingAVARCancelButton"
        Me.StreamingAVARCancelButton.Size = New System.Drawing.Size(77, 61)
        Me.StreamingAVARCancelButton.TabIndex = 12
        Me.StreamingAVARCancelButton.Text = "Cancel"
        Me.StreamingAVARCancelButton.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(10, 262)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(101, 17)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "Time Sampling?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'NumberDRToCapture
        '
        Me.NumberDRToCapture.Location = New System.Drawing.Point(80, 236)
        Me.NumberDRToCapture.Name = "NumberDRToCapture"
        Me.NumberDRToCapture.Size = New System.Drawing.Size(111, 20)
        Me.NumberDRToCapture.TabIndex = 14
        Me.NumberDRToCapture.Text = "1000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "# Samples To Capture:"
        '
        'MeasureDR
        '
        Me.MeasureDR.Location = New System.Drawing.Point(11, 162)
        Me.MeasureDR.Name = "MeasureDR"
        Me.MeasureDR.Size = New System.Drawing.Size(59, 94)
        Me.MeasureDR.TabIndex = 16
        Me.MeasureDR.Text = "Measure DR"
        Me.MeasureDR.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(79, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Label4"
        '
        'DRDIO
        '
        Me.DRDIO.FormattingEnabled = True
        Me.DRDIO.Location = New System.Drawing.Point(80, 196)
        Me.DRDIO.Name = "DRDIO"
        Me.DRDIO.Size = New System.Drawing.Size(111, 21)
        Me.DRDIO.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 182)
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
        Me.statusLabel.Location = New System.Drawing.Point(51, 358)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(145, 20)
        Me.statusLabel.TabIndex = 28
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 362)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Status: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 396)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Capture Progress:"
        '
        'CaptureProgressStreaming
        '
        Me.CaptureProgressStreaming.Location = New System.Drawing.Point(105, 394)
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
        'RegisterBulkReadGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 426)
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
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.StreamingAVARCancelButton)
        Me.Controls.Add(Me.ClearAllButton)
        Me.Controls.Add(Me.RegisterList)
        Me.Controls.Add(Me.MainButton)
        Me.Controls.Add(Me.ListView1)
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
    Friend WithEvents ListView1 As ListView
    Friend WithEvents MainButton As Button
    Friend WithEvents RegisterList As ComboBox
    Friend WithEvents ClearAllButton As Button
    Friend WithEvents StreamingAVARCancelButton As Button
    Friend WithEvents CheckBox1 As CheckBox
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
End Class
