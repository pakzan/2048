Public Class Form1
    Dim m(50, 50) As Label
    Dim s(50, 50), x(50, 50) As Integer
    Dim lb As Integer
    Dim lb1 As Single
    Dim a, b, c, d As New Byte
    Dim rnd As New Random
    Dim box As String
    Dim endcount As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        box = InputBox("Input your box num")

        If Me.Height >= Me.Width Then
            lb = (Me.Width - 200) / Val(box)
        ElseIf Me.Width > Me.Height Then
            lb = (Me.Height - 200) / Val(box)
        End If

        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                Dim var As New Label
                var.Font = New Font("Times new roman", 15, FontStyle.Regular)
                var.TextAlign = ContentAlignment.MiddleCenter
                var.ForeColor = Color.White
                var.Size = New Size(lb - 2, lb - 2)
                var.Location = New Point((Me.Width - Val(box) * lb) / 2 + i * lb - 10, (Me.Height - Val(box) * lb) / 2 + j * lb - 10)
                var.BackColor = Color.Aquamarine
                m(i, j) = var
                s(i, j) = 0
                Me.Controls.Add(m(i, j))
            Next
        Next
        create()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim bHandled As Boolean = False
        If timerup.Enabled = True Or timerdown.enabled = True Or timerleft.enabled = True Or timerright.enabled = True Then
            Return
        End If
        Select Case e.KeyCode
            Case Keys.Right
                timerright.start()
                e.Handled = True
            Case Keys.Left
                timerleft.start()
                e.Handled = True
            Case Keys.Up
                timerup.Start()
                e.Handled = True
            Case Keys.Down
                timerdown.start()
                e.Handled = True
        End Select
        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                x(i, j) = 0
            Next
        Next
        score()
    End Sub

    Private Sub create()
        Do
            a = rnd.Next(0, Val(box))
            b = rnd.Next(0, Val(box))
            c = rnd.Next(1, 3)
        Loop Until m(a, b).Text = ""
        If c = 1 Then
            m(a, b).Text = "2"
        ElseIf c = 2 Then
            m(a, b).Text = "4"
        End If
        recolour()
        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                If m(i, j).Text = "" Then
                    s(i, j) = 0
                Else
                    s(i, j) = m(i, j).Text
                End If
            Next
        Next

    End Sub
    Private Sub recolour()


        If Me.Height >= Me.Width Then
            lb1 = (((Me.Width - 200) / Val(box)) - 2) / 60
        ElseIf Me.Width > Me.Height Then
            lb1 = (((Me.Height - 200) / Val(box)) - 2) / 60
        End If

        If lb1 <= 0 Then
            Return
        End If
        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                Select Case Len(m(i, j).Text)
                    Case Is = 1
                        m(i, j).Font = New Font("Times new roman", 18 * lb1, FontStyle.Regular)
                    Case Is = 2
                        m(i, j).Font = New Font("Times new roman", 16 * lb1, FontStyle.Regular)
                    Case Is = 3
                        m(i, j).Font = New Font("Times new roman", 14 * lb1, FontStyle.Regular)
                    Case Is = 4
                        m(i, j).Font = New Font("Times new roman", 12 * lb1, FontStyle.Regular)
                    Case Is = 5
                        m(i, j).Font = New Font("Times new roman", 10 * lb1, FontStyle.Regular)
                End Select

                Select Case m(i, j).Text
                    Case Is = ""
                        m(i, j).BackColor = Color.Aquamarine
                        m(i, j).ForeColor = Color.White
                    Case Is = "2"
                        m(i, j).BackColor = Color.DeepSkyBlue
                        m(i, j).ForeColor = Color.White
                    Case Is = "4"
                        m(i, j).BackColor = Color.DodgerBlue
                        m(i, j).ForeColor = Color.White
                    Case Is = "8"
                        m(i, j).BackColor = Color.RoyalBlue
                        m(i, j).ForeColor = Color.WhiteSmoke
                    Case Is = "16"
                        m(i, j).BackColor = Color.Navy
                        m(i, j).ForeColor = Color.WhiteSmoke
                    Case Is = "32"
                        m(i, j).BackColor = Color.MediumBlue
                        m(i, j).ForeColor = Color.WhiteSmoke
                    Case Is = "64"
                        m(i, j).BackColor = Color.SlateBlue
                        m(i, j).ForeColor = Color.WhiteSmoke
                    Case Is = "128"
                        m(i, j).BackColor = Color.BlueViolet
                        m(i, j).ForeColor = Color.Yellow
                    Case Is = "256"
                        m(i, j).BackColor = Color.MediumOrchid
                        m(i, j).ForeColor = Color.Yellow
                    Case Is = "512"
                        m(i, j).BackColor = Color.Purple
                        m(i, j).ForeColor = Color.Yellow
                    Case Is = "1024"
                        m(i, j).BackColor = Color.YellowGreen
                        m(i, j).ForeColor = Color.Maroon
                    Case Is = "2048"
                        m(i, j).BackColor = Color.ForestGreen
                        m(i, j).ForeColor = Color.Maroon
                    Case Is = "4096"
                        m(i, j).BackColor = Color.DarkGreen
                        m(i, j).ForeColor = Color.LightGreen
                    Case Is = "8192"
                        m(i, j).BackColor = Color.DarkRed
                        m(i, j).ForeColor = Color.GreenYellow
                End Select
            Next

        Next
    End Sub
    Private Sub score()
        Dim s1 As Integer
        Dim s2 As Byte
        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                s1 = s1 + Val(m(i, j).Text)
            Next
        Next
        label1.Text = "Score: " + Str(s1)

        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                If m(i, j).Text = "" Then
                    s2 = 1
                End If
                If i < Val(box - 1) Then
                    If m(i, j).Text = m(i + 1, j).Text Then
                        s2 = 1
                    End If
                End If
                If j < Val(box - 1) Then
                    If m(i, j).Text = m(i, j + 1).Text Then
                        s2 = 1
                    End If
                End If
            Next
        Next
        If s2 = 0 Then
            MsgBox("You lose!", MsgBoxStyle.OkOnly, "LOSE!")
        End If

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Val(box) = 0 Then
            Return
        End If
        If Me.Height > Me.Width Then
            lb = (Me.Width - 200) / Val(box)
        ElseIf Me.Width > Me.Height Then
            lb = (Me.Height - 200) / Val(box)
        End If

        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                Me.Controls.Remove(m(i, j))
                Dim var As New Label
                var.Font = New Font("Times new roman", 15, FontStyle.Regular)
                var.TextAlign = ContentAlignment.MiddleCenter
                var.ForeColor = Color.White
                var.Size = New Size(lb - 2, lb - 2)
                var.Location = New Point((Me.Width - Val(box) * lb) / 2 + i * lb - 10, (Me.Height - Val(box) * lb) / 2 + j * lb - 10)
                var.BackColor = Color.Aquamarine
                m(i, j) = var
                m(i, j).Text = s(i, j)
                If m(i, j).Text = "0" Then
                    m(i, j).Text = ""
                End If
                Me.Controls.Add(m(i, j))
            Next
        Next
        recolour()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerup.Tick
        endcount = 1
        For j = 0 To Val(box - 1)
            For i = 0 To Val(box - 1)
                If m(i, j).Text <> "" Then
                    Dim n As New Byte
                    For z = Val(box - 2) To 0 Step -1
                        If j > z And n = 0 Then
                            If m(i, z).Text = "" Then
                                m(i, z).Text = m(i, z + 1).Text
                                m(i, z + 1).Text = ""
                                n = 1
                                endcount = 0
                            ElseIf m(i, z).Text = m(i, z + 1).Text And x(i, z) = 0 And x(i, z + 1) = 0 Then
                                m(i, z).Text = Val(m(i, z).Text) + Val(m(i, z + 1).Text)
                                x(i, z) = 1
                                m(i, z + 1).Text = ""
                                n = 1
                            ElseIf m(i, z).Text <> m(i, z + 1).Text Then
                                n = 1
                            End If
                        End If
                    Next
                End If
            Next
        Next

        recolour()
        If endcount = 1 Then
            Dim g As Integer
            For i = 0 To Val(box - 1)
                For j = 0 To Val(box - 1)
                    If m(i, j).Text = "" Then
                        m(i, j).Text = "0"
                    End If
                    If s(i, j) = m(i, j).Text Then
                        g = g + 1
                    End If
                    If m(i, j).Text = "0" Then
                        m(i, j).Text = ""
                    End If
                Next
            Next
            timerup.Stop()
            If g = Val(box) ^ 2 Then
                Return
            End If
            create()
            endcount = 0
        End If
    End Sub
    Private Sub Timerdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerdown.Tick
        endcount = 1
        For j = Val(box - 1) To 0 Step -1
            For i = 0 To Val(box - 1)
                If m(i, j).Text <> "" Then
                    Dim n As New Byte
                    For z = 1 To Val(box - 1)
                        If j < z And n = 0 Then
                            If m(i, z).Text = "" Then
                                m(i, z).Text = m(i, z - 1).Text
                                m(i, z - 1).Text = ""
                                n = 1
                                endcount = 0
                            ElseIf m(i, z).Text = m(i, z - 1).Text And x(i, z) = 0 And x(i, z - 1) = 0 Then
                                m(i, z).Text = Val(m(i, z).Text) + Val(m(i, z - 1).Text)
                                m(i, z - 1).Text = ""
                                x(i, z) = 1
                                n = 1
                            ElseIf m(i, z).Text <> m(i, z - 1).Text Then
                                n = 1
                            End If
                        End If
                    Next
                End If
            Next
        Next
        recolour()
        If endcount = 1 Then
            Dim g As Integer
            For i = 0 To Val(box - 1)
                For j = 0 To Val(box - 1)
                    If m(i, j).Text = "" Then
                        m(i, j).Text = "0"
                    End If
                    If s(i, j) = m(i, j).Text Then
                        g = g + 1
                    End If
                    If m(i, j).Text = "0" Then
                        m(i, j).Text = ""
                    End If
                Next
            Next
            Timerdown.Stop()
            If g = Val(box) ^ 2 Then
                Return
            End If
            create()
            endcount = 0
        End If
    End Sub
    Private Sub Timerleft_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerleft.Tick
        endcount = 1
        For i = 0 To Val(box - 1)
            For j = 0 To Val(box - 1)
                If m(i, j).Text <> "" Then
                    Dim n As New Byte
                    For z = Val(box - 2) To 0 Step -1
                        If i > z And n = 0 Then
                            If m(z, j).Text = "" Then
                                m(z, j).Text = m(z + 1, j).Text
                                m(z + 1, j).Text = ""
                                n = 1
                                endcount = 0
                            ElseIf m(z, j).Text = m(z + 1, j).Text And x(z, j) = 0 And x(z + 1, j) = 0 Then
                                m(z, j).Text = Val(m(z, j).Text) + Val(m(z + 1, j).Text)
                                x(z, j) = 1
                                m(z + 1, j).Text = ""
                                n = 1
                            ElseIf m(z, j).Text <> m(z + 1, j).Text Then
                                n = 1
                            End If
                        End If
                    Next
                End If
            Next
        Next
        recolour()
        If endcount = 1 Then
            Dim g As Integer
            For i = 0 To Val(box - 1)
                For j = 0 To Val(box - 1)
                    If m(i, j).Text = "" Then
                        m(i, j).Text = "0"
                    End If
                    If s(i, j) = m(i, j).Text Then
                        g = g + 1
                    End If
                    If m(i, j).Text = "0" Then
                        m(i, j).Text = ""
                    End If
                Next
            Next
            Timerleft.Stop()
            If g = Val(box) ^ 2 Then
                Return
            End If
            create()
            endcount = 0
        End If
    End Sub
    Private Sub Timerright_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerright.Tick
        endcount = 1
        For i = Val(box - 1) To 0 Step -1
            For j = 0 To Val(box - 1)
                If m(i, j).Text <> "" Then
                    Dim n As New Byte
                    For z = 1 To Val(box - 1)
                        If i < z And n = 0 Then
                            If m(z, j).Text = "" Then
                                m(z, j).Text = m(z - 1, j).Text
                                m(z - 1, j).Text = ""
                                n = 1
                                endcount = 0
                            ElseIf m(z, j).Text = m(z - 1, j).Text And x(z, j) = 0 And x(z - 1, j) = 0 Then
                                m(z, j).Text = Val(m(z, j).Text) + Val(m(z - 1, j).Text)
                                x(z, j) = 1
                                m(z - 1, j).Text = ""
                                n = 1
                            ElseIf m(z, j).Text <> m(z - 1, j).Text Then
                                n = 1
                            End If
                        End If
                    Next
                End If
            Next
        Next
        recolour()
        If endcount = 1 Then
            Dim g As Integer
            For i = 0 To Val(box - 1)
                For j = 0 To Val(box - 1)
                    If m(i, j).Text = "" Then
                        m(i, j).Text = "0"
                    End If
                    If s(i, j) = m(i, j).Text Then
                        g = g + 1
                    End If
                    If m(i, j).Text = "0" Then
                        m(i, j).Text = ""
                    End If
                Next
            Next
            Timerright.Stop()
            If g = Val(box) ^ 2 Then
                Return
            End If
            create()
            endcount = 0
        End If
    End Sub
End Class
