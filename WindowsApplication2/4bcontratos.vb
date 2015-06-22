Public Class frmcontratos

    Private Sub Form4_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter1.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
    End Sub

    Private Sub txtpcontrato_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpcontrato.TextChanged
        Me.CMNuevosBindingSource1.Filter = "Contratos = '" & txtpcontrato.Text & "'"
    End Sub

    Private Sub txtpproceso_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpproceso.TextChanged
        Me.CMNuevosBindingSource1.Filter = "PROCESO like '%" & txtpproceso.Text & "%'"
    End Sub
    Private Sub btnseleccionar_Click(sender As System.Object, e As System.EventArgs) Handles btnseleccionar.Click
        If btnnit.Text <> "" Then
            MsgBox("El contrato" & " " & btnnit.Text & " " & "se ya esta registrado ", MsgBoxStyle.Critical, "Error")
        Else
            frmformulario.impcm = btnncontratista.Text
            frmformulario.impnit = btnnit.Text
            frmformulario.modo = 3
            frmformulario.nuevoproceso()
            Me.Close()
        End If
    End Sub

    Private Sub btnncontratista_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles btnncontratista.KeyPress
        btnnit.Text = ""
        If (Asc(e.KeyChar)) = 13 Then
            btnseleccionar.PerformClick()
        End If
    End Sub

    Private Sub btncancelar_Click(sender As System.Object, e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
        Close()

    End Sub

    Private Sub txtpcontratista_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpcontratista.TextChanged
        Me.CMNuevosBindingSource1.Filter = "PROVEEDOR like '%" & txtpcontratista.Text & "%'"
    End Sub
End Class