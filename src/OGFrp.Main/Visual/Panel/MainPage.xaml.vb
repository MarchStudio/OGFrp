Imports OGFrp.UI

Public Class MainPage

    Dim AccessToken As String

    Dim Config As New Config
    Dim Assets As New AssetModel

    Public Sub _init_(ByVal AccessToken As String, ByVal Username As String)
        Me.AccessToken = AccessToken
        Config.ReadConfig()
        Select Case Config.Lang.Val
            Case "zh_cn"
                Assets = (New Assets).zh_cn
            Case "en_us"
                Assets = (New Assets).en_us
        End Select
        Me.ed_UserInfo.Header = Assets.UserInfo
        Me.lb_Username.Content = Assets.Username & " : " & Username
        Me.lb_AccessToken.Content = Assets.AccessToken & " : " & AccessToken
        Me.Visibility = Visibility.Visible
    End Sub

End Class
