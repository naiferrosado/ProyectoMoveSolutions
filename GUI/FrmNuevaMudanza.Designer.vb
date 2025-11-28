<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevaMudanza
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
        cboClientes = New ComboBox()
        cboEmpleados = New ComboBox()
        cboVehiculos = New ComboBox()
        txtOrigen = New TextBox()
        txtDestino = New TextBox()
        dtpFecha = New DateTimePicker()
        txtCosto = New TextBox()
        btnGuarfar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        btnProbarConexion = New Button()
        Label6 = New Label()
        s = New GroupBox()
        txtDistancia = New TextBox()
        Button2 = New Button()
        PictureBox1 = New PictureBox()
        btnLimpiarMapa = New Button()
        panelMapa = New Panel()
        s.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        panelMapa.SuspendLayout()
        SuspendLayout()
        ' 
        ' cboClientes
        ' 
        cboClientes.FormattingEnabled = True
        cboClientes.Location = New Point(31, 112)
        cboClientes.Margin = New Padding(4)
        cboClientes.Name = "cboClientes"
        cboClientes.Size = New Size(353, 33)
        cboClientes.TabIndex = 0
        ' 
        ' cboEmpleados
        ' 
        cboEmpleados.FormattingEnabled = True
        cboEmpleados.Location = New Point(39, 259)
        cboEmpleados.Margin = New Padding(4)
        cboEmpleados.Name = "cboEmpleados"
        cboEmpleados.Size = New Size(345, 33)
        cboEmpleados.TabIndex = 1
        ' 
        ' cboVehiculos
        ' 
        cboVehiculos.FormattingEnabled = True
        cboVehiculos.Location = New Point(39, 410)
        cboVehiculos.Margin = New Padding(4)
        cboVehiculos.Name = "cboVehiculos"
        cboVehiculos.Size = New Size(345, 33)
        cboVehiculos.TabIndex = 2
        ' 
        ' txtOrigen
        ' 
        txtOrigen.Location = New Point(637, 129)
        txtOrigen.Margin = New Padding(4)
        txtOrigen.Name = "txtOrigen"
        txtOrigen.Size = New Size(404, 31)
        txtOrigen.TabIndex = 3
        ' 
        ' txtDestino
        ' 
        txtDestino.Location = New Point(637, 226)
        txtDestino.Margin = New Padding(4)
        txtDestino.Multiline = True
        txtDestino.Name = "txtDestino"
        txtDestino.Size = New Size(404, 33)
        txtDestino.TabIndex = 4
        ' 
        ' dtpFecha
        ' 
        dtpFecha.Location = New Point(637, 423)
        dtpFecha.Margin = New Padding(4)
        dtpFecha.Name = "dtpFecha"
        dtpFecha.Size = New Size(404, 31)
        dtpFecha.TabIndex = 5
        ' 
        ' txtCosto
        ' 
        txtCosto.Location = New Point(637, 341)
        txtCosto.Margin = New Padding(4)
        txtCosto.Name = "txtCosto"
        txtCosto.Size = New Size(404, 31)
        txtCosto.TabIndex = 6
        ' 
        ' btnGuarfar
        ' 
        btnGuarfar.BackColor = Color.Green
        btnGuarfar.ForeColor = SystemColors.Control
        btnGuarfar.Location = New Point(867, 506)
        btnGuarfar.Margin = New Padding(4)
        btnGuarfar.Name = "btnGuarfar"
        btnGuarfar.Size = New Size(148, 55)
        btnGuarfar.TabIndex = 7
        btnGuarfar.Text = "Guardar"
        btnGuarfar.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.White
        Label1.Location = New Point(39, 42)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(168, 25)
        Label1.TabIndex = 8
        Label1.Text = "Seleeciona el cliente"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.SlateGray
        Label2.ForeColor = Color.White
        Label2.Location = New Point(39, 211)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(197, 25)
        Label2.TabIndex = 9
        Label2.Text = "Selecciona el empleado"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.White
        Label3.Location = New Point(55, 332)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(182, 25)
        Label3.TabIndex = 10
        Label3.Text = "Selecciona el vehiculo"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = Color.White
        Label4.Location = New Point(637, 78)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.RightToLeft = RightToLeft.Yes
        Label4.Size = New Size(70, 25)
        Label4.TabIndex = 30
        Label4.Text = ":Origen"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = Color.White
        Label5.Location = New Point(637, 182)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(73, 25)
        Label5.TabIndex = 12
        Label5.Text = "Destino"
        ' 
        ' btnProbarConexion
        ' 
        btnProbarConexion.BackColor = Color.RoyalBlue
        btnProbarConexion.ForeColor = SystemColors.Control
        btnProbarConexion.Location = New Point(637, 506)
        btnProbarConexion.Margin = New Padding(4)
        btnProbarConexion.Name = "btnProbarConexion"
        btnProbarConexion.Size = New Size(141, 52)
        btnProbarConexion.TabIndex = 13
        btnProbarConexion.Text = "Boton Probar"
        btnProbarConexion.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.ForeColor = Color.White
        Label6.Location = New Point(637, 293)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(63, 25)
        Label6.TabIndex = 14
        Label6.Text = "Costo:"
        ' 
        ' s
        ' 
        s.AccessibleRole = AccessibleRole.Sound
        s.BackColor = Color.SlateGray
        s.Controls.Add(cboClientes)
        s.Controls.Add(Label1)
        s.Controls.Add(Label2)
        s.Controls.Add(cboEmpleados)
        s.Controls.Add(Label3)
        s.Controls.Add(cboVehiculos)
        s.Location = New Point(147, 15)
        s.Margin = New Padding(4)
        s.Name = "s"
        s.Padding = New Padding(4)
        s.Size = New Size(458, 544)
        s.TabIndex = 15
        s.TabStop = False
        ' 
        ' txtDistancia
        ' 
        txtDistancia.Location = New Point(822, 515)
        txtDistancia.Margin = New Padding(4, 5, 4, 5)
        txtDistancia.Name = "txtDistancia"
        txtDistancia.Size = New Size(10, 31)
        txtDistancia.TabIndex = 34
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(822, 515)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(10, 38)
        Button2.TabIndex = 35
        Button2.Text = "Limpiar mapa"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.dejar__1_
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(119, 109)
        PictureBox1.TabIndex = 36
        PictureBox1.TabStop = False
        ' 
        ' btnLimpiarMapa
        ' 
        btnLimpiarMapa.Location = New Point(10, 812)
        btnLimpiarMapa.Margin = New Padding(4, 5, 4, 5)
        btnLimpiarMapa.Name = "btnLimpiarMapa"
        btnLimpiarMapa.Size = New Size(107, 38)
        btnLimpiarMapa.TabIndex = 8
        btnLimpiarMapa.Text = "Limpiar"
        btnLimpiarMapa.UseVisualStyleBackColor = True
        ' 
        ' panelMapa
        ' 
        panelMapa.Controls.Add(btnLimpiarMapa)
        panelMapa.Location = New Point(0, 644)
        panelMapa.Margin = New Padding(4, 5, 4, 5)
        panelMapa.Name = "panelMapa"
        panelMapa.Size = New Size(1087, 409)
        panelMapa.TabIndex = 33
        ' 
        ' FrmNuevaMudanza
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1100, 1050)
        Controls.Add(PictureBox1)
        Controls.Add(Button2)
        Controls.Add(panelMapa)
        Controls.Add(s)
        Controls.Add(Label6)
        Controls.Add(btnProbarConexion)
        Controls.Add(Label5)
        Controls.Add(txtDistancia)
        Controls.Add(Label4)
        Controls.Add(btnGuarfar)
        Controls.Add(txtCosto)
        Controls.Add(dtpFecha)
        Controls.Add(txtDestino)
        Controls.Add(txtOrigen)
        ForeColor = SystemColors.ControlText
        Margin = New Padding(4)
        Name = "FrmNuevaMudanza"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmNuevaMudanza"
        WindowState = FormWindowState.Maximized
        s.ResumeLayout(False)
        s.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        panelMapa.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboClientes As ComboBox
    Friend WithEvents cboEmpleados As ComboBox
    Friend WithEvents cboVehiculos As ComboBox
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents txtCosto As TextBox
    Friend WithEvents btnGuarfar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnProbarConexion As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents s As GroupBox
    Friend WithEvents txtDistancia As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnLimpiarMapa As Button
    Friend WithEvents panelMapa As Panel
End Class
