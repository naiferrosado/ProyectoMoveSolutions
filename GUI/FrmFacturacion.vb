Imports BLL
Imports Entidades

Public Class FrmFacturacion

    Private ReadOnly _facturaService As New FacturaService()
    Private ReadOnly _pagoService As New PagoService()
    Private ReadOnly _mudanzaService As New MudanzaService()

    Private _mudanzaActual As MudanzaEntidad
    Private _facturaActual As FacturaEntidad


    '  LOAD

    Private Sub FrmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMetodoPago.Items.Clear()
        cmbMetodoPago.Items.Add("Efectivo")
        cmbMetodoPago.Items.Add("Transferencia")
        cmbMetodoPago.Items.Add("Tarjeta")
        cmbMetodoPago.SelectedIndex = 0

        dgvPagos.AutoGenerateColumns = True
    End Sub


    '  BUSCAR MUDANZA

    Private Sub btnBuscarMudanza_Click(sender As Object, e As EventArgs) Handles btnBuscarMudanza.Click
        Dim id As Integer

        If Not Integer.TryParse(txtMudanzaId.Text, id) Then
            MessageBox.Show("Ingrese un ID de mudanza válido.")
            Return
        End If

        _mudanzaActual = _mudanzaService.ObtenerPorId(id)

        If _mudanzaActual Is Nothing Then
            MessageBox.Show("Mudanza no encontrada.")
            LimpiarMudanza()
            Return
        End If

        MostrarMudanza()

        ' Cargar factura asociada
        _facturaActual = _facturaService.ObtenerPorMudanzaId(id)
        If _facturaActual IsNot Nothing Then
            MostrarFactura()
            CargarPagos()
        Else
            LimpiarFactura()
            dgvPagos.DataSource = Nothing
        End If
    End Sub


    '  GENERAR FACTURA

    Private Sub btnGenerarFactura_Click(sender As Object, e As EventArgs) Handles btnGenerarFactura.Click
        If _mudanzaActual Is Nothing Then
            MessageBox.Show("Debe buscar una mudanza primero.")
            Return
        End If

        Dim factura = _facturaService.GenerarFactura(_mudanzaActual.MudanzaId)
        If factura Is Nothing Then
            MessageBox.Show("No se pudo generar la factura.")
            Return
        End If

        _facturaActual = factura
        MostrarFactura()
        CargarPagos()

        MessageBox.Show("Factura generada correctamente.")
    End Sub


    '  REGISTRAR PAGO

    Private Sub btnRegistrarPago_Click(sender As Object, e As EventArgs) Handles btnRegistrarPago.Click
        If _facturaActual Is Nothing Then
            MessageBox.Show("Debe tener una factura cargada.")
            Return
        End If

        Dim monto As Decimal
        If Not Decimal.TryParse(txtMontoPago.Text, monto) OrElse monto <= 0D Then
            MessageBox.Show("Ingrese un monto válido.")
            Return
        End If

        Dim pago As New PagoEntidad With {
            .FacturaId = _facturaActual.FacturaId,
            .MetodoPago = cmbMetodoPago.Text,
            .Monto = monto,
            .FechaPago = DateTime.Now
        }

        If _pagoService.RegistrarPago(pago) Then
            ' recargar datos
            _facturaActual = _facturaService.ObtenerPorId(_facturaActual.FacturaId)
            MostrarFactura()
            CargarPagos()

            txtMontoPago.Clear()
            MessageBox.Show("Pago registrado correctamente.")
        Else
            MessageBox.Show("No se pudo registrar el pago.")
        End If
    End Sub


    '  MÉTODOS AUXILIARES

    Private Sub MostrarMudanza()
        txtCliente.Text = _mudanzaActual.Cliente.Nombre
        txtEstadoMudanza.Text = _mudanzaActual.Estado
        txtCostoEstimado.Text = _mudanzaActual.CostoEstimado.GetValueOrDefault(0D).ToString("N2")
    End Sub

    Private Sub LimpiarMudanza()
        txtCliente.Clear()
        txtEstadoMudanza.Clear()
        txtCostoEstimado.Clear()
    End Sub

    Private Sub MostrarFactura()
        txtFacturaId.Text = _facturaActual.FacturaId.ToString()
        txtMontoTotal.Text = _facturaActual.MontoTotal.ToString("N2")
        txtImpuesto.Text = _facturaActual.Impuesto.ToString("N2")
        txtFechaEmision.Text = _facturaActual.FechaEmision.ToString("dd/MM/yyyy HH:mm")
        txtEstadoFactura.Text = _facturaActual.Estado
    End Sub

    Private Sub LimpiarFactura()
        txtFacturaId.Clear()
        txtMontoTotal.Clear()
        txtImpuesto.Clear()
        txtFechaEmision.Clear()
        txtEstadoFactura.Clear()
    End Sub

    Private Sub CargarPagos()
        dgvPagos.DataSource = Nothing
        dgvPagos.DataSource = _pagoService.ObtenerPagosDeFactura(_facturaActual.FacturaId)
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class
