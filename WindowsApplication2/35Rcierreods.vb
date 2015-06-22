Public Class Form2
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
        CrystalReport121.RecordSelectionFormula = "{CierreODS.Identificador} ='" & fcampocontrato & "'"
    End Sub
    Private Sub mostrar2()
        CrystalReport121.RecordSelectionFormula = "{CierreODS.Contratos} ='" & fcampocontrato & "'"
    End Sub

    Private Sub CrystalReportViewer1_Load(sender As System.Object, e As System.EventArgs) Handles CrystalReportViewer1.Load
        If frmreportes1.numero = 1 Then
            mostrar()
        ElseIf frmreportes1.numero = 2 Then
            mostrar2()
        End If
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
    End Sub
End Class