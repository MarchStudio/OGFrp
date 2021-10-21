Imports OGFrp.UI
Imports System.Threading

Public Class LoginBox

    Dim ac As New Assets()  'Temp用ac
    Dim Assets As New AssetModel

    Dim nextControl As MainPage

    Public Sub _init_(nextControl As MainPage)
        Me.nextControl = nextControl
        Dim Config = New Config()
        Config.ReadConfig()
        Select Case Config.Lang.Val
            Case "zh_cn"
                Assets = ac.zh_cn
            Case "en_us"
                Assets = ac.en_us
        End Select
        Me.tb_Username.Text = Config.Username.Val
        If Me.tb_Username.Text = "" Then
            Me.tb_Username.Text = Assets.Username
            Me.tb_Username.Foreground = Brushes.Gray
        End If
        Me.lb_pwdNotice.Foreground = Brushes.Gray
        Me.lb_pwdNotice.Content = Assets.Password
        Me.tempfrm.Show()
        Me.tempfrm.Visible = False
    End Sub

    Dim tempfrm As New Forms.Form With {
        .WindowState = Forms.FormWindowState.Minimized,
        .ShowInTaskbar = False,
        .Left = Integer.MaxValue,
        .Top = Integer.MaxValue,
        .FormBorderStyle = Forms.FormBorderStyle.None,
        .Width = 0,
        .Height = 0
    }

    Dim Net As New Net

    ''' <summary>
    ''' 登录（返回token）
    ''' </summary>
    Private Sub login()
        Try
            tempfrm.Invoke(
                Sub()
                    Me.Visibility = Visibility.Hidden
                    nextControl._init_(Net.GetAccessToken(Me.tb_Username.Text, Me.tb_Password.Password), Me.tb_Username.Text)
                End Sub)
        Catch ex As Exception
            tempfrm.Invoke(
                Sub()
                    MsgBox(ex.ToString)
                    Me.lb_info.Content = Assets.LoginFailed
                    Me.tb_Username.IsEnabled = True
                    Me.tb_Password.IsEnabled = True
                    Me.bt_login.IsEnabled = True
                End Sub)
        End Try
    End Sub

    Private Sub bt_login_Click(sender As Object, e As RoutedEventArgs) Handles bt_login.Click
        If Me.tb_Username.Text = vbNullString Or Me.tb_Password.Password = vbNullString Then
            Me.lb_info.Content = Assets.LoginFailed
        Else
            With Me
                Me.tb_Username.IsEnabled = False
                Me.tb_Password.IsEnabled = False
                Me.bt_login.IsEnabled = False
            End With
            Me.lb_info.Content = Assets.Logining
            Dim LoginThread As New Thread(AddressOf login)
            LoginThread.Start()
        End If
    End Sub

    Private Sub usrnme_foc() Handles tb_Username.GotFocus
        Dim Config = New Config()
        Config.ReadConfig()
        Dim Assets As New AssetModel
        Dim ac As New Assets()  'Temp用
        Select Case Config.Lang.Val
            Case "zh_cn"
                Assets = ac.zh_cn
            Case "en_us"
                Assets = ac.en_us
        End Select
        If Me.tb_Username.Text = Assets.Username Then
            Me.tb_Username.Foreground = Brushes.Black
            Me.tb_Username.Text = ""
        End If
    End Sub

    Private Sub usrnme_lfc() Handles tb_Username.LostFocus
        Dim Config = New Config()
        Config.ReadConfig()
        Dim Assets As New AssetModel
        Dim ac As New Assets()  'Temp用
        Select Case Config.Lang.Val
            Case "zh_cn"
                Assets = ac.zh_cn
            Case "en_us"
                Assets = ac.en_us
        End Select
        If Me.tb_Username.Text = "" Then
            Me.tb_Username.Foreground = Brushes.Gray
            Me.tb_Username.Text = Assets.Username
        End If
    End Sub

    Private Sub pswd_foc() Handles lb_pwdNotice.MouseDown, tb_Password.GotFocus
        Me.lb_pwdNotice.Visibility = Visibility.Hidden
        Me.tb_Password.Focus()
    End Sub

    Private Sub pswd_lfc() Handles tb_Password.LostFocus
        If Me.tb_Password.Password = vbNullString Then
            Me.lb_pwdNotice.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub pswd_msetr() Handles lb_pwdNotice.MouseMove
        If Me.tb_Password.IsEnabled Then
            Me.lb_pwdNotice.BorderBrush = Me.tb_Password.SelectionBrush
        End If
    End Sub

    Private Sub pswd_mslv() Handles lb_pwdNotice.MouseLeave
        Me.lb_pwdNotice.BorderBrush = Brushes.Transparent
    End Sub
End Class
