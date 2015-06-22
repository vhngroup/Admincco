Public Class rporteporestado
    Private fcampocontrato As String
    Private Sub CrystalReportViewer1_Load(sender As System.Object, e As System.EventArgs) Handles CrystalReportViewer1.Load
        If frmreportes1.numero = 1 Then
            mostrar()
        Else
            frmreportes1.numero = 0
        End If
    End Sub
    Public Property Modelo As String
        Get
            Return fcampocontrato
        End Get
        Set(ByVal value As String)
            fcampocontrato = value
        End Set
    End Property
    Private Sub mostrar()
        CrystalReport61.RecordSelectionFormula = "{CMNuevos.Estado} ='" & fcampocontrato & "'"
    End Sub

    Private Sub rporteporestado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
    End Sub
End Class