Imports System.DirectoryServices
Imports System.Data.OleDb
Imports System.Text
Imports System.Runtime.InteropServices
Imports IWshRuntimeLibrary
Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class Form7
    Dim cadena As String
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim adaptador As New OleDbDataAdapter
    Dim lector As OleDbDataReader
    Dim conexioncontador = ADONETUtil.cn2
    Dim comandoscontador As New SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            ' Base que se desea compactar, la cual reside
            ' en la misma carpeta que contiene el ejecutable
            ' de nuestra aplicación.
            '
            Dim origen As String = IO.Path.Combine("N:\PROYECTOS\Administracion de Contratos\Proyecto\", "Datos1.accdb")

            ' Base de datos de destino.
            '
            Dim destino As String = IO.Path.Combine("N:\PROYECTOS\Administracion de Contratos\Proyecto\", "Backup.accdb")

            CompactDataBase( _
                origen, String.Empty, _
                destino, String.Empty, _
                AccessDatabaseTypeEnum.dbVersion140)

            MessageBox.Show("Se ha compactado satisfactoriamente la base de datos.")

        Catch ex As Exception
            ' Se ha producido un error.
            '
            If (ex.InnerException Is Nothing) Then
                MessageBox.Show(ex.Message)
            Else
                MessageBox.Show(ex.InnerException.Message)
            End If

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ComboBox2.Visible = True
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Panner' Puede moverla o quitarla según sea necesario.
        Me.PannerTableAdapter.Fill(Me.Adminco_MasterDataSet.Panner)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Admin' Puede moverla o quitarla según sea necesario.
        Me.AdminTableAdapter.Fill(Me.Adminco_MasterDataSet.Admin)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Seguridad2' Puede moverla o quitarla según sea necesario.
        Me.Seguridad2TableAdapter.Fill(Me.Adminco_MasterDataSet.Seguridad2)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Seguridad4' Puede moverla o quitarla según sea necesario.
        Me.Seguridad4TableAdapter.Fill(Me.Adminco_MasterDataSet.Seguridad4)
        ComboBox2.SelectedIndex = 0
        roll.SelectedIndex = 0
    End Sub
 
    Private Sub guardar()
        Try
            comandos.CommandText = cadena
            comandos.CommandType = CommandType.Text
            comandos.Connection = conexion
            comandos.Parameters.AddWithValue("Fecha", Nombre.Text)
            comandos.Parameters.AddWithValue("Contar", Usuario.Text)
            comandos.Parameters.AddWithValue("nombre", roll)
            comandos.Parameters.AddWithValue("e-mail", correo)
            comandos.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Nombre_TextChanged(sender As Object, e As EventArgs)
        correo.Text = Usuario.Text & "@pacificrubiales.com.co"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conexioncontador = ADONETUtil.cn
        Dim comandoscontador As New SqlCommand
        If conexioncontador.State = ConnectionState.Open Then
        Else
            conexioncontador.Open()
        End If
        Try
            Dim str2 As String
            str2 = "Update  Seguridad4 SET Ubicacion = '" & ComboBox1.Text & "' Where Id = '" & 1 & "'"
            comandoscontador = New SqlCommand(str2, conexioncontador)
            comandoscontador.ExecuteNonQuery()
            conexion.Close()
            conexioncontador.Close()
            ComboBox1.Enabled = False
            Button4.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Form7-fun-01:" & "_" & ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ComboBox1.Enabled = True
        Button4.Enabled = True
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox2.Enabled = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex <> 0 Then
            Nombre.Enabled = True
            Usuario.Enabled = True
            roll.Enabled = True
            correo.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim str2 As String
        If conexioncontador.State = ConnectionState.Open Then
        Else
            conexioncontador.Open()
        End If

        Select Case ComboBox2.SelectedIndex
            Case 1
                    cadena = "INSERT INTO Seguridad2 (Nombre, Usuario, Roll, CorreoE) VALUES (@Nombre, @Usuario, @Roll,  @CorreoE)"
                    comandoscontador.CommandText = cadena
                    comandoscontador.CommandType = CommandType.Text
                    comandoscontador.Connection = conexioncontador
                    comandoscontador.Parameters.AddWithValue("@Nombre", Nombre.Text)
                    comandoscontador.Parameters.AddWithValue("@Usuario", Usuario.Text)
                    comandoscontador.Parameters.AddWithValue("@Roll", roll.Text)
                    comandoscontador.Parameters.AddWithValue("@CorreoE", correo.Text)
                    guardarusuarios()
            Case 2
                    cadena = "INSERT INTO Admin (Listauser, Roll, Cargo, CorreoE, Nombre) VALUES (@Listauser, @Roll, @CorreoE, @Nombre)"
                    comandoscontador.CommandText = cadena
                    comandoscontador.CommandType = CommandType.Text
                    comandoscontador.Connection = conexioncontador
                    comandoscontador.Parameters.AddWithValue("@Listauser", Usuario.Text)
                    comandoscontador.Parameters.AddWithValue("@Roll", roll.Text)
                    comandoscontador.Parameters.AddWithValue("@CorreoE", correo.Text)
                    comandoscontador.Parameters.AddWithValue("@Nombre", Nombre.Text)
                    guardarusuarios()
            Case 3
                    cadena = "INSERT INTO Panner (Nombre) VALUES (@Nombre)"
                    comandoscontador.CommandText = cadena
                    comandoscontador.CommandType = CommandType.Text
                    comandoscontador.Connection = conexioncontador
                    comandoscontador.Parameters.AddWithValue("@Nombre", Usuario.Text)
                    guardarusuarios()
            Case Else
                    GroupBox1.Visible = True
                    cadena = ""
        End Select
    End Sub
    Private Sub guardarusuarios()
        Try
            comandoscontador.ExecuteNonQuery()
            conexioncontador.Close()
            Button6.Enabled = False
            Nombre.Enabled = False
            Usuario.Enabled = False
            roll.Enabled = False
            correo.Enabled = False
            Nombre.Text = ""
            Usuario.Text = ""
            roll.SelectedIndex = 0
            correo.Text = ""
            Button6.Enabled = False
            MsgBox("Registro " & ComboBox2.Text & " Guardado satisfactoriamente")
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod1-fun-02:" & "_" & ex.Message)
        End Try
    End Sub


    Private Sub correo_TextChanged(sender As Object, e As EventArgs) Handles correo.TextChanged
        If ComboBox2.SelectedIndex <> 0 Then
            Button6.Enabled = True
        End If
    End Sub
    Private Sub Usuario_TextChanged(sender As Object, e As EventArgs) Handles Usuario.TextChanged
        Select Case ComboBox2.SelectedIndex
            Case 1
                Me.Seguridad2BindingSource.Filter = "Usuario like '%" & Usuario.Text & "%'"
                If Label6.Text.Trim = Usuario.Text.Trim Then
                    Button6.Enabled = False
                    ComboBox2.SelectedIndex = 0
                    MsgBox("Usuario ya exieste")
                End If
            Case 2
                Me.AdminBindingSource.Filter = "Listauser like '%" & Usuario.Text & "%'"
                If Label7.Text.Trim = Usuario.Text.Trim Then
                    Button6.Enabled = False
                    ComboBox2.SelectedIndex = 0
                    MsgBox("Usuario ya exieste")
                End If
            Case 3
                Me.PannerBindingSource.Filter = "Nombre like '%" & Usuario.Text & "%'"
                If Label8.Text.Trim = Usuario.Text.Trim Then
                    Button6.Enabled = False
                    ComboBox2.SelectedIndex = 0
                    MsgBox("Usuario ya exieste")
                End If
            Case Else
                GroupBox1.Visible = True
                cadena = ""
        End Select
    End Sub
End Class