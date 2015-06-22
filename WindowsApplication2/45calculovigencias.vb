Public Class Form12
    Friend vigencia As Integer
    Friend cmbopcion As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub contrato_TextChanged(sender As Object, e As EventArgs) Handles contrato.TextChanged
        Me.CMNuevosBindingSource.Filter = "Contratos = '" & contrato.Text & "'"
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        desv1.Text = CDbl(org1.Text) - CDbl(s1.Text)
        desv2.Text = CDbl(org2.Text) - CDbl(s2.Text)
        desv3.Text = CDbl(org3.Text) - CDbl(s3.Text)
        desv4.Text = CDbl(org4.Text) - CDbl(s4.Text)
        desv5.Text = CDbl(org5.Text) - CDbl(s5.Text)
        If cmbopcion = "Costo" Then
            TextBox2.Text = frmaprobarcontrato.costotal.Text
        Else
            vigenciavisible()
        End If
        newvisible()
    End Sub
    Private Sub newvisible()
        Select Case vigencia
            Case 1
                n1.Enabled = True
            Case 2
                n1.Enabled = True
                n2.Enabled = True
            Case 3
                n1.Enabled = True
                n2.Enabled = True
                n3.Enabled = True
            Case 4
                n1.Enabled = True
                n2.Enabled = True
                n3.Enabled = True
                n4.Enabled = True
            Case 5
                n1.Enabled = True
                n2.Enabled = True
                n3.Enabled = True
                n4.Enabled = True
                n5.Enabled = True
            Case Else
                n1.Enabled = False
                n2.Enabled = False
                n3.Enabled = False
                n4.Enabled = False
                n5.Enabled = False
        End Select
    End Sub
    Private Sub vigenciavisible()
        Select Case vigencia
            Case 1
                s1.Enabled = True
            Case 2
                s1.Enabled = True
                n2.Enabled = True
            Case 3
                s1.Enabled = True
                n2.Enabled = True
                n3.Enabled = True
            Case 4
                s1.Enabled = True
                n2.Enabled = True
                n3.Enabled = True
                n4.Enabled = True
            Case 5
                s1.Enabled = True
                n2.Enabled = True
                n3.Enabled = True
                n4.Enabled = True
                n5.Enabled = True
            Case Else
                s1.Enabled = False
                n2.Enabled = False
                n3.Enabled = False
                n4.Enabled = False
                n5.Enabled = False
        End Select
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmaprobarcontrato.txtano1.Text = CDbl(nv1.Text)
        frmaprobarcontrato.txtano2.Text = CDbl(nv2.Text)
        frmaprobarcontrato.txtano3.Text = CDbl(nv3.Text)
        frmaprobarcontrato.txtano4.Text = CDbl(nv4.Text)
        frmaprobarcontrato.txtano5.Text = CDbl(nv5.Text)
        frmaprobarcontrato.vigenciaorg(0) = CDbl(org1.Text) + CDbl(n1.Text)
        frmaprobarcontrato.vigenciaorg(1) = CDbl(org2.Text) + CDbl(n2.Text)
        frmaprobarcontrato.vigenciaorg(2) = CDbl(org3.Text) + CDbl(n3.Text)
        frmaprobarcontrato.vigenciaorg(3) = CDbl(org4.Text) + CDbl(n4.Text)
        frmaprobarcontrato.vigenciaorg(4) = CDbl(org5.Text) + CDbl(n5.Text)
        frmaprobarcontrato.CheckBox1.Enabled = True
        frmaprobarcontrato.calcvigencias.Visible = False
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            n1.Enabled = False
            n2.Enabled = False
            n3.Enabled = False
            n4.Enabled = False
            n5.Enabled = False
            calcular()
            If msensajetotal.Text = "" Then
                Button1.Enabled = True
            End If
        End If
        If CheckBox1.Checked = False Then
            newvisible()
            Button1.Enabled = False
        End If
    End Sub
    Private Sub calcular()
        If n1.Text = "" Then n1.Text = 0
        If n2.Text = "" Then n2.Text = 0
        If n3.Text = "" Then n3.Text = 0
        If n4.Text = "" Then n4.Text = 0
        If n5.Text = "" Then n5.Text = 0
        nv1.Text = CDbl(n1.Text) + CDbl(s1.Text)
        nv2.Text = CDbl(n2.Text) + CDbl(s2.Text)
        nv3.Text = CDbl(n3.Text) + CDbl(s3.Text)
        nv4.Text = CDbl(n4.Text) + CDbl(s4.Text)
        nv5.Text = CDbl(n5.Text) + CDbl(s5.Text)
        validar()
    End Sub
    Private Sub validar()
        stotal.Text = FormatNumber(CDbl(nv1.Text) + CDbl(nv2.Text) + CDbl(nv3.Text) + CDbl(nv4.Text) + CDbl(nv5.Text))
        Dim falta As Double
        falta = TextBox2.Text - stotal.Text
        If CDbl(stotal.Text) <> CDbl(TextBox2.Text) Then
            msensajetotal.Text = "La suma total de las vigencias no es igual al valor total del contrato faltan" & " " & CDbl(falta)
        Else
            msensajetotal.Text = ""
        End If
    End Sub

    Private Sub org1_TextChanged(sender As Object, e As EventArgs) Handles org1.TextChanged
        org1.Text = FormatNumber(CDbl(org1.Text), 2)
    End Sub
    Private Sub org2_TextChanged(sender As Object, e As EventArgs) Handles org2.TextChanged
        org2.Text = FormatNumber(CDbl(org2.Text), 2)
    End Sub
    Private Sub org3_TextChanged(sender As Object, e As EventArgs) Handles org3.TextChanged
        org3.Text = FormatNumber(CDbl(org3.Text), 2)
    End Sub
    Private Sub org4_TextChanged(sender As Object, e As EventArgs) Handles org4.TextChanged
        org4.Text = FormatNumber(CDbl(org4.Text), 2)
    End Sub
    Private Sub org5_TextChanged(sender As Object, e As EventArgs) Handles org5.TextChanged
        org5.Text = FormatNumber(CDbl(org5.Text), 2)
    End Sub

    Private Sub s1_LostFocus(sender As Object, e As EventArgs) Handles s1.LostFocus
        If s1.Text = "" Then s1.Text = 0
        s1.Text = FormatNumber(CDbl(s1.Text), 2)
    End Sub
    Private Sub s2_LostFocus(sender As Object, e As EventArgs) Handles s2.LostFocus
        If s2.Text = "" Then s2.Text = 0
        s2.Text = FormatNumber(CDbl(s2.Text), 2)
    End Sub
    Private Sub s3_LostFocus(sender As Object, e As EventArgs) Handles s3.LostFocus
        If s3.Text = "" Then s3.Text = 0
        s3.Text = FormatNumber(CDbl(s3.Text), 2)
    End Sub
    Private Sub s4_LostFocus(sender As Object, e As EventArgs) Handles s4.LostFocus
        If s4.Text = "" Then s4.Text = 0
        s4.Text = FormatNumber(CDbl(s4.Text), 2)
    End Sub
    Private Sub s5_LostFocus(sender As Object, e As EventArgs) Handles s5.LostFocus
        If s5.Text = "" Then s5.Text = 0
        s5.Text = FormatNumber(CDbl(s5.Text), 2)
    End Sub
    Private Sub s1_TextChanged(sender As Object, e As EventArgs) Handles s1.TextChanged
        If (String.IsNullOrEmpty(s1.Text.Trim())) Then
            Me.ErrorProvider6.SetError(s1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider6.Clear()
        End If
    End Sub
    Private Sub s2_TextChanged(sender As Object, e As EventArgs) Handles s2.TextChanged
        If (String.IsNullOrEmpty(s2.Text.Trim())) Then
            Me.ErrorProvider7.SetError(s2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider7.Clear()
        End If
    End Sub
    Private Sub s3_TextChanged(sender As Object, e As EventArgs) Handles s3.TextChanged
        If (String.IsNullOrEmpty(s3.Text.Trim())) Then
            Me.ErrorProvider9.SetError(s3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider9.Clear()
        End If
    End Sub
    Private Sub s4_TextChanged(sender As Object, e As EventArgs) Handles s4.TextChanged
        If (String.IsNullOrEmpty(s4.Text.Trim())) Then
            Me.ErrorProvider9.SetError(s4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider9.Clear()
        End If
    End Sub
    Private Sub s5_TextChanged(sender As Object, e As EventArgs) Handles s5.TextChanged
        If (String.IsNullOrEmpty(s5.Text.Trim())) Then
            Me.ErrorProvider10.SetError(s5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider10.Clear()
        End If
    End Sub
    Private Sub desv1_TextChanged(sender As Object, e As EventArgs) Handles desv1.TextChanged
        desv1.Text = FormatNumber(CDbl(desv1.Text), 2)
    End Sub
    Private Sub desv2_TextChanged(sender As Object, e As EventArgs) Handles desv2.TextChanged
        desv2.Text = FormatNumber(CDbl(desv2.Text), 2)
    End Sub
    Private Sub desv3_TextChanged(sender As Object, e As EventArgs) Handles desv3.TextChanged
        desv3.Text = FormatNumber(CDbl(desv3.Text), 2)
    End Sub
    Private Sub desv4_TextChanged(sender As Object, e As EventArgs) Handles desv4.TextChanged
        desv4.Text = FormatNumber(CDbl(desv4.Text), 2)
    End Sub
    Private Sub desv5_TextChanged(sender As Object, e As EventArgs) Handles desv5.TextChanged
        desv5.Text = FormatNumber(CDbl(desv5.Text), 2)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = FormatNumber(CDbl(TextBox2.Text), 2)
    End Sub

    Private Sub stotal_TextChanged(sender As Object, e As EventArgs) Handles stotal.TextChanged
        stotal.Text = FormatNumber(CDbl(stotal.Text), 2)
    End Sub

    Private Sub nv1_TextChanged(sender As Object, e As EventArgs) Handles nv1.TextChanged
        nv1.Text = FormatNumber(CDbl(nv1.Text), 2)
    End Sub
    Private Sub nv2_TextChanged(sender As Object, e As EventArgs) Handles nv2.TextChanged
        nv2.Text = FormatNumber(CDbl(nv2.Text), 2)
    End Sub
    Private Sub nv3_TextChanged(sender As Object, e As EventArgs) Handles nv3.TextChanged
        nv3.Text = FormatNumber(CDbl(nv3.Text), 2)
    End Sub
    Private Sub nv4_TextChanged(sender As Object, e As EventArgs) Handles nv4.TextChanged
        nv4.Text = FormatNumber(CDbl(nv4.Text), 2)
    End Sub
    Private Sub nv5_TextChanged(sender As Object, e As EventArgs) Handles nv5.TextChanged
        nv5.Text = FormatNumber(CDbl(nv5.Text), 2)
    End Sub

    Private Sub n1_TextChanged(sender As Object, e As EventArgs) Handles n1.TextChanged
        If (String.IsNullOrEmpty(n1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(n1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
        End If
    End Sub
    Private Sub n2_TextChanged(sender As Object, e As EventArgs) Handles n2.TextChanged
        If (String.IsNullOrEmpty(n2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(n2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
        End If
    End Sub
    Private Sub n3_TextChanged(sender As Object, e As EventArgs) Handles n3.TextChanged
        If (String.IsNullOrEmpty(n3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(n3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
        End If
    End Sub
    Private Sub n4_TextChanged(sender As Object, e As EventArgs) Handles n4.TextChanged
        If (String.IsNullOrEmpty(n4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(n4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
        End If
    End Sub
    Private Sub n5_TextChanged(sender As Object, e As EventArgs) Handles n5.TextChanged
        If (String.IsNullOrEmpty(n5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(n5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
        End If
    End Sub
    Private Sub n1_LostFocus(sender As Object, e As System.EventArgs) Handles n1.LostFocus
        n1.Text = FormatNumber(CDbl(n1.Text), 2)
    End Sub
    Private Sub n2_LostFocus(sender As Object, e As System.EventArgs) Handles n2.LostFocus
        n2.Text = FormatNumber(CDbl(n2.Text), 2)
    End Sub
    Private Sub n3_LostFocus(sender As Object, e As System.EventArgs) Handles n3.LostFocus
        n3.Text = FormatNumber(CDbl(n3.Text), 2)
    End Sub
    Private Sub n4_LostFocus(sender As Object, e As System.EventArgs) Handles n4.LostFocus
        n4.Text = FormatNumber(CDbl(n4.Text), 2)
    End Sub
    Private Sub n5_LostFocus(sender As Object, e As System.EventArgs) Handles n5.LostFocus
        n5.Text = FormatNumber(CDbl(n5.Text), 2)
    End Sub
End Class