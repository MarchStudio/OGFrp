Imports System
Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic

Module Main

    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)

    Function CreateFolder(ByVal FolderPath As String) As String
        Try
            If Directory.Exists(path) = False Then
                Directory.CreateDirectory(path)
            End If
        Catch ex As Exception
            Return "Error while creating folder!" + vbCrLf + "Detail:" + ex.ToString()
        End Try
        Return "Program folder created."
    End Function

    Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\OGFrp"

    Sub Main()
        Console.WriteLine("OGfrp is now running.")
        Console.WriteLine(CreateFolder(path))
        Dim ini As String
        Console.WriteLine("Please Enter ini code.")
        ini = Console.ReadLine()
        Try
            Dim CLient As New WebClient
            Console.WriteLine("Now downloading ini file:" + ini + "...")
            CLient.DownloadFile("https://api.oldgod.cn/?f=/OGFrp/ini/" & ini, path + "frpc.ini")
            Console.WriteLine("ini file downloaded, now downloading frpc.exe")
            CLient.DownloadFile("https://api.oldgod.cn/?f=/OGFrp/frpc.exe", path + "\frpc.exe")
            Console.WriteLine("All files downloaded!")
            CLient.Dispose()
        Catch ex As Exception
            Console.WriteLine("Download failed!")
            Console.WriteLine("Detail:" + ex.ToString)
            Console.WriteLine("Press enter to continue.")
            Console.Read()
        End Try
        Console.WriteLine("Now starting frpc.exe...")
        Shell(path & "\frpc.exe" & " -c " + path + "\frpc.ini")
    End Sub

End Module
