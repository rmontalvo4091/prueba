Public Class frmUsuarios
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Me.Close()
    End Sub

    Private Sub DataTextBox_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmUsuarios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If _rol = 1 Then
            DataGrid1.DataSource = dame_usuarios("").Tables(0)
        Else
            DataGrid1.DataSource = dame_usuarios(_nombre).Tables(0)
        End If

    End Sub

    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim frmUsuNvo As New frmUsuarioNvo
        frmUsuNvo.ShowDialog()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        _nombre = (DataGrid1(DataGrid1.CurrentRowIndex(), 1))
        _idusuario = (DataGrid1(DataGrid1.CurrentRowIndex(), 0))
        _clave = (DataGrid1(DataGrid1.CurrentRowIndex(), 2))
        _pin = (DataGrid1(DataGrid1.CurrentRowIndex(), 3))


        Dim frmcampin As New frmUsuarioCambioPin
        frmcampin.ShowDialog()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _idusuario = (DataGrid1(DataGrid1.CurrentRowIndex(), 0))

        Dim response As MsgBoxResult
        ' g = Form12.MovimientosDataGridView.CurrentCell.RowIndex
        response = MsgBox("Desea Eliminar el Registro?", MsgBoxStyle.YesNo, "Advertencia")
        If response = MsgBoxResult.Yes Then
            Dim f As Integer
            f = eliminar_usuario(_idusuario)
            If f = 1 Then
                MsgBox("Usuario Eliminado")
            Else
                MsgBox("Error al Eliminar")
            End If
        End If


    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        _nombre = (DataGrid1(DataGrid1.CurrentRowIndex(), 1))
        _idusuario = (DataGrid1(DataGrid1.CurrentRowIndex(), 0))
        _clave = (DataGrid1(DataGrid1.CurrentRowIndex(), 2))
        _pin = (DataGrid1(DataGrid1.CurrentRowIndex(), 3))


        Dim frmcamcont As New frmUsuarioCambioPass
        frmcamcont.ShowDialog()
    End Sub
End Class