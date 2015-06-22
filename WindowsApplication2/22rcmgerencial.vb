Public Class frmreportemarcos

    Private Sub frmreportemarcos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class