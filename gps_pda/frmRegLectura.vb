Public Class frmRegLectura

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.Close()
    End Sub

    Private Sub frmRegLectura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_Combo(Me.cmbLectura, "select idtlectura,tlectura_descripcion from tlectura")

        Me.txtCliente.Text = _cliente
        Me.txtMedidor.Text = _idmedidor
        Me.txtDirec.Text = _direccion
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        Dim h, i As Integer
        If _modouso = "OFFLINE" Then
            'MsgBox(Now)
            h = insert_reglectura((_idplanilla & _idusuario & Now.ToString("yyyyMMddhhmm").ToString), Me.txtValor.Text, Now, 14444.111, 144555.111, Me.cmbLectura.SelectedValue, _idusuario, Me.txtObservacion.Text)
        Else
            'h = servicio.insert_reglectura((_idplanilla & _idusuario & Now.ToString("yyyyMMddhhmm").ToString), Me.txtValor.Text, Now, 14444.111, 144555.111, Me.cmbLectura.SelectedValue, _idusuario, Me.txtObservacion.Text)
            'h = servicio.insert_reglectura((_idplanilla & _idusuario & Now.ToString("yyyyMMddhhmm").ToString), Me.txtValor.Text, Now, 14444.111, 144555.111, Me.cmbLectura.SelectedValue, _idusuario, Me.txtObservacion.Text)
        End If

        If h > 0 Then
            If _modouso = "OFFLINE" Then
                i = update_planilla_medidor(_idcliente, _idmedidor, _idpredio, (_idplanilla & _idusuario & Now.ToString("yyyyMMddhhmm").ToString))
            Else
              
                'MsgBox((_idplanilla & _idusuario & Now.ToString("yyyyMMddhhmm").ToString))
                i = servicio.update_planilla_medidor(_idcliente, _idmedidor, _idpredio, (_idplanilla & _idusuario & Now.ToString("yyyyMMddhhmm").ToString))
            End If

            If i > 0 Then

                MsgBox("Datos Guardados con Exito", MsgBoxStyle.Information)
                Me.Close()
            Else
                MsgBox("Error al Guardar", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Error al Guardar", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class