Public Class AboutBox

    Public Sub SetTheme(Theme As Theme)
        Me.Background = Theme.contentBackground
        Me.Foreground = Theme.contentForeground
    End Sub

    Private Sub Lb_OpenSource_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Lb_OpenSource.MouseDown
        Process.Start("https://github.com/MarchStudio/OGFrp")
    End Sub
End Class
