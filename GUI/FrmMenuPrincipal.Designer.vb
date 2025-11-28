<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPrincipal
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
        btnIrAClientes = New Button()
        btnIrAEmpleados = New Button()
        btnIrAMudanzas = New Button()
        btnIrAVehiculos = New Button()
        btnIrAReportes = New Button()
        btnIrAFacturacion = New Button()
        btnIrAUsuarios = New Button()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Narrow", 28F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(352, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(357, 66)
        Label1.TabIndex = 0
        Label1.Text = "Menú Principal"
        ' 
        ' btnIrAClientes
        ' 
        btnIrAClientes.BackColor = Color.Olive
        btnIrAClientes.Font = New Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnIrAClientes.ForeColor = SystemColors.Control
        btnIrAClientes.Location = New Point(456, 177)
        btnIrAClientes.Name = "btnIrAClientes"
        btnIrAClientes.Size = New Size(201, 65)
        btnIrAClientes.TabIndex = 2
        btnIrAClientes.Text = "Clientes"
        btnIrAClientes.UseVisualStyleBackColor = False
        ' 
        ' btnIrAEmpleados
        ' 
        btnIrAEmpleados.BackColor = Color.DarkGreen
        btnIrAEmpleados.Font = New Font("Arial Black", 12F, FontStyle.Bold)
        btnIrAEmpleados.ForeColor = SystemColors.Control
        btnIrAEmpleados.Location = New Point(227, 177)
        btnIrAEmpleados.Name = "btnIrAEmpleados"
        btnIrAEmpleados.Size = New Size(201, 65)
        btnIrAEmpleados.TabIndex = 3
        btnIrAEmpleados.Text = "Empleados"
        btnIrAEmpleados.UseVisualStyleBackColor = False
        ' 
        ' btnIrAMudanzas
        ' 
        btnIrAMudanzas.BackColor = Color.Orange
        btnIrAMudanzas.Font = New Font("Arial Black", 12F, FontStyle.Bold)
        btnIrAMudanzas.ForeColor = SystemColors.Control
        btnIrAMudanzas.Location = New Point(227, 279)
        btnIrAMudanzas.Name = "btnIrAMudanzas"
        btnIrAMudanzas.Size = New Size(201, 65)
        btnIrAMudanzas.TabIndex = 4
        btnIrAMudanzas.Text = "Mudanzas"
        btnIrAMudanzas.UseVisualStyleBackColor = False
        ' 
        ' btnIrAVehiculos
        ' 
        btnIrAVehiculos.BackColor = Color.SlateGray
        btnIrAVehiculos.Font = New Font("Arial Black", 12F, FontStyle.Bold)
        btnIrAVehiculos.ForeColor = SystemColors.Control
        btnIrAVehiculos.Location = New Point(685, 177)
        btnIrAVehiculos.Name = "btnIrAVehiculos"
        btnIrAVehiculos.Size = New Size(201, 65)
        btnIrAVehiculos.TabIndex = 5
        btnIrAVehiculos.Text = "Vehículos"
        btnIrAVehiculos.UseVisualStyleBackColor = False
        ' 
        ' btnIrAReportes
        ' 
        btnIrAReportes.BackColor = Color.SlateBlue
        btnIrAReportes.Font = New Font("Arial Black", 12F, FontStyle.Bold)
        btnIrAReportes.ForeColor = SystemColors.Control
        btnIrAReportes.Location = New Point(456, 381)
        btnIrAReportes.Name = "btnIrAReportes"
        btnIrAReportes.Size = New Size(201, 65)
        btnIrAReportes.TabIndex = 6
        btnIrAReportes.Text = "Reportes"
        btnIrAReportes.UseVisualStyleBackColor = False
        ' 
        ' btnIrAFacturacion
        ' 
        btnIrAFacturacion.BackColor = Color.Indigo
        btnIrAFacturacion.Font = New Font("Arial Black", 12F, FontStyle.Bold)
        btnIrAFacturacion.ForeColor = SystemColors.Control
        btnIrAFacturacion.Location = New Point(685, 279)
        btnIrAFacturacion.Name = "btnIrAFacturacion"
        btnIrAFacturacion.Size = New Size(201, 65)
        btnIrAFacturacion.TabIndex = 7
        btnIrAFacturacion.Text = "Facturación"
        btnIrAFacturacion.UseVisualStyleBackColor = False
        ' 
        ' btnIrAUsuarios
        ' 
        btnIrAUsuarios.BackColor = Color.DeepPink
        btnIrAUsuarios.Font = New Font("Arial Black", 12F, FontStyle.Bold)
        btnIrAUsuarios.ForeColor = SystemColors.Control
        btnIrAUsuarios.Location = New Point(456, 279)
        btnIrAUsuarios.Name = "btnIrAUsuarios"
        btnIrAUsuarios.Size = New Size(201, 65)
        btnIrAUsuarios.TabIndex = 8
        btnIrAUsuarios.Text = "Usuarios"
        btnIrAUsuarios.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.InitialImage = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(223, 158)
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(12, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(161, 29)
        Label2.TabIndex = 10
        Label2.Text = "Move Solutions"
        ' 
        ' FrmMenuPrincipal
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1030, 624)
        Controls.Add(Label2)
        Controls.Add(PictureBox1)
        Controls.Add(btnIrAUsuarios)
        Controls.Add(btnIrAFacturacion)
        Controls.Add(btnIrAReportes)
        Controls.Add(btnIrAVehiculos)
        Controls.Add(btnIrAMudanzas)
        Controls.Add(btnIrAEmpleados)
        Controls.Add(btnIrAClientes)
        Controls.Add(Label1)
        Name = "FrmMenuPrincipal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmMenuPrincipal"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnIrAClientes As Button
    Friend WithEvents btnIrAEmpleados As Button
    Friend WithEvents btnIrAMudanzas As Button
    Friend WithEvents btnIrAVehiculos As Button
    Friend WithEvents btnIrAReportes As Button
    Friend WithEvents btnIrAFacturacion As Button
    Friend WithEvents btnIrAUsuarios As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
End Class
