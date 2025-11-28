<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleMudanza
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
        txtCliente = New TextBox()
        txtCosto = New TextBox()
        txtFecha = New TextBox()
        txtDestino = New TextBox()
        txtOrigen = New TextBox()
        txtVehiculo = New TextBox()
        txtEmpleado = New TextBox()
        btnMarcarEnProceso = New Button()
        btnMarcarCompletada = New Button()
        btnCerrar = New Button()
        btnCancelarMudanza = New Button()
        txtEstado = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtCliente
        ' 
        txtCliente.Location = New Point(135, 36)
        txtCliente.Margin = New Padding(4)
        txtCliente.Name = "txtCliente"
        txtCliente.Size = New Size(539, 31)
        txtCliente.TabIndex = 0
        ' 
        ' txtCosto
        ' 
        txtCosto.Location = New Point(135, 532)
        txtCosto.Margin = New Padding(4)
        txtCosto.Name = "txtCosto"
        txtCosto.Size = New Size(539, 31)
        txtCosto.TabIndex = 1
        ' 
        ' txtFecha
        ' 
        txtFecha.Location = New Point(135, 438)
        txtFecha.Margin = New Padding(4)
        txtFecha.Name = "txtFecha"
        txtFecha.Size = New Size(539, 31)
        txtFecha.TabIndex = 2
        ' 
        ' txtDestino
        ' 
        txtDestino.Location = New Point(135, 359)
        txtDestino.Margin = New Padding(4)
        txtDestino.Name = "txtDestino"
        txtDestino.Size = New Size(539, 31)
        txtDestino.TabIndex = 3
        ' 
        ' txtOrigen
        ' 
        txtOrigen.Location = New Point(135, 275)
        txtOrigen.Margin = New Padding(4)
        txtOrigen.Name = "txtOrigen"
        txtOrigen.Size = New Size(539, 31)
        txtOrigen.TabIndex = 4
        ' 
        ' txtVehiculo
        ' 
        txtVehiculo.Location = New Point(135, 199)
        txtVehiculo.Margin = New Padding(4)
        txtVehiculo.Name = "txtVehiculo"
        txtVehiculo.Size = New Size(539, 31)
        txtVehiculo.TabIndex = 5
        ' 
        ' txtEmpleado
        ' 
        txtEmpleado.Location = New Point(135, 115)
        txtEmpleado.Margin = New Padding(4)
        txtEmpleado.Name = "txtEmpleado"
        txtEmpleado.Size = New Size(539, 31)
        txtEmpleado.TabIndex = 6
        ' 
        ' btnMarcarEnProceso
        ' 
        btnMarcarEnProceso.Location = New Point(61, 706)
        btnMarcarEnProceso.Margin = New Padding(4)
        btnMarcarEnProceso.Name = "btnMarcarEnProceso"
        btnMarcarEnProceso.Size = New Size(136, 45)
        btnMarcarEnProceso.TabIndex = 7
        btnMarcarEnProceso.Text = "En Proceso"
        btnMarcarEnProceso.UseVisualStyleBackColor = True
        ' 
        ' btnMarcarCompletada
        ' 
        btnMarcarCompletada.Location = New Point(342, 706)
        btnMarcarCompletada.Margin = New Padding(4)
        btnMarcarCompletada.Name = "btnMarcarCompletada"
        btnMarcarCompletada.Size = New Size(146, 45)
        btnMarcarCompletada.TabIndex = 8
        btnMarcarCompletada.Text = "Completada"
        btnMarcarCompletada.UseVisualStyleBackColor = True
        ' 
        ' btnCerrar
        ' 
        btnCerrar.Location = New Point(849, 706)
        btnCerrar.Margin = New Padding(4)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(136, 45)
        btnCerrar.TabIndex = 9
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelarMudanza
        ' 
        btnCancelarMudanza.Location = New Point(598, 706)
        btnCancelarMudanza.Margin = New Padding(4)
        btnCancelarMudanza.Name = "btnCancelarMudanza"
        btnCancelarMudanza.Size = New Size(141, 45)
        btnCancelarMudanza.TabIndex = 10
        btnCancelarMudanza.Text = "Cancelar"
        btnCancelarMudanza.UseVisualStyleBackColor = True
        ' 
        ' txtEstado
        ' 
        txtEstado.Location = New Point(135, 630)
        txtEstado.Margin = New Padding(4)
        txtEstado.Name = "txtEstado"
        txtEstado.Size = New Size(539, 31)
        txtEstado.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.White
        Label1.Location = New Point(21, 45)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(69, 25)
        Label1.TabIndex = 12
        Label1.Text = "Cliente:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.White
        Label2.Location = New Point(2, 124)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 25)
        Label2.TabIndex = 13
        Label2.Text = "Empleado:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.White
        Label3.Location = New Point(15, 208)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 25)
        Label3.TabIndex = 14
        Label3.Text = "Vehiculo:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = Color.White
        Label4.Location = New Point(31, 279)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 25)
        Label4.TabIndex = 15
        Label4.Text = "Origen:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = Color.White
        Label5.Location = New Point(21, 368)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(77, 25)
        Label5.TabIndex = 16
        Label5.Text = "Destino:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.ForeColor = Color.White
        Label6.Location = New Point(38, 446)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(61, 25)
        Label6.TabIndex = 17
        Label6.Text = "Fecha:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.ForeColor = Color.White
        Label7.Location = New Point(40, 541)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(63, 25)
        Label7.TabIndex = 18
        Label7.Text = "Costo:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.ForeColor = Color.White
        Label8.Location = New Point(40, 639)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(70, 25)
        Label8.TabIndex = 19
        Label8.Text = "Estado:"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Silver
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(858, 11)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(190, 172)
        PictureBox1.TabIndex = 20
        PictureBox1.TabStop = False
        ' 
        ' FrmDetalleMudanza
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1079, 785)
        Controls.Add(PictureBox1)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtEstado)
        Controls.Add(btnCancelarMudanza)
        Controls.Add(btnCerrar)
        Controls.Add(btnMarcarCompletada)
        Controls.Add(btnMarcarEnProceso)
        Controls.Add(txtEmpleado)
        Controls.Add(txtVehiculo)
        Controls.Add(txtOrigen)
        Controls.Add(txtDestino)
        Controls.Add(txtFecha)
        Controls.Add(txtCosto)
        Controls.Add(txtCliente)
        Margin = New Padding(4)
        Name = "FrmDetalleMudanza"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmDetalleMudanza"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCliente As TextBox
    Friend WithEvents txtCosto As TextBox
    Friend WithEvents txtFecha As TextBox
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents txtVehiculo As TextBox
    Friend WithEvents txtEmpleado As TextBox
    Friend WithEvents btnMarcarEnProceso As Button
    Friend WithEvents btnMarcarCompletada As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnCancelarMudanza As Button
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
