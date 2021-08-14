Imports System.Data
Imports System.Data.SqlClient

Public Class UASApp
    Dim objCmd As New SqlCommand
    Dim objDataAdapter As New SqlDataAdapter
    Dim objDataSet As New DataSet
    Dim objDataTable As New DataTable
    Dim dbSql As New Conection.Config
    Dim strSql As String

    Private Sub UASApp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call clearGrade()
    End Sub
    Private Sub clearGrade()
        tbNoAngg.Text = ""
        tbNmAngg.Text = ""
        tbAlamAngg.Text = ""
        cbJenisKel.Text = "Laki-Laki"
        tbNoAngg.Enabled = False
        tbNmAngg.Enabled = False
        tbAlamAngg.Enabled = False
        cbJenisKel.Enabled = False
        btnNew.Text = "&New"
        btnSave.Text = "&Save"
        btnEdit.Enabled = False
        btnSave.Enabled = False
        btnDelete.Enabled = False

        Call dgPerpus()
    End Sub
    Private Sub executeCRUDGrade()
        dbSql.UnCon()
        objCmd.CommandText = strSql
        objCmd.Connection = dbSql.con
        objCmd.ExecuteNonQuery()
        dbSql.UnCon()
        strSql = ""
    End Sub
    Private Sub dgPerpus()
        On Error Resume Next
        objDataTable.Clear()
        strSql = "SELECT * FROM TblAnggota"
        objCmd.Connection = dbSql.con
        objCmd.CommandType = CommandType.Text
        objCmd.CommandText = strSql
        objDataAdapter = New SqlDataAdapter(objCmd)
        objDataAdapter.Fill(objDataSet, "dgPerpus")
        dbSql.UnCon()
        objDataTable = objDataSet.Tables("dgPerpus")
        DataGridView1.DataSource = objDataTable
        strSql = ""
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "&New" Then

            btnNew.Text = "&Cancel"
            tbNoAngg.Enabled = True

            tbNoAngg.Focus()
        Else
            Call clearGrade()
        End If
    End Sub

    Private Sub tbNoAngg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbNoAngg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            tbNmAngg.Enabled = True
            tbNmAngg.Focus()
        End If

    End Sub

    Private Sub tbNmAngg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbNmAngg.KeyPress
        If e.KeyChar = Chr(13) Then
            cbJenisKel.Enabled = True
            tbAlamAngg.Enabled = True

        End If
    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "&Save" Then
            'Save Table
            strSql = "INSERT INTO TblAnggota (NoAngg, NmAngg, AlmtAngg, JnsKel) VALUES ('" & tbNoAngg.Text & "', '" & tbNmAngg.Text & "','" & tbAlamAngg.Text & "','" & cbJenisKel.Text & "')"
            Call executeCRUDGrade()
            MsgBox("Data Has Been Saved", vbInformation)
        Else
            'Update Data
            strSql = "UPDATE TblAnggota SET NoAngg = '" & tbNoAngg.Text & "', NmAngg = '" & tbNmAngg.Text & "', AlmtAngg = '" & tbAlamAngg.Text & "', JnsKel = '" & cbJenisKel.Text & "' " _
                & " WHERE NoAngg = '" & tbNoAngg.Text & "'"
            Call executeCRUDGrade()
            MsgBox("Data Updated", vbInformation)
        End If
        Call clearGrade()
    End Sub

    Private Sub tbAlamAngg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbAlamAngg.KeyPress
        If e.KeyChar = Chr(13) Then

            btnSave.Enabled = True
            btnSave.Focus()

        End If
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        ' menampilkan data di kolom input
        With DataGridView1

            Dim sRow As Integer = .CurrentRow.Index
            tbNoAngg.Text = .Item(0, sRow).Value
            tbNmAngg.Text = .Item(1, sRow).Value
            cbJenisKel.Text = .Item(2, sRow).Value
            tbAlamAngg.Text = .Item(2, sRow).Value

            btnNew.Text = "&Cancel"
            btnEdit.Enabled = True
            btnDelete.Enabled = True

        End With
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click

        btnSave.Enabled = True
        btnDelete.Enabled = True
        btnSave.Text = "&Update"
        tbNoAngg.Enabled = True
        tbNmAngg.Enabled = True
        tbAlamAngg.Enabled = True
        cbJenisKel.Enabled = True

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim mYes_No As String = MsgBox("Are you sure you want to delete this ?", vbYesNo)
        If mYes_No = vbYes Then
            strSql = "DELETE FROM TblAnggota WHERE NoAngg = '" & tbNoAngg.Text & "'"
            Call executeCRUDGrade()
            MsgBox("Data Has been deleted", vbInformation)
            Call clearGrade()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles btnSave.KeyPress
        If btnSave.Text = "&Save" Then
            'Save Table
            strSql = "INSERT INTO TblAnggota (NoAngg, NmAngg, AlmtAngg, JnsKel) VALUES ('" & tbNoAngg.Text & "', '" & tbNmAngg.Text & "','" & tbAlamAngg.Text & "','" & cbJenisKel.Text & "')"
            Call executeCRUDGrade()
            MsgBox("Data Has Been Saved", vbInformation)
        Else
            'Update Data
            strSql = "UPDATE TblAnggota SET NoAngg = '" & tbNoAngg.Text & "', NmAngg = '" & tbNmAngg.Text & "', AlmtAngg = '" & tbAlamAngg.Text & "', JnsKel = '" & cbJenisKel.Text & "' " _
                & " WHERE NoAngg = '" & tbNoAngg.Text & "'"
            Call executeCRUDGrade()
            MsgBox("Data Updated", vbInformation)
        End If
        Call clearGrade()
    End Sub
End Class
