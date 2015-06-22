Public Class frmselectasociasion

    Private Sub frmselectasociasion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.AreasTableAdapter.Fill(Me.Adminco_MasterDataSet.Areas)
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txticampo.TextChanged
        Me.AreasBindingSource4.Filter = "Campo like '%" & txticampo.Text & "%'"
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtiproyecto.TextChanged
        Me.AreasBindingSource4.Filter = "Proyecto like '%" & txtiproyecto.Text & "%'"
    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtisistema.TextChanged
        Me.AreasBindingSource4.Filter = "SISTEMA like '%" & txtisistema.Text & "%'"
    End Sub

    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtisubsistem.TextChanged
        Me.AreasBindingSource4.Filter = "SUBSISTEMA like '%" & txtisubsistem.Text & "%'"
    End Sub

    Private Sub txtselect_Click(sender As System.Object, e As System.EventArgs) Handles txtselect.Click
        frmactualizarods.modo1 = 3
        frmactualizarods.impprogramam = TextBox1.Text
        frmactualizarods.subprograma = TextBox2.Text
        frmactualizarods.impproyectom = TextBox3.Text
        frmactualizarods.impproyecto = TextBox4.Text
        ' frmactualizarods.validar()
        frmformulario.modo = 5
        frmformulario.impprogramam1 = TextBox1.Text
        frmformulario.subprograma1 = TextBox2.Text
        frmformulario.impproyectom1 = TextBox3.Text
        frmformulario.impproyecto1 = TextBox4.Text
        frmformulario.nuevoproceso()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class