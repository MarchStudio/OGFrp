Public Class SettingsPage

    Public Assets As UI.AssetModel
    Public Config As UI.Config
    Public Theme As Theme

    Public Sub _init_()
        Me.lb_title.Text = Assets.Settings
        Me.ctm_lang.Assets = Me.Assets
        Me.ctm_lang.Config = Me.Config
        Me.ctm_lang._init_()
        Me.ctm_flm.Assets = Me.Assets
        Me.ctm_flm.Config = Me.Config
        Me.ctm_flm._init_()
        Me.ctm_Theme.Assets = Me.Assets
        Me.ctm_Theme.Config = Me.Config
        Me.ctm_Theme.Theme = Me.Theme
        Me.ctm_Theme._init_()
    End Sub

End Class
