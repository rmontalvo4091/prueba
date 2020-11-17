<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRegLectura
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
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMedidor = New System.Windows.Forms.TextBox
        Me.txtDirec = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtValor = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbLectura = New System.Windows.Forms.ComboBox
        Me.txtObservacion = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Grabar"
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Salir"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 20)
        Me.Label1.Text = "Medidor:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 20)
        Me.Label2.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.Text = "Direccion:"
        '
        'txtMedidor
        '
        Me.txtMedidor.Location = New System.Drawing.Point(85, 26)
        Me.txtMedidor.Name = "txtMedidor"
        Me.txtMedidor.Size = New System.Drawing.Size(143, 21)
        Me.txtMedidor.TabIndex = 3
        '
        'txtDirec
        '
        Me.txtDirec.Location = New System.Drawing.Point(85, 91)
        Me.txtDirec.Name = "txtDirec"
        Me.txtDirec.Size = New System.Drawing.Size(143, 21)
        Me.txtDirec.TabIndex = 4
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(85, 60)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(143, 21)
        Me.txtCliente.TabIndex = 5
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(85, 118)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(143, 21)
        Me.txtValor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 20)
        Me.Label4.Text = "Valor.Cont.:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.Text = "Tipo Lect.:"
        '
        'cmbLectura
        '
        Me.cmbLectura.Location = New System.Drawing.Point(85, 145)
        Me.cmbLectura.Name = "cmbLectura"
        Me.cmbLectura.Size = New System.Drawing.Size(143, 22)
        Me.cmbLectura.TabIndex = 11
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(3, 197)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(225, 58)
        Me.txtObservacion.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 20)
        Me.Label6.Text = "Observacion:"
        '
        'frmRegLectura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.cmbLectura)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtDirec)
        Me.Controls.Add(Me.txtMedidor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmRegLectura"
        Me.Text = "Registro de Lectura"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMedidor As System.Windows.Forms.TextBox
    Friend WithEvents txtDirec As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbLectura As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
