Imports System.ComponentModel
Imports OGFrp.UI

Class MainWindow

#Region "自定义标题栏的交互"
    ''' <summary>
    ''' 窗口拖动
    ''' </summary>
    Private Sub TitleBar_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles TitleBar.MouseLeftButtonDown
        Me.DragMove()
    End Sub

    ''' <summary>
    ''' 窗口关闭
    ''' </summary>
    Private Sub Bt_Close_Click(sender As Object, e As RoutedEventArgs) Handles Bt_Close.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 窗口最小化
    ''' </summary>
    Private Sub Bt_Min_Click(sender As Object, e As RoutedEventArgs) Handles Bt_Min.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Dim clicks As Integer = 0
    ''' <summary>
    ''' 取消最大化
    ''' </summary>
    Private Sub MainWindow_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        If Me.WindowState = WindowState.Maximized Then
            Me.WindowState = WindowState.Normal
        End If
    End Sub
#End Region

    Dim ac As New Assets()  'Temp用ac
    Dim Assets As AssetModel
    Dim Config As New Config()
    Dim Theme As New Theme()

    Private Sub _init_() Handles Me.Loaded
        Config.ReadConfig()
        Select Case Config.Theme.Val
            Case "System"
                Me.Theme.GetSystemTheme()
            Case "Dark"
                Me.Theme.SetDarkTheme()
            Case Else
                Config.Theme.Val = "Light"
                Config.WriteConfig()
        End Select
        If Theme.isDark Then
            Me.Gd_Bg.Effect = New Media.Effects.BlurEffect With {
                .KernelType = Effects.KernelType.Gaussian, .Radius = 10}
        End If
        Me.Assets = ac.SearchAsset(Config.Lang.Val)
        Me.Theme.SetDisplayName(Assets.ThemeSystem, Assets.ThemeLight, Assets.ThemeDark)
        Me.LoginBox.Assets = Me.Assets
        Me.LoginBox.Theme = Me.Theme
        Me.LoginBox.Visibility = Visibility.Visible
        Me.LoginBox.Config = Me.Config
        Me.LoginBox._init_()
        Me.txtTitle.Foreground = Me.Theme.titleActiveTextColor
        Me.txtTitle.Text = Assets.Welcome
        Me.MainPanel.Assets = Me.Assets
        Me.MainPanel.ctm_SettingsPage.Config = Me.Config
        Me.MainPanel.ctm_SettingsPage.Theme = Me.Theme
        Me.MainPanel.Theme = Me.Theme
        Me.bd_titlefillL.Background = Me.Theme.titleActiveColor
        Me.bd_titlefillR.Background = Me.Theme.titleActiveColor
        Me.Bt_Close.Foreground = Me.Theme.titleActiveTextColor
        Me.Bt_Min.Foreground = Me.Theme.titleActiveTextColor
    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

    Private Sub LoginBox_LoginSucceed() Handles LoginBox.LoginSucceed
        Me.txtTitle.Foreground = Brushes.White
        If Theme.isOriginal Then
            Me.bd_titlefillL.Visibility = Visibility.Collapsed
        End If
        Me.Gd_Bg.Effect = New Media.Effects.BlurEffect With {
                .KernelType = Effects.KernelType.Gaussian, .Radius = 0}
        Me.MainPanel.Visibility = Visibility.Visible
        Me.MainPanel.Username = Me.LoginBox.Username
        Me.MainPanel.Nickname = Me.LoginBox.Username
        Me.MainPanel.UserToken = Me.LoginBox.UserToken
        Me.MainPanel.Config = Me.Config
        Me.MainPanel._init_()
        Me.txtTitle.Text = "OGFrp"
    End Sub

    Private Sub MainWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Me.bd_titlefillL.Visibility = Visibility.Visible Then
            Me.txtTitle.Foreground = Me.Theme.titleActiveTextColor
        Else
            Me.txtTitle.Foreground = Brushes.White
        End If
        Me.bd_titlefillL.Background = Me.Theme.titleActiveColor
        Me.bd_titlefillR.Background = Me.Theme.titleActiveColor
        Me.Bt_Close.Foreground = Me.Theme.titleActiveTextColor
        Me.Bt_Min.Foreground = Me.Theme.titleActiveTextColor
        Me.MainPanel.FormActive()
    End Sub

    Private Sub MainWindow_Deactivated(sender As Object, e As EventArgs) Handles Me.Deactivated
        Me.txtTitle.Foreground = Me.Theme.titleInactiveTextColor
        Me.bd_titlefillL.Background = Me.Theme.titleInactiveColor
        Me.bd_titlefillR.Background = Me.Theme.titleInactiveColor
        Me.Bt_Close.Foreground = Me.Theme.titleInactiveTextColor
        Me.Bt_Min.Foreground = Me.Theme.titleInactiveTextColor
        Me.MainPanel.FormDeactive()
    End Sub
End Class
