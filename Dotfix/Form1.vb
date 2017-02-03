Public Class Form1
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Dim result As Integer
    Dim p() As Process
    Private Function CheckIfRunning()
        p = Process.GetProcessesByName("Dotfix")
        If p.Count > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckIfRunning() = True Then
            MsgBox("Another Dotfix has been running.")
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Visible = True Then
            Me.Hide()
        End If
        For i = 1 To 255
            result = 0
            result = GetAsyncKeyState(i)
            If result = -32767 Then
                If (Control.ModifierKeys And Keys.Shift) = False Then
                    If i = 190 Then
                        SendKeys.Send(".")
                    End If
                End If

            End If
        Next i
    End Sub
End Class
