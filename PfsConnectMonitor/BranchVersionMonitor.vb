Imports System.IO

Public Class BranchVersionMonitor

#Region " Constants "
    Private Const VersionFileDirectoryTemplate As String = "C:\Users\{0}\Source\Repos\Advantage\src"
    Private Const VersionFileName As String = "version.txt"
    Private Const PfsConnectFilePath As String = "C:\PfsConnect\PfsConnect.ini"
#End Region

#Region " Events "
    Public Event BranchMonitorException(sender As Object, e As Exception)
    Protected Overridable Sub OnBranchMonitorException(e As Exception)
        RaiseEvent BranchMonitorException(Me, e)
    End Sub

    Public Event BranchVersionChanged(sender As Object, e As Version)
    Protected Overridable Sub OnBranchVersionChanged(e As Version)
        RaiseEvent BranchVersionChanged(Me, e)
    End Sub
#End Region

#Region " Fields "
    Private ReadOnly _handler As PfsConnectionHandler
    Private WithEvents _watcher As FileSystemWatcher
#End Region

#Region " Properties "
    Protected ReadOnly Property VersionFileDirectory As String
        Get
            Return String.Format(VersionFileDirectoryTemplate, Environment.UserName)
        End Get
    End Property

    Protected ReadOnly Property VersionFilePath As String
        Get
            Return Path.Combine(VersionFileDirectory, VersionFileName)
        End Get
    End Property
#End Region

#Region " Constructor "
    Sub New()
        Try
            _handler = New PfsConnectionHandler()
            _watcher = New FileSystemWatcher(VersionFileDirectory, VersionFileName)
            _watcher.NotifyFilter = NotifyFilters.LastWrite Or NotifyFilters.LastAccess
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub
#End Region

#Region " Private "
    Private Sub ExceptionHandler(ex As Exception)
        Console.WriteLine(ex.ToString())
        OnBranchMonitorException(ex)
    End Sub

    Private Sub _watcher_Changed(sender As Object, e As FileSystemEventArgs) Handles _watcher.Changed
        Try
            HandleVersionChange()
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Private Sub _watcher_Error(sender As Object, e As ErrorEventArgs) Handles _watcher.[Error]
        Try
            OnBranchMonitorException(e.GetException())
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub
#End Region

#Region " Protected "
    Protected Overridable Sub BeginMonitorBranch()
        Try
            _watcher.EnableRaisingEvents = True
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Protected Overridable Sub EndMonitorBranch()
        Try
            _watcher.EnableRaisingEvents = False
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Protected Overridable Sub HandleVersionChange()
        Try
            Dim newVersion As Version = GetCurrentBranchVersion()
            Dim newTestDatabaseName As String = BuildTestDatabaseName(newVersion)
            UpdatePfsConnectDatabase(newTestDatabaseName)
            OnBranchVersionChanged(newVersion)
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Protected Overridable Sub UpdatePfsConnectDatabase(newTestDatabaseName As String)
        Try
            Dim fileLines = File.ReadAllLines(PfsConnectFilePath)
            Dim newFileLines As New List(Of String)
            For Each line As String In fileLines
                If line.StartsWith("Catalog=") Then
                    newFileLines.Add(String.Format("Catalog={0}", newTestDatabaseName))
                Else
                    newFileLines.Add(line)
                End If
            Next
            File.WriteAllLines(PfsConnectFilePath, newFileLines)
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Protected Overridable Function GetCurrentPfsConnectDatabase() As String
        Dim testDatabaseName As String = String.Empty
        Try
            Dim fileLines = File.ReadAllLines(PfsConnectFilePath)
            For Each line As String In fileLines
                If line.StartsWith("Catalog=") Then
                    testDatabaseName = line.Replace("Catalog=", "")
                    Exit For
                End If
            Next
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
        Return testDatabaseName
    End Function

    Protected Overridable Function GetCurrentBranchVersion() As Version
        Dim newVersion As Version = Nothing
        Try
            Dim fileContent = File.ReadAllText(VersionFilePath)
            newVersion = Version.Parse(fileContent)
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
        Return newVersion
    End Function

    Protected Overridable Function BuildTestDatabaseName(branchVersion As Version) As String
        Dim databaseName As String = String.Empty
        Try
            databaseName = String.Format("Test{0}{1}", branchVersion.Major, branchVersion.Minor)
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
        Return databaseName
    End Function
#End Region

#Region " Public "
    Public Sub StartMonitor()
        Try
            BeginMonitorBranch()
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Public Sub StopMonitor()
        Try
            EndMonitorBranch()
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
    End Sub

    Public Function GetTestDatabase() As String
        Dim databaseName As String = String.Empty
        Try
            databaseName = GetCurrentPfsConnectDatabase()
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
        Return databaseName
    End Function

    Public Function SetPfsConnectDatabase(newTestDatabaseName As String) As Boolean
        Dim success = False
        Try
            UpdatePfsConnectDatabase(newTestDatabaseName)
            success = True
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
        Return success
    End Function

    Public Function GetBranchVersion() As Version
        Dim currentVersion As Version = Nothing
        Try
            currentVersion = GetCurrentBranchVersion()
        Catch ex As Exception
            ExceptionHandler(ex)
        End Try
        Return currentVersion
    End Function
#End Region

End Class
