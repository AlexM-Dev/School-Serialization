Public Class frmEdit
    Private _FirstName As String
    Private _LastName As String
    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            txtFirstName.Text = value
            _FirstName = value
        End Set
    End Property
    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            txtLastName.Text = value
            _LastName = value
        End Set
    End Property
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(first As String, last As String)
        InitializeComponent()

        FirstName = first
        LastName = last
    End Sub

    Public Shared Function ShowEditor(Optional first As String = "",
                                      Optional last As String = "") As Member
        Dim editor As New frmEdit(first, last)
        editor.ShowDialog()

        Return New Member(editor.FirstName, editor.LastName)
    End Function

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        FirstName = txtFirstName.Text
        LastName = txtLastName.Text

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class