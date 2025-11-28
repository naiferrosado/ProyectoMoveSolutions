<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVahiculos
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
        txtPlaca = New TextBox()
        txtModelo = New TextBox()
        txtCapacidad = New TextBox()
        GroupBox1 = New GroupBox()
        cmbEstado = New ComboBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        lblTotal = New Label()
        btnCancelar = New Button()
        Button3 = New Button()
        Button2 = New Button()
        btnGuardar = New Button()
        txtBuscar = New TextBox()
        Button5 = New Button()
        dgvVehiculos = New DataGridView()
        PictureBox1 = New PictureBox()
        Label5 = New Label()
        GroupBox1.SuspendLayout()
        CType(dgvVehiculos, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtPlaca
        ' 
        txtPlaca.Location = New Point(138, 26)
        txtPlaca.Margin = New Padding(3, 4, 3, 4)
        txtPlaca.Name = "txtPlaca"
        txtPlaca.Size = New Size(201, 27)
        txtPlaca.TabIndex = 0
        ' 
        ' txtModelo
        ' 
        txtModelo.Location = New Point(138, 85)
        txtModelo.Margin = New Padding(3, 4, 3, 4)
        txtModelo.Name = "txtModelo"
        txtModelo.Size = New Size(201, 27)
        txtModelo.TabIndex = 2
        ' 
        ' txtCapacidad
        ' 
        txtCapacidad.Location = New Point(138, 146)
        txtCapacidad.Margin = New Padding(3, 4, 3, 4)
        txtCapacidad.Name = "txtCapacidad"
        txtCapacidad.Size = New Size(201, 27)
        txtCapacidad.TabIndex = 3
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(cmbEstado)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(lblTotal)
        GroupBox1.Controls.Add(btnCancelar)
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(btnGuardar)
        GroupBox1.Controls.Add(txtPlaca)
        GroupBox1.Controls.Add(txtCapacidad)
        GroupBox1.Controls.Add(txtModelo)
        GroupBox1.Location = New Point(65, 53)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(717, 248)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        ' 
        ' cmbEstado
        ' 
        cmbEstado.FormattingEnabled = True
        cmbEstado.Location = New Point(138, 196)
        cmbEstado.Margin = New Padding(3, 4, 3, 4)
        cmbEstado.Name = "cmbEstado"
        cmbEstado.Size = New Size(201, 28)
        cmbEstado.TabIndex = 13
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = Color.White
        Label4.Location = New Point(58, 205)
        Label4.Name = "Label4"
        Label4.Size = New Size(57, 20)
        Label4.TabIndex = 12
        Label4.Text = "Estado:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.White
        Label3.Location = New Point(6, 151)
        Label3.Name = "Label3"
        Label3.Size = New Size(125, 20)
        Label3.TabIndex = 11
        Label3.Text = "Capacidad en KG:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.White
        Label2.Location = New Point(58, 89)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 20)
        Label2.TabIndex = 10
        Label2.Text = "Modelo:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.White
        Label1.Location = New Point(58, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 20)
        Label1.TabIndex = 9
        Label1.Text = "Placa:"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(639, 31)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(56, 22)
        lblTotal.TabIndex = 8
        lblTotal.Text = "Label1"
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.DarkSlateGray
        btnCancelar.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        btnCancelar.ForeColor = SystemColors.Control
        btnCancelar.Location = New Point(547, 200)
        btnCancelar.Margin = New Padding(3, 4, 3, 4)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(86, 31)
        btnCancelar.TabIndex = 7
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Orange
        Button3.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        Button3.ForeColor = SystemColors.Control
        Button3.Location = New Point(547, 146)
        Button3.Margin = New Padding(3, 4, 3, 4)
        Button3.Name = "Button3"
        Button3.Size = New Size(86, 31)
        Button3.TabIndex = 6
        Button3.Text = "Actualizar"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Red
        Button2.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        Button2.ForeColor = SystemColors.Control
        Button2.Location = New Point(547, 90)
        Button2.Margin = New Padding(3, 4, 3, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(86, 31)
        Button2.TabIndex = 5
        Button2.Text = "Eliminar"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.Green
        btnGuardar.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        btnGuardar.ForeColor = SystemColors.Control
        btnGuardar.Location = New Point(547, 31)
        btnGuardar.Margin = New Padding(3, 4, 3, 4)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(86, 31)
        btnGuardar.TabIndex = 4
        btnGuardar.Text = "Agregar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(114, 310)
        txtBuscar.Margin = New Padding(3, 4, 3, 4)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(230, 27)
        txtBuscar.TabIndex = 8
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Arial Narrow", 10F, FontStyle.Bold)
        Button5.Location = New Point(17, 308)
        Button5.Margin = New Padding(3, 4, 3, 4)
        Button5.Name = "Button5"
        Button5.Size = New Size(86, 31)
        Button5.TabIndex = 8
        Button5.Text = "Buscar"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' dgvVehiculos
        ' 
        dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvVehiculos.Location = New Point(14, 352)
        dgvVehiculos.Margin = New Padding(3, 4, 3, 4)
        dgvVehiculos.Name = "dgvVehiculos"
        dgvVehiculos.RowHeadersWidth = 51
        dgvVehiculos.Size = New Size(810, 259)
        dgvVehiculos.TabIndex = 9
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(1, -18)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(161, 113)
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.Control
        Label5.Location = New Point(342, 7)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(143, 32)
        Label5.TabIndex = 11
        Label5.Text = "Vehículos"
        ' 
        ' FrmVahiculos
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(835, 621)
        Controls.Add(Label5)
        Controls.Add(PictureBox1)
        Controls.Add(dgvVehiculos)
        Controls.Add(Button5)
        Controls.Add(txtBuscar)
        Controls.Add(GroupBox1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FrmVahiculos"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmVahiculos"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvVehiculos, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtPlaca As TextBox
    Friend WithEvents txtModelo As TextBox
    Friend WithEvents txtCapacidad As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents dgvVehiculos As DataGridView
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
End Class
