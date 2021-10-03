Imports OGFrp.UI

Public Class Login

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
        Me.lb_Welcome.Content = Assets.Welcome
        Me.lb_Loading.Content = Assets.Loading
    End Sub

End Class
