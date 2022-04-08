Public Class ThemeConfig

    Public Assets As UI.AssetModel
    Public Config As UI.Config
    Public Theme As Theme

    Public Sub _init_()
        Me.lb_Theme.Text = Assets.Theme
        Dim Displays(2) As String
        Dim index = 0
        For Each i In Theme.DisplayItems
            Displays(index) = i.DisplayName
            index += 1
        Next
        Me.cb_val.ItemsSource = Displays
        Me.cb_val.Text = Theme.ClassNameToDisplayName(Config.Theme.Val)
    End Sub

    Private Sub cb_val_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cb_val.SelectionChanged
        Dim t As String = Me.cb_val.SelectedItem
        Config.Theme.Val = Theme.DisplayNameToClassName(t)
        Config.WriteConfig()
    End Sub

End Class
