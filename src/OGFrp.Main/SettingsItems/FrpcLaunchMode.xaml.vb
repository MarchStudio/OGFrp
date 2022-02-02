Public Class FrpcLaunchMode

    Public Assets As UI.AssetModel
    Public Config As UI.Config

    Public Sub _init_()
        Me.lb_flm.Text = Assets.FrpcLaunchMode
        Me.cb_val.Items.Add(Assets.ByProxy)
        Me.cb_val.Items.Add(Assets.ByNode)
        If Config.FrpcLaunchMode.Val = "node" Then
            Me.cb_val.Text = Assets.ByNode
        Else
            Config.FrpcLaunchMode.Val = "prroxy"
            Me.cb_val.Text = Assets.ByProxy
        End If
    End Sub

    Private Sub cb_val_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cb_val.SelectionChanged
        Select Case Me.cb_val.SelectedItem
            Case Assets.ByProxy
                Config.FrpcLaunchMode.Val = "prroxy"
            Case Assets.ByNode
                Config.FrpcLaunchMode.Val = "node"
        End Select
        Config.WriteConfig()
    End Sub
End Class
