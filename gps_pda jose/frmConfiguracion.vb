Public Class frmConfiguracion

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frusu As New frmUsuarios
        frusu.ShowDialog()
    End Sub

    Private Sub btnModo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModo.Click
        Dim fmod As New frmModo
        fmod.ShowDialog()
    End Sub
End Class