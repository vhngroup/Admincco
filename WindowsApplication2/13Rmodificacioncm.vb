Public Class frmupdatereportemarco
    Private fcampocontrato As String
    Public Property Modelo1 As String
        Get
            Return fcampocontrato
        End Get
        Set(ByVal value As String)
            fcampocontrato = value
        End Set
    End Property

    Private Sub mostrar()
        CrystalReport31.RecordSelectionFormula = "{CMNuevos.Contratos} ='" & fcampocontrato & "'"
    End Sub


    Private Sub CrystalReportViewer1_Load(sender As System.Object, e As System.EventArgs) Handles CrystalReportViewer1.Load
        mostrar()
    End Sub

    Private Sub frmupdatereportemarco_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
    End Sub
End Class