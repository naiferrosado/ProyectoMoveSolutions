<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoUser
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
        txtNombre = New TextBox()
        txtContraseña = New TextBox()
        txtCorreo = New TextBox()
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        cmbRol = New ComboBox()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(224, 84)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(150, 27)
        txtNombre.TabIndex = 0
        ' 
        ' txtContraseña
        ' 
        txtContraseña.Location = New Point(224, 172)
        txtContraseña.Margin = New Padding(3, 4, 3, 4)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(150, 27)
        txtContraseña.TabIndex = 1
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(224, 254)
        txtCorreo.Margin = New Padding(3, 4, 3, 4)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(150, 27)
        txtCorreo.TabIndex = 2
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DarkGreen
        Button1.ForeColor = SystemColors.Control
        Button1.Location = New Point(224, 433)
        Button1.Margin = New Padding(3, 4, 3, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(149, 41)
        Button1.TabIndex = 3
        Button1.Text = "Crear "
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSlateGray
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(266, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(62, 20)
        Label1.TabIndex = 4
        Label1.Text = "Usuario:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(250, 135)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 20)
        Label2.TabIndex = 5
        Label2.Text = "Contraseña:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(258, 221)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 20)
        Label3.TabIndex = 6
        Label3.Text = "Correo:"
        ' 
        ' cmbRol
        ' 
        cmbRol.FormattingEnabled = True
        cmbRol.Items.AddRange(New Object() {"1"})
        cmbRol.Location = New Point(224, 343)
        cmbRol.Margin = New Padding(3, 4, 3, 4)
        cmbRol.Name = "cmbRol"
        cmbRol.Size = New Size(150, 28)
        cmbRol.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(266, 301)
        Label4.Name = "Label4"
        Label4.Size = New Size(34, 20)
        Label4.TabIndex = 8
        Label4.Text = "Rol:"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(2, -25)
        PictureBox1.Margin = New Padding(2, 2, 2, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(178, 126)
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' NuevoUser
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(578, 485)
        Controls.Add(PictureBox1)
        Controls.Add(Label4)
        Controls.Add(cmbRol)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(txtCorreo)
        Controls.Add(txtContraseña)
        Controls.Add(txtNombre)
        Margin = New Padding(3, 4, 3, 4)
        Name = "NuevoUser"
        StartPosition = FormStartPosition.CenterScreen
        Text = "NuevoUser"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbRol As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
