Imports System.IO
Public Class frmCarga

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        'borramos registros tabla registro
        eliminar_registros()

        'leemos para ingresar codigos
        Dim objReader As New StreamReader("\My Documents\data_JL.csv")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        Dim i As Integer
        For i = 1 To arrText.Count - 1
            'For i = 1 To 1
            Dim strTemp As String = arrText(i)
            Dim lineArr() As String = strTemp.Split(",")
            ' For k = 0 To lineArr.Length - 1
            'insertamos registros
            'nuevo_registro(lineArr(0), lineArr(1))
            ' Next
        Next
    End Sub
End Class