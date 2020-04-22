<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BinaryFileWriterGUI

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
        Me.numBytes = New System.Windows.Forms.TextBox()
        Me.fillPattern = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_GenFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'numBytes
        '
        Me.numBytes.Location = New System.Drawing.Point(103, 12)
        Me.numBytes.Name = "numBytes"
        Me.numBytes.Size = New System.Drawing.Size(74, 20)
        Me.numBytes.TabIndex = 4
        Me.numBytes.Text = "64"
        '
        'fillPattern
        '
        Me.fillPattern.Location = New System.Drawing.Point(12, 51)
        Me.fillPattern.Name = "fillPattern"
        Me.fillPattern.Size = New System.Drawing.Size(220, 20)
        Me.fillPattern.TabIndex = 3
        Me.fillPattern.Text = "00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fill Pattern (hex):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Number of Bytes:"
        '
        'btn_GenFile
        '
        Me.btn_GenFile.Location = New System.Drawing.Point(77, 79)
        Me.btn_GenFile.Name = "btn_GenFile"
        Me.btn_GenFile.Size = New System.Drawing.Size(75, 64)
        Me.btn_GenFile.TabIndex = 0
        Me.btn_GenFile.Text = "Generate File"
        Me.btn_GenFile.UseVisualStyleBackColor = True
        '
        'BinaryFileWriterGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 151)
        Me.Controls.Add(Me.numBytes)
        Me.Controls.Add(Me.fillPattern)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_GenFile)
        Me.MaximumSize = New System.Drawing.Size(500, 190)
        Me.MinimumSize = New System.Drawing.Size(200, 190)
        Me.Name = "BinaryFileWriterGUI"
        Me.Text = "Binary File Writer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_GenFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents fillPattern As TextBox
    Friend WithEvents numBytes As TextBox
End Class
