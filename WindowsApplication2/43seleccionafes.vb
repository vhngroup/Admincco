Public Class frmafes
    
    Private Sub frmafes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Facilidades' Puede moverla o quitarla según sea necesario.
        Me.FacilidadesTableAdapter.Fill(Me.Adminco_MasterDataSet.Facilidades)
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles bproyecto.TextChanged
        Me.FacilidadesBindingSource.Filter = "Facilidad like '%" & bproyecto.Text & "%'"
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles afe.TextChanged
        Me.FacilidadesBindingSource.Filter = "AFE like '%" & afe.Text & "%'"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex <> 0 Then
            mostrar()
            habilitar()
        Else
            ocultar()
        End If
    End Sub
    Private Sub habilitar()
        Select Case Label18.Text
            Case 1
                afe1.Text = Label19.Text
            Case 2
                afe2.Text = Label19.Text
            Case 3
                afe3.Text = Label19.Text
            Case 4
                afe4.Text = Label19.Text
            Case 5
                afe5.Text = Label19.Text
            Case 6
                afe6.Text = Label19.Text
            Case Else

        End Select
    End Sub
    Private Sub mostrar()
        DataGridView1.Enabled = True
        bproyecto.Enabled = True
        afe.Enabled = True
        Button3.Enabled = True
        TextBox3.Enabled = True
    End Sub
    Private Sub ocultar()
        DataGridView1.Enabled = False
        bproyecto.Enabled = False
        afe.Enabled = False
        TextBox3.Enabled = False
        Button1.Enabled = False
        Button3.Enabled = False
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged
        Me.FacilidadesBindingSource.Filter = "Ubicacion like '%" & TextBox3.Text & "%'"
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Label18.Text = Label18.Text + 1
        If Label18.Text = ComboBox1.Text Then
            Button3.Enabled = False
            aceptar()
        Else
            Button3.Enabled = True
        End If
        habilitar()
    End Sub

    Private Sub afe1_TextChanged(sender As System.Object, e As System.EventArgs) Handles afe1.TextChanged
        If afe1.Text <> "" Then
            porc1.Enabled = True
            If porc1.Text = "" Then porc1.Text = 0
            If porc2.Text = "" Then porc2.Text = 0
            If porc3.Text = "" Then porc3.Text = 0
            If porc4.Text = "" Then porc4.Text = 0
            If porc5.Text = "" Then porc5.Text = 0
            If porc6.Text = "" Then porc6.Text = 0
        Else
            porc1.Enabled = False

        End If
    End Sub

    Private Sub afe2_TextChanged(sender As System.Object, e As System.EventArgs) Handles afe2.TextChanged
        If afe2.Text <> "" Then
            porc2.Enabled = True
            If porc1.Text = "" Then porc1.Text = 0
            If porc2.Text = "" Then porc2.Text = 0
            If porc3.Text = "" Then porc3.Text = 0
            If porc4.Text = "" Then porc4.Text = 0
            If porc5.Text = "" Then porc5.Text = 0
            If porc6.Text = "" Then porc6.Text = 0
        Else
            porc2.Enabled = False

        End If
    End Sub

    Private Sub afe3_TextChanged(sender As System.Object, e As System.EventArgs) Handles afe3.TextChanged
        If afe3.Text <> "" Then
            porc3.Enabled = True
            If porc1.Text = "" Then porc1.Text = 0
            If porc2.Text = "" Then porc2.Text = 0
            If porc3.Text = "" Then porc3.Text = 0
            If porc4.Text = "" Then porc4.Text = 0
            If porc5.Text = "" Then porc5.Text = 0
            If porc6.Text = "" Then porc6.Text = 0
        Else
            porc3.Enabled = False

        End If
    End Sub

    Private Sub afe4_TextChanged(sender As System.Object, e As System.EventArgs) Handles afe4.TextChanged
        If afe4.Text <> "" Then
            porc4.Enabled = True
            If porc1.Text = "" Then porc1.Text = 0
            If porc2.Text = "" Then porc2.Text = 0
            If porc3.Text = "" Then porc3.Text = 0
            If porc4.Text = "" Then porc4.Text = 0
            If porc5.Text = "" Then porc5.Text = 0
            If porc6.Text = "" Then porc6.Text = 0
        Else
            porc4.Enabled = False

        End If
    End Sub

    Private Sub afe5_TextChanged(sender As System.Object, e As System.EventArgs) Handles afe5.TextChanged
        If afe5.Text <> "" Then
            porc5.Enabled = True
            If porc1.Text = "" Then porc1.Text = 0
            If porc2.Text = "" Then porc2.Text = 0
            If porc3.Text = "" Then porc3.Text = 0
            If porc4.Text = "" Then porc4.Text = 0
            If porc5.Text = "" Then porc5.Text = 0
            If porc6.Text = "" Then porc6.Text = 0
        Else
            porc5.Enabled = False

        End If
    End Sub

    Private Sub afe6_TextChanged(sender As System.Object, e As System.EventArgs) Handles afe6.TextChanged
        If afe6.Text <> "" Then
            porc6.Enabled = True
            If porc1.Text = "" Then porc1.Text = 0
            If porc2.Text = "" Then porc2.Text = 0
            If porc3.Text = "" Then porc3.Text = 0
            If porc4.Text = "" Then porc4.Text = 0
            If porc5.Text = "" Then porc5.Text = 0
            If porc6.Text = "" Then porc6.Text = 0
        Else
            porc6.Enabled = False

        End If
    End Sub

    Private Sub porc1_TextChanged(sender As System.Object, e As System.EventArgs) Handles porc1.TextChanged
        If (String.IsNullOrEmpty(porc1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(porc1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            aceptar()
        End If
    End Sub

    Private Sub porc2_TextChanged(sender As System.Object, e As System.EventArgs) Handles porc2.TextChanged
        If (String.IsNullOrEmpty(porc2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(porc2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            aceptar()
        End If
    End Sub

    Private Sub porc3_TextChanged(sender As System.Object, e As System.EventArgs) Handles porc3.TextChanged
        If (String.IsNullOrEmpty(porc3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(porc3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            aceptar()
        End If
    End Sub
    Private Sub porc4_TextChanged(sender As System.Object, e As System.EventArgs) Handles porc4.TextChanged
    If (String.IsNullOrEmpty(porc4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(porc4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            aceptar()
        End If
    End Sub

    Private Sub porc5_TextChanged(sender As System.Object, e As System.EventArgs) Handles porc5.TextChanged
        If (String.IsNullOrEmpty(porc5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(porc5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
            aceptar()
        End If
    End Sub

    Private Sub porc6_TextChanged(sender As System.Object, e As System.EventArgs) Handles porc6.TextChanged
        If (String.IsNullOrEmpty(porc6.Text.Trim())) Then
            Me.ErrorProvider6.SetError(porc6, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider6.Clear()
            aceptar()
        End If
    End Sub
    Private Sub aceptar()
        If porc1.Text = "" Then porc1.Text = 0
        If porc2.Text = "" Then porc2.Text = 0
        If porc3.Text = "" Then porc3.Text = 0
        If porc4.Text = "" Then porc4.Text = 0
        If porc5.Text = "" Then porc5.Text = 0
        If porc6.Text = "" Then porc6.Text = 0
        TextBox1.Text = FormatNumber(CDbl(porc1.Text) + CDbl(porc2.Text) + CDbl(porc3.Text) + CDbl(porc4.Text) + CDbl(porc5.Text) + CDbl(porc6.Text))
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = FormatNumber(100) Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmactualizarods.afe1 = afe1.Text
        frmactualizarods.afe2 = afe2.Text
        frmactualizarods.afe3 = afe3.Text
        frmactualizarods.afe4 = afe4.Text
        frmactualizarods.afe5 = afe5.Text
        frmactualizarods.afe6 = afe6.Text
        frmactualizarods.afeporc1 = porc1.Text
        frmactualizarods.afeporc2 = porc2.Text
        frmactualizarods.afeporc3 = porc3.Text
        frmactualizarods.afeporc4 = porc4.Text
        frmactualizarods.afeporc5 = porc5.Text
        frmactualizarods.afeporc6 = porc6.Text
        frmactualizarods.APE.Text = afe1.Text & "; " & afe2.Text & "; " & afe3.Text & "; " & afe4.Text & "; " & afe5.Text & "; " & afe6.Text
    End Sub
End Class