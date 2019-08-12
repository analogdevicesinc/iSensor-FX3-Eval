<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PinAccessGUI

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
        Me.dgvPinList = New System.Windows.Forms.DataGridView()
        Me.ButtonWriteLow = New System.Windows.Forms.Button()
        Me.ButtonWriteHigh = New System.Windows.Forms.Button()
        Me.ButtonReadAll = New System.Windows.Forms.Button()
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPinList
        '
        Me.dgvPinList.AllowUserToAddRows = False
        Me.dgvPinList.AllowUserToDeleteRows = False
        Me.dgvPinList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPinList.Location = New System.Drawing.Point(10, 10)
        Me.dgvPinList.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvPinList.MultiSelect = False
        Me.dgvPinList.Name = "dgvPinList"
        Me.dgvPinList.ReadOnly = True
        Me.dgvPinList.RowHeadersVisible = False
        Me.dgvPinList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPinList.RowTemplate.Height = 24
        Me.dgvPinList.RowTemplate.ReadOnly = True
        Me.dgvPinList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPinList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPinList.Size = New System.Drawing.Size(204, 296)
        Me.dgvPinList.TabIndex = 2
        '
        'ButtonWriteLow
        '
        Me.ButtonWriteLow.Location = New System.Drawing.Point(244, 41)
        Me.ButtonWriteLow.Name = "ButtonWriteLow"
        Me.ButtonWriteLow.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteLow.TabIndex = 3
        Me.ButtonWriteLow.Text = "Write Low"
        Me.ButtonWriteLow.UseVisualStyleBackColor = True
        '
        'ButtonWriteHigh
        '
        Me.ButtonWriteHigh.Location = New System.Drawing.Point(244, 111)
        Me.ButtonWriteHigh.Name = "ButtonWriteHigh"
        Me.ButtonWriteHigh.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteHigh.TabIndex = 4
        Me.ButtonWriteHigh.Text = "Write High"
        Me.ButtonWriteHigh.UseVisualStyleBackColor = True
        '
        'ButtonReadAll
        '
        Me.ButtonReadAll.Location = New System.Drawing.Point(244, 181)
        Me.ButtonReadAll.Name = "ButtonReadAll"
        Me.ButtonReadAll.Size = New System.Drawing.Size(75, 64)
        Me.ButtonReadAll.TabIndex = 5
        Me.ButtonReadAll.Text = "Read All"
        Me.ButtonReadAll.UseVisualStyleBackColor = True
        '
        'PinAccessGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 353)
        Me.Controls.Add(Me.ButtonReadAll)
        Me.Controls.Add(Me.ButtonWriteHigh)
        Me.Controls.Add(Me.ButtonWriteLow)
        Me.Controls.Add(Me.dgvPinList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "PinAccessGUI"
        Me.Text = "PinAccessGUI"
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvPinList As DataGridView
    Friend WithEvents ButtonWriteLow As Button
    Friend WithEvents ButtonWriteHigh As Button
    Friend WithEvents ButtonReadAll As Button
End Class
