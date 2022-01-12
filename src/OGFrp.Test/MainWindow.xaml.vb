Class MainWindow
    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Me.FrpcCover.SetProxyName("NULL Proxy")
        Me.FrpcCover.SetServerName("NULL Server")
        Me.FrpcCover.SetViewLogContent("显示日志")
        Me.FrpcCover.SetTextForeColor(Brushes.White)
    End Sub

    Private Sub tb_ini_TextChanged(sender As Object, e As TextChangedEventArgs) Handles tb_ini.TextChanged
        Me.FrpcCover.SetIniFile(Me.tb_ini.Text.ToString())
        Me.FrpcCover.SetProxyName(Me.FrpcCover.iniFile)
    End Sub

    Private Sub tb_frpc_TextChanged(sender As Object, e As TextChangedEventArgs) Handles tb_frpc.TextChanged
        Me.FrpcCover.SetFrpcLoca(Me.tb_frpc.Text.ToString())
        Me.FrpcCover.SetServerName(Me.FrpcCover.frpcLoca)
    End Sub
End Class
