<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmReporte
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
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblPendientes = New System.Windows.Forms.Label
        Me.lblproc = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lbltotpor = New System.Windows.Forms.Label
        Me.lblprocpor = New System.Windows.Forms.Label
        Me.lblpenpor = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbl_nhojas = New System.Windows.Forms.Label
        Me.lblTiempoTrabajo = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblRuta = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(28, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 20)
        Me.Label1.Text = "REPORTE DE TRABAJO"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(149, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.Text = "PORCENTAJE"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label3.Location = New System.Drawing.Point(79, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 20)
        Me.Label3.Text = "CANTIDAD"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(43, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 20)
        Me.Label4.Text = "TOTAL"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(1, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.Text = "PROCESADOS"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(1, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 20)
        Me.Label6.Text = "PENDIENTES"
        '
        'lblPendientes
        '
        Me.lblPendientes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblPendientes.Location = New System.Drawing.Point(94, 109)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(45, 20)
        Me.lblPendientes.Text = "pendientes"
        '
        'lblproc
        '
        Me.lblproc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblproc.Location = New System.Drawing.Point(94, 89)
        Me.lblproc.Name = "lblproc"
        Me.lblproc.Size = New System.Drawing.Size(45, 20)
        Me.lblproc.Text = "procesados"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblTotal.Location = New System.Drawing.Point(94, 69)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(45, 20)
        Me.lblTotal.Text = "total"
        '
        'lbltotpor
        '
        Me.lbltotpor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lbltotpor.Location = New System.Drawing.Point(159, 69)
        Me.lbltotpor.Name = "lbltotpor"
        Me.lbltotpor.Size = New System.Drawing.Size(45, 20)
        Me.lbltotpor.Text = "total"
        '
        'lblprocpor
        '
        Me.lblprocpor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblprocpor.Location = New System.Drawing.Point(159, 89)
        Me.lblprocpor.Name = "lblprocpor"
        Me.lblprocpor.Size = New System.Drawing.Size(45, 20)
        Me.lblprocpor.Text = "procesados"
        '
        'lblpenpor
        '
        Me.lblpenpor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblpenpor.Location = New System.Drawing.Point(159, 109)
        Me.lblpenpor.Name = "lblpenpor"
        Me.lblpenpor.Size = New System.Drawing.Size(45, 20)
        Me.lblpenpor.Text = "pendientes"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Panel1.Controls.Add(Me.lbl_nhojas)
        Me.Panel1.Controls.Add(Me.lblTiempoTrabajo)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(3, 149)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(223, 116)
        '
        'lbl_nhojas
        '
        Me.lbl_nhojas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lbl_nhojas.Location = New System.Drawing.Point(153, 77)
        Me.lbl_nhojas.Name = "lbl_nhojas"
        Me.lbl_nhojas.Size = New System.Drawing.Size(56, 20)
        Me.lbl_nhojas.Text = "145 hojas"
        '
        'lblTiempoTrabajo
        '
        Me.lblTiempoTrabajo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblTiempoTrabajo.Location = New System.Drawing.Point(133, 43)
        Me.lblTiempoTrabajo.Name = "lblTiempoTrabajo"
        Me.lblTiempoTrabajo.Size = New System.Drawing.Size(84, 27)
        Me.lblTiempoTrabajo.Text = "-"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label10.Location = New System.Drawing.Point(153, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 20)
        Me.Label10.Text = "-"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(3, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 25)
        Me.Label9.Text = "CANT. IMPRESION PRE AVISOS"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(3, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 27)
        Me.Label8.Text = "TIEMPO DE TRABAJO LABORAL"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(3, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 35)
        Me.Label7.Text = "TIEMPO PROMEDIO ENTRE REGISTROS"
        '
        'lblRuta
        '
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRuta.Location = New System.Drawing.Point(43, 29)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(183, 20)
        Me.lblRuta.Text = "RUTA: "
        '
        'frmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbltotpor)
        Me.Controls.Add(Me.lblprocpor)
        Me.Controls.Add(Me.lblpenpor)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblproc)
        Me.Controls.Add(Me.lblPendientes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmReporte"
        Me.Text = "frmReporte"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPendientes As System.Windows.Forms.Label
    Friend WithEvents lblproc As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lbltotpor As System.Windows.Forms.Label
    Friend WithEvents lblprocpor As System.Windows.Forms.Label
    Friend WithEvents lblpenpor As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_nhojas As System.Windows.Forms.Label
    Friend WithEvents lblTiempoTrabajo As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents lblRuta As System.Windows.Forms.Label
End Class
