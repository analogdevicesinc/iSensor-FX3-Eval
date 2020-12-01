<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrequencyPlotGUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.dataPlot = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RegisterList = New System.Windows.Forms.ListView()
        Me.regSelect = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.drFreq = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_addreg = New System.Windows.Forms.Button()
        Me.btn_removeReg = New System.Windows.Forms.Button()
        Me.btn_run = New System.Windows.Forms.Button()
        Me.btn_stopPlot = New System.Windows.Forms.Button()
        Me.FFT_Averages = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.logYaxis = New System.Windows.Forms.CheckBox()
        Me.logXaxis = New System.Windows.Forms.CheckBox()
        Me.btn_ClearLabels = New System.Windows.Forms.Button()
        Me.btn_Export = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_saveplot = New System.Windows.Forms.Button()
        Me.NFFT = New System.Windows.Forms.ComboBox()
        Me.btn_apply3db = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.input_3db_min = New System.Windows.Forms.TextBox()
        Me.input_3db_max = New System.Windows.Forms.TextBox()
        Me.btn_SetLabel = New System.Windows.Forms.Button()
        Me.check_sciLabel = New System.Windows.Forms.CheckBox()
        CType(Me.dataPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataPlot
        '
        ChartArea1.Name = "ChartArea1"
        Me.dataPlot.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.dataPlot.Legends.Add(Legend1)
        Me.dataPlot.Location = New System.Drawing.Point(237, 9)
        Me.dataPlot.Name = "dataPlot"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.dataPlot.Series.Add(Series1)
        Me.dataPlot.Size = New System.Drawing.Size(587, 511)
        Me.dataPlot.TabIndex = 0
        Me.dataPlot.Text = "dataPlot"
        '
        'RegisterList
        '
        Me.RegisterList.Location = New System.Drawing.Point(10, 206)
        Me.RegisterList.Name = "RegisterList"
        Me.RegisterList.Size = New System.Drawing.Size(221, 170)
        Me.RegisterList.TabIndex = 1
        Me.RegisterList.UseCompatibleStateImageBehavior = False
        '
        'regSelect
        '
        Me.regSelect.FormattingEnabled = True
        Me.regSelect.Location = New System.Drawing.Point(69, 133)
        Me.regSelect.Name = "regSelect"
        Me.regSelect.Size = New System.Drawing.Size(162, 21)
        Me.regSelect.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Samples Per FFT:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sample Frequency:"
        '
        'drFreq
        '
        Me.drFreq.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.drFreq.Location = New System.Drawing.Point(113, 61)
        Me.drFreq.Name = "drFreq"
        Me.drFreq.ReadOnly = True
        Me.drFreq.Size = New System.Drawing.Size(118, 20)
        Me.drFreq.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Registers:"
        '
        'btn_addreg
        '
        Me.btn_addreg.Location = New System.Drawing.Point(10, 160)
        Me.btn_addreg.Name = "btn_addreg"
        Me.btn_addreg.Size = New System.Drawing.Size(70, 40)
        Me.btn_addreg.TabIndex = 8
        Me.btn_addreg.Text = "Add Register"
        Me.btn_addreg.UseVisualStyleBackColor = True
        '
        'btn_removeReg
        '
        Me.btn_removeReg.Location = New System.Drawing.Point(86, 161)
        Me.btn_removeReg.Name = "btn_removeReg"
        Me.btn_removeReg.Size = New System.Drawing.Size(70, 40)
        Me.btn_removeReg.TabIndex = 9
        Me.btn_removeReg.Text = "Remove Register"
        Me.btn_removeReg.UseVisualStyleBackColor = True
        '
        'btn_run
        '
        Me.btn_run.Location = New System.Drawing.Point(10, 382)
        Me.btn_run.Name = "btn_run"
        Me.btn_run.Size = New System.Drawing.Size(70, 40)
        Me.btn_run.TabIndex = 10
        Me.btn_run.Text = "Start Plot"
        Me.btn_run.UseVisualStyleBackColor = True
        '
        'btn_stopPlot
        '
        Me.btn_stopPlot.Location = New System.Drawing.Point(86, 382)
        Me.btn_stopPlot.Name = "btn_stopPlot"
        Me.btn_stopPlot.Size = New System.Drawing.Size(70, 40)
        Me.btn_stopPlot.TabIndex = 11
        Me.btn_stopPlot.Text = "Stop Plot"
        Me.btn_stopPlot.UseVisualStyleBackColor = True
        '
        'FFT_Averages
        '
        Me.FFT_Averages.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FFT_Averages.Location = New System.Drawing.Point(113, 35)
        Me.FFT_Averages.Name = "FFT_Averages"
        Me.FFT_Averages.Size = New System.Drawing.Size(118, 20)
        Me.FFT_Averages.TabIndex = 14
        Me.FFT_Averages.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "FFT Averages:"
        '
        'logYaxis
        '
        Me.logYaxis.AutoSize = True
        Me.logYaxis.Location = New System.Drawing.Point(87, 87)
        Me.logYaxis.Name = "logYaxis"
        Me.logYaxis.Size = New System.Drawing.Size(76, 17)
        Me.logYaxis.TabIndex = 15
        Me.logYaxis.Text = "Log Y-Axis"
        Me.logYaxis.UseVisualStyleBackColor = True
        '
        'logXaxis
        '
        Me.logXaxis.AutoSize = True
        Me.logXaxis.Location = New System.Drawing.Point(10, 87)
        Me.logXaxis.Name = "logXaxis"
        Me.logXaxis.Size = New System.Drawing.Size(76, 17)
        Me.logXaxis.TabIndex = 16
        Me.logXaxis.Text = "Log X-Axis"
        Me.logXaxis.UseVisualStyleBackColor = True
        '
        'btn_ClearLabels
        '
        Me.btn_ClearLabels.Location = New System.Drawing.Point(161, 382)
        Me.btn_ClearLabels.Name = "btn_ClearLabels"
        Me.btn_ClearLabels.Size = New System.Drawing.Size(70, 40)
        Me.btn_ClearLabels.TabIndex = 17
        Me.btn_ClearLabels.Text = "Clear Labels"
        Me.btn_ClearLabels.UseVisualStyleBackColor = True
        '
        'btn_Export
        '
        Me.btn_Export.Location = New System.Drawing.Point(86, 428)
        Me.btn_Export.Name = "btn_Export"
        Me.btn_Export.Size = New System.Drawing.Size(70, 40)
        Me.btn_Export.TabIndex = 18
        Me.btn_Export.Text = "Export Plot Data"
        Me.btn_Export.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(161, 161)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(70, 40)
        Me.btn_Clear.TabIndex = 19
        Me.btn_Clear.Text = "Clear All Registers"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_saveplot
        '
        Me.btn_saveplot.Location = New System.Drawing.Point(161, 428)
        Me.btn_saveplot.Name = "btn_saveplot"
        Me.btn_saveplot.Size = New System.Drawing.Size(70, 40)
        Me.btn_saveplot.TabIndex = 20
        Me.btn_saveplot.Text = "Save Plot"
        Me.btn_saveplot.UseVisualStyleBackColor = True
        '
        'NFFT
        '
        Me.NFFT.FormattingEnabled = True
        Me.NFFT.Location = New System.Drawing.Point(113, 9)
        Me.NFFT.Name = "NFFT"
        Me.NFFT.Size = New System.Drawing.Size(118, 21)
        Me.NFFT.TabIndex = 21
        '
        'btn_apply3db
        '
        Me.btn_apply3db.Location = New System.Drawing.Point(10, 428)
        Me.btn_apply3db.Name = "btn_apply3db"
        Me.btn_apply3db.Size = New System.Drawing.Size(70, 40)
        Me.btn_apply3db.TabIndex = 22
        Me.btn_apply3db.Text = "Apply -3dB Lines"
        Me.btn_apply3db.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 476)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Pass Band Min Freq (Hz):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 502)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Pass Band Max Freq (Hz):"
        '
        'input_3db_min
        '
        Me.input_3db_min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.input_3db_min.Location = New System.Drawing.Point(140, 474)
        Me.input_3db_min.Name = "input_3db_min"
        Me.input_3db_min.Size = New System.Drawing.Size(91, 20)
        Me.input_3db_min.TabIndex = 25
        Me.input_3db_min.Text = "10"
        '
        'input_3db_max
        '
        Me.input_3db_max.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.input_3db_max.Location = New System.Drawing.Point(140, 500)
        Me.input_3db_max.Name = "input_3db_max"
        Me.input_3db_max.Size = New System.Drawing.Size(91, 20)
        Me.input_3db_max.TabIndex = 26
        Me.input_3db_max.Text = "100"
        '
        'btn_SetLabel
        '
        Me.btn_SetLabel.Location = New System.Drawing.Point(161, 87)
        Me.btn_SetLabel.Name = "btn_SetLabel"
        Me.btn_SetLabel.Size = New System.Drawing.Size(70, 40)
        Me.btn_SetLabel.TabIndex = 27
        Me.btn_SetLabel.Text = "Set Y-Axis Label"
        Me.btn_SetLabel.UseVisualStyleBackColor = True
        '
        'check_sciLabel
        '
        Me.check_sciLabel.AutoSize = True
        Me.check_sciLabel.Location = New System.Drawing.Point(10, 110)
        Me.check_sciLabel.Name = "check_sciLabel"
        Me.check_sciLabel.Size = New System.Drawing.Size(146, 17)
        Me.check_sciLabel.TabIndex = 28
        Me.check_sciLabel.Text = "Scientific Notation Labels"
        Me.check_sciLabel.UseVisualStyleBackColor = True
        '
        'FrequencyPlotGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 531)
        Me.Controls.Add(Me.check_sciLabel)
        Me.Controls.Add(Me.btn_SetLabel)
        Me.Controls.Add(Me.input_3db_max)
        Me.Controls.Add(Me.input_3db_min)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_apply3db)
        Me.Controls.Add(Me.NFFT)
        Me.Controls.Add(Me.btn_saveplot)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.btn_Export)
        Me.Controls.Add(Me.btn_ClearLabels)
        Me.Controls.Add(Me.logXaxis)
        Me.Controls.Add(Me.logYaxis)
        Me.Controls.Add(Me.FFT_Averages)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_stopPlot)
        Me.Controls.Add(Me.btn_run)
        Me.Controls.Add(Me.btn_removeReg)
        Me.Controls.Add(Me.btn_addreg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.drFreq)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.regSelect)
        Me.Controls.Add(Me.RegisterList)
        Me.Controls.Add(Me.dataPlot)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimumSize = New System.Drawing.Size(850, 570)
        Me.Name = "FrequencyPlotGUI"
        Me.Text = "Frequency Plotting"
        CType(Me.dataPlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dataPlot As DataVisualization.Charting.Chart
    Friend WithEvents RegisterList As ListView
    Friend WithEvents regSelect As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents drFreq As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_addreg As Button
    Friend WithEvents btn_removeReg As Button
    Friend WithEvents btn_run As Button
    Friend WithEvents btn_stopPlot As Button
    Friend WithEvents FFT_Averages As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents logYaxis As CheckBox
    Friend WithEvents logXaxis As CheckBox
    Friend WithEvents btn_ClearLabels As Button
    Friend WithEvents btn_Export As Button
    Friend WithEvents btn_Clear As Button
    Friend WithEvents btn_saveplot As Button
    Friend WithEvents NFFT As ComboBox
    Friend WithEvents btn_apply3db As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents input_3db_min As TextBox
    Friend WithEvents input_3db_max As TextBox
    Friend WithEvents btn_SetLabel As Button
    Friend WithEvents check_sciLabel As CheckBox
End Class
