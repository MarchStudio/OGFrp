Public Class LanguageConfig

    Public Assets As UI.AssetModel
    Public Config As UI.Config

    Public Sub _init_()
        Me.lb_Lang.Text = Assets.Language
        Me.cb_val.ItemsSource = (New UI.Assets).AssetCollection
        Me.cb_val.DisplayMemberPath = "LangNameD"
        Me.cb_val.Text = (New UI.Assets).LangNameStoD(Config.Lang.Val)
    End Sub

    Private Sub cb_val_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cb_val.SelectionChanged
        Dim t As UI.AssetModel = Me.cb_val.SelectedItem
        Config.Lang.Val = t.LangNameS
        Config.WriteConfig()
    End Sub
End Class
