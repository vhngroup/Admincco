Public Class ods

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
        CrystalReport11.RecordSelectionFormula = "{ODS.Identificador} ='" & fcampocontrato & "'"
    End Sub
    Private Sub mostrar2()
        CrystalReport11.RecordSelectionFormula = "{ODS.Contratos} ='" & fcampocontrato & "'"
    End Sub
    Private Sub CrystalReportViewer1_Load(sender As System.Object, e As System.EventArgs) Handles CrystalReportViewer1.Load
        If frmreportes1.numero = 1 Or fmrmodificarods.numero2 = 1 Or rcierreods.numero2 = 1 Then
            mostrar()
        ElseIf frmreportes1.numero = 2 Then
            mostrar2()
        Else
            frmreportes1.numero = 0
        End If
    End Sub

    Private Sub ods_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
    End Sub
End Class