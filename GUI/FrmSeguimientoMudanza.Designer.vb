<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeguimientoMudanza
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
        dgvMudanzas = New DataGridView()
        txtBuscar = New TextBox()
        cmbEstadoFiltro = New ComboBox()
        btnVerDetalle = New Button()
        lblPendietes = New Label()
        lblEnProceso = New Label()
        lblCompletadas = New Label()
        lblTotal = New Label()
        btnRefrescar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        Button1 = New Button()
        CType(dgvMudanzas, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvMudanzas
        ' 
        dgvMudanzas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMudanzas.Location = New Point(15, 342)
        dgvMudanzas.Margin = New Padding(4, 4, 4, 4)
        dgvMudanzas.Name = "dgvMudanzas"
        dgvMudanzas.RowHeadersWidth = 51
        dgvMudanzas.Size = New Size(1084, 372)
        dgvMudanzas.TabIndex = 0
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(15, 301)
        txtBuscar.Margin = New Padding(4, 4, 4, 4)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(520, 31)
        txtBuscar.TabIndex = 1
        ' 
        ' cmbEstadoFiltro
        ' 
        cmbEstadoFiltro.FormattingEnabled = True
        cmbEstadoFiltro.Items.AddRange(New Object() {"Todas", "Pendientes", "En Procreso", "Completada"})
        cmbEstadoFiltro.Location = New Point(755, 80)
        cmbEstadoFiltro.Margin = New Padding(4, 4, 4, 4)
        cmbEstadoFiltro.Name = "cmbEstadoFiltro"
        cmbEstadoFiltro.Size = New Size(222, 33)
        cmbEstadoFiltro.TabIndex = 2
        ' 
        ' btnVerDetalle
        ' 
        btnVerDetalle.Location = New Point(751, 169)
        btnVerDetalle.Margin = New Padding(4, 4, 4, 4)
        btnVerDetalle.Name = "btnVerDetalle"
        btnVerDetalle.Size = New Size(118, 36)
        btnVerDetalle.TabIndex = 3
        btnVerDetalle.Text = "Detalle"
        btnVerDetalle.UseVisualStyleBackColor = True
        ' 
        ' lblPendietes
        ' 
        lblPendietes.AutoSize = True
        lblPendietes.Location = New Point(55, 30)
        lblPendietes.Margin = New Padding(4, 0, 4, 0)
        lblPendietes.Name = "lblPendietes"
        lblPendietes.Size = New Size(63, 25)
        lblPendietes.TabIndex = 4
        lblPendietes.Text = "Label1"
        ' 
        ' lblEnProceso
        ' 
        lblEnProceso.AutoSize = True
        lblEnProceso.Location = New Point(49, 28)
        lblEnProceso.Margin = New Padding(4, 0, 4, 0)
        lblEnProceso.Name = "lblEnProceso"
        lblEnProceso.Size = New Size(63, 25)
        lblEnProceso.TabIndex = 5
        lblEnProceso.Text = "Label2"
        ' 
        ' lblCompletadas
        ' 
        lblCompletadas.AutoSize = True
        lblCompletadas.Location = New Point(50, 29)
        lblCompletadas.Margin = New Padding(4, 0, 4, 0)
        lblCompletadas.Name = "lblCompletadas"
        lblCompletadas.Size = New Size(63, 25)
        lblCompletadas.TabIndex = 6
        lblCompletadas.Text = "Label3"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(58, 31)
        lblTotal.Margin = New Padding(4, 0, 4, 0)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(63, 25)
        lblTotal.TabIndex = 7
        lblTotal.Text = "Label4"
        ' 
        ' btnRefrescar
        ' 
        btnRefrescar.Location = New Point(876, 169)
        btnRefrescar.Margin = New Padding(4, 4, 4, 4)
        btnRefrescar.Name = "btnRefrescar"
        btnRefrescar.Size = New Size(118, 36)
        btnRefrescar.TabIndex = 8
        btnRefrescar.Text = "Refrescar"
        btnRefrescar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(40, 69)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 25)
        Label1.TabIndex = 9
        Label1.Text = "Pendientes"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(38, 69)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 25)
        Label2.TabIndex = 10
        Label2.Text = "En Proceso"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(36, 74)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(117, 25)
        Label3.TabIndex = 11
        Label3.Text = "Completadas"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(58, 69)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 25)
        Label4.TabIndex = 12
        Label4.Text = "Total"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = SystemColors.ButtonHighlight
        Label5.Location = New Point(15, 272)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(63, 25)
        Label5.TabIndex = 13
        Label5.Text = "Buscar"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.AppWorkspace
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(lblPendietes)
        Panel1.Location = New Point(15, 62)
        Panel1.Margin = New Padding(4, 4, 4, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(178, 108)
        Panel1.TabIndex = 14
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ActiveCaption
        Panel2.Controls.Add(lblEnProceso)
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(200, 62)
        Panel2.Margin = New Padding(4, 4, 4, 4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(178, 108)
        Panel2.TabIndex = 15
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Turquoise
        Panel3.Controls.Add(lblCompletadas)
        Panel3.Controls.Add(Label3)
        Panel3.Location = New Point(385, 62)
        Panel3.Margin = New Padding(4, 4, 4, 4)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(178, 108)
        Panel3.TabIndex = 16
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.ButtonHighlight
        Panel4.Controls.Add(lblTotal)
        Panel4.Controls.Add(Label4)
        Panel4.Location = New Point(570, 62)
        Panel4.Margin = New Padding(4, 4, 4, 4)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(178, 108)
        Panel4.TabIndex = 17
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(974, 14)
        Button1.Margin = New Padding(2)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 33
        Button1.Text = "Atrás"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' FrmSeguimientoMudanza
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1100, 882)
        Controls.Add(Button1)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label5)
        Controls.Add(btnRefrescar)
        Controls.Add(btnVerDetalle)
        Controls.Add(cmbEstadoFiltro)
        Controls.Add(txtBuscar)
        Controls.Add(dgvMudanzas)
        Margin = New Padding(4, 4, 4, 4)
        Name = "FrmSeguimientoMudanza"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmSeguimientoMudanza"
        CType(dgvMudanzas, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvMudanzas As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cmbEstadoFiltro As ComboBox
    Friend WithEvents btnVerDetalle As Button
    Friend WithEvents lblPendietes As Label
    Friend WithEvents lblEnProceso As Label
    Friend WithEvents lblCompletadas As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnRefrescar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
End Class
