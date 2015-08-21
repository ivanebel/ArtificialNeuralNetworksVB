<Serializable()> Public Class Neuron

    ' Default Bias
    Private Const default_bias As Double = -1

    ' Default Activation
    Private Const default_activation As Double = 1

    ' Each input weight for this neuron
    Public dendrites As Generic.List(Of Dendrite)

    ' Number of inputs to the neuron
    Public dendrite_count As Long

    ' dendrite pointer
    ' what weight are we on currently for data
    ' processing?
    Public d_pointer As Long

    ' Output of the neuron
    ' after activation
    Public output As Double

    ' Change in weights
    Public delta As Double

    ' Current error value of the neuron
    Public e As Double


    Public Sub New()

    End Sub

    Public Sub New(ByVal num_dendrites As Integer)
        dendrite_count = 0
        d_pointer = 0
        output = 0
        e = 0
        delta = 0
        dendrites = New List(Of Dendrite)

        ' We need an extra dendrite for the bias
        If num_dendrites > 0 Then

            For i As Integer = 0 To num_dendrites - 1
                addDendrite()
            Next
            ' Add a dendrite for the bias
            addDendrite()
        End If
    End Sub

    ' Adds a dendrite (input weight) to the neuron
    Public Sub addDendrite()
        dendrites.Add(New Dendrite())
        dendrite_count += 1
    End Sub

    ' Processes a neurons output
    ' each time this method is called

    ' output += input * weight
    Public Sub process(ByVal input As Double)

        ' If we have dendrites
        If dendrite_count > 0 Then

            ' Add to the output
            output += input * dendrites(d_pointer).weight

            ' Move our pointer to the next weight
            d_pointer += 1

            ' If we're at the end of our dendrites
            ' reset the pointer
            If d_pointer = dendrite_count - 1 Then
                d_pointer = 0
            End If
        Else
            ' We are the first layer and our input is our output
            output += input
        End If

    End Sub

    ' Activates the neuron
    ' By adding in the bias
    ' And passing the output through the sigmoid
    Public Sub activate()

        ' if we have dendrites
        If dendrite_count > 0 Then

            ' Add in the bias
            output = output + dendrites.Last().weight * default_bias

            ' Sigmoid our output
            output = sigmoid(output, default_activation)
        End If

    End Sub

    ' Resets this neuron
    Public Sub reset()
        output = 0
        d_pointer = 0
    End Sub

    ' Sigmoid activation function
    Private Function sigmoid(ByVal netinput As Double, ByVal response As Double)
        Return (1 / (1 + Math.Exp(-netinput / response)))
    End Function

    ' Alter the weights for this neuron
    ' We need the outputs of the left side layer
    ' in the network
    Public Sub alter_weights(ByRef l_outputs As List(Of Double), ByRef lr As Double)

        ' Alter each dendrite (input weight)
        For i As Integer = 0 To l_outputs.Count - 1

            ' weight += learning rate * left side output * output * (1 - output) * error
            dendrites(i).weight += lr * _
                l_outputs(i) * _
                output * (1 - output) * _
                e

        Next

        ' Alter our bias
        dendrites.Last().weight += lr * output * (1 - output) * e

    End Sub

    ' Calculate this neurons error
    ' We need outputs, weights, and errors of the right side layer
    Public Function calc_error(ByRef r_outputs As List(Of Double), _
                               ByRef r_weights As List(Of Double), _
                               ByRef r_error As List(Of Double))
        ' Sum of outputs * weights
        Dim total As Double

        ' For each neuron from the right side layer
        For i As Integer = 0 To r_outputs.Count - 1

            ' Sum ( weight * output * ( 1 - output ) * error )
            total += r_weights(i) * r_outputs(i) * (1 - r_outputs(i)) * r_error(i)

        Next

        e = total

        Return e
    End Function

    ' Calculate our output if located in output layer
    Public Function calculate_errorOutput(ByVal expected As Double)

        e = expected - output

        Return e

    End Function

    Public Sub print()
        Console.Write(" D-" & dendrite_count)
    End Sub
End Class
