<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataPlotGUI

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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.regView = New System.Windows.Forms.DataGridView()
        Me.Label = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Page = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contents = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plot = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Offset = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sampleFreq = New System.Windows.Forms.TextBox()
        Me.btn_startStop = New System.Windows.Forms.Button()
        Me.dataPlot = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.samplesRendered = New System.Windows.Forms.TextBox()
        Me.btn_autonull = New System.Windows.Forms.Button()
        Me.logToCSV = New System.Windows.Forms.CheckBox()
        Me.saveChart = New System.Windows.Forms.Button()
        Me.playFromCSV = New System.Windows.Forms.Button()
        CType(Me.regView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'regView
        '
        Me.regView.AllowUserToAddRows = False
        Me.regView.AllowUserToDeleteRows = False
        Me.regView.BackgroundColor = System.Drawing.Color.White
        Me.regView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.regView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Label, Me.Page, Me.Address, Me.Contents, Me.Plot, Me.Offset})
        Me.regView.Location = New System.Drawing.Point(11, 89)
        Me.regView.Margin = New System.Windows.Forms.Padding(2)
        Me.regView.MultiSelect = False
        Me.regView.Name = "regView"
        Me.regView.RowHeadersVisible = False
        Me.regView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.regView.RowTemplate.Height = 24
        Me.regView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.regView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.regView.Size = New System.Drawing.Size(494, 413)
        Me.regView.TabIndex = 3
        '
        'Label
        '
        Me.Label.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Label.HeaderText = "Label"
        Me.Label.Name = "Label"
        Me.Label.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Label.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Page
        '
        Me.Page.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Page.HeaderText = "Page"
        Me.Page.Name = "Page"
        Me.Page.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Page.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Page.Width = 35
        '
        'Address
        '
        Me.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Address.Width = 50
        '
        'Contents
        '
        Me.Contents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Contents.HeaderText = "Contents"
        Me.Contents.Name = "Contents"
        Me.Contents.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Contents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Plot
        '
        Me.Plot.HeaderText = "Plot"
        Me.Plot.Name = "Plot"
        Me.Plot.Width = 35
        '
        'Offset
        '
        Me.Offset.HeaderText = "Offset"
        Me.Offset.Name = "Offset"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sample Frequency (Hz) :"
        '
        'sampleFreq
        '
        Me.sampleFreq.Location = New System.Drawing.Point(141, 6)
        Me.sampleFreq.Name = "sampleFreq"
        Me.sampleFreq.Size = New System.Drawing.Size(143, 20)
        Me.sampleFreq.TabIndex = 5
        '
        'btn_startStop
        '
        Me.btn_startStop.Location = New System.Drawing.Point(323, 6)
        Me.btn_startStop.Name = "btn_startStop"
        Me.btn_startStop.Size = New System.Drawing.Size(88, 35)
        Me.btn_startStop.TabIndex = 6
        Me.btn_startStop.Text = "Start Plotting"
        Me.btn_startStop.UseVisualStyleBackColor = True
        '
        'dataPlot
        '
        ChartArea1.Name = "ChartArea1"
        Me.dataPlot.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.dataPlot.Legends.Add(Legend1)
        Me.dataPlot.Location = New System.Drawing.Point(511, 6)
        Me.dataPlot.Name = "dataPlot"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.dataPlot.Series.Add(Series1)
        Me.dataPlot.Size = New System.Drawing.Size(867, 496)
        Me.dataPlot.TabIndex = 7
        Me.dataPlot.Text = "Data Plot"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Samples Rendered :"
        '
        'samplesRendered
        '
        Me.samplesRendered.Location = New System.Drawing.Point(141, 32)
        Me.samplesRendered.Name = "samplesRendered"
        Me.samplesRendered.Size = New System.Drawing.Size(143, 20)
        Me.samplesRendered.TabIndex = 9
        '
        'btn_autonull
        '
        Me.btn_autonull.Location = New System.Drawing.Point(417, 6)
        Me.btn_autonull.Name = "btn_autonull"
        Me.btn_autonull.Size = New System.Drawing.Size(88, 35)
        Me.btn_autonull.TabIndex = 10
        Me.btn_autonull.Text = "Auto-Null"
        Me.btn_autonull.UseVisualStyleBackColor = True
        '
        'logToCSV
        '
        Me.logToCSV.AutoSize = True
        Me.logToCSV.Location = New System.Drawing.Point(15, 58)
        Me.logToCSV.Name = "logToCSV"
        Me.logToCSV.Size = New System.Drawing.Size(127, 17)
        Me.logToCSV.TabIndex = 11
        Me.logToCSV.Text = "Log Plot Data to CSV"
        Me.logToCSV.UseVisualStyleBackColor = True
        '
        'saveChart
        '
        Me.saveChart.Location = New System.Drawing.Point(417, 47)
        Me.saveChart.Name = "saveChart"
        Me.saveChart.Size = New System.Drawing.Size(88, 35)
        Me.saveChart.TabIndex = 12
        Me.saveChart.Text = "Save Plot"
        Me.saveChart.UseVisualStyleBackColor = True
        '
        'playFromCSV
        '
        Me.playFromCSV.Location = New System.Drawing.Point(323, 47)
        Me.playFromCSV.Name = "playFromCSV"
        Me.playFromCSV.Size = New System.Drawing.Size(88, 35)
        Me.playFromCSV.TabIndex = 13
        Me.playFromCSV.Text = "Play From CSV"
        Me.playFromCSV.UseVisualStyleBackColor = True
        '
        'DataPlotGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1390, 513)
        Me.Controls.Add(Me.playFromCSV)
        Me.Controls.Add(Me.saveChart)
        Me.Controls.Add(Me.logToCSV)
        Me.Controls.Add(Me.btn_autonull)
        Me.Controls.Add(Me.samplesRendered)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dataPlot)
        Me.Controls.Add(Me.btn_startStop)
        Me.Controls.Add(Me.sampleFreq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.regView)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "DataPlotGUI"
        Me.Text = "DataPlotGUI"
        CType(Me.regView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataPlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents regView As DataGridView
    Friend WithEvents Label As DataGridViewTextBoxColumn
    Friend WithEvents Page As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents Contents As DataGridViewTextBoxColumn
    Friend WithEvents Plot As DataGridViewCheckBoxColumn
    Friend WithEvents Offset As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents sampleFreq As TextBox
    Friend WithEvents btn_startStop As Button
    Friend WithEvents dataPlot As DataVisualization.Charting.Chart
    Friend WithEvents Label2 As Label
    Friend WithEvents samplesRendered As TextBox
    Friend WithEvents btn_autonull As Button
    Friend WithEvents logToCSV As CheckBox
    Friend WithEvents saveChart As Button
    Friend WithEvents playFromCSV As Button
End Class
