Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Form13
    Dim db As IDbConnection
    Dim midataset As DataSet
    Dim mienlazador As New BindingSource
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim reader As OleDbDataReader

    Private Sub Form13_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Facilidades' Puede moverla o quitarla según sea necesario.
        Me.FacilidadesTableAdapter.Fill(Me.Adminco_MasterDataSet.Facilidades)
        lstUbicacion.SelectedIndex = 0
        REM existe.Visible = False
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstUbicacion.SelectedIndexChanged
        If lstUbicacion.SelectedIndex = 0 Then
            Equipo.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        Else
            Equipo.Enabled = True
        End If
    End Sub

    Private Sub ubicacion_TextChanged(sender As System.Object, e As System.EventArgs) Handles Equipo.TextChanged
        Me.FacilidadesBindingSource.Filter = "Facilidad like '%" & Equipo.Text & "%'"
        If Equipo.Text <> "" Then
            TextBox1.Enabled = True
            If existe.Text.Trim = Equipo.Text.Trim Then
                TextBox1.Text = TextBox3.Text
                TextBox1.Enabled = False
                TextBox2.Enabled = False

                Button1.Visible = False
            Else
                TextBox1.Enabled = True
                TextBox2.Enabled = True

                Button1.Visible = True
            End If
        Else
            TextBox1.Enabled = False
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Me.FacilidadesBindingSource.Filter = "AFE like '%" & TextBox1.Text & "%'"
        If TextBox1.Text <> "" Then
            TextBox2.Enabled = True
            If TextBox3.Text.Trim = TextBox1.Text.Trim Then
                Equipo.Text = existe.Text
                Equipo.Enabled = False
                TextBox2.Enabled = False

                Button1.Visible = False
            Else

                Equipo.Enabled = True
                TextBox2.Enabled = True

                Button1.Visible = True
            End If
        Else

            TextBox2.Enabled = False
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text <> "" Or TextBox2.Text <> 0 Then
            Me.ErrorProvider1.Clear()
            Button1.Enabled = True
        Else
            Me.ErrorProvider1.SetError(TextBox2, "Por favor ingrese el valor del equipo")
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos.CommandText = "INSERT INTO Facilidades (Facilidad, Ubicacion, AFE, VALOR) VALUES (Facilidad, Ubicacion, AFE, VALOR)"
            comandos.CommandType = CommandType.Text
            comandos.Connection = conexion
            comandos.Parameters.AddWithValue("Facilidad", Equipo.Text)
            comandos.Parameters.AddWithValue("Ubicacion", lstUbicacion.Text)
            comandos.Parameters.AddWithValue("AFE", TextBox1.Text)
            comandos.Parameters.AddWithValue("VALOR", TextBox2.Text)
            comandos.ExecuteNonQuery()
            conexion.Close()
            MsgBox("Guardado Corectamente", vbInformation, ("Guardado"))
            Button1.Enabled = False
            Equipo.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod33-fun-01:" & "_" & ex.Message)
        End Try
    End Sub

    Private Sub existe_Click(sender As Object, e As System.EventArgs) Handles existe.Click
        Equipo.Text = existe.Text
    End Sub
    Private Sub TextBox3_Click(sender As Object, e As System.EventArgs) Handles TextBox3.Click
        TextBox1.Text = TextBox3.Text
    End Sub
End Class