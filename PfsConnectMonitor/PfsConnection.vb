Imports System.Text

Public Class PfsConnection
    Public Property DataSource As String
    Public Property Catalog As String
    Public Property UserId As String
    Public Property Password As String
    Public Property Enabled As Boolean

    Public Function BuildIniFileSection() As String
        Dim sb As New StringBuilder()
        Dim template As String = If(Enabled, "{0}={1}", "#{0}={1}")
        sb.AppendLine(String.Format("#*** {0,-20}:{1,-20} ***", DataSource, Catalog))
        sb.AppendLine(String.Format(template, "DataSource", DataSource))
        sb.AppendLine(String.Format(template, "Catalog", Catalog))
        sb.AppendLine(String.Format(template, "UserId", UserId))
        sb.AppendLine(String.Format(template, "Password", Password))
        Return sb.ToString()
    End Function

    Public Shared Function GetNewPfsConnection(lines As IList(Of String)) As PfsConnection
        Dim pfsCn As New PfsConnection()
        pfsCn.Enabled = True
        For Each line As String In lines
            If line.Contains("DataSource") Then
                pfsCn.DataSource = line.Split("=")(1)
            ElseIf line.Contains("Catalog") Then
                pfsCn.Catalog = line.Split("=")(1)
            ElseIf line.Contains("UserId") Then
                pfsCn.UserId = line.Split("=")(1)
            ElseIf line.Contains("Password") Then
                pfsCn.Password = line.Split("=")(1)
            End If
            If line.StartsWith("#") Then
                pfsCn.Enabled = False
            End If
        Next
        Return pfsCn
    End Function
End Class
