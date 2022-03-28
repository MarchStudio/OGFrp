Public Class Theme

    Public titleActiveColor As Brush
    Public titleInactiveColor As Brush
    Public titleActiveTextColor As Brush
    Public titleInactiveTextColor As Brush
    Public contentBackground As Brush
    Public contentForeground As Brush

    Public Sub New()
        titleActiveColor = New SolidColorBrush(Color.FromArgb(204, 255, 255, 255))
        titleInactiveColor = New SolidColorBrush(Color.FromArgb(255, 255, 255, 255))
        titleActiveTextColor = Brushes.Black
        titleInactiveTextColor = Brushes.Gray
        contentBackground = New SolidColorBrush(Color.FromArgb(204, 255, 255, 255))
        contentForeground = Brushes.Black
    End Sub

    Public Sub CalcBorW(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer)
        If (red * 0.299 + green * 0.587 + blue * 0.114) > 186 Then
            Me.titleActiveTextColor = Brushes.Black
        Else
            Me.titleActiveTextColor = Brushes.White
        End If
    End Sub

    Public Sub GetSystemTheme()
        If Environment.OSVersion.Version.Major = 6 Then
            If Environment.OSVersion.Version.Minor = 1 Or Environment.OSVersion.Version.Minor = 0 Then '判断Windows 7或Vista
                'PASS
            Else 'Windows 8及以上版本的Win系统
                Dim FormTitleColor As Boolean = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorPrevalence", True)
                Dim A As Integer = 204
                Dim R As Integer = 255
                Dim G As Integer = 255
                Dim B As Integer = 255
                If FormTitleColor Then
                    Dim FormColorSource As String = Hex(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "ColorizationColor", Int32.Parse("FF000000", Globalization.NumberStyles.HexNumber)))
                    A = 255
                    R = Int32.Parse(FormColorSource.Substring(2, 2), Globalization.NumberStyles.HexNumber)
                    G = Int32.Parse(FormColorSource.Substring(4, 2), Globalization.NumberStyles.HexNumber)
                    B = Int32.Parse(FormColorSource.Substring(6, 2), Globalization.NumberStyles.HexNumber)
                End If
                Me.titleActiveColor = New SolidColorBrush(Color.FromArgb(A, R, G, B))
                CalcBorW(R, G, B) '设置标题栏字体颜色为黑色或白色
            End If
        End If
    End Sub

End Class
