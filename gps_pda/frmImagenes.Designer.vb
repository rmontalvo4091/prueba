<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmImagenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImagenes))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.mnu = New System.Windows.Forms.MenuItem
        Me.mnuCapturarImagen = New System.Windows.Forms.MenuItem
        Me.mnuCargarImagen = New System.Windows.Forms.MenuItem
        Me.mnuSalir = New System.Windows.Forms.MenuItem
        Me.picImagen = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.mnu)
        '
        'mnu
        '
        Me.mnu.MenuItems.Add(Me.mnuCapturarImagen)
        Me.mnu.MenuItems.Add(Me.mnuCargarImagen)
        Me.mnu.MenuItems.Add(Me.mnuSalir)
        Me.mnu.Text = "Menu"
        '
        'mnuCapturarImagen
        '
        Me.mnuCapturarImagen.Text = "1. Capturar Imagen"
        '
        'mnuCargarImagen
        '
        Me.mnuCargarImagen.Text = "2. Cargar Imagen"
        '
        'mnuSalir
        '
        Me.mnuSalir.Text = "3. Salir"
        '
        'picImagen
        '
        Me.picImagen.Image = CType(resources.GetObject("picImagen.Image"), System.Drawing.Image)
        Me.picImagen.Location = New System.Drawing.Point(25, 21)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(190, 222)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmImagenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.picImagen)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmImagenes"
        Me.Text = "formImagenes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mnu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCapturarImagen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCargarImagen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.MenuItem
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
End Class
