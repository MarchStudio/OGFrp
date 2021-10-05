Imports OGFrp.UI
Imports System.Windows.Media.Effects

Public Class Login

    Public Sub _init_(nc As LoginBox)
        nextControl = nc
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
        Me.bt_Letsgo.Content = Assets.Letsgo
    End Sub

    WithEvents Timer As New System.Windows.Forms.Timer With
    {
        .Enabled = False,
        .Interval = 50
    }

    Dim TickTime = 0
    Dim nextControl As LoginBox

    Sub Tiner_Tick() Handles Timer.Tick
        Me.BG.Effect = New BlurEffect With {
            .KernelType = KernelType.Box,
            .Radius = TickTime / 3
        }
        TickTime += 1
        nextControl.IsEnabled = True
        nextControl.Effect = New BlurEffect With {
            .KernelType = KernelType.Gaussian,
            .Radius = Int((20 - TickTime) / 10)
        }
        Me.bt_Letsgo.Opacity -= 5
        If TickTime >= 20 Then
            Me.Timer.Stop()
        End If
    End Sub

    Public Sub LoaingDone()
        Me.lb_Welcome.Visibility = Visibility.Collapsed
        Me.bt_Letsgo.IsEnabled = False
        nextControl.Visibility = Visibility.Visible
        nextControl.Opacity = 100
        Me.Timer.Start()
    End Sub

    Private Sub bt_Letsgo_Click(sender As Object, e As RoutedEventArgs) Handles bt_Letsgo.Click
        LoaingDone()
    End Sub
End Class
