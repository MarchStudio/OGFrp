Imports OGFrp.UI

Module Module1

    Dim FS As New FrpServer
    Dim Net As New Net

    Sub Main()
        Dim url = "https://api.ogfrp.cn/?action=getnodesidip&token="
        Dim fmd = FS.StringToServer("1|hk1.ogfrp.cn")
        Console.Write(fmd.ToString())
        Shell("pause")
    End Sub

End Module
