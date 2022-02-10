Imports OGFrp.UI

Public Class FrpcPanel

    Dim fctn As FrpcCollections

    Dim Assets As AssetModel
    Dim Token As String

    Public Sub _init_(ByVal token As String, ByVal Assets As AssetModel)
        Me.Assets = Assets
        Me.Token = token
        Me.lb_Refresh.Text = Me.Assets.Refresh
        LoadProxys()
    End Sub

    Private Sub LoadProxys()
        Try
            Me.Grid.Height = 0
            fctn = New FrpcCollections(Token)
            fctn.getFrpcConfigCollection()
            Dim fcCtn = fctn.ProxyDisplays()
            For i = 0 To fcCtn.ToArray.Length - 1
                Dim fc = fcCtn(i)
                fc.AutoDisplay()
                fc.HorizontalAlignment = HorizontalAlignment.Center
                fc.VerticalAlignment = VerticalAlignment.Top
                fc.Width = Me.Grid.Width - 40
                fc.Height = 80
                fc.Margin = New Thickness(Me.lb_Refresh.ActualWidth + 10, 5 + 85 * i, Me.lb_Refresh.ActualWidth + 10, 0)
                fc.SetViewLogContent(Assets.ViewLog)
                fc.text_Duplicated = Assets.Duplicated
                fc.SetDuplicateNotice(Assets.ClickToDuplicate)
                fc.SetTextForeColor(Brushes.Black)
                Me.Grid.Children.Add(fc)
                Me.Grid.Height += 85
            Next
            Me.Grid.Height += 5
        Catch
        End Try
    End Sub

    Private Sub ReLoadProxys() Handles lb_Refresh.MouseLeftButtonUp
        Me.lb_Refresh.Text = Me.Assets.Refreshing
        Me.Grid.Children.Clear()
        Dim ivk As New System.Windows.Forms.Form With {
            .ShowInTaskbar = False,
            .WindowState = Forms.FormWindowState.Minimized,
            .Width = 0,
            .Height = 0
        }
        ivk.Show()
        Dim rstd As New Threading.Thread(
            Sub()
                ivk.Invoke(Sub()
                               LoadProxys()
                               Me.lb_Refresh.Text = Me.Assets.Refresh
                           End Sub)
            End Sub)
        rstd.Start()
    End Sub

    Public Sub CloseAllFrpc()
        For Each fc As FrpcCover In Me.Grid.Children
            fc.frpc.Kill()
        Next
    End Sub

End Class
