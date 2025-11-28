<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionClientes
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
        Label2 = New Label()
        Panel3 = New Panel()
        Label4 = New Label()
        Panel2 = New Panel()
        Label3 = New Label()
        Button8 = New Button()
        DataGridView1 = New DataGridView()
        TextBox1 = New TextBox()
        Label5 = New Label()
        PictureBox1 = New PictureBox()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(352, 9)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(348, 51)
        Label2.TabIndex = 2
        Label2.Text = "Gestión Clientes"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.SlateGray
        Panel3.Controls.Add(Label4)
        Panel3.Location = New Point(509, 125)
        Panel3.Margin = New Padding(2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(275, 150)
        Panel3.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(21, 22)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(244, 29)
        Label4.TabIndex = 0
        Label4.Text = "Clientes a Contactar"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.SlateGray
        Panel2.Controls.Add(Label3)
        Panel2.Location = New Point(213, 125)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(258, 150)
        Panel2.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 12F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(42, 22)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(204, 29)
        Label3.TabIndex = 0
        Label3.Text = "Total de Clientes"
        ' 
        ' Button8
        ' 
        Button8.BackColor = Color.DarkGreen
        Button8.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button8.ForeColor = SystemColors.Control
        Button8.Location = New Point(868, 279)
        Button8.Margin = New Padding(2)
        Button8.Name = "Button8"
        Button8.Size = New Size(152, 41)
        Button8.TabIndex = 10
        Button8.Text = "Agregar Cliente"
        Button8.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(18, 359)
        DataGridView1.Margin = New Padding(2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1020, 354)
        DataGridView1.TabIndex = 11
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(132, 303)
        TextBox1.Margin = New Padding(2)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(376, 31)
        TextBox1.TabIndex = 12
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.Control
        Label5.Location = New Point(18, 303)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(93, 29)
        Label5.TabIndex = 17
        Label5.Text = "Buscar"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.camion__1_
        PictureBox1.Location = New Point(0, -31)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(201, 141)
        PictureBox1.TabIndex = 18
        PictureBox1.TabStop = False
        ' 
        ' GestionClientes
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1054, 726)
        Controls.Add(PictureBox1)
        Controls.Add(Label5)
        Controls.Add(TextBox1)
        Controls.Add(DataGridView1)
        Controls.Add(Button8)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Label2)
        Margin = New Padding(2)
        Name = "GestionClientes"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GestionClientes"
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
