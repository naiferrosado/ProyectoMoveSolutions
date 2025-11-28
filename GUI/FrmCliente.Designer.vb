<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCliente
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
        dgvClientes = New DataGridView()
        lblTotal = New Label()
        Button5 = New Button()
        txtBuscar = New TextBox()
        btnCancelar = New Button()
        Label4 = New Label()
        Button2 = New Button()
        btnEliminar = New Button()
        btnGuardar = New Button()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtDireccion = New TextBox()
        txtCorreo = New TextBox()
        txtTelefono = New TextBox()
        GroupBox1 = New GroupBox()
        txtNombre = New TextBox()
        Button1 = New Button()
        CType(dgvClientes, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvClientes
        ' 
        dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClientes.Location = New Point(13, 301)
        dgvClientes.Margin = New Padding(4, 5, 4, 5)
        dgvClientes.Name = "dgvClientes"
        dgvClientes.RowHeadersWidth = 62
        dgvClientes.Size = New Size(1039, 492)
        dgvClientes.TabIndex = 7
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.ForeColor = SystemColors.Control
        lblTotal.Location = New Point(764, 78)
        lblTotal.Margin = New Padding(4, 0, 4, 0)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(98, 29)
        lblTotal.TabIndex = 10
        lblTotal.Text = "lblTotal"
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(899, 282)
        Button5.Margin = New Padding(4, 5, 4, 5)
        Button5.Name = "Button5"
        Button5.Size = New Size(108, 38)
        Button5.TabIndex = 9
        Button5.Text = "Buscar"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(718, 282)
        txtBuscar.Margin = New Padding(4, 5, 4, 5)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(142, 31)
        txtBuscar.TabIndex = 8
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.DarkSlateGray
        btnCancelar.Font = New Font("Arial Narrow", 12F, FontStyle.Bold)
        btnCancelar.ForeColor = SystemColors.Control
        btnCancelar.Location = New Point(567, 142)
        btnCancelar.Margin = New Padding(4, 5, 4, 5)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(142, 58)
        btnCancelar.TabIndex = 3
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(39, 211)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(89, 25)
        Label4.TabIndex = 7
        Label4.Text = "Direccion:"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Orange
        Button2.Font = New Font("Arial Narrow", 12F, FontStyle.Bold)
        Button2.ForeColor = SystemColors.Control
        Button2.Location = New Point(567, 71)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(142, 58)
        Button2.TabIndex = 1
        Button2.Text = "Actualizar"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Color.Red
        btnEliminar.Font = New Font("Arial Narrow", 12F, FontStyle.Bold)
        btnEliminar.ForeColor = SystemColors.Control
        btnEliminar.Location = New Point(402, 71)
        btnEliminar.Margin = New Padding(4, 5, 4, 5)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(142, 58)
        btnEliminar.TabIndex = 2
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.Green
        btnGuardar.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGuardar.ForeColor = SystemColors.Control
        btnGuardar.Location = New Point(402, 142)
        btnGuardar.Margin = New Padding(4, 5, 4, 5)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(142, 58)
        btnGuardar.TabIndex = 0
        btnGuardar.Text = "Agregar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(39, 165)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(70, 25)
        Label3.TabIndex = 6
        Label3.Text = "Correo:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(37, 115)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 25)
        Label2.TabIndex = 5
        Label2.Text = "Telefono:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(39, 68)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 25)
        Label1.TabIndex = 4
        Label1.Text = "Nombre:"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Location = New Point(128, 208)
        txtDireccion.Margin = New Padding(4, 5, 4, 5)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(241, 31)
        txtDireccion.TabIndex = 1
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(128, 162)
        txtCorreo.Margin = New Padding(4, 5, 4, 5)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(241, 31)
        txtCorreo.TabIndex = 2
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(128, 112)
        txtTelefono.Margin = New Padding(4, 5, 4, 5)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(241, 31)
        txtTelefono.TabIndex = 3
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblTotal)
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(txtBuscar)
        GroupBox1.Controls.Add(btnCancelar)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(btnEliminar)
        GroupBox1.Controls.Add(btnGuardar)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtNombre)
        GroupBox1.Controls.Add(txtDireccion)
        GroupBox1.Controls.Add(txtCorreo)
        GroupBox1.Controls.Add(txtTelefono)
        GroupBox1.Location = New Point(13, 23)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(892, 268)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        GroupBox1.Text = "GroupBox1"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(128, 65)
        txtNombre.Margin = New Padding(4, 5, 4, 5)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(241, 31)
        txtNombre.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(1016, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(114, 41)
        Button1.TabIndex = 8
        Button1.Text = "Atrás"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' FrmCliente
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1142, 822)
        Controls.Add(Button1)
        Controls.Add(dgvClientes)
        Controls.Add(GroupBox1)
        Margin = New Padding(4, 5, 4, 5)
        Name = "FrmCliente"
        Text = "FrmCliente"
        CType(dgvClientes, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Button1 As Button
End Class
