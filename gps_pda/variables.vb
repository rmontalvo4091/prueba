Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.IO.Ports

Module variables
    'cadena conexion
    Public sqlConn As System.Data.SqlServerCe.SqlCeConnection
    Public ruta As String = "Data Source='My Documents\planillaSELA.sdf'" 'ubicacion por defecto.
    Public _ciclo As String
    Public _sector As Integer
    Public _ruta As String
    Public _secubuscado As Integer
    Public _idObsBuscado As Integer
    Public _nhojas As Integer
    Public _idfoto As Integer
    Public _version As String
    Public C As String = "170F"
    Public _mailTo, _mailIdcliente, _mailNunmed, _mailDetalle, _mailObs As String
    Public Function ceros(ByVal Nro As String, ByVal Cantidad As Integer) As String
        Dim numero As String, cuantos As String, i As Integer
        numero = Trim(Nro) 'Trim quita los espacion en blanco 
        cuantos = "0"
        For i = 1 To Cantidad
            cuantos = cuantos & "0"
        Next i
        ceros = Mid(cuantos, 1, Cantidad - Len(numero)) & numero
    End Function
    Public Sub verModo(ByVal modo As TextBox)
        modo.Text = _modouso
    End Sub


#Region "usuarios"
    Public _nombre As String
    Public _clave As String
    Public _pin As String
    Public _idusuario As String
    Public _rol As Integer
    Public O As String = "AA90"

    Public Function dame_usuarios(ByVal usuario As String) As DataSet
        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter("Select * from usuario" & " where usuario_nombre like  '%" & usuario & "%'", sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()
    End Function
    Public Function dame_pin(ByVal pin As String) As DataSet
        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter("Select * from usuario" & " where usuario_pin=  '" & pin & "'", sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()
    End Function
    Public Function dame_login(ByVal pin As String) As DataSet
        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter("Select * from usuario" & " where usuario_pin=  '" & pin & "'", sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()
    End Function
    Public Function nuevo_usuario(ByVal nombre As String, ByVal clave As String, ByVal pin As String) As Integer
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "INSERT INTO usuario (usuario_nombre,usuario_clave,usuario_pin) VALUES ('" & nombre & "'" & ", " & "'" & clave & "'" & ", " & "'" & pin & "')"

        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If

        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function

    Public Function editar_usuario(ByVal idusuario As Integer, ByVal nombre As String, ByVal clave As String, ByVal pin As String) As Integer
        'insertamos datos
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "Update usuario SET usuario_nombre= '" & nombre & "'" & " ,usuario_clave= '" & clave & "'" & " ,usuario_pin= '" & pin & "'" & " where idusuario=  '" & idusuario & "'"

        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function
    Public Function eliminar_usuario(ByVal idusuario As Integer) As Integer

        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "delete from usuario where idusuario = '" & idusuario & "'"
        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()

    End Function

    Function encryptar(ByVal input As String) As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function
#End Region

#Region "Registro"

    Public Function nuevo_registro(ByVal codcliente As String, ByVal codigoubicacion As String) As Integer
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "INSERT INTO registro (codcliente,codigoubicacion) VALUES (@codcliente,@codigoubicacion)"
        cmd.Parameters.Add("@codcliente", SqlDbType.NVarChar)
        cmd.Parameters("@codcliente").Value = codcliente

        cmd.Parameters.Add("@codigoubicacion", SqlDbType.NVarChar)
        cmd.Parameters("@codigoubicacion").Value = codigoubicacion

        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If

        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function


    Public Function eliminar_registros() As Integer

        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "delete from registro"
        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()

    End Function
#End Region

#Region "Envio Correo"
    Public _correo_envio As String
    Public E As String = "D82D"
#End Region

#Region "planilla"

    'variables para registro lecturas
    Public _idmedidor As String
    Public _cliente As String
    Public _direccion As String
    Public _idplanilla As Integer
    Public _idcliente As Integer
    Public _idpredio As String





    Public Function predios_asignados() As DataSet

        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        ' sqlDA = New SqlServerCe.SqlCeDataAdapter("SELECT  cliente_idcliente, predio_idpredio, medidor_idmedidor, planilla_medidor_nombrecliente, planilla_medidor_direccion, preaviso_cobro_idpreaviso FROM  planilla_medidor" & " where planilla_idplanilla=  '" & idplanilla & "'", sqlConn)
        sqlDA = New SqlServerCe.SqlCeDataAdapter("SELECT m.cliente_idcliente, m.predio_idpredio, m.medidor_idmedidor, m.planilla_medidor_nombrecliente, m.planilla_medidor_direccion, m.preaviso_cobro_idpreaviso, m.reglectura_idreglectura,  CASE reglectura_idreglectura WHEN '0' THEN 'PENDIENTE' WHEN '' THEN 'PENDIENTE' ELSE 'PROCESADO' END AS Estado, r.reglectura_valor, r.idtlectura, r.reglectura_obs_detalle  FROM            planilla_medidor AS m LEFT OUTER JOIN reglectura AS r ON m.reglectura_idreglectura = r.idreglectura", sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()

    End Function
    Public Function planilla_asignada(ByVal idusuario As Integer) As DataTable
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter("SELECT * from planilla" & " where idusuario=  '" & idusuario & "'", sqlConn)
        sqlDA.Fill(sqlDT)
        Return (sqlDT)
        sqlConn.Close()
    End Function

    Public Sub cargar_Combo(ByVal ComboBox As ComboBox, ByVal sql As String)

        ''Dim sSQL As String = "SELECT * FROM usuarios"
        'Dim comm As SqlCommand = New SqlCommand(sql, New SqlConnection(ruta))
        'Dim Da As SqlDataAdapter = New SqlDataAdapter(comm)
        'Dim dt As DataTable = New DataTable()
        'Da.Fill(dt)

        'ComboBox.DataSource = dt

        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter(sql, sqlConn)
        sqlDA.Fill(sqlDT)

        ComboBox.DataSource = sqlDT


        ' Asignar el campo a la propiedad DisplayMember del combo 
        ComboBox.DisplayMember = sqlDT.Columns(1).Caption.ToString
        ComboBox.ValueMember = sqlDT.Columns(0).Caption.ToString

        sqlConn.Close()

    End Sub


    Public Function update_planilla_medidor(ByVal idcliente As Integer, ByVal idmedidor As String, ByVal idpredio As String, ByVal idlectura As String) As Integer
        'insertamos datos
        'sqlConn = New SqlServerCe.SqlCeConnection(conection)
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "Update planilla_medidor SET reglectura_idreglectura= '" & idlectura & "'" & " where cliente_idcliente =  '" & idcliente & "'" & " and" & " predio_idpredio = '" & idpredio & "'" & " and" & " medidor_idmedidor = '" & idmedidor & "'"

        Dim m As Integer

        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function

#End Region
#Region "planilla items"
    'variables para registro lecturas
    Public _nummedidor As String
    Public _nomcliente As String
    Public _direccioninmueble As String
    Public _idplanillauser As Integer
    Public _cuenta As Integer
    Public _minsecu As Integer
    Public _maxsecu As Integer
    Public _anterior As Integer
    Public _siguiente As Integer
    Public _indicesecu As Integer
    Public _SQLruta As String
    Public _SQLestadoreg As String
    Public Function convertir(ByVal texto As String) As Integer
        Dim _valor As Integer
        If texto <> "" Then
            _valor = Convert.ToInt64(texto)
        Else
            _valor = 0
        End If
        Return _valor
    End Function
    Public Function planilla_listar_rutas(ByVal idusuario As Integer) As DataSet
        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT DISTINCT usr_cicl, REPLACE(STR(usr_sect, 3), SPACE(1), '0') AS usr_sect, usr_ruta" & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "'" '& " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()
    End Function
    Public Function buscarRegistro_porCuenta(ByVal texto As String) As DataSet
        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT usr_manz as manz,usr_rloc as lote, usr_sloc as ubic,usr_secu as secu, CAST(usr_matr AS nchar) + CAST(usr_dive AS nchar) AS cuenta, usr_apno as nombre, usr_dirr as direccion, usr_numm as medidor FROM planillaitems" & " WHERE (CAST(usr_matr AS nchar) + CAST(usr_dive AS nchar) LIKE '%" & texto & "%')" & _SQLruta & _SQLestadoreg  '& " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()
    End Function
    Public Function buscarRegistro_por(ByVal campo As String, ByVal texto As String) As DataSet
        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT usr_manz as manz,usr_rloc as lote, usr_sloc as ubic,usr_secu as secu, CAST(usr_matr AS nchar) + CAST(usr_dive AS nchar) AS cuenta, usr_apno as nombre, usr_dirr as direccion, usr_numm as medidor FROM planillaitems" & " WHERE " & campo & " LIKE '" & texto & "'" & _SQLruta & _SQLestadoreg  '& " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()
    End Function
    Public Function buscarRegistro_Manzano(ByVal manzano As String) As Integer
        Dim sqlDS = New DataSet
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT TOP(1) usr_secu FROM planillaitems" & " WHERE usr_manz=" & Convert.ToInt32(manzano) & _SQLruta & _SQLestadoreg & " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim indiceBuscado As Integer
        'sig = sqlDT.Rows(0)("usr_secu")
        If sqlDT.Rows.Count > 0 Then
            indiceBuscado = sqlDT.Rows(0)("usr_secu")
        Else
            indiceBuscado = -1
        End If
        sqlConn.Close()
        Return (indiceBuscado)
    End Function
    Public Function buscarRegistro_LoteManzano(ByVal manzano As String, ByVal lote As String) As Integer
        Dim sqlDS = New DataSet
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT TOP(1) usr_secu FROM planillaitems" & " WHERE usr_manz=" & Convert.ToInt32(manzano) & " AND usr_rloc=" & Convert.ToInt32(lote) & _SQLruta & _SQLestadoreg & " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim indiceBuscado As Integer
        'sig = sqlDT.Rows(0)("usr_secu")
        If sqlDT.Rows.Count > 0 Then
            indiceBuscado = sqlDT.Rows(0)("usr_secu")
        Else
            indiceBuscado = -1
        End If
        sqlConn.Close()
        Return (indiceBuscado)
    End Function
    Public Function dame_categoriaNombre(ByVal idcat As Integer) As String
        Dim sqlDS = New DataSet
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT TOP(1) categoria_nomsigla FROM categoria" & " WHERE 	idcategoria=" & idcat '& _SQLruta & _SQLestadoreg '& " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim cateBuscado As String
        'sig = sqlDT.Rows(0)("usr_secu")
        If sqlDT.Rows.Count > 0 Then
            cateBuscado = sqlDT.Rows(0)("categoria_nomsigla")
        Else
            cateBuscado = "-1"
        End If
        sqlConn.Close()
        Return (cateBuscado)
    End Function

    Public Function planilla_asignada_listar(ByVal idusuario As Integer) As DataSet

        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT planilla_mes, planilla_gestion, planillaitems.*" & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "'" & " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        Return (sqlDS)
        sqlConn.Close()

    End Function
    Public Function planillaitems_min(ByVal idusuario As Integer) As Integer
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT MIN(usr_secu) AS min_usr_secu" & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "'" & _SQLruta & _SQLestadoreg
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim min As Integer
        If sqlDT.Rows.Count > 0 Then
            min = sqlDT.Rows(0)("min_usr_secu")
        Else
            min = -1
        End If
        sqlConn.Close()
        Return (min)
    End Function
    Public Function planillaitems_max(ByVal idusuario As Integer) As Integer
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT MAX(usr_secu) AS max_usr_secu" & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "'" & _SQLruta & _SQLestadoreg
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim max As Integer
        If sqlDT.Rows.Count > 0 Then
            max = sqlDT.Rows(0)("max_usr_secu")
        Else
            max = -1
        End If
        sqlConn.Close()
        Return (max)
    End Function
    Public Function planillaitems_sig(ByVal idusuario As Integer, ByVal indice As Integer) As Integer
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT TOP(1) usr_secu " & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "' AND usr_secu>" & indice & _SQLruta & _SQLestadoreg & " ORDER BY usr_secu ASC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim sig As Integer
        'sig = sqlDT.Rows(0)("usr_secu")
        If sqlDT.Rows.Count > 0 Then
            sig = sqlDT.Rows(0)("usr_secu")
        Else
            sig = indice
        End If
        sqlConn.Close()
        Return (sig)
    End Function
    Public Function planillaitems_ant(ByVal idusuario As Integer, ByVal indice As Integer) As Integer
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT TOP(1) usr_secu " & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "' AND usr_secu<" & indice & _SQLruta & _SQLestadoreg & " ORDER BY usr_secu DESC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim ant As Integer
        If sqlDT.Rows.Count > 0 Then
            ant = sqlDT.Rows(0)("usr_secu")
        Else
            ant = indice
        End If
        sqlConn.Close()
        Return (ant)
    End Function
    Public Function dame_secuenciaUltimoRegistro() As Integer
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT TOP (1) usr_secu FROM planillaitems, reglectura WHERE planillaitems.reglectura_idreglectura=reglectura.idreglectura " & _SQLruta & _SQLestadoreg & " ORDER BY reglectura_fecha DESC"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Dim ultimo As Integer
        If sqlDT.Rows.Count > 0 Then
            ultimo = sqlDT.Rows(0)("usr_secu")
        Else
            ultimo = -1
        End If
        sqlConn.Close()
        Return (ultimo)
    End Function
    Public Sub planillaindice(ByVal idusuario As Integer, ByVal _indice As Integer)
        _indicesecu = _indice
        If _indicesecu = 0 Then
            _indicesecu = _minsecu
            _anterior = 0
            _siguiente = planillaitems_sig(_idusuario, _indicesecu)
        Else
            If _indicesecu <= _minsecu Then
                _indicesecu = _minsecu
                _anterior = _minsecu '0
                _siguiente = planillaitems_sig(_idusuario, _indicesecu)
            ElseIf _indicesecu >= _maxsecu Then
                _indicesecu = _maxsecu
                _anterior = planillaitems_ant(_idusuario, _indicesecu)
                _siguiente = _maxsecu '0
            ElseIf (_indicesecu > _minsecu And _indicesecu < _maxsecu) Then
                _anterior = planillaitems_ant(_idusuario, _indicesecu)
                _siguiente = planillaitems_sig(_idusuario, _indicesecu)
            End If
        End If
    End Sub
    Public Function planilla_datos(ByVal idusuario As Integer) As DataTable
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT planilla_mes, planilla_gestion" & " FROM planilla" & " WHERE usuario_idusuario='" & idusuario & "'"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Return (sqlDT)
        sqlConn.Close()
    End Function
    Public Function planillaitem(ByVal idusuario As Integer, ByVal secu As Integer) As DataTable
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT planillaitems.*" & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "' AND usr_secu='" & secu & "'" & _SQLruta & _SQLestadoreg
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDT)
        Return (sqlDT)
        sqlConn.Close()
    End Function

    Public Function dame_tarifa(ByVal idcate As Integer) As DataTable

        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            _SQL = "SELECT * " & " FROM tarifas" & " WHERE tarifas_mes='" & planilla_datos(_idusuario).Rows(0)("planilla_mes") & "'" & " AND tarifas_gestion='" & planilla_datos(_idusuario).Rows(0)("planilla_gestion") & "'" & " AND tarifas_categoria=" & idcate
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT)
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (sqlDT)
    End Function
    Public Function dame_obs(ByVal idobs As Integer) As DataTable

        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            _SQL = "SELECT * " & " FROM obs" & " WHERE idobs='" & idobs & "'"
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT)
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (sqlDT)
    End Function
    Public Function dame_idObs(ByVal txtObs As String) As DataSet

        Dim sqlDS = New DataSet
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        _SQL = "SELECT idobs, obs_desc " & " FROM obs" & " WHERE obs_desc LIKE '%" & txtObs & "%'"
        sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
        sqlDA.Fill(sqlDS, "Sini")
        sqlConn.Close()
        Return (sqlDS)

    End Function
    Public Function dame_sitiocaja(ByVal idsitiocaja As Integer) As DataTable

        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            _SQL = "SELECT * " & " FROM sitiocaja" & " WHERE idsitiocaja='" & idsitiocaja & "'"
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT)
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (sqlDT)
    End Function
    Public Function ver_avance(ByVal idusuario As Integer) As DataTable

        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            _SQL = "SELECT COUNT(*) AS total " & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "' AND reglectura_idreglectura>0" & _SQLruta
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT)
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (sqlDT)
    End Function
    Public Function dame_totalitems(ByVal idusuario As Integer) As DataTable

        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            _SQL = "SELECT COUNT(*) AS total " & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND usuario_idusuario='" & idusuario & "'" & _SQLruta
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT)
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (sqlDT)
    End Function
    Public Sub cargar_Combo2(ByVal ComboBox As ComboBox, ByVal sql As String)

        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter(sql, sqlConn)
        sqlDA.Fill(sqlDT)

        ComboBox.DataSource = sqlDT
        ComboBox.DisplayMember = sqlDT.Columns(1).Caption.ToString
        ComboBox.ValueMember = sqlDT.Columns(0).Caption.ToString

        sqlConn.Close()

    End Sub


    Public Function update_planillaitems_reglectura(ByVal indicesecu As String, ByVal idlectura As Integer) As Integer
        'insertamos datos
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "Update planillaitems SET reglectura_idreglectura='" & idlectura & "'" & " where usr_secu='" & indicesecu & "'" & _SQLruta

        Dim m As Integer

        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function
    Public Function dame_planillaitems_impresion(ByVal indicesecu As String, ByVal idlectura As Integer) As Integer
        'iobtenemos valor del contador
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Dim contador As Integer
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            '_SQL = "SELECT usr_impr AS total" & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla AND reglectura_idreglectura='" & idlectura & "'" & " AND usr_secu='" & indicesecu & "'" & _SQLruta
            _SQL = "SELECT usr_impr AS total" & " FROM planilla, planillaitems" & " WHERE planilla.idplanilla=planillaitems.planilla_idplanilla " & " AND usr_secu='" & indicesecu & "'" & _SQLruta
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT)
            If sqlDT.Rows.Count > 0 Then
                contador = sqlDT.Rows(0)("total")
            Else
                contador = -1
            End If
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (contador)
    End Function
    Public Function update_planillaitems_impresion(ByVal indicesecu As String, ByVal idlectura As Integer) As Integer
        'insertamos conteo de impresion
        Dim cmd As New SqlServerCe.SqlCeCommand
        Dim i As Integer
        i = dame_planillaitems_impresion(indicesecu, idlectura)
        i = i + 1 'incrementando la impresion
        cmd.CommandType = System.Data.CommandType.Text
        'cmd.CommandText = "UPDATE planillaitems SET usr_impr='" & i & "'" & " WHERE reglectura_idreglectura='" & idlectura & "' AND usr_secu='" & indicesecu & "'" & _SQLruta
        cmd.CommandText = "UPDATE planillaitems SET usr_impr='" & i & "'" & " WHERE " & " usr_secu='" & indicesecu & "'" & _SQLruta
        Dim m As Integer

        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function
#End Region
#Region "Registro Lecturas"
    Public _valorlectura As Integer
    Public _observ As String
    Public _idtlectura As String
    Public _idreglectura As String


    Public Function update_reglectura(ByVal idreglectura As String, ByVal valor As Integer, ByVal observ As String, ByVal latitud_mod As Double, ByVal longitud_mod As Double, ByVal fecha_mod As Date) As Integer
        'insertamos datos
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        '
        cmd.CommandText = "Update reglectura SET reglectura_valor= '" & valor & "'," & " reglectura_obs_detalle = '" & observ & "'," & " reglectura_gps_latitud_mod  = '" & latitud_mod & "'," & " reglectura_gps_longitud_mod = '" & longitud_mod & "'," & " reglectura_fecha_mod = '" & fecha_mod & "'" & " where idreglectura =  '" & idreglectura & "'"
        Dim m As Integer

        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function
    Public Function insert_reglectura(ByVal idreglectura As String, ByVal reglectura_valor As Integer, ByVal reglectura_fecha As Date, ByVal reglectura_gps_latitud As Double, ByVal reglectura_gps_longitud As Double, ByVal idtlectura As String, ByVal idusuario As Integer, ByVal reglectura_obs_detalle As String) As Integer
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "INSERT INTO reglectura (idreglectura, reglectura_valor, reglectura_fecha, reglectura_gps_latitud, reglectura_gps_longitud, idtlectura, idusuario, reglectura_obs_detalle) VALUES (@idreglectura, @reglectura_valor, @reglectura_fecha, @reglectura_gps_latitud, @reglectura_gps_longitud, @idtlectura, @idusuario, @reglectura_obs_detalle)"
        cmd.Parameters.Add("@idreglectura", SqlDbType.NVarChar).Value = idreglectura
        cmd.Parameters.Add("@reglectura_valor", SqlDbType.Decimal).Value = reglectura_valor
        cmd.Parameters.Add("@reglectura_fecha", SqlDbType.DateTime).Value = reglectura_fecha
        cmd.Parameters.Add("@reglectura_gps_latitud", SqlDbType.Decimal).Value = reglectura_gps_latitud
        cmd.Parameters.Add("@reglectura_gps_longitud", SqlDbType.Decimal).Value = reglectura_gps_longitud
        cmd.Parameters.Add("@idtlectura", SqlDbType.NVarChar).Value = idtlectura
        cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = idusuario
        cmd.Parameters.Add("@reglectura_obs_detalle", SqlDbType.NVarChar).Value = reglectura_obs_detalle

        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If

        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function
#End Region

#Region "Registro Lecturas en Secuencia"
    Public _valorlecturasecu As Integer
    Public _observsecu As String
    Public _idobssecu As String
    Public _idreglecturasecu As String

    Public Function update_reglecturasecu(ByVal idreglectura As String, ByVal valor As Integer, ByVal idobs As Integer, ByVal observ As String, ByVal latitud_mod As Double, ByVal longitud_mod As Double, ByVal fecha_mod As DateTime) As Integer
        'insertamos datos
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text

        cmd.CommandText = "Update reglectura SET reglectura_valor= '" & valor & "'," & " obs_idobs='" & idobs & "'," & " reglectura_obs_detalle = '" & observ & "'," & " reglectura_gps_latitud  = '" & latitud_mod & "'," & " reglectura_gps_longitud = '" & longitud_mod & "'," & " reglectura_fecha = @reglectura_fecha" & " where idreglectura =  '" & idreglectura & "'"
        cmd.Parameters.Add("@reglectura_fecha", SqlDbType.DateTime).Value = fecha_mod

        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If
        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function
    Public Function insert_reglecturasecu(ByVal idreglectura As Integer, ByVal reglectura_valor As Integer, ByVal reglectura_fecha As Date, ByVal reglectura_gps_latitud As Double, ByVal reglectura_gps_longitud As Double, ByVal obs_idobs As Integer, ByVal reglectura_obs_detalle As String, ByVal tlectura_idtlectura As String, ByVal usuario_idusuario As Integer) As Integer
        Dim cmd As New SqlServerCe.SqlCeCommand
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "INSERT INTO reglectura (idreglectura, reglectura_valor, reglectura_fecha, reglectura_gps_latitud, reglectura_gps_longitud, obs_idobs, reglectura_obs_detalle, tlectura_idtlectura, usuario_idusuario) VALUES (@idreglectura, @reglectura_valor, @reglectura_fecha, @reglectura_gps_latitud, @reglectura_gps_longitud, @obs_idobs, @reglectura_obs_detalle, @tlectura_idtlectura, @usuario_idusuario)"
        cmd.Parameters.Add("@idreglectura", SqlDbType.Int).Value = idreglectura
        cmd.Parameters.Add("@reglectura_valor", SqlDbType.Int).Value = reglectura_valor
        cmd.Parameters.Add("@reglectura_fecha", SqlDbType.DateTime).Value = reglectura_fecha
        cmd.Parameters.Add("@reglectura_gps_latitud", SqlDbType.Decimal).Value = reglectura_gps_latitud
        cmd.Parameters.Add("@reglectura_gps_longitud", SqlDbType.Decimal).Value = reglectura_gps_longitud
        cmd.Parameters.Add("@obs_idobs", SqlDbType.Int).Value = obs_idobs
        cmd.Parameters.Add("@reglectura_obs_detalle", SqlDbType.NText).Value = reglectura_obs_detalle
        cmd.Parameters.Add("@tlectura_idtlectura", SqlDbType.NVarChar).Value = tlectura_idtlectura
        cmd.Parameters.Add("@usuario_idusuario", SqlDbType.Int).Value = usuario_idusuario


        Dim m As Integer
        cmd.Connection = sqlConn
        If sqlConn.State = ConnectionState.Closed Then
            sqlConn.Open()
        End If

        m = cmd.ExecuteNonQuery()
        If m > 0 Then
            Return 1
        Else
            Return 0
        End If
        sqlConn.Close()
    End Function
    Public Function dame_registrolectura(ByVal idusuario As Integer, ByVal secu As Integer) As DataTable
        Dim sqlDT2 = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            _SQL = "SELECT reglectura.*" & " FROM reglectura, planillaitems" & " WHERE planillaitems.reglectura_idreglectura=reglectura.idreglectura AND usuario_idusuario='" & idusuario & "' AND usr_secu='" & secu & "' ORDER BY usr_secu ASC"
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT2)
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (sqlDT2)
    End Function
    Public Function dame_registrolecturaById(ByVal idreglectura As Integer) As DataTable
        Dim sqlDT2 = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        Dim _SQL As String
        Try
            sqlConn = New SqlServerCe.SqlCeConnection(ruta)
            sqlConn.Open()
            _SQL = "SELECT reglectura.*" & " FROM reglectura" & " WHERE idreglectura='" & idreglectura & "'"
            sqlDA = New SqlServerCe.SqlCeDataAdapter(_SQL, sqlConn)
            sqlDA.Fill(sqlDT2)
            sqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return (sqlDT2)
    End Function
#End Region
#Region "GPS"
    Dim puertoserie As New SerialPort
    Public D As String = "E0B2"
    Public Function hallar_posicion() As ArrayList
        Dim ItemList As New ArrayList()
        Try
            puertoserie.PortName = "COM6"
            puertoserie.Parity = Parity.None
            puertoserie.StopBits = StopBits.One
            puertoserie.DataBits = 8
            puertoserie.BaudRate = 4800
            puertoserie.Open()

            Dim data As String = leerPuertoSerie()
            Dim strArr() As String = data.Split("$")
            Dim i As Integer = 0
            If strArr.Length > 1 Then
                Try
                    'For i = 1 To strArr.Length
                    For i = 1 To 1
                        Dim strTemp As String = strArr(i)

                        Dim lineArr() As String = strTemp.Split(",")

                        If (lineArr(0) = "GPGGA") Then
                            Try

                                ' Latitude
                                Dim dLat As Double = Convert.ToDouble(lineArr(2))


                                Dim PosDb As Double = CType(Replace(lineArr(2), ".", ","), Double) 'Replace . with , (Used in danish doubles)
                                Dim Deg As Double = Math.Floor(PosDb / 100)
                                Dim DecPos As Double = Math.Round(Deg + ((PosDb - (Deg * 100)) / 60), 5)

                                ItemList.Add(DecPos * -1)

                                ' longitud
                                Dim PosDb2 As Double = CType(Replace(lineArr(4), ".", ","), Double) 'Replace . with , (Used in danish doubles)
                                Dim Deg2 As Double = Math.Floor(PosDb2 / 100)
                                Dim DecPos2 As Double = Math.Round(Deg2 + ((PosDb2 - (Deg2 * 100)) / 60), 5)

                                ItemList.Add(DecPos2 * -1)

                                'resultado
                                Return ItemList

                            Catch
                                ItemList.Add(2)
                            End Try
                        End If

                    Next

                Catch
                    'do nothing
                End Try

            End If

        Catch ex As Exception
            ItemList.Add(2)
            Return ItemList
        End Try
    End Function
    Public Function leerPuertoSerie() As String
        Try
            If puertoserie.IsOpen Then

                Dim bData As Byte() = Nothing
                Dim numberOfBytes As Integer = 256

                bData = New Byte(numberOfBytes - 1) {}

                puertoserie.Read(bData, 0, numberOfBytes)
                puertoserie.DiscardInBuffer()

                Return System.Text.Encoding.UTF8.GetString(bData, 0, numberOfBytes)
            Else
                Return ""
            End If
        Catch Ex As Exception
            Return ""
        End Try
    End Function


#End Region

#Region "Preaviso"
    Public _idpreaviso As Integer
    Public Function ver_preaviso(ByVal idpreaviso As Integer) As DataTable
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter("  SELECT m.planilla_idplanilla, m.cliente_idcliente, m.predio_idpredio, m.medidor_idmedidor, m.manzano_idmanzano, m.ciclo_idciclo, m.sector_idsector, m.ruta_idruta, m.reglectura_idreglectura,   m.preaviso_cobro_idpreaviso, m.planilla_medidor_nombrecliente, m.planilla_medidor_direccion, p.idpreaviso_cobro, p.preaviso_numero, p.preaviso_fechaemision, p.preaviso_fechacorte,   p.preaviso_numerodeudas, p.preaviso_totaldeuda, p.preaviso_impreso, p.preaviso_lectanterior, p.preaviso_fechanterior, p.preaviso_lectactual, p.preaviso_fechactual, p.preaviso_totalservicio,  p.preaviso_totalpagar, p.idmedidor FROM  planilla_medidor AS m LEFT OUTER JOIN preaviso_cobro AS p ON m.preaviso_cobro_idpreaviso = p.idpreaviso_cobro" & " where p.idpreaviso_cobro =  '" & idpreaviso & "'", sqlConn)
        sqlDA.Fill(sqlDT)
        Return (sqlDT)
        sqlConn.Close()
    End Function
    Public Function ver_historico(ByVal idpreaviso As Integer) As DataTable
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter("   SELECT h.* FROM    preaviso_cobro AS p INNER JOIN   historico_consumo AS h ON p.idpreaviso_cobro = h.idpreaviso_cobro " & " where p.idpreaviso_cobro =  '" & idpreaviso & "'", sqlConn)
        sqlDA.Fill(sqlDT)
        Return (sqlDT)
        sqlConn.Close()
    End Function
    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                       Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = UCase(palabras & "Y " & dec & "/100 BOLIVIANOS")
            Else
                Letras = UCase(palabras) & "Y " & "00/100 BOLIVIANOS"
            End If
        Else
            Letras = ""
        End If
    End Function
    Public Function isLecturaCeroConObs(ByVal lectura As Integer, ByVal numericObs As Integer) As Boolean
        'CASO de lectura en CERO o existe una observacion registrada
        Dim listaObs() As Integer = {2, 3, 7, 14, 21, 28, 31, 33, 42}
        Dim imprimirObs As Boolean = False
        Dim num As Integer
        If lectura = 0 And numericObs > 0 Then

            For Each num In listaObs
                If num = numericObs Then
                    imprimirObs = True
                End If
            Next
        End If
        Return imprimirObs
    End Function

#End Region

#Region "Reporte"
    Public Function dame_avance() As DataTable
        Dim sqlDT = New DataTable
        Dim sqlDA = New SqlServerCe.SqlCeDataAdapter
        sqlConn = New SqlServerCe.SqlCeConnection(ruta)
        sqlConn.Open()
        sqlDA = New SqlServerCe.SqlCeDataAdapter("SELECT        COUNT(p.medidor_idmedidor) AS total_reg, COUNT(r.idreglectura) AS total_avanz  FROM            planilla_medidor AS p LEFT OUTER JOIN    reglectura AS r ON p.reglectura_idreglectura = r.idreglectura", sqlConn)
        sqlDA.Fill(sqlDT)
        Return (sqlDT)
        sqlConn.Close()
    End Function
#End Region

#Region "Online"
    Public _modouso As String
    Public servicio As New webPda.consult 'webLectura.consult
#End Region
#Region "End"




#End Region
End Module
