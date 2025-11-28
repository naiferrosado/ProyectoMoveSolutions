<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionMudanzas
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
        Panel2 = New Panel()
        lblCompletadas = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        DataGridView1 = New DataGridView()
        Button8 = New Button()
        Label4 = New Label()
        Button10 = New Button()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Panel2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.SlateGray
        Panel2.Controls.Add(lblCompletadas)
        Panel2.Controls.Add(Label3)
        Panel2.Location = New Point(187, 80)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(226, 126)
        Panel2.TabIndex = 9
        ' 
        ' lblCompletadas
        ' 
        lblCompletadas.AutoSize = True
        lblCompletadas.Font = New Font("Arial", 10F, FontStyle.Bold)
        lblCompletadas.ForeColor = SystemColors.Control
        lblCompletadas.Location = New Point(69, 70)
        lblCompletadas.Name = "lblCompletadas"
        lblCompletadas.Size = New Size(60, 19)
        lblCompletadas.TabIndex = 1
        lblCompletadas.Text = "Label2"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 10F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(26, 15)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(195, 19)
        Label3.TabIndex = 0
        Label3.Text = "Mudanzas Completadas"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(112, 234)
        TextBox1.Margin = New Padding(2)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(302, 27)
        TextBox1.TabIndex = 13
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(9, 270)
        DataGridView1.Margin = New Padding(2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(976, 223)
        DataGridView1.TabIndex = 14
        ' 
        ' Button8
        ' 
        Button8.BackColor = Color.DarkGreen
        Button8.Font = New Font("Arial", 10F, FontStyle.Bold)
        Button8.ForeColor = SystemColors.Control
        Button8.Location = New Point(493, 210)
        Button8.Margin = New Padding(2)
        Button8.Name = "Button8"
        Button8.Size = New Size(196, 33)
        Button8.TabIndex = 15
        Button8.Text = "Nueva Mudanza"
        Button8.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(28, 224)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(65, 19)
        Label4.TabIndex = 16
        Label4.Text = "Buscar"
        ' 
        ' Button10
        ' 
        Button10.BackColor = Color.SteelBlue
        Button10.Font = New Font("Arial", 10F, FontStyle.Bold)
        Button10.ForeColor = SystemColors.Control
        Button10.Location = New Point(734, 210)
        Button10.Margin = New Padding(2)
        Button10.Name = "Button10"
        Button10.Size = New Size(196, 33)
        Button10.TabIndex = 18
        Button10.Text = "Seguimiento Mundaza"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(5, -20)
        PictureBox1.Margin = New Padding(2, 2, 2, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(178, 126)
        PictureBox1.TabIndex = 19
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(382, 23)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(279, 35)
        Label1.TabIndex = 20
        Label1.Text = "Gestión Mudanzas"
        ' 
        ' GestionMudanzas
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(992, 526)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(Button10)
        Controls.Add(Label4)
        Controls.Add(Button8)
        Controls.Add(DataGridView1)
        Controls.Add(TextBox1)
        Controls.Add(Panel2)
        Margin = New Padding(2)
        Name = "GestionMudanzas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GestionMudanzas"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button8 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents lblCompletadas As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
End Class
