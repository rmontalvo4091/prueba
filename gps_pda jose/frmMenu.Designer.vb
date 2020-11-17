<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.pboxAvatar = New System.Windows.Forms.PictureBox
        Me.lblUsuario = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.lblHora = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.btnPlanilla = New System.Windows.Forms.Button
        Me.btnReportes = New System.Windows.Forms.Button
        Me.btnConfig = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lblModo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'pboxAvatar
        '
        Me.pboxAvatar.Image = CType(resources.GetObject("pboxAvatar.Image"), System.Drawing.Image)
        Me.pboxAvatar.Location = New System.Drawing.Point(16, 31)
        Me.pboxAvatar.Name = "pboxAvatar"
        Me.pboxAvatar.Size = New System.Drawing.Size(88, 87)
        Me.pboxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'lblUsuario
        '
        Me.lblUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblUsuario.Location = New System.Drawing.Point(119, 65)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(100, 20)
        Me.lblUsuario.Tag = ""
        Me.lblUsuario.Text = "usuario"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(119, 39)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(100, 23)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'lblHora
        '
        Me.lblHora.Location = New System.Drawing.Point(119, 85)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(100, 36)
        Me.lblHora.Text = "hh:mm:ss"
        '
        'Timer1
        '
        '
        'btnPlanilla
        '
        Me.btnPlanilla.Location = New System.Drawing.Point(16, 124)
        Me.btnPlanilla.Name = "btnPlanilla"
        Me.btnPlanilla.Size = New System.Drawing.Size(97, 63)
        Me.btnPlanilla.TabIndex = 5
        Me.btnPlanilla.Text = "Llenar Planilla"
        '
        'btnReportes
        '
        Me.btnReportes.Location = New System.Drawing.Point(119, 124)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(107, 63)
        Me.btnReportes.TabIndex = 6
        Me.btnReportes.Text = "Reportes"
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(16, 193)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(97, 62)
        Me.btnConfig.TabIndex = 7
        Me.btnConfig.Text = "Configuracion"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(119, 193)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(107, 62)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "Salir"
        '
        'lblModo
        '
        Me.lblModo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblModo.Location = New System.Drawing.Point(158, 12)
        Me.lblModo.Name = "lblModo"
        Me.lblModo.Size = New System.Drawing.Size(68, 20)
        Me.lblModo.Text = "MODO"
        Me.lblModo.Visible = False
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.lblModo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.btnReportes)
        Me.Controls.Add(Me.btnPlanilla)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.pboxAvatar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmMenu"
        Me.Text = "MENU"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pboxAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnPlanilla As System.Windows.Forms.Button
    Friend WithEvents btnReportes As System.Windows.Forms.Button
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblModo As System.Windows.Forms.Label
End Class
