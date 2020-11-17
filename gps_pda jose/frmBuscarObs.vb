Imports System.Data
Imports System
Imports System.Windows.Forms
Imports System.IO
Public Class frmBuscarObs
    Public dt As DataTable
    Public dvobs As DataView
    Public elegido As Integer

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub DataGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.ParentChanged

    End Sub

    Private Sub txtTexto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTexto.TextChanged

    End Sub

    Private Sub btnAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If (_idObsbuscado = -1) Then
            _idObsBuscado = elegido
            Me.Close()
        Else
            MessageBox.Show("Error: Seleccione presionando sobre una fila o con el lapiz del dispositivo movil!.")
        End If
    End Sub

    Private Sub frmBuscarObs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _idObsBuscado = -1
        dvobs = dame_idObs("").Tables("Sini").DefaultView
        DataGrid1.DataSource = dvobs
        DataGrid1.Width = "1000"
        'Dim aGridTableStyle As New DataGridTableStyle
        'Me.DataGrid1.TableStyles.Add(aGridTableStyle)
        'aGridTableStyle.MappingName = "Sini"


        'Dim aCol1 As New DataGridTextBoxColumn

        'With aCol1
        '    .MappingName = "obs_desc"
        '    .Width = 350
        '    .HeaderText = "Descripcion"
        'End With

        'With aGridTableStyle.GridColumnStyles
        '    .Add(aCol1)
        'End With

        'Me.DataGrid1.TableStyles.Add(aGridTableStyle)
        'dvregistros = dame_idObs(txtTexto.Text).Tables("Sini").DefaultView
        'DataGrid1.DataSource = dvregistros
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        dvobs = dame_idObs(txtTexto.Text).Tables("Sini").DefaultView
        DataGrid1.DataSource = dvobs
    End Sub

    Private Sub DataGrid1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        elegido = Convert.ToInt64(DataGrid1(DataGrid1.CurrentRowIndex(), 0))
    End Sub

    Private Sub DataGrid1_CurrentCellChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        elegido = Convert.ToInt64(DataGrid1(DataGrid1.CurrentRowIndex(), 0))
    End Sub

    Private Sub btnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    End Sub
End Class