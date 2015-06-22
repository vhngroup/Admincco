Public Class restadoactualcm
    Private fcampocontrato As String
    Private Sub restadoactualcm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If frmreportes1.numero = 1 Or frmaprobarcontrato.numero1 = 1 Then
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
        CrystalReport51.RecordSelectionFormula = "{CMNuevos.Contratos} ='" & fcampocontrato & "'"
    End Sub
End Class