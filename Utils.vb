Module Utils
    Const XML As String = ".xml"
    Const BIN As String = ".bin"
    Dim FILENAME As String

    Dim letter_A As Double() = {0, 0, 1, 0, 0, _
                                0, 1, 0, 1, 0, _
                                1, 1, 1, 1, 1, _
                                1, 0, 0, 0, 1, _
                                1, 0, 0, 0, 1}

    Public Sub save(ByVal fn As String, ByVal type As Integer, ByRef obj As Object)
        FILENAME = fn
        If type = 0 Then
            save_xml(obj)
        Else
            save_bin(obj)
        End If
    End Sub

    Public Sub load(ByVal fn As String, ByVal type As Integer, ByRef obj As Object)
        FILENAME = fn

        If type = 0 Then
            load_xml(obj)
        Else
            load_bin(obj)
        End If
    End Sub

    Private Sub save_xml(ByRef obj As Object)
        Dim XMLS As New Xml.Serialization.XmlSerializer(obj.GetType())
        Dim SW As New IO.StringWriter()

        XMLS.Serialize(SW, obj)

        My.Computer.FileSystem.WriteAllText(FILENAME & XML, SW.ToString(), False)
    End Sub

    Private Sub load_xml(ByRef obj As Object)
        Dim XMLS As New Xml.Serialization.XmlSerializer(obj.GetType())
        Dim data As String = My.Computer.FileSystem.ReadAllText(FILENAME & XML)
        Dim SR As New IO.StringReader(data)

        obj = XMLS.Deserialize(SR)
    End Sub
    Private Sub save_bin(ByRef obj As Object)
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim MS As New System.IO.MemoryStream()

        'Serialization is first in memory,
        'then written to the binary file
        BF.Serialize(MS, obj)
        My.Computer.FileSystem.WriteAllBytes(FILENAME & BIN, MS.GetBuffer(), False)
    End Sub
    Private Sub load_bin(ByRef obj As Object)
        Dim BF As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim MS As New System.IO.MemoryStream()

        Dim bytes As Byte() = My.Computer.FileSystem.ReadAllBytes(FILENAME & BIN)
        obj = BF.Deserialize(New System.IO.MemoryStream(bytes))

        'DirectCast(BF.Deserialize(New System.IO.MemoryStream(bytes)), )
    End Sub

    Function GetRand() As Double
        Randomize()
        GetRand = 2 - (1 + Rnd() + Rnd())
    End Function
End Module
