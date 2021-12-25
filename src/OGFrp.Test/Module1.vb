Imports OGFrp.UI

Module Module1

    Dim FS As New FrpServer
    Dim Net As New Net
    Dim frp As New Frp

    Dim t As IEnumerable(Of FrpServerModel)

    Sub Main()
        Dim url = "https://api.ogfrp.cn/?action=getnodesidip&token="
        Console.Write("Token:")
        Dim token = Console.ReadLine()
        url = url + token
        Do
            Console.WriteLine(frp.serverToId(Console.ReadLine(), token))
        Loop
        Shell("cmd /c pause")
    End Sub

End Module
