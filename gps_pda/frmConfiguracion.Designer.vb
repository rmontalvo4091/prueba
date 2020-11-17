<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmConfiguracion
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnModo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(62, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 65)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "USUARIOS"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(62, 182)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 65)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "SALIR"
        '
        'btnModo
        '
        Me.btnModo.Location = New System.Drawing.Point(62, 102)
        Me.btnModo.Name = "btnModo"
        Me.btnModo.Size = New System.Drawing.Size(109, 65)
        Me.btnModo.TabIndex = 2
        Me.btnModo.Text = "MODO USO"
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.btnModo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmConfiguracion"
        Me.Text = "CONFIGURACION"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnModo As System.Windows.Forms.Button
End Class
