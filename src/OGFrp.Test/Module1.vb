Imports OGFrp.UI

Module Module1

    Sub Main()
        Console.WriteLine("Token: ")
        Dim fctn As New FrpcCollections(Console.ReadLine())
        fctn.getFrpcConfigCollection()
        Dim ctn = fctn.GetProxyCtn()
        For Each ts In ctn
            Console.WriteLine(ts)
            Console.WriteLine("-------------")
        Next
        Console.Read()
    End Sub

End Module
