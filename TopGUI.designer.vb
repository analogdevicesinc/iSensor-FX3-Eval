<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TopGUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TopGUI))
        Me.text_FX3Status = New System.Windows.Forms.Label()
        Me.label_FX3Status = New System.Windows.Forms.Label()
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.text_DUTStatus = New System.Windows.Forms.Label()
        Me.label_DUTStatus = New System.Windows.Forms.Label()
        Me.btn_ResetDUT = New System.Windows.Forms.Button()
        Me.btn_SelectDUT = New System.Windows.Forms.Button()
        Me.btn_DisconnectFX3 = New System.Windows.Forms.Button()
        Me.btn_RegAccess = New System.Windows.Forms.Button()
        Me.text_DUTType = New System.Windows.Forms.Label()
        Me.label_DUTType = New System.Windows.Forms.Label()
        Me.btn_RealTime = New System.Windows.Forms.Button()
        Me.btn_BulkRegRead = New System.Windows.Forms.Button()
        Me.btn_CheckDUTConnection = New System.Windows.Forms.Button()
        Me.btn_FX3Config = New System.Windows.Forms.Button()
        Me.btn_APIInfo = New System.Windows.Forms.Button()
        Me.btn_BoardInfo = New System.Windows.Forms.Button()
        Me.btn_PWMSetup = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'text_FX3Status
        '
        Me.text_FX3Status.AutoSize = True
        Me.text_FX3Status.Location = New System.Drawing.Point(9, 83)
        Me.text_FX3Status.Name = "text_FX3Status"
        Me.text_FX3Status.Size = New System.Drawing.Size(65, 13)
        Me.text_FX3Status.TabIndex = 4
        Me.text_FX3Status.Text = "FX3 Status: "
        '
        'label_FX3Status
        '
        Me.label_FX3Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_FX3Status.Location = New System.Drawing.Point(77, 82)
        Me.label_FX3Status.Name = "label_FX3Status"
        Me.label_FX3Status.Size = New System.Drawing.Size(253, 16)
        Me.label_FX3Status.TabIndex = 5
        Me.label_FX3Status.Text = "Ok"
        Me.label_FX3Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_Connect
        '
        Me.btn_Connect.Location = New System.Drawing.Point(11, 9)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(75, 64)
        Me.btn_Connect.TabIndex = 0
        Me.btn_Connect.Text = "Connect to FX3"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'text_DUTStatus
        '
        Me.text_DUTStatus.AutoSize = True
        Me.text_DUTStatus.Location = New System.Drawing.Point(9, 106)
        Me.text_DUTStatus.Name = "text_DUTStatus"
        Me.text_DUTStatus.Size = New System.Drawing.Size(66, 13)
        Me.text_DUTStatus.TabIndex = 12
        Me.text_DUTStatus.Text = "DUT Status:"
        '
        'label_DUTStatus
        '
        Me.label_DUTStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTStatus.Location = New System.Drawing.Point(77, 104)
        Me.label_DUTStatus.Name = "label_DUTStatus"
        Me.label_DUTStatus.Size = New System.Drawing.Size(253, 16)
        Me.label_DUTStatus.TabIndex = 13
        Me.label_DUTStatus.Text = "Label2"
        Me.label_DUTStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_ResetDUT
        '
        Me.btn_ResetDUT.Location = New System.Drawing.Point(174, 9)
        Me.btn_ResetDUT.Name = "btn_ResetDUT"
        Me.btn_ResetDUT.Size = New System.Drawing.Size(75, 64)
        Me.btn_ResetDUT.TabIndex = 14
        Me.btn_ResetDUT.Text = "Reset DUT"
        Me.btn_ResetDUT.UseVisualStyleBackColor = True
        '
        'btn_SelectDUT
        '
        Me.btn_SelectDUT.Location = New System.Drawing.Point(12, 219)
        Me.btn_SelectDUT.Name = "btn_SelectDUT"
        Me.btn_SelectDUT.Size = New System.Drawing.Size(75, 64)
        Me.btn_SelectDUT.TabIndex = 15
        Me.btn_SelectDUT.Text = "Select DUT Type"
        Me.btn_SelectDUT.UseVisualStyleBackColor = True
        '
        'btn_DisconnectFX3
        '
        Me.btn_DisconnectFX3.Location = New System.Drawing.Point(92, 9)
        Me.btn_DisconnectFX3.Name = "btn_DisconnectFX3"
        Me.btn_DisconnectFX3.Size = New System.Drawing.Size(75, 64)
        Me.btn_DisconnectFX3.TabIndex = 16
        Me.btn_DisconnectFX3.Text = "Reset FX3"
        Me.btn_DisconnectFX3.UseVisualStyleBackColor = True
        '
        'btn_RegAccess
        '
        Me.btn_RegAccess.Location = New System.Drawing.Point(12, 149)
        Me.btn_RegAccess.Name = "btn_RegAccess"
        Me.btn_RegAccess.Size = New System.Drawing.Size(75, 64)
        Me.btn_RegAccess.TabIndex = 0
        Me.btn_RegAccess.Text = "Register Access"
        Me.btn_RegAccess.UseVisualStyleBackColor = True
        '
        'text_DUTType
        '
        Me.text_DUTType.AutoSize = True
        Me.text_DUTType.Location = New System.Drawing.Point(9, 128)
        Me.text_DUTType.Name = "text_DUTType"
        Me.text_DUTType.Size = New System.Drawing.Size(60, 13)
        Me.text_DUTType.TabIndex = 18
        Me.text_DUTType.Text = "DUT Type:"
        '
        'label_DUTType
        '
        Me.label_DUTType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTType.Location = New System.Drawing.Point(77, 127)
        Me.label_DUTType.Name = "label_DUTType"
        Me.label_DUTType.Size = New System.Drawing.Size(253, 16)
        Me.label_DUTType.TabIndex = 19
        Me.label_DUTType.Text = "Ok"
        Me.label_DUTType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_RealTime
        '
        Me.btn_RealTime.Location = New System.Drawing.Point(93, 149)
        Me.btn_RealTime.Name = "btn_RealTime"
        Me.btn_RealTime.Size = New System.Drawing.Size(75, 64)
        Me.btn_RealTime.TabIndex = 20
        Me.btn_RealTime.Text = "Real Time Data Capture"
        Me.btn_RealTime.UseVisualStyleBackColor = True
        '
        'btn_BulkRegRead
        '
        Me.btn_BulkRegRead.Location = New System.Drawing.Point(174, 149)
        Me.btn_BulkRegRead.Name = "btn_BulkRegRead"
        Me.btn_BulkRegRead.Size = New System.Drawing.Size(75, 64)
        Me.btn_BulkRegRead.TabIndex = 21
        Me.btn_BulkRegRead.Text = "Bulk Register Capture"
        Me.btn_BulkRegRead.UseVisualStyleBackColor = True
        '
        'btn_CheckDUTConnection
        '
        Me.btn_CheckDUTConnection.Location = New System.Drawing.Point(255, 9)
        Me.btn_CheckDUTConnection.Name = "btn_CheckDUTConnection"
        Me.btn_CheckDUTConnection.Size = New System.Drawing.Size(75, 64)
        Me.btn_CheckDUTConnection.TabIndex = 22
        Me.btn_CheckDUTConnection.Text = "Check DUT Connection"
        Me.btn_CheckDUTConnection.UseVisualStyleBackColor = True
        '
        'btn_FX3Config
        '
        Me.btn_FX3Config.Location = New System.Drawing.Point(92, 219)
        Me.btn_FX3Config.Name = "btn_FX3Config"
        Me.btn_FX3Config.Size = New System.Drawing.Size(75, 64)
        Me.btn_FX3Config.TabIndex = 23
        Me.btn_FX3Config.Text = "Set FX3 Config"
        Me.btn_FX3Config.UseVisualStyleBackColor = True
        '
        'btn_APIInfo
        '
        Me.btn_APIInfo.Location = New System.Drawing.Point(255, 218)
        Me.btn_APIInfo.Name = "btn_APIInfo"
        Me.btn_APIInfo.Size = New System.Drawing.Size(75, 64)
        Me.btn_APIInfo.TabIndex = 24
        Me.btn_APIInfo.Text = "FX3 API Info"
        Me.btn_APIInfo.UseVisualStyleBackColor = True
        '
        'btn_BoardInfo
        '
        Me.btn_BoardInfo.Location = New System.Drawing.Point(174, 219)
        Me.btn_BoardInfo.Name = "btn_BoardInfo"
        Me.btn_BoardInfo.Size = New System.Drawing.Size(75, 64)
        Me.btn_BoardInfo.TabIndex = 26
        Me.btn_BoardInfo.Text = "FX3 Board Info"
        Me.btn_BoardInfo.UseVisualStyleBackColor = True
        '
        'btn_PWMSetup
        '
        Me.btn_PWMSetup.Location = New System.Drawing.Point(255, 149)
        Me.btn_PWMSetup.Name = "btn_PWMSetup"
        Me.btn_PWMSetup.Size = New System.Drawing.Size(75, 64)
        Me.btn_PWMSetup.TabIndex = 25
        Me.btn_PWMSetup.Text = "PWM Setup"
        Me.btn_PWMSetup.UseVisualStyleBackColor = True
        '
        'TopGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 291)
        Me.Controls.Add(Me.btn_BoardInfo)
        Me.Controls.Add(Me.btn_PWMSetup)
        Me.Controls.Add(Me.btn_APIInfo)
        Me.Controls.Add(Me.btn_FX3Config)
        Me.Controls.Add(Me.btn_CheckDUTConnection)
        Me.Controls.Add(Me.btn_BulkRegRead)
        Me.Controls.Add(Me.btn_RealTime)
        Me.Controls.Add(Me.label_DUTType)
        Me.Controls.Add(Me.text_DUTType)
        Me.Controls.Add(Me.btn_RegAccess)
        Me.Controls.Add(Me.btn_DisconnectFX3)
        Me.Controls.Add(Me.btn_SelectDUT)
        Me.Controls.Add(Me.btn_ResetDUT)
        Me.Controls.Add(Me.label_DUTStatus)
        Me.Controls.Add(Me.text_DUTStatus)
        Me.Controls.Add(Me.btn_Connect)
        Me.Controls.Add(Me.label_FX3Status)
        Me.Controls.Add(Me.text_FX3Status)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(360, 330)
        Me.MinimumSize = New System.Drawing.Size(360, 330)
        Me.Name = "TopGUI"
        Me.Text = "iSensor FX3 GUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents text_FX3Status As Label
    Friend WithEvents label_FX3Status As Label
    Friend WithEvents btn_Connect As Button
    Friend WithEvents text_DUTStatus As Label
    Friend WithEvents label_DUTStatus As Label
    Friend WithEvents btn_ResetDUT As Button
    Friend WithEvents btn_SelectDUT As Button
    Friend WithEvents btn_DisconnectFX3 As Button
    Friend WithEvents btn_RegAccess As Button
    Friend WithEvents text_DUTType As Label
    Friend WithEvents label_DUTType As Label
    Friend WithEvents btn_RealTime As Button
    Friend WithEvents btn_BulkRegRead As Button
    Friend WithEvents btn_CheckDUTConnection As Button
    Friend WithEvents btn_FX3Config As Button
    Friend WithEvents btn_APIInfo As Button
    Friend WithEvents btn_BoardInfo As Button
    Friend WithEvents btn_PWMSetup As Button
End Class
