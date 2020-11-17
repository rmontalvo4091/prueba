Imports System.Data
Imports System
Imports System.Windows.Forms
Imports System.IO
Imports gps_pda.PrintCENET
Imports Microsoft.Win32
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports Microsoft.WindowsMobile.Samples.Location
Imports System.Reflection

Public Class FormRegistroLecturaSecu
    Private dvdatos As DataView
    Private dsdatos As DataSet
    Private dtdatos As DataTable
    Private dtreglectura As DataTable
    Private dtobs As DataTable
    Private dttarifas As DataTable
    Private dtavance As DataTable
    Private dttotal As DataTable
    Private dsrutas As DataSet
    Dim idreglectura, _indextemp As Integer
    Private mCurLang As Int32 = 0
    Private periodo As Date
    Private modoEdicion As Boolean
    Private hubocambios As Boolean
    Dim indicetemp As Integer
    Dim idcategoria As Integer
    Private dtplanilla As DataTable
    Dim gps As New Gps()
    Dim device As GpsDeviceState = Nothing
    Dim position As Microsoft.WindowsMobile.Samples.Location.GpsPosition
    Dim sateliti As Integer
    Dim sats() As Satellite
    Dim satSol As Satellite
    Dim lat As Double
    Dim lon As Double
    Dim _mes As Integer
    Dim _gestion As Integer


    Private Sub menuRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuRegresar.Click
        If gps.Opened Then
            gps.Close()
        End If
        Me.Close()
    End Sub

    Private Sub FormRegistroLecturaSecu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _SQLruta = ""
        Try
            If _SQLruta = "" Then
                asignar_ruta_default()
                _SQLruta = " AND usr_cicl='" & _ciclo & "' AND usr_sect=" & _sector & " AND usr_ruta='" & _ruta & "'"
            End If
        Catch ex As Exception

        End Try

        If _modouso = "OFFLINE" Then
            If Not gps.Opened Then
                gps.Open()
            End If
        End If

        _SQLestadoreg = ""
        mnuTodos.Checked = True
        mnuPendientes.Checked = False
        'valores por defecto para GPS
        lat = -17.960701
        lon = -67.104515
        'valor temporal de la secuencia
        _indextemp = _indicesecu

        'indicadores de edicion y cambios reiniciados.
        hubocambios = False
        modoEdicion = False

        Dim mintemp As Integer
        Dim maxtemp As Integer
        Dim ultimasecutemp As Integer

        '////seccion de indices, datos de planilla y check de menu
        If _modouso = "OFFLINE" Then
            mintemp = planillaitems_min(_idusuario)
            maxtemp = planillaitems_max(_idusuario)
            ultimasecutemp = dame_secuenciaUltimoRegistro()
            dtplanilla = planilla_datos(_idusuario)
            MenuOfline.Checked = True
            MenuOnline.Checked = False
        Else
            mintemp = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
            maxtemp = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
            ultimasecutemp = servicio.dame_secuenciaUltimoRegistro(_SQLruta, _SQLestadoreg)
            dtplanilla = servicio.planilla_datos(_idusuario, _SQLruta)
            MenuOfline.Checked = False
            MenuOnline.Checked = True
        End If
        '///fin seccion

        'controlando rango valores min y max
        If mintemp = -1 Then
            _minsecu = _indextemp
        Else
            _minsecu = mintemp
        End If
        If maxtemp = -1 Then
            _maxsecu = _indextemp
        Else
            _maxsecu = maxtemp
        End If

        numsecu.Maximum = _maxsecu
        numsecu.Minimum = _minsecu
        'fin controlando rangos valores
        'prosesionando ultimo registro grabado....
        If ultimasecutemp = -1 Then
            _indextemp = _minsecu
        Else
            _indextemp = ultimasecutemp
        End If
        'fin posesionar ultimo registro
        avanzar(_indextemp)
        labelPeriodo.Text = "Per:" & dtplanilla.Rows(0)("planilla_mes") & "/" & dtplanilla.Rows(0)("planilla_gestion")
        periodo = New DateTime(dtplanilla.Rows(0)("planilla_gestion"), dtplanilla.Rows(0)("planilla_mes"), 1)
        _mes = dtplanilla.Rows(0)("planilla_mes")
        _gestion = dtplanilla.Rows(0)("planilla_gestion")
        cargar_datos()
        Dim name As String = System.Reflection.Assembly.GetExecutingAssembly().FullName 'System.Reflection.Assembly.GetExecutingAssembly().GetName()
        Dim words As String() = name.Split(New Char() {","c})

        _version = words(1)
        lblVersion.Text = _version
        'tabconPlanillaItem.TabPages.RemoveAt(3) ' suponiendo que la numeracion parte de 0.
        tabconPlanillaItem.TabPages.RemoveAt(2) ' suponiendo que la numeracion parte de 0.
        tabconPlanillaItem.SelectedIndex = 0
    End Sub

    Public Function VerificarConexionURL(ByVal mURL As String) As Boolean
        Dim Peticion As System.Net.WebRequest
        Dim Respuesta As System.Net.HttpWebResponse
        Try
            Peticion = System.Net.WebRequest.Create(mURL)
            Respuesta = Peticion.GetResponse()
            Return True
        Catch ex As System.Net.WebException
            If ex.Status = Net.WebExceptionStatus.NameResolutionFailure Then
                Return False
            End If
            Return False
        End Try
    End Function
    Public Function VerificarConexionInternet(ByVal mURL As String) As Boolean
        Dim bool As Boolean
        bool = False
        'seccion no corresponde al proyecto TEAMFUNDATION-selaOruro-jaranibar
    End Function
    Public Shared Function DnsTest() As Boolean
        Try
            Dim ipHe As System.Net.IPHostEntry = System.Net.Dns.GetHostByName("www.google.com")
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function dame_posicion() As String
        ' Ubicacion ...
        Dim status As String
        status = ""
        Try
            'gps.Open()
            If Not gps.Opened Then
                System.Threading.Thread.Sleep(1000)
                gps.Open()
            End If
            If gps.Opened Then
                Dim str As String = ""
                If device IsNot Nothing Then
                    str = device.FriendlyName
                End If
                status = str & vbCrLf
                position = gps.GetPosition()
                position.GetSatellitesInSolution()

                sateliti = position.SatelliteCount

                If position IsNot Nothing Then
                    If position.SeaLevelAltitudeValid AndAlso position.SpeedValid AndAlso position.LatitudeValid AndAlso position.LongitudeValid AndAlso position.SatellitesInSolutionValid AndAlso position.SatellitesInViewValid AndAlso position.SatelliteCountValid AndAlso position.TimeValid Then
                        lat = position.Latitude
                        lon = position.Longitude
                        status = status & " LAT: " & position.Latitude & vbCrLf
                        status = status & " LONG: " & position.Longitude & vbCrLf
                        status = status & " LAT2: " & position.Latitude & vbCrLf & "LONG2: " & position.Longitude & vbCrLf & "Number Satellites: " & position.SatelliteCount & vbCrLf & "DTE/TME: " & position.Time.ToString()
                    Else
                        gps.Close()
                        System.Threading.Thread.Sleep(1000)
                        gps.Open()
                        str = ""
                        If device IsNot Nothing Then
                            str = device.FriendlyName
                        End If
                        status = str & vbCrLf
                        System.Threading.Thread.Sleep(9000)
                        position = gps.GetPosition()
                        position.GetSatellitesInSolution()

                        sateliti = position.SatelliteCount

                        If position IsNot Nothing Then
                            If position.SeaLevelAltitudeValid AndAlso position.SpeedValid AndAlso position.LatitudeValid AndAlso position.LongitudeValid AndAlso position.SatellitesInSolutionValid AndAlso position.SatellitesInViewValid AndAlso position.SatelliteCountValid AndAlso position.TimeValid Then
                                lat = position.Latitude
                                lon = position.Longitude
                                status = status & " LAT: " & position.Latitude & vbCrLf
                                status = status & " LONG: " & position.Longitude & vbCrLf
                                status = status & " LAT2: " & position.Latitude & vbCrLf & "LONG2: " & position.Longitude & vbCrLf & "Number Satellites: " & position.SatelliteCount & vbCrLf & "DTE/TME: " & position.Time.ToString()
                            End If
                            'status = status & " LAT2: 0" & vbCrLf & "LONG2: 0" & vbCrLf
                        End If
                    End If
                Else


                End If
            End If

            'If gps.Opened Then
            '    gps.Close()
            'End If
        Catch ex As NullReferenceException

        End Try
        Return (status)
    End Function
    Sub procesarPulsaciones(ByVal sender As Object, ByVal e As KeyEventArgs)
        ' al pulsar ...
        Select Case e.KeyCode
            Case Keys.Right 'cursor derecha
                Me.Text = "Derecha"
            Case Keys.Left  'cursor izquierda
                Me.Text = "Izquierda"
            Case Keys.Up    'cursor arriba
                Me.Text = "Arriba"
            Case Keys.Down  'cursor abajo
                Me.Text = "Abajo"
        End Select
    End Sub
    Sub asignar_ruta_default()
        If _modouso = "OFFLINE" Then
            dsrutas = planilla_listar_rutas(_idusuario)
        Else
            Try
                dsrutas = Nothing
                Dim customersDataSet As DataSet = servicio.planilla_listar_rutas(_idusuario)
                dsrutas = customersDataSet
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try

        End If
        _ciclo = dsrutas.Tables("Sini").Rows(0)("usr_cicl")
        _sector = dsrutas.Tables("Sini").Rows(0)("usr_sect")
        _ruta = dsrutas.Tables("Sini").Rows(0)("usr_ruta")
    End Sub
    Sub cargar_datos()
        If _modouso = "OFFLINE" Then
            dtdatos = planillaitem(_idusuario, _indicesecu)
            dtavance = ver_avance(_idusuario)
            dttotal = dame_totalitems(_idusuario)
        Else
            'modoUso = ONLINE....
            dtdatos = servicio.planillaitem(_idusuario, _indicesecu, _SQLruta, _SQLestadoreg)
            dtavance = servicio.ver_avance(_idusuario, _SQLruta)
            dttotal = servicio.dame_totalitems(_idusuario, _SQLruta)
            dtplanilla = servicio.planilla_datos(_idusuario, _SQLruta)
            labelPeriodo.Text = "Per:" & dtplanilla.Rows(0)("planilla_mes") & "/" & dtplanilla.Rows(0)("planilla_gestion")
            periodo = New DateTime(dtplanilla.Rows(0)("planilla_gestion"), dtplanilla.Rows(0)("planilla_mes"), 1)
        End If

        'si hay datos por registrar...
        If dtdatos.Rows.Count > 0 Then

            mostrar_datos(dtdatos)
        Else
            'si se alcanzo ha registrar todos....
            If dtavance.Rows(0)("total") = dttotal.Rows(0)("total") Then
                'MessageBox.Show("Felicidades...! termino los registros de lectura de esta ruta. (" & _ciclo & "-" & ceros(_sector, 3) & "-" & _ruta & ")")
                MsgBox("Felicidades...! termino toma de lecturas en esta ruta. (" & _ciclo & "-" & ceros(_sector, 3) & "-" & _ruta & ")", vbInformation + vbOKOnly, "Informacion")
                'cambiando de estado a TODOS y llevando al usuario a la ruta llenada
                _SQLestadoreg = ""
                mnuPendientes.Checked = False
                mnuTodos.Checked = True
                If _modouso = "OFFLINE" Then
                    _minsecu = planillaitems_min(_idusuario)
                    _maxsecu = planillaitems_max(_idusuario)
                Else
                    _minsecu = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
                    _maxsecu = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
                End If

                numsecu.Maximum = _maxsecu
                numsecu.Minimum = _minsecu
                _indicesecu = _minsecu
                avanzar(_indicesecu)
                cargar_datos()
                'fin cambio de modo a TODOS
            Else

                MessageBox.Show("No hay elementos que mostrar")
            End If
        End If

        'este caso solo debera suceder cuando esta seleccionado PENDIENTES....
        'caso no contemplado segun usuario de sela....
        Me.tabconPlanillaItem.SelectedIndex = 0
    End Sub
    Sub mostrar_datos(ByVal dtdatos As DataTable)
        'Si el cliente no cuenta con medidor
        If dtdatos.Rows(0)("usr_numm") = "" Then
            txtMedidor.BackColor = Color.Yellow
        Else
            ' en caso de que tenga Medidor
            txtMedidor.BackColor = Color.White
        End If

        'adicionado el 17-01-2017
        If Convert.ToInt64(dtdatos.Rows(0)("cor_esta")) = 1 Then
            lblcortado.Visible = True
        Else
            lblcortado.Visible = False
        End If
        'fin de adicion......
        _idfoto = dtdatos.Rows(0)("idplanillaitems")
        txtCuenta.Text = dtdatos.Rows(0)("usr_matr") & dtdatos.Rows(0)("usr_dive")
        txtCliente.Text = dtdatos.Rows(0)("usr_apno")
        txtMedidor.Text = dtdatos.Rows(0)("usr_numm")
        txtDireccion.Text = dtdatos.Rows(0)("usr_dirr")
        txtCiclo.Text = dtdatos.Rows(0)("usr_cicl")
        txtSector.Text = ceros(dtdatos.Rows(0)("usr_sect"), 3)
        txtRuta.Text = dtdatos.Rows(0)("usr_ruta")
        txtManzano.Text = ceros(dtdatos.Rows(0)("usr_manz"), 2)
        txtLote.Text = ceros(dtdatos.Rows(0)("usr_rloc"), 3)
        txtUbicacion.Text = dtdatos.Rows(0)("usr_sloc")
        'adiciones del 17-01-2017
        'Sitio de la caja, segun requerimiento de SELA...
        If Convert.ToInt64(dtdatos.Rows(0)("usr_sica")) > 0 Then 'si el codigo de sitio caja esta anotado y es mayor a 0
            If _modouso = "OFFLINE" Then
                'recuperando en OFFLINE
                txtCaja.Text = dame_sitiocaja(Convert.ToInt64(dtdatos.Rows(0)("usr_sica"))).Rows(0)("sitiocaja_descripcion")
            Else
                'recuperando en ONLINE
                txtCaja.Text = servicio.dame_sitiocaja(Convert.ToInt64(dtdatos.Rows(0)("usr_sica"))).Rows(0)("sitiocaja_descripcion")
            End If

        Else
            'de otro modo colocar vacio en el textbox de Caja Sitio
            txtCaja.Text = ""
        End If
        txtEmp.Text = dtdatos.Rows(0)("usr_emp")
        'fin adiciones....
        If _modouso = "OFFLINE" Then
            txtCategoria.Text = dame_categoriaNombre(Convert.ToInt32(dtdatos.Rows(0)("usr_cate")))
        Else
            txtCategoria.Text = servicio.dame_categoriaNombre(Convert.ToInt32(dtdatos.Rows(0)("usr_cate")))
        End If
        txtMayor.Text = dtdatos.Rows(0)("usr_mayor")
        txtDeuda.Text = dtdatos.Rows(0)("deuda")
        txtMeses.Text = dtdatos.Rows(0)("mes")
        txtLec1.Text = dtdatos.Rows(0)("lec1")
        txtLec2.Text = dtdatos.Rows(0)("lec2")
        txtLec3.Text = dtdatos.Rows(0)("lec3")
        txtLec4.Text = dtdatos.Rows(0)("lec4")
        txtLec5.Text = dtdatos.Rows(0)("lec5")
        txtLec6.Text = dtdatos.Rows(0)("lec6")
        txtProm.Text = dtdatos.Rows(0)("usr_prhi")
        idreglectura = dtdatos.Rows(0)("reglectura_idreglectura")
        'ver avance...
        labelAvance.Text = dtavance.Rows(0)("total") & " de " & dttotal.Rows(0)("total") & " reg. hechos"
        tabconPlanillaItem.SelectedIndex = 0

        'mostrando adjuntos con fotos
        If _modouso = "OFFLINE" Then
            Try
                Dim filenameIMG As String = _idfoto & ".jpg" 'extension por defecto de imagen de usuarios...
                If File.Exists("\My Documents\" & filenameIMG) = True Then
                    lblAdjuntos.Text = "(1)Adj."
                Else
                    lblAdjuntos.Text = ""
                End If
            Catch ex As Exception
                lblAdjuntos.Text = ""
            End Try

        Else
            'version no soporta online con fotos....
        End If
        'en caso de REGISTRO GRABADO DE LECTURA
        If idreglectura > 0 Then

            'reponiendo colores a los controles
            'numericObs.ForeColor = Color.Black
            'txtMedidor.BackColor = Color.White

            'recuperando registro de lectura grabado
            If _modouso = "OFFLINE" Then
                dtreglectura = dame_registrolecturaById(idreglectura)
            Else
                dtreglectura = servicio.dame_registrolecturaById(idreglectura)
            End If


            'mostrando registro de lectura....

            mostrar_reglectura(dtreglectura) '**********  OJO.....

            'controlando si existe medidor o es usuario directo.
            If (txtMedidor.Text = "") Then
                numericObs.Value = 5 'idobs para servicio sin medidor
                txtValor.Text = ""    'colocar sin lectura.
                txtValor.ReadOnly = True ' deshabilitar la caja de texto
                numericObs.ReadOnly = True ' desactivando cambios en idobs
                numericObs.Increment = 0  'sin adicionar nada.
            Else
                txtValor.ReadOnly = False   ' habilitar la caja de texto cuando tengn medidor.
                numericObs.ReadOnly = False ' activando cambios en idobs
                numericObs.Increment = 1  'volviendo a incrementar
            End If
            'fin control de usuario medidor

            'cambiandoel texto del boton GRABAR por MODIFICAR....
            MenuGrabar.Text = "MODIFICAR_Lectura"
            'habilitando boton de impresion para lecturas con valores mayores a cero.
            'tambien debe controlarse que tenga medidor condicion: And (txtMedidor.Text <> "")
            If ((txtValor.Text <> "" Or txtValor.Text <> "0") And (txtMedidor.Text <> "")) Then
                MenuImprimir.Enabled = True
            Else
                MenuImprimir.Enabled = False
            End If
            'colocando modo de edicion
            modoEdicion = True
        Else
            'caso REGISTRO NUEVO
            txtValor.Text = ""
            'En caso de que el cliente no tenga medidor...
            If (txtMedidor.Text = "") Then
                numericObs.Value = 5 'idobs para servicio sin medidor
                txtValor.Text = ""    'colocar sin lectura.
                txtValor.ReadOnly = True ' deshabilitar la caja de texto
                numericObs.ReadOnly = True ' desactivando cambios en idobs
                numericObs.Increment = 0  'sin adicionar nada.

                If _modouso = "OFFLINE" Then
                    dtobs = dame_obs(numericObs.Value)
                Else
                    dtobs = servicio.dame_obs(numericObs.Value)
                End If
                txtObs.Text = Convert.ToString(dtobs.Rows(0)("obs_desc"))
                txtObs.ReadOnly = True 'solo modo de lectura para campo observacion
                numericObs.ForeColor = Color.Red

            Else
                'asumimos que tiene medidor
                txtValor.ReadOnly = False   ' habilitar la caja de texto cuando tengn medidor.
                numericObs.ReadOnly = False ' activando cambios en idobs
                numericObs.Increment = 1  'volviendo a incrementar

                numericObs.Value = 0
                If _modouso = "OFFLINE" Then
                    dtobs = dame_obs(numericObs.Value)
                Else
                    dtobs = servicio.dame_obs(numericObs.Value)
                End If
                txtObs.Text = Convert.ToString(dtobs.Rows(0)("obs_desc"))
                txtObs.ReadOnly = True 'solo modo de lectura para campo observacion
                numericObs.ForeColor = Color.Black


            End If
            txtObservacion.Text = ""
            MenuGrabar.Text = "GUARDAR_Lectura"
            MenuImprimir.Enabled = False
            modoEdicion = False
            hubocambios = False
        End If

    End Sub
    Sub mostrar_reglectura(ByVal dtreglectura As DataTable)
        'Si existe al menos un registro de lectura....
        If dtreglectura.Rows.Count > 0 Then
            'recuperando el valor de la lectura
            txtValor.Text = Convert.ToString(dtreglectura.Rows(0)("reglectura_valor"))
            'recuperando el numbero de observacion
            numericObs.Value = Convert.ToInt64(dtreglectura.Rows(0)("obs_idobs"))
            'CASO DE LECTURAS SIN MEDIDOR...

            If _modouso = "OFFLINE" Then
                dtobs = dame_obs(numericObs.Value)
            Else
                dtobs = servicio.dame_obs(numericObs.Value)
            End If
            'recupernado el nombre o descripcion de la observacion
            txtObs.Text = Convert.ToString(dtobs.Rows(0)("obs_desc"))
            'recuperando segunda observacion
            txtObservacion.Text = Convert.ToString(dtreglectura.Rows(0)("reglectura_obs_detalle"))

            If numericObs.Value > 0 Then
                'dtobs = dame_obs(numericObs.Value) '   quitado por jlaa 07-03-2017
                If Convert.ToBoolean(dtobs.Rows(0)("obs_prom")) = True Then
                    'txtValor.Text = ""
                    'txtValor.ReadOnly = True 'CAMBIADO POR jlaa 09-02-2017
                Else
                    If Convert.ToInt64(txtValor.Text) < 0 Then
                        txtValor.Text = ""
                    Else

                    End If
                    txtValor.ReadOnly = False
                End If

            Else
                txtValor.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub btnSig1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig1.Click

        If hubocambios Then
            Dim Pregunta As Integer
            Pregunta = MsgBox("Hubo cambios en el registro ¿Desea guardar?.", vbYesNo + vbExclamation + vbDefaultButton2, "Se detecto cambios.")
            If Pregunta = vbYes Then
                ' elimino al usuario
                cambiar_lectura(idreglectura)
            Else
                ' NO elimino al usuario
                ' Exit lo que sea
                avanzar(_siguiente)
                cargar_datos()
            End If
        Else
            avanzar(_siguiente)
            cargar_datos()
        End If
    End Sub
    Private Sub avanzar(ByVal index As Integer)
        Dim dtindices As DataTable
        Dim mintemp As Integer
        Dim maxtemp As Integer

        If _modouso = "OFFLINE" Then
            planillaindice(_idusuario, index)
            mintemp = planillaitems_min(_idusuario)
            maxtemp = planillaitems_max(_idusuario)
        Else
            dtindices = servicio.planillaindice(_idusuario, index, _minsecu, _maxsecu, _indicesecu, _siguiente, _anterior, _SQLruta, _SQLestadoreg)
            _anterior = dtindices.Rows(0)("cursor")
            _indicesecu = dtindices.Rows(1)("cursor")
            _siguiente = dtindices.Rows(2)("cursor")
            mintemp = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
            maxtemp = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
        End If

        If _anterior = _siguiente Then
            numsecu.Maximum = _siguiente
            numsecu.Minimum = _anterior
        Else
            If mintemp = -1 Then
                _minsecu = index
            Else
                _minsecu = mintemp
            End If
            If maxtemp = -1 Then
                _maxsecu = index
            Else
                _maxsecu = maxtemp
            End If
            numsecu.Maximum = _maxsecu
            numsecu.Minimum = _minsecu
        End If

        numsecu.Value = _indicesecu
        modoEdicion = False
        hubocambios = False
    End Sub
    Private Sub grabar_lectura()
        'INSERTAR LECTURA EN LA BASE DE DATOS.
        Dim h, i As Integer
        Dim idreglec As Integer
        Dim _valor As Integer
        _valor = -1
        _valor = convertir(txtValor.Text)

        If _modouso = "OFFLINE" Then
            'MsgBox(Now)
            Try
                idreglec = Convert.ToInt64(Now.ToString("dd").ToString & Now.ToString("hhmmss").ToString)
                'Dim g As Integer
                'g = 1
                h = insert_reglecturasecu(idreglec, _valor, Now, lat, lon, Me.numericObs.Value, Me.txtObservacion.Text, 0, _idusuario)
                If h > 0 Then
                    i = update_planillaitems_reglectura(_indicesecu, idreglec)
                    If i > 0 Then
                        '**** esta seccion imprime PREAVISO despues de grabar los datos****
                        'modificado el 18-01-2017 jaranibar
                        If (MsgBox("¿Desea imprimir Preaviso de cobro?", vbQuestion + vbYesNo, "Consulta") = vbYes) Then
                            'operador confirma la impresion silenciosa
                            imprimir_aviso()
                            'fin aumento jaranibar 2018
                        End If
                        'Me.Close()
                        '**********fin impresion PREAVISO****
                        modoEdicion = False
                        hubocambios = False
                        avanzar(_siguiente)
                        cargar_datos() 'ocasionaba un salto doble. JLAA 15-02-2017
                        Dim tp As TabPage = tabconPlanillaItem.TabPages(1)
                        Me.tabconPlanillaItem.SelectedIndex = 0
                    Else
                        MsgBox("Error al Guardar", MsgBoxStyle.Exclamation, "Error de sistema")
                    End If
                Else
                    MsgBox("Error al Guardar", MsgBoxStyle.Exclamation, "Error de sistema")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try

        Else
            'MODO ONLINE
            Try
                h = servicio.insert_reglectura(_valor, lat, lon, Me.numericObs.Value, Me.txtObservacion.Text, 0, _idusuario)
                If h > 0 Then

                    i = servicio.update_planillaitems_reglectura(_indicesecu, h, _SQLruta)
                    If i > 0 Then
                        'modificado el 18-01-2017 jlaa, requerimiento de SELA.....quitar mensaje en el sistema.
                        'If (MsgBox("¿Desea imprimir Preaviso?", vbCritical + vbYesNo) = vbYes) Then
                        'operador confirma el dato ingresado
                        'Print(True)
                        'End If
                        'Me.Close()
                        modoEdicion = False
                        hubocambios = False
                        avanzar(_siguiente)
                        cargar_datos() 'ocasionaba un salto doble. JLAA 15-02-2017
                        Dim tp As TabPage = tabconPlanillaItem.TabPages(1)
                        Me.tabconPlanillaItem.SelectedIndex = 0
                    Else
                        MsgBox("Error al Guardar", MsgBoxStyle.Exclamation)
                    End If
                Else
                    MsgBox("Error al Guardar", MsgBoxStyle.Exclamation)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try

        End If


    End Sub
    Private Sub cambiar_lectura(ByVal idreglectura As Integer)
        Dim h As Integer
        Dim _valor As Integer
        Dim fecha_ing As String
        fecha_ing = Now.ToString("dd-MM-yyyy hh:mm:ss")
        _valor = convertir(txtValor.Text)
        If _modouso = "OFFLINE" Then
            h = update_reglecturasecu(idreglectura, _valor, Me.numericObs.Value, Me.txtObservacion.Text, "-17.960701", "-67.104515", Now)
            If (MsgBox("¿Desea reimprimir nuevo aviso de cobro con cambios?", vbQuestion + vbYesNo, "Consulta") = vbYes) Then
                'operador confirma la impresion silenciosa
                cargar_datos()
                imprimir_aviso()
                'fin aumento JLAA 2018
            End If
        Else
            h = servicio.update_reglecturasecu(idreglectura, _valor, Me.numericObs.Value, Me.txtObservacion.Text, "-17.960701", "-67.104515")
        End If
        If h > 0 Then
            'Modificado el 18-01-2017 jlaa
            'If (MsgBox("¿Desea imprimir Preaviso?", vbCritical + vbYesNo) = vbYes) Then
            'operador confirma el dato ingresado
            'Print(True)
            'End If
            avanzar(_siguiente)
            cargar_datos()
            Dim tp As TabPage = tabconPlanillaItem.TabPages(1)
            Me.tabconPlanillaItem.SelectedIndex = 0
        Else
            MsgBox("Error al Guardar", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub validarLectura(ByVal valor As String)
        'modulo revisado por jaranibar 15-05-2017
        Dim _tempcomsumo As Integer
        Dim _promedio As Integer
        Dim _valor As Integer
        Dim _lecant As Integer
        _tempcomsumo = 0
        If txtValor.Text = "" Then
            'CASO: lecturador no lleno valor en LECTURA y existe MEDIDOR
            If Not (String.IsNullOrEmpty(txtMedidor.Text)) And numericObs.Value = 0 Then 'si hay medidor y es LECTURA NORMAL
                'pedir valor de lectura NO PUEDE SER VACIO.
                'Error no coloco un valor en lectura
                MsgBox("Debe introducir un valor de lectura", vbCritical + vbOKOnly, "Error Operador")
                txtValor.Focus()
            Else
                'SIN MEDIDOR
                'entonces GRABAR o MODIFICAR la lectura directamente.
                If modoEdicion Then
                    cambiar_lectura(idreglectura)
                Else
                    grabar_lectura()
                End If
            End If
        Else
            'suponemos que HAY MEDIDOR, el sistema obliga a tener lectura en ese caso.
            If ((txtValor.Text <> "") And ((Convert.ToInt32(txtValor.Text) = 0 And numericObs.Value = 0) Or (Convert.ToInt32(txtValor.Text) > 0 And numericObs.Value = 5))) Then
                'CASO: Lecturador tiene una lectura anotada.
                MsgBox("Revise y cambie CODIGO observacion", vbCritical + vbOKOnly, "Error Operador")
                numericObs.Focus()

            Else
                'caso de valores admitidos
                'fijando valores para promedio y lectura
                _valor = convertir(txtValor.Text)
                _promedio = convertir(txtProm.Text)
                _lecant = convertir(txtLec1.Text)
                'Si el promedio es vacio o CERO o fuera caso MENOR (no previsto en el sistema)
                If (_valor >= 0 And numericObs.Value >= 0) Then
                    If _promedio <= 0 Then
                        'entonces GRABAR o MODIFICAR la lectura directamente.
                        If modoEdicion Then
                            cambiar_lectura(idreglectura)
                        Else
                            grabar_lectura()
                        End If
                    Else
                        'sino entonces verificar CONSUMOS...aLTOS, BAJOS Y normales
                        _tempcomsumo = _valor - _lecant
                        If (_tempcomsumo > 2 * _promedio) Then 'LECTURA ALTA
                            If (MsgBox("¿Desea Grabar LECTURA ALTA?", vbExclamation + vbYesNo, "Advertencia") = vbYes) Then
                                'operador confirma el dato ingresado
                                'txtObservacion.Text = "Consumo ALTO"
                                If modoEdicion Then
                                    cambiar_lectura(idreglectura)
                                Else
                                    grabar_lectura()
                                End If
                            Else
                                txtValor.Focus() 'operador cancela la operacion
                            End If
                        Else
                            'LECTURA BAJA
                            If (_tempcomsumo < 0) Then
                                If (MsgBox("¿Desea Grabar LECTURA BAJA?", vbExclamation + vbYesNo, "Advertencia") = vbYes) Then
                                    'operador confirma el dato ingresado
                                    'txtObservacion.Text = "Consumo NEGATIVO"
                                    If modoEdicion Then
                                        cambiar_lectura(idreglectura)
                                    Else
                                        grabar_lectura()
                                    End If
                                Else
                                    txtValor.Focus() 'operador cancela la operacion
                                End If
                            Else
                                'LECTURA NORMAL
                                If (_tempcomsumo >= 0 And _tempcomsumo <= 2 * _promedio) Then
                                    'LECTURA NORMAL
                                    If modoEdicion Then
                                        cambiar_lectura(idreglectura)
                                    Else
                                        grabar_lectura()
                                    End If
                                Else
                                    'LECTURA NO CONTEMPLADA
                                    MsgBox("ERROR, comunique al administrador el caso de LECTURA.\r\n NO PODRA GRABARSE EL REGISTRO", vbCritical + vbOKOnly, "Error sistema")

                                End If

                            End If
                        End If

                    End If

                Else
                    'caso no contemplado
                    MsgBox("Se produjo un error! CASO NO PREVISTO \r\n Comunique al administrador el caso.", vbCritical + vbOKOnly, "Error sistema")
                End If

            End If 'fin caso de ...casos admitidos
        End If


    End Sub
    
    Private Sub Print8(ByVal silent As Boolean)
        Dim consumo As Double
        Dim cservicio As Double
        Dim cconsumo As Double
        Dim lectura As Integer
        Dim fecha_anterior As Date
        Dim txtmora As String
        Dim print1 As PrintCE
        Dim y As Double = 0.0
        consumo = 0
        Dim py As Double
        py = 0.09
        Try
            print1 = New PrintCE
        Catch x As Exception
            MessageBox.Show(x.Message, "Error")
            Return
        End Try
        print1.Init(C & "-" & O & "-" & D & "-" & E)
        print1.Language = mCurLang
        print1.MeasureUnit = MeasureUnit.kInches

        If silent = True Then
            'configuracion de pagina ZEBRA ZQ520
            Dim info As PrintInfo
            info.printer = 15
            info.port = 4
            info.portrait = True
            info.color_mode = 0
            info.draft_mode = False
            info.paper = 4
            info.paper_width = 8001
            info.paper_height = 9652
            info.start_page = info.end_page = -1
            info.left_margin = info.right_margin = 0
            info.top_margin = info.bottom_margin = 0
            'fin de configuracion de opciones de pagina.

            ' set output file path
            Dim reg_key As String = "HKEY_CURRENT_USER\Software\IneSoft\PrintCE"
            Registry.SetValue(reg_key, "FilePath", "\silent_out.prn")

            ' silent setup
            If print1.SilentPrintSetup(Me.Handle, info) = False Then
                print1.UnInit()
                MsgBox("Falla en Impresion, comunique al administrador !", vbExclamation + vbOKOnly, "Error Impresion")
                Return
            End If
            ' disable progress dialog box
            print1.SilentMode = True

        Else
            ' show print setup dialog
            If print1.SetupDlg(Me.Handle) = False Then
                print1.UnInit()
                Return
            End If
        End If

        ' set margins
        print1.LeftMargin = 0.02
        print1.RightMargin = 0.02
        print1.TopMargin = 0.005
        print1.BottomMargin = 0.0

        ' start printing document
        print1.StartDoc()

        ' start printing page
        print1.StartPage()

        Dim n As Integer = 0
        'cargando logo del cliente SELA, jaranibar 06-01-2017
        Dim ret As Boolean = print1.DrawPicture("\logo_sela.jpg", 0.06, 0.04, 0.49, 0.28, True)
        print1.FontSize = 14.0
        print1.FontBold = True
        print1.DrawText("SELA-ORURO", 0.8, 0.1 - py)

        'SUBTITULO
        print1.FontSize = 10.0
        print1.FontBold = True
        print1.DrawText("AVISO DE COBRO", 0.85, 0.35 - py) 'SUBTITULO

        'Codigo Lecturador
        print1.FontSize = 7.0
        print1.FontBold = False
        print1.DrawText("OP: " & _idusuario, 2.35, 0.15 - py) 'SUBTITULO
        'usuario
        print1.DrawText("US: " & _nombre, 2.35, 0.25 - py) 'SUBTITULO
        'version del sistema
        print1.FontSize = 6.5
        print1.DrawText(_version, 2.34, 0.35 - py) 'SUBTITULO


        'cabecera labels
        print1.FontBold = True
        print1.FontSize = 9.0

        print1.DrawText("Nro.", 2.45, 0.55 - py) 'nro 0
        print1.DrawText("PERIODO", 0.7, 0.55 - py) 'nro 1
        print1.DrawText("CUENTA", 0.06, 0.76 - py) 'nro 2
        print1.DrawText("CATASTRO", 0.7, 0.76 - py) 'nro 3
        print1.DrawText("MEDIDOR", 1.6, 0.76 - py) 'nro 3
        print1.DrawText("FECHA", 2.45, 0.76 - py) 'nro 3
        print1.DrawText("CATEGORIA", 0.06, 1.03 - py)   'nro 4
        print1.TextHorAlign = TextHorAlign.hRight
        'opcion eliminada en el sistema, 04-05-2017
        print1.TextHorAlign = TextHorAlign.hLeft
        print1.DrawText("NOMBRE", 0.06, 1.3 - py)   'nro 8
        print1.DrawText("DIRECCION", 0.06, 1.6 - py)   'nro 9


        'cabecera data
        print1.FontBold = False
        print1.FontSize = 8.0
        print1.DrawText(ceros(_indicesecu, 4), 2.78, 0.55 - py)    'nro 0  NRO SECUENCIA...segun req. de sela.
        print1.DrawText(UCase(MonthName(_mes)) & " / " & _gestion, 1.42, 0.55 - py)    'nro 1  PERIODO DE COBRO
        print1.DrawText(txtCuenta.Text, 0.06, 0.9 - py) 'nro 2  CUENTA
        print1.DrawText(_ciclo & "-" & ceros(_sector, 3) & "-" & _ruta & "-" & (txtManzano.Text) & "-" & (txtLote.Text), 0.7, 0.9 - py)  'nro 3  Nro de preaviso
        print1.DrawText(txtCategoria.Text, 0.06, 1.16 - py)    'nro 4  CICLO
        print1.DrawText(Now.ToString("dd/MM/yyyy"), 2.45, 0.9 - py)    'nro 5  fecha de emision
        print1.DrawText(Now.ToString("hh:mm tt"), 2.45, 1.03 - py)    'nro 5  fecha de emision
        print1.DrawText(txtMedidor.Text, 1.6, 0.9 - py)    'nro 7  numero de medidor
        print1.DrawText(txtCliente.Text, 0.06, 1.45 - py)    'nro 8.- nombre
        print1.DrawText(txtDireccion.Text, 0.06, 1.75 - py)    'nro 9.- direccion



        'consumo labels
        If Not isLecturaCeroConObs(lectura, numericObs.Value) Then
            print1.FontBold = True
            print1.FontSize = 9.0
            print1.DrawText("FECHA", 0.75, 1.9 - py)
            print1.DrawText("LECTURA", 1.37, 1.9 - py)
            print1.DrawText("ANTERIOR", 0.06, 2.03 - py)
            print1.DrawText("ACTUAL", 0.06, 2.16 - py)
            print1.DrawText("CONSUMO ACTUAL", 0.06, 2.29 - py)
        End If

        'comsumo data
        print1.FontBold = False
        print1.FontSize = 8.0

        If Not isLecturaCeroConObs(lectura, numericObs.Value) Then
            If IsDBNull(dtdatos.Rows(0)("fechan1")) Then
                print1.DrawText(Now.AddDays(-30).ToString("dd/MM/yyyy"), 0.75, 2.03 - py) 'fecha anterior NO EXISTE EN EL SISTEMA
            Else
                print1.DrawText(DateTime.Parse(dtdatos.Rows(0)("fechan1")).ToString("dd/MM/yyyy"), 0.75, 2.03 - py) 'fecha anterior REGISTRADO EN BASE DE DATOS
            End If

            print1.DrawText(Now.ToString("dd/MM/yyyy"), 0.75, 2.16 - py) ' fecha actual = AHORA
            print1.TextHorAlign = TextHorAlign.hRight
            print1.DrawText(txtLec1.Text, 1.75, 2.03 - py) 'lectura anterior LEC1

        End If



        If txtValor.Text = "" Then
            lectura = 0
        Else
            lectura = Convert.ToInt64(txtValor.Text)
        End If

        '#AREA DE CALCULO DE CONSUMO.
        If txtValor.Enabled = False And txtValor.Text <> "" Then
            consumo = 0
        Else
            'CASO EN QUE EXISTE CONSUMO SEA POSITIVO O NEGATIVO
            Dim difLec As Double
            difLec = lectura - Convert.ToInt64(txtLec1.Text)
            If difLec >= 0 Then
                'CASO DE CONSUMO POSITIVO O CONSUMO NORMAL.
                'consumo = Convert.ToInt64(txtValor.Text) - Convert.ToInt64(txtLec1.Text)
                consumo = difLec
            Else
                'CASO CONSUMO NEGATIVO
                Dim capMed As Integer
                '#AREA DE CONTROL DE VUELTA DE MEDIDOR
                If (Convert.ToInt32(dtdatos.Rows(0)("usr_came").ToString()) > 0) Then
                    capMed = Math.Pow(10, Convert.ToInt32(dtdatos.Rows(0)("usr_came").ToString()))

                    'CASO DE VUELTA DE MEDIDOR Y CONSUMO CALCULADO
                    If ((Convert.ToInt64(txtLec1.Text) > capMed * 0.89) And (lectura < capMed * 0.11)) Then
                        consumo = (capMed - Convert.ToInt64(txtLec1.Text)) + lectura
                    Else
                        consumo = difLec
                    End If
                Else
                    'ultimo casi confirmar de CONSUMO NEGATIVO INCONSISTENTE.
                    consumo = difLec
                End If

            End If

        End If
        '# FIN AREA DE CALCULO DE CONSUMO....

        'consumo = Decimal.Round(consumo, 1)' no aplica redondeo...
        idcategoria = Convert.ToInt64(dtdatos.Rows(0)("usr_cate"))

        If Not isLecturaCeroConObs(lectura, numericObs.Value) Then
            print1.DrawText(lectura, 1.75, 2.16 - py)
        End If

        'imprimiendo el consumo si fuera mayor que cero 
        'nop aplica formateo consumo.ToString("##,##0.00")

        '#AREA DE DATOS LECTURA
        If consumo >= 0 Then
            print1.DrawText(consumo, 1.75, 2.29 - py)
            print1.TextHorAlign = TextHorAlign.hLeft
            print1.DrawText(" (m3)", 1.75, 2.29 - py)
        Else
            If Not isLecturaCeroConObs(lectura, numericObs.Value) Then
                print1.DrawText("***", 1.75, 2.29 - py)
                print1.TextHorAlign = TextHorAlign.hLeft
            End If

        End If
        print1.TextHorAlign = TextHorAlign.hRight
        print1.FontSize = 7.5
        If consumo >= 0 Then
            'print1.DrawText("DEBE POR SERVICIO DEL MES  ", 0.01, 2.5)
            print1.DrawText("FACTURA DEL MES " & (UCase(MonthName(_mes, True))) & ". Bs.", 1.37, 2.5 - py)
        End If
        If (Convert.ToInt32(txtMeses.Text) = 1) Then
            print1.DrawText("FACTURA PENDIENTE Bs.", 1.37, 2.61 - py)
        End If
        If (Convert.ToInt32(txtMeses.Text) > 1) Then
            print1.DrawText("(" & txtMeses.Text & ")" & "FACT. PENDIENTES Bs.", 1.37, 2.61 - py)
        End If
        If (Convert.ToInt32(txtMeses.Text) <= 0) Then
            print1.DrawText("(" & txtMeses.Text & ")" & "FACTURAS PENDIENTES Bs.", 1.37, 2.61 - py)
        End If

        If consumo >= 0 Then
            print1.FontBold = True
            print1.DrawText("TOTAL Bs.", 1.37, 2.72 - py)
            print1.FontBold = False
        End If
        print1.TextHorAlign = TextHorAlign.hLeft
        print1.FontSize = 8.0
        'inicando variables auxiliares
        cconsumo = 0
        Dim leyConsumo = 0
        txtmora = ""
        dttarifas = dame_tarifa(idcategoria)
        If dame_tarifa(idcategoria).Rows.Count > 0 Then
            If consumo >= 0 Then
                'si el existe un consumo que facturar

                'calculando consumo segun rando de tarifa
                Select Case consumo

                    Case Is <= 20
                        cconsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran1")
                        If consumo <= 15 Then
                            leyConsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran1")
                        Else
                            leyConsumo = 15 * dame_tarifa(idcategoria).Rows(0)("tarifas_ran1")
                        End If

                    Case 21 To 30
                        Try
                            cconsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran2")
                            leyConsumo = 15 * dame_tarifa(idcategoria).Rows(0)("tarifas_ran2")
                        Catch ex As Exception

                        End Try
                    Case 31 To 40
                        Try
                            cconsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran3")
                            leyConsumo = 15 * dame_tarifa(idcategoria).Rows(0)("tarifas_ran3")
                        Catch ex As Exception

                        End Try
                    Case 41 To 60
                        Try
                            cconsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran4")
                            leyConsumo = 15 * dame_tarifa(idcategoria).Rows(0)("tarifas_ran4")
                        Catch ex As Exception

                        End Try
                    Case 61 To 80
                        Try
                            cconsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran5")
                            leyConsumo = 15 * dame_tarifa(idcategoria).Rows(0)("tarifas_ran5")
                        Catch ex As Exception

                        End Try
                    Case 81 To 100
                        Try
                            cconsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran6")
                            leyConsumo = 15 * dame_tarifa(idcategoria).Rows(0)("tarifas_ran6")
                        Catch ex As Exception

                        End Try
                    Case Is > 100
                        Try
                            cconsumo = consumo * dame_tarifa(idcategoria).Rows(0)("tarifas_ran7")
                            leyConsumo = 15 * dame_tarifa(idcategoria).Rows(0)("tarifas_ran7")
                        Catch ex As Exception

                        End Try
                End Select

                'calculando descuento por ley del 20%
                Dim dley As Double
                If txtMayor.Text = "S" Then
                    'CONDICION DE REBAJA SOLO APLICA HASTA CONSUMO DE 15.
                    dley = (Convert.ToDouble(dame_tarifa(idcategoria).Rows(0)("tarifas_cfijo")) + leyConsumo) * 0.2
                    'dley = (Convert.ToDouble(dame_tarifa(idcategoria).Rows(0)("tarifas_cfijo")) + cconsumo) * 0.2
                Else
                    dley = 0
                End If
                'dley = Decimal.Round(dley, 1)'se quita redondeo al descuento por ley
                'calculando costo por mora
                Dim cmora As Double
                If Convert.ToInt64(txtMeses.Text) >= 2 Then
                    cmora = Convert.ToDouble(dame_tarifa(idcategoria).Rows(0)("tarifas_mora"))
                    txtmora = " y COSTO POR MORA"
                Else
                    cmora = 0
                    txtmora = ""
                End If
                'cmora = Decimal.Round(cmora, 1)'quitando redondeo a cargo por mora.
                Dim cfijo, cform As Double
                cfijo = Convert.ToDouble(dame_tarifa(idcategoria).Rows(0)("tarifas_cfijo"))

                'cfijo = Decimal.Round(cfijo, 1)
                cform = Convert.ToDouble(dame_tarifa(idcategoria).Rows(0)("tarifas_formu"))
                'cform = Decimal.Round(cform, 1)

                'cservicio = cfijo + cconsumo + cform - dley + cmora

                '///considerando casos de calculo de categorias...
                cconsumo = Decimal.Round(cconsumo, 2)
                If idcategoria = 18 Then
                    Dim nuvi As Integer = Convert.ToInt32(dtdatos.Rows(0)("usr_nuvi").ToString())
                    cservicio = caso_edificios(cconsumo, nuvi, cfijo, cform)
                ElseIf idcategoria = 21 Then
                    Dim nope As Integer = Convert.ToInt32(dtdatos.Rows(0)("usr_nope").ToString())
                    cservicio = caso_sSolidario(consumo, nope, cfijo, cform)
                Else
                    'todos los demas casos y categorias
                    cservicio = cfijo + cconsumo + cform - dley ' se quito mora a sol. del cliente sela.
                End If

                cservicio = Decimal.Round(cservicio, 1) 'REDONDEO segun requerimiento SELA.
                print1.TextHorAlign = TextHorAlign.hRight
                print1.DrawText(FormatNumber(cservicio, 2), 1.9, 2.5 - py) ' A.- total servicio....
                print1.TextHorAlign = TextHorAlign.hLeft
            Else
                ' si es un consumo negativo
                ' A.- total servicio....
                'CASO de consumo negativo, ALERTA de lectura a normal. INCONSISTENTE.
                'AREA mensaje#1
                print1.FontSize = 7.5
                print1.DrawText("*Aviso.- Ud. debe pasar a consultar su deuda por ODECO-SELA*", 0.055, 3.23 - py)
                print1.FontSize = 8.0

            End If
        Else
            'cservicio = 0  ' sino existe tarifa el costo de servicio sera cero.
            print1.FontSize = 7.5
            print1.DrawText("Error en el sistema !, no existe tarifa para este periodo.", 0.2, 2.89 - py) ' A.- total servicio....
            print1.FontSize = 8.0

        End If
        'CASO de lectura en CERO o existe una observacion registrada
        'End If
        Dim msgLecCero As String
        If isLecturaCeroConObs(lectura, numericObs.Value) Then
            print1.DrawText("Sr. Usuario tome lectura de su medidor", 0.06, 2.03 - py)
            print1.FontBold = True
            print1.DrawText("SELA no tomo lectura porque:", 0.06, 2.16 - py)
            print1.FontBold = False
            print1.DrawText(txtObs.Text, 0.06, 2.29 - py)
        End If
        ' A.- total servicio....
        print1.TextHorAlign = TextHorAlign.hRight
        Dim deuda As Decimal
        Try
            deuda = Decimal.Round(Convert.ToDouble(txtDeuda.Text), 1)

        Catch ex As Exception
            deuda = 0
        End Try
        print1.DrawText(FormatNumber(deuda, 2), 1.9, 2.61 - py) ' B.- total deuda anterior

        If consumo >= 0 Then
            print1.DrawText(FormatNumber(cservicio + deuda, 2), 1.9, 2.72 - py) 'total a pagar A+B
        End If

        print1.TextHorAlign = TextHorAlign.hLeft
        'eliminado por cliente final, modificado a requerimiento SELA. jaranibar
        'total literal
        'print1.DrawText("TOTAL LITERAL", 0, 2.9)
        'print1.DrawText(Letras(FormatNumber(cservicio + Convert.ToDouble(txtDeuda.Text), 2)), 1, 2.9)

        'total deudas
        print1.FontBold = True
        print1.DrawText("OBSERVACION", 0.06, 3.1 - py)
        print1.FontBold = False
        'print1.DrawText("(" & txtMeses.Text & ") DEUDAS ANTERIORES" & txtmora, 1, 3.1 - py)
        If Convert.ToInt32(txtMeses.Text) = 0 Or txtMeses.Text = "" Then
            print1.DrawText("Sin deudas pendientes, cliente puntual!", 1, 3.1 - py)
        End If
        If Convert.ToInt32(txtMeses.Text) = 1 Then
            print1.DrawText("(" & txtMeses.Text & ") DEUDA ANTERIOR", 1, 3.1 - py)
        End If
        If Convert.ToInt32(txtMeses.Text) >= 2 Then
            print1.DrawText("(" & txtMeses.Text & ") DEUDAS ANTERIORES", 1, 3.1 - py)
            'mensaje de costo por mora
            print1.FontBold = False
            print1.FontSize = 6.01
            If Not isLecturaCeroConObs(lectura, numericObs.Value) Then
                print1.DrawText("ALERTA!. Ud. esta a punto de recibir corte de servicio y cargos por rehabilitacion.", 0.055, 2.95 - py)
            End If

        End If

        'historico

        print1.FontBold = True
        print1.FontSize = 9.0

        'print1.DrawText("HISTORIAL DE CONSUMO", 2.25, 2.05 - py)
        print1.LineWidth = 0.018
        print1.DrawLine(2.05, 1.9 - py, 2.05, 2.86 - py)
        print1.DrawText("HISTORIAL", 2.11, 1.9 - py)
        print1.FontBold = True
        print1.FontSize = 7.0
        print1.DrawText("PERIODO", 2.07, 2.05 - py)
        print1.DrawText("CONSUMO", 2.545, 2.05 - py)

        'consumo_data
        print1.FontBold = False
        print1.FontSize = 8.0

        consumo = 0
        For n = 0 To 5
            print1.DrawText(n + 1, 2.08, 2.16 + n * 0.11 - py)
            print1.DrawText(periodo.AddMonths(n - 6).ToString("MMM/yyyy"), 2.18, 2.16 + n * 0.11 - py)
            Select Case n
                Case 0
                    'falta un historico Lec7
                    'consumo = 0
                    Dim lec7 As String
                    'lec7 = dtdatos.Rows(0)("lec7")
                    If String.IsNullOrEmpty(dtdatos.Rows(0)("lec7")) Then
                        lec7 = 0
                    Else
                        lec7 = Convert.ToInt64(dtdatos.Rows(0)("lec7"))
                    End If
                    If Convert.ToInt64(dtdatos.Rows(0)("lec7")) >= 0 Then
                        consumo = Convert.ToInt64(txtLec6.Text) - Convert.ToInt64(dtdatos.Rows(0)("lec7"))
                    Else
                        consumo = 0
                    End If
                Case 1
                    If txtLec5.Text <> "0" And txtLec6.Text <> "0" Then
                        consumo = Convert.ToInt64(txtLec5.Text) - Convert.ToInt64(txtLec6.Text)
                    Else
                        consumo = 0
                    End If
                Case 2
                    If txtLec4.Text <> "0" And txtLec5.Text <> "0" Then
                        consumo = Convert.ToInt64(txtLec4.Text) - Convert.ToInt64(txtLec5.Text)
                    Else
                        consumo = 0
                    End If
                Case 3

                    If txtLec3.Text <> "0" And txtLec4.Text <> "0" Then
                        consumo = Convert.ToInt64(txtLec3.Text) - Convert.ToInt64(txtLec4.Text)
                    Else
                        consumo = 0
                    End If
                Case 4
                    If txtLec2.Text <> "0" And txtLec3.Text <> "0" Then
                        consumo = Convert.ToInt64(txtLec2.Text) - Convert.ToInt64(txtLec3.Text)
                    Else
                        consumo = 0
                    End If
                Case 5
                    'consumo = Convert.ToInt64(txtLec1.Text) - Convert.ToInt64(txtLec2.Text)
                    If txtLec1.Text <> "0" And txtLec2.Text <> "0" Then
                        consumo = Convert.ToInt64(txtLec1.Text) - Convert.ToInt64(txtLec2.Text)
                    Else
                        consumo = 0
                    End If
            End Select
            print1.TextHorAlign = TextHorAlign.hRight
            print1.DrawText(consumo, 2.97, 2.16 + n * 0.11 - py)
            print1.TextHorAlign = TextHorAlign.hLeft
        Next
        'mensaje de costo por mora
        print1.FontBold = False
        print1.FontSize = 6.01
        'AREA MENSAJE#2
        print1.DrawText("SI SU DEUDA ES MAYOR A 2 MESES SE COBRARA LA MULTA POR MORA EN CAJA.", 0.055, 3.35 - py)

        ''pie de pagina
        print1.FontBold = False
        print1.FontSize = 6.3
        'print1.DrawText("ESTIMADO CLIENTE, SE RECOMIENDA PAGAR EL SERVICIO, PARA EVITAR RECARGOS/CORTES QUE", 0, 3.4)
        'AREA PIE#1
        print1.FontBold = True
        print1.FontSize = 5.95
        print1.DrawText("Si Ud. cancelo en caja meses pendientes, no tome en cuenta el valor de fact. pend.", 0.055, 3.4)
        'AREA PIE#2
        'print1.FontBold = False
        'print1.FontSize = 6.3
        'print1.DrawText("Estimado Cliente, en  caso de  encontrar diferencias en la  lectura actual y la", 0.06, 3.6 - py)
        'print1.DrawText("lectura  de  su  medidor,   favor  presentar  el  reclamo  en  ODECO  para  la ", 0.06, 3.7 - py)
        'print1.DrawText("corrección  en el mes.   ...GRACIAS!...", 0.06, 3.8 - py)
        If (txtCuenta.Text.Length = 0 Or String.IsNullOrEmpty(txtCuenta.Text)) Then ' aviso para cladestinos
            print1.DrawText("NOTIFICACION PARA APERSONARSE POR SeLA ORURO( OFICINA GESTION TRAMITES)", 0.06, 3.6 - py)
            print1.DrawText("A REGULARIZAR SU INSTALACION CLANDESTINA, ", 0.06, 3.7 - py)
            print1.DrawText("AFIN DE EVITAR EL RETIRO DESDE LA MATRIZ  ...GRACIAS!...", 0.06, 3.8 - py)
        Else
            print1.DrawText("Estimado Cliente, en  caso de  encontrar diferencias en la  lectura actual y la", 0.06, 3.6 - py)
            print1.DrawText("lectura  de  su  medidor,   favor  presentar  el  reclamo  en  ODECO  para  la ", 0.06, 3.7 - py)
            print1.DrawText("corrección  en el mes.   ...GRACIAS!...", 0.06, 3.8 - py)
        End If

        'AREA PIE#2
        print1.DrawText("TELEFONOS ODECO 5276665 - 5235947 - 5277045.  SELA ORURO", 0.25, 3.9 - py)

        ''End If

        ''===============================================================

        ' end printing document
        print1.EndDoc()

        ' library deinitialization
        print1.UnInit()

    End Sub

    Private Sub btnAnt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnt1.Click

        If hubocambios Then
            Dim Pregunta As Integer
            Pregunta = MsgBox("Hubo cambios en el registro ¿Desea guardar?.", vbYesNo + vbExclamation + vbDefaultButton2, "Se detecto cambios.")
            If Pregunta = vbYes Then
                ' elimino al usuario
                cambiar_lectura(idreglectura)
            Else
                ' NO elimino al usuario
                ' Exit lo que sea
                avanzar(_anterior)
                cargar_datos()
            End If
        Else
            avanzar(_anterior)
            cargar_datos()
        End If
    End Sub

    Private Sub btnSig2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig2.Click
        If hubocambios Then
            Dim Pregunta As Integer
            Pregunta = MsgBox("Hubo cambios en el registro ¿Desea guardar?.", vbYesNo + vbExclamation + vbDefaultButton2, "Se detecto cambios.")
            If Pregunta = vbYes Then
                ' elimino al usuario
                cambiar_lectura(idreglectura)
            Else
                ' NO elimino al usuario
                ' Exit lo que sea
                avanzar(_maxsecu)
                cargar_datos()
            End If
        Else
            avanzar(_maxsecu)
            cargar_datos()
        End If
    End Sub

    Private Sub btnAnt2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnt2.Click
        'avanzar(_minsecu)
        'cargar_datos()
        If hubocambios Then
            Dim Pregunta As Integer
            Pregunta = MsgBox("Hubo cambios en el registro ¿Desea guardar?.", vbYesNo + vbExclamation + vbDefaultButton2, "Se detecto cambios.")
            If Pregunta = vbYes Then
                ' elimino al usuario
                cambiar_lectura(idreglectura)
            Else
                ' NO elimino al usuario
                ' Exit lo que sea
                avanzar(_minsecu)
                cargar_datos()
            End If
        Else
            avanzar(_minsecu)
            cargar_datos()
        End If
    End Sub

    Private Sub MenuGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuGrabar.Click

        'If VerificarConexionURL("http://www.google.com") Then
        '    MsgBox(dame_posicion())
        'Else
        '    MsgBox("No existe conexion internet")
        'End If
        'If DnsTest() Then
        '    'MsgBox("hay internet")
        '    MsgBox(dame_posicion())
        'Else
        '    MsgBox("sin internet error, revise conexion")
        'End If
        'MsgBox(dame_posicion())

        'escribirLog("ninguno")

        Dim msgGPS As String
        If _modouso = "ONLINE" Then
            Try
                msgGPS = dame_posicion()
            Catch ex As Exception
            End Try
        End If
        validarLectura(txtValor.Text)
    End Sub

    Private Sub MenuImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuImprimir.Click
        If hubocambios Then
            Dim Pregunta As Integer
            Pregunta = MsgBox("Hubieron cambios en el registro de lectura ¿Desea modificar el registro de lectura?", vbYesNo + vbExclamation + vbDefaultButton2, "Se detecto cambios.")
            If Pregunta = vbYes Then
                ' guardar e imprimir
                validarLectura(txtValor.Text)
            Else
                ' salirse no hacer nada
                'volver cargar datos
                cargar_datos()
            End If
        Else
            'MessageBox.Show("ant :" + _anterior.ToString() + "; sig: " + _siguiente.ToString())
            'Print(True) 'modificado el 17-01-2017 jlaa
            'Print(False)
            'Print8(True)
            'Print8(False)
            imprimir_aviso()
        End If

    End Sub
    Public Sub imprimir_aviso()

        update_planillaitems_impresion(_indicesecu, idreglectura)
        Print8(True) 'para sela
        'Print8(False) 'para debug
        _nhojas = _nhojas + 1

    End Sub

    Private Sub numericObs_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numericObs.ValueChanged
        Try
            If _modouso = "OFFLINE" Then
                dtobs = dame_obs(numericObs.Value)
            Else
                dtobs = servicio.dame_obs(numericObs.Value)
            End If

            txtObs.Text = Convert.ToString(dtobs.Rows(0)("obs_desc"))
            'si tipo de obs es 0

            If Convert.ToBoolean(dtobs.Rows(0)("obs_prom")) Then
                'txtValor.Text = Convert.ToDecimal(txtProm.Text) + Convert.ToDecimal(txtLec1.Text)
                'txtValor.Text = ""
                'txtValor.ReadOnly = True
            Else
                'txtValor.ReadOnly = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        If modoEdicion Then
            hubocambios = True
        End If
    End Sub

    Private Sub numericObs_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numericObs.KeyUp
        Try
            If _modouso = "OFFLINE" Then
                dtobs = dame_obs(numericObs.Value)
            Else
                dtobs = servicio.dame_obs(numericObs.Value)
            End If
            txtObs.Text = Convert.ToString(dtobs.Rows(0)("obs_desc"))
            If Convert.ToBoolean(dtobs.Rows(0)("obs_prom")) Then
                'txtValor.Text = Convert.ToDecimal(txtProm.Text) + Convert.ToDecimal(txtLec1.Text)
                'txtValor.Text = ""
                'txtValor.ReadOnly = True
            Else
                'txtValor.ReadOnly = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub txtValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValor.TextChanged
        If modoEdicion Then
            hubocambios = True
        End If
    End Sub

    Private Sub txtObservacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservacion.TextChanged
        If modoEdicion Then
            hubocambios = True
        End If
    End Sub

    Private Sub txtValor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            'MessageBox.Show("Enter key")
            validarLectura(txtValor.Text)
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

    Private Sub numsecu_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numsecu.ValueChanged
        Try
            indicetemp = _indicesecu
            avanzar(numsecu.Value)
            cargar_datos()
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
            'MessageBox.Show("La secuencia " & numsecu.Value & " no existe en el sistema!.El sistema avanzara a uno valido por Ud.")
            If numsecu.Value > indicetemp Then
                numsecu.Value = _siguiente
            Else
                If numsecu.Value < indicetemp Then
                    numsecu.Value = _anterior
                End If
            End If
            'MessageBox.Show("La secuencia " & indicetemp & " no existe en el sistema!.El sistema avanzo a uno valido por Ud.")
        Finally
        End Try
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim cambiarRuta As New frmElegirRuta
        ' Show testDialog as a modal dialog and determine if DialogResult = OK.
        If cambiarRuta.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' Read the contents of testDialog's TextBox.
            If _indicesecu >= 0 Then 'cuando habia secuencia 0 no avanzaba por esta condicion JLLA 15-02-2017

                avanzar(_indicesecu)
                cargar_datos()
            Else
                'se trata de uno lleno o un caso no previstro
                'cambiar modo de trabajo en la RUTA a TODOS...
                _SQLestadoreg = ""
                mnuPendientes.Checked = False
                mnuTodos.Checked = True
                If _modouso = "OFFLINE" Then
                    _minsecu = planillaitems_min(_idusuario)
                    _maxsecu = planillaitems_max(_idusuario)
                Else
                    _minsecu = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
                    _maxsecu = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
                End If
                numsecu.Maximum = _maxsecu
                numsecu.Minimum = _minsecu
                _indicesecu = _maxsecu
                avanzar(_indicesecu)
                cargar_datos()
            End If
        Else
            'txtResult.Text = "Cancelled"
        End If
        cambiarRuta.Dispose()
    End Sub
    Public Function caso_sSolidario(ByVal consumo As Integer, ByVal nope As Integer, ByVal cargoFijo As Double, ByVal form As Double) As Double
        Dim cns As Integer
        Dim cnsol As Integer
        Dim total As Double

        cns = consumo
        cnsol = nope * 4.5

        If cnsol <= cns Then
            total = cargoFijo + ((cnsol * 1.78) + ((cns - cnsol) * 2.54)) + form
        Else
            total = cargoFijo + (cnsol * 1.78) + form
        End If
        Return (total)
    End Function
    Public Function caso_edificios(ByVal cconsumo As Double, ByVal nuvi As Integer, ByVal cargoFijo As Double, ByVal form As Double) As Double
        Dim usr_nuvi As Integer
        Dim calculo As Double
        usr_nuvi = nuvi
        'calculo = (consumo * tarifa) + (cargoFijo * usr_nuvi) + form
        calculo = cconsumo + (cargoFijo * usr_nuvi) + form
        Return (calculo)

    End Function

    Private Sub MenuBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBusqueda.Click
        Dim buscarRegistro As New frmBuscarRegistro

        ' Show testDialog as a modal dialog and determine if DialogResult = OK.
        If buscarRegistro.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' Read the contents of testDialog's TextBox.
            If _secubuscado = -1 Then
            Else
                avanzar(_secubuscado)
                cargar_datos()
                'aumentado
                _secubuscado = -1
            End If
        Else
            'txtResult.Text = "Cancelled"
        End If
        buscarRegistro.Dispose()

    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPendientes.Click

        Dim tpendiente As Integer

        'calculando pendientes...
        If _modouso = "OFFLINE" Then
            dtavance = ver_avance(_idusuario)
            dttotal = dame_totalitems(_idusuario)
        Else
            dtavance = servicio.ver_avance(_idusuario, _SQLruta)
            dttotal = servicio.dame_totalitems(_idusuario, _SQLruta)
        End If
        tpendiente = dttotal.Rows(0)("total") - dtavance.Rows(0)("total")
        If tpendiente = 0 Then
            MessageBox.Show("Ud. no tiene pendientes!")
            _SQLestadoreg = ""
            mnuPendientes.Checked = False
            mnuTodos.Checked = True
        Else
            _SQLestadoreg = " AND planillaitems.reglectura_idreglectura=0"
            mnuPendientes.Checked = True
            mnuTodos.Checked = False
            If _anterior = _siguiente Then
                numsecu.Maximum = _siguiente
                numsecu.Minimum = _anterior
                _indicesecu = _anterior
            Else
                If _modouso = "OFFLINE" Then
                    _minsecu = planillaitems_min(_idusuario)
                    _maxsecu = planillaitems_max(_idusuario)
                Else
                    _minsecu = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
                    _maxsecu = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
                End If
                numsecu.Maximum = _maxsecu
                numsecu.Minimum = _minsecu
                _indicesecu = _minsecu
            End If
            avanzar(_indicesecu)
            cargar_datos()
        End If

    End Sub

    Private Sub mnuTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTodos.Click
        Dim ultimoreg As Integer
        _SQLestadoreg = ""
        mnuPendientes.Checked = False
        mnuTodos.Checked = True
        If _modouso = "OFFLINE" Then
            _minsecu = planillaitems_min(_idusuario)
            _maxsecu = planillaitems_max(_idusuario)
            ultimoreg = dame_secuenciaUltimoRegistro()
        Else
            _minsecu = servicio.planillaitems_min(_idusuario, _SQLruta, _SQLestadoreg)
            _maxsecu = servicio.planillaitems_max(_idusuario, _SQLruta, _SQLestadoreg)
            ultimoreg = servicio.dame_secuenciaUltimoRegistro(_SQLruta, _SQLestadoreg)
        End If
        numsecu.Maximum = _maxsecu
        numsecu.Minimum = _minsecu
        '_indicesecu = _minsecu
        If ultimoreg = -1 Then
            _indicesecu = _minsecu
        Else
            _indicesecu = ultimoreg
        End If
        avanzar(_indicesecu)
        cargar_datos()
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub txtManzano_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManzano.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        Dim indiceBuscado As Integer
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            'MessageBox.Show("Enter key BUSCANDO manzano")
            indiceBuscado = buscarRegistro_Manzano(txtManzano.Text)
            If indiceBuscado >= 0 Then
                _indicesecu = indiceBuscado
                avanzar(_indicesecu)
                cargar_datos()
            Else
                MessageBox.Show("No se encontro el manzano solicitado.")
                avanzar(_indicesecu)
                cargar_datos()
            End If
        End If
    End Sub

    Private Sub txtLote_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLote.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        Dim indiceBuscado As Integer
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            'MessageBox.Show("Enter key BUSCANDO manzano")
            indiceBuscado = buscarRegistro_LoteManzano(txtManzano.Text, txtLote.Text)
            If indiceBuscado >= 0 Then
                _indicesecu = indiceBuscado
                avanzar(_indicesecu)
                cargar_datos()
            Else
                MessageBox.Show("No se encontro el lote en el manzano indicado.")
                avanzar(_indicesecu)
                cargar_datos()
            End If
        End If
    End Sub


    Private Sub MenuOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuOnline.Click
        _modouso = "ONLINE"
        Me.Close()
    End Sub

    Private Sub MenuOfline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuOfline.Click
        _modouso = "OFFLINE"
        Me.Close()
    End Sub

    Private Sub mnuFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFoto.Click
        If _modouso = "OFFLINE" Then

            Dim AdjuntarFoto As New frmImagenes
            AdjuntarFoto.Show()
        Else
            MsgBox("Esta opcion, no esta disponible en ONLINE. Requiere FTP")
        End If
    End Sub

    Private Sub mnuEmailPreaviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmailPreaviso.Click
        If _modouso = "OFFLINE" Then
            MsgBox("No disponible esta opcion. CAMBIE A MODO ONLINE", vbInformation, "Informacion")
        Else
            _mailIdcliente = txtCuenta.Text & vbCrLf & "CLIENTE: " & txtCliente.Text & vbCrLf
            _mailNunmed = txtMedidor.Text & vbCrLf & "DIRECCION: " & txtDireccion.Text & vbCrLf
            _mailDetalle = vbCrLf & vbCrLf & "LECTURA ACTUAL: " & txtValor.Text & vbCrLf & "OBS: " & txtObs.Text & vbCrLf & ""

            If txtMeses.Text = "" Then
                _mailObs = "CUENTA AL DIA"
            Else
                Dim _meses As Integer
                _meses = Convert.ToInt64(txtMeses.Text)
                If _meses > 0 Then
                    _mailObs = "CON DEUDA (" & _meses & ") MES(es) "
                End If
            End If
            Dim EnviarCorreo As New frmMailCliente
            EnviarCorreo.Show()
        End If
    End Sub

    Private Sub mnuReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReporte.Click
        Dim frrep As New frmReporte
        frrep.ShowDialog()
    End Sub

    Private Sub btnElegirObs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElegirObs.Click
        If _modouso = "OFFLINE" Then
            Dim buscarObs As New frmBuscarObs

            ' Show testDialog as a modal dialog and determine if DialogResult = OK.
            If buscarObs.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ' Read the contents of testDialog's TextBox.
                If _idObsBuscado = -1 Then
                Else
                    numericObs.Value = _idObsBuscado
                    'aumentado
                    _idObsBuscado = -1
                End If
            Else
                'txtResult.Text = "Cancelled"
            End If
            buscarObs.Dispose()
        Else
            MsgBox("Esta opcion, no esta disponible en ONLINE")
        End If
    End Sub

    Private Sub mnuVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVersion.Click
        MsgBox(_version, vbOK, "Informacion del sistema")
    End Sub

    Private Sub escribirLog(ByVal texto As String)

        'If Not VLman_arch.FolderExists("RUTA DE LA CARPETA") Then
        '    codigo eliminado en la version
        'End If

        Dim sw As StreamWriter
        Dim _fileLogName As String
        Dim filenameLOG As String
        _fileLogName = "log"
        filenameLOG = _fileLogName & ".txt"
        Dim Path As String
        Path = "\Storage Card\" & filenameLOG
        If File.Exists(Path) = True Then
            MessageBox.Show("Grabado en memoria")
            sw = New StreamWriter(Path)
            sw.WriteLine("Lectura: " & texto)
            sw.Close()

        Else
            'File.Create(Path)
            ' Creando el archivo log...
            sw = File.CreateText(Path)
            sw.WriteLine("Hello")
            sw.WriteLine("Nuevo")
            sw.WriteLine("archivo LOG del sistema de lectura")
            sw.Flush()
            sw.Close()
            MessageBox.Show("Grabado en memoria")
        End If
    End Sub

    Private Sub btnPboxFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPboxFoto.Click
        If _modouso = "OFFLINE" Then

            Dim AdjuntarFoto As New frmImagenes
            AdjuntarFoto.Show()
        Else
            MsgBox("Esta opcion, no esta disponible en ONLINE. Requiere FTP")
        End If
    End Sub

    Private Sub MenuOpiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuOpiones.Click

    End Sub
End Class