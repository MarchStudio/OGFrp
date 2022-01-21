Imports System.IO
Imports OGFrp.UI

Public Class MainPanel

    Public Property Username As String
    Public Property Nickname As String
    Public Property UserToken As String
    Public Property UserImage As New System.Drawing.Bitmap(My.Resources.UserHead)

    Public Assets As AssetModel

    Dim SelectedBg As Brush

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
                Me.ctm_HomePage.SetImage(imgBitmap)
            Catch
            End Try
        End If
        Dim invoker As New Forms.Form With {
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
                    invoker.Invoke(
                        Sub()
                            Dim imgBitmap As New System.Drawing.Bitmap(Gravatar.FolderPath + "\" + Username + ".png")
                            'Me.UserImage = imgBitmap
                            Me.ctm_userdisplay.SetImage(Me.UserImage)
                            Me.ctm_HomePage.SetImage(Me.UserImage)
                        End Sub)
                Catch
                End Try
            End Sub
        )
        dldtd.Start()
        Dim proxyLstd As New System.Threading.Thread(
            Sub()
                Try
                    invoker.Invoke(
                    Sub()
                        Me.ctm_FrpcPanel._init_(Me.UserToken, Me.Assets)
                    End Sub)
                Catch
                    invoker.Invoke(
                    Sub()
                        Me.ctm_FrpcPanel.Content = "null"
                        Me.ctm_FrpcPanel.HorizontalAlignment = HorizontalAlignment.Center
                    End Sub)
                End Try
            End Sub)
        proxyLstd.Start()
        Me.SelectedBg = Me.bt_Home.Background
        selectBtn(bt_Home)
        Me.bt_Home.Content = Assets.Home
        Me.bt_frpc.Content = Assets.Frp
        Me.ctm_HomePage.Visibility = Visibility.Visible
        Me.ctm_HomePage.IsEnabled = True
        Me.ctm_HomePage.Assets = Me.Assets
        Me.ctm_HomePage.Username = Username
        Me.ctm_HomePage._init_()
    End Sub

    Public Sub SetUserImage(ByVal Image As System.Drawing.Bitmap)
        Me.ctm_userdisplay.SetImage(Image)
    End Sub


    Private Sub selectBtn(ByVal btn As Button)
        Me.bt_Home.Background = Brushes.Transparent
        Me.bt_frpc.Background = Brushes.Transparent
        Me.bt_Home.BorderBrush = Brushes.Transparent
        Me.bt_frpc.BorderBrush = Brushes.Transparent
        btn.Background = SelectedBg
        btn.BorderBrush = Brushes.White
        Me.ctm_HomePage.Visibility = Visibility.Collapsed
        Me.ctm_FrpcPanel.Visibility = Visibility.Collapsed
        Me.ctm_HomePage.IsEnabled = False
        Me.ctm_FrpcPanel.IsEnabled = False
    End Sub

    Private Sub bt_Home_Click(sender As Object, e As RoutedEventArgs) Handles bt_Home.Click
        selectBtn(bt_Home)
        Me.ctm_HomePage.Visibility = Visibility.Visible
        Me.ctm_HomePage.IsEnabled = True
    End Sub

    Private Sub bt_frpc_Click(sender As Object, e As RoutedEventArgs) Handles bt_frpc.Click
        'Dim nw As New ServerSelectionWindow
        'nw.Assets = Me.Assets
        'nw._init_(Me.UserToken)
        'nw.ShowDialog()
        selectBtn(bt_frpc)
        Me.ctm_FrpcPanel.Visibility = Visibility.Visible
        Me.ctm_FrpcPanel.IsEnabled = True
    End Sub
End Class
