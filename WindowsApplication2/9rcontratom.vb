Imports CrystalDecisions.CrystalReports.Engine

Public Class frmReportes
    Private fcampocontrato As Double
    Public Property Modelo As Double
        Get
            Return fcampocontrato
        End Get
        Set(ByVal value As Double)
            fcampocontrato = value
        End Set
    End Property
    Private Sub mostrar()
        CrystalReport21.RecordSelectionFormula = "{CMNuevos.Contratos} ='" & fcampocontrato & "'"
    End Sub
    Private Sub CrystalReportViewer1_Load(sender As System.Object, e As System.EventArgs) Handles CrystalReportViewer1.Load
        If frmreportes1.numero = 1 Or frmaprobarcontrato.numero1 = 1 Then
            mostrar()
        Else
            frmreportes1.numero = 0
        End If
    End Sub

    Private Sub frmReportes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
    End Sub
End Class