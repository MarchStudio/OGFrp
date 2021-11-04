Imports System.ComponentModel
Imports OGFrp.UI

Class MainWindow

    Private Sub MainWindow_Loaded() Handles MyBase.Loaded
        Me.Login._init_(Me.LoginBox)
        Me.LoginBox._init_(Me.MainPage, Me)
    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub
End Class
