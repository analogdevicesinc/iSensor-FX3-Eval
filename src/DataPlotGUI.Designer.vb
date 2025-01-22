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
        Me.check_fixedTime = New System.Windows.Forms.CheckBox()
        Me.x_timestamp = New System.Windows.Forms.CheckBox()
        Me.btn_SetLabel = New System.Windows.Forms.Button()
        Me.PlotOptions = New System.Windows.Forms.TabControl()
        Me.ControlPage = New System.Windows.Forms.TabPage()
        Me.axis_autoscale = New System.Windows.Forms.CheckBox()
        Me.btn_copyPlot = New System.Windows.Forms.Button()
        Me.SettingsPage = New System.Windows.Forms.TabPage()
        Me.x_axis_scroll = New System.Windows.Forms.CheckBox()
        Me.btn_RemovePlot = New System.Windows.Forms.Button()
        Me.btn_AddPlot = New System.Windows.Forms.Button()
        Me.btn_setTitle = New System.Windows.Forms.Button()
        Me.Label = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Page = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contents = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Offset = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.regView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlotOptions.SuspendLayout()
        Me.ControlPage.SuspendLayout()
        Me.SettingsPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'regView
        '
        Me.regView.AllowUserToAddRows = False
        Me.regView.AllowUserToDeleteRows = False
        Me.regView.BackgroundColor = System.Drawing.Color.White
        Me.regView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.regView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Label, Me.Page, Me.Address, Me.Contents, Me.Offset})
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
        'label_sampleFreq
        '
        Me.label_sampleFreq.AutoSize = True
        Me.label_sampleFreq.Location = New System.Drawing.Point(6, 9)
        Me.label_sampleFreq.Name = "label_sampleFreq"
        Me.label_sampleFreq.Size = New System.Drawing.Size(117, 13)
        Me.label_sampleFreq.TabIndex = 4
        Me.label_sampleFreq.Text = "Plot Update Rate (Hz) :"
        '
        'sampleFreq
        '
        Me.sampleFreq.Location = New System.Drawing.Point(129, 7)
        Me.sampleFreq.Name = "sampleFreq"
        Me.sampleFreq.Size = New System.Drawing.Size(80, 20)
        Me.sampleFreq.TabIndex = 4
        '
        'btn_startStop
        '
        Me.btn_startStop.Location = New System.Drawing.Point(6, 6)
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
        Me.label_samplesRendered.Location = New System.Drawing.Point(6, 35)
        Me.label_samplesRendered.Name = "label_samplesRendered"
        Me.label_samplesRendered.Size = New System.Drawing.Size(103, 13)
        Me.label_samplesRendered.TabIndex = 8
        Me.label_samplesRendered.Text = "Samples Rendered :"
        '
        'samplesRendered
        '
        Me.samplesRendered.Location = New System.Drawing.Point(129, 33)
        Me.samplesRendered.Name = "samplesRendered"
        Me.samplesRendered.Size = New System.Drawing.Size(80, 20)
        Me.samplesRendered.TabIndex = 5
        '
        'btn_autonull
        '
        Me.btn_autonull.Location = New System.Drawing.Point(100, 6)
        Me.btn_autonull.Name = "btn_autonull"
        Me.btn_autonull.Size = New System.Drawing.Size(88, 35)
        Me.btn_autonull.TabIndex = 1
        Me.btn_autonull.Text = "Auto-Null"
        Me.btn_autonull.UseVisualStyleBackColor = True
        '
        'logToCSV
        '
        Me.logToCSV.AutoSize = True
        Me.logToCSV.Location = New System.Drawing.Point(204, 62)
        Me.logToCSV.Name = "logToCSV"
        Me.logToCSV.Size = New System.Drawing.Size(106, 17)
        Me.logToCSV.TabIndex = 6
        Me.logToCSV.Text = "Log Data to CSV"
        Me.logToCSV.UseVisualStyleBackColor = True
        '
        'btn_saveChart
        '
        Me.btn_saveChart.Location = New System.Drawing.Point(413, 6)
        Me.btn_saveChart.Name = "btn_saveChart"
        Me.btn_saveChart.Size = New System.Drawing.Size(88, 35)
        Me.btn_saveChart.TabIndex = 2
        Me.btn_saveChart.Text = "Save Plot Image"
        Me.btn_saveChart.UseVisualStyleBackColor = True
        '
        'playFromCSV
        '
        Me.playFromCSV.Location = New System.Drawing.Point(6, 47)
        Me.playFromCSV.Name = "playFromCSV"
        Me.playFromCSV.Size = New System.Drawing.Size(88, 35)
        Me.playFromCSV.TabIndex = 13
        Me.playFromCSV.Text = "Play From CSV"
        Me.playFromCSV.UseVisualStyleBackColor = True
        '
        'btn_stopPlayback
        '
        Me.btn_stopPlayback.Location = New System.Drawing.Point(6, 47)
        Me.btn_stopPlayback.Name = "btn_stopPlayback"
        Me.btn_stopPlayback.Size = New System.Drawing.Size(88, 35)
        Me.btn_stopPlayback.TabIndex = 3
        Me.btn_stopPlayback.Text = "Stop Playback"
        Me.btn_stopPlayback.UseVisualStyleBackColor = True
        '
        'check_fixedTime
        '
        Me.check_fixedTime.AutoSize = True
        Me.check_fixedTime.Location = New System.Drawing.Point(213, 57)
        Me.check_fixedTime.Name = "check_fixedTime"
        Me.check_fixedTime.Size = New System.Drawing.Size(115, 17)
        Me.check_fixedTime.TabIndex = 21
        Me.check_fixedTime.Text = "Fixed Duration Plot"
        Me.check_fixedTime.UseVisualStyleBackColor = True
        '
        'x_timestamp
        '
        Me.x_timestamp.AutoSize = True
        Me.x_timestamp.Location = New System.Drawing.Point(9, 62)
        Me.x_timestamp.Name = "x_timestamp"
        Me.x_timestamp.Size = New System.Drawing.Size(109, 17)
        Me.x_timestamp.TabIndex = 22
        Me.x_timestamp.Text = "Timestamp X-Axis"
        Me.x_timestamp.UseVisualStyleBackColor = True
        '
        'btn_SetLabel
        '
        Me.btn_SetLabel.Location = New System.Drawing.Point(413, 47)
        Me.btn_SetLabel.Name = "btn_SetLabel"
        Me.btn_SetLabel.Size = New System.Drawing.Size(88, 35)
        Me.btn_SetLabel.TabIndex = 23
        Me.btn_SetLabel.Text = "Set Y-Axis Labels"
        Me.btn_SetLabel.UseVisualStyleBackColor = True
        '
        'PlotOptions
        '
        Me.PlotOptions.Controls.Add(Me.ControlPage)
        Me.PlotOptions.Controls.Add(Me.SettingsPage)
        Me.PlotOptions.Location = New System.Drawing.Point(10, 6)
        Me.PlotOptions.Name = "PlotOptions"
        Me.PlotOptions.SelectedIndex = 0
        Me.PlotOptions.Size = New System.Drawing.Size(516, 111)
        Me.PlotOptions.TabIndex = 25
        '
        'ControlPage
        '
        Me.ControlPage.Controls.Add(Me.axis_autoscale)
        Me.ControlPage.Controls.Add(Me.btn_copyPlot)
        Me.ControlPage.Controls.Add(Me.btn_startStop)
        Me.ControlPage.Controls.Add(Me.btn_stopPlayback)
        Me.ControlPage.Controls.Add(Me.playFromCSV)
        Me.ControlPage.Controls.Add(Me.check_fixedTime)
        Me.ControlPage.Controls.Add(Me.btn_autonull)
        Me.ControlPage.Controls.Add(Me.btn_saveChart)
        Me.ControlPage.Location = New System.Drawing.Point(4, 22)
        Me.ControlPage.Name = "ControlPage"
        Me.ControlPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ControlPage.Size = New System.Drawing.Size(508, 85)
        Me.ControlPage.TabIndex = 0
        Me.ControlPage.Text = "Plotter Control"
        Me.ControlPage.UseVisualStyleBackColor = True
        '
        'axis_autoscale
        '
        Me.axis_autoscale.AutoSize = True
        Me.axis_autoscale.Location = New System.Drawing.Point(100, 57)
        Me.axis_autoscale.Name = "axis_autoscale"
        Me.axis_autoscale.Size = New System.Drawing.Size(107, 17)
        Me.axis_autoscale.TabIndex = 23
        Me.axis_autoscale.Text = "AutoScale Y-Axis"
        Me.axis_autoscale.UseVisualStyleBackColor = True
        '
        'btn_copyPlot
        '
        Me.btn_copyPlot.Location = New System.Drawing.Point(413, 47)
        Me.btn_copyPlot.Name = "btn_copyPlot"
        Me.btn_copyPlot.Size = New System.Drawing.Size(88, 35)
        Me.btn_copyPlot.TabIndex = 22
        Me.btn_copyPlot.Text = "Copy To Clipboard"
        Me.btn_copyPlot.UseVisualStyleBackColor = True
        '
        'SettingsPage
        '
        Me.SettingsPage.Controls.Add(Me.x_axis_scroll)
        Me.SettingsPage.Controls.Add(Me.btn_RemovePlot)
        Me.SettingsPage.Controls.Add(Me.btn_AddPlot)
        Me.SettingsPage.Controls.Add(Me.btn_setTitle)
        Me.SettingsPage.Controls.Add(Me.btn_SetLabel)
        Me.SettingsPage.Controls.Add(Me.label_sampleFreq)
        Me.SettingsPage.Controls.Add(Me.x_timestamp)
        Me.SettingsPage.Controls.Add(Me.sampleFreq)
        Me.SettingsPage.Controls.Add(Me.samplesRendered)
        Me.SettingsPage.Controls.Add(Me.label_samplesRendered)
        Me.SettingsPage.Controls.Add(Me.logToCSV)
        Me.SettingsPage.Location = New System.Drawing.Point(4, 22)
        Me.SettingsPage.Name = "SettingsPage"
        Me.SettingsPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SettingsPage.Size = New System.Drawing.Size(508, 85)
        Me.SettingsPage.TabIndex = 1
        Me.SettingsPage.Text = "Settings"
        Me.SettingsPage.UseVisualStyleBackColor = True
        '
        'x_axis_scroll
        '
        Me.x_axis_scroll.AutoSize = True
        Me.x_axis_scroll.Location = New System.Drawing.Point(124, 62)
        Me.x_axis_scroll.Name = "x_axis_scroll"
        Me.x_axis_scroll.Size = New System.Drawing.Size(74, 17)
        Me.x_axis_scroll.TabIndex = 29
        Me.x_axis_scroll.Text = "Plot Zoom"
        Me.x_axis_scroll.UseVisualStyleBackColor = True
        '
        'btn_RemovePlot
        '
        Me.btn_RemovePlot.Location = New System.Drawing.Point(319, 47)
        Me.btn_RemovePlot.Name = "btn_RemovePlot"
        Me.btn_RemovePlot.Size = New System.Drawing.Size(88, 35)
        Me.btn_RemovePlot.TabIndex = 28
        Me.btn_RemovePlot.Text = "Remove Plot Window"
        Me.btn_RemovePlot.UseVisualStyleBackColor = True
        '
        'btn_AddPlot
        '
        Me.btn_AddPlot.Location = New System.Drawing.Point(319, 6)
        Me.btn_AddPlot.Name = "btn_AddPlot"
        Me.btn_AddPlot.Size = New System.Drawing.Size(88, 35)
        Me.btn_AddPlot.TabIndex = 27
        Me.btn_AddPlot.Text = "Add Plot Window"
        Me.btn_AddPlot.UseVisualStyleBackColor = True
        '
        'btn_setTitle
        '
        Me.btn_setTitle.Location = New System.Drawing.Point(413, 6)
        Me.btn_setTitle.Name = "btn_setTitle"
        Me.btn_setTitle.Size = New System.Drawing.Size(88, 35)
        Me.btn_setTitle.TabIndex = 26
        Me.btn_setTitle.Text = "Set Title"
        Me.btn_setTitle.UseVisualStyleBackColor = True
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
        'Offset
        '
        Me.Offset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Offset.HeaderText = "Offset"
        Me.Offset.Name = "Offset"
        Me.Offset.Width = 60
        '
        'DataPlotGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1390, 524)
        Me.Controls.Add(Me.PlotOptions)
        Me.Controls.Add(Me.dataPlot)
        Me.Controls.Add(Me.regView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.MinimumSize = New System.Drawing.Size(900, 400)
        Me.Name = "DataPlotGUI"
        Me.Text = "Data Plotting"
        CType(Me.regView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataPlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlotOptions.ResumeLayout(False)
        Me.ControlPage.ResumeLayout(False)
        Me.ControlPage.PerformLayout()
        Me.SettingsPage.ResumeLayout(False)
        Me.SettingsPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents regView As DataGridView
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
    Friend WithEvents check_fixedTime As CheckBox
    Friend WithEvents x_timestamp As CheckBox
    Friend WithEvents btn_SetLabel As Button
    Friend WithEvents PlotOptions As TabControl
    Friend WithEvents ControlPage As TabPage
    Friend WithEvents btn_copyPlot As Button
    Friend WithEvents SettingsPage As TabPage
    Friend WithEvents btn_setTitle As Button
    Friend WithEvents btn_RemovePlot As Button
    Friend WithEvents btn_AddPlot As Button
    Friend WithEvents x_axis_scroll As CheckBox
    Friend WithEvents axis_autoscale As CheckBox
    Friend WithEvents Label As DataGridViewTextBoxColumn
    Friend WithEvents Page As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents Contents As DataGridViewTextBoxColumn
    Friend WithEvents Offset As DataGridViewTextBoxColumn
End Class
