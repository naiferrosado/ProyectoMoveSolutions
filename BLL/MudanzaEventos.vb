Public Module MudanzaEventos
    ' Evento global para notificar cambios en mudanza (creación/actualización)
    Public Event MudanzaChanged(mudanzaId As Integer)

    Public Sub OnMudanzaChanged(mudanzaId As Integer)
        RaiseEvent MudanzaChanged(mudanzaId)
    End Sub
End Module