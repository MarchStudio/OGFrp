Imports OGFrp.UI

Public Class ServerSelectionWindow

    Dim Config As New Config
    Dim Assets As New AssetModel
    Dim Frp As New Frp
    Dim FrpServer As New FrpServer
    Dim Net As New Net

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
        Dim Content = Net.Get("https://api.ogfrp.cn/?action=getnodesidip&token=" + AccessToken)
        Dim frpservers = FrpServer.FrpsServerList(Content)
        Me.cb_Server.DataSource = frpservers
        Me.cb_Server.DisplayMember = "Address"
    End Sub

    Private Sub bt_launch_Click(sender As Object, e As EventArgs) Handles bt_launch.Click
        Dim SelectedServer As FrpServerModel = Me.cb_Server.SelectedItem
        If Frp.launchFrpc(Me.AccessToken, SelectedServer.ID) = -1 Then
            MsgBox("启动失败！", 16, "OGFrp")
        End If
        Me.Dispose()
    End Sub

    Private Sub ServerSelectionWindow_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Dispose()
    End Sub
End Class