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
        Me.btn_plotFFT = New System.Windows.Forms.Button()
        Me.btn_OtherApps = New System.Windows.Forms.Button()
        Me.btn_PinAccess = New System.Windows.Forms.Button()
        Me.label_apiVersion = New System.Windows.Forms.Label()
        Me.btn_plotData = New System.Windows.Forms.Button()
        Me.regMapPath_Label = New System.Windows.Forms.Label()
        Me.report_issue = New System.Windows.Forms.LinkLabel()
        Me.checkVersion = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'text_FX3Status
        '
        Me.text_FX3Status.AutoSize = True
        Me.text_FX3Status.Location = New System.Drawing.Point(10, 79)
        Me.text_FX3Status.Name = "text_FX3Status"
        Me.text_FX3Status.Size = New System.Drawing.Size(65, 13)
        Me.text_FX3Status.TabIndex = 4
        Me.text_FX3Status.Text = "FX3 Status: "
        '
        'label_FX3Status
        '
        Me.label_FX3Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_FX3Status.Location = New System.Drawing.Point(81, 76)
        Me.label_FX3Status.Name = "label_FX3Status"
        Me.label_FX3Status.Size = New System.Drawing.Size(330, 18)
        Me.label_FX3Status.TabIndex = 5
        Me.label_FX3Status.Text = "Ok"
        Me.label_FX3Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_Connect
        '
        Me.btn_Connect.Location = New System.Drawing.Point(11, 9)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(75, 62)
        Me.btn_Connect.TabIndex = 0
        Me.btn_Connect.Text = "Connect to FX3"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'text_DUTStatus
        '
        Me.text_DUTStatus.AutoSize = True
        Me.text_DUTStatus.Location = New System.Drawing.Point(10, 105)
        Me.text_DUTStatus.Name = "text_DUTStatus"
        Me.text_DUTStatus.Size = New System.Drawing.Size(66, 13)
        Me.text_DUTStatus.TabIndex = 12
        Me.text_DUTStatus.Text = "DUT Status:"
        '
        'label_DUTStatus
        '
        Me.label_DUTStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTStatus.Location = New System.Drawing.Point(82, 102)
        Me.label_DUTStatus.Name = "label_DUTStatus"
        Me.label_DUTStatus.Size = New System.Drawing.Size(329, 18)
        Me.label_DUTStatus.TabIndex = 13
        Me.label_DUTStatus.Text = "Waiting for FX3"
        Me.label_DUTStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_ResetDUT
        '
        Me.btn_ResetDUT.Location = New System.Drawing.Point(92, 9)
        Me.btn_ResetDUT.Name = "btn_ResetDUT"
        Me.btn_ResetDUT.Size = New System.Drawing.Size(75, 62)
        Me.btn_ResetDUT.TabIndex = 1
        Me.btn_ResetDUT.Text = "Reset DUT"
        Me.btn_ResetDUT.UseVisualStyleBackColor = True
        '
        'btn_SelectDUT
        '
        Me.btn_SelectDUT.Location = New System.Drawing.Point(255, 9)
        Me.btn_SelectDUT.Name = "btn_SelectDUT"
        Me.btn_SelectDUT.Size = New System.Drawing.Size(75, 62)
        Me.btn_SelectDUT.TabIndex = 3
        Me.btn_SelectDUT.Text = "Select DUT Type"
        Me.btn_SelectDUT.UseVisualStyleBackColor = True
        '
        'btn_RegAccess
        '
        Me.btn_RegAccess.Location = New System.Drawing.Point(11, 153)
        Me.btn_RegAccess.Name = "btn_RegAccess"
        Me.btn_RegAccess.Size = New System.Drawing.Size(75, 62)
        Me.btn_RegAccess.TabIndex = 5
        Me.btn_RegAccess.Text = "Register Access"
        Me.btn_RegAccess.UseVisualStyleBackColor = True
        '
        'text_DUTType
        '
        Me.text_DUTType.AutoSize = True
        Me.text_DUTType.Location = New System.Drawing.Point(10, 131)
        Me.text_DUTType.Name = "text_DUTType"
        Me.text_DUTType.Size = New System.Drawing.Size(60, 13)
        Me.text_DUTType.TabIndex = 18
        Me.text_DUTType.Text = "DUT Type:"
        '
        'label_DUTType
        '
        Me.label_DUTType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTType.Location = New System.Drawing.Point(82, 128)
        Me.label_DUTType.Name = "label_DUTType"
        Me.label_DUTType.Size = New System.Drawing.Size(329, 18)
        Me.label_DUTType.TabIndex = 19
        Me.label_DUTType.Text = "Not Set"
        Me.label_DUTType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_RealTime
        '
        Me.btn_RealTime.Location = New System.Drawing.Point(93, 153)
        Me.btn_RealTime.Name = "btn_RealTime"
        Me.btn_RealTime.Size = New System.Drawing.Size(75, 62)
        Me.btn_RealTime.TabIndex = 6
        Me.btn_RealTime.Text = "Burst Data Capture"
        Me.btn_RealTime.UseVisualStyleBackColor = True
        '
        'btn_BulkRegRead
        '
        Me.btn_BulkRegRead.Location = New System.Drawing.Point(174, 153)
        Me.btn_BulkRegRead.Name = "btn_BulkRegRead"
        Me.btn_BulkRegRead.Size = New System.Drawing.Size(75, 62)
        Me.btn_BulkRegRead.TabIndex = 7
        Me.btn_BulkRegRead.Text = "Register Logging"
        Me.btn_BulkRegRead.UseVisualStyleBackColor = True
        '
        'btn_CheckDUTConnection
        '
        Me.btn_CheckDUTConnection.Location = New System.Drawing.Point(173, 9)
        Me.btn_CheckDUTConnection.Name = "btn_CheckDUTConnection"
        Me.btn_CheckDUTConnection.Size = New System.Drawing.Size(75, 62)
        Me.btn_CheckDUTConnection.TabIndex = 2
        Me.btn_CheckDUTConnection.Text = "Check DUT Connection"
        Me.btn_CheckDUTConnection.UseVisualStyleBackColor = True
        '
        'btn_FX3Config
        '
        Me.btn_FX3Config.Location = New System.Drawing.Point(336, 9)
        Me.btn_FX3Config.Name = "btn_FX3Config"
        Me.btn_FX3Config.Size = New System.Drawing.Size(75, 62)
        Me.btn_FX3Config.TabIndex = 4
        Me.btn_FX3Config.Text = "FX3 Config. Options"
        Me.btn_FX3Config.UseVisualStyleBackColor = True
        '
        'btn_APIInfo
        '
        Me.btn_APIInfo.Location = New System.Drawing.Point(173, 221)
        Me.btn_APIInfo.Name = "btn_APIInfo"
        Me.btn_APIInfo.Size = New System.Drawing.Size(75, 62)
        Me.btn_APIInfo.TabIndex = 12
        Me.btn_APIInfo.Text = "FX3 API Info."
        Me.btn_APIInfo.UseVisualStyleBackColor = True
        '
        'btn_BoardInfo
        '
        Me.btn_BoardInfo.Location = New System.Drawing.Point(255, 221)
        Me.btn_BoardInfo.Name = "btn_BoardInfo"
        Me.btn_BoardInfo.Size = New System.Drawing.Size(75, 62)
        Me.btn_BoardInfo.TabIndex = 13
        Me.btn_BoardInfo.Text = "FX3 Board Info."
        Me.btn_BoardInfo.UseVisualStyleBackColor = True
        '
        'btn_PWMSetup
        '
        Me.btn_PWMSetup.Location = New System.Drawing.Point(92, 221)
        Me.btn_PWMSetup.Name = "btn_PWMSetup"
        Me.btn_PWMSetup.Size = New System.Drawing.Size(75, 62)
        Me.btn_PWMSetup.TabIndex = 11
        Me.btn_PWMSetup.Text = "PWM Output Setup"
        Me.btn_PWMSetup.UseVisualStyleBackColor = True
        '
        'btn_plotFFT
        '
        Me.btn_plotFFT.Location = New System.Drawing.Point(336, 153)
        Me.btn_plotFFT.Name = "btn_plotFFT"
        Me.btn_plotFFT.Size = New System.Drawing.Size(75, 62)
        Me.btn_plotFFT.TabIndex = 9
        Me.btn_plotFFT.Text = "FFT Data Plotting"
        Me.btn_plotFFT.UseVisualStyleBackColor = True
        '
        'btn_OtherApps
        '
        Me.btn_OtherApps.Location = New System.Drawing.Point(336, 221)
        Me.btn_OtherApps.Name = "btn_OtherApps"
        Me.btn_OtherApps.Size = New System.Drawing.Size(75, 62)
        Me.btn_OtherApps.TabIndex = 14
        Me.btn_OtherApps.Text = "Other Applications"
        Me.btn_OtherApps.UseVisualStyleBackColor = True
        '
        'btn_PinAccess
        '
        Me.btn_PinAccess.Location = New System.Drawing.Point(11, 221)
        Me.btn_PinAccess.Name = "btn_PinAccess"
        Me.btn_PinAccess.Size = New System.Drawing.Size(75, 62)
        Me.btn_PinAccess.TabIndex = 10
        Me.btn_PinAccess.Text = "Pin Access"
        Me.btn_PinAccess.UseVisualStyleBackColor = True
        '
        'label_apiVersion
        '
        Me.label_apiVersion.Location = New System.Drawing.Point(10, 286)
        Me.label_apiVersion.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.label_apiVersion.Name = "label_apiVersion"
        Me.label_apiVersion.Size = New System.Drawing.Size(401, 13)
        Me.label_apiVersion.TabIndex = 30
        Me.label_apiVersion.Text = "apiVersion"
        '
        'btn_plotData
        '
        Me.btn_plotData.Location = New System.Drawing.Point(255, 153)
        Me.btn_plotData.Name = "btn_plotData"
        Me.btn_plotData.Size = New System.Drawing.Size(75, 62)
        Me.btn_plotData.TabIndex = 8
        Me.btn_plotData.Text = "Data Plotting"
        Me.btn_plotData.UseVisualStyleBackColor = True
        '
        'regMapPath_Label
        '
        Me.regMapPath_Label.AutoSize = True
        Me.regMapPath_Label.Location = New System.Drawing.Point(10, 304)
        Me.regMapPath_Label.Name = "regMapPath_Label"
        Me.regMapPath_Label.Size = New System.Drawing.Size(70, 13)
        Me.regMapPath_Label.TabIndex = 33
        Me.regMapPath_Label.Text = "RegMapPath"
        '
        'report_issue
        '
        Me.report_issue.AutoSize = True
        Me.report_issue.Location = New System.Drawing.Point(344, 304)
        Me.report_issue.Name = "report_issue"
        Me.report_issue.Size = New System.Drawing.Size(67, 13)
        Me.report_issue.TabIndex = 15
        Me.report_issue.TabStop = True
        Me.report_issue.Text = "Report Issue"
        '
        'checkVersion
        '
        Me.checkVersion.AutoSize = True
        Me.checkVersion.Location = New System.Drawing.Point(318, 286)
        Me.checkVersion.Name = "checkVersion"
        Me.checkVersion.Size = New System.Drawing.Size(94, 13)
        Me.checkVersion.TabIndex = 34
        Me.checkVersion.TabStop = True
        Me.checkVersion.Text = "Check For Update"
        '
        'TopGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 326)
        Me.Controls.Add(Me.checkVersion)
        Me.Controls.Add(Me.report_issue)
        Me.Controls.Add(Me.regMapPath_Label)
        Me.Controls.Add(Me.btn_plotData)
        Me.Controls.Add(Me.label_apiVersion)
        Me.Controls.Add(Me.btn_PinAccess)
        Me.Controls.Add(Me.btn_OtherApps)
        Me.Controls.Add(Me.btn_plotFFT)
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
        Me.Controls.Add(Me.btn_SelectDUT)
        Me.Controls.Add(Me.btn_ResetDUT)
        Me.Controls.Add(Me.label_DUTStatus)
        Me.Controls.Add(Me.text_DUTStatus)
        Me.Controls.Add(Me.btn_Connect)
        Me.Controls.Add(Me.label_FX3Status)
        Me.Controls.Add(Me.text_FX3Status)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(440, 365)
        Me.MinimumSize = New System.Drawing.Size(440, 365)
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
    Friend WithEvents btn_plotFFT As Button
    Friend WithEvents btn_OtherApps As Button
    Friend WithEvents btn_PinAccess As Button
    Friend WithEvents label_apiVersion As Label
    Friend WithEvents btn_plotData As Button
    Friend WithEvents regMapPath_Label As Label
    Friend WithEvents report_issue As LinkLabel
    Friend WithEvents checkVersion As LinkLabel
End Class
