Public Class frmUsuarioNvo

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim n As Integer
        n = nuevo_usuario(Me.txtNombre.Text, Me.txtClave.Text, Me.TxtPin.Text)
        If n = 1 Then
            MsgBox("Datos creados correctamente")
            Me.Close()
        Else
            MsgBox("Error al crear")
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Close()
    End Sub

    Private Sub frmUsuarioNvo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    MsgBox(MD5Encrypt("12345"))
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class