Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Web.Services
Imports System.Web.Services.Protocols
Public Class frmConsulta
    Dim servicio As New webPda.consult
    Private Sub frmConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DataGrid1.DataSource = servicio.ConsultaBD_STOCK
        'MsgBox(servicio.ConsultaBD_STOCK().Rows.Count.ToString)
    End Sub
End Class