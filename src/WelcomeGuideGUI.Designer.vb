<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeGuideGUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeGuideGUI))
        Me.displayImage = New System.Windows.Forms.PictureBox()
        Me.btn_Next = New System.Windows.Forms.Button()
        Me.btn_prev = New System.Windows.Forms.Button()
        Me.check_doNotShow = New System.Windows.Forms.CheckBox()
        Me.messageText = New System.Windows.Forms.Label()
        Me.wikiLink = New System.Windows.Forms.LinkLabel()
        Me.slideNum = New System.Windows.Forms.Label()
        CType(Me.displayImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'displayImage
        '
        Me.displayImage.Location = New System.Drawing.Point(10, 114)
        Me.displayImage.Name = "displayImage"
        Me.displayImage.Size = New System.Drawing.Size(725, 459)
        Me.displayImage.TabIndex = 0
        Me.displayImage.TabStop = False
        '
        'btn_Next
        '
        Me.btn_Next.Location = New System.Drawing.Point(592, 579)
        Me.btn_Next.Name = "btn_Next"
        Me.btn_Next.Size = New System.Drawing.Size(75, 22)
        Me.btn_Next.TabIndex = 2
        Me.btn_Next.Text = "Next ->"
        Me.btn_Next.UseVisualStyleBackColor = True
        '
        'btn_prev
        '
        Me.btn_prev.Location = New System.Drawing.Point(511, 579)
        Me.btn_prev.Name = "btn_prev"
        Me.btn_prev.Size = New System.Drawing.Size(75, 22)
        Me.btn_prev.TabIndex = 3
        Me.btn_prev.Text = "<- Previous"
        Me.btn_prev.UseVisualStyleBackColor = True
        '
        'check_doNotShow
        '
        Me.check_doNotShow.AutoSize = True
        Me.check_doNotShow.Location = New System.Drawing.Point(385, 583)
        Me.check_doNotShow.Name = "check_doNotShow"
        Me.check_doNotShow.Size = New System.Drawing.Size(120, 17)
        Me.check_doNotShow.TabIndex = 4
        Me.check_doNotShow.Text = "Do Not Show Again"
        Me.check_doNotShow.UseVisualStyleBackColor = True
        '
        'messageText
        '
        Me.messageText.Location = New System.Drawing.Point(7, 9)
        Me.messageText.Name = "messageText"
        Me.messageText.Size = New System.Drawing.Size(728, 102)
        Me.messageText.TabIndex = 5
        Me.messageText.Text = "Label1"
        '
        'wikiLink
        '
        Me.wikiLink.AutoSize = True
        Me.wikiLink.Location = New System.Drawing.Point(7, 584)
        Me.wikiLink.Name = "wikiLink"
        Me.wikiLink.Size = New System.Drawing.Size(108, 13)
        Me.wikiLink.TabIndex = 6
        Me.wikiLink.TabStop = True
        Me.wikiLink.Text = "EVAL-ADIS-FX3 Wiki"
        '
        'slideNum
        '
        Me.slideNum.AutoSize = True
        Me.slideNum.Location = New System.Drawing.Point(673, 584)
        Me.slideNum.Name = "slideNum"
        Me.slideNum.Size = New System.Drawing.Size(62, 13)
        Me.slideNum.TabIndex = 7
        Me.slideNum.Text = "Slide 10/10"
        Me.slideNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WelcomeGuideGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 611)
        Me.Controls.Add(Me.slideNum)
        Me.Controls.Add(Me.wikiLink)
        Me.Controls.Add(Me.messageText)
        Me.Controls.Add(Me.check_doNotShow)
        Me.Controls.Add(Me.btn_prev)
        Me.Controls.Add(Me.btn_Next)
        Me.Controls.Add(Me.displayImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WelcomeGuideGUI"
        Me.Text = "iSensor FX3 Eval Setup Guide"
        CType(Me.displayImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents displayImage As PictureBox
    Friend WithEvents btn_Next As Button
    Friend WithEvents btn_prev As Button
    Friend WithEvents check_doNotShow As CheckBox
    Friend WithEvents messageText As Label
    Friend WithEvents wikiLink As LinkLabel
    Friend WithEvents slideNum As Label
End Class
