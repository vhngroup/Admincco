Public Class frmcontatista

    Private Sub frmcontratista_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ListaProveedores' Puede moverla o quitarla según sea necesario.
        Me.ListaProveedoresTableAdapter.Fill(Me.Adminco_MasterDataSet.Listaproveedores)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ListaProveedores' Puede moverla o quitarla según sea necesario.
        Me.ListaProveedoresTableAdapter.Fill(Me.Adminco_MasterDataSet.Listaproveedores)
    End Sub
    Private Sub txtbuscar1_TextChanged(sender As System.Object, ByVal e As System.EventArgs) Handles txtbuscar.TextChanged
        Me.ListaProveedoresBindingSource.Filter = "NombreProveedor like '%" & txtbuscar.Text & "%'"
    End Sub

    Public Sub btselect_Click(sender As System.Object, e As System.EventArgs) Handles btselect.Click
        frmactualizarods.modo1 = 2
        frmformulario.modo = 2
        frmformulario.impcontratista = TextBox2.Text
        frmformulario.impnit = TextBox3.Text
        frmformulario.nuevoproceso()
        frmactualizarods.impcontratista = TextBox2.Text
        frmactualizarods.impnit = TextBox3.Text
        Me.Close()
    End Sub
End Class