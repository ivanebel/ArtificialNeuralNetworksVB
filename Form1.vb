Public Class Form1
    Dim sequalit As NeuralNetwork
    Dim create As Boolean = False

    Dim letter_A As Double() = {0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1}
    Dim letter_B As Double() = {1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0}
    Dim letter_C As Double() = {1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0}
    Dim letter_D As Double() = {1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0}
    Dim letter_E As Double() = {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1}
    Dim letter_F As Double() = {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0}
    Dim letter_G As Double() = {0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0}
    Dim letter_H As Double() = {1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1}
    Dim letter_I As Double() = {0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0}
    Dim letter_J As Double() = {0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0}
    Dim letter_K As Double() = {1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0}
    Dim letter_L As Double() = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0}
    Dim letter_M As Double() = {1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1}
    Dim letter_N As Double() = {1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1}
    Dim letter_O As Double() = {0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0}
    Dim letter_P As Double() = {1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0}
    Dim letter_Q As Double() = {0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1}
    Dim letter_R As Double() = {1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0}
    Dim letter_S As Double() = {0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0}
    Dim letter_T As Double() = {1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0}
    Dim letter_U As Double() = {1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0}
    Dim letter_V As Double() = {1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0}
    Dim letter_W As Double() = {1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0}
    Dim letter_X As Double() = {1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1}
    Dim letter_Y As Double() = {1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0}
    Dim letter_Z As Double() = {1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1}

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Add(5)

        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Height = 50
        Next

        DataGridView1.ClearSelection()

        cmb1.SelectedIndex = 0

        Dim layers() As Integer = {25, 10, 26}

        sequalit = New NeuralNetwork(0.2, layers)

        create = True
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim h As Integer = e.ColumnIndex
        Dim b As Integer = e.RowIndex

        DataGridView1.ClearSelection()

        If DataGridView1.Rows(b).Cells(h).Style.BackColor <> Color.Black Then
            DataGridView1.Rows(b).Cells(h).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(b).Cells(h).Style.BackColor = Color.White
        End If

    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        'Dim h As Integer = e.ColumnIndex
        'Dim b As Integer = e.RowIndex

        'DataGridView1.ClearSelection()

        'If DataGridView1.Rows(b).Cells(h).Style.BackColor <> Color.Black Then
        '    DataGridView1.Rows(b).Cells(h).Style.BackColor = Color.Black
        'Else
        '    DataGridView1.Rows(b).Cells(h).Style.BackColor = Color.White
        'End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        'If Keys.Space Then

        '    If DataGridView1.CurrentCell.Style.BackColor <> Color.Black Then
        '        DataGridView1.CurrentCell.Style.BackColor = Color.Black
        '    Else
        '        DataGridView1.CurrentCell.Style.BackColor = Color.White
        '    End If

        'End If
    End Sub

    Private Sub cmb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb1.SelectedIndexChanged
        Select Case cmb1.SelectedIndex
            Case 0
                doubleToDGV(letter_A)
            Case 1
                doubleToDGV(letter_B)
            Case 2
                doubleToDGV(letter_C)
            Case 3
                doubleToDGV(letter_D)
            Case 4
                doubleToDGV(letter_E)
            Case 5
                doubleToDGV(letter_F)
            Case 6
                doubleToDGV(letter_G)
            Case 7
                doubleToDGV(letter_H)
            Case 8
                doubleToDGV(letter_I)
            Case 9
                doubleToDGV(letter_J)
            Case 10
                doubleToDGV(letter_K)
            Case 11
                doubleToDGV(letter_L)
            Case 12
                doubleToDGV(letter_M)
            Case 13
                doubleToDGV(letter_N)
            Case 14
                doubleToDGV(letter_O)
            Case 15
                doubleToDGV(letter_P)
            Case 16
                doubleToDGV(letter_Q)
            Case 17
                doubleToDGV(letter_R)
            Case 18
                doubleToDGV(letter_S)
            Case 19
                doubleToDGV(letter_T)
            Case 20
                doubleToDGV(letter_U)
            Case 21
                doubleToDGV(letter_V)
            Case 22
                doubleToDGV(letter_W)
            Case 23
                doubleToDGV(letter_X)
            Case 24
                doubleToDGV(letter_Y)
            Case 25
                doubleToDGV(letter_Z)
        End Select
    End Sub

    Private Sub btn_create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_create.Click
        Dim layers() As Integer = {25, 10, 26}

        sequalit = New NeuralNetwork(0.2, layers)

        create = True
    End Sub

    Private Sub btn_run_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_run.Click
        Dim myInput() As Double = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

        Dim naco As New List(Of Integer)

        For i = 0 To 4
            For j = 0 To 4
                If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Black Then
                    naco.Add(1)
                Else
                    naco.Add(0)
                End If
            Next
        Next

        If naco.Count <> 0 Then
            For i = 0 To naco.Count - 1
                myInput(i) = naco(i)
            Next
        End If

        Dim myOutput() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        Dim x() As Double
        x = sequalit.process(myInput)

        Dim strOut As String = ""
        For i = 0 To 24
            strOut = strOut & myOutput(i) & " : " & Format(x(i), "F2") & vbCrLf
        Next

        lbl_output.Text = strOut
        'lbl_output.Text = myOutput(0) & " : " & Format(x(0), "F2") & vbCrLf & myOutput(1) & " : " & Format(x(1), "F2") _
        '    & vbCrLf & myOutput(2) & " : " & Format(x(2), "F2") & vbCrLf & myOutput(3) & " : " & Format(x(3), "F2") _
        '    & vbCrLf & myOutput(4) & " : " & Format(x(4), "F2") & vbCrLf & myOutput(5) & " : " & Format(x(5), "F2") _
        '    & vbCrLf & myOutput(6) & " : " & Format(x(6), "F2") & vbCrLf & myOutput(7) & " : " & Format(x(7), "F2") _
        '    & vbCrLf & myOutput(8) & " : " & Format(x(8), "F2") & vbCrLf & myOutput(9) & " : " & Format(x(9), "F2") _
        '    & vbCrLf & myOutput(10) & " : " & Format(x(10), "F2")



    End Sub

    Private Sub btn_train_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_train.Click
        Dim inputSet As New List(Of Double())

        inputSet.Add(letter_A)
        inputSet.Add(letter_B)
        inputSet.Add(letter_C)
        inputSet.Add(letter_D)
        inputSet.Add(letter_E)
        inputSet.Add(letter_F)
        inputSet.Add(letter_G)
        inputSet.Add(letter_H)
        inputSet.Add(letter_I)
        inputSet.Add(letter_J)
        inputSet.Add(letter_K)
        inputSet.Add(letter_L)
        inputSet.Add(letter_M)
        inputSet.Add(letter_N)
        inputSet.Add(letter_O)
        inputSet.Add(letter_P)
        inputSet.Add(letter_Q)
        inputSet.Add(letter_R)
        inputSet.Add(letter_S)
        inputSet.Add(letter_T)
        inputSet.Add(letter_U)
        inputSet.Add(letter_V)
        inputSet.Add(letter_W)
        inputSet.Add(letter_X)
        inputSet.Add(letter_Y)
        inputSet.Add(letter_Z)

        Dim outputSet As New List(Of Double())
        outputSet.Add(New Double() {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})

        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0})
        outputSet.Add(New Double() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1})

        Dim ee As Double = sequalit.train(inputSet, outputSet)

        Label1.Text = Format(ee, "F2")

        btn_run_Click(sender, e)



    End Sub

    Private Sub doubleToDGV(ByVal input() As Double)
        If input(0) = 1 Then
            DataGridView1.Rows(0).Cells(0).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(0).Cells(0).Style.BackColor = Color.White
        End If
        If input(1) = 1 Then
            DataGridView1.Rows(0).Cells(1).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(0).Cells(1).Style.BackColor = Color.White
        End If
        If input(2) = 1 Then
            DataGridView1.Rows(0).Cells(2).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(0).Cells(2).Style.BackColor = Color.White
        End If
        If input(3) = 1 Then
            DataGridView1.Rows(0).Cells(3).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(0).Cells(3).Style.BackColor = Color.White
        End If
        If input(4) = 1 Then
            DataGridView1.Rows(0).Cells(4).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(0).Cells(4).Style.BackColor = Color.White
        End If
        If input(5) = 1 Then
            DataGridView1.Rows(1).Cells(0).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(1).Cells(0).Style.BackColor = Color.White
        End If
        If input(6) = 1 Then
            DataGridView1.Rows(1).Cells(1).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(1).Cells(1).Style.BackColor = Color.White
        End If
        If input(7) = 1 Then
            DataGridView1.Rows(1).Cells(2).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(1).Cells(2).Style.BackColor = Color.White
        End If
        If input(8) = 1 Then
            DataGridView1.Rows(1).Cells(3).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(1).Cells(3).Style.BackColor = Color.White
        End If
        If input(9) = 1 Then
            DataGridView1.Rows(1).Cells(4).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(1).Cells(4).Style.BackColor = Color.White
        End If
        If input(10) = 1 Then
            DataGridView1.Rows(2).Cells(0).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(2).Cells(0).Style.BackColor = Color.White
        End If
        If input(11) = 1 Then
            DataGridView1.Rows(2).Cells(1).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(2).Cells(1).Style.BackColor = Color.White
        End If
        If input(12) = 1 Then
            DataGridView1.Rows(2).Cells(2).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(2).Cells(2).Style.BackColor = Color.White
        End If
        If input(13) = 1 Then
            DataGridView1.Rows(2).Cells(3).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(2).Cells(3).Style.BackColor = Color.White
        End If
        If input(14) = 1 Then
            DataGridView1.Rows(2).Cells(4).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(2).Cells(4).Style.BackColor = Color.White
        End If
        If input(15) = 1 Then
            DataGridView1.Rows(3).Cells(0).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(3).Cells(0).Style.BackColor = Color.White
        End If
        If input(16) = 1 Then
            DataGridView1.Rows(3).Cells(1).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(3).Cells(1).Style.BackColor = Color.White
        End If
        If input(17) = 1 Then
            DataGridView1.Rows(3).Cells(2).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(3).Cells(2).Style.BackColor = Color.White
        End If
        If input(18) = 1 Then
            DataGridView1.Rows(3).Cells(3).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(3).Cells(3).Style.BackColor = Color.White
        End If
        If input(19) = 1 Then
            DataGridView1.Rows(3).Cells(4).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(3).Cells(4).Style.BackColor = Color.White
        End If
        If input(20) = 1 Then
            DataGridView1.Rows(4).Cells(0).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(4).Cells(0).Style.BackColor = Color.White
        End If
        If input(21) = 1 Then
            DataGridView1.Rows(4).Cells(1).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(4).Cells(1).Style.BackColor = Color.White
        End If
        If input(22) = 1 Then
            DataGridView1.Rows(4).Cells(2).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(4).Cells(2).Style.BackColor = Color.White
        End If
        If input(23) = 1 Then
            DataGridView1.Rows(4).Cells(3).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(4).Cells(3).Style.BackColor = Color.White
        End If
        If input(24) = 1 Then
            DataGridView1.Rows(4).Cells(4).Style.BackColor = Color.Black
        Else
            DataGridView1.Rows(4).Cells(4).Style.BackColor = Color.White
        End If

        DataGridView1.ClearSelection()


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strIni1 As String = "Dim letter_"
        Dim strIni2 As String = " As Double() = {"
        Dim strMid As String = ""
        Dim strFin As String = "x"

        Dim strIni As String = strIni1 & txtLetter.Text & strIni2

        For i = 0 To 4
            For j = 0 To 4
                If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Black Then
                    strMid = strMid & "1, "
                Else
                    strMid = strMid & "0, "
                End If
            Next
        Next

        Dim str As String = strIni & strMid ' & strFin

        Dim str2 As String = str.TrimEnd()
        Dim str3 As String = str2.Remove(str2.Length - 1, 1) & "}"

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\letras.txt", True)
        file.WriteLine(str3)
        file.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        doubleToDGV(letter_A)

    End Sub
End Class
