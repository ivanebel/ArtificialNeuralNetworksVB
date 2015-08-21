<Serializable()> Public Class Layer

    ' List of Neurons in layer
    Public neurons As Generic.List(Of Neuron)
    ' Number of neurons in layer
    Public neuron_count As Long

    Public Sub New()

    End Sub

    Public Sub New(ByVal num_neurons As Integer, ByVal num_dendrites As Integer)

        neuron_count = 0
        neurons = New List(Of Neuron)

        ' Add neurons with number of dendrites attatched to each neuron
        For i As Integer = 0 To num_neurons - 1
            addNeuron(num_dendrites)
        Next

    End Sub

    ' Add a neuron to the layer
    Public Sub addNeuron(ByVal num_dendrites As Integer)

        ' Add neuron with dendrties
        neurons.Add(New Neuron(num_dendrites))

        neuron_count += 1

    End Sub

    ' Process this layers neurons
    ' Input is the Output of the previous layer
    Public Function process(ByRef input As List(Of Double))

        ' Output of this layer
        Dim output As New List(Of Double)

        For i As Integer = 0 To neuron_count - 1
            ' Reset our neuron
            neurons(i).reset()

            ' For each input ( dendrite )
            ' Process the data
            For Each data As Double In input
                neurons(i).process(data)
            Next

            ' Activate our neuron
            neurons(i).activate()

            ' Add neurons output to this layers output
            output.Add(neurons(i).output)

        Next


        Return output

    End Function

    ' Returns each neurons error
    ' in a list
    Public Function getErrors()
        Dim errors As New List(Of Double)

        For Each neuron As Neuron In neurons
            errors.Add(neuron.e)
        Next

        Return errors
    End Function

    ' Returns every weight attached to a neuron
    ' at the specified index in the layer
    Public Function getWeights(ByVal index As Integer)
        Dim weights As New List(Of Double)

        For Each neuron As Neuron In neurons
            weights.Add(neuron.dendrites(index).weight)
        Next

        Return weights
    End Function

    ' Returns each neurons output
    ' in a list
    Public Function getOutputs()
        Dim outputs As New List(Of Double)

        For Each neuron As Neuron In neurons
            outputs.Add(neuron.output)
        Next

        Return outputs
    End Function

    ' Resets each neurons training data
    ' data consists
    ' e = error
    ' delta = change in weight
    Public Sub reset_training_data()
        For i As Integer = 0 To neuron_count - 1
            neurons(i).e = 0
            neurons(i).delta = 0
        Next
    End Sub


    Public Sub print()
        Console.Write(" N-" & neuron_count)
        neurons.Item(0).print()

    End Sub

End Class
