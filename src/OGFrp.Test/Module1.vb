Imports OGFrp.UI

Module Module1

    Dim FS As New FrpServer
    Dim Net As New Net

    Dim t As IEnumerable(Of FrpServerModel)

    Sub Main()
        Dim url = "https://api.ogfrp.cn/?action=getnodesidip&token="
        Console.Write("Token:")
        url = url + Console.ReadLine()
        t = FS.FrpsServerList(Net.Get(url))
        With New Form1
            .ComboBox1.DataSource = t
            .ComboBox1.DisplayMember = "Address"
            .ShowDialog()
        End With
        Shell("cmd /c pause")
    End Sub

End Module
