Public Class odsactivas
    Private fcampocontrato As String
    Private Sub odsactivas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
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
        CrystalReport41.RecordSelectionFormula = "{ODS.estado} ='" & fcampocontrato & "'"
    End Sub
End Class