Imports System.Data
Imports System
Imports System.IO
Imports System.Drawing
Imports Microsoft.WindowsMobile.Forms
Public Class frmImagenes
    Dim bmp As Bitmap
    Dim filenameIMG As String

    Private Sub mnuCapturarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapturarImagen.Click
        'atualizaImagen(obtenImagen)
        ' Definir una nueva Instancia del control CameraCaptureDialog
        Dim cameraCapture As New Microsoft.WindowsMobile.Forms.CameraCaptureDialog
        ' Si es necesario definir que control sera el Owner de la Captura
        cameraCapture.Owner = Nothing
        ' Definir el titulo del cuadro de dialogo de la Interfaz de la Camara
        cameraCapture.Title = "Tomar foto..."

        cameraCapture.DefaultFileName = filenameIMG
        ' Resolucion de la Foto: 640x480 , 1600x1200 , 2048x1536 (ver si la camara acepta estas imagenes)
        cameraCapture.Resolution = New Size(640, 480)
        ' Definir el modo de la Foto
        cameraCapture.Mode = CameraCaptureMode.Still
        'Establecer el directorio por defecto donde guardaran las fotos
        cameraCapture.InitialDirectory = "\My Documents\"
        'Establecer la calidad de la Foto 
        cameraCapture.StillQuality = CameraCaptureStillQuality.High
        Try
            cameraCapture.ShowDialog()
            If cameraCapture.FileName <> String.Empty Then

                Me.picImagen.Image = New Bitmap(cameraCapture.FileName)
                'recuerda QUE LA CAMARA DEBE SACAR EN MODO VGA para ver en picture box sino no se lo ve.
                'Dim image As Image
                'image = image.FromHbitmap(cameraCapture.FileName)
                'picImagen.Image = image
                'bmp = New Bitmap(cameraCapture.FileName)
                If MsgBox("Guardar esta imagen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ' Se graba la Foto al confirmar 
                    MsgBox("Se guardo la foto en... " + cameraCapture.FileName, MsgBoxStyle.Information)
                    'Me.picImagen.Image = Nothing
                Else
                    ' Se borra la foto si no se desea guardar
                    System.IO.File.Delete(cameraCapture.FileName)
                    MsgBox("Foto Borrada ... " + cameraCapture.FileName, MsgBoxStyle.Information)
                    Me.picImagen.Image = Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: Foto no se grabó. " & ex.ToString, MsgBoxStyle.Information)
        Finally
            cameraCapture.Dispose()
        End Try
    End Sub

    Private Sub atualizaImagen(ByVal nomeArquivo As String)
        Try
            'se nÆo foi selecionanda uma imgem entÆo sai
            If nomeArquivo Is Nothing Then
                Exit Sub
            End If

            'exibe a imagem no controle PictureBox do dispositivo
            'picImagen.Image = New Bitmap(nomeArquivo)

            If MsgBox("Desea colocar esta imagen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ' Se graba la Foto al confirmar 
                picImagen.Image = New Bitmap(nomeArquivo)
                MsgBox("Se guardo la foto en... " + nomeArquivo, MsgBoxStyle.Information)
                System.IO.File.Copy(nomeArquivo, "\My Documents\" & filenameIMG, 1)
                'Me.picImagen.Image = Nothing
            Else

            End If

        Catch ex As Exception
            MsgBox("ERROR!, imagen muy grande verifique que sea VGA. " & ex.ToString())
        End Try

    End Sub

    Private Function obtenImagen() As String

        Dim resultado As String = Nothing
        'abre a janela de dialogo para capturar uma imagegm
        Dim cameraDialog As New CameraCaptureDialog()
        'define alguns parƒmetros para a camera
        cameraDialog.Mode = CameraCaptureMode.Still
        cameraDialog.StillQuality = CameraCaptureStillQuality.High
        cameraDialog.Resolution = New Size(640, 480)
        'se a captura ocorreu com sucesso obtem o nome da imagem
        If cameraDialog.ShowDialog() = DialogResult.OK Then
            resultado = cameraDialog.FileName
        End If

        'exibe e libera a camera
        Me.Show()
        cameraDialog.Dispose()
        'retorna o nome da imagem
        Return resultado
    End Function

    Private Sub mnuCargarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCargarImagen.Click
        atualizaImagen(carregaImagen())
    End Sub

    Private Function carregaImagen() As String

        Dim resultado As String = Nothing

        Dim selectDialogue As New SelectPictureDialog()

        If selectDialogue.ShowDialog() = DialogResult.OK Then
            resultado = selectDialogue.FileName
        End If

        Me.Show()
        selectDialogue.Dispose()

        Return resultado
    End Function

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub picImagen_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picImagen.Paint
        Try
            'e.Graphics.DrawImage(bmp, 0, 0)
        Catch
        End Try

    End Sub

    Private Sub frmImagenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            filenameIMG = _idfoto & ".jpg"
            If File.Exists("\My Documents\" & filenameIMG) = True Then
                picImagen.Image = New Bitmap("\My Documents\" & filenameIMG)
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class