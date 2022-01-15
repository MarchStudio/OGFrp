Imports OGFrp.UI

Public Class HomePage

    Public Assets As AssetModel

    Public UserImage As System.Drawing.Bitmap
    Public Username As String

    Public Sub _init_()
        Me.lb_UserInfo.Content = Assets.UserInfo
        Me.lb_welcomeBack.Content = Assets.WelcomeBack
        Me.lb_Username.Content = Username
    End Sub

    Public Sub SetImage(Image As System.Drawing.Bitmap)
        Me.bd_HeadImage.Background = New ImageBrush With {
            .ImageSource = UI.Image.BitmapToImageSource(Image)
        }
    End Sub

End Class
