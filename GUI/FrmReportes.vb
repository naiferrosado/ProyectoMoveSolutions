Imports BLL
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure

Public Class FrmReportes


    Public Sub New()
        InitializeComponent()

        ' Declarar licencia (obligatorio desde QuestPDF 2024+)
        QuestPDF.Settings.License = LicenseType.Community
    End Sub

    Private ReadOnly _reporteService As New ReporteService()


    '  LOAD

    Private Sub FrmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEstado.Items.Clear()
        cmbEstado.Items.Add("Todos")
        cmbEstado.Items.Add("Pendiente")
        cmbEstado.Items.Add("En Proceso")
        cmbEstado.Items.Add("Completada")
        cmbEstado.SelectedIndex = 0

        dtpInicio.Value = DateTime.Today.AddDays(-7)
        dtpFin.Value = DateTime.Today

        dgvReporte.AutoGenerateColumns = True
    End Sub


    '  GENERAR REPORTE

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        Dim inicio = dtpInicio.Value.Date
        Dim fin = dtpFin.Value.Date.AddDays(1).AddTicks(-1)
        Dim estado = cmbEstado.Text
        Dim filtroCliente = txtClienteFiltro.Text

        Dim datos = _reporteService.GenerarReporte(inicio, fin, estado, filtroCliente)

        dgvReporte.DataSource = Nothing
        dgvReporte.DataSource = datos
    End Sub


    '  EXPORTAR CSV

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvReporte.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar.")
            Return
        End If

        Dim sfd As New SaveFileDialog() With {
            .Filter = "CSV (*.csv)|*.csv",
            .FileName = "Reporte_Mudanzas.csv"
        }

        If sfd.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        Using sw As New IO.StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)

            ' Encabezados
            For i As Integer = 0 To dgvReporte.Columns.Count - 1
                sw.Write(dgvReporte.Columns(i).HeaderText)
                If i < dgvReporte.Columns.Count - 1 Then sw.Write(";")
            Next
            sw.WriteLine()

            ' Filas
            For Each row As DataGridViewRow In dgvReporte.Rows
                If Not row.IsNewRow Then
                    For i As Integer = 0 To dgvReporte.Columns.Count - 1
                        Dim valor = If(row.Cells(i).Value, "").ToString()
                        sw.Write(valor)
                        If i < dgvReporte.Columns.Count - 1 Then sw.Write(";")
                    Next
                    sw.WriteLine()
                End If
            Next

        End Using

        MessageBox.Show("Reporte exportado correctamente (CSV).")
    End Sub


    '  EXPORTAR PDF (BOTÓN NUEVO)

    Private Sub btnExportarPDF_Click(sender As Object, e As EventArgs) Handles btnExportarPDF.Click
        If dgvReporte.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar en PDF.")
            Return
        End If

        Dim sfd As New SaveFileDialog() With {
            .Filter = "PDF (*.pdf)|*.pdf",
            .FileName = "Reporte_Mudanzas.pdf"
        }

        If sfd.ShowDialog() = DialogResult.OK Then
            ExportarPDF(sfd.FileName)
        End If
    End Sub


    '  MÉTODO PARA EXPORTAR A PDF (QuestPDF)

    Private Sub ExportarPDF(ruta As String)
        Try
            Dim doc = Document.Create(Sub(container)
                                          container.Page(Sub(page)
                                                             page.Size(PageSizes.A4)
                                                             page.Margin(40)
                                                             page.PageColor(Colors.White)
                                                             page.DefaultTextStyle(Function(s) s.FontSize(11))


                                                             '                  ENCABEZADO

                                                             page.Header().Element(Sub(h)
                                                                                       h.PaddingBottom(20).Text("Reporte de Mudanzas").
                                                                                          Bold().
                                                                                          FontSize(20).
                                                                                          AlignCenter()
                                                                                   End Sub)


                                                             '                       TABLA

                                                             page.Content().Table(Sub(table)

                                                                                      ' Columnas
                                                                                      table.ColumnsDefinition(Sub(columns)
                                                                                                                  For i = 1 To dgvReporte.Columns.Count
                                                                                                                      columns.RelativeColumn()
                                                                                                                  Next
                                                                                                              End Sub)

                                                                                      ' Encabezados
                                                                                      table.Header(Sub(header)
                                                                                                       For Each col As DataGridViewColumn In dgvReporte.Columns
                                                                                                           header.Cell().
                                                                                                               Background(Colors.Grey.Lighten3).
                                                                                                               Padding(5).
                                                                                                               Text(col.HeaderText).Bold()
                                                                                                       Next
                                                                                                   End Sub)

                                                                                      ' Filas
                                                                                      For Each row As DataGridViewRow In dgvReporte.Rows
                                                                                          If Not row.IsNewRow Then
                                                                                              For i = 0 To dgvReporte.Columns.Count - 1
                                                                                                  Dim valor = If(row.Cells(i).Value, "").ToString()
                                                                                                  table.Cell().
                                                                                                      BorderBottom(1).
                                                                                                      BorderColor(Colors.Grey.Lighten3).
                                                                                                      Padding(5).
                                                                                                      Text(valor)
                                                                                              Next
                                                                                          End If
                                                                                      Next

                                                                                  End Sub)


                                                             '                       FOOTER

                                                             page.Footer().
                                                                 AlignRight().
                                                                 Text("Generado el " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"))

                                                         End Sub)
                                      End Sub)

            doc.GeneratePdf(ruta)

            MessageBox.Show("PDF generado correctamente.", "Éxito")

        Catch ex As Exception
            MessageBox.Show("Error al generar PDF: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class
