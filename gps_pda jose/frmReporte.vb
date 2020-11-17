Imports System.Data
Public Class frmReporte

    Private Sub Label1_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.ParentChanged

    End Sub

    Private Sub frmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblRuta.Text = "RUTA: " & _ciclo & "-" & ceros(_sector, 3) & "-" & _ruta
        If _modouso = "OFFLINE" Then
            Me.lblTotal.Text = dame_totalitems(_idusuario).Rows(0)("total") 'dame_avance.Rows(0)("total_reg")
            Me.lblproc.Text = ver_avance(_idusuario).Rows(0)("total")
            Me.lblPendientes.Text = dame_totalitems(_idusuario).Rows(0)("total") - ver_avance(_idusuario).Rows(0)("total")

            Me.lbltotpor.Text = "100%"
            Me.lblprocpor.Text = Decimal.Round((ver_avance(_idusuario).Rows(0)("total") / dame_totalitems(_idusuario).Rows(0)("total")) * 100, 0) & "%"
            Me.lblpenpor.Text = Decimal.Round(((dame_totalitems(_idusuario).Rows(0)("total") - ver_avance(_idusuario).Rows(0)("total")) / dame_totalitems(_idusuario).Rows(0)("total")) * 100, 0) & "%"
            Me.lbl_nhojas.Text = _nhojas & " hojas"

        Else
            Me.lblTotal.Text = servicio.dame_totalitems(_idusuario, _SQLruta).Rows(0)("total") 'dame_avance.Rows(0)("total_reg")
            Me.lblproc.Text = servicio.ver_avance(_idusuario, _SQLruta).Rows(0)("total")
            Me.lblPendientes.Text = servicio.dame_totalitems(_idusuario, _SQLruta).Rows(0)("total") - servicio.ver_avance(_idusuario, _SQLruta).Rows(0)("total")

            Me.lbltotpor.Text = "100%"
            Me.lblprocpor.Text = Decimal.Round((servicio.ver_avance(_idusuario, _SQLruta).Rows(0)("total") / servicio.dame_totalitems(_idusuario, _SQLruta).Rows(0)("total")) * 100, 0) & "%"
            Me.lblpenpor.Text = Decimal.Round(((servicio.dame_totalitems(_idusuario, _SQLruta).Rows(0)("total") - servicio.ver_avance(_idusuario, _SQLruta).Rows(0)("total")) / servicio.dame_totalitems(_idusuario, _SQLruta).Rows(0)("total")) * 100, 0) & "%"
            Me.lblTiempoTrabajo.Text = servicio.dame_tiempoLaboralRuta(_idusuario, _SQLruta, _SQLestadoreg)
            Me.lbl_nhojas.Text = _nhojas & " hojas"
        End If

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.Close()
    End Sub
End Class