Public Class frmModo

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOnline.CheckedChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOffline.CheckedChanged
       

    End Sub

    Private Sub frmModo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case _modouso
            Case "OFFLINE"
                Me.rdbOffline.Checked = True
            Case "ONLINE"
                Me.rdbOnline.Checked = True
        End Select
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        If Me.rdbOffline.Checked = True Then
            _modouso = "OFFLINE"
            Me.Close()
        Else
            _modouso = "ONLINE"
            'MessageBox.Show("Ud. no tiene autorizacion de trabajo en este modo!.")
            Me.Close()
        End If
    End Sub
End Class