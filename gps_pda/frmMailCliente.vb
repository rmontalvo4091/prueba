Imports System.Data
Imports System
Imports System.Windows.Forms
Public Class frmMailCliente
    Dim resp As Integer
    Function ValidateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)
        Return emailMatch.Success
    End Function
    Sub enviar_email()
        Try
            If ValidateEmail(txtMail.Text) Then
                _mailTo = txtMail.Text
                resp = servicio.enviar_mail2(_mailTo, "NOTIFICACION DE COBRO A CLIENTE", _mailIdcliente, _mailNunmed, _mailDetalle, _mailObs)
                If resp = 1 Then
                    MsgBox("Mensaje Enviado Correctamente!.")
                    Close()
                Else
                    MsgBox("Se produjo un error al eviar correo. Comunique al Administrador del sistema.")
                End If
            Else
                MsgBox("Correo electronico invalido, verifique e intente nuevamente.")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        enviar_email()
    End Sub

    Private Sub frmMailCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        enviar_email()
    End Sub
End Class