Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports Newtonsoft.Json

Public Class frmMain
    Private Sub itmAdd_Click(sender As Object, e As EventArgs) Handles itmAdd.Click
        '' Load member.
        Dim m As Member = frmEdit.ShowEditor()

        LoadMembers(New List(Of Member)({m}))
    End Sub

    Private Sub itmEdit_Click(sender As Object, e As EventArgs) Handles itmEdit.Click
        If lvwMembers.SelectedIndices.Count > 0 Then
            Dim l As ListViewItem = lvwMembers.SelectedItems(0)

            '' Editor only supports the editing of 2 properties right now.
            '' Not very dynamic.
            Dim m As Member = frmEdit.ShowEditor(l.SubItems(1).Text,
                                                 l.SubItems(2).Text)

            LoadMembers(New List(Of Member)({m}))
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetWindowTheme(lvwMembers.Handle, "explorer", Nothing)

        Dim pl = GetType(Member).GetProperties()
        For Each p In pl
            Dim s As String = p.Name
            Dim builder = New StringBuilder()
            For i = 0 To s.Length - 1
                '' If it's a capital, prepend a space.
                '' Makes it more readable.
                If (Char.IsUpper(s(i))) Then
                    builder.Append(" "c)
                End If
                builder.Append(s(i))
            Next

            '' Add the column with the name.
            lvwMembers.Columns.Add(builder.ToString().Trim)
        Next
    End Sub

    Private Sub itmRemove_Click(sender As Object, e As EventArgs) Handles itmRemove.Click
        '' Remove all selected items.
        For Each l As ListViewItem In lvwMembers.SelectedItems
            lvwMembers.Items.Remove(l)
        Next
    End Sub

    Private Sub itmClear_Click(sender As Object, e As EventArgs) Handles itmClear.Click
        lvwMembers.Items.Clear()
    End Sub

    Private Sub itmExit_Click(sender As Object, e As EventArgs) Handles itmExit.Click
        Me.Close()
    End Sub

    Private Sub itmSave_Click(sender As Object, e As EventArgs) Handles itmSave.Click
        Using sfd As New SaveFileDialog()
            sfd.Filter = "Comma-Separated Values Files (*.csv)|*.csv|" &
                         "Extensible Markup Language Files (*.XML)|*.xml|" &
                         "JavaScript Object Notation (*.json)|*.json|" &
                         "Other Files (Binary)|*.*"
            sfd.Title = "Save Members"
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim fi As New FileInfo(sfd.FileName)
                Select Case fi.Extension
                    Case ".csv"
                        '' Serialise as a CSV file.
                        Dim nl = Environment.NewLine
                        Dim builder As New StringBuilder()
                        For Each l As ListViewItem In lvwMembers.Items
                            Dim si = l.SubItems
                            For i = 1 To si.Count - 1
                                builder.Append(si(i).Text.Replace(",", "<comma>"))
                                If (i < si.Count - 1) Then
                                    builder.Append(",")
                                End If
                            Next
                            builder.AppendLine()
                        Next
                        File.WriteAllText(sfd.FileName, builder.ToString())
                    Case ".xml"
                        '' Serialise as an XML file.
                        '' Convert list of items to list of members
                        Dim ser As New XmlSerializer(GetType(List(Of Member)))
                        Dim writer As TextWriter = New StreamWriter(sfd.FileName)
                        ser.Serialize(writer, GetMembers())
                        writer.Close()
                    Case ".json"
                        '' Serialise as a JSON file.
                        Dim contents As String = JsonConvert.SerializeObject(GetMembers())
                        File.WriteAllText(sfd.FileName, contents)
                    Case Else
                        '' Serialise as a binary file.
                        Dim bin As New BinaryFormatter()
                        Dim fs As New FileStream(sfd.FileName, FileMode.Create)
                        bin.Serialize(fs, GetMembers())
                        fs.Close()
                End Select
            End If
        End Using
    End Sub

    Private Sub ItmLoad_Click(sender As Object, e As EventArgs) Handles ItmLoad.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Comma-Separated Values Files (*.csv)|*.csv|" &
                         "Extensible Markup Language Files (*.XML)|*.xml|" &
                         "JavaScript Object Notation (*.json)|*.json|" &
                         "Other Files (Binary)|*.*"
            ofd.Title = "Load Members"
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim fi As New FileInfo(ofd.FileName)
                Dim lv As New List(Of Member)
                Select Case fi.Extension
                    Case ".csv"
                        '' Load from csv file.
                        '' We're doing a blind read here.
                        '' We're only using the indexes.
                        Dim read = File.ReadAllLines(ofd.FileName)
                        For Each value In read
                            Dim member As New Member()
                            Dim pi = GetType(Member).GetProperties()
                            Dim arr = value.Split(","c)
                            For i = 0 To pi.Count - 1
                                pi(i).SetValue(member, arr(i))
                            Next
                            lv.Add(member)
                        Next
                    Case ".xml"
                        '' Load from XML file.
                        Dim ser As New XmlSerializer(GetType(List(Of Member)))
                        Dim reader As TextReader = New StreamReader(ofd.FileName)
                        lv = ser.Deserialize(reader)
                        reader.Close()
                    Case ".json"
                        '' Load from JSON file.
                        Dim contents As String = File.ReadAllText(ofd.FileName)
                        lv = JsonConvert.DeserializeObject(Of List(Of Member))(contents)
                    Case Else
                        '' Load from binary file.
                        Dim bin As New BinaryFormatter()
                        Dim fs As New FileStream(ofd.FileName, FileMode.Open)
                        lv = bin.Deserialize(fs)
                        fs.Close()
                End Select

                LoadMembers(lv)
            End If
        End Using
    End Sub

    Function GetMembers() As List(Of Member)
        Dim members As New List(Of Member)
        For Each l As ListViewItem In lvwMembers.Items
            Dim m As New Member(l.SubItems(1).Text, l.SubItems(2).Text)
            members.Add(m)
        Next
        Return members
    End Function
    Sub LoadMembers(lm As List(Of Member))
        lvwMembers.Items.Clear()
        For Each m In lm
            Dim l As New ListViewItem
            l.Text = lvwMembers.Items.Count

            '' Dynamic property matching.
            '' For all the properties in Member, add a subitem.
            For Each p In m.GetType().GetProperties
                l.SubItems.Add(p.GetValue(m))
            Next

            lvwMembers.Items.Add(l)
        Next
    End Sub
End Class
