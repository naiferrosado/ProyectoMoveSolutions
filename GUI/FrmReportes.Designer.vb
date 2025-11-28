<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        dtpInicio = New DateTimePicker()
        Label3 = New Label()
        dtpFin = New DateTimePicker()
        Label4 = New Label()
        cmbEstado = New ComboBox()
        Label5 = New Label()
        txtClienteFiltro = New TextBox()
        btnGenerarReporte = New Button()
        btnExportar = New Button()
        dgvReporte = New DataGridView()
        btnExportarPDF = New Button()
        Button1 = New Button()
        CType(dgvReporte, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Narrow", 28F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(351, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(228, 66)
        Label1.TabIndex = 0
        Label1.Text = "Reportes"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(27, 109)
        Label2.Name = "Label2"
        Label2.Size = New Size(103, 25)
        Label2.TabIndex = 1
        Label2.Text = "Fecha inicio"
        ' 
        ' dtpInicio
        ' 
        dtpInicio.Location = New Point(157, 109)
        dtpInicio.Name = "dtpInicio"
        dtpInicio.Size = New Size(331, 31)
        dtpInicio.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(27, 160)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 25)
        Label3.TabIndex = 3
        Label3.Text = "Fecha fin"
        ' 
        ' dtpFin
        ' 
        dtpFin.Location = New Point(157, 160)
        dtpFin.Name = "dtpFin"
        dtpFin.Size = New Size(336, 31)
        dtpFin.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(27, 210)
        Label4.Name = "Label4"
        Label4.Size = New Size(66, 25)
        Label4.TabIndex = 5
        Label4.Text = "Estado"
        ' 
        ' cmbEstado
        ' 
        cmbEstado.FormattingEnabled = True
        cmbEstado.Items.AddRange(New Object() {"Todos", "", "", "Pendiente", "", "En curso", "", "", "Completada"})
        cmbEstado.Location = New Point(157, 210)
        cmbEstado.Name = "cmbEstado"
        cmbEstado.Size = New Size(336, 33)
        cmbEstado.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = SystemColors.Control
        Label5.Location = New Point(27, 264)
        Label5.Name = "Label5"
        Label5.Size = New Size(65, 25)
        Label5.TabIndex = 7
        Label5.Text = "Cliente"
        ' 
        ' txtClienteFiltro
        ' 
        txtClienteFiltro.Location = New Point(157, 264)
        txtClienteFiltro.Name = "txtClienteFiltro"
        txtClienteFiltro.Size = New Size(331, 31)
        txtClienteFiltro.TabIndex = 8
        ' 
        ' btnGenerarReporte
        ' 
        btnGenerarReporte.Location = New Point(133, 331)
        btnGenerarReporte.Name = "btnGenerarReporte"
        btnGenerarReporte.Size = New Size(112, 34)
        btnGenerarReporte.TabIndex = 9
        btnGenerarReporte.Text = "Generar Reporte"
        btnGenerarReporte.UseVisualStyleBackColor = True
        ' 
        ' btnExportar
        ' 
        btnExportar.Location = New Point(278, 331)
        btnExportar.Name = "btnExportar"
        btnExportar.Size = New Size(145, 34)
        btnExportar.TabIndex = 10
        btnExportar.Text = "Exportar CSV"
        btnExportar.UseVisualStyleBackColor = True
        ' 
        ' dgvReporte
        ' 
        dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReporte.Location = New Point(12, 416)
        dgvReporte.Name = "dgvReporte"
        dgvReporte.RowHeadersWidth = 62
        dgvReporte.Size = New Size(875, 256)
        dgvReporte.TabIndex = 11
        ' 
        ' btnExportarPDF
        ' 
        btnExportarPDF.Location = New Point(446, 331)
        btnExportarPDF.Name = "btnExportarPDF"
        btnExportarPDF.Size = New Size(133, 34)
        btnExportarPDF.TabIndex = 12
        btnExportarPDF.Text = "Exportar PDF"
        btnExportarPDF.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(775, 25)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 13
        Button1.Text = "Atrás"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' FrmReportes
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(899, 682)
        Controls.Add(Button1)
        Controls.Add(btnExportarPDF)
        Controls.Add(dgvReporte)
        Controls.Add(btnExportar)
        Controls.Add(btnGenerarReporte)
        Controls.Add(txtClienteFiltro)
        Controls.Add(Label5)
        Controls.Add(cmbEstado)
        Controls.Add(Label4)
        Controls.Add(dtpFin)
        Controls.Add(Label3)
        Controls.Add(dtpInicio)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FrmReportes"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmReportes"
        CType(dgvReporte, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtClienteFiltro As TextBox
    Friend WithEvents btnGenerarReporte As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents dgvReporte As DataGridView
    Friend WithEvents btnExportarPDF As Button
    Friend WithEvents Button1 As Button
End Class
