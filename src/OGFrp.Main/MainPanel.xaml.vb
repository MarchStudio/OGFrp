Imports System.IO
Imports OGFrp.UI

Public Class MainPanel

    Public Property Username As String
    Public Property Nickname As String
    Public Property UserToken As String
    Public Property UserImage As New System.Drawing.Bitmap(My.Resources.UserHead)

    Public Assets As AssetModel
    Public Config As Config
    Public Theme As Theme

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
        'Set theme---
        Me.ctm_FrpcPanel.Background = Theme.contentBackground
        Me.ctm_FrpcPanel.Foreground = Theme.contentForeground
        Me.ctm_SettingsPage.Background = Theme.contentBackground
        Me.ctm_SettingsPage.Foreground = Theme.contentForeground
        Me.ctm_About.Background = Theme.contentBackground
        Me.ctm_About.Foreground = Theme.contentForeground
        If Theme.isDark Then
            Me.Gd_SidePanel.Background = New SolidColorBrush(Color.FromArgb(225, 25, 25, 28))
        End If
        '---
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
        Me.bt_Settings.ToolTip = Assets.Settings
        Me.bt_About.ToolTip = Assets.About
        Me.ctm_SettingsPage.Assets = Me.Assets
        'Me.ctm_SettingsPage.Config = MainWindow.Config
        '在MainWindow初始化时已经传入Config
        Me.ctm_SettingsPage._init_()
    End Sub

    Public Sub SetUserImage(ByVal Image As System.Drawing.Bitmap)
        Me.ctm_userdisplay.SetImage(Image)
    End Sub

    Private Sub SetBtnUnselected(ByVal btn As Button)
        btn.Background = Brushes.Transparent
        btn.BorderBrush = Brushes.Transparent
    End Sub

    Private Sub DisablePage(ByVal page As Control)
        page.Visibility = Visibility.Collapsed
        page.IsEnabled = False
    End Sub

    Private Sub EnablePage(ByVal page As Control)
        page.Visibility = Visibility.Visible
        page.IsEnabled = True
    End Sub

    Private Sub selectBtn(ByVal btn As Button)
        SetBtnUnselected(bt_Home)
        SetBtnUnselected(bt_frpc)
        SetBtnUnselected(bt_Settings)
        SetBtnUnselected(bt_About)
        btn.Background = SelectedBg
        btn.BorderBrush = Brushes.White
        DisablePage(ctm_HomePage)
        DisablePage(ctm_FrpcPanel)
        DisablePage(ctm_SettingsPage)
        DisablePage(ctm_About)
    End Sub

    Private Sub bt_Home_Click(sender As Object, e As RoutedEventArgs) Handles bt_Home.Click
        selectBtn(bt_Home)
        EnablePage(ctm_HomePage)
    End Sub

    Private Sub bt_frpc_Click(sender As Object, e As RoutedEventArgs) Handles bt_frpc.Click
        If Config.FrpcLaunchMode.Val = "node" Then
            Dim nw As New ServerSelectionWindow
            nw.Assets = Me.Assets
            nw._init_(Me.UserToken)
            nw.ShowDialog()
        Else
            selectBtn(bt_frpc)
            EnablePage(ctm_FrpcPanel)
        End If
    End Sub

    Private Sub bt_Settings_Click(sender As Object, e As RoutedEventArgs) Handles bt_Settings.Click
        selectBtn(bt_Settings)
        EnablePage(ctm_SettingsPage)
    End Sub

    Private Sub bt_About_Click(sender As Object, e As RoutedEventArgs) Handles bt_About.Click
        selectBtn(bt_About)
        EnablePage(ctm_About)
    End Sub

    Public Sub FormActive()
    End Sub

    Public Sub FormDeactive()
    End Sub
End Class
