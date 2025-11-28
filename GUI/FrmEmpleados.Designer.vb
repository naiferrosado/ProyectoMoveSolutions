<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmpleados
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
        grpDatosEmpleado = New GroupBox()
        cmbDisponibilidad = New ComboBox()
        Label5 = New Label()
        Label4 = New Label()
        cmbRol = New ComboBox()
        txtTelefono = New TextBox()
        Label3 = New Label()
        txtNombre = New TextBox()
        Label2 = New Label()
        txtEmpleadoId = New TextBox()
        Label1 = New Label()
        pnlAcciones = New Panel()
        btnEliminar = New Button()
        btnEditar = New Button()
        btnGuardar = New Button()
        btnNuevo = New Button()
        dgvEmpleados = New DataGridView()
        colId = New DataGridViewTextBoxColumn()
        colNombre = New DataGridViewTextBoxColumn()
        colTelefono = New DataGridViewTextBoxColumn()
        colRol = New DataGridViewTextBoxColumn()
        colDisp = New DataGridViewTextBoxColumn()
        PictureBox1 = New PictureBox()
        Label6 = New Label()
        grpDatosEmpleado.SuspendLayout()
        pnlAcciones.SuspendLayout()
        CType(dgvEmpleados, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' grpDatosEmpleado
        ' 
        grpDatosEmpleado.Controls.Add(cmbDisponibilidad)
        grpDatosEmpleado.Controls.Add(Label5)
        grpDatosEmpleado.Controls.Add(Label4)
        grpDatosEmpleado.Controls.Add(cmbRol)
        grpDatosEmpleado.Controls.Add(txtTelefono)
        grpDatosEmpleado.Controls.Add(Label3)
        grpDatosEmpleado.Controls.Add(txtNombre)
        grpDatosEmpleado.Controls.Add(Label2)
        grpDatosEmpleado.Controls.Add(txtEmpleadoId)
        grpDatosEmpleado.Controls.Add(Label1)
        grpDatosEmpleado.Location = New Point(232, 74)
        grpDatosEmpleado.Margin = New Padding(2)
        grpDatosEmpleado.Name = "grpDatosEmpleado"
        grpDatosEmpleado.Padding = New Padding(2)
        grpDatosEmpleado.Size = New Size(804, 238)
        grpDatosEmpleado.TabIndex = 0
        grpDatosEmpleado.TabStop = False
        grpDatosEmpleado.Text = "Datos del Empleado"
        ' 
        ' cmbDisponibilidad
        ' 
        cmbDisponibilidad.FormattingEnabled = True
        cmbDisponibilidad.Items.AddRange(New Object() {"Disponible", "Ocupado", "Fuera de servicio"})
        cmbDisponibilidad.Location = New Point(584, 142)
        cmbDisponibilidad.Margin = New Padding(2)
        cmbDisponibilidad.Name = "cmbDisponibilidad"
        cmbDisponibilidad.Size = New Size(206, 33)
        cmbDisponibilidad.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        Label5.ForeColor = SystemColors.Control
        Label5.Location = New Point(436, 142)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(125, 24)
        Label5.TabIndex = 8
        Label5.Text = "Disponibilidad:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(511, 80)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(41, 24)
        Label4.TabIndex = 7
        Label4.Text = "Rol:"
        ' 
        ' cmbRol
        ' 
        cmbRol.FormattingEnabled = True
        cmbRol.Items.AddRange(New Object() {"Conductor", "Ayudante", "Supervisor", "Oficina"})
        cmbRol.Location = New Point(584, 78)
        cmbRol.Margin = New Padding(2)
        cmbRol.Name = "cmbRol"
        cmbRol.Size = New Size(206, 33)
        cmbRol.TabIndex = 6
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(126, 175)
        txtTelefono.Margin = New Padding(2)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(206, 31)
        txtTelefono.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(28, 175)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 24)
        Label3.TabIndex = 4
        Label3.Text = "Teléfono:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(126, 120)
        txtNombre.Margin = New Padding(2)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(206, 31)
        txtNombre.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(25, 120)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 24)
        Label2.TabIndex = 2
        Label2.Text = "Nombre:"
        ' 
        ' txtEmpleadoId
        ' 
        txtEmpleadoId.Location = New Point(126, 55)
        txtEmpleadoId.Margin = New Padding(2)
        txtEmpleadoId.Name = "txtEmpleadoId"
        txtEmpleadoId.ReadOnly = True
        txtEmpleadoId.Size = New Size(206, 31)
        txtEmpleadoId.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(28, 55)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(31, 24)
        Label1.TabIndex = 0
        Label1.Text = "ID:"
        ' 
        ' pnlAcciones
        ' 
        pnlAcciones.Controls.Add(btnEliminar)
        pnlAcciones.Controls.Add(btnEditar)
        pnlAcciones.Controls.Add(btnGuardar)
        pnlAcciones.Controls.Add(btnNuevo)
        pnlAcciones.Location = New Point(25, 301)
        pnlAcciones.Margin = New Padding(2)
        pnlAcciones.Name = "pnlAcciones"
        pnlAcciones.Size = New Size(722, 92)
        pnlAcciones.TabIndex = 1
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Color.Red
        btnEliminar.FlatStyle = FlatStyle.Flat
        btnEliminar.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        btnEliminar.ForeColor = SystemColors.Control
        btnEliminar.Location = New Point(468, 30)
        btnEliminar.Margin = New Padding(2)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(112, 44)
        btnEliminar.TabIndex = 3
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' btnEditar
        ' 
        btnEditar.BackColor = Color.Orange
        btnEditar.FlatStyle = FlatStyle.Flat
        btnEditar.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        btnEditar.ForeColor = SystemColors.Control
        btnEditar.Location = New Point(331, 30)
        btnEditar.Margin = New Padding(2)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(112, 44)
        btnEditar.TabIndex = 2
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.LimeGreen
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        btnGuardar.ForeColor = SystemColors.Control
        btnGuardar.Location = New Point(181, 30)
        btnGuardar.Margin = New Padding(2)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(112, 44)
        btnGuardar.TabIndex = 1
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = SystemColors.HotTrack
        btnNuevo.FlatStyle = FlatStyle.Flat
        btnNuevo.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        btnNuevo.ForeColor = SystemColors.Control
        btnNuevo.Location = New Point(15, 30)
        btnNuevo.Margin = New Padding(2)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(112, 44)
        btnNuevo.TabIndex = 0
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' dgvEmpleados
        ' 
        dgvEmpleados.AllowUserToAddRows = False
        dgvEmpleados.AllowUserToDeleteRows = False
        dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEmpleados.Columns.AddRange(New DataGridViewColumn() {colId, colNombre, colTelefono, colRol, colDisp})
        dgvEmpleados.Location = New Point(25, 399)
        dgvEmpleados.Margin = New Padding(2)
        dgvEmpleados.Name = "dgvEmpleados"
        dgvEmpleados.ReadOnly = True
        dgvEmpleados.RowHeadersWidth = 62
        dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEmpleados.Size = New Size(860, 292)
        dgvEmpleados.TabIndex = 2
        ' 
        ' colId
        ' 
        colId.HeaderText = "ID"
        colId.MinimumWidth = 8
        colId.Name = "colId"
        colId.ReadOnly = True
        ' 
        ' colNombre
        ' 
        colNombre.HeaderText = "Nombre"
        colNombre.MinimumWidth = 8
        colNombre.Name = "colNombre"
        colNombre.ReadOnly = True
        ' 
        ' colTelefono
        ' 
        colTelefono.HeaderText = "Teléfono"
        colTelefono.MinimumWidth = 8
        colTelefono.Name = "colTelefono"
        colTelefono.ReadOnly = True
        ' 
        ' colRol
        ' 
        colRol.HeaderText = "Rol"
        colRol.MinimumWidth = 8
        colRol.Name = "colRol"
        colRol.ReadOnly = True
        ' 
        ' colDisp
        ' 
        colDisp.HeaderText = "Disponibilidad"
        colDisp.MinimumWidth = 8
        colDisp.Name = "colDisp"
        colDisp.ReadOnly = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(2, 4)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(208, 148)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.Control
        Label6.Location = New Point(408, 22)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(187, 37)
        Label6.TabIndex = 12
        Label6.Text = "Empleados"
        ' 
        ' FrmEmpleados
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1066, 698)
        Controls.Add(Label6)
        Controls.Add(PictureBox1)
        Controls.Add(dgvEmpleados)
        Controls.Add(pnlAcciones)
        Controls.Add(grpDatosEmpleado)
        Margin = New Padding(2)
        Name = "FrmEmpleados"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmEmpleados"
        grpDatosEmpleado.ResumeLayout(False)
        grpDatosEmpleado.PerformLayout()
        pnlAcciones.ResumeLayout(False)
        CType(dgvEmpleados, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents grpDatosEmpleado As GroupBox
    Friend WithEvents txtEmpleadoId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbRol As ComboBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbDisponibilidad As ComboBox
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents dgvEmpleados As DataGridView
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colNombre As DataGridViewTextBoxColumn
    Friend WithEvents colTelefono As DataGridViewTextBoxColumn
    Friend WithEvents colRol As DataGridViewTextBoxColumn
    Friend WithEvents colDisp As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label6 As Label
End Class
