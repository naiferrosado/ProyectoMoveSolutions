<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturacion
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
        gbMudanza = New GroupBox()
        txtCostoEstimado = New TextBox()
        Label4 = New Label()
        txtEstadoMudanza = New TextBox()
        Label3 = New Label()
        txtCliente = New TextBox()
        Label2 = New Label()
        btnBuscarMudanza = New Button()
        txtMudanzaId = New TextBox()
        Label1 = New Label()
        gbFactura = New GroupBox()
        btnGenerarFactura = New Button()
        txtEstadoFactura = New TextBox()
        Label9 = New Label()
        txtFechaEmision = New TextBox()
        Label8 = New Label()
        txtImpuesto = New TextBox()
        Label7 = New Label()
        txtMontoTotal = New TextBox()
        Label6 = New Label()
        txtFacturaId = New TextBox()
        Label5 = New Label()
        gbPago = New GroupBox()
        btnRegistrarPago = New Button()
        txtMontoPago = New TextBox()
        Label11 = New Label()
        cmbMetodoPago = New ComboBox()
        Label10 = New Label()
        dgvPagos = New DataGridView()
        Button1 = New Button()
        gbMudanza.SuspendLayout()
        gbFactura.SuspendLayout()
        gbPago.SuspendLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' gbMudanza
        ' 
        gbMudanza.Controls.Add(txtCostoEstimado)
        gbMudanza.Controls.Add(Label4)
        gbMudanza.Controls.Add(txtEstadoMudanza)
        gbMudanza.Controls.Add(Label3)
        gbMudanza.Controls.Add(txtCliente)
        gbMudanza.Controls.Add(Label2)
        gbMudanza.Controls.Add(btnBuscarMudanza)
        gbMudanza.Controls.Add(txtMudanzaId)
        gbMudanza.Controls.Add(Label1)
        gbMudanza.ForeColor = SystemColors.Control
        gbMudanza.Location = New Point(0, 3)
        gbMudanza.Name = "gbMudanza"
        gbMudanza.Size = New Size(428, 359)
        gbMudanza.TabIndex = 0
        gbMudanza.TabStop = False
        gbMudanza.Text = "Datos de la mudanza"
        ' 
        ' txtCostoEstimado
        ' 
        txtCostoEstimado.Location = New Point(168, 237)
        txtCostoEstimado.Name = "txtCostoEstimado"
        txtCostoEstimado.ReadOnly = True
        txtCostoEstimado.Size = New Size(241, 31)
        txtCostoEstimado.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(7, 240)
        Label4.Name = "Label4"
        Label4.Size = New Size(138, 25)
        Label4.TabIndex = 7
        Label4.Text = "Costo estimado"
        ' 
        ' txtEstadoMudanza
        ' 
        txtEstadoMudanza.Location = New Point(168, 179)
        txtEstadoMudanza.Name = "txtEstadoMudanza"
        txtEstadoMudanza.ReadOnly = True
        txtEstadoMudanza.Size = New Size(241, 31)
        txtEstadoMudanza.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(7, 174)
        Label3.Name = "Label3"
        Label3.Size = New Size(144, 25)
        Label3.TabIndex = 5
        Label3.Text = "Estado mudanza"
        ' 
        ' txtCliente
        ' 
        txtCliente.Location = New Point(168, 117)
        txtCliente.Name = "txtCliente"
        txtCliente.ReadOnly = True
        txtCliente.Size = New Size(241, 31)
        txtCliente.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(7, 107)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 25)
        Label2.TabIndex = 3
        Label2.Text = "Cliente"
        ' 
        ' btnBuscarMudanza
        ' 
        btnBuscarMudanza.ForeColor = SystemColors.Desktop
        btnBuscarMudanza.Location = New Point(204, 293)
        btnBuscarMudanza.Name = "btnBuscarMudanza"
        btnBuscarMudanza.Size = New Size(173, 41)
        btnBuscarMudanza.TabIndex = 2
        btnBuscarMudanza.Text = "Buscar"
        btnBuscarMudanza.UseVisualStyleBackColor = True
        ' 
        ' txtMudanzaId
        ' 
        txtMudanzaId.Location = New Point(168, 57)
        txtMudanzaId.Name = "txtMudanzaId"
        txtMudanzaId.Size = New Size(241, 31)
        txtMudanzaId.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(7, 57)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 25)
        Label1.TabIndex = 0
        Label1.Text = "ID Mudanza"
        ' 
        ' gbFactura
        ' 
        gbFactura.Controls.Add(btnGenerarFactura)
        gbFactura.Controls.Add(txtEstadoFactura)
        gbFactura.Controls.Add(Label9)
        gbFactura.Controls.Add(txtFechaEmision)
        gbFactura.Controls.Add(Label8)
        gbFactura.Controls.Add(txtImpuesto)
        gbFactura.Controls.Add(Label7)
        gbFactura.Controls.Add(txtMontoTotal)
        gbFactura.Controls.Add(Label6)
        gbFactura.Controls.Add(txtFacturaId)
        gbFactura.Controls.Add(Label5)
        gbFactura.ForeColor = SystemColors.Control
        gbFactura.Location = New Point(0, 413)
        gbFactura.Name = "gbFactura"
        gbFactura.Size = New Size(919, 258)
        gbFactura.TabIndex = 1
        gbFactura.TabStop = False
        gbFactura.Text = "Factura"
        ' 
        ' btnGenerarFactura
        ' 
        btnGenerarFactura.ForeColor = SystemColors.Desktop
        btnGenerarFactura.Location = New Point(578, 187)
        btnGenerarFactura.Name = "btnGenerarFactura"
        btnGenerarFactura.Size = New Size(167, 34)
        btnGenerarFactura.TabIndex = 10
        btnGenerarFactura.Text = "Generar Factura"
        btnGenerarFactura.UseVisualStyleBackColor = True
        ' 
        ' txtEstadoFactura
        ' 
        txtEstadoFactura.Location = New Point(155, 185)
        txtEstadoFactura.Name = "txtEstadoFactura"
        txtEstadoFactura.Size = New Size(222, 31)
        txtEstadoFactura.TabIndex = 9
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(26, 187)
        Label9.Name = "Label9"
        Label9.Size = New Size(125, 25)
        Label9.TabIndex = 8
        Label9.Text = "Estado factura"
        ' 
        ' txtFechaEmision
        ' 
        txtFechaEmision.Location = New Point(555, 120)
        txtFechaEmision.Name = "txtFechaEmision"
        txtFechaEmision.ReadOnly = True
        txtFechaEmision.Size = New Size(216, 31)
        txtFechaEmision.TabIndex = 7
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(431, 126)
        Label8.Name = "Label8"
        Label8.Size = New Size(124, 25)
        Label8.TabIndex = 6
        Label8.Text = "Fecha emisión"
        ' 
        ' txtImpuesto
        ' 
        txtImpuesto.Location = New Point(155, 126)
        txtImpuesto.Name = "txtImpuesto"
        txtImpuesto.ReadOnly = True
        txtImpuesto.Size = New Size(222, 31)
        txtImpuesto.TabIndex = 5
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(24, 130)
        Label7.Name = "Label7"
        Label7.Size = New Size(118, 25)
        Label7.TabIndex = 4
        Label7.Text = "Impuesto (%)"
        ' 
        ' txtMontoTotal
        ' 
        txtMontoTotal.Location = New Point(555, 61)
        txtMontoTotal.Name = "txtMontoTotal"
        txtMontoTotal.Size = New Size(216, 31)
        txtMontoTotal.TabIndex = 3
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(431, 61)
        Label6.Name = "Label6"
        Label6.Size = New Size(107, 25)
        Label6.TabIndex = 2
        Label6.Text = "Monto total"
        ' 
        ' txtFacturaId
        ' 
        txtFacturaId.Location = New Point(155, 61)
        txtFacturaId.Name = "txtFacturaId"
        txtFacturaId.ReadOnly = True
        txtFacturaId.Size = New Size(222, 31)
        txtFacturaId.TabIndex = 1
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(24, 64)
        Label5.Name = "Label5"
        Label5.Size = New Size(91, 25)
        Label5.TabIndex = 0
        Label5.Text = "ID Factura"
        ' 
        ' gbPago
        ' 
        gbPago.Controls.Add(btnRegistrarPago)
        gbPago.Controls.Add(txtMontoPago)
        gbPago.Controls.Add(Label11)
        gbPago.Controls.Add(cmbMetodoPago)
        gbPago.Controls.Add(Label10)
        gbPago.ForeColor = SystemColors.Control
        gbPago.Location = New Point(449, 12)
        gbPago.Name = "gbPago"
        gbPago.Size = New Size(340, 350)
        gbPago.TabIndex = 2
        gbPago.TabStop = False
        gbPago.Text = "Generar Pago"
        ' 
        ' btnRegistrarPago
        ' 
        btnRegistrarPago.ForeColor = SystemColors.Desktop
        btnRegistrarPago.Location = New Point(43, 251)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Size = New Size(155, 44)
        btnRegistrarPago.TabIndex = 4
        btnRegistrarPago.Text = "Registrar Pago"
        btnRegistrarPago.UseVisualStyleBackColor = True
        ' 
        ' txtMontoPago
        ' 
        txtMontoPago.Location = New Point(23, 194)
        txtMontoPago.Name = "txtMontoPago"
        txtMontoPago.Size = New Size(219, 31)
        txtMontoPago.TabIndex = 3
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.ForeColor = SystemColors.Control
        Label11.Location = New Point(23, 151)
        Label11.Name = "Label11"
        Label11.Size = New Size(66, 25)
        Label11.TabIndex = 2
        Label11.Text = "Monto"
        ' 
        ' cmbMetodoPago
        ' 
        cmbMetodoPago.FormattingEnabled = True
        cmbMetodoPago.Items.AddRange(New Object() {"Efectivo", "", "", "Transferencia", "", "", "Tarjeta"})
        cmbMetodoPago.Location = New Point(23, 85)
        cmbMetodoPago.Name = "cmbMetodoPago"
        cmbMetodoPago.Size = New Size(219, 33)
        cmbMetodoPago.TabIndex = 1
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.ForeColor = SystemColors.Control
        Label10.Location = New Point(23, 43)
        Label10.Name = "Label10"
        Label10.Size = New Size(148, 25)
        Label10.TabIndex = 0
        Label10.Text = "Método de pago"
        ' 
        ' dgvPagos
        ' 
        dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPagos.Location = New Point(12, 707)
        dgvPagos.Name = "dgvPagos"
        dgvPagos.RowHeadersWidth = 62
        dgvPagos.Size = New Size(994, 331)
        dgvPagos.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(894, 28)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 4
        Button1.Text = "Atrás"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' FrmFacturacion
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1034, 1050)
        Controls.Add(Button1)
        Controls.Add(dgvPagos)
        Controls.Add(gbPago)
        Controls.Add(gbFactura)
        Controls.Add(gbMudanza)
        Name = "FrmFacturacion"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmFacturacion"
        gbMudanza.ResumeLayout(False)
        gbMudanza.PerformLayout()
        gbFactura.ResumeLayout(False)
        gbFactura.PerformLayout()
        gbPago.ResumeLayout(False)
        gbPago.PerformLayout()
        CType(dgvPagos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents gbMudanza As GroupBox
    Friend WithEvents txtMudanzaId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscarMudanza As Button
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEstadoMudanza As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCostoEstimado As TextBox
    Friend WithEvents gbFactura As GroupBox
    Friend WithEvents txtFacturaId As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMontoTotal As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtImpuesto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFechaEmision As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEstadoFactura As TextBox
    Friend WithEvents btnGenerarFactura As Button
    Friend WithEvents gbPago As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbMetodoPago As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtMontoPago As TextBox
    Friend WithEvents btnRegistrarPago As Button
    Friend WithEvents dgvPagos As DataGridView
    Friend WithEvents Button1 As Button
End Class
