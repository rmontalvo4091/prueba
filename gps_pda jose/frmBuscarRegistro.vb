Imports System.Data
Imports System
Imports System.Windows.Forms
Imports System.IO
Public Class frmBuscarRegistro
    Public dt As DataTable
    Private dvregistros As DataView
    Public elegido As Integer
    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCampo.SelectedValueChanged

    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmBuscarRegistro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dt = New DataTable("Tabla")

        dt.Columns.Add("campo")
        dt.Columns.Add("descripcion")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr("campo") = "usr_rloc"
        dr("descripcion") = "Lote en Catastro"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("campo") = "usr_manz"
        dr("descripcion") = "Manzano en Catastro"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("campo") = "usr_cuenta"
        dr("descripcion") = "Cuenta Cliente"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("campo") = "usr_apno"
        dr("descripcion") = "Apellido y Nombres del Cliente"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("campo") = "usr_numm"
        dr("descripcion") = "Numero de Medidor"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("campo") = "usr_dirr"
        dr("descripcion") = "Direccion"
        dt.Rows.Add(dr)




        cmbCampo.DataSource = dt
        cmbCampo.ValueMember = "campo"
        cmbCampo.DisplayMember = "descripcion"
        cmbCampo.SelectedText = "Seleccione un criterio de busqueda...."
        _secubuscado = -1

        lblruta.Text = "RUTA : " & _ciclo & "-" & ceros(_sector, 3) & "-" & _ruta

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'MessageBox.Show(cmbCampo.SelectedValue.ToString())
        
        If txtTexto.Text <> "" Then
            Select Case cmbCampo.SelectedValue.ToString()
                Case "usr_cuenta"
                    'buscar por cuenta
                    dvregistros = buscarRegistro_porCuenta(txtTexto.Text).Tables("Sini").DefaultView
                    DataGrid1.DataSource = dvregistros

                    If DataGrid1.VisibleRowCount > 0 Then
                        btnAceptar.Enabled = True
                        lblsinresultados.Visible = False
                        lblruta.Visible = True
                    Else
                        btnAceptar.Enabled = False
                        lblsinresultados.Visible = True
                        lblruta.Visible = False
                    End If
                Case "usr_apno"
                    'buscar por nombre
                    dvregistros = buscarRegistro_por(cmbCampo.SelectedValue.ToString(), "%" & txtTexto.Text & "%").Tables("Sini").DefaultView
                    DataGrid1.DataSource = dvregistros

                    If DataGrid1.VisibleRowCount > 0 Then
                        btnAceptar.Enabled = True
                        lblsinresultados.Visible = False
                        lblruta.Visible = True
                    Else
                        btnAceptar.Enabled = False
                        lblsinresultados.Visible = True
                        lblruta.Visible = False
                    End If
                Case "usr_numm"
                    'buscar por medidor
                    dvregistros = buscarRegistro_por(cmbCampo.SelectedValue.ToString(), "%" & txtTexto.Text).Tables("Sini").DefaultView
                    DataGrid1.DataSource = dvregistros

                    If DataGrid1.VisibleRowCount > 0 Then
                        btnAceptar.Enabled = True
                        lblsinresultados.Visible = False
                        lblruta.Visible = True
                    Else
                        btnAceptar.Enabled = False
                        lblsinresultados.Visible = True
                        lblruta.Visible = False
                    End If
                Case "usr_dirr"
                    'buscar por direccion
                    dvregistros = buscarRegistro_por(cmbCampo.SelectedValue.ToString(), txtTexto.Text & "%").Tables("Sini").DefaultView
                    DataGrid1.DataSource = dvregistros

                    If DataGrid1.VisibleRowCount > 0 Then
                        btnAceptar.Enabled = True
                        lblsinresultados.Visible = False
                        lblruta.Visible = True
                    Else
                        btnAceptar.Enabled = False
                        lblsinresultados.Visible = True
                        lblruta.Visible = False
                    End If
                Case "usr_manz"
                    'buscar por manzano
                    dvregistros = buscarRegistro_por(cmbCampo.SelectedValue.ToString(), txtTexto.Text).Tables("Sini").DefaultView
                    DataGrid1.DataSource = dvregistros

                    If DataGrid1.VisibleRowCount > 0 Then
                        btnAceptar.Enabled = True
                        lblsinresultados.Visible = False
                        lblruta.Visible = True
                    Else
                        btnAceptar.Enabled = False
                        lblsinresultados.Visible = True
                        lblruta.Visible = False
                    End If
                Case "usr_rloc"
                    'buscar por lote
                    dvregistros = buscarRegistro_por(cmbCampo.SelectedValue.ToString(), txtTexto.Text).Tables("Sini").DefaultView
                    DataGrid1.DataSource = dvregistros

                    If DataGrid1.VisibleRowCount > 0 Then
                        btnAceptar.Enabled = True
                        lblsinresultados.Visible = False
                        lblruta.Visible = True
                    Else
                        btnAceptar.Enabled = False
                        lblsinresultados.Visible = True
                        lblruta.Visible = False
                    End If
            End Select
        End If
    End Sub

    Private Sub DataGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        elegido = Convert.ToInt64(DataGrid1(DataGrid1.CurrentRowIndex(), 3))
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If (_secubuscado = -1) Then
            _secubuscado = elegido
            txtsecubuscado.Text = elegido
            Me.Close()
        Else
            MessageBox.Show("Error: Seleccione presionando sobre una fila o con el lapiz del dispositivo movil!.")
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        elegido = Convert.ToInt64(DataGrid1(DataGrid1.CurrentRowIndex(), 3))
    End Sub
End Class