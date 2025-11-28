<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        txtUsuario = New TextBox()
        txtContraseña = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Label3 = New Label()
        PictureBox1 = New PictureBox()
        Label4 = New Label()
        PictureBox2 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(270, 406)
        txtUsuario.Margin = New Padding(2)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(223, 31)
        txtUsuario.TabIndex = 0
        ' 
        ' txtContraseña
        ' 
        txtContraseña.Location = New Point(270, 496)
        txtContraseña.Margin = New Padding(2)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(223, 31)
        txtContraseña.TabIndex = 1
        txtContraseña.UseSystemPasswordChar = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(333, 359)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 32)
        Label1.TabIndex = 2
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(309, 453)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(145, 32)
        Label2.TabIndex = 3
        Label2.Text = "Contraseña"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Green
        Button1.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold)
        Button1.ForeColor = SystemColors.ButtonHighlight
        Button1.Location = New Point(271, 548)
        Button1.Margin = New Padding(2)
        Button1.Name = "Button1"
        Button1.Size = New Size(222, 55)
        Button1.TabIndex = 4
        Button1.Text = "Iniciar"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(236, 48)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(297, 48)
        Label3.TabIndex = 6
        Label3.Text = "Inicio de Sesión"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(11, 12)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(208, 148)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(11, 9)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(197, 32)
        Label4.TabIndex = 8
        Label4.Text = "Move Solutions"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.circulo_de_usuario__3_
        PictureBox2.Location = New Point(291, 138)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(247, 218)
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(800, 618)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(Label4)
        Controls.Add(PictureBox1)
        Controls.Add(Label3)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(txtContraseña)
        Controls.Add(txtUsuario)
        Margin = New Padding(2)
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
