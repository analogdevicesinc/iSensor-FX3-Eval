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
        Me.Scale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.label_sampleFreq = New System.Windows.Forms.Label()
        Me.sampleFreq = New System.Windows.Forms.TextBox()
        Me.btn_startStop = New System.Windows.Forms.Button()
        Me.dataPlot = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.label_samplesRendered = New System.Windows.Forms.Label()
        Me.samplesRendered = New System.Windows.Forms.TextBox()
        Me.btn_autonull = New System.Windows.Forms.Button()
        Me.logToCSV = New System.Windows.Forms.CheckBox()
        Me.btn_saveChart = New System.Windows.Forms.Button()
        Me.playFromCSV = New System.Windows.Forms.Button()
        Me.btn_stopPlayback = New System.Windows.Forms.Button()
        Me.axis_autoscale = New System.Windows.Forms.CheckBox()
        Me.maxscale = New System.Windows.Forms.TextBox()
        Me.minScale = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.check_fixedTime = New System.Windows.Forms.CheckBox()
        Me.x_timestamp = New System.Windows.Forms.CheckBox()
        Me.btn_SetLabel = New System.Windows.Forms.Button()
        Me.x_axis_scroll = New System.Windows.Forms.CheckBox()
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
        Me.regView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Label, Me.Page, Me.Address, Me.Contents, Me.Plot, Me.Offset, Me.Scale})
        Me.regView.Location = New System.Drawing.Point(11, 125)
        Me.regView.Margin = New System.Windows.Forms.Padding(2)
        Me.regView.MultiSelect = False
        Me.regView.Name = "regView"
        Me.regView.RowHeadersVisible = False
        Me.regView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.regView.RowTemplate.Height = 24
        Me.regView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.regView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.regView.Size = New System.Drawing.Size(515, 389)
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
        'Scale
        '
        Me.Scale.HeaderText = "Scale"
        Me.Scale.Name = "Scale"
        '
        'label_sampleFreq
        '
        Me.label_sampleFreq.AutoSize = True
        Me.label_sampleFreq.Location = New System.Drawing.Point(8, 9)
        Me.label_sampleFreq.Name = "label_sampleFreq"
        Me.label_sampleFreq.Size = New System.Drawing.Size(123, 13)
        Me.label_sampleFreq.TabIndex = 4
        Me.label_sampleFreq.Text = "Sample Frequency (Hz) :"
        '
        'sampleFreq
        '
        Me.sampleFreq.Location = New System.Drawing.Point(141, 6)
        Me.sampleFreq.Name = "sampleFreq"
        Me.sampleFreq.Size = New System.Drawing.Size(143, 20)
        Me.sampleFreq.TabIndex = 4
        '
        'btn_startStop
        '
        Me.btn_startStop.Location = New System.Drawing.Point(344, 6)
        Me.btn_startStop.Name = "btn_startStop"
        Me.btn_startStop.Size = New System.Drawing.Size(88, 35)
        Me.btn_startStop.TabIndex = 0
        Me.btn_startStop.Text = "Start Plotting"
        Me.btn_startStop.UseVisualStyleBackColor = True
        '
        'dataPlot
        '
        ChartArea1.Name = "ChartArea1"
        Me.dataPlot.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.dataPlot.Legends.Add(Legend1)
        Me.dataPlot.Location = New System.Drawing.Point(531, 6)
        Me.dataPlot.Name = "dataPlot"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.dataPlot.Series.Add(Series1)
        Me.dataPlot.Size = New System.Drawing.Size(850, 508)
        Me.dataPlot.TabIndex = 7
        Me.dataPlot.Text = "Data Plot"
        '
        'label_samplesRendered
        '
        Me.label_samplesRendered.AutoSize = True
        Me.label_samplesRendered.Location = New System.Drawing.Point(8, 35)
        Me.label_samplesRendered.Name = "label_samplesRendered"
        Me.label_samplesRendered.Size = New System.Drawing.Size(103, 13)
        Me.label_samplesRendered.TabIndex = 8
        Me.label_samplesRendered.Text = "Samples Rendered :"
        '
        'samplesRendered
        '
        Me.samplesRendered.Location = New System.Drawing.Point(141, 32)
        Me.samplesRendered.Name = "samplesRendered"
        Me.samplesRendered.Size = New System.Drawing.Size(143, 20)
        Me.samplesRendered.TabIndex = 5
        '
        'btn_autonull
        '
        Me.btn_autonull.Location = New System.Drawing.Point(438, 6)
        Me.btn_autonull.Name = "btn_autonull"
        Me.btn_autonull.Size = New System.Drawing.Size(88, 35)
        Me.btn_autonull.TabIndex = 1
        Me.btn_autonull.Text = "Auto-Null"
        Me.btn_autonull.UseVisualStyleBackColor = True
        '
        'logToCSV
        '
        Me.logToCSV.AutoSize = True
        Me.logToCSV.Location = New System.Drawing.Point(11, 57)
        Me.logToCSV.Name = "logToCSV"
        Me.logToCSV.Size = New System.Drawing.Size(127, 17)
        Me.logToCSV.TabIndex = 6
        Me.logToCSV.Text = "Log Plot Data to CSV"
        Me.logToCSV.UseVisualStyleBackColor = True
        '
        'btn_saveChart
        '
        Me.btn_saveChart.Location = New System.Drawing.Point(438, 47)
        Me.btn_saveChart.Name = "btn_saveChart"
        Me.btn_saveChart.Size = New System.Drawing.Size(88, 35)
        Me.btn_saveChart.TabIndex = 2
        Me.btn_saveChart.Text = "Save Plot"
        Me.btn_saveChart.UseVisualStyleBackColor = True
        '
        'playFromCSV
        '
        Me.playFromCSV.Location = New System.Drawing.Point(344, 47)
        Me.playFromCSV.Name = "playFromCSV"
        Me.playFromCSV.Size = New System.Drawing.Size(88, 35)
        Me.playFromCSV.TabIndex = 13
        Me.playFromCSV.Text = "Play From CSV"
        Me.playFromCSV.UseVisualStyleBackColor = True
        '
        'btn_stopPlayback
        '
        Me.btn_stopPlayback.Location = New System.Drawing.Point(344, 47)
        Me.btn_stopPlayback.Name = "btn_stopPlayback"
        Me.btn_stopPlayback.Size = New System.Drawing.Size(88, 35)
        Me.btn_stopPlayback.TabIndex = 3
        Me.btn_stopPlayback.Text = "Stop Playback"
        Me.btn_stopPlayback.UseVisualStyleBackColor = True
        '
        'axis_autoscale
        '
        Me.axis_autoscale.AutoSize = True
        Me.axis_autoscale.Location = New System.Drawing.Point(11, 103)
        Me.axis_autoscale.Name = "axis_autoscale"
        Me.axis_autoscale.Size = New System.Drawing.Size(107, 17)
        Me.axis_autoscale.TabIndex = 7
        Me.axis_autoscale.Text = "AutoScale Y-Axis"
        Me.axis_autoscale.UseVisualStyleBackColor = True
        '
        'maxscale
        '
        Me.maxscale.Location = New System.Drawing.Point(310, 100)
        Me.maxscale.Name = "maxscale"
        Me.maxscale.Size = New System.Drawing.Size(111, 20)
        Me.maxscale.TabIndex = 9
        '
        'minScale
        '
        Me.minScale.Location = New System.Drawing.Point(157, 100)
        Me.minScale.Name = "minScale"
        Me.minScale.Size = New System.Drawing.Size(111, 20)
        Me.minScale.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(124, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Min:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(274, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Max:"
        '
        'check_fixedTime
        '
        Me.check_fixedTime.AutoSize = True
        Me.check_fixedTime.Location = New System.Drawing.Point(157, 57)
        Me.check_fixedTime.Name = "check_fixedTime"
        Me.check_fixedTime.Size = New System.Drawing.Size(115, 17)
        Me.check_fixedTime.TabIndex = 21
        Me.check_fixedTime.Text = "Fixed Duration Plot"
        Me.check_fixedTime.UseVisualStyleBackColor = True
        '
        'x_timestamp
        '
        Me.x_timestamp.AutoSize = True
        Me.x_timestamp.Location = New System.Drawing.Point(11, 80)
        Me.x_timestamp.Name = "x_timestamp"
        Me.x_timestamp.Size = New System.Drawing.Size(109, 17)
        Me.x_timestamp.TabIndex = 22
        Me.x_timestamp.Text = "Timestamp X-Axis"
        Me.x_timestamp.UseVisualStyleBackColor = True
        '
        'btn_SetLabel
        '
        Me.btn_SetLabel.Location = New System.Drawing.Point(438, 100)
        Me.btn_SetLabel.Name = "btn_SetLabel"
        Me.btn_SetLabel.Size = New System.Drawing.Size(88, 20)
        Me.btn_SetLabel.TabIndex = 23
        Me.btn_SetLabel.Text = "Set Label"
        Me.btn_SetLabel.UseVisualStyleBackColor = True
        '
        'x_axis_scroll
        '
        Me.x_axis_scroll.AutoSize = True
        Me.x_axis_scroll.Location = New System.Drawing.Point(157, 80)
        Me.x_axis_scroll.Name = "x_axis_scroll"
        Me.x_axis_scroll.Size = New System.Drawing.Size(103, 17)
        Me.x_axis_scroll.TabIndex = 24
        Me.x_axis_scroll.Text = "X-Axis Scroll Bar"
        Me.x_axis_scroll.UseVisualStyleBackColor = True
        '
        'DataPlotGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1390, 524)
        Me.Controls.Add(Me.x_axis_scroll)
        Me.Controls.Add(Me.btn_SetLabel)
        Me.Controls.Add(Me.x_timestamp)
        Me.Controls.Add(Me.check_fixedTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.minScale)
        Me.Controls.Add(Me.maxscale)
        Me.Controls.Add(Me.axis_autoscale)
        Me.Controls.Add(Me.btn_stopPlayback)
        Me.Controls.Add(Me.playFromCSV)
        Me.Controls.Add(Me.btn_saveChart)
        Me.Controls.Add(Me.logToCSV)
        Me.Controls.Add(Me.btn_autonull)
        Me.Controls.Add(Me.samplesRendered)
        Me.Controls.Add(Me.label_samplesRendered)
        Me.Controls.Add(Me.dataPlot)
        Me.Controls.Add(Me.btn_startStop)
        Me.Controls.Add(Me.sampleFreq)
        Me.Controls.Add(Me.label_sampleFreq)
        Me.Controls.Add(Me.regView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.MinimumSize = New System.Drawing.Size(900, 400)
        Me.Name = "DataPlotGUI"
        Me.Text = "Data Plotting"
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
    Friend WithEvents label_sampleFreq As Label
    Friend WithEvents sampleFreq As TextBox
    Friend WithEvents btn_startStop As Button
    Friend WithEvents dataPlot As DataVisualization.Charting.Chart
    Friend WithEvents label_samplesRendered As Label
    Friend WithEvents samplesRendered As TextBox
    Friend WithEvents btn_autonull As Button
    Friend WithEvents logToCSV As CheckBox
    Friend WithEvents btn_saveChart As Button
    Friend WithEvents playFromCSV As Button
    Friend WithEvents btn_stopPlayback As Button
    Friend WithEvents axis_autoscale As CheckBox
    Friend WithEvents maxscale As TextBox
    Friend WithEvents minScale As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents check_fixedTime As CheckBox
    Friend WithEvents x_timestamp As CheckBox
    Friend WithEvents Scale As DataGridViewTextBoxColumn
    Friend WithEvents btn_SetLabel As Button
    Friend WithEvents x_axis_scroll As CheckBox
End Class
