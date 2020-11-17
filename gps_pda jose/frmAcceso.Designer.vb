<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmAcceso
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
        Me.txtUsu = New System.Windows.Forms.TextBox
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.lblUsu = New System.Windows.Forms.Label
        Me.lblPass = New System.Windows.Forms.Label
        Me.rdbUsu = New System.Windows.Forms.RadioButton
        Me.rdbPin = New System.Windows.Forms.RadioButton
        Me.lblPin = New System.Windows.Forms.Label
        Me.txtPin = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "INGRESAR"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "SALIR"
        '
        'txtUsu
        '
        Me.txtUsu.Location = New System.Drawing.Point(120, 68)
        Me.txtUsu.Name = "txtUsu"
        Me.txtUsu.Size = New System.Drawing.Size(100, 21)
        Me.txtUsu.TabIndex = 1
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(120, 120)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(100, 21)
        Me.txtPass.TabIndex = 2
        '
        'lblUsu
        '
        Me.lblUsu.Location = New System.Drawing.Point(14, 69)
        Me.lblUsu.Name = "lblUsu"
        Me.lblUsu.Size = New System.Drawing.Size(79, 20)
        Me.lblUsu.Text = "USUARIO:"
        '
        'lblPass
        '
        Me.lblPass.Location = New System.Drawing.Point(14, 121)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(93, 20)
        Me.lblPass.Text = "PASSWORD:"
        '
        'rdbUsu
        '
        Me.rdbUsu.Location = New System.Drawing.Point(120, 3)
        Me.rdbUsu.Name = "rdbUsu"
        Me.rdbUsu.Size = New System.Drawing.Size(100, 20)
        Me.rdbUsu.TabIndex = 5
        Me.rdbUsu.TabStop = False
        Me.rdbUsu.Text = "USUARIO"
        '
        'rdbPin
        '
        Me.rdbPin.Checked = True
        Me.rdbPin.Location = New System.Drawing.Point(7, 3)
        Me.rdbPin.Name = "rdbPin"
        Me.rdbPin.Size = New System.Drawing.Size(100, 20)
        Me.rdbPin.TabIndex = 6
        Me.rdbPin.Text = "PIN"
        '
        'lblPin
        '
        Me.lblPin.Location = New System.Drawing.Point(14, 94)
        Me.lblPin.Name = "lblPin"
        Me.lblPin.Size = New System.Drawing.Size(79, 20)
        Me.lblPin.Text = "PIN:"
        '
        'txtPin
        '
        Me.txtPin.Location = New System.Drawing.Point(120, 93)
        Me.txtPin.Name = "txtPin"
        Me.txtPin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPin.Size = New System.Drawing.Size(100, 21)
        Me.txtPin.TabIndex = 8
        '
        'frmAcceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.lblPin)
        Me.Controls.Add(Me.txtPin)
        Me.Controls.Add(Me.rdbPin)
        Me.Controls.Add(Me.rdbUsu)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUsu)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUsu)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmAcceso"
        Me.Text = "LOGIN"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtUsu As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents lblUsu As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents rdbUsu As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPin As System.Windows.Forms.RadioButton
    Friend WithEvents lblPin As System.Windows.Forms.Label
    Friend WithEvents txtPin As System.Windows.Forms.TextBox
End Class
