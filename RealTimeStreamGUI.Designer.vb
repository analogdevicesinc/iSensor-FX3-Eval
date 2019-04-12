<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RealTimeStreamGUI
    Inherits System.Windows.Forms.Form

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
        Me.captureButton = New System.Windows.Forms.Button()
        Me.outputModeBox = New System.Windows.Forms.ComboBox()
        Me.numFramesInput = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numFramesCaptured = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.timeOutBox = New System.Windows.Forms.CheckBox()
        Me.PurgeFramesBox = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.framesPurged = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.captureMultipleFrames = New System.Windows.Forms.CheckBox()
        Me.numStepsToCapture = New System.Windows.Forms.TextBox()
        Me.enableExternalTrigger = New System.Windows.Forms.CheckBox()
        Me.DIOSelector = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DIOSelector, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'captureButton
        '
        Me.captureButton.Location = New System.Drawing.Point(129, 59)
        Me.captureButton.Name = "captureButton"
        Me.captureButton.Size = New System.Drawing.Size(75, 64)
        Me.captureButton.TabIndex = 0
        Me.captureButton.Text = "Start Capture"
        Me.captureButton.UseVisualStyleBackColor = True
        '
        'outputModeBox
        '
        Me.outputModeBox.FormattingEnabled = True
        Me.outputModeBox.Location = New System.Drawing.Point(108, 32)
        Me.outputModeBox.Name = "outputModeBox"
        Me.outputModeBox.Size = New System.Drawing.Size(169, 21)
        Me.outputModeBox.TabIndex = 1
        '
        'numFramesInput
        '
        Me.numFramesInput.Location = New System.Drawing.Point(108, 6)
        Me.numFramesInput.Name = "numFramesInput"
        Me.numFramesInput.Size = New System.Drawing.Size(169, 20)
        Me.numFramesInput.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Number of Frames:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Output Format:"
        '
        'numFramesCaptured
        '
        Me.numFramesCaptured.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.numFramesCaptured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numFramesCaptured.Location = New System.Drawing.Point(10, 203)
        Me.numFramesCaptured.Name = "numFramesCaptured"
        Me.numFramesCaptured.Size = New System.Drawing.Size(100, 16)
        Me.numFramesCaptured.TabIndex = 5
        Me.numFramesCaptured.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "# Frames Captured:"
        '
        'timeOutBox
        '
        Me.timeOutBox.AutoSize = True
        Me.timeOutBox.Location = New System.Drawing.Point(10, 59)
        Me.timeOutBox.Name = "timeOutBox"
        Me.timeOutBox.Size = New System.Drawing.Size(100, 17)
        Me.timeOutBox.TabIndex = 7
        Me.timeOutBox.Text = "Enable Timeout"
        Me.timeOutBox.UseVisualStyleBackColor = True
        '
        'PurgeFramesBox
        '
        Me.PurgeFramesBox.AutoSize = True
        Me.PurgeFramesBox.Location = New System.Drawing.Point(10, 82)
        Me.PurgeFramesBox.Name = "PurgeFramesBox"
        Me.PurgeFramesBox.Size = New System.Drawing.Size(113, 17)
        Me.PurgeFramesBox.TabIndex = 8
        Me.PurgeFramesBox.Text = "Purge Bad Frames"
        Me.PurgeFramesBox.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "# Frames Purged:"
        '
        'framesPurged
        '
        Me.framesPurged.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.framesPurged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.framesPurged.Location = New System.Drawing.Point(10, 243)
        Me.framesPurged.Name = "framesPurged"
        Me.framesPurged.Size = New System.Drawing.Size(100, 16)
        Me.framesPurged.TabIndex = 10
        Me.framesPurged.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(149, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "# Captures to Record"
        '
        'captureMultipleFrames
        '
        Me.captureMultipleFrames.AutoSize = True
        Me.captureMultipleFrames.Location = New System.Drawing.Point(152, 183)
        Me.captureMultipleFrames.Name = "captureMultipleFrames"
        Me.captureMultipleFrames.Size = New System.Drawing.Size(113, 17)
        Me.captureMultipleFrames.TabIndex = 13
        Me.captureMultipleFrames.Text = "Multiple Captures?"
        Me.captureMultipleFrames.UseVisualStyleBackColor = True
        '
        'numStepsToCapture
        '
        Me.numStepsToCapture.Location = New System.Drawing.Point(152, 156)
        Me.numStepsToCapture.Name = "numStepsToCapture"
        Me.numStepsToCapture.Size = New System.Drawing.Size(115, 20)
        Me.numStepsToCapture.TabIndex = 14
        Me.numStepsToCapture.Text = "0"
        '
        'enableExternalTrigger
        '
        Me.enableExternalTrigger.AutoSize = True
        Me.enableExternalTrigger.Location = New System.Drawing.Point(152, 200)
        Me.enableExternalTrigger.Name = "enableExternalTrigger"
        Me.enableExternalTrigger.Size = New System.Drawing.Size(106, 17)
        Me.enableExternalTrigger.TabIndex = 15
        Me.enableExternalTrigger.Text = "External Trigger?"
        Me.enableExternalTrigger.UseVisualStyleBackColor = True
        '
        'DIOSelector
        '
        Me.DIOSelector.Location = New System.Drawing.Point(152, 239)
        Me.DIOSelector.Name = "DIOSelector"
        Me.DIOSelector.Size = New System.Drawing.Size(55, 20)
        Me.DIOSelector.TabIndex = 16
        Me.DIOSelector.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(149, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Trigger DIO"
        '
        'RealTimeStreamGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 271)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DIOSelector)
        Me.Controls.Add(Me.enableExternalTrigger)
        Me.Controls.Add(Me.numStepsToCapture)
        Me.Controls.Add(Me.captureMultipleFrames)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.framesPurged)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PurgeFramesBox)
        Me.Controls.Add(Me.timeOutBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numFramesCaptured)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numFramesInput)
        Me.Controls.Add(Me.outputModeBox)
        Me.Controls.Add(Me.captureButton)
        Me.Name = "RealTimeStreamGUI"
        Me.Text = "RealTimeStreamGUI"
        CType(Me.DIOSelector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents captureButton As Button
    Friend WithEvents outputModeBox As ComboBox
    Friend WithEvents numFramesInput As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents numFramesCaptured As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents timeOutBox As CheckBox
    Friend WithEvents PurgeFramesBox As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents framesPurged As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents captureMultipleFrames As CheckBox
    Friend WithEvents numStepsToCapture As TextBox
    Friend WithEvents enableExternalTrigger As CheckBox
    Friend WithEvents DIOSelector As NumericUpDown
    Friend WithEvents Label6 As Label
End Class
