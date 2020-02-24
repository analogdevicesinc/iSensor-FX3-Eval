<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterGUI

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegisterGUI))
        Me.ButtonWrite = New System.Windows.Forms.Button()
        Me.regView = New System.Windows.Forms.DataGridView()
        Me.Label = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Page = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contents = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.newValue = New System.Windows.Forms.TextBox()
        Me.writeLabel = New System.Windows.Forms.Label()
        Me.readLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonRead = New System.Windows.Forms.Button()
        Me.scaledData = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.selectPage = New System.Windows.Forms.ComboBox()
        Me.DrFreq = New System.Windows.Forms.Label()
        Me.contRead = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.measureDr = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn_DumpRegmap = New System.Windows.Forms.Button()
        Me.drActive = New System.Windows.Forms.CheckBox()
        Me.CurrentValue = New System.Windows.Forms.TextBox()
        CType(Me.regView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonWrite
        '
        Me.ButtonWrite.Location = New System.Drawing.Point(100, 80)
        Me.ButtonWrite.Name = "ButtonWrite"
        Me.ButtonWrite.Size = New System.Drawing.Size(61, 21)
        Me.ButtonWrite.TabIndex = 7
        Me.ButtonWrite.Text = "WRITE"
        Me.ButtonWrite.UseVisualStyleBackColor = True
        '
        'regView
        '
        Me.regView.AllowUserToAddRows = False
        Me.regView.AllowUserToDeleteRows = False
        Me.regView.BackgroundColor = System.Drawing.Color.White
        Me.regView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.regView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Label, Me.Page, Me.Address, Me.Contents})
        Me.regView.Location = New System.Drawing.Point(11, 42)
        Me.regView.Margin = New System.Windows.Forms.Padding(2)
        Me.regView.MultiSelect = False
        Me.regView.Name = "regView"
        Me.regView.ReadOnly = True
        Me.regView.RowHeadersVisible = False
        Me.regView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.regView.RowTemplate.Height = 24
        Me.regView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.regView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.regView.Size = New System.Drawing.Size(385, 487)
        Me.regView.TabIndex = 2
        '
        'Label
        '
        Me.Label.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Label.HeaderText = "Label"
        Me.Label.Name = "Label"
        Me.Label.ReadOnly = True
        Me.Label.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Label.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Page
        '
        Me.Page.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Page.HeaderText = "Page"
        Me.Page.Name = "Page"
        Me.Page.ReadOnly = True
        Me.Page.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Page.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Page.Width = 35
        '
        'Address
        '
        Me.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Address.Width = 50
        '
        'Contents
        '
        Me.Contents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Contents.HeaderText = "Contents"
        Me.Contents.Name = "Contents"
        Me.Contents.ReadOnly = True
        Me.Contents.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Contents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Contents.Width = 110
        '
        'newValue
        '
        Me.newValue.Location = New System.Drawing.Point(13, 80)
        Me.newValue.Name = "newValue"
        Me.newValue.Size = New System.Drawing.Size(72, 20)
        Me.newValue.TabIndex = 10
        Me.newValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'writeLabel
        '
        Me.writeLabel.AutoSize = True
        Me.writeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.writeLabel.Location = New System.Drawing.Point(10, 64)
        Me.writeLabel.Name = "writeLabel"
        Me.writeLabel.Size = New System.Drawing.Size(94, 13)
        Me.writeLabel.TabIndex = 11
        Me.writeLabel.Text = "New Hex Value"
        '
        'readLabel
        '
        Me.readLabel.AutoSize = True
        Me.readLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.readLabel.Location = New System.Drawing.Point(10, 16)
        Me.readLabel.Name = "readLabel"
        Me.readLabel.Size = New System.Drawing.Size(110, 13)
        Me.readLabel.TabIndex = 15
        Me.readLabel.Text = "Current Hex Value"
        '
        'ButtonRead
        '
        Me.ButtonRead.Location = New System.Drawing.Point(120, 19)
        Me.ButtonRead.Name = "ButtonRead"
        Me.ButtonRead.Size = New System.Drawing.Size(80, 59)
        Me.ButtonRead.TabIndex = 17
        Me.ButtonRead.Text = "Read"
        Me.ButtonRead.UseVisualStyleBackColor = True
        '
        'scaledData
        '
        Me.scaledData.AutoSize = True
        Me.scaledData.Location = New System.Drawing.Point(9, 51)
        Me.scaledData.Name = "scaledData"
        Me.scaledData.Size = New System.Drawing.Size(79, 17)
        Me.scaledData.TabIndex = 20
        Me.scaledData.Text = "Scale Data"
        Me.scaledData.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Select a Page"
        '
        'selectPage
        '
        Me.selectPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selectPage.FormattingEnabled = True
        Me.selectPage.Location = New System.Drawing.Point(100, 9)
        Me.selectPage.Margin = New System.Windows.Forms.Padding(2)
        Me.selectPage.Name = "selectPage"
        Me.selectPage.Size = New System.Drawing.Size(159, 21)
        Me.selectPage.TabIndex = 21
        '
        'DrFreq
        '
        Me.DrFreq.AutoSize = True
        Me.DrFreq.Location = New System.Drawing.Point(6, 39)
        Me.DrFreq.Name = "DrFreq"
        Me.DrFreq.Size = New System.Drawing.Size(112, 13)
        Me.DrFreq.TabIndex = 25
        Me.DrFreq.Text = "Analyzing Data Ready"
        '
        'contRead
        '
        Me.contRead.AutoSize = True
        Me.contRead.Location = New System.Drawing.Point(9, 30)
        Me.contRead.Name = "contRead"
        Me.contRead.Size = New System.Drawing.Size(113, 17)
        Me.contRead.TabIndex = 26
        Me.contRead.Text = "Continuous Reads"
        Me.contRead.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.measureDr)
        Me.GroupBox3.Controls.Add(Me.DrFreq)
        Me.GroupBox3.Location = New System.Drawing.Point(401, 238)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 63)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Ready"
        '
        'measureDr
        '
        Me.measureDr.AutoSize = True
        Me.measureDr.Location = New System.Drawing.Point(9, 19)
        Me.measureDr.Name = "measureDr"
        Me.measureDr.Size = New System.Drawing.Size(127, 17)
        Me.measureDr.TabIndex = 27
        Me.measureDr.Text = "Measure Data Ready"
        Me.measureDr.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CurrentValue)
        Me.GroupBox4.Controls.Add(Me.readLabel)
        Me.GroupBox4.Controls.Add(Me.writeLabel)
        Me.GroupBox4.Controls.Add(Me.newValue)
        Me.GroupBox4.Controls.Add(Me.ButtonWrite)
        Me.GroupBox4.Location = New System.Drawing.Point(401, 110)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(211, 122)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selected Register"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ButtonRead)
        Me.GroupBox5.Controls.Add(Me.contRead)
        Me.GroupBox5.Controls.Add(Me.scaledData)
        Me.GroupBox5.Location = New System.Drawing.Point(401, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(209, 92)
        Me.GroupBox5.TabIndex = 29
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Control"
        '
        'btn_DumpRegmap
        '
        Me.btn_DumpRegmap.Location = New System.Drawing.Point(464, 482)
        Me.btn_DumpRegmap.Name = "btn_DumpRegmap"
        Me.btn_DumpRegmap.Size = New System.Drawing.Size(83, 47)
        Me.btn_DumpRegmap.TabIndex = 30
        Me.btn_DumpRegmap.Text = "Dump RegMap"
        Me.btn_DumpRegmap.UseVisualStyleBackColor = True
        '
        'drActive
        '
        Me.drActive.AutoSize = True
        Me.drActive.Location = New System.Drawing.Point(410, 307)
        Me.drActive.Name = "drActive"
        Me.drActive.Size = New System.Drawing.Size(145, 17)
        Me.drActive.TabIndex = 31
        Me.drActive.Text = "DR Sync Register Reads"
        Me.drActive.UseVisualStyleBackColor = True
        '
        'CurrentValue
        '
        Me.CurrentValue.BackColor = System.Drawing.SystemColors.Window
        Me.CurrentValue.Location = New System.Drawing.Point(13, 37)
        Me.CurrentValue.Name = "CurrentValue"
        Me.CurrentValue.ReadOnly = True
        Me.CurrentValue.Size = New System.Drawing.Size(72, 20)
        Me.CurrentValue.TabIndex = 16
        Me.CurrentValue.Text = "Not Read"
        Me.CurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RegisterGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 538)
        Me.Controls.Add(Me.drActive)
        Me.Controls.Add(Me.btn_DumpRegmap)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.selectPage)
        Me.Controls.Add(Me.regView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximumSize = New System.Drawing.Size(640, 1000)
        Me.MinimumSize = New System.Drawing.Size(640, 440)
        Me.Name = "RegisterGUI"
        Me.Text = "Register Access"
        CType(Me.regView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonWrite As System.Windows.Forms.Button
    Friend WithEvents regView As System.Windows.Forms.DataGridView
    Friend WithEvents newValue As System.Windows.Forms.TextBox
    Friend WithEvents writeLabel As System.Windows.Forms.Label
    Friend WithEvents readLabel As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ButtonRead As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents selectPage As System.Windows.Forms.ComboBox
    Friend WithEvents Label As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Page As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Contents As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrFreq As System.Windows.Forms.Label
    Friend WithEvents contRead As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents scaledData As CheckBox
    Friend WithEvents measureDr As CheckBox
    Friend WithEvents btn_DumpRegmap As Button
    Friend WithEvents drActive As CheckBox
    Friend WithEvents CurrentValue As TextBox
End Class
