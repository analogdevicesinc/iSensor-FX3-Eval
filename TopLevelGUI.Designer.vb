<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TopLevelGUI
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
        Me.RegisterAccess = New System.Windows.Forms.Button()
        Me.ManualMode = New System.Windows.Forms.Button()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.StatusText = New System.Windows.Forms.Label()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.readIDButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DUTStatusBox = New System.Windows.Forms.Label()
        Me.configureSPI = New System.Windows.Forms.Button()
        Me.checkConnection = New System.Windows.Forms.Button()
        Me.ReadPinButton = New System.Windows.Forms.Button()
        Me.realTimeStreamButton = New System.Windows.Forms.Button()
        Me.ResetDUTButton = New System.Windows.Forms.Button()
        Me.TextFileStreamingButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RegisterAccess
        '
        Me.RegisterAccess.Location = New System.Drawing.Point(11, 127)
        Me.RegisterAccess.Name = "RegisterAccess"
        Me.RegisterAccess.Size = New System.Drawing.Size(75, 64)
        Me.RegisterAccess.TabIndex = 0
        Me.RegisterAccess.Text = "Register Access"
        Me.RegisterAccess.UseVisualStyleBackColor = True
        '
        'ManualMode
        '
        Me.ManualMode.Location = New System.Drawing.Point(255, 127)
        Me.ManualMode.Name = "ManualMode"
        Me.ManualMode.Size = New System.Drawing.Size(75, 64)
        Me.ManualMode.TabIndex = 2
        Me.ManualMode.Text = "Manual Capture Mode"
        Me.ManualMode.UseVisualStyleBackColor = True
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(9, 83)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(65, 13)
        Me.StatusLabel.TabIndex = 4
        Me.StatusLabel.Text = "FX3 Status: "
        '
        'StatusText
        '
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusText.Location = New System.Drawing.Point(73, 82)
        Me.StatusText.Name = "StatusText"
        Me.StatusText.Size = New System.Drawing.Size(257, 14)
        Me.StatusText.TabIndex = 5
        Me.StatusText.Text = "Ok"
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(11, 9)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(75, 64)
        Me.ConnectButton.TabIndex = 6
        Me.ConnectButton.Text = "Connect to FX3"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(93, 9)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(75, 64)
        Me.ResetButton.TabIndex = 10
        Me.ResetButton.Text = "Reset FX3"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'readIDButton
        '
        Me.readIDButton.Location = New System.Drawing.Point(93, 197)
        Me.readIDButton.Name = "readIDButton"
        Me.readIDButton.Size = New System.Drawing.Size(75, 64)
        Me.readIDButton.TabIndex = 11
        Me.readIDButton.Text = "Read Firmware ID"
        Me.readIDButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "DUT Status:"
        '
        'DUTStatusBox
        '
        Me.DUTStatusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DUTStatusBox.Location = New System.Drawing.Point(77, 106)
        Me.DUTStatusBox.Name = "DUTStatusBox"
        Me.DUTStatusBox.Size = New System.Drawing.Size(253, 14)
        Me.DUTStatusBox.TabIndex = 13
        Me.DUTStatusBox.Text = "Label2"
        Me.DUTStatusBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'configureSPI
        '
        Me.configureSPI.Location = New System.Drawing.Point(174, 9)
        Me.configureSPI.Name = "configureSPI"
        Me.configureSPI.Size = New System.Drawing.Size(75, 64)
        Me.configureSPI.TabIndex = 14
        Me.configureSPI.Text = "Configure Board"
        Me.configureSPI.UseVisualStyleBackColor = True
        '
        'checkConnection
        '
        Me.checkConnection.Location = New System.Drawing.Point(174, 197)
        Me.checkConnection.Name = "checkConnection"
        Me.checkConnection.Size = New System.Drawing.Size(75, 64)
        Me.checkConnection.TabIndex = 15
        Me.checkConnection.Text = "Check DUT Connection"
        Me.checkConnection.UseVisualStyleBackColor = True
        '
        'ReadPinButton
        '
        Me.ReadPinButton.Location = New System.Drawing.Point(12, 197)
        Me.ReadPinButton.Name = "ReadPinButton"
        Me.ReadPinButton.Size = New System.Drawing.Size(75, 64)
        Me.ReadPinButton.TabIndex = 16
        Me.ReadPinButton.Text = "Read Pin"
        Me.ReadPinButton.UseVisualStyleBackColor = True
        '
        'realTimeStreamButton
        '
        Me.realTimeStreamButton.Location = New System.Drawing.Point(92, 127)
        Me.realTimeStreamButton.Name = "realTimeStreamButton"
        Me.realTimeStreamButton.Size = New System.Drawing.Size(75, 64)
        Me.realTimeStreamButton.TabIndex = 17
        Me.realTimeStreamButton.Text = "Real Time Streaming"
        Me.realTimeStreamButton.UseVisualStyleBackColor = True
        '
        'ResetDUTButton
        '
        Me.ResetDUTButton.Location = New System.Drawing.Point(255, 9)
        Me.ResetDUTButton.Name = "ResetDUTButton"
        Me.ResetDUTButton.Size = New System.Drawing.Size(75, 64)
        Me.ResetDUTButton.TabIndex = 19
        Me.ResetDUTButton.Text = "Reset DUT"
        Me.ResetDUTButton.UseVisualStyleBackColor = True
        '
        'TextFileStreamingButton
        '
        Me.TextFileStreamingButton.Location = New System.Drawing.Point(173, 127)
        Me.TextFileStreamingButton.Name = "TextFileStreamingButton"
        Me.TextFileStreamingButton.Size = New System.Drawing.Size(75, 64)
        Me.TextFileStreamingButton.TabIndex = 20
        Me.TextFileStreamingButton.Text = "Text File Stream Manager Streaming"
        Me.TextFileStreamingButton.UseVisualStyleBackColor = True
        '
        'TopLevelGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 268)
        Me.Controls.Add(Me.TextFileStreamingButton)
        Me.Controls.Add(Me.ResetDUTButton)
        Me.Controls.Add(Me.realTimeStreamButton)
        Me.Controls.Add(Me.ReadPinButton)
        Me.Controls.Add(Me.checkConnection)
        Me.Controls.Add(Me.configureSPI)
        Me.Controls.Add(Me.DUTStatusBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.readIDButton)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.StatusText)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.ManualMode)
        Me.Controls.Add(Me.RegisterAccess)
        Me.Name = "TopLevelGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ADcmXLx021 Interface"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RegisterAccess As Button
    Friend WithEvents ManualMode As Button
    Friend WithEvents StatusLabel As Label
    Friend WithEvents StatusText As Label
    Friend WithEvents ConnectButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents readIDButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DUTStatusBox As Label
    Friend WithEvents configureSPI As Button
    Friend WithEvents checkConnection As Button
    Friend WithEvents ReadPinButton As Button
    Friend WithEvents realTimeStreamButton As Button
    Friend WithEvents ResetDUTButton As Button
    Friend WithEvents TextFileStreamingButton As Button
End Class
