<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Panel1 = New Panel()
        Button7 = New Button()
        Button6 = New Button()
        btnIrAEmpleados = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        Button8 = New Button()
        Button9 = New Button()
        Button10 = New Button()
        Panel2 = New Panel()
        Label3 = New Label()
        Panel3 = New Panel()
        Label4 = New Label()
        DataGridView1 = New DataGridView()
        TextBox1 = New TextBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkSlateGray
        Panel1.Controls.Add(Button7)
        Panel1.Controls.Add(Button6)
        Panel1.Controls.Add(btnIrAEmpleados)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(1, 2)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(238, 642)
        Panel1.TabIndex = 0
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(35, 576)
        Button7.Margin = New Padding(2)
        Button7.Name = "Button7"
        Button7.Size = New Size(144, 34)
        Button7.TabIndex = 8
        Button7.Text = "Reportes"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(35, 522)
        Button6.Margin = New Padding(2)
        Button6.Name = "Button6"
        Button6.Size = New Size(144, 34)
        Button6.TabIndex = 7
        Button6.Text = "Facturacion"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' btnIrAEmpleados
        ' 
        btnIrAEmpleados.Location = New Point(35, 460)
        btnIrAEmpleados.Margin = New Padding(2)
        btnIrAEmpleados.Name = "btnIrAEmpleados"
        btnIrAEmpleados.Size = New Size(144, 34)
        btnIrAEmpleados.TabIndex = 6
        btnIrAEmpleados.Text = "Empleados"
        btnIrAEmpleados.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(35, 402)
        Button4.Margin = New Padding(2)
        Button4.Name = "Button4"
        Button4.Size = New Size(144, 34)
        Button4.TabIndex = 5
        Button4.Text = "Vehiculos"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(35, 344)
        Button3.Margin = New Padding(2)
        Button3.Name = "Button3"
        Button3.Size = New Size(144, 34)
        Button3.TabIndex = 4
        Button3.Text = "Mudanzas"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(35, 285)
        Button2.Margin = New Padding(2)
        Button2.Name = "Button2"
        Button2.Size = New Size(144, 34)
        Button2.TabIndex = 3
        Button2.Text = "Clientes"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(35, 225)
        Button1.Margin = New Padding(2)
        Button1.Name = "Button1"
        Button1.Size = New Size(144, 34)
        Button1.TabIndex = 2
        Button1.Text = "Dashboard"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(42, 188)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(136, 25)
        Label1.TabIndex = 1
        Label1.Text = "Move Solutions"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(2, 0)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(190, 172)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(244, 12)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(148, 25)
        Label2.TabIndex = 1
        Label2.Text = "Resumen General"
        ' 
        ' Button8
        ' 
        Button8.BackColor = Color.DarkGreen
        Button8.ForeColor = SystemColors.Control
        Button8.Location = New Point(416, 12)
        Button8.Margin = New Padding(2)
        Button8.Name = "Button8"
        Button8.Size = New Size(169, 41)
        Button8.TabIndex = 2
        Button8.Text = "Nueva Mudanza"
        Button8.UseVisualStyleBackColor = False
        ' 
        ' Button9
        ' 
        Button9.BackColor = Color.Blue
        Button9.ForeColor = SystemColors.Control
        Button9.Location = New Point(590, 14)
        Button9.Margin = New Padding(2)
        Button9.Name = "Button9"
        Button9.Size = New Size(199, 41)
        Button9.TabIndex = 3
        Button9.Text = "Gestion de Usuarios"
        Button9.UseVisualStyleBackColor = False
        ' 
        ' Button10
        ' 
        Button10.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Button10.ForeColor = SystemColors.Control
        Button10.Location = New Point(794, 12)
        Button10.Margin = New Padding(2)
        Button10.Name = "Button10"
        Button10.Size = New Size(112, 41)
        Button10.TabIndex = 4
        Button10.Text = "Reportes"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkSlateGray
        Panel2.Controls.Add(Label3)
        Panel2.Location = New Point(262, 70)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(263, 150)
        Panel2.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(16, 18)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(235, 24)
        Label3.TabIndex = 0
        Label3.Text = "Mudanzas Completadas"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkSlateGray
        Panel3.Controls.Add(Label4)
        Panel3.Location = New Point(552, 70)
        Panel3.Margin = New Padding(2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(192, 150)
        Panel3.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 10F, FontStyle.Bold)
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(15, 18)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(171, 24)
        Label4.TabIndex = 0
        Label4.Text = "Ingresos del Mes"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(244, 296)
        DataGridView1.Margin = New Padding(2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(670, 335)
        DataGridView1.TabIndex = 9
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(262, 248)
        TextBox1.Margin = New Padding(2)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(376, 31)
        TextBox1.TabIndex = 13
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(941, 744)
        Controls.Add(TextBox1)
        Controls.Add(DataGridView1)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Button10)
        Controls.Add(Button9)
        Controls.Add(Button8)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(2)
        Name = "Dashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Dashboard"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents btnIrAEmpleados As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
End Class
