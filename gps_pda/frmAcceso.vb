Public Class frmAcceso
    Dim m As Integer = 0

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
    
        If rdbUsu.Checked = True And dame_login(Me.txtPass.Text).Tables(0).Rows.Count > 0 Then
            If dame_login(Me.txtPass.Text).Tables(0).Rows(0)("usuario_clave") <> encryptar(txtPass.Text) Then
                MsgBox("Datos Incorrectos", MsgBoxStyle.Critical)
                m = m + 1
                If m = 3 Then
                    MsgBox("Demasiados Intentos, la aplicacion se cerrara", MsgBoxStyle.Critical)
                    Application.Exit()
                End If
            Else
                _nombre = dame_login(Me.txtPass.Text).Tables(0).Rows(0)("usuario_nombre")
                _idusuario = dame_login(Me.txtPass.Text).Tables(0).Rows(0)("idusuario")
                _rol = dame_login(Me.txtPass.Text).Tables(0).Rows(0)("rol_idrol")
                _modouso = "OFFLINE" 'completado por raul j.
                _indicesecu = 0 'adicionado por jose luis
                Dim frmmen As New frmMenu
                frmmen.ShowDialog()
            End If
        Else
            If rdbUsu.Checked = True And dame_login(Me.txtPass.Text).Tables(0).Rows.Count = 0 Then
                MsgBox("Datos Incorrectos", MsgBoxStyle.Critical)
                m = m + 1
                If m = 3 Then
                    MsgBox("Demasiados Intentos, la aplicacion se cerrara", MsgBoxStyle.Critical)
                    Application.Exit()
                End If
            End If
        End If


        If rdbPin.Checked = True And dame_pin(Me.txtPin.Text).Tables(0).Rows.Count > 0 Then
            If dame_pin(Me.txtPin.Text).Tables(0).Rows(0)("usuario_pin") <> Me.txtPin.Text Then
                MsgBox("Datos Incorrectos", MsgBoxStyle.Critical)
            Else
                _nombre = dame_login(Me.txtPin.Text).Tables(0).Rows(0)("usuario_nombre")
                _idusuario = dame_login(Me.txtPin.Text).Tables(0).Rows(0)("idusuario")
                _rol = dame_login(Me.txtPin.Text).Tables(0).Rows(0)("rol_idrol")
                _modouso = "OFFLINE"
                Dim frmmen As New frmMenu
                frmmen.ShowDialog()
            End If
        Else
            If rdbPin.Checked = True And dame_pin(Me.txtPin.Text).Tables(0).Rows.Count = 0 Then
                MsgBox("Datos Incorrectos", MsgBoxStyle.Critical)
                m = m + 1
                If m = 3 Then
                    MsgBox("Demasiados Intentos, la aplicacion se cerrara", MsgBoxStyle.Critical)
                    Application.Exit()
                End If
            End If
        End If
       
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Close()
    End Sub

    Private Sub frmAcceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdbPin.Checked = True
        txtPin.Focus()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPin.CheckedChanged
        Me.txtUsu.Visible = False
        Me.txtPass.Visible = False
        Me.lblUsu.Visible = False
        Me.lblPass.Visible = False


        Me.lblPin.Visible = True
        Me.txtPin.Visible = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUsu.CheckedChanged
        Me.txtUsu.Visible = True
        Me.txtPass.Visible = True
        Me.lblUsu.Visible = True
        Me.lblPass.Visible = True


        Me.lblPin.Visible = False
        Me.txtPin.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox(getMd5Hash("12345"))
    End Sub

    Private Sub txtPin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPin.KeyPress
        'If Not IsNumeric(e.KeyChar) Then
        'e.Handled = True
        'End If
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            'MessageBox.Show("Enter key")
            MenuItem1_Click(MenuItem1, Nothing)
        Else
            'MessageBox.Show(tmp.KeyChar)
            If [Char].IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf [Char].IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
End Class