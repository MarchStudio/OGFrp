Public Class AboutBox
    Private Sub Lb_OpenSource_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles Lb_OpenSource.MouseDown
        Process.Start("https://github.com/MarchStudio/OGFrp")
    End Sub
End Class
