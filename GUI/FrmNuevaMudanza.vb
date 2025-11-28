Imports BLL
Imports BLL.BLL
Imports Entidades
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class FrmNuevaMudanza

    Private ReadOnly clienteService As New ClienteService()
    Private ReadOnly mudanzaService As New MudanzaService()
    Private ReadOnly empleadoService As New EmpleadoService()
    Private ReadOnly vehiculoService As New VehiculoService()
    Private WithEvents webViewMapa As WebView2

    Private Sub FrmNuevaMudanza_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InicializarWebView()
        CargarCombos()
    End Sub
    Private Async Sub InicializarWebView()
        Try
            webViewMapa = New WebView2()
            webViewMapa.Dock = DockStyle.Fill
            panelMapa.Controls.Add(webViewMapa)

            ' Inicializar WebView2
            Await webViewMapa.EnsureCoreWebView2Async(Nothing)

            ' Registrar el handler para mensajes
            AddHandler webViewMapa.CoreWebView2.WebMessageReceived, AddressOf WebView_MessageReceived

            ' Cargar el archivo mapa.html
            Dim rutaMapa As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mapa.html")

            ' Si el archivo no existe, crearlo
            If Not IO.File.Exists(rutaMapa) Then
                CrearArchivoMapa(rutaMapa)
            End If

            webViewMapa.Source = New Uri(rutaMapa)

        Catch ex As Exception
            MessageBox.Show($"Error al inicializar mapa: {ex.Message}")
        End Try
    End Sub
    Private Sub CrearArchivoMapa(rutaArchivo As String)
        Dim html As String = "<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: Arial, sans-serif; overflow: hidden; }
        #map { 
            height: 100vh; 
            width: 100%; 
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            position: relative;
            cursor: crosshair;
        }
        
        /* Panel inferior discreto */
        .info-bar {
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            background: rgba(0, 0, 0, 0.75);
            backdrop-filter: blur(10px);
            padding: 12px 20px;
            display: flex;
            align-items: center;
            justify-content: space-between;
            z-index: 1000;
            border-top: 2px solid rgba(255, 255, 255, 0.1);
        }
        
        .info-group {
            display: flex;
            align-items: center;
            gap: 25px;
        }
        
        .info-item {
            display: flex;
            align-items: center;
            gap: 8px;
            color: white;
            font-size: 13px;
        }
        
        .info-item .icon {
            font-size: 16px;
            opacity: 0.8;
        }
        
        .info-item .label {
            color: rgba(255, 255, 255, 0.6);
            font-weight: 500;
        }
        
        .info-item .value {
            color: white;
            font-weight: 600;
        }
        
        .btn-clear {
            background: rgba(220, 53, 69, 0.9);
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 6px;
            cursor: pointer;
            font-size: 13px;
            font-weight: 600;
            transition: all 0.2s;
            display: flex;
            align-items: center;
            gap: 6px;
        }
        
        .btn-clear:hover { 
            background: rgba(220, 53, 69, 1);
            transform: translateY(-1px);
        }
        
        .btn-clear:active {
            transform: translateY(0);
        }
        
        /* Marcadores mejorados */
        .marker {
            position: absolute;
            width: 32px;
            height: 42px;
            transform: translate(-16px, -42px);
            cursor: pointer;
            z-index: 10;
            animation: markerDrop 0.4s ease-out;
        }
        
        @keyframes markerDrop {
            0% {
                transform: translate(-16px, -100px);
                opacity: 0;
            }
            60% {
                transform: translate(-16px, -38px);
            }
            100% {
                transform: translate(-16px, -42px);
                opacity: 1;
            }
        }
        
        .marker-green {
            background: url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzIiIGhlaWdodD0iNDIiIHZpZXdCb3g9IjAgMCAzMiA0MiIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48ZGVmcz48ZmlsdGVyIGlkPSJzaGFkb3ciPjxmZUdhdXNzaWFuQmx1ciBpbj0iU291cmNlQWxwaGEiIHN0ZERldmlhdGlvbj0iMiIvPjxmZU9mZnNldCBkeT0iMiIgcmVzdWx0PSJvZmZzZXRibHVyIi8+PGZlTWVyZ2U+PGZlTWVyZ2VOb2RlLz48ZmVNZXJnZU5vZGUgaW49IlNvdXJjZUdyYXBoaWMiLz48L2ZlTWVyZ2U+PC9maWx0ZXI+PC9kZWZzPjxwYXRoIGQ9Ik0xNiAyQzEwLjUgMiA2IDYuNSA2IDEyYzAgOCA5IDI2IDEwIDI4IDEtMiAxMC0yMCAxMC0yOCAwLTUuNS00LjUtMTAtMTAtMTB6IiBmaWxsPSIjMTBiOTgxIiBmaWx0ZXI9InVybCgjc2hhZG93KSIvPjxjaXJjbGUgY3g9IjE2IiBjeT0iMTIiIHI9IjUiIGZpbGw9IndoaXRlIi8+PHRleHQgeD0iMTYiIHk9IjE2IiBmb250LXNpemU9IjEyIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtd2VpZ2h0PSJib2xkIiBmaWxsPSIjMTBiOTgxIiB0ZXh0LWFuY2hvcj0ibWlkZGxlIj5BPC90ZXh0Pjwvc3ZnPg==') no-repeat center;
            background-size: contain;
        }
        
        .marker-red {
            background: url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzIiIGhlaWdodD0iNDIiIHZpZXdCb3g9IjAgMCAzMiA0MiIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48ZGVmcz48ZmlsdGVyIGlkPSJzaGFkb3ciPjxmZUdhdXNzaWFuQmx1ciBpbj0iU291cmNlQWxwaGEiIHN0ZERldmlhdGlvbj0iMiIvPjxmZU9mZnNldCBkeT0iMiIgcmVzdWx0PSJvZmZzZXRibHVyIi8+PGZlTWVyZ2U+PGZlTWVyZ2VOb2RlLz48ZmVNZXJnZU5vZGUgaW49IlNvdXJjZUdyYXBoaWMiLz48L2ZlTWVyZ2U+PC9maWx0ZXI+PC9kZWZzPjxwYXRoIGQ9Ik0xNiAyQzEwLjUgMiA2IDYuNSA2IDEyYzAgOCA5IDI2IDEwIDI4IDEtMiAxMC0yMCAxMC0yOCAwLTUuNS00LjUtMTAtMTAtMTB6IiBmaWxsPSIjZWYzNDM0IiBmaWx0ZXI9InVybCgjc2hhZG93KSIvPjxjaXJjbGUgY3g9IjE2IiBjeT0iMTIiIHI9IjUiIGZpbGw9IndoaXRlIi8+PHRleHQgeD0iMTYiIHk9IjE2IiBmb250LXNpemU9IjEyIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtd2VpZ2h0PSJib2xkIiBmaWxsPSIjZWYzNDM0IiB0ZXh0LWFuY2hvcj0ibWlkZGxlIj5CPC90ZXh0Pjwvc3ZnPg==') no-repeat center;
            background-size: contain;
        }
        
        /* Línea de conexión mejorada */
        .line {
            position: absolute;
            background: linear-gradient(90deg, #10b981, #3b82f6);
            height: 4px;
            transform-origin: 0 50%;
            z-index: 5;
            pointer-events: none;
            box-shadow: 0 2px 8px rgba(59, 130, 246, 0.4);
            animation: lineDraw 0.5s ease-out;
        }
        
        @keyframes lineDraw {
            from {
                width: 0 !important;
            }
        }
        
        /* Punto de click visual */
        .click-ripple {
            position: absolute;
            width: 40px;
            height: 40px;
            border: 3px solid rgba(255, 255, 255, 0.8);
            border-radius: 50%;
            transform: translate(-20px, -20px);
            animation: ripple 0.6s ease-out;
            pointer-events: none;
            z-index: 1;
        }
        
        @keyframes ripple {
            to {
                transform: translate(-20px, -20px) scale(2);
                opacity: 0;
            }
        }
        
        /* Tooltip discreto */
        .tooltip {
            position: absolute;
            background: rgba(0, 0, 0, 0.85);
            color: white;
            padding: 6px 12px;
            border-radius: 6px;
            font-size: 12px;
            pointer-events: none;
            z-index: 2000;
            white-space: nowrap;
            transform: translateY(-100%);
            margin-top: -10px;
            opacity: 0;
            transition: opacity 0.2s;
        }
        
        .tooltip.show {
            opacity: 1;
        }
        
        .tooltip::after {
            content: '';
            position: absolute;
            bottom: -6px;
            left: 50%;
            transform: translateX(-50%);
            width: 0;
            height: 0;
            border-left: 6px solid transparent;
            border-right: 6px solid transparent;
            border-top: 6px solid rgba(0, 0, 0, 0.85);
        }
    </style>
</head>
<body>
    <div id='map'></div>
    
    <!-- Barra de información inferior -->
    <div class='info-bar'>
        <div class='info-group'>
            <div class='info-item'>
                <span class='icon'>🟢</span>
                <span class='label'>Origen:</span>
                <span class='value' id='origen-text'>--</span>
            </div>
            <div class='info-item'>
                <span class='icon'>🔴</span>
                <span class='label'>Destino:</span>
                <span class='value' id='destino-text'>--</span>
            </div>
            <div class='info-item'>
                <span class='icon'>📏</span>
                <span class='label'>Distancia:</span>
                <span class='value' id='distancia-text'>--</span>
            </div>
        </div>
        <button class='btn-clear' onclick='limpiarMarcadores()'>
            <span>🗑️</span>
            <span>Limpiar</span>
        </button>
    </div>
    
    <div id='tooltip' class='tooltip'></div>

    <script>
        let markerOrigen = null;
        let markerDestino = null;
        let lineElement = null;
        let coordOrigen = null;
        let coordDestino = null;

        const mapElement = document.getElementById('map');
        const tooltip = document.getElementById('tooltip');

        // Detectar clicks en el mapa
        mapElement.addEventListener('click', function(e) {
            const rect = mapElement.getBoundingClientRect();
            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;
            
            // Efecto visual de click
            crearRipple(x, y);
            
            agregarMarcador(x, y);
        });

        // Mostrar tooltip al mover el mouse
        mapElement.addEventListener('mousemove', function(e) {
            if (!markerOrigen) {
                tooltip.textContent = 'Click para seleccionar origen';
            } else if (!markerDestino) {
                tooltip.textContent = 'Click para seleccionar destino';
            } else {
                tooltip.textContent = 'Ambos puntos seleccionados';
            }
            
            tooltip.style.left = e.clientX + 'px';
            tooltip.style.top = e.clientY + 'px';
            tooltip.classList.add('show');
        });

        mapElement.addEventListener('mouseleave', function() {
            tooltip.classList.remove('show');
        });

        function crearRipple(x, y) {
            const ripple = document.createElement('div');
            ripple.className = 'click-ripple';
            ripple.style.left = x + 'px';
            ripple.style.top = y + 'px';
            mapElement.appendChild(ripple);
            
            setTimeout(() => {
                mapElement.removeChild(ripple);
            }, 600);
        }

        function agregarMarcador(x, y) {
            if (!markerOrigen) {
                // Crear marcador de origen (verde)
                markerOrigen = document.createElement('div');
                markerOrigen.className = 'marker marker-green';
                markerOrigen.style.left = x + 'px';
                markerOrigen.style.top = y + 'px';
                
                mapElement.appendChild(markerOrigen);
                coordOrigen = { x: x, y: y };
                
                const direccion = `Punto A (${Math.round(x)}, ${Math.round(y)})`;
                document.getElementById('origen-text').textContent = direccion;
                
                // Enviar a VB.NET
                window.chrome.webview.postMessage({
                    tipo: 'origen',
                    direccion: direccion,
                    x: x,
                    y: y
                });
                
            } else if (!markerDestino) {
                // Crear marcador de destino (rojo)
                markerDestino = document.createElement('div');
                markerDestino.className = 'marker marker-red';
                markerDestino.style.left = x + 'px';
                markerDestino.style.top = y + 'px';
                
                mapElement.appendChild(markerDestino);
                coordDestino = { x: x, y: y };
                
                const direccion = `Punto B (${Math.round(x)}, ${Math.round(y)})`;
                document.getElementById('destino-text').textContent = direccion;
                
                // Enviar a VB.NET
                window.chrome.webview.postMessage({
                    tipo: 'destino',
                    direccion: direccion,
                    x: x,
                    y: y
                });
                
                // Calcular y dibujar línea
                calcularDistancia();
            }
        }

        function calcularDistancia() {
            if (coordOrigen && coordDestino) {
                // Calcular distancia euclidiana en píxeles
                const dx = coordDestino.x - coordOrigen.x;
                const dy = coordDestino.y - coordOrigen.y;
                const distanciaPx = Math.sqrt(dx * dx + dy * dy);
                
                // Convertir a kilómetros (100 píxeles ≈ 1 km)
                const distanciaKm = (distanciaPx / 100).toFixed(2);
                
                // Dibujar línea
                if (lineElement) {
                    mapElement.removeChild(lineElement);
                }
                
                lineElement = document.createElement('div');
                lineElement.className = 'line';
                lineElement.style.left = coordOrigen.x + 'px';
                lineElement.style.top = coordOrigen.y + 'px';
                lineElement.style.width = distanciaPx + 'px';
                
                const angle = Math.atan2(dy, dx) * 180 / Math.PI;
                lineElement.style.transform = `rotate(${angle}deg)`;
                
                mapElement.appendChild(lineElement);
                
                // Actualizar UI
                document.getElementById('distancia-text').textContent = distanciaKm + ' km';
                
                // Enviar distancia a VB.NET
                window.chrome.webview.postMessage({
                    tipo: 'distancia',
                    distancia: distanciaKm
                });
            }
        }

        function limpiarMarcadores() {
            // Remover marcadores
            if (markerOrigen) {
                mapElement.removeChild(markerOrigen);
                markerOrigen = null;
                coordOrigen = null;
            }
            
            if (markerDestino) {
                mapElement.removeChild(markerDestino);
                markerDestino = null;
                coordDestino = null;
            }
            
            if (lineElement) {
                mapElement.removeChild(lineElement);
                lineElement = null;
            }
            
            // Limpiar textos
            document.getElementById('origen-text').textContent = '--';
            document.getElementById('destino-text').textContent = '--';
            document.getElementById('distancia-text').textContent = '--';
            
            // Notificar a VB.NET
            window.chrome.webview.postMessage({ tipo: 'limpiar' });
        }

        // Mensaje de confirmación de carga
        console.log('✓ Mapa interactivo cargado correctamente');
    </script>
</body>
</html>"

        File.WriteAllText(rutaArchivo, html)
    End Sub
    Private Sub WebView_MessageReceived(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
        Try
            Dim json As String = e.WebMessageAsJson

            ' Mostrar el JSON completo que llega (para debug)
            System.Diagnostics.Debug.WriteLine("JSON recibido: " & json)

            ' Parsear manualmente
            If json.Contains("""tipo"":""origen""") Then
                Dim inicio = json.IndexOf("""direccion"":""") + 14
                Dim fin = json.IndexOf("""", inicio)
                If inicio > 13 AndAlso fin > inicio Then
                    txtOrigen.Text = json.Substring(inicio, fin - inicio)
                End If

            ElseIf json.Contains("""tipo"":""destino""") Then
                Dim inicio = json.IndexOf("""direccion"":""") + 14
                Dim fin = json.IndexOf("""", inicio)
                If inicio > 13 AndAlso fin > inicio Then
                    txtDestino.Text = json.Substring(inicio, fin - inicio)
                End If

            ElseIf json.Contains("""tipo"":""distancia""") Then
                Dim inicio = json.IndexOf("""distancia"":""") + 14
                Dim fin = json.IndexOf("""", inicio)
                If inicio > 13 AndAlso fin > inicio Then
                    txtDistancia.Text = json.Substring(inicio, fin - inicio)
                End If

            ElseIf json.Contains("""tipo"":""limpiar""") Then
                txtOrigen.Clear()
                txtDestino.Clear()
                If txtDistancia IsNot Nothing Then txtDistancia.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error")
        End Try
    End Sub
    Private Sub CargarCombos()
        ' CLIENTES
        Try
            Dim clientes = clienteService.ObtenerTodosLosClientes()
            If clientes Is Nothing Then clientes = New List(Of ClienteEntidad)()
            Dim clientesDs = clientes.Select(Function(c) New With {
                                            .Id = c.ClienteId,
                                            .Texto = If(String.IsNullOrWhiteSpace(GetPropString(c, "Nombre")), GetPropString(c, "Correo"), GetPropString(c, "Nombre"))
                                         }).ToList()
            cboClientes.DataSource = clientesDs
            cboClientes.DisplayMember = "Texto"
            cboClientes.ValueMember = "Id"
            cboClientes.SelectedIndex = If(clientesDs.Count > 0, 0, -1)
        Catch ex As Exception
            MessageBox.Show("Error cargando clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboClientes.DataSource = New List(Of Object)()
        End Try

        ' EMPLEADOS
        Try
            Dim empleados = empleadoService.ObtenerTodos()
            If empleados Is Nothing Then empleados = New List(Of EmpleadoEntidad)()
            Dim empleadosDs = empleados.Select(Function(emp) New With {
                                              .Id = emp.EmpleadoId,
                                              .Texto = If(Not String.IsNullOrWhiteSpace(GetPropString(emp, "NombreCompleto")),
                                                           GetPropString(emp, "NombreCompleto"),
                                                           If(Not String.IsNullOrWhiteSpace(GetPropString(emp, "Nombre")) AndAlso Not String.IsNullOrWhiteSpace(GetPropString(emp, "Apellido")),
                                                              GetPropString(emp, "Nombre") & " " & GetPropString(emp, "Apellido"),
                                                              GetPropString(emp, "Nombre")
                                                           )
                                                       )
                                           }).ToList()
            cboEmpleados.DataSource = empleadosDs
            cboEmpleados.DisplayMember = "Texto"
            cboEmpleados.ValueMember = "Id"
            cboEmpleados.SelectedIndex = If(empleadosDs.Count > 0, 0, -1)
        Catch ex As Exception
            MessageBox.Show("Error cargando empleados: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmpleados.DataSource = New List(Of Object)()
        End Try

        ' VEHICULOS
        Try
            Dim vehiculos = vehiculoService.ObtenerTodosLosVehiculos()
            If vehiculos Is Nothing Then vehiculos = New List(Of VehiculoEntidad)()
            Dim vehDs = vehiculos.Select(Function(v) New With {
                                        .Id = v.VehiculoId,
                                        .Texto = If(Not String.IsNullOrWhiteSpace(GetPropString(v, "Descripcion")),
                                                    GetPropString(v, "Descripcion"),
                                                    If(Not String.IsNullOrWhiteSpace(GetPropString(v, "Marca")) OrElse Not String.IsNullOrWhiteSpace(GetPropString(v, "Modelo")),
                                                       (GetPropString(v, "Marca") & " " & GetPropString(v, "Modelo")).Trim(),
                                                       GetPropString(v, "Placa")
                                                    )
                                                  )
                                      }).ToList()
            cboVehiculos.DataSource = vehDs
            cboVehiculos.DisplayMember = "Texto"
            cboVehiculos.ValueMember = "Id"
            cboVehiculos.SelectedIndex = If(vehDs.Count > 0, 0, -1)
        Catch ex As Exception
            MessageBox.Show("Error cargando vehículos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVehiculos.DataSource = New List(Of Object)()
        End Try
    End Sub

    ' Helper: devuelve el valor de la propiedad (string) si existe, sino String.Empty
    Private Function GetPropString(obj As Object, propName As String) As String
        If obj Is Nothing Then Return String.Empty
        Dim t = obj.GetType()
        Dim pi = t.GetProperty(propName)
        If pi Is Nothing Then Return String.Empty
        Dim val = pi.GetValue(obj, Nothing)
        If val Is Nothing Then Return String.Empty
        Return val.ToString()
    End Function

    Private Sub btnGuarfar_Click(sender As Object, e As EventArgs) Handles btnGuarfar.Click
        Try
            ' Validaciones básicas
            If cboClientes.SelectedIndex = -1 Then Throw New Exception("Debe seleccionar un cliente.")
            If String.IsNullOrWhiteSpace(txtOrigen.Text) Then Throw New Exception("Debe ingresar el origen.")
            If String.IsNullOrWhiteSpace(txtDestino.Text) Then Throw New Exception("Debe ingresar el destino.")

            ' Validar longitudes acorde al modelo (MaxLength 150)
            If txtOrigen.Text.Trim().Length > 150 Then Throw New Exception("Origen demasiado largo (máx 150).")
            If txtDestino.Text.Trim().Length > 150 Then Throw New Exception("Destino demasiado largo (máx 150).")

            ' Parsear costo
            Dim costoDecimal As Decimal = 0
            If Not String.IsNullOrWhiteSpace(txtCosto.Text) Then
                If Not Decimal.TryParse(txtCosto.Text, costoDecimal) Then
                    Throw New Exception("Costo inválido.")
                End If
                If costoDecimal < 0 OrElse costoDecimal > 99999999.99D Then
                    Throw New Exception("Costo fuera de rango.")
                End If
            End If

            ' Obtener ClienteId
            Dim clienteId As Integer
            If Not Integer.TryParse(Convert.ToString(cboClientes.SelectedValue), clienteId) Then
                Throw New Exception("Cliente seleccionado inválido.")
            End If

            ' Obtener EmpleadoId opcional
            Dim empleadoId As Integer? = Nothing
            Dim tempEmpleado As Integer
            If cboEmpleados.SelectedValue IsNot Nothing AndAlso Integer.TryParse(Convert.ToString(cboEmpleados.SelectedValue), tempEmpleado) Then
                empleadoId = tempEmpleado
            End If

            ' Obtener VehiculoId opcional
            Dim vehiculoId As Integer? = Nothing
            Dim tempVehiculo As Integer
            If cboVehiculos.SelectedValue IsNot Nothing AndAlso Integer.TryParse(Convert.ToString(cboVehiculos.SelectedValue), tempVehiculo) Then
                vehiculoId = tempVehiculo
            End If

            ' CREAR OBJETO MUDANZA
            Dim nueva As New MudanzaEntidad With {
            .ClienteId = clienteId,
            .EmpleadoId = empleadoId,
            .VehiculoId = vehiculoId,
            .Origen = txtOrigen.Text.Trim(),
            .Destino = txtDestino.Text.Trim(),
            .FechaProgramada = dtpFecha.Value,
            .Estado = "Pendiente",
            .CostoEstimado = If(txtCosto.Text = "", Nothing, CType(costoDecimal, Decimal?))
        }

            ' GUARDAR
            Try
                If mudanzaService.CrearMudanza(nueva) Then
                    MessageBox.Show("Mudanza registrada correctamente.", "Éxito")

                    ' Refrescar formularios abiertos
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is FrmSeguimientoMudanza Then
                            DirectCast(f, FrmSeguimientoMudanza).RefrescarVista()
                        End If
                    Next

                    ' NO cerrar → limpiar los campos
                    LimpiarCampos()
                Else
                    MessageBox.Show("Error al registrar la mudanza. El servicio devolvió False.", "Error")
                End If

            Catch exSave As Exception
                MessageBox.Show("Error guardando mudanza: " & exSave.GetBaseException().Message, "Error crítico")
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub
    Private Sub LimpiarCampos()
        cboClientes.SelectedIndex = -1
        cboEmpleados.SelectedIndex = -1
        cboVehiculos.SelectedIndex = -1

        txtOrigen.Clear()
        txtDestino.Clear()
        txtCosto.Clear()

        dtpFecha.Value = DateTime.Now
    End Sub


    Private Sub btnProbarConexion_Click(sender As Object, e As EventArgs) Handles btnProbarConexion.Click
        Try
            Dim clientes = clienteService.ObtenerTodosLosClientes()
            Dim empleados = empleadoService.ObtenerTodos()
            Dim vehiculos = vehiculoService.ObtenerTodosLosVehiculos()

            Dim msg As New System.Text.StringBuilder()
            msg.AppendLine($"Clientes: {If(clientes Is Nothing, 0, clientes.Count)}")
            If clientes IsNot Nothing AndAlso clientes.Count > 0 Then
                msg.AppendLine("Primera cliente propiedades:")
                msg.AppendLine(ListarPropiedades(clientes(0)))
            End If

            msg.AppendLine()
            msg.AppendLine($"Empleados: {If(empleados Is Nothing, 0, empleados.Count)}")
            If empleados IsNot Nothing AndAlso empleados.Count > 0 Then
                msg.AppendLine("Primero empleado propiedades:")
                msg.AppendLine(ListarPropiedades(empleados(0)))
            End If

            msg.AppendLine()
            msg.AppendLine($"Vehículos: {If(vehiculos Is Nothing, 0, vehiculos.Count)}")
            If vehiculos IsNot Nothing AndAlso vehiculos.Count > 0 Then
                msg.AppendLine("Primero vehículo propiedades:")
                msg.AppendLine(ListarPropiedades(vehiculos(0)))
            End If

            MessageBox.Show(msg.ToString(), "Diagnóstico Servicios")
        Catch ex As Exception
            MessageBox.Show("Error en prueba: " & ex.Message)
        End Try
    End Sub

    Private Function ListarPropiedades(obj As Object) As String
        If obj Is Nothing Then Return String.Empty
        Dim t = obj.GetType()
        Dim sb As New System.Text.StringBuilder()
        For Each pi In t.GetProperties()
            Dim val = pi.GetValue(obj, Nothing)
            sb.AppendLine($"{pi.Name} = {If(val Is Nothing, "<null>", val.ToString())}")
        Next
        Return sb.ToString()
    End Function

    Private Sub txtCosto_TextChanged(sender As Object, e As EventArgs) Handles txtCosto.TextChanged
        ' Si el textbox está vacío, salir
        If txtCosto.Text = "" Then Exit Sub

        ' Mantener solo números
        Dim soloNumeros As String = ""
        For Each c As Char In txtCosto.Text
            If Char.IsDigit(c) Then
                soloNumeros &= c
            End If
        Next

        ' Si se modificó, reemplazar el texto
        If txtCosto.Text <> soloNumeros Then
            Dim pos As Integer = txtCosto.SelectionStart - 1
            txtCosto.Text = soloNumeros
            If pos < 0 Then pos = 0
            txtCosto.SelectionStart = pos
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim f As New GestionMudanzas
        f.Show()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If webViewMapa IsNot Nothing AndAlso webViewMapa.CoreWebView2 IsNot Nothing Then
            webViewMapa.CoreWebView2.ExecuteScriptAsync("limpiarMarcadores();")
        End If
    End Sub
    Private Sub FrmNuevaMudanza_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If webViewMapa IsNot Nothing Then webViewMapa.Dispose()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New GestionMudanzas()
        f.Show()
        Me.Close()
    End Sub
End Class