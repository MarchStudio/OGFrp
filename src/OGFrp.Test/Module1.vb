Imports OGFrp.UI

Module Module1

    Dim FS As New FrpServer
    Dim Net As New Net
    Dim frp As New Frp

    Dim t As IEnumerable(Of FrpServerModel)

    Sub Main()
        Console.Write("Frpc location: ")
        Dim frpc As New Frpc(Console.ReadLine())
        Console.Write("ini Location: ")
        frpc.setIniLoca(Console.ReadLine())
        While True
            Console.Write("> ")
            Dim t As String
            t = Console.ReadLine
            Select Case t
                Case "launch"
                    Console.WriteLine(frpc.Launch())
                Case "kill"
                    frpc.Kill()
                Case "l"
                    frpc.getLog()
            End Select
        End While
    End Sub

End Module
