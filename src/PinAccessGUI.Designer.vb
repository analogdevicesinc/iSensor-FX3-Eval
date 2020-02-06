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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ButtonWriteLow = New System.Windows.Forms.Button()
        Me.ButtonWriteHigh = New System.Windows.Forms.Button()
        Me.ButtonReadAll = New System.Windows.Forms.Button()
        Me.dgvPinList = New System.Windows.Forms.DataGridView()
        Me.ButtonPulseDrive = New System.Windows.Forms.Button()
        Me.ComboBoxHighLow = New System.Windows.Forms.ComboBox()
        Me.LabelPeriod = New System.Windows.Forms.Label()
        Me.TextBoxPeriod = New System.Windows.Forms.TextBox()
        Me.LabelHighLow = New System.Windows.Forms.Label()
        Me.ButtonReadSelected = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonWriteLow
        '
        Me.ButtonWriteLow.Location = New System.Drawing.Point(197, 11)
        Me.ButtonWriteLow.Name = "ButtonWriteLow"
        Me.ButtonWriteLow.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteLow.TabIndex = 3
        Me.ButtonWriteLow.Text = "Write Low"
        Me.ButtonWriteLow.UseVisualStyleBackColor = True
        '
        'ButtonWriteHigh
        '
        Me.ButtonWriteHigh.Location = New System.Drawing.Point(197, 85)
        Me.ButtonWriteHigh.Name = "ButtonWriteHigh"
        Me.ButtonWriteHigh.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteHigh.TabIndex = 4
        Me.ButtonWriteHigh.Text = "Write High"
        Me.ButtonWriteHigh.UseVisualStyleBackColor = True
        '
        'ButtonReadAll
        '
        Me.ButtonReadAll.Location = New System.Drawing.Point(197, 159)
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPinList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPinList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPinList.Location = New System.Drawing.Point(11, 11)
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
        Me.ButtonPulseDrive.Location = New System.Drawing.Point(76, 96)
        Me.ButtonPulseDrive.Name = "ButtonPulseDrive"
        Me.ButtonPulseDrive.Size = New System.Drawing.Size(75, 64)
        Me.ButtonPulseDrive.TabIndex = 17
        Me.ButtonPulseDrive.Text = "Pulse Drive"
        Me.ButtonPulseDrive.UseVisualStyleBackColor = True
        '
        'ComboBoxHighLow
        '
        Me.ComboBoxHighLow.FormattingEnabled = True
        Me.ComboBoxHighLow.Location = New System.Drawing.Point(74, 29)
        Me.ComboBoxHighLow.Name = "ComboBoxHighLow"
        Me.ComboBoxHighLow.Size = New System.Drawing.Size(126, 21)
        Me.ComboBoxHighLow.TabIndex = 15
        '
        'LabelPeriod
        '
        Me.LabelPeriod.AutoSize = True
        Me.LabelPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabelPeriod.Location = New System.Drawing.Point(6, 63)
        Me.LabelPeriod.Name = "LabelPeriod"
        Me.LabelPeriod.Size = New System.Drawing.Size(62, 13)
        Me.LabelPeriod.TabIndex = 13
        Me.LabelPeriod.Text = "Period (ms):"
        '
        'TextBoxPeriod
        '
        Me.TextBoxPeriod.Location = New System.Drawing.Point(74, 60)
        Me.TextBoxPeriod.Name = "TextBoxPeriod"
        Me.TextBoxPeriod.Size = New System.Drawing.Size(126, 20)
        Me.TextBoxPeriod.TabIndex = 12
        '
        'LabelHighLow
        '
        Me.LabelHighLow.AutoSize = True
        Me.LabelHighLow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabelHighLow.Location = New System.Drawing.Point(6, 32)
        Me.LabelHighLow.Name = "LabelHighLow"
        Me.LabelHighLow.Size = New System.Drawing.Size(57, 13)
        Me.LabelHighLow.TabIndex = 11
        Me.LabelHighLow.Text = "High/Low:"
        '
        'ButtonReadSelected
        '
        Me.ButtonReadSelected.Location = New System.Drawing.Point(197, 232)
        Me.ButtonReadSelected.Name = "ButtonReadSelected"
        Me.ButtonReadSelected.Size = New System.Drawing.Size(75, 64)
        Me.ButtonReadSelected.TabIndex = 18
        Me.ButtonReadSelected.Text = "Read Selected"
        Me.ButtonReadSelected.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxPeriod)
        Me.GroupBox1.Controls.Add(Me.LabelHighLow)
        Me.GroupBox1.Controls.Add(Me.ButtonPulseDrive)
        Me.GroupBox1.Controls.Add(Me.LabelPeriod)
        Me.GroupBox1.Controls.Add(Me.ComboBoxHighLow)
        Me.GroupBox1.Location = New System.Drawing.Point(281, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(218, 175)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pulse Drive"
        '
        'PinAccessGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 311)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonReadSelected)
        Me.Controls.Add(Me.dgvPinList)
        Me.Controls.Add(Me.ButtonReadAll)
        Me.Controls.Add(Me.ButtonWriteHigh)
        Me.Controls.Add(Me.ButtonWriteLow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximumSize = New System.Drawing.Size(530, 350)
        Me.MinimumSize = New System.Drawing.Size(530, 350)
        Me.Name = "PinAccessGUI"
        Me.Text = "Pin Access"
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonWriteLow As Button
    Friend WithEvents ButtonWriteHigh As Button
    Friend WithEvents ButtonReadAll As Button
    Friend WithEvents dgvPinList As DataGridView
    Friend WithEvents ButtonPulseDrive As Button
    Friend WithEvents ComboBoxHighLow As ComboBox
    Friend WithEvents LabelPeriod As Label
    Friend WithEvents TextBoxPeriod As TextBox
    Friend WithEvents LabelHighLow As Label
    Friend WithEvents ButtonReadSelected As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
