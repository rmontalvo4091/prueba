<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmUsuarioCambioPass
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
        Me.TxtPin = New System.Windows.Forms.TextBox
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtClaveNva2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtClaveNva = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Grabar"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Salir"
        '
        'TxtPin
        '
        Me.TxtPin.Location = New System.Drawing.Point(72, 244)
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPin.Size = New System.Drawing.Size(137, 21)
        Me.TxtPin.TabIndex = 12
        Me.TxtPin.Visible = False
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(83, 217)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(137, 21)
        Me.txtClave.TabIndex = 11
        Me.txtClave.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(83, 74)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(137, 21)
        Me.txtNombre.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(-8, 244)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.Text = "Pin Actual:"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.Text = "Clave:"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.Text = "Nombre:"
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(83, 19)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(137, 21)
        Me.txtID.TabIndex = 17
        Me.txtID.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.Text = "ID:"
        Me.Label4.Visible = False
        '
        'txtClaveNva2
        '
        Me.txtClaveNva2.Location = New System.Drawing.Point(83, 152)
        Me.txtClaveNva2.Name = "txtClaveNva2"
        Me.txtClaveNva2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClaveNva2.Size = New System.Drawing.Size(137, 21)
        Me.txtClaveNva2.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 20)
        Me.Label5.Text = "Repetir Clave:"
        '
        'txtClaveNva
        '
        Me.txtClaveNva.Location = New System.Drawing.Point(83, 115)
        Me.txtClaveNva.Name = "txtClaveNva"
        Me.txtClaveNva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClaveNva.Size = New System.Drawing.Size(137, 21)
        Me.txtClaveNva.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 20)
        Me.Label6.Text = "Clave Nueva:"
        '
        'frmUsuarioCambioPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.txtClaveNva)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtClaveNva2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtPin)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmUsuarioCambioPass"
        Me.Text = "CAMBIAR CONTRASEÑA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtPin As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents txtClaveNva2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtClaveNva As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
