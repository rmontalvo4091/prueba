<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmNotificacion
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
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtMedidor = New System.Windows.Forms.TextBox
        Me.cmbMensaje = New System.Windows.Forms.ComboBox
        Me.txtObservacion = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Enviar"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Salir"
        '
        'cmbTipo
        '
        Me.cmbTipo.Items.Add("CORREO")
        Me.cmbTipo.Items.Add("SMS")
        Me.cmbTipo.Location = New System.Drawing.Point(94, 20)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(100, 22)
        Me.cmbTipo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.Text = "Enviar por:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.Text = "Medidor:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 20)
        Me.Label4.Text = "Mensaje:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 20)
        Me.Label5.Text = "Observacion:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(95, 49)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(142, 21)
        Me.txtCliente.TabIndex = 5
        '
        'txtMedidor
        '
        Me.txtMedidor.Location = New System.Drawing.Point(94, 86)
        Me.txtMedidor.Name = "txtMedidor"
        Me.txtMedidor.Size = New System.Drawing.Size(142, 21)
        Me.txtMedidor.TabIndex = 6
        '
        'cmbMensaje
        '
        Me.cmbMensaje.Items.Add("MEDIDOR NO ENCONTRADO")
        Me.cmbMensaje.Items.Add("MEDIDOR INACCESIBLE")
        Me.cmbMensaje.Items.Add("MEDIDOR INSERVIBLE")
        Me.cmbMensaje.Location = New System.Drawing.Point(95, 116)
        Me.cmbMensaje.Name = "cmbMensaje"
        Me.cmbMensaje.Size = New System.Drawing.Size(142, 22)
        Me.cmbMensaje.TabIndex = 7
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(94, 157)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(142, 77)
        Me.txtObservacion.TabIndex = 8
        '
        'frmNotificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.cmbMensaje)
        Me.Controls.Add(Me.txtMedidor)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTipo)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmNotificacion"
        Me.Text = "NOTIFICACIONES"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtMedidor As System.Windows.Forms.TextBox
    Friend WithEvents cmbMensaje As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
End Class
