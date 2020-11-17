Public Class frmUsuarioEdit

    Private Sub frmUsuarioEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtID.Text = _idusuario
        Me.txtNombre.Text = _nombre
        Me.txtClave.Text = _clave
        Me.TxtPin.Text = _pin
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim m As Integer
        m = editar_usuario(Me.txtID.Text, Me.txtNombre.Text, Me.txtClave.Text, Me.TxtPin.Text)
        If m = 1 Then
            MsgBox("Datos Actualizados Correctamente")
            Me.Close()
        Else
            MsgBox("Error al Actualizar")
        End If
    End Sub
End Class