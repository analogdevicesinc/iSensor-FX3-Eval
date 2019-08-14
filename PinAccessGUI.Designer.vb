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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ButtonWriteLow = New System.Windows.Forms.Button()
        Me.ButtonWriteHigh = New System.Windows.Forms.Button()
        Me.ButtonReadAll = New System.Windows.Forms.Button()
        Me.dgvPinList = New System.Windows.Forms.DataGridView()
        Me.ButtonPulseDrive = New System.Windows.Forms.Button()
        Me.ComboBoxMode = New System.Windows.Forms.ComboBox()
        Me.ComboBoxHighLow = New System.Windows.Forms.ComboBox()
        Me.LabelMode = New System.Windows.Forms.Label()
        Me.LabelPeriod = New System.Windows.Forms.Label()
        Me.TextBoxPeriod = New System.Windows.Forms.TextBox()
        Me.LabelHighLow = New System.Windows.Forms.Label()
        Me.ButtonReadSelected = New System.Windows.Forms.Button()
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonWriteLow
        '
        Me.ButtonWriteLow.Location = New System.Drawing.Point(216, 31)
        Me.ButtonWriteLow.Name = "ButtonWriteLow"
        Me.ButtonWriteLow.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteLow.TabIndex = 3
        Me.ButtonWriteLow.Text = "Write Low"
        Me.ButtonWriteLow.UseVisualStyleBackColor = True
        '
        'ButtonWriteHigh
        '
        Me.ButtonWriteHigh.Location = New System.Drawing.Point(216, 101)
        Me.ButtonWriteHigh.Name = "ButtonWriteHigh"
        Me.ButtonWriteHigh.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteHigh.TabIndex = 4
        Me.ButtonWriteHigh.Text = "Write High"
        Me.ButtonWriteHigh.UseVisualStyleBackColor = True
        '
        'ButtonReadAll
        '
        Me.ButtonReadAll.Location = New System.Drawing.Point(216, 171)
        Me.ButtonReadAll.Name = "ButtonReadAll"
        Me.ButtonReadAll.Size = New System.Drawing.Size(75, 64)
        Me.ButtonReadAll.TabIndex = 5
        Me.ButtonReadAll.Text = "Read All"
        Me.ButtonReadAll.UseVisualStyleBackColor = True
        '
        'dgvPinList
        '
        Me.dgvPinList.AllowUserToAddRows = False
        Me.dgvPinList.AllowUserToDeleteRows = False
        Me.dgvPinList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPinList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPinList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPinList.Location = New System.Drawing.Point(7, 31)
        Me.dgvPinList.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvPinList.MultiSelect = False
        Me.dgvPinList.Name = "dgvPinList"
        Me.dgvPinList.ReadOnly = True
        Me.dgvPinList.RowHeadersVisible = False
        Me.dgvPinList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPinList.RowTemplate.Height = 24
        Me.dgvPinList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPinList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPinList.Size = New System.Drawing.Size(178, 285)
        Me.dgvPinList.TabIndex = 6
        '
        'ButtonPulseDrive
        '
        Me.ButtonPulseDrive.Location = New System.Drawing.Point(371, 171)
        Me.ButtonPulseDrive.Name = "ButtonPulseDrive"
        Me.ButtonPulseDrive.Size = New System.Drawing.Size(75, 64)
        Me.ButtonPulseDrive.TabIndex = 17
        Me.ButtonPulseDrive.Text = "Pulse Drive"
        Me.ButtonPulseDrive.UseVisualStyleBackColor = True
        '
        'ComboBoxMode
        '
        Me.ComboBoxMode.FormattingEnabled = True
        Me.ComboBoxMode.Location = New System.Drawing.Point(387, 127)
        Me.ComboBoxMode.Name = "ComboBoxMode"
        Me.ComboBoxMode.Size = New System.Drawing.Size(126, 21)
        Me.ComboBoxMode.TabIndex = 16
        '
        'ComboBoxHighLow
        '
        Me.ComboBoxHighLow.FormattingEnabled = True
        Me.ComboBoxHighLow.Location = New System.Drawing.Point(387, 74)
        Me.ComboBoxHighLow.Name = "ComboBoxHighLow"
        Me.ComboBoxHighLow.Size = New System.Drawing.Size(126, 21)
        Me.ComboBoxHighLow.TabIndex = 15
        '
        'LabelMode
        '
        Me.LabelMode.AutoSize = True
        Me.LabelMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMode.Location = New System.Drawing.Point(338, 127)
        Me.LabelMode.Name = "LabelMode"
        Me.LabelMode.Size = New System.Drawing.Size(43, 16)
        Me.LabelMode.TabIndex = 14
        Me.LabelMode.Text = "Mode"
        '
        'LabelPeriod
        '
        Me.LabelPeriod.AutoSize = True
        Me.LabelPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPeriod.Location = New System.Drawing.Point(304, 101)
        Me.LabelPeriod.Name = "LabelPeriod"
        Me.LabelPeriod.Size = New System.Drawing.Size(77, 16)
        Me.LabelPeriod.TabIndex = 13
        Me.LabelPeriod.Text = "Period (ms)"
        '
        'TextBoxPeriod
        '
        Me.TextBoxPeriod.Location = New System.Drawing.Point(387, 101)
        Me.TextBoxPeriod.Name = "TextBoxPeriod"
        Me.TextBoxPeriod.Size = New System.Drawing.Size(126, 20)
        Me.TextBoxPeriod.TabIndex = 12
        '
        'LabelHighLow
        '
        Me.LabelHighLow.AutoSize = True
        Me.LabelHighLow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHighLow.Location = New System.Drawing.Point(317, 75)
        Me.LabelHighLow.Name = "LabelHighLow"
        Me.LabelHighLow.Size = New System.Drawing.Size(64, 16)
        Me.LabelHighLow.TabIndex = 11
        Me.LabelHighLow.Text = "High/Low"
        '
        'ButtonReadSelected
        '
        Me.ButtonReadSelected.Location = New System.Drawing.Point(216, 241)
        Me.ButtonReadSelected.Name = "ButtonReadSelected"
        Me.ButtonReadSelected.Size = New System.Drawing.Size(75, 64)
        Me.ButtonReadSelected.TabIndex = 18
        Me.ButtonReadSelected.Text = "Read Selected"
        Me.ButtonReadSelected.UseVisualStyleBackColor = True
        '
        'PinAccessGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 327)
        Me.Controls.Add(Me.ButtonReadSelected)
        Me.Controls.Add(Me.ButtonPulseDrive)
        Me.Controls.Add(Me.ComboBoxMode)
        Me.Controls.Add(Me.ComboBoxHighLow)
        Me.Controls.Add(Me.LabelMode)
        Me.Controls.Add(Me.LabelPeriod)
        Me.Controls.Add(Me.TextBoxPeriod)
        Me.Controls.Add(Me.LabelHighLow)
        Me.Controls.Add(Me.dgvPinList)
        Me.Controls.Add(Me.ButtonReadAll)
        Me.Controls.Add(Me.ButtonWriteHigh)
        Me.Controls.Add(Me.ButtonWriteLow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "PinAccessGUI"
        Me.Text = "PinAccessGUI"
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonWriteLow As Button
    Friend WithEvents ButtonWriteHigh As Button
    Friend WithEvents ButtonReadAll As Button
    Friend WithEvents dgvPinList As DataGridView
    Friend WithEvents ButtonPulseDrive As Button
    Friend WithEvents ComboBoxMode As ComboBox
    Friend WithEvents ComboBoxHighLow As ComboBox
    Friend WithEvents LabelMode As Label
    Friend WithEvents LabelPeriod As Label
    Friend WithEvents TextBoxPeriod As TextBox
    Friend WithEvents LabelHighLow As Label
    Friend WithEvents ButtonReadSelected As Button
End Class
