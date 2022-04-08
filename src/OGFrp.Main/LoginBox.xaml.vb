Imports OGFrp.UI
Imports System.IO
Imports System.Threading

Public Class LoginBox

    Public Assets As AssetModel
    Public Theme As Theme
    Public Config As Config

    Dim loginResult As UserControl

    Public Event LoginSucceed()

    Public Username As String
    Public UserToken As String

    Private Sub SearchHeadImg(email As String)
        If File.Exists(Gravatar.FolderPath + "\" + email + ".png") Then
            Try
                Dim imgBitmap As New System.Drawing.Bitmap(Gravatar.FolderPath + "\" + email + ".png")
                Me.img_head.Source = UI.Image.BitmapToImageSource(imgBitmap)
            Catch
            End Try
        End If
    End Sub

    Public Sub _init_()
        Me.tb_Username.Text = Config.Username.Val
        Me.lb_unmNotice.Content = Assets.Username
        Me.lb_pwdNotice.Content = Assets.Password
        Me.lb_unmNotice.Foreground = Brushes.Gray
        Me.lb_pwdNotice.Foreground = Brushes.Gray
        Me.tempfrm.Show()
        Me.tempfrm.Visible = False
        If Not Config.Username.Val = "" Then
            Me.tb_Username.Text = Config.Username.Val
            Me.lb_unmNotice.Visibility = Visibility.Hidden
            SearchHeadImg(Config.Username.Val)
            Me.tb_Password.Focus()
            Me.lb_pwdNotice.Visibility = Visibility.Hidden
        End If
        If Me.Theme.isDark Then
            Me.Gd_login.Background = Theme.contentBackground
            Me.tb_Username.Foreground = Theme.contentForeground
            Me.tb_Password.Foreground = Theme.contentForeground
            Me.tb_Username.Background = Theme.contentBackground
            Me.tb_Password.Background = Theme.contentBackground
        End If
        Me.lb_info.Foreground = Theme.contentForeground
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
    ''' 已获取的用户头像
    ''' </summary>
    Public UserImage As System.Drawing.Bitmap

    ''' <summary>
    ''' 当成功获取用户头像后触发
    ''' </summary>
    Public Event GotUserImage()

    ''' <summary>
    ''' 登录（返回token）
    ''' </summary>
    Private Sub login()
        Try
            tempfrm.Invoke(
                Sub()
                    Me.UserToken = Net.GetAccessToken(Me.tb_Username.Text, Me.tb_Password.Password)
                    Me.Username = Me.tb_Username.Text
                    RaiseEvent LoginSucceed()
                    Me.Visibility = Visibility.Hidden
                End Sub)
        Catch ex As Exception
            tempfrm.Invoke(
                Sub()
                    Me.lb_info.Content = Assets.LoginFailed
                    Me.tb_Username.IsEnabled = True
                    Me.tb_Password.IsEnabled = True
                    Me.bt_login.IsEnabled = True
                    Dim WebException As System.Net.WebException = ex
                    If WebException.Status = System.Net.WebExceptionStatus.ProtocolError Then
                        Me.lb_info.Content += " “ + Assets.InvaildUorP
                    Else
                        'The following line is for debug only.
                        MsgBox(ex.ToString())
                    End If
                End Sub)
        End Try
    End Sub

    Private Sub bt_login_Click() Handles bt_login.Click
        Me.Config.Username.Val = Me.tb_Username.Text
        Config.WriteConfig()
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

    Private Sub tb_Password_KeyDown(sender As Object, e As KeyEventArgs) Handles tb_Password.KeyDown
        If e.Key = Key.Enter Then
            Me.bt_login_Click()
        End If
    End Sub

    Private Sub usrnme_foc() Handles lb_unmNotice.MouseDown, tb_Username.GotFocus
        Me.lb_unmNotice.Visibility = Visibility.Hidden
        Me.tb_Username.Focus()
    End Sub

    Private Sub usrnme_lfc() Handles tb_Username.LostFocus
        If Me.tb_Username.Text = vbNullString Then
            Me.lb_unmNotice.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub unm_msetr() Handles lb_unmNotice.MouseMove
        If Me.tb_Password.IsEnabled Then
            Me.lb_unmNotice.BorderBrush = Me.tb_Username.SelectionBrush
        End If
    End Sub

    Private Sub unm_mslv() Handles lb_unmNotice.MouseLeave
        Me.lb_unmNotice.BorderBrush = Brushes.Transparent
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
