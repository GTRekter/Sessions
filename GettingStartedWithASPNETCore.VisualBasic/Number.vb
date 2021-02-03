Public Class Number
    Public Shared Function IsPrime(ByVal number As Integer) As Boolean
        Dim primeI As Integer
        Dim primeFlag As Boolean
        primeFlag = True
        For primeI = 2 To number / 2
            If number Mod primeI = 0 Then
                Return False
            End If
        Next
        Return primeFlag
    End Function
End Class
