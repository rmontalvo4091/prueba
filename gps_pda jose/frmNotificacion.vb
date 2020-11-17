Public Class frmNotificacion

    Private Sub frmNotificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCliente.Text = _cliente
        Me.txtMedidor.Text = _idmedidor
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If Me.cmbTipo.Text = "CORREO" Then
            Dim m As Integer = servicio.enviar_mail2("joseluis.aranibar@gmail.com", "Notificacion Electronica", _cliente, _idmedidor, cmbMensaje.Text, Me.txtObservacion.Text)
            If m = 1 Then
                MsgBox("Mensaje enviado con exito", MsgBoxStyle.Information)
            Else
                MsgBox("Error al enviar Mensaje ", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub
End Class