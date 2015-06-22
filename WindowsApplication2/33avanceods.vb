Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class form10
    Dim db As IDbConnection
    Dim midataset As DataSet
    Dim mienlazador As New BindingSource
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    REM Friend valorods As Double = fmrmodificarods.total1.Text
    REM Friend numeroods As String = fmrmodificarods.cmbcontrato1.Text
    Private Sub form10_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.avancesaprobados' Puede moverla o quitarla según sea necesario.
        Me.AvancesaprobadosTableAdapter.Fill(Me.Adminco_MasterDataSet.avancesaprobados)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.avances' Puede moverla o quitarla según sea necesario.
        Me.AvancesTableAdapter.Fill(Me.Adminco_MasterDataSet.avances)
        vista()
    End Sub
    Private Sub vista()
        If dado1.Text > 0 Then dado1.Enabled = False
        If dado2.Text > 0 Then dado2.Enabled = False
        If dado3.Text > 0 Then dado3.Enabled = False
        If dado4.Text > 0 Then dado4.Enabled = False
        If dado5.Text > 0 Then dado5.Enabled = False
        If dado6.Text > 0 Then dado6.Enabled = False
        If dado7.Text > 0 Then dado7.Enabled = False
        If dado8.Text > 0 Then dado8.Enabled = False
        If dado9.Text > 0 Then dado9.Enabled = False
        If dado10.Text > 0 Then dado10.Enabled = False
        If dado1.Text > 0 Then DateTimePicker1.Enabled = False
        If dado2.Text > 0 Then DateTimePicker2.Enabled = False
        If dado3.Text > 0 Then DateTimePicker3.Enabled = False
        If dado4.Text > 0 Then DateTimePicker4.Enabled = False
        If dado5.Text > 0 Then DateTimePicker5.Enabled = False
        If dado6.Text > 0 Then DateTimePicker6.Enabled = False
        If dado7.Text > 0 Then DateTimePicker7.Enabled = False
        If dado8.Text > 0 Then DateTimePicker8.Enabled = False
        If dado9.Text > 0 Then DateTimePicker9.Enabled = False
        If dado10.Text > 0 Then DateTimePicker10.Enabled = False
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado1.TextChanged
        dado1.Text = Trim(dejarNumerosPuntos(dado1.Text))
        If (String.IsNullOrEmpty(dado1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(dado1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            calculo()
        End If
    End Sub
    Function dejarNumerosPuntos(cadenaTexto As String) As String
        Const listaNumeros = "0123456789,."
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = 0 Then
            Exit Function
        End If

        cadenaTemporal = ""

        For i = 1 To Len(cadenaTexto)
            If InStr(listaNumeros, Mid$(cadenaTexto, i, 1)) Then
                cadenaTemporal = cadenaTemporal + Mid$(cadenaTexto, i, 1)
            End If
        Next
        dejarNumerosPuntos = cadenaTemporal
    End Function

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado2.TextChanged
        dado2.Text = Trim(dejarNumerosPuntos(dado2.Text))
        If (String.IsNullOrEmpty(dado2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(dado2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            calculo()
        End If
    End Sub


    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado3.TextChanged
        dado3.Text = Trim(dejarNumerosPuntos(dado3.Text))
        If (String.IsNullOrEmpty(dado3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(dado3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado4.TextChanged
        dado4.Text = Trim(dejarNumerosPuntos(dado4.Text))
        If (String.IsNullOrEmpty(dado4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(dado4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado5.TextChanged
        dado5.Text = Trim(dejarNumerosPuntos(dado5.Text))
        If (String.IsNullOrEmpty(dado5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(dado5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado6.TextChanged
        dado6.Text = Trim(dejarNumerosPuntos(dado6.Text))
        If (String.IsNullOrEmpty(dado6.Text.Trim())) Then
            Me.ErrorProvider7.SetError(dado6, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider7.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado7.TextChanged
        dado7.Text = Trim(dejarNumerosPuntos(dado7.Text))
        If (String.IsNullOrEmpty(dado7.Text.Trim())) Then
            Me.ErrorProvider8.SetError(dado7, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider8.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox9_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado8.TextChanged
        dado8.Text = Trim(dejarNumerosPuntos(dado8.Text))
        If (String.IsNullOrEmpty(dado8.Text.Trim())) Then
            Me.ErrorProvider9.SetError(dado8, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider9.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox10_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado9.TextChanged
        dado9.Text = Trim(dejarNumerosPuntos(dado9.Text))
        If (String.IsNullOrEmpty(dado9.Text.Trim())) Then
            Me.ErrorProvider10.SetError(dado9, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider10.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox11_TextChanged(sender As System.Object, e As System.EventArgs) Handles dado10.TextChanged
        dado10.Text = Trim(dejarNumerosPuntos(dado10.Text))
        If (String.IsNullOrEmpty(dado10.Text.Trim())) Then
            Me.ErrorProvider11.SetError(dado10, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider11.Clear()
            calculo()
        End If
    End Sub
    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then TextBox6.Text = 0
        TextBox6.Text = FormatNumber(CDbl(TextBox6.Text), 2)
        If lblvalorods.Text = "" Then lblvalorods.Text = 0
        lblvalorods.Text = FormatNumber(CDbl(lblvalorods.Text), 2)
        If CDbl(TextBox6.Text) > CDbl(lblvalorods.Text) Then
            Button1.Enabled = False
            Me.ErrorProvider12.SetError(TextBox6, "El valor de los avances no puede ser superior al de la ODS")
        Else
            Me.ErrorProvider12.Clear()
            Button1.Enabled = True
        End If
    End Sub
    Private Sub calculo()
        If dado1.Text = "" Then dado1.Text = 0
        If dado2.Text = "" Then dado2.Text = 0
        If dado3.Text = "" Then dado3.Text = 0
        If dado4.Text = "" Then dado4.Text = 0
        If dado5.Text = "" Then dado5.Text = 0
        If dado6.Text = "" Then dado6.Text = 0
        If dado7.Text = "" Then dado7.Text = 0
        If dado8.Text = "" Then dado8.Text = 0
        If dado9.Text = "" Then dado9.Text = 0
        If dado10.Text = "" Then dado10.Text = 0
        TextBox6.Text = FormatNumber(CDbl(dado1.Text) + CDbl(dado2.Text) + CDbl(dado3.Text) + CDbl(dado4.Text) + CDbl(dado5.Text) + CDbl(dado6.Text) + CDbl(dado7.Text) + CDbl(dado8.Text) + CDbl(dado9.Text) + CDbl(dado10.Text))
    End Sub
    Private Sub lblvalorods_TextChanged(sender As Object, e As System.EventArgs) Handles lblvalorods.TextChanged
        If lblvalorods.Text = "" Then lblvalorods.Text = 0
        lblvalorods.Text = FormatNumber(CDbl(lblvalorods.Text), 2)
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Dim str As String
        Try
            str = "Update avances SET Avance1 = '" & dado1.Text & "',  fechaavance1 = '" & DateTimePicker1.Text & "', Avance2 = '" & dado2.Text & "',  fechaavance2 = '" & DateTimePicker2.Text & "', Avance3 = '" & dado3.Text & "',  fechaavance3 = '" & DateTimePicker3.Text & "', Avance4 = '" & dado4.Text & "',  fechaavance4 = '" & DateTimePicker4.Text & "', Avance5 = '" & dado5.Text & "',  fechaavance5 = '" & DateTimePicker5.Text & "', Avance6 = '" & dado6.Text & "',  fechaavance6 = '" & DateTimePicker6.Text & "', Avance7 = '" & dado7.Text & "',  fechaavance7 = '" & DateTimePicker7.Text & "', Avance8 = '" & dado8.Text & "',  fechaavance8 = '" & DateTimePicker8.Text & "', Avance9 = '" & dado9.Text & "',  fechaavance9 = '" & DateTimePicker9.Text & "', Avance10 = '" & dado10.Text & "',  fechaavance10 = '" & DateTimePicker10.Text & " ' Where Identificador = '" & cmbnumeroods.Text & "'"
            comandos = New SqlCommand(str, conexion)
            comandos.ExecuteNonQuery()
            conexion.Close()
            MsgBox("Se actualizo correctamente el registro")
            Button1.Enabled = False
            vista()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod33-fun-01:" & "_" & ex.Message)
        End Try
        guardar2()
    End Sub
    Private Sub guardar2()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Dim str As String
        Try
            If ComboBox1.SelectedIndex = 1 Then
                str = "Update ODS SET saldocomprometido = '" & TextBox6.Text & " ' Where Identificador = '" & cmbnumeroods.Text & "'"
                comandos = New SqlCommand(str, conexion)
                comandos.ExecuteNonQuery()
                conexion.Close()
                MsgBox("Se actualizo correctamente el registro")
            End If
            If ComboBox1.SelectedIndex = 2 Then
                str = "Update ODS SET SaldoEjecutado = '" & TextBox6.Text & " ' Where Identificador = '" & cmbnumeroods.Text & "'"
                comandos = New SqlCommand(str, conexion)
                comandos.ExecuteNonQuery()
                conexion.Close()
                MsgBox("Se actualizo correctamente el registro")
            End If
            Button1.Enabled = False
            vista()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod33-fun-02:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub cmbnumeroods_TextChanged(sender As Object, e As System.EventArgs) Handles cmbnumeroods.TextChanged
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ODS' Puede moverla o quitarla según sea necesario.
        REM Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.estados' Puede moverla o quitarla según sea necesario.
        ComboBox1.SelectedIndex = 0
        REM vista()
    End Sub
    Private Sub limpiar()
        dado1.DataBindings.Clear()
        DateTimePicker1.DataBindings.Clear()
        dado2.DataBindings.Clear()
        DateTimePicker2.DataBindings.Clear()
        dado3.DataBindings.Clear()
        DateTimePicker3.DataBindings.Clear()
        DateTimePicker4.DataBindings.Clear()
        dado4.DataBindings.Clear()
        DateTimePicker5.DataBindings.Clear()
        dado5.DataBindings.Clear()
        DateTimePicker6.DataBindings.Clear()
        dado6.DataBindings.Clear()
        DateTimePicker7.DataBindings.Clear()
        dado7.DataBindings.Clear()
        DateTimePicker8.DataBindings.Clear()
        dado8.DataBindings.Clear()
        DateTimePicker9.DataBindings.Clear()
        dado9.DataBindings.Clear()
        DateTimePicker10.DataBindings.Clear()
        dado10.DataBindings.Clear()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.TextChanged
        vista()
        If ComboBox1.SelectedIndex = 0 Then
            limpiar()
            dado1.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance1"))
            DateTimePicker1.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance1"))
            dado2.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance2"))
            DateTimePicker2.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance2"))
            dado3.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance3"))
            DateTimePicker3.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance3"))
            dado4.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance4"))
            DateTimePicker4.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance4"))
            dado5.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance5"))
            DateTimePicker5.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance5"))
            dado6.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance6"))
            DateTimePicker6.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance6"))
            dado7.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance7"))
            DateTimePicker7.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance7"))
            dado8.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance8"))
            DateTimePicker8.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance8"))
            dado9.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance9"))
            DateTimePicker9.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance9"))
            dado10.DataBindings.Add(New Binding("text", AvancesBindingSource, "avance10"))
            DateTimePicker10.DataBindings.Add(New Binding("text", AvancesBindingSource, "fechaavance10"))
        End If
        If ComboBox1.SelectedIndex = 1 Then
            limpiar()
            dado1.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance1"))
            DateTimePicker1.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance1"))
            dado2.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance2"))
            DateTimePicker2.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance2"))
            dado3.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance3"))
            DateTimePicker3.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance3"))
            dado4.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance4"))
            DateTimePicker4.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance4"))
            dado5.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance5"))
            DateTimePicker5.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance5"))
            dado6.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance6"))
            DateTimePicker6.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance6"))
            dado7.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance7"))
            DateTimePicker7.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance7"))
            dado8.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance8"))
            DateTimePicker8.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance8"))
            dado9.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance9"))
            DateTimePicker9.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance9"))
            dado10.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "avance10"))
            DateTimePicker10.DataBindings.Add(New Binding("text", AvancesaprobadosBindingSource, "fechaavance10"))
        End If
    End Sub
End Class
