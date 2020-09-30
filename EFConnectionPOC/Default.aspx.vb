Imports EFConnection.DataModel

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If IsPostBack = False Then

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If testSelect.SelectedIndex <> -1 Then
            If testSelect.Items(testSelect.SelectedIndex).Value = "1" Then
                SingleConnection.SetDBType("1")
                Dim db = New SafeworkEntities(SingleConnection.ConString)
                Dim language = (From lg In db.Languages Select lg).FirstOrDefault()
                Label1.Text = language.Language1
            ElseIf testSelect.Items(testSelect.SelectedIndex).Value = "2" Then
                SingleConnection.SetDBType("2")
                Dim db = New SafeworkEntities(SingleConnection.ConString)
                Dim language = (From lg In db.Languages Select lg).FirstOrDefault()
                Label1.Text = language.Language1
            End If

        End If
    End Sub

    Protected Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        Label2.Text = SingleConnection.ConString
    End Sub
End Class