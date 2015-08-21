<Serializable()> Public Class Dendrite

    ' Input weight
    Public weight As Double

    ' Randomize the weight upon creation
    Public Sub New()
        weight = GetRand()
    End Sub

End Class
