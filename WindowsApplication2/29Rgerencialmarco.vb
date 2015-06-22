Public Class Form1

    Private fcampocontrato As String
    Public Property Modelo As String
        Get
            Return fcampocontrato
        End Get
        Set(ByVal value As String)
            fcampocontrato = value
        End Set
    End Property

    Private Sub mostrar()
        CrystalReport101.RecordSelectionFormula = "{CMNuevos.estado} ='" & fcampocontrato & "'"
    End Sub
    Private Sub CrystalReportViewer1_Load(sender As System.Object, e As System.EventArgs) Handles CrystalReportViewer1.Load
        If frmreportes1.numero = 1 Or fmrmodificarods.numero2 = 1 Then
            mostrar()
        Else
            frmreportes1.numero = 0
        End If
    End Sub
End Class