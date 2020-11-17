Imports System.Data
Imports System
Imports System.Windows.Forms
Imports System.IO
Public Class frmElegirRuta
    Private dvrutas As DataView
    Private _pciclo As String
    Private _psector As Integer
    Private _pruta As String
    Private dtavance As DataTable
    Private dttotal As DataTable

    Public Function ceros(ByVal Nro As String, ByVal Cantidad As Integer) As String
        Dim numero As String, cuantos As String, i As Integer
        numero = Trim(Nro) 'Trim quita los espacion en blanco 
        cuantos = "0"
        For i = 1 To Cantidad
            cuantos = cuantos & "0"
        Next i
        ceros = Mid(cuantos, 1, Cantidad - Len(numero)) & numero
    End Function

    Private Sub frmElegirRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _modouso = "OFFLINE" Then
            dvrutas = planilla_listar_rutas(_idusuario).Tables("Sini").DefaultView
        Else
            dvrutas = servicio.planilla_listar_rutas(_idusuario).Tables("Sini").DefaultView
        End If

        DataGrid1.DataSource = dvrutas
        _pciclo = (DataGrid1(0, 0))
        _psector = Convert.ToInt64(DataGrid1(0, 1))
        _pruta = (DataGrid1(0, 2))
        lblRutaActual.Text = "Ruta act.: " & _ciclo & "-" & ceros(_sector, 3) & "-" & _ruta
    End Sub

    Private Sub DataGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        Try
            _pciclo = (DataGrid1(DataGrid1.CurrentRowIndex(), 0))
            _psector = Convert.ToInt64(DataGrid1(DataGrid1.CurrentRowIndex(), 1))
            _pruta = (DataGrid1(DataGrid1.CurrentRowIndex(), 2))
            'MessageBox.Show("Cambio Aplicado correctamente: CICLO-SECTOR-RUTA = " & _ciclo & " - " & ceros(_sector, 3) & " - " & _ruta)
            'Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If DataGrid1.VisibleRowCount > 0 Then
                'MessageBox.Show("Hay valores para elegir")

                'MessageBox.Show("Cambiaste a: CICLO-SECTOR-RUTA = " & _ciclo & " - " & ceros(_sector, 3) & " - " & _ruta)
                If (MsgBox("¿Desea Cambiar a la ruta " & _pciclo & "-" & ceros(_psector, 3) & "-" & _pruta & " ?", vbCritical + vbYesNo) = vbYes) Then
                    'confirma el cambio de RUTA
                    _ciclo = _pciclo
                    _sector = _psector
                    _ruta = _pruta
                    _SQLruta = " AND usr_cicl='" & _ciclo & "' AND usr_sect=" & _sector & " AND usr_ruta='" & _ruta & "'"
                    '_indicesecu = 0 'forzando inicio en cero...
                    'SELECCIONANDO INDICE DE INICIO
                    '_minsecu = planillaitems_min(_idusuario)
                    '_maxsecu = planillaitems_max(_idusuario)
                    If _SQLestadoreg = "" Then
                        If _modouso = "OFFLINE" Then
                            _minsecu = planillaitems_min(_idusuario)
                            _maxsecu = planillaitems_max(_idusuario)
                            'ESTADO TODOS
                            If dame_secuenciaUltimoRegistro() = -1 Then
                                _indicesecu = _minsecu
                            Else
                                _indicesecu = dame_secuenciaUltimoRegistro()
                            End If
                        Else
                            _minsecu = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
                            _maxsecu = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
                            'ESTADO TODOS
                            If servicio.dame_secuenciaUltimoRegistro(_SQLruta, _SQLestadoreg) = -1 Then
                                _indicesecu = _minsecu
                            Else
                                _indicesecu = servicio.dame_secuenciaUltimoRegistro(_SQLruta, _SQLestadoreg)
                            End If
                        End If


                    Else
                        If _modouso = "OFFLINE" Then

                            'ESTADO PENDIENTES
                            'calculando el minimo y maximo de la nueva ruta
                            dtavance = ver_avance(_idusuario)
                            dttotal = dame_totalitems(_idusuario)
                            If dtavance.Rows(0)("total") = dttotal.Rows(0)("total") Then
                                'MessageBox.Show("Ud. acabo los registros de la ruta. (" & _ciclo & "-" & ceros(_sector, 3) & "-" & _ruta & ")")
                                _indicesecu = -1
                            Else
                                _minsecu = planillaitems_min(_idusuario)
                                _maxsecu = planillaitems_max(_idusuario)
                                _indicesecu = _minsecu
                            End If
                            'MessageBox.Show("indice:" & _indicesecu)
                        Else
                            'ESTADO PENDIENTES
                            'calculando el minimo y maximo de la nueva ruta
                            dtavance = servicio.ver_avance(_idusuario, _SQLruta)
                            dttotal = servicio.dame_totalitems(_idusuario, _SQLruta)
                            If dtavance.Rows(0)("total") = dttotal.Rows(0)("total") Then
                                'MessageBox.Show("Ud. acabo los registros de la ruta. (" & _ciclo & "-" & ceros(_sector, 3) & "-" & _ruta & ")")
                                _indicesecu = -1
                            Else
                                _minsecu = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
                                _maxsecu = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
                                _indicesecu = _minsecu
                            End If
                            'MessageBox.Show("indice:" & _indicesecu)
                        End If

                    End If

                    Me.Close()

                Else
                    'CANCELAR SELECCION

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        Try
            _pciclo = (DataGrid1(DataGrid1.CurrentRowIndex(), 0))
            _psector = Convert.ToInt64(DataGrid1(DataGrid1.CurrentRowIndex(), 1))
            _pruta = (DataGrid1(DataGrid1.CurrentRowIndex(), 2))
            'MessageBox.Show("Cambio Aplicado correctamente: CICLO-SECTOR-RUTA = " & _ciclo & " - " & ceros(_sector, 3) & " - " & _ruta)
            'Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class