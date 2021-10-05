Imports OGFrp.UI

Public Class LoginBox

    Public Sub _init_()
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
        Me.tb_Username.Text = Config.Username.Val
        Me.tb_ServerAddr.Text = Config.ServerAddr.Val
        If Me.tb_Username.Text = "" Then
            Me.tb_Username.Text = Assets.Username
            Me.tb_Username.Foreground = Brushes.Gray
        End If
        If Me.tb_Username.Text = "" Then
            Me.tb_ServerAddr.Text = Assets.ServerAddr
            Me.tb_ServerAddr.Foreground = Brushes.Gray
        End If
        Me.tb_Passward.Text = Assets.Passward
        Me.tb_Passward.Foreground = Brushes.Gray
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

    Private Sub psw_foc() Handles tb_Passward.GotFocus
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
        If Me.tb_Passward.Text = Assets.Passward Then
            Me.tb_Passward.Foreground = Brushes.Black
            Me.tb_Passward.Text = ""
        End If
    End Sub

    Private Sub psw_lfc() Handles tb_Passward.LostFocus
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
        If Me.tb_Passward.Text = "" Then
            Me.tb_Passward.Foreground = Brushes.Gray
            Me.tb_Passward.Text = Assets.Passward
        End If
    End Sub

    Private Sub svr_foc() Handles tb_ServerAddr.GotFocus
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
        If Me.tb_ServerAddr.Text = Assets.ServerAddr Then
            Me.tb_ServerAddr.Foreground = Brushes.Black
            Me.tb_ServerAddr.Text = ""
        End If
    End Sub

    Private Sub svr_lfc() Handles tb_ServerAddr.LostFocus
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
        If Me.tb_ServerAddr.Text = "" Then
            Me.tb_ServerAddr.Foreground = Brushes.Gray
            Me.tb_ServerAddr.Text = Assets.ServerAddr
        End If
    End Sub
End Class
