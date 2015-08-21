<Serializable()> Public Class NeuralNetwork
    ' Maximum number of cycles to train for
    Const TRAINING_CYCLES As Integer = 100

    ' Our array of layers
    Public layers As Generic.List(Of Layer)

    ' How many layers
    Public layer_count As Long

    ' How many inputs to the NN
    Public input_count As Long

    ' Learning rate of the NN
    Public learning_rate As Double = 0.2

    Public Sub New()
    End Sub


    Public Sub New(ByRef lr As Double, ByRef lyrs() As Integer)

        layer_count = 0
        learning_rate = lr

        layers = New List(Of Layer)

        ' Create layers including the input layer
        ' So that the first hidden layer gets created
        ' correctly
        For Each num As Integer In lyrs
            addLayer(num)
        Next

        ' Remove the input layer since it has no dendrites
        layers.RemoveAt(0)
        layer_count -= 1

        ' Set how many inputs we have
        input_count = lyrs(0)

    End Sub

    ' Add a layer to the NN
    ' with number of neurons in this layer
    Public Sub addLayer(ByRef num_neurons As Integer)

        ' If the first layer
        ' Create a layer of neurons with no dendrites
        If layer_count = 0 Then
            layers.Add(New Layer(num_neurons, 0))

            ' Otherwise we create a layer with number of dendrites
            ' equal to the previous layer
        Else
            layers.Add(New Layer(num_neurons, layers(layer_count - 1).neuron_count))
        End If

        layer_count += 1

    End Sub

    ' Return how many weights exist in the NN
    Public Function getWeightCount()

        Dim w_count As Integer = 0

        For Each l As Layer In layers
            For Each n As Neuron In l.neurons
                For Each d As Dendrite In n.dendrites
                    w_count += 1
                Next
            Next
        Next

        Return w_count

    End Function

    ' Return a list of every single
    ' weight in the NN
    Public Function getWeights()

        Dim weights As New List(Of Double)

        For Each l As Layer In layers
            For Each n As Neuron In l.neurons
                For Each d As Dendrite In n.dendrites
                    weights.Add(d.weight)
                Next
            Next
        Next

        Return weights

    End Function

    ' Insert a list of weights into the NN
    Public Sub putWeights(ByRef weights() As Double)

        Dim lst As New List(Of Double)
        lst.AddRange(weights)
        putWeights(lst)

    End Sub

    ' Insert a list of weights into the NN
    Public Sub putWeights(ByRef weights As List(Of Double))

        Dim cWeight As Integer = 0

        For lay As Integer = 0 To layer_count - 1

            For neu As Integer = 0 To layers(lay).neuron_count - 1

                For den As Integer = 0 To layers(lay).neurons(neu).dendrite_count - 1

                    layers(lay).neurons(neu).dendrites(den).weight = weights(cWeight)
                    cWeight = cWeight + 1

                Next den
            Next neu
        Next lay

    End Sub

    ' Processes the NN with the input
    ' Returns a array of output
    Public Function process(ByVal input() As Double)

        Dim i As New List(Of Double)
        i.AddRange(input)
        Return process(i).ToArray()

    End Function

    ' Processes the NN with the input
    ' Returns a list of output
    Public Function process(ByRef input As List(Of Double))

        ' Output of a layer
        Dim layer_output As List(Of Double)

        ' our input is our first output
        layer_output = input

        ' for each layer
        ' process layer with previous output and store
        ' the new layer output
        For i As Integer = 0 To layer_count - 1
            layer_output = layers(i).process(layer_output)
        Next

        ' The last layer is our output!
        Return layer_output

    End Function

    ' Trains the NN
    ' list of inputs, and list of expected outputs
    ' returns net error of the NN
    Public Function train(ByRef input As List(Of Double()), ByRef output As List(Of Double())) As Double

        ' Net error of the NN
        Dim net_error As Double

        ' For each of our training cycles
        For cycle As Integer = 0 To TRAINING_CYCLES

            ' For each input
            For j As Integer = 0 To input.Count - 1

                ' Process our current input so we can start
                ' calculating errors
                process(input(j))

                ' Calculate error of the output layer
                For neu As Integer = 0 To layers.Last().neuron_count - 1
                    net_error += layers.Last().neurons(neu).calculate_errorOutput(output(j)(neu))
                Next

                ' Calculate error of the hidden layers
                For lay As Integer = layer_count - 2 To 0
                    For neu As Integer = 0 To layers(lay).neuron_count - 1
                        net_error += _
                            layers(lay).neurons(neu).calc_error( _
                                layers(lay + 1).getOutputs(), _
                                layers(lay + 1).getWeights(neu), _
                                layers(lay + 1).getErrors())
                    Next neu
                Next lay

                ' Alter all weights in NN

                ' The outputs of the next layer
                Dim n_outputs As New List(Of Double)

                For lay As Integer = 0 To layer_count - 1
                    For neu As Integer = 0 To layers(lay).neuron_count - 1

                        ' If first layer, we just need the inputs
                        ' Else we grab outputs of the previous layer
                        If lay = 0 Then
                            n_outputs.AddRange(input(j))
                        Else
                            n_outputs = layers(lay - 1).getOutputs()
                        End If

                        ' Alter the neurons weights
                        layers(lay).neurons(neu).alter_weights( _
                            n_outputs, learning_rate)

                        n_outputs.Clear()
                    Next neu
                Next lay

                ' Reset each layers training data
                For i As Integer = 0 To layer_count - 1
                    layers(i).reset_training_data()
                Next i

            Next j

        Next cycle

        Return net_error * -1

    End Function

    Public Sub print()
        For Each l As Layer In layers
            Console.Write("L::")
            l.print()
            Console.WriteLine()
        Next
    End Sub

End Class
