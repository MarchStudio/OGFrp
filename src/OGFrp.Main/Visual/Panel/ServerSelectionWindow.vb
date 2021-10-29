Imports OGFrp.UI

Public Class ServerSelectionWindow

    Dim Config As New Config
    Dim Assets As New AssetModel
    Dim Frp As New Frp

    Dim AccessToken As String

    Public Sub _init_(ByVal AccessToken As String)
        Me.AccessToken = AccessToken
        Config.ReadConfig()
        Select Case Config.Lang.Val
            Case "zh_cn"
                Assets = (New Assets).zh_cn
            Case "en_us"
                Assets = (New Assets).en_us
        End Select
        Me.lb_Server.Text = Assets.PlzSelectServer
        Me.bt_launch.Text = Assets.LaunchFrpc
        Me.cb_Server.Text = "hk1.ogfrp.cn"
    End Sub

    Private Sub bt_launch_Click(sender As Object, e As EventArgs) Handles bt_launch.Click
        Frp.launchFrpc(Me.AccessToken, Me.cb_Server.Text)
        Me.Dispose()
    End Sub

    Private Sub ServerSelectionWindow_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Dispose()
    End Sub
End Class