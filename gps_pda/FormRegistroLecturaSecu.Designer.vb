<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormRegistroLecturaSecu
    Inherits System.Windows.Forms.Form

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar con el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRegistroLecturaSecu))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuRegresar = New System.Windows.Forms.MenuItem
        Me.MenuOpiones = New System.Windows.Forms.MenuItem
        Me.MenuOnline = New System.Windows.Forms.MenuItem
        Me.MenuOfline = New System.Windows.Forms.MenuItem
        Me.MenuBusqueda = New System.Windows.Forms.MenuItem
        Me.MenuImprimir = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuTodos = New System.Windows.Forms.MenuItem
        Me.mnuPendientes = New System.Windows.Forms.MenuItem
        Me.mnuFoto = New System.Windows.Forms.MenuItem
        Me.mnuEmailPreaviso = New System.Windows.Forms.MenuItem
        Me.mnuReporte = New System.Windows.Forms.MenuItem
        Me.mnuVersion = New System.Windows.Forms.MenuItem
        Me.MenuGrabar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.numsecu = New System.Windows.Forms.NumericUpDown
        Me.labelPeriodo = New System.Windows.Forms.Label
        Me.labelSecuencia = New System.Windows.Forms.Label
        Me.btnAnt1 = New System.Windows.Forms.Button
        Me.btnSig1 = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnAnt2 = New System.Windows.Forms.Button
        Me.btnSig2 = New System.Windows.Forms.Button
        Me.labelAvance = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lblAdjuntos = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.btnPboxFoto = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.numericObs = New System.Windows.Forms.NumericUpDown
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblasterisco = New System.Windows.Forms.Label
        Me.btnElegirObs = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtObservacion = New System.Windows.Forms.TextBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtValor = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.tabconPlanillaItem = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCategoria = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtMedidor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCaja = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtEmp = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtUbicacion = New System.Windows.Forms.TextBox
        Me.txtLote = New System.Windows.Forms.TextBox
        Me.txtManzano = New System.Windows.Forms.TextBox
        Me.txtRuta = New System.Windows.Forms.TextBox
        Me.txtSector = New System.Windows.Forms.TextBox
        Me.txtCiclo = New System.Windows.Forms.TextBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtMeses = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtDeuda = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtMayor = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblcortado = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.txtProm = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtLec4 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtLec5 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtLec6 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtLec1 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtLec2 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtLec3 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.tabconPlanillaItem.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuRegresar)
        Me.mainMenu1.MenuItems.Add(Me.MenuOpiones)
        Me.mainMenu1.MenuItems.Add(Me.MenuGrabar)
        '
        'MenuRegresar
        '
        Me.MenuRegresar.Text = "<-SALIR"
        '
        'MenuOpiones
        '
        Me.MenuOpiones.MenuItems.Add(Me.MenuOnline)
        Me.MenuOpiones.MenuItems.Add(Me.MenuOfline)
        Me.MenuOpiones.MenuItems.Add(Me.MenuBusqueda)
        Me.MenuOpiones.MenuItems.Add(Me.MenuImprimir)
        Me.MenuOpiones.MenuItems.Add(Me.MenuItem1)
        Me.MenuOpiones.MenuItems.Add(Me.mnuTodos)
        Me.MenuOpiones.MenuItems.Add(Me.mnuPendientes)
        Me.MenuOpiones.MenuItems.Add(Me.mnuFoto)
        Me.MenuOpiones.MenuItems.Add(Me.mnuEmailPreaviso)
        Me.MenuOpiones.MenuItems.Add(Me.mnuReporte)
        Me.MenuOpiones.MenuItems.Add(Me.mnuVersion)
        Me.MenuOpiones.Text = "MENU_Opcion"
        '
        'MenuOnline
        '
        Me.MenuOnline.Text = "Modo Online"
        '
        'MenuOfline
        '
        Me.MenuOfline.Checked = True
        Me.MenuOfline.Text = "Modo Local"
        '
        'MenuBusqueda
        '
        Me.MenuBusqueda.Text = "Busqueda"
        '
        'MenuImprimir
        '
        Me.MenuImprimir.Enabled = False
        Me.MenuImprimir.Text = "Imprimir Preaviso"
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Cambiar de Ruta"
        '
        'mnuTodos
        '
        Me.mnuTodos.Checked = True
        Me.mnuTodos.Text = "Mostrar TODOS"
        '
        'mnuPendientes
        '
        Me.mnuPendientes.Text = "Mostrar PENDIENTES"
        '
        'mnuFoto
        '
        Me.mnuFoto.Text = "Adjuntar Foto"
        '
        'mnuEmailPreaviso
        '
        Me.mnuEmailPreaviso.Text = "Notificar Preaviso Email"
        '
        'mnuReporte
        '
        Me.mnuReporte.Text = "Reporte Trabajo"
        '
        'mnuVersion
        '
        Me.mnuVersion.Text = "Version del Sistema Mobil"
        '
        'MenuGrabar
        '
        Me.MenuGrabar.Text = "GUARDAR_Lectura"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.numsecu)
        Me.Panel1.Controls.Add(Me.labelPeriodo)
        Me.Panel1.Controls.Add(Me.labelSecuencia)
        Me.Panel1.Controls.Add(Me.btnAnt1)
        Me.Panel1.Controls.Add(Me.btnSig1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 30)
        '
        'numsecu
        '
        Me.numsecu.Location = New System.Drawing.Point(76, 1)
        Me.numsecu.Name = "numsecu"
        Me.numsecu.Size = New System.Drawing.Size(56, 22)
        Me.numsecu.TabIndex = 1
        '
        'labelPeriodo
        '
        Me.labelPeriodo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.labelPeriodo.ForeColor = System.Drawing.Color.Red
        Me.labelPeriodo.Location = New System.Drawing.Point(132, 5)
        Me.labelPeriodo.Name = "labelPeriodo"
        Me.labelPeriodo.Size = New System.Drawing.Size(55, 20)
        Me.labelPeriodo.Text = "P: 1/2016"
        '
        'labelSecuencia
        '
        Me.labelSecuencia.Location = New System.Drawing.Point(47, 4)
        Me.labelSecuencia.Name = "labelSecuencia"
        Me.labelSecuencia.Size = New System.Drawing.Size(29, 18)
        Me.labelSecuencia.Text = "Scu:"
        '
        'btnAnt1
        '
        Me.btnAnt1.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAnt1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnAnt1.Location = New System.Drawing.Point(0, 0)
        Me.btnAnt1.Name = "btnAnt1"
        Me.btnAnt1.Size = New System.Drawing.Size(45, 30)
        Me.btnAnt1.TabIndex = 20
        Me.btnAnt1.Text = "<Ant."
        '
        'btnSig1
        '
        Me.btnSig1.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSig1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnSig1.Location = New System.Drawing.Point(189, 0)
        Me.btnSig1.Name = "btnSig1"
        Me.btnSig1.Size = New System.Drawing.Size(51, 30)
        Me.btnSig1.TabIndex = 21
        Me.btnSig1.Text = "Sig.>"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAnt2)
        Me.Panel2.Controls.Add(Me.btnSig2)
        Me.Panel2.Controls.Add(Me.labelAvance)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 244)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(240, 24)
        '
        'btnAnt2
        '
        Me.btnAnt2.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAnt2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnAnt2.Location = New System.Drawing.Point(0, 0)
        Me.btnAnt2.Name = "btnAnt2"
        Me.btnAnt2.Size = New System.Drawing.Size(54, 24)
        Me.btnAnt2.TabIndex = 22
        Me.btnAnt2.Text = "<< Prim."
        '
        'btnSig2
        '
        Me.btnSig2.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSig2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnSig2.Location = New System.Drawing.Point(189, 0)
        Me.btnSig2.Name = "btnSig2"
        Me.btnSig2.Size = New System.Drawing.Size(51, 24)
        Me.btnSig2.TabIndex = 23
        Me.btnSig2.Text = "Ultim>>"
        '
        'labelAvance
        '
        Me.labelAvance.Location = New System.Drawing.Point(55, 3)
        Me.labelAvance.Name = "labelAvance"
        Me.labelAvance.Size = New System.Drawing.Size(128, 17)
        Me.labelAvance.Text = "0/500 reg. hechos"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 30)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 214)
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblAdjuntos)
        Me.Panel5.Controls.Add(Me.lblVersion)
        Me.Panel5.Controls.Add(Me.btnPboxFoto)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.numericObs)
        Me.Panel5.Controls.Add(Me.Label26)
        Me.Panel5.Controls.Add(Me.lblasterisco)
        Me.Panel5.Controls.Add(Me.btnElegirObs)
        Me.Panel5.Controls.Add(Me.Label23)
        Me.Panel5.Controls.Add(Me.txtObservacion)
        Me.Panel5.Controls.Add(Me.txtObs)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.txtValor)
        Me.Panel5.Controls.Add(Me.Label25)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 109)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(240, 105)
        '
        'lblAdjuntos
        '
        Me.lblAdjuntos.Font = New System.Drawing.Font("Tahoma", 7.5!, System.Drawing.FontStyle.Regular)
        Me.lblAdjuntos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAdjuntos.Location = New System.Drawing.Point(199, 46)
        Me.lblAdjuntos.Name = "lblAdjuntos"
        Me.lblAdjuntos.Size = New System.Drawing.Size(38, 18)
        Me.lblAdjuntos.Text = "(1) Adj."
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblVersion.Location = New System.Drawing.Point(158, 92)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(80, 13)
        '
        'btnPboxFoto
        '
        Me.btnPboxFoto.Image = CType(resources.GetObject("btnPboxFoto.Image"), System.Drawing.Image)
        Me.btnPboxFoto.Location = New System.Drawing.Point(201, 65)
        Me.btnPboxFoto.Name = "btnPboxFoto"
        Me.btnPboxFoto.Size = New System.Drawing.Size(36, 27)
        Me.btnPboxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label7.Location = New System.Drawing.Point(7, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 12)
        Me.Label7.Text = "A ."
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label6.Location = New System.Drawing.Point(6, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 18)
        Me.Label6.Text = "R S"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label5.Location = New System.Drawing.Point(6, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 18)
        Me.Label5.Text = "T B"
        '
        'numericObs
        '
        Me.numericObs.Location = New System.Drawing.Point(30, 21)
        Me.numericObs.Maximum = New Decimal(New Integer() {66, 0, 0, 0})
        Me.numericObs.Name = "numericObs"
        Me.numericObs.Size = New System.Drawing.Size(49, 22)
        Me.numericObs.TabIndex = 15
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(3, 92)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(140, 13)
        Me.Label26.Text = "(*) Campos Obligatorios"
        '
        'lblasterisco
        '
        Me.lblasterisco.ForeColor = System.Drawing.Color.Red
        Me.lblasterisco.Location = New System.Drawing.Point(49, 0)
        Me.lblasterisco.Name = "lblasterisco"
        Me.lblasterisco.Size = New System.Drawing.Size(23, 20)
        Me.lblasterisco.Text = "(*)"
        '
        'btnElegirObs
        '
        Me.btnElegirObs.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.btnElegirObs.Location = New System.Drawing.Point(199, 23)
        Me.btnElegirObs.Name = "btnElegirObs"
        Me.btnElegirObs.Size = New System.Drawing.Size(38, 20)
        Me.btnElegirObs.TabIndex = 17
        Me.btnElegirObs.Text = "Buscar"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label23.Location = New System.Drawing.Point(4, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 18)
        Me.Label23.Text = "O O"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(30, 44)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(170, 48)
        Me.txtObservacion.TabIndex = 17
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(80, 22)
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(120, 21)
        Me.txtObs.TabIndex = 16
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(1, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(26, 20)
        Me.Label24.Text = "Obs"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(80, 1)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(120, 21)
        Me.txtValor.TabIndex = 14
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(1, 1)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 20)
        Me.Label25.Text = "Lectura:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.tabconPlanillaItem)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(240, 108)
        '
        'tabconPlanillaItem
        '
        Me.tabconPlanillaItem.Controls.Add(Me.TabPage2)
        Me.tabconPlanillaItem.Controls.Add(Me.TabPage1)
        Me.tabconPlanillaItem.Controls.Add(Me.TabPage4)
        Me.tabconPlanillaItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabconPlanillaItem.Location = New System.Drawing.Point(0, 0)
        Me.tabconPlanillaItem.Name = "tabconPlanillaItem"
        Me.tabconPlanillaItem.SelectedIndex = 0
        Me.tabconPlanillaItem.Size = New System.Drawing.Size(240, 108)
        Me.tabconPlanillaItem.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtCategoria)
        Me.TabPage2.Controls.Add(Me.txtDireccion)
        Me.TabPage2.Controls.Add(Me.txtMedidor)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtCaja)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.txtEmp)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.txtUbicacion)
        Me.TabPage2.Controls.Add(Me.txtLote)
        Me.TabPage2.Controls.Add(Me.txtManzano)
        Me.TabPage2.Controls.Add(Me.txtRuta)
        Me.TabPage2.Controls.Add(Me.txtSector)
        Me.TabPage2.Controls.Add(Me.txtCiclo)
        Me.TabPage2.Location = New System.Drawing.Point(0, 0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(240, 85)
        Me.TabPage2.Text = "Catastro"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(119, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 20)
        Me.Label4.Text = "Cate"
        '
        'txtCategoria
        '
        Me.txtCategoria.Location = New System.Drawing.Point(154, 65)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(86, 21)
        Me.txtCategoria.TabIndex = 12
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(0, 44)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(240, 21)
        Me.txtDireccion.TabIndex = 10
        '
        'txtMedidor
        '
        Me.txtMedidor.Location = New System.Drawing.Point(31, 23)
        Me.txtMedidor.Name = "txtMedidor"
        Me.txtMedidor.ReadOnly = True
        Me.txtMedidor.Size = New System.Drawing.Size(108, 21)
        Me.txtMedidor.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(1, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 19)
        Me.Label3.Text = "Med"
        '
        'txtCaja
        '
        Me.txtCaja.Location = New System.Drawing.Point(159, 23)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.ReadOnly = True
        Me.txtCaja.Size = New System.Drawing.Size(79, 21)
        Me.txtCaja.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(138, 25)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(22, 20)
        Me.Label27.Text = "Cja"
        '
        'txtEmp
        '
        Me.txtEmp.Location = New System.Drawing.Point(31, 65)
        Me.txtEmp.Name = "txtEmp"
        Me.txtEmp.ReadOnly = True
        Me.txtEmp.Size = New System.Drawing.Size(80, 21)
        Me.txtEmp.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(3, 68)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 18)
        Me.Label22.Text = "Emp"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Location = New System.Drawing.Point(211, 1)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.ReadOnly = True
        Me.txtUbicacion.Size = New System.Drawing.Size(27, 21)
        Me.txtUbicacion.TabIndex = 7
        '
        'txtLote
        '
        Me.txtLote.BackColor = System.Drawing.Color.Yellow
        Me.txtLote.Location = New System.Drawing.Point(165, 1)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(45, 21)
        Me.txtLote.TabIndex = 6
        '
        'txtManzano
        '
        Me.txtManzano.BackColor = System.Drawing.Color.Yellow
        Me.txtManzano.Location = New System.Drawing.Point(125, 1)
        Me.txtManzano.Name = "txtManzano"
        Me.txtManzano.Size = New System.Drawing.Size(39, 21)
        Me.txtManzano.TabIndex = 5
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(87, 1)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(37, 21)
        Me.txtRuta.TabIndex = 4
        '
        'txtSector
        '
        Me.txtSector.Location = New System.Drawing.Point(41, 1)
        Me.txtSector.Name = "txtSector"
        Me.txtSector.ReadOnly = True
        Me.txtSector.Size = New System.Drawing.Size(45, 21)
        Me.txtSector.TabIndex = 3
        '
        'txtCiclo
        '
        Me.txtCiclo.Location = New System.Drawing.Point(1, 1)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.ReadOnly = True
        Me.txtCiclo.Size = New System.Drawing.Size(39, 21)
        Me.txtCiclo.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtMeses)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtDeuda)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtMayor)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.lblcortado)
        Me.TabPage1.Controls.Add(Me.txtCliente)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtCuenta)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(0, 0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(232, 82)
        Me.TabPage1.Text = "Info. Principal"
        '
        'txtMeses
        '
        Me.txtMeses.Location = New System.Drawing.Point(186, 63)
        Me.txtMeses.Name = "txtMeses"
        Me.txtMeses.ReadOnly = True
        Me.txtMeses.Size = New System.Drawing.Size(51, 21)
        Me.txtMeses.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(139, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 20)
        Me.Label13.Text = "Meses:"
        '
        'txtDeuda
        '
        Me.txtDeuda.Location = New System.Drawing.Point(49, 63)
        Me.txtDeuda.Name = "txtDeuda"
        Me.txtDeuda.ReadOnly = True
        Me.txtDeuda.Size = New System.Drawing.Size(84, 21)
        Me.txtDeuda.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(1, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 20)
        Me.Label14.Text = "Deuda:"
        '
        'txtMayor
        '
        Me.txtMayor.Location = New System.Drawing.Point(186, 42)
        Me.txtMayor.Name = "txtMayor"
        Me.txtMayor.ReadOnly = True
        Me.txtMayor.Size = New System.Drawing.Size(51, 21)
        Me.txtMayor.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(56, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 20)
        Me.Label9.Text = "Rebaja Tercera Edad:"
        '
        'lblcortado
        '
        Me.lblcortado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblcortado.ForeColor = System.Drawing.Color.Red
        Me.lblcortado.Location = New System.Drawing.Point(142, 1)
        Me.lblcortado.Name = "lblcortado"
        Me.lblcortado.Size = New System.Drawing.Size(94, 18)
        Me.lblcortado.Text = "Ser. CORTADO"
        Me.lblcortado.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(49, 21)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(188, 21)
        Me.txtCliente.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(2, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.Text = "Cliente:"
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(49, 0)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(89, 21)
        Me.txtCuenta.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 20)
        Me.Label1.Text = "Cuenta:"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtProm)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Controls.Add(Me.txtLec4)
        Me.TabPage4.Controls.Add(Me.Label18)
        Me.TabPage4.Controls.Add(Me.txtLec5)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.txtLec6)
        Me.TabPage4.Controls.Add(Me.Label20)
        Me.TabPage4.Controls.Add(Me.txtLec1)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Controls.Add(Me.txtLec2)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.txtLec3)
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Location = New System.Drawing.Point(0, 0)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(232, 82)
        Me.TabPage4.Text = "Historico"
        '
        'txtProm
        '
        Me.txtProm.Location = New System.Drawing.Point(121, 63)
        Me.txtProm.Name = "txtProm"
        Me.txtProm.Size = New System.Drawing.Size(51, 21)
        Me.txtProm.TabIndex = 39
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(3, 63)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 20)
        Me.Label21.Text = "Promedio Consumo"
        '
        'txtLec4
        '
        Me.txtLec4.Location = New System.Drawing.Point(50, 42)
        Me.txtLec4.Name = "txtLec4"
        Me.txtLec4.Size = New System.Drawing.Size(67, 21)
        Me.txtLec4.TabIndex = 34
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(1, 42)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 20)
        Me.Label18.Text = "3"
        '
        'txtLec5
        '
        Me.txtLec5.Location = New System.Drawing.Point(50, 21)
        Me.txtLec5.Name = "txtLec5"
        Me.txtLec5.Size = New System.Drawing.Size(67, 21)
        Me.txtLec5.TabIndex = 33
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(1, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 20)
        Me.Label19.Text = "2"
        '
        'txtLec6
        '
        Me.txtLec6.Location = New System.Drawing.Point(50, 0)
        Me.txtLec6.Name = "txtLec6"
        Me.txtLec6.Size = New System.Drawing.Size(67, 21)
        Me.txtLec6.TabIndex = 32
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(1, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 20)
        Me.Label20.Text = "1"
        '
        'txtLec1
        '
        Me.txtLec1.Location = New System.Drawing.Point(172, 42)
        Me.txtLec1.Name = "txtLec1"
        Me.txtLec1.Size = New System.Drawing.Size(68, 21)
        Me.txtLec1.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(121, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 20)
        Me.Label15.Text = "6"
        '
        'txtLec2
        '
        Me.txtLec2.Location = New System.Drawing.Point(172, 21)
        Me.txtLec2.Name = "txtLec2"
        Me.txtLec2.Size = New System.Drawing.Size(68, 21)
        Me.txtLec2.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(121, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 20)
        Me.Label16.Text = "5"
        '
        'txtLec3
        '
        Me.txtLec3.Location = New System.Drawing.Point(172, 0)
        Me.txtLec3.Name = "txtLec3"
        Me.txtLec3.Size = New System.Drawing.Size(68, 21)
        Me.txtLec3.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(121, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 20)
        Me.Label17.Text = "4"
        '
        'FormRegistroLecturaSecu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Menu = Me.mainMenu1
        Me.Name = "FormRegistroLecturaSecu"
        Me.Text = "Toma Lectura"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.tabconPlanillaItem.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MenuRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuOpiones As System.Windows.Forms.MenuItem
    Friend WithEvents MenuOnline As System.Windows.Forms.MenuItem
    Friend WithEvents MenuOfline As System.Windows.Forms.MenuItem
    Friend WithEvents MenuGrabar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuBusqueda As System.Windows.Forms.MenuItem
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents tabconPlanillaItem As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtManzano As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtSector As System.Windows.Forms.TextBox
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents txtLec4 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtLec5 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtLec6 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtLec1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtLec2 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLec3 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtProm As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnAnt2 As System.Windows.Forms.Button
    Friend WithEvents btnSig2 As System.Windows.Forms.Button
    Friend WithEvents labelAvance As System.Windows.Forms.Label
    Friend WithEvents labelSecuencia As System.Windows.Forms.Label
    Friend WithEvents btnAnt1 As System.Windows.Forms.Button
    Friend WithEvents btnSig1 As System.Windows.Forms.Button
    Friend WithEvents btnElegirObs As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblasterisco As System.Windows.Forms.Label
    Friend WithEvents numericObs As System.Windows.Forms.NumericUpDown
    Friend WithEvents MenuImprimir As System.Windows.Forms.MenuItem
    Friend WithEvents labelPeriodo As System.Windows.Forms.Label
    Friend WithEvents numsecu As System.Windows.Forms.NumericUpDown
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents lblcortado As System.Windows.Forms.Label
    Friend WithEvents txtEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents mnuTodos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPendientes As System.Windows.Forms.MenuItem
    Friend WithEvents txtMedidor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtMeses As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDeuda As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMayor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mnuFoto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEmailPreaviso As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReporte As System.Windows.Forms.MenuItem
    Friend WithEvents btnPboxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents mnuVersion As System.Windows.Forms.MenuItem
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblAdjuntos As System.Windows.Forms.Label
End Class
