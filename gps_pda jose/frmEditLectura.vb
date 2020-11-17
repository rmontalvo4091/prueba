Public Class frmEditLectura

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.Close()
    End Sub

    Private Sub frmRegLectura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_Combo(Me.cmbLectura, "select idtlectura,tlectura_descripcion from tlectura")

        Me.txtCliente.Text = _cliente
        Me.txtMedidor.Text = _idmedidor
        Me.txtDirec.Text = _direccion
        Me.txtValor.Text = _valorlectura
        Me.txtObservacion.Text = _observ
        Me.cmbLectura.SelectedValue = _idtlectura
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        Dim h As Integer
        Dim fecha_ing As String
        fecha_ing = Now.ToString("dd-MM-yyyy hh:mm:ss")
        h = update_reglectura(_idreglectura, Me.txtValor.Text, Me.txtObservacion.Text, "334343.434", "4324234.22", fecha_ing)

        If h > 0 Then
            MsgBox("Datos Guardados con Exito", MsgBoxStyle.Information)
            Me.Close()
        Else
            MsgBox("Error al Guardar", MsgBoxStyle.Exclamation)
        End If
      
    End Sub
End Class