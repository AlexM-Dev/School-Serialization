<Serializable()>
Public Class Member
    Public Property FirstName As String
    Public Property LastName As String
    Public Sub New()

    End Sub
    Public Sub New(first As String, last As String)
        Me.FirstName = first
        Me.LastName = last
    End Sub
End Class
