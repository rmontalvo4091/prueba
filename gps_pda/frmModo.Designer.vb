<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmModo
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
        Me.rdbOnline = New System.Windows.Forms.RadioButton
        Me.rdbOffline = New System.Windows.Forms.RadioButton
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "SALIR"
        '
        'rdbOnline
        '
        Me.rdbOnline.Location = New System.Drawing.Point(62, 58)
        Me.rdbOnline.Name = "rdbOnline"
        Me.rdbOnline.Size = New System.Drawing.Size(100, 20)
        Me.rdbOnline.TabIndex = 0
        Me.rdbOnline.TabStop = False
        Me.rdbOnline.Text = "ONLINE"
        '
        'rdbOffline
        '
        Me.rdbOffline.Location = New System.Drawing.Point(62, 122)
        Me.rdbOffline.Name = "rdbOffline"
        Me.rdbOffline.Size = New System.Drawing.Size(100, 20)
        Me.rdbOffline.TabIndex = 1
        Me.rdbOffline.TabStop = False
        Me.rdbOffline.Text = "OFFLINE"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "APLICAR"
        '
        'frmModo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.rdbOffline)
        Me.Controls.Add(Me.rdbOnline)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmModo"
        Me.Text = "MODO DE USO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents rdbOnline As System.Windows.Forms.RadioButton
    Friend WithEvents rdbOffline As System.Windows.Forms.RadioButton
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
End Class
