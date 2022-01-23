Public Class SettingsPage

    Public Assets As UI.AssetModel

    Public Config As UI.Config

    Public Sub _init_()
        Me.lb_title.Text = Assets.Settings
        Me.ctm_lang.Assets = Me.Assets
        Me.ctm_lang.Config = Me.Config
        Me.ctm_lang._init_()
    End Sub

End Class
