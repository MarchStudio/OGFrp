Imports System.IO
Imports OGFrp.UI

Public Class MainPanel

    Public Property Username As String
    Public Property Nickname As String
    Public Property UserToken As String
    Public Property UserImage As System.Drawing.Bitmap

    Public Sub _init_()
        'ini user display
        Me.ctm_userdisplay.SetDisplayName(Me.Nickname)
        'ini head image
        If File.Exists(Gravatar.FolderPath + "\" + Username + ".png") Then
            Try
                Dim imgBitmap As New System.Drawing.Bitmap(Gravatar.FolderPath + "\" + Username + ".png")
                Me.ctm_userdisplay.bd_head.Background = New ImageBrush With {
                    .ImageSource = UI.Image.BitmapToImageSource(imgBitmap)
                }
            Catch
            End Try
        End If
        Dim invoker As New Windows.Forms.Form With {
            .Width = 0,
            .Height = 0,
            .ShowInTaskbar = 0,
            .FormBorderStyle = Forms.FormBorderStyle.None,
            .WindowState = Forms.FormWindowState.Minimized
        }
        invoker.Show()
        invoker.Hide()
        Dim dldtd As New System.Threading.Thread(
                Sub()
                    Try
                        Gravatar.getImage(Me.Username)
                        invoker.Invoke(Sub()
                                           Dim imgBitmap As New System.Drawing.Bitmap(Gravatar.FolderPath + "\" + Username + ".png")
                                           Me.ctm_userdisplay.SetImage(imgBitmap)
                                       End Sub)
                    Catch
                    End Try
                End Sub)
        dldtd.Start()
    End Sub

    Public Sub SetUserImage(ByVal Image As System.Drawing.Bitmap)
        Me.ctm_userdisplay.SetImage(Image)
    End Sub

End Class
