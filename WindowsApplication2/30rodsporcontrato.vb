Public Class rodsporcontrato
    Private fcampocontrato As String
    Private Sub rodsporcontrato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        If frmreportes1.numero = 1 Then
            mostrar()
        Else
            frmreportes1.numero = 0
        End If
    End Sub
    Private Sub mostrar()
        Copia_de_CrystalReport81.RecordSelectionFormula = "{ODS.Contratos} ='" & fcampocontrato & "'"
    End Sub
    Public Property Modelo As String
        Get
            Return fcampocontrato
        End Get
        Set(ByVal value As String)
            fcampocontrato = value
        End Set
    End Property
End Class