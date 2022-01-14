Imports System.Drawing

Public Class UserDisplay

    Public Username As String
    Public DisplayName As String

    Dim webSite As String

    Public Sub SetUsername(Username As String)
        Me.Username = Username
    End Sub

    Public Sub SetDisplayName(DisplayName As String)
        Me.DisplayName = DisplayName
        Me.lb_Username.Content = DisplayName
    End Sub

    Public Sub SetImage(Image As Bitmap)
        Me.bd_head.Background = New ImageBrush With {
            .ImageSource = UI.Image.BitmapToImageSource(Image)
        }
    End Sub
    Public Sub SetImage(ImageLoca As String)
        Dim imgBitmap As New Bitmap(ImageLoca)
        Me.bd_head.Background = New ImageBrush With {
            .ImageSource = UI.Image.BitmapToImageSource(imgBitmap)
        }
    End Sub

    Public Sub SetImageFromEmail(email As String)
        UI.Gravatar.getImage(Me.Username)
        Dim UserImage = New System.Drawing.Bitmap(UI.Gravatar.FolderPath + "\" + Username + ".png")
        Me.bd_head.Background = New ImageBrush With {
        .ImageSource = UI.Image.BitmapToImageSource(UserImage)
        }
    End Sub

End Class
