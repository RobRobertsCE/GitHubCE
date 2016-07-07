Public Class BranchMonitor

    Private ReadOnly _handler As PfsConnectionHandler

    Sub New()
        _handler = New PfsConnectionHandler()
    End Sub

    Private Sub ExceptionHandler(ex As Exception)
        Console.WriteLine(ex.ToString())
    End Sub

    Protected Overridable Sub BeginMonitorBranch()

    End Sub

    Protected Overridable Sub EndMonitorBranch()

    End Sub

    Protected Overridable Sub UpdatePfsConnection()

    End Sub

End Class
