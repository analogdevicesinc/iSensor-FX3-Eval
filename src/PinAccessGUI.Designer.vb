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
        Me.ComboBoxHighLow = New System.Windows.Forms.ComboBox()
        Me.LabelPeriod = New System.Windows.Forms.Label()
        Me.TextBoxPeriod = New System.Windows.Forms.TextBox()
        Me.LabelHighLow = New System.Windows.Forms.Label()
        Me.ButtonReadSelected = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GPIO_Value = New System.Windows.Forms.TextBox()
        Me.btn_ReadGPIO = New System.Windows.Forms.Button()
        Me.btn_SetGPIOHigh = New System.Windows.Forms.Button()
        Me.btn_SetGPIOLow = New System.Windows.Forms.Button()
        Me.GPIO_Num = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonWriteLow
        '
        Me.ButtonWriteLow.Location = New System.Drawing.Point(197, 85)
        Me.ButtonWriteLow.Name = "ButtonWriteLow"
        Me.ButtonWriteLow.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteLow.TabIndex = 3
        Me.ButtonWriteLow.Text = "Write Low"
        Me.ButtonWriteLow.UseVisualStyleBackColor = True
        '
        'ButtonWriteHigh
        '
        Me.ButtonWriteHigh.Location = New System.Drawing.Point(197, 10)
        Me.ButtonWriteHigh.Name = "ButtonWriteHigh"
        Me.ButtonWriteHigh.Size = New System.Drawing.Size(75, 64)
        Me.ButtonWriteHigh.TabIndex = 4
        Me.ButtonWriteHigh.Text = "Write High"
        Me.ButtonWriteHigh.UseVisualStyleBackColor = True
        '
        'ButtonReadAll
        '
        Me.ButtonReadAll.Location = New System.Drawing.Point(197, 160)
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
        Me.ButtonPulseDrive.Location = New System.Drawing.Point(75, 78)
        Me.ButtonPulseDrive.Name = "ButtonPulseDrive"
        Me.ButtonPulseDrive.Size = New System.Drawing.Size(75, 40)
        Me.ButtonPulseDrive.TabIndex = 17
        Me.ButtonPulseDrive.Text = "Pulse Drive"
        Me.ButtonPulseDrive.UseVisualStyleBackColor = True
        '
        'ComboBoxHighLow
        '
        Me.ComboBoxHighLow.FormattingEnabled = True
        Me.ComboBoxHighLow.Location = New System.Drawing.Point(74, 22)
        Me.ComboBoxHighLow.Name = "ComboBoxHighLow"
        Me.ComboBoxHighLow.Size = New System.Drawing.Size(130, 21)
        Me.ComboBoxHighLow.TabIndex = 15
        '
        'LabelPeriod
        '
        Me.LabelPeriod.AutoSize = True
        Me.LabelPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabelPeriod.Location = New System.Drawing.Point(6, 52)
        Me.LabelPeriod.Name = "LabelPeriod"
        Me.LabelPeriod.Size = New System.Drawing.Size(62, 13)
        Me.LabelPeriod.TabIndex = 13
        Me.LabelPeriod.Text = "Period (ms):"
        '
        'TextBoxPeriod
        '
        Me.TextBoxPeriod.Location = New System.Drawing.Point(74, 49)
        Me.TextBoxPeriod.Name = "TextBoxPeriod"
        Me.TextBoxPeriod.Size = New System.Drawing.Size(130, 20)
        Me.TextBoxPeriod.TabIndex = 12
        '
        'LabelHighLow
        '
        Me.LabelHighLow.AutoSize = True
        Me.LabelHighLow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabelHighLow.Location = New System.Drawing.Point(6, 24)
        Me.LabelHighLow.Name = "LabelHighLow"
        Me.LabelHighLow.Size = New System.Drawing.Size(57, 13)
        Me.LabelHighLow.TabIndex = 11
        Me.LabelHighLow.Text = "High/Low:"
        '
        'ButtonReadSelected
        '
        Me.ButtonReadSelected.Location = New System.Drawing.Point(197, 233)
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
        Me.GroupBox1.Size = New System.Drawing.Size(218, 128)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pulse Drive"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.GPIO_Value)
        Me.GroupBox2.Controls.Add(Me.btn_ReadGPIO)
        Me.GroupBox2.Controls.Add(Me.btn_SetGPIOHigh)
        Me.GroupBox2.Controls.Add(Me.btn_SetGPIOLow)
        Me.GroupBox2.Controls.Add(Me.GPIO_Num)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(281, 146)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(218, 153)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GPIO Pin Access"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Pin Value:"
        '
        'GPIO_Value
        '
        Me.GPIO_Value.Location = New System.Drawing.Point(9, 120)
        Me.GPIO_Value.Name = "GPIO_Value"
        Me.GPIO_Value.Size = New System.Drawing.Size(75, 20)
        Me.GPIO_Value.TabIndex = 21
        '
        'btn_ReadGPIO
        '
        Me.btn_ReadGPIO.Location = New System.Drawing.Point(9, 51)
        Me.btn_ReadGPIO.Name = "btn_ReadGPIO"
        Me.btn_ReadGPIO.Size = New System.Drawing.Size(75, 40)
        Me.btn_ReadGPIO.TabIndex = 20
        Me.btn_ReadGPIO.Text = "Read Pin"
        Me.btn_ReadGPIO.UseVisualStyleBackColor = True
        '
        'btn_SetGPIOHigh
        '
        Me.btn_SetGPIOHigh.Location = New System.Drawing.Point(129, 51)
        Me.btn_SetGPIOHigh.Name = "btn_SetGPIOHigh"
        Me.btn_SetGPIOHigh.Size = New System.Drawing.Size(75, 40)
        Me.btn_SetGPIOHigh.TabIndex = 19
        Me.btn_SetGPIOHigh.Text = "Write High"
        Me.btn_SetGPIOHigh.UseVisualStyleBackColor = True
        '
        'btn_SetGPIOLow
        '
        Me.btn_SetGPIOLow.Location = New System.Drawing.Point(129, 100)
        Me.btn_SetGPIOLow.Name = "btn_SetGPIOLow"
        Me.btn_SetGPIOLow.Size = New System.Drawing.Size(75, 40)
        Me.btn_SetGPIOLow.TabIndex = 18
        Me.btn_SetGPIOLow.Text = "Write Low"
        Me.btn_SetGPIOLow.UseVisualStyleBackColor = True
        '
        'GPIO_Num
        '
        Me.GPIO_Num.Location = New System.Drawing.Point(88, 23)
        Me.GPIO_Num.Name = "GPIO_Num"
        Me.GPIO_Num.Size = New System.Drawing.Size(116, 20)
        Me.GPIO_Num.TabIndex = 12
        Me.GPIO_Num.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "GPIO Number:"
        '
        'PinAccessGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 311)
        Me.Controls.Add(Me.GroupBox2)
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GPIO_Value As TextBox
    Friend WithEvents btn_ReadGPIO As Button
    Friend WithEvents btn_SetGPIOHigh As Button
    Friend WithEvents btn_SetGPIOLow As Button
    Friend WithEvents GPIO_Num As TextBox
    Friend WithEvents Label1 As Label
End Class
