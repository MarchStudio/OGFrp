Imports OGFrp.UI

Public Class FrpcPanel

    Dim fctn As FrpcCollections

    Public Sub _init_(ByVal token As String)
        fctn = New FrpcCollections(token)
        fctn.getFrpcConfigCollection()
        Dim fcCtn = fctn.ProxyDisplays()
        For i = 0 To fcCtn.ToArray.Length - 1
            Dim fc = fcCtn(i)
            fc.AutoDisplay()
            fc.HorizontalAlignment = HorizontalAlignment.Center
            fc.VerticalAlignment = VerticalAlignment.Top
            fc.Width = Me.Grid.Width - 40
            fc.Height = 80
            fc.Margin = New Thickness(20, 5 + 85 * i, 20, 0)
            fc.SetTextForeColor(Brushes.Black)
            Me.Grid.Children.Add(fc)
        Next
    End Sub

End Class
