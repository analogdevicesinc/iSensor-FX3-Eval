<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registerAccessGUI

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
        Me.newLabel = New System.Windows.Forms.Label()
        Me.selectPage = New System.Windows.Forms.ComboBox()
        Me.WriteButton = New System.Windows.Forms.Button()
        Me.curVal = New System.Windows.Forms.TextBox()
        Me.regView = New System.Windows.Forms.ListView()
        Me.readBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.refreshBtn = New System.Windows.Forms.CheckBox()
        Me.pageReadBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.newVal = New System.Windows.Forms.TextBox()
        Me.regLabel = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'newLabel
        '
        Me.newLabel.AutoSize = True
        Me.newLabel.Location = New System.Drawing.Point(437, 107)
        Me.newLabel.Name = "newLabel"
        Me.newLabel.Size = New System.Drawing.Size(62, 13)
        Me.newLabel.TabIndex = 1
        Me.newLabel.Text = "New Value:"
        '
        'selectPage
        '
        Me.selectPage.FormattingEnabled = True
        Me.selectPage.Location = New System.Drawing.Point(86, 8)
        Me.selectPage.Name = "selectPage"
        Me.selectPage.Size = New System.Drawing.Size(123, 21)
        Me.selectPage.TabIndex = 2
        '
        'WriteButton
        '
        Me.WriteButton.Location = New System.Drawing.Point(547, 134)
        Me.WriteButton.Name = "WriteButton"
        Me.WriteButton.Size = New System.Drawing.Size(75, 36)
        Me.WriteButton.TabIndex = 4
        Me.WriteButton.Text = "Write Selected"
        Me.WriteButton.UseVisualStyleBackColor = True
        '
        'curVal
        '
        Me.curVal.Location = New System.Drawing.Point(521, 74)
        Me.curVal.Name = "curVal"
        Me.curVal.Size = New System.Drawing.Size(101, 20)
        Me.curVal.TabIndex = 6
        '
        'regView
        '
        Me.regView.Location = New System.Drawing.Point(12, 48)
        Me.regView.Name = "regView"
        Me.regView.Size = New System.Drawing.Size(419, 300)
        Me.regView.TabIndex = 7
        Me.regView.UseCompatibleStateImageBehavior = False
        '
        'readBtn
        '
        Me.readBtn.Location = New System.Drawing.Point(440, 134)
        Me.readBtn.Name = "readBtn"
        Me.readBtn.Size = New System.Drawing.Size(75, 36)
        Me.readBtn.TabIndex = 8
        Me.readBtn.Text = "Read Selected"
        Me.readBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Select Page:"
        '
        'refreshBtn
        '
        Me.refreshBtn.AutoSize = True
        Me.refreshBtn.Location = New System.Drawing.Point(308, 10)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(104, 17)
        Me.refreshBtn.TabIndex = 10
        Me.refreshBtn.Text = "Periodic Refresh"
        Me.refreshBtn.UseVisualStyleBackColor = True
        '
        'pageReadBtn
        '
        Me.pageReadBtn.Location = New System.Drawing.Point(215, 6)
        Me.pageReadBtn.Name = "pageReadBtn"
        Me.pageReadBtn.Size = New System.Drawing.Size(75, 23)
        Me.pageReadBtn.TabIndex = 11
        Me.pageReadBtn.Text = "Read Page"
        Me.pageReadBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Current Value:"
        '
        'newVal
        '
        Me.newVal.Location = New System.Drawing.Point(521, 100)
        Me.newVal.Name = "newVal"
        Me.newVal.Size = New System.Drawing.Size(101, 20)
        Me.newVal.TabIndex = 13
        '
        'regLabel
        '
        Me.regLabel.Location = New System.Drawing.Point(521, 48)
        Me.regLabel.Name = "regLabel"
        Me.regLabel.Size = New System.Drawing.Size(101, 20)
        Me.regLabel.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Register:"
        '
        'registerAccessGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 362)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.regLabel)
        Me.Controls.Add(Me.newVal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pageReadBtn)
        Me.Controls.Add(Me.refreshBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.readBtn)
        Me.Controls.Add(Me.regView)
        Me.Controls.Add(Me.curVal)
        Me.Controls.Add(Me.WriteButton)
        Me.Controls.Add(Me.selectPage)
        Me.Controls.Add(Me.newLabel)
        Me.Name = "registerAccessGUI"
        Me.Text = "Register Access"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents newLabel As Label
    Friend WithEvents selectPage As ComboBox
    Friend WithEvents WriteButton As Button
    Friend WithEvents curVal As TextBox
    Friend WithEvents regView As ListView
    Friend WithEvents readBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents refreshBtn As CheckBox
    Friend WithEvents pageReadBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents newVal As TextBox
    Friend WithEvents regLabel As TextBox
    Friend WithEvents Label3 As Label
End Class
