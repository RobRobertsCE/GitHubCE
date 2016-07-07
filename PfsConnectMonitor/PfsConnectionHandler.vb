Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class PfsConnectionHandler

    Private Const IniFilePath As String = "C:\PFSCommon\PfsConnect.ini"
    Private Const JsonFilePath As String = "C:\PFSCommon\PfsConnect.json"

    Private ReadOnly _pfsConnections As IList(Of PfsConnection)

    Sub New()
        _pfsConnections = New List(Of PfsConnection)
        LoadPfsConnections()
        ReadPfsConnectFile()
    End Sub

    Private Sub ExceptionHandler(ex As Exception)
        Console.WriteLine(ex.ToString())
    End Sub

    Protected Overridable Sub WritePfsConnectFile(pfsCn As PfsConnection)
        Try
            ' ReSharper disable once VBReplaceWithSingleCallToCount
            If Not _pfsConnections.Where(Function(c) c.Enabled = True).Count() = 1 Then
                Throw New InvalidOperationException("Connection list must have one and only one enabled connection!")
            End If
            File.WriteAllText(IniFilePath, Me.ToString())
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Protected Overridable Sub LoadPfsConnections()
        If File.Exists(JsonFilePath) Then
            Dim json = File.ReadAllText(JsonFilePath)
            Dim connections = JsonConvert.DeserializeObject(Of IList(Of PfsConnection))(json)
            AddPfsConnections(connections)
        End If
    End Sub

    Protected Overridable Sub SavePfsConnections()
        Try
            Dim pfsConnectJson = JsonConvert.SerializeObject(_pfsConnections)
            File.WriteAllText(JsonFilePath, pfsConnectJson)
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Protected Overridable Sub ReadPfsConnectFile()
        Try
            If File.Exists(IniFilePath) Then
                Dim pfsConnectFileLines = File.ReadAllLines(IniFilePath)
                For lineIdx = 0 To pfsConnectFileLines.Count - 1
                    Dim pfsConnectFileLine = pfsConnectFileLines(lineIdx)
                    If pfsConnectFileLine.StartsWith("#***") Then
                        Dim lineBuffer(4) As PfsConnection
                        pfsConnectFileLines.ToArray().CopyTo(lineBuffer, lineIdx)
                        Dim pfsConnect = PfsConnection.GetNewPfsConnection(pfsConnectFileLines)
                        AddPfsConnection(pfsConnect)
                    End If
                Next
            End If
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Protected Overridable Sub AddPfsConnections(pfsCnList As List(Of PfsConnection))
        For Each pfsConnection As PfsConnection In pfsCnList
            AddPfsConnection(pfsConnection)
        Next
    End Sub

    Protected Overridable Sub AddPfsConnection(pfsCn As PfsConnection)
        If pfsCn.Enabled Then
            For Each pfsConnection As PfsConnection In _pfsConnections.Where(Function(c) c.Enabled).ToList()
                pfsConnection.Enabled = False
            Next
        End If
        _pfsConnections.Add(pfsCn)
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("[SQL2000]")
        sb.AppendLine("WorkStation=WORKSTATION")
        sb.AppendLine("PacketSize=4096")
        sb.AppendLine("IntegratedSecurity=0")
        sb.AppendLine("PersistSecurity=False")
        sb.AppendLine("SqlDependency=0")
        sb.AppendLine("Training=Training")
        For Each pfsConnection As PfsConnection In _pfsConnections
            sb.Append(pfsConnection.BuildIniFileSection())
        Next
        sb.AppendLine("[Info]")
        sb.AppendLine("StationNo=99")
        sb.AppendLine("ReportPath=c:\PFSCommon\Reports")
        Return sb.ToString()
    End Function
End Class