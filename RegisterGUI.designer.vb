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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CurrentValue = New System.Windows.Forms.Label()
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
        CType(Me.regView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonWrite
        '
        Me.ButtonWrite.Location = New System.Drawing.Point(267, 191)
        Me.ButtonWrite.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.ButtonWrite.Name = "ButtonWrite"
        Me.ButtonWrite.Size = New System.Drawing.Size(163, 50)
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
        Me.regView.Location = New System.Drawing.Point(29, 100)
        Me.regView.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.regView.MultiSelect = False
        Me.regView.Name = "regView"
        Me.regView.ReadOnly = True
        Me.regView.RowHeadersVisible = False
        Me.regView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.regView.RowTemplate.Height = 24
        Me.regView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.regView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.regView.Size = New System.Drawing.Size(1027, 1161)
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
        Me.newValue.Location = New System.Drawing.Point(35, 191)
        Me.newValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.newValue.Name = "newValue"
        Me.newValue.Size = New System.Drawing.Size(185, 38)
        Me.newValue.TabIndex = 10
        Me.newValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 153)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(222, 32)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "New Hex Value"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 38)
        Me.Label5.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(264, 32)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Current Hex Value"
        '
        'CurrentValue
        '
        Me.CurrentValue.BackColor = System.Drawing.Color.White
        Me.CurrentValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CurrentValue.Location = New System.Drawing.Point(35, 81)
        Me.CurrentValue.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.CurrentValue.Name = "CurrentValue"
        Me.CurrentValue.Size = New System.Drawing.Size(189, 45)
        Me.CurrentValue.TabIndex = 16
        Me.CurrentValue.Text = "Not Read"
        Me.CurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonRead
        '
        Me.ButtonRead.Location = New System.Drawing.Point(320, 45)
        Me.ButtonRead.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.ButtonRead.Name = "ButtonRead"
        Me.ButtonRead.Size = New System.Drawing.Size(213, 141)
        Me.ButtonRead.TabIndex = 17
        Me.ButtonRead.Text = "Read"
        Me.ButtonRead.UseVisualStyleBackColor = True
        '
        'scaledData
        '
        Me.scaledData.AutoSize = True
        Me.scaledData.Location = New System.Drawing.Point(24, 122)
        Me.scaledData.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.scaledData.Name = "scaledData"
        Me.scaledData.Size = New System.Drawing.Size(192, 36)
        Me.scaledData.TabIndex = 20
        Me.scaledData.Text = "Scale Data"
        Me.scaledData.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 29)
        Me.Label6.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(205, 32)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Select a Page"
        '
        'selectPage
        '
        Me.selectPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selectPage.FormattingEnabled = True
        Me.selectPage.Location = New System.Drawing.Point(267, 21)
        Me.selectPage.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.selectPage.Name = "selectPage"
        Me.selectPage.Size = New System.Drawing.Size(417, 39)
        Me.selectPage.TabIndex = 21
        '
        'DrFreq
        '
        Me.DrFreq.AutoSize = True
        Me.DrFreq.Location = New System.Drawing.Point(16, 93)
        Me.DrFreq.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.DrFreq.Name = "DrFreq"
        Me.DrFreq.Size = New System.Drawing.Size(296, 32)
        Me.DrFreq.TabIndex = 25
        Me.DrFreq.Text = "Analyzing Data Ready"
        '
        'contRead
        '
        Me.contRead.AutoSize = True
        Me.contRead.Location = New System.Drawing.Point(24, 72)
        Me.contRead.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.contRead.Name = "contRead"
        Me.contRead.Size = New System.Drawing.Size(287, 36)
        Me.contRead.TabIndex = 26
        Me.contRead.Text = "Continuous Reads"
        Me.contRead.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.measureDr)
        Me.GroupBox3.Controls.Add(Me.DrFreq)
        Me.GroupBox3.Location = New System.Drawing.Point(1069, 568)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox3.Size = New System.Drawing.Size(563, 150)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Ready"
        '
        'measureDr
        '
        Me.measureDr.AutoSize = True
        Me.measureDr.Location = New System.Drawing.Point(24, 45)
        Me.measureDr.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.measureDr.Name = "measureDr"
        Me.measureDr.Size = New System.Drawing.Size(319, 36)
        Me.measureDr.TabIndex = 27
        Me.measureDr.Text = "Measure Data Ready"
        Me.measureDr.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.CurrentValue)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.newValue)
        Me.GroupBox4.Controls.Add(Me.ButtonWrite)
        Me.GroupBox4.Location = New System.Drawing.Point(1069, 262)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox4.Size = New System.Drawing.Size(563, 291)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selected Register"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ButtonRead)
        Me.GroupBox5.Controls.Add(Me.contRead)
        Me.GroupBox5.Controls.Add(Me.scaledData)
        Me.GroupBox5.Location = New System.Drawing.Point(1069, 29)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox5.Size = New System.Drawing.Size(557, 219)
        Me.GroupBox5.TabIndex = 29
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Control"
        '
        'btn_DumpRegmap
        '
        Me.btn_DumpRegmap.Location = New System.Drawing.Point(1253, 1147)
        Me.btn_DumpRegmap.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_DumpRegmap.Name = "btn_DumpRegmap"
        Me.btn_DumpRegmap.Size = New System.Drawing.Size(221, 112)
        Me.btn_DumpRegmap.TabIndex = 30
        Me.btn_DumpRegmap.Text = "Dump RegMap"
        Me.btn_DumpRegmap.UseVisualStyleBackColor = True
        '
        'RegisterGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1659, 1288)
        Me.Controls.Add(Me.btn_DumpRegmap)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.selectPage)
        Me.Controls.Add(Me.regView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CurrentValue As System.Windows.Forms.Label
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
End Class
