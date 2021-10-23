Imports OGFrp.UI
Imports System.Threading
Imports System.Windows.Forms

Public Class MainPage

    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)

    Private Sub Notice(ByVal content As String, Optional delayTime As Integer = 5)
        Me.lb_frpcNotice.Content = content
        Dim controlThread As New Thread(
            Sub()
                Sleep(delayTime * 1000)
                Me.tmpFrm.Invoke(
                    Sub()
                        Me.lb_frpcNotice.Content = ""
                    End Sub
                )
            End Sub
        )
        controlThread.Start()
    End Sub

    Dim AccessToken As String

    Dim Config As New Config
    Dim Assets As New AssetModel
    Dim Frp As New Frp

    Private Sub DownloadFrpc()
        Me.bt_dldFrpc.IsEnabled = False
        Me.bt_dldFrpc.Content = Assets.Downloading
        Me.bt_launchFrpc.IsEnabled = False
        Notice(Assets.DownloadingFrpc)
        Dim downloadThread As New Thread(
            Sub()
                Dim downloadState As Integer
                Try
                    downloadState = Frp.DownloadFrpc()
                Catch ex As Exception
                    Notice(Assets.DownloadFailed)
                End Try
                tmpFrm.Invoke(
                    Sub()
                        Me.bt_dldFrpc.IsEnabled = True
                        Me.bt_dldFrpc.Content = Assets.DownloadFrpc
                        Me.bt_launchFrpc.IsEnabled = True
                    End Sub
                )
                If downloadState = 0 Then
                    tmpFrm.Invoke(
                    Sub()
                        Notice("")
                    End Sub
                )
                End If
            End Sub
        )
        downloadThread.Start()
    End Sub

    Private Sub reDownloadFrpc() Handles bt_dldFrpc.Click
        Me.bt_dldFrpc.IsEnabled = False
        Me.bt_dldFrpc.Content = Assets.Downloading
        Me.bt_launchFrpc.IsEnabled = False
        Notice(Assets.DownloadingFrpc)
        Dim downloadThread As New Thread(
            Sub()
                If Frp.reDownloadFrpc() = -1 Then
                    Notice(Assets.DownloadFailed)
                End If
                tmpFrm.Invoke(
                    Sub()
                        Me.bt_dldFrpc.IsEnabled = True
                        Me.bt_dldFrpc.Content = Assets.DownloadFrpc
                        Me.bt_launchFrpc.IsEnabled = True
                        Notice(Assets.DownloadedFrpc)
                    End Sub
                )
            End Sub
        )
        downloadThread.Start()
    End Sub

    Dim tmpFrm As New Form With
    {
        .Top = Integer.MaxValue,
        .Left = Integer.MaxValue,
        .Width = 0,
        .Height = 0,
        .FormBorderStyle = FormBorderStyle.None,
        .ShowInTaskbar = False
    }

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
        Me.bt_dldFrpc.Content = Assets.DownloadFrpc
        Me.bt_launchFrpc.Content = Assets.LaunchFrpc
        tmpFrm.Show()
        tmpFrm.Hide()
        Me.lb_frpcNotice.Content = ""
        Me.Visibility = Visibility.Visible
        DownloadFrpc()
    End Sub

    Private Sub MainPage_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        End
    End Sub
End Class
