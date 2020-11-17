Imports System.Data
Imports System
Imports System.IO
Imports System.Drawing
Imports Microsoft.WindowsMobile.Forms

Public Class frmMenu

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub btnUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fmusu As New frmUsuarios
        fmusu.ShowDialog()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmcar As New frmCarga
        frmcar.ShowDialog()
    End Sub

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblUsuario.Text = UCase(_nombre)
        Me.lblModo.Text = _modouso
        'inicializando timer para la hora
        Timer1.Interval = 1000
        Timer1.Enabled = True
        _nhojas = 0
        'cargando foto
        Dim archivoFoto As String
        archivoFoto = _nombre & ".jpg"
        If File.Exists("\My Documents\" & archivoFoto) = True Then
            pboxAvatar.Image = New Bitmap("\My Documents\" & archivoFoto)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblHora.Text = DateTime.Now
    End Sub

    Private Sub btnSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        Dim frmconf As New frmConfiguracion
        frmconf.ShowDialog()
    End Sub

    Private Sub btnPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlanilla.Click
        'Dim frpl As New frmPlanilla
        'frpl.ShowDialog()
        Dim frmregsecu As New FormRegistroLecturaSecu
        frmregsecu.ShowDialog()
    End Sub

    Private Sub btnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportes.Click

        If String.IsNullOrEmpty(_SQLruta) Then
            MsgBox(" Seleccione una ruta en Planilla, e intente nuevamente.")
        Else
            'MsgBox(_SQLruta)
            Dim frrep As New frmReporte
            frrep.ShowDialog()
        End If
    End Sub
End Class