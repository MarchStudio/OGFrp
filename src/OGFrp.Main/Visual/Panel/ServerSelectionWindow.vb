Imports OGFrp.UI

Public Class ServerSelectionWindow

    Dim Config As New Config
    Dim Assets As New AssetModel
    Dim Frp As New Frp

    Public Sub _init_(ByVal AccessToken As String, ByVal Username As String)
        Config.ReadConfig()
        Select Case Config.Lang.Val
            Case "zh_cn"
                Assets = (New Assets).zh_cn
            Case "en_us"
                Assets = (New Assets).en_us
        End Select
    End Sub

    Private Sub ServerSelectionWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class