Module Module1
    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)
    Sub Main()
        Shell("cmd /c curl https://api.oldgod.cn/?f=/OGFrp/frp_0.37.1_windows_amd64/frpc.exe --output %temp%\frpc.exe", vbHide)
        Shell("cmd /c curl https://api.oldgod.cn/?f=/OGFrp/ini/XGChemPixel.ini --output %temp%\frpc.ini", vbHide)
        Sleep(10000)
        Shell("cmd /c %temp%\frpc.exe -c %temp%\frpc.ini", vbNormalFocus)

    End Sub

End Module
