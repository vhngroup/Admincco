Public Class Form8
    Private Sub Form8_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Servicios' Puede moverla o quitarla según sea necesario.
        Me.ServiciosTableAdapter.Fill(Me.Adminco_MasterDataSet.Servicios)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Close()
    End Sub

    Private Sub btselect2_Click(sender As System.Object, e As System.EventArgs) Handles btselect2.Click
        form6.impservicio1 = textcontract.Text
        form6.importacion()
        REM  frmactualizarods.ident = textcontract.Text

        frmestructurarechazada.impservicio1 = textcontract.Text
        frmestructurarechazada.importacion()
        REM frmestructurarechazada.ident = textcontract.Text

        Me.Close()
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            Me.ServiciosBindingSource1.Filter = "Servicio ='" & TextBox1.Text & "'"
        End If
    End Sub

    Private Sub txtbuscar5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbuscar5.TextChanged
        Me.ServiciosBindingSource1.Filter = "[Texto breve] like '*" & txtbuscar5.Text & "*'"
    End Sub
End Class