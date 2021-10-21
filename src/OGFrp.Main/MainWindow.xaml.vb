Imports OGFrp.UI

Class MainWindow

    Private Sub MainWindow_Loaded() Handles MyBase.Loaded
        Me.Login._init_(Me.LoginBox)
        Me.LoginBox._init_(Me.MainPage)
    End Sub

End Class
