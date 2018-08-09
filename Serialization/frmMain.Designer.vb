<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lvwMembers = New System.Windows.Forms.ListView()
        Me.cmnID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.hdrFile = New System.Windows.Forms.MenuItem()
        Me.itmSave = New System.Windows.Forms.MenuItem()
        Me.ItmLoad = New System.Windows.Forms.MenuItem()
        Me.sepFile = New System.Windows.Forms.MenuItem()
        Me.itmExit = New System.Windows.Forms.MenuItem()
        Me.hdrEdit = New System.Windows.Forms.MenuItem()
        Me.itmAdd = New System.Windows.Forms.MenuItem()
        Me.itmEdit = New System.Windows.Forms.MenuItem()
        Me.itmRemove = New System.Windows.Forms.MenuItem()
        Me.sepEdit = New System.Windows.Forms.MenuItem()
        Me.itmClear = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'lvwMembers
        '
        Me.lvwMembers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwMembers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cmnID})
        Me.lvwMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwMembers.FullRowSelect = True
        Me.lvwMembers.Location = New System.Drawing.Point(0, 0)
        Me.lvwMembers.Name = "lvwMembers"
        Me.lvwMembers.Size = New System.Drawing.Size(243, 338)
        Me.lvwMembers.TabIndex = 1
        Me.lvwMembers.UseCompatibleStateImageBehavior = False
        Me.lvwMembers.View = System.Windows.Forms.View.Details
        '
        'cmnID
        '
        Me.cmnID.Text = "#"
        Me.cmnID.Width = 29
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.hdrFile, Me.hdrEdit})
        '
        'hdrFile
        '
        Me.hdrFile.Index = 0
        Me.hdrFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.itmSave, Me.ItmLoad, Me.sepFile, Me.itmExit})
        Me.hdrFile.Text = "File"
        '
        'itmSave
        '
        Me.itmSave.Index = 0
        Me.itmSave.Text = "Save"
        '
        'ItmLoad
        '
        Me.ItmLoad.Index = 1
        Me.ItmLoad.Text = "Load"
        '
        'sepFile
        '
        Me.sepFile.Index = 2
        Me.sepFile.Text = "-"
        '
        'itmExit
        '
        Me.itmExit.Index = 3
        Me.itmExit.Text = "Exit"
        '
        'hdrEdit
        '
        Me.hdrEdit.Index = 1
        Me.hdrEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.itmAdd, Me.itmEdit, Me.itmRemove, Me.sepEdit, Me.itmClear})
        Me.hdrEdit.Text = "Edit"
        '
        'itmAdd
        '
        Me.itmAdd.Index = 0
        Me.itmAdd.Text = "Add Member"
        '
        'itmEdit
        '
        Me.itmEdit.Index = 1
        Me.itmEdit.Text = "Edit Member"
        '
        'itmRemove
        '
        Me.itmRemove.Index = 2
        Me.itmRemove.Text = "Remove Member"
        '
        'sepEdit
        '
        Me.sepEdit.Index = 3
        Me.sepEdit.Text = "-"
        '
        'itmClear
        '
        Me.itmClear.Index = 4
        Me.itmClear.Text = "Clear Members"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 338)
        Me.Controls.Add(Me.lvwMembers)
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.Text = "Serialization"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwMembers As ListView
    Friend WithEvents cmnID As ColumnHeader
    Friend WithEvents mnuMain As MainMenu
    Friend WithEvents hdrFile As MenuItem
    Friend WithEvents itmSave As MenuItem
    Friend WithEvents ItmLoad As MenuItem
    Friend WithEvents sepFile As MenuItem
    Friend WithEvents itmExit As MenuItem
    Friend WithEvents hdrEdit As MenuItem
    Friend WithEvents itmAdd As MenuItem
    Friend WithEvents itmEdit As MenuItem
    Friend WithEvents itmRemove As MenuItem
    Friend WithEvents sepEdit As MenuItem
    Friend WithEvents itmClear As MenuItem
End Class
