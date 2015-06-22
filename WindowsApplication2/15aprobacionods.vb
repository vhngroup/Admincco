Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Text
Imports System.Drawing
Imports System.Data.SqlClient
Public Class fmrmodificarods
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim comandos1 As New SqlCommand
    Dim comandos2 As New SqlCommand
    Dim comandos3 As New SqlCommand
    Dim comandos4 As New SqlCommand
    Dim comandos5 As New SqlCommand
    Friend chktext
    Friend hoy As Date
    Friend numero2 As String
    Dim eplanner As String
    Friend servicio2(3)
    Friend nservicio2(3)
    Friend costod2(3)
    Friend admin2(3)
    Friend impre2(3)
    Friend util2(3)
    Friend subt2(3)
    Friend iva2(3)
    Friend total2(3)
    Friend a2(3)
    Friend i2(3)
    Friend u2(3)
    Friend cosdirecto
    Friend imptxtcostadminglobal
    Friend imptxtcostimpglobal
    Friend imptxtcostutilglobal
    Friend imptxtcostsubglobal
    Friend imptxtcostivaglobal
    Friend impvrgtotal
    Friend modo
    Dim restadirecto(4) As Double
    Dim restaadmin(4) As Double
    Dim restaimpre(4) As Double
    Dim restautil(4) As Double
    Dim restasubtotal(4) As Double
    Dim restaiva(4) As Double
    Dim restatotal(4) As Double
    Dim newvigencia(4) As Double
    Dim delta As Integer
    Dim number As String
    Private Sub fmrmodificarods_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        REM classResize.ResizeForm(Me, @1366, @768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ODS' Puede moverla o quitarla según sea necesario.
        REM Me.CMNuevosBindingSource.Filter = "Contratos ='" & Id.Text & "'"
        delta = 1

        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        REM grptime.Enabled = False
        hoy = System.DateTime.Now.Date
        anovigencia.Text = Year(dtfecha1.Value)
        cmbmodificacion.SelectedIndex = 0
    End Sub
    Private Sub vigencia()
        anovigencia.Text = Year(hoy)
        If anovigencia.Text = ano1.Text Then
            txtvigencia.Text = vigenciaorg1.Text
            saldovigencia.Text = vigencia1.Text
        End If
        If anovigencia.Text = ano2.Text Then
            txtvigencia.Text = vigenciaorg2.Text
            saldovigencia.Text = Vigencia2.Text
        End If
        If anovigencia.Text = ano3.Text Then
            txtvigencia.Text = vigenciaorg3.Text
            saldovigencia.Text = Vigencia3.Text
        End If
        If anovigencia.Text = ano4.Text Then
            txtvigencia.Text = vigenciaorg4.Text
            saldovigencia.Text = vigencia4.Text
        End If
        If anovigencia.Text = ano5.Text Then
            txtvigencia.Text = vigenciaorg5.Text
            saldovigencia.Text = vigencia5.Text
        End If
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
        frmmenu.Show()
    End Sub
    Private Sub CheckBox5_CheckStateChanged(sender As Object, e As System.EventArgs) Handles CheckBox5.CheckStateChanged
        If CheckBox5.Checked = True Then
            btguardar.Enabled = True
            chktext = hoy & "" & My.Settings.usuario2
        Else
            btguardar.Enabled = False
        End If
    End Sub
    Private Sub costod1_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod1.TextChanged
        If costod1.Text = "" Then costod1.Text = 0
        costod1.Text = FormatNumber(CDbl(costod1.Text), 2)
    End Sub
    Private Sub admin1_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin1.TextChanged
        If admin1.Text = "" Then admin1.Text = 0
        admin1.Text = FormatNumber(CDbl(admin1.Text), 2)
    End Sub
    Private Sub impre1_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre1.TextChanged
        If impre1.Text = "" Then impre1.Text = 0
        impre1.Text = FormatNumber(CDbl(impre1.Text), 2)
    End Sub
    Private Sub util1_TextChanged(sender As System.Object, e As System.EventArgs) Handles util1.TextChanged
        If util1.Text = "" Then util1.Text = 0
        util1.Text = FormatNumber(CDbl(util1.Text), 2)
    End Sub
    Private Sub subt1_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt1.TextChanged
        If subt1.Text = "" Then subt1.Text = 0
        subt1.Text = FormatNumber(CDbl(subt1.Text), 2)
    End Sub
    Private Sub iva1_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva1.TextChanged
        If iva1.Text = "" Then iva1.Text = 0
        iva1.Text = FormatNumber(CDbl(iva1.Text), 2)
    End Sub
    Private Sub total1_TextChanged(sender As System.Object, e As System.EventArgs) Handles total1.TextChanged
        If total1.Text = "" Then total1.Text = 0
        total1.Text = FormatNumber(CDbl(total1.Text), 2)
    End Sub
    Private Sub avanceods_Click(sender As System.Object, e As System.EventArgs) Handles avanceods.Click
        MsgBox("Modulo en desarrollo, disculpe las molestias.")
        REM form10.lblvalorods.Text = total1.Text
        REM form10.cmbnumeroods.Text = id.Text
        REM form10.ShowDialog()
        REM form10.Dispose()
    End Sub
    Private Sub mcostot_TextChanged(sender As Object, e As System.EventArgs) Handles mcostot.TextChanged
        If mcostot.Text = "" Then mcostot.Text = 0
        mcostot.Text = FormatNumber(CDbl(mcostot.Text), 2)
    End Sub
    Private Sub saldototal_TextChanged(sender As Object, e As System.EventArgs) Handles saldototal.TextChanged
        If saldototal.Text = "" Then saldototal.Text = 0
        saldototal.Text = FormatNumber(CDbl(saldototal.Text), 2)
    End Sub
    Private Sub txtvigencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtvigencia.TextChanged
        If txtvigencia.Text = "" Then txtvigencia.Text = 0
        txtvigencia.Text = FormatNumber(CDbl(txtvigencia.Text), 2)
    End Sub
    Private Sub cmbmodificacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbmodificacion.SelectedIndexChanged
        btndistribuir.Enabled = False
        txtnota.Enabled = False
        grptime.Enabled = False
        textdescripcion.Enabled = False
        CheckBox5.Enabled = False
        CheckBox5.Visible = False
        avanceods.Enabled = False
        Select Case cmbmodificacion.SelectedIndex
            Case 0
                CheckBox5.Enabled = False
                CheckBox5.Visible = False
            Case 1
                btndistribuir.Enabled = True
                avanceods.Enabled = False
            Case 2
                txtnota.Enabled = True
                CheckBox5.Enabled = True
                CheckBox5.Visible = True
                avanceods.Enabled = False
            Case 3
                grptime.Enabled = True
                CheckBox5.Enabled = True
                CheckBox5.Visible = True
                avanceods.Enabled = False
            Case 4
                textdescripcion.Enabled = True
                CheckBox5.Enabled = True
                CheckBox5.Visible = True
            Case Else
                btndistribuir.Enabled = False
                txtnota.Enabled = False
                grptime.Enabled = False
                textdescripcion.Enabled = False
                CheckBox5.Enabled = False
                CheckBox5.Visible = False
                avanceods.Enabled = False
        End Select
    End Sub
    Private Sub DateTimePicker6_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker6.ValueChanged
        If grptime.Enabled = True Then
            calculofecha()
        End If
    End Sub
    Private Sub DateTimePicker5_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker5.ValueChanged
        If grptime.Enabled = True Then
            calculofecha()
        End If
    End Sub
    Private Sub calculofecha()
        If DateTimePicker2.Value > DateTimePicker6.Value Then
            MsgBox("La duracion de la ODS no puede iniciar antes que el contrato Marco.")
            DateTimePicker6.Value = DateTimePicker2.Value
        End If
        If DateTimePicker1.Value < DateTimePicker5.Value Then
            MsgBox("La duracion de la ODS no puede finalizar despues que el contrato Marco.")
            DateTimePicker5.Value = DateTimePicker1.Value
        End If
        tiempods.Text = DateTimePicker5.Value.Subtract(DateTimePicker6.Value).TotalDays
    End Sub
    Private Sub btguardar_Click(sender As System.Object, e As System.EventArgs) Handles btguardar.Click
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If

        If cmbmodificacion.SelectedIndex = 0 Then
            If CheckBox5.Checked = True Then
                Estadoods.Text = "Ejecucion"
                Try
                    comandos1.CommandType = CommandType.StoredProcedure
                    comandos1.CommandText = "odsagregaravance"
                    comandos1.Connection = conexion
                    comandos1.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
                    comandos1.Parameters.Add("@Avance1", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance2", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance3", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance4", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance5", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance6", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance7", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance8", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance9", SqlDbType.Float).Value = 0
                    comandos1.Parameters.Add("@Avance10", SqlDbType.Float).Value = 0
                    comandos1.ExecuteNonQuery()
                    conexion.Close()
                    paso2()
                    guardar2()
                    enviarmail()
                Catch ex As Exception
                    MessageBox.Show("Notificar error codigo Mod15-fun-01:" & "_" & ex.Message)
                End Try
            End If
        End If

        If cmbmodificacion.SelectedIndex = 1 Then
            Try
                comandos2.CommandType = CommandType.StoredProcedure
                comandos2.CommandText = "odsmodificadinero"
                comandos2.Connection = conexion
                comandos2.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
                comandos2.Parameters.Add("@CostoDirecto", SqlDbType.Float).Value = cosdirecto
                comandos2.Parameters.Add("@Administracion", SqlDbType.Float).Value = imptxtcostadminglobal
                comandos2.Parameters.Add("@Imprevisto", SqlDbType.Float).Value = imptxtcostimpglobal
                comandos2.Parameters.Add("@Utilidad", SqlDbType.Float).Value = imptxtcostutilglobal
                comandos2.Parameters.Add("@Subtotal", SqlDbType.Float).Value = imptxtcostsubglobal
                comandos2.Parameters.Add("@iva", SqlDbType.Float).Value = imptxtcostivaglobal
                comandos2.Parameters.Add("@valorods", SqlDbType.Float).Value = impvrgtotal
                comandos2.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod2(0)
                comandos2.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin2(0)
                comandos2.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre2(0)
                comandos2.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util2(0)
                comandos2.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt2(0)
                comandos2.Parameters.Add("@iva1", SqlDbType.Float).Value = iva2(0)
                comandos2.Parameters.Add("@VrTotal1 ", SqlDbType.Float).Value = total2(0)
                comandos2.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod2(1)
                comandos2.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin2(1)
                comandos2.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre2(1)
                comandos2.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util2(1)
                comandos2.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt2(1)
                comandos2.Parameters.Add("@iva2", SqlDbType.Float).Value = iva2(1)
                comandos2.Parameters.Add("@VrTotal2", SqlDbType.Float).Value = total2(1)
                comandos2.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod2(2)
                comandos2.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin2(2)
                comandos2.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre2(2)
                comandos2.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util2(2)
                comandos2.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt2(2)
                comandos2.Parameters.Add("@iva3", SqlDbType.Float).Value = iva2(2)
                comandos2.Parameters.Add("@VrTotal3", SqlDbType.Float).Value = total2(2)
                comandos2.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod2(3)
                comandos2.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin2(3)
                comandos2.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre2(3)
                comandos2.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util2(3)
                comandos2.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt2(3)
                comandos2.Parameters.Add("@iva4", SqlDbType.Float).Value = iva2(3)
                comandos2.Parameters.Add("@VrTotal4", SqlDbType.Float).Value = total2(3)
                comandos2.ExecuteNonQuery()
                conexion.Close()
                ComboBox1.Enabled = False
                TextBox3.Enabled = False
                Button2.Enabled = False
                cmbmodificacion.Enabled = False
                txtnota.Enabled = False
                grptime.Enabled = False
                btndistribuir.Enabled = False
                CheckBox5.Enabled = False
                avanceods.Enabled = False
                btguardar.Enabled = False
                btguardar.Enabled = False
                impods.Enabled = True
                paso3()
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod15-fun-02:" & "_" & ex.Message)
            End Try
        End If

        If cmbmodificacion.SelectedIndex = 2 Then
            Try
                comandos3.CommandType = CommandType.StoredProcedure
                comandos3.CommandText = "odsmodificanotaentrega"
                comandos3.Connection = conexion
                comandos3.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
                comandos3.Parameters.Add("@Notaentrega", SqlDbType.NVarChar).Value = txtnota.Text
                comandos3.ExecuteNonQuery()
                conexion.Close()
                ComboBox1.Enabled = False
                TextBox3.Enabled = False
                Button2.Enabled = False
                cmbmodificacion.Enabled = False
                txtnota.Enabled = False
                grptime.Enabled = False
                btndistribuir.Enabled = False
                CheckBox5.Enabled = False
                avanceods.Enabled = False
                btguardar.Enabled = False
                MsgBox("Registro actualizado")
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod15-fun-03:" & "_" & ex.Message)
            End Try
        End If

        If cmbmodificacion.SelectedIndex = 3 Then
            Try
                comandos4.CommandType = CommandType.StoredProcedure
                comandos4.CommandText = "odsmodificatiempo"
                comandos4.Connection = conexion
                comandos4.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
                comandos4.Parameters.Add("@FechInicio", SqlDbType.DateTime).Value = DateTimePicker6.Value.Date
                comandos4.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = DateTimePicker5.Value.Date
                comandos4.Parameters.Add("@dias", SqlDbType.Int).Value = tiempods.Text()
                comandos4.ExecuteNonQuery()
                conexion.Close()
                ComboBox1.Enabled = False
                TextBox3.Enabled = False
                Button2.Enabled = False
                cmbmodificacion.Enabled = False
                txtnota.Enabled = False
                grptime.Enabled = False
                btndistribuir.Enabled = False
                CheckBox5.Enabled = False
                avanceods.Enabled = False
                btguardar.Enabled = False
                MsgBox("Registro actualizado")
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod15-fun-04:" & "_" & ex.Message)
            End Try
        End If

        If cmbmodificacion.SelectedIndex = 4 Then
            Try
                comandos4.CommandType = CommandType.StoredProcedure
                comandos4.CommandText = "odsmodificadescripccion"
                comandos4.Connection = conexion
                comandos4.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
                comandos4.Parameters.Add("@descripccion", SqlDbType.NVarChar).Value = textdescripcion.Text()
                comandos4.ExecuteNonQuery()
                conexion.Close()
                ComboBox1.Enabled = False
                TextBox3.Enabled = False
                Button2.Enabled = False
                cmbmodificacion.Enabled = False
                txtnota.Enabled = False
                grptime.Enabled = False
                btndistribuir.Enabled = False
                CheckBox5.Enabled = False
                avanceods.Enabled = False
                btguardar.Enabled = False
                MsgBox("Registro actualizado")
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod15-fun-04:" & "_" & ex.Message)
            End Try
        End If

    End Sub
    Private Sub paso2()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            Dim str3 As String
            str3 = "Update ODS SET estado = '" & Estadoods.Text & "', VALIDAADMIN = '" & chktext & "' Where Identificador = '" & Id.Text & "'"
            comandos3 = New SqlCommand(str3, conexion)
            comandos3.ExecuteNonQuery()
            MsgBox("Guardado Corectamente", vbInformation, ("Guardado"))
            btguardar.Enabled = False
            CheckBox5.Enabled = False
            impods.Enabled = True
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod15-fun-03:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub paso3()
        REM MsgBox("entro a guardar " & restadirecto(0))
        REM actualiza los saldos en el CM
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos4.CommandType = CommandType.StoredProcedure
            comandos4.CommandText = "odsactualizasaldocm"
            comandos4.Connection = conexion
            comandos4.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = ComboBox1.Text
            comandos4.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = restadirecto(0)
            comandos4.Parameters.Add("@Administracion1", SqlDbType.Float).Value = restaadmin(0)
            comandos4.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = restaimpre(0)
            comandos4.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = restautil(0)
            comandos4.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = restasubtotal(0)
            comandos4.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = restaiva(0)
            comandos4.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = restatotal(0)
            comandos4.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = restadirecto(1)
            comandos4.Parameters.Add("@Administracion2", SqlDbType.Float).Value = restaadmin(1)
            comandos4.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = restaimpre(1)
            comandos4.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = restautil(1)
            comandos4.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = restasubtotal(1)
            comandos4.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = restaiva(1)
            comandos4.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = restatotal(1)
            comandos4.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = restadirecto(3)
            comandos4.Parameters.Add("@Administracion3", SqlDbType.Float).Value = restaadmin(3)
            comandos4.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = restaimpre(3)
            comandos4.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = restautil(3)
            comandos4.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = restasubtotal(3)
            comandos4.Parameters.Add("@iva3", SqlDbType.Float).Value = restaiva(3)
            comandos4.Parameters.Add("@VrTotal3 ", SqlDbType.Float).Value = restatotal(3)
            comandos4.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = restadirecto(3)
            comandos4.Parameters.Add("@Administracion4", SqlDbType.Float).Value = restaadmin(3)
            comandos4.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = restaimpre(3)
            comandos4.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = restautil(3)
            comandos4.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = restasubtotal(3)
            comandos4.Parameters.Add("@iva4", SqlDbType.Float).Value = restaiva(3)
            comandos4.Parameters.Add("@VrTotal4 ", SqlDbType.Float).Value = restatotal(3)
            comandos4.Parameters.Add("@VALOR1", SqlDbType.Float).Value = newvigencia(0) REM guarda el valor la vigencia
            comandos4.Parameters.Add("@VALOR2", SqlDbType.Float).Value = newvigencia(1)
            comandos4.Parameters.Add("@VALOR3", SqlDbType.Float).Value = newvigencia(2)
            comandos4.Parameters.Add("@VALOR4", SqlDbType.Float).Value = newvigencia(3)
            comandos4.Parameters.Add("@VALOR5", SqlDbType.Float).Value = newvigencia(4)
            comandos4.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = CDbl(Label78.Text)
            comandos4.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = CDbl(restadirecto(4))
            comandos4.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = CDbl(restaadmin(4))
            comandos4.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = CDbl(restaimpre(4))
            comandos4.Parameters.Add("@saldoutil", SqlDbType.Float).Value = CDbl(restautil(4))
            comandos4.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = CDbl(restasubtotal(4))
            comandos4.Parameters.Add("@saldoiva", SqlDbType.Float).Value = CDbl(restaiva(4))
            comandos4.Parameters.Add("@saldototal", SqlDbType.Float).Value = CDbl(restatotal(4))
            comandos4.ExecuteNonQuery()
            conexion.Close()
            MsgBox("Registro actualizado")
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod15-fun-04:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub guardar2()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos5.CommandText = "INSERT INTO avancesaprobados ( Identificador, Avance1, Avance2, Avance3, Avance4, Avance5, Avance6, Avance7, Avance8, Avance9, Avance10) VALUES (@Identificador, @Avance1, @Avance2, @Avance3, @Avance4, @Avance5, @Avance6, @Avance7, @Avance8, @Avance9, @Avance10)"
            comandos5.CommandTimeout = 15
            comandos5.CommandType = CommandType.Text
            comandos5.Connection = conexion
            comandos5.Parameters.AddWithValue("@Identificador", Id.Text)
            comandos5.Parameters.AddWithValue("@Avance1", 0)
            comandos5.Parameters.AddWithValue("@Avance2", 0)
            comandos5.Parameters.AddWithValue("@Avance3", 0)
            comandos5.Parameters.AddWithValue("@Avance4", 0)
            comandos5.Parameters.AddWithValue("@Avance5", 0)
            comandos5.Parameters.AddWithValue("@Avance6", 0)
            comandos5.Parameters.AddWithValue("@Avance7", 0)
            comandos5.Parameters.AddWithValue("@Avance8", 0)
            comandos5.Parameters.AddWithValue("@Avance9", 0)
            comandos5.Parameters.AddWithValue("@Avance10", 0)
            comandos5.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod15-fun-05:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub enviarmail()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = eadmin.Text + ";" + ecreado.Text + ";" + eplanner
        For Each myprocess In Process.GetProcesses
            'If myprocess.MainWindowTitle.Contains("@Microsoft Outlook") Then
            '* Creamos un Objeto que hará referencia a nuestra aplicación Outlook 
            Dim m_OutLook As Outlook.Application
            Try
                '* Creamos un Objeto tipo Mail 
                Dim objMail As Outlook.MailItem
                '* Inicializamos nuestra apliación OutLook 
                m_OutLook = CreateObject("Outlook.Application")
                '* Creamos una instancia de un objeto tipo MailItem 
                objMail = m_OutLook.CreateItem(Outlook.OlItemType.olMailItem)
                '* Asignamos las propiedades a nuestra Instancial del objeto 
                '* MailItem 
                objMail.To = vldestinatarios
                objMail.Subject = "La Orden de servicio #" & " " + number & " " + " ha cambiado de estado"
                objMail.Body = "La Orden de servicio #" & " " & number & " " & "ha sido creado por el usuario." & " " + txtcreado1.Text & " " & "y fue aprobada por el administrador." & " " & cmbadmin1.Text & vbCrLf & "Su alcance es:" & " " & textdescripcion.Text & " " & " Su estado actual es En Ejecución." & vbCrLf & "Mensaje Automatico Generado por el sistema de control de contratos de Pacific Rubiales Energy, si tiene alguna inquietud, por favor ponerse en contacto con el soporte administrativo:" & " " & cname.Text
                objMail.Send()
                Exit For
            Catch ex As Exception
                '* Si se produce algun Error 
                respuesta = MsgBox("No se ha podido notificar a los interezados, Desea reintentar enviar la notificacion?", MsgBoxStyle.YesNo, "Se ha producido un error al notificar")
                If respuesta = vbYes Then
                    Shell("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", AppWinStyle.MinimizedNoFocus)
                    enviarmail()
                ElseIf respuesta = vbNo Then
                    Exit For
                End If
                Exit Sub
            Finally
                m_OutLook = Nothing ' Destruimos el objeto (recoger la basura...)
            End Try
            'End If
        Next
    End Sub
    Private Sub impods_Click(sender As System.Object, e As System.EventArgs) Handles impods.Click
        numero2 = 1
        Dim mireporte As ods
        mireporte = New ods
        mireporte.Modelo1 = Id.Text
        mireporte.Show()
    End Sub
    Friend Sub modalidad()
        If modo = 4 Then
            costod1.Text = verestructuraods.txtcostdglobal.Text
            admin1.Text = verestructuraods.txtcostadminglobal.Text
            impre1.Text = verestructuraods.txtcostimpglobal.Text
            util1.Text = verestructuraods.txtcostutilglobal.Text
            subt1.Text = verestructuraods.txtcostsubglobal.Text
            iva1.Text = verestructuraods.txtcostivaglobal.Text
            total1.Text = verestructuraods.vrgtotal.Text
            btndistribuir.Enabled = False
            CheckBox5.Enabled = True
            If cmbmodificacion.SelectedIndex = 1 Then
                contabilizarcm()
                updatevigencia()
            End If
        End If
    End Sub
    Private Sub valida()
        If Estadoods.Text.Trim = "Preliminar".Trim Then
            avanceods.Enabled = False
            cmbmodificacion.Enabled = False
            Me.BackColor = System.Drawing.Color.Gainsboro()
            If My.Settings.usuario2 = cmbadmin1.Text Or TextBox1.Text.Trim = My.Settings.usuario2.Trim Then
                btndistribuir.Enabled = True
                CheckBox5.Visible = True
                cmbmodificacion.Enabled = False
                avanceods.Enabled = False
            Else
                CheckBox5.Visible = False
                btndistribuir.Enabled = False
                avanceods.Enabled = False
            End If
        Else
            CheckBox5.Visible = False
            btndistribuir.Enabled = False
            avanceods.Enabled = False
        End If

        If Estadoods.Text.Trim = "Ejecucion".Trim Then
            If My.Settings.usuario2 = txtcreado1.Text Or TextBox1.Text.Trim = My.Settings.usuario2.Trim Then
                avanceods.Enabled = True
                Me.BackColor = System.Drawing.Color.White
                cmbmodificacion.Enabled = True

            Else
                avanceods.Enabled = False
                cmbmodificacion.Enabled = False
            End If
        End If
    End Sub
    Private Sub btndistribuir_Click(sender As System.Object, e As System.EventArgs) Handles btndistribuir.Click
        REM  alertas()
        If cmbmodificacion.SelectedIndex = 1 Then
            If txtvigencia.Text <= 0 Then
                MsgBox("No se puede modificar la ODS, ya que no se tiene saldo en la vigencia", MsgBoxStyle.Exclamation)
            Else
                For i As Integer = 0 To 4
                    restadirecto(i) = 0
                    restaadmin(i) = 0
                    restaimpre(i) = 0
                    restautil(i) = 0
                    restaiva(i) = 0
                    restasubtotal(i) = 0
                    restatotal(i) = 0
                    newvigencia(i) = 0
                Next
                verestructuraods.modificacion()
                verestructuraods.ShowDialog()
                CheckBox5.Visible = True
                REM CheckBox5.Enabled = True
            End If
        End If
        If cmbmodificacion.SelectedIndex = 0 Then
            verestructuraods.ShowDialog()
        End If
        verestructuraods.Dispose()
        REM CheckBox5.Enabled = True
    End Sub
    Private Sub saldovigencia_TextChanged_1(sender As Object, e As EventArgs) Handles saldovigencia.TextChanged
        If saldovigencia.Text = "" Then saldovigencia.Text = 0
        saldovigencia.Text = FormatNumber(CDbl(saldovigencia.Text), 2)
    End Sub
    Private Sub contabilizarcm()

        REM  MsgBox("Entra el valor del costodirecto nivel 1   " & verestructuraods.restadirecto(0))
        REM resta los valores de la primera linea de la ODS y se la pone al contrato.

        restadirecto(0) = FormatNumber(CDbl(impcd1.Text) + CDbl(verestructuraods.restadirecto(0)))
        restaadmin(0) = FormatNumber(CDbl(impadm1.Text) + CDbl(verestructuraods.restaadmin(0)))
        restaimpre(0) = FormatNumber(CDbl(impimp1.Text) + CDbl(verestructuraods.restaimpre(0)))
        restautil(0) = FormatNumber(CDbl(imputi1.Text) + CDbl(verestructuraods.restautil(0)))
        restasubtotal(0) = FormatNumber(CDbl(impsubto1.Text) + CDbl(verestructuraods.restasubtotal(0)))
        restaiva(0) = FormatNumber(CDbl(impiva1.Text) + CDbl(verestructuraods.restaiva(0)))
        restatotal(0) = FormatNumber(CDbl(imptotal1.Text) + CDbl(verestructuraods.restatotal(0)))

        restadirecto(1) = FormatNumber(CDbl(impcd2.Text) + CDbl(verestructuraods.restadirecto(1)))
        restaadmin(1) = FormatNumber(CDbl(impadm2.Text) + CDbl(verestructuraods.restaadmin(1)))
        restaimpre(1) = FormatNumber(CDbl(impimp2.Text) + CDbl(verestructuraods.restaimpre(1)))
        restautil(1) = FormatNumber(CDbl(imputi2.Text) + CDbl(verestructuraods.restautil(1)))
        restasubtotal(1) = FormatNumber(CDbl(impsubto2.Text) + CDbl(verestructuraods.restasubtotal(1)))
        restaiva(1) = FormatNumber(CDbl(impiva2.Text) + CDbl(verestructuraods.restaiva(1)))
        restatotal(1) = FormatNumber(CDbl(imptotal2.Text) + CDbl(verestructuraods.restatotal(1)))

        REM resta los valores de la tercera linea de la ODS y se la pone al contrato.
        restadirecto(2) = FormatNumber(CDbl(impcd3.Text) + CDbl(verestructuraods.restadirecto(2)))
        restaadmin(2) = FormatNumber(CDbl(impadm3.Text) + CDbl(verestructuraods.restaadmin(2)))
        restaimpre(2) = FormatNumber(CDbl(impimp3.Text) + CDbl(verestructuraods.restaimpre(2)))
        restautil(2) = FormatNumber(CDbl(imputi3.Text) + CDbl(verestructuraods.restautil(2)))
        restasubtotal(2) = FormatNumber(CDbl(impsubto3.Text) + CDbl(verestructuraods.restasubtotal(2)))
        restaiva(2) = FormatNumber(CDbl(impiva3.Text) + CDbl(verestructuraods.restaiva(2)))
        restatotal(2) = FormatNumber(CDbl(imptotal3.Text) + CDbl(verestructuraods.restatotal(2)))

        REM resta los valores de la cuarta linea de la ODS y se la pone al contrato.
        restadirecto(3) = FormatNumber(CDbl(impcd4.Text) + CDbl(verestructuraods.restadirecto(3)))
        restaadmin(3) = FormatNumber(CDbl(impadm4.Text) + CDbl(verestructuraods.restaadmin(3)))
        restaimpre(3) = FormatNumber(CDbl(impimp4.Text) + CDbl(verestructuraods.restaimpre(3)))
        restautil(3) = FormatNumber(CDbl(imputi4.Text) + CDbl(verestructuraods.restautil(3)))
        restasubtotal(3) = FormatNumber(CDbl(impsubto4.Text) + CDbl(verestructuraods.restasubtotal(3)))
        restaiva(3) = FormatNumber(CDbl(impiva4.Text) + CDbl(verestructuraods.restaiva(3)))
        restatotal(3) = FormatNumber(CDbl(imptotal4.Text) + CDbl(verestructuraods.restatotal(3)))

        REM resta los valores de la quinta linea de la ODS y se la pone al contrato.
        restadirecto(4) = FormatNumber(CDbl(traecostd.Text) + CDbl(verestructuraods.restadirecto(4)))
        restaadmin(4) = FormatNumber(CDbl(traeadmin.Text) + CDbl(verestructuraods.restaadmin(4)))
        restaimpre(4) = FormatNumber(CDbl(traeimpre.Text) + CDbl(verestructuraods.restaimpre(4)))
        restautil(4) = FormatNumber(CDbl(traeutil.Text) + CDbl(verestructuraods.restautil(4)))
        restasubtotal(4) = FormatNumber(CDbl(traesubt.Text) + CDbl(verestructuraods.restasubtotal(4)))
        restaiva(4) = FormatNumber(CDbl(traeiva.Text) + CDbl(verestructuraods.restaiva(4)))
        restatotal(4) = FormatNumber(CDbl(traetotal.Text) + CDbl(verestructuraods.restatotal(4)))

    End Sub
    Private Sub updatevigencia()
        anovigencia.Text = Year(hoy)
        If anovigencia.Text = ano1.Text Then
            If verestructuraods.desviacion.Text = 0 Then
                saldovigencia.Text = 0
            Else
                saldovigencia.Text = FormatNumber(CDbl(verestructuraods.desviacion.Text))
            End If
            newvigencia(0) = saldovigencia.Text
        Else
            newvigencia(0) = FormatNumber(CDbl(vigencia1.Text))
        End If

        If anovigencia.Text = ano2.Text Then
            If verestructuraods.desviacion.Text = 0 Then
                saldovigencia.Text = 0
            Else
                saldovigencia.Text = FormatNumber(CDbl(verestructuraods.desviacion.Text))
            End If
            newvigencia(1) = saldovigencia.Text
        Else
            newvigencia(1) = FormatNumber(CDbl(Vigencia2.Text))
        End If

        If anovigencia.Text = ano3.Text Then
            If verestructuraods.desviacion.Text = 0 Then
                saldovigencia.Text = 0
            Else
                saldovigencia.Text = FormatNumber(CDbl(verestructuraods.desviacion.Text))
            End If
            newvigencia(2) = saldovigencia.Text
        Else
            newvigencia(2) = FormatNumber(CDbl(Vigencia3.Text))
        End If

        If anovigencia.Text = ano4.Text Then
            If verestructuraods.desviacion.Text = 0 Then
                saldovigencia.Text = 0
            Else
                saldovigencia.Text = FormatNumber(CDbl(verestructuraods.desviacion.Text))
            End If
            newvigencia(3) = saldovigencia.Text
        Else
            newvigencia(3) = FormatNumber(CDbl(vigencia4.Text))
        End If

        If anovigencia.Text = ano5.Text Then
            If verestructuraods.desviacion.Text = 0 Then
                saldovigencia.Text = 0
            Else
                saldovigencia.Text = FormatNumber(CDbl(verestructuraods.desviacion.Text))
            End If

            newvigencia(4) = saldovigencia.Text
        Else
            newvigencia(4) = FormatNumber(CDbl(vigencia5.Text))
        End If

        Label78.Text = FormatNumber(CDbl(txtvigencia.Text) - CDbl(saldovigencia.Text))
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
          Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
            number = ComboBox1.Text & "-" & TextBox3.Text
            Me.CMNuevosBindingSource.Filter = "Contratos ='" & ComboBox1.Text & "'"
            Me.ODSBindingSource.Filter = "Identificador ='" & number & "'"
            If textdescripcion.Text = "" Then
                btndistribuir.Enabled = False
                avanceods.Enabled = False
                MsgBox("La ODS # " & number & " No existe")
            Else
                Id.Text = number
            End If

            vigencia()
            valida()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
        number = ComboBox1.Text & "-" & TextBox3.Text
        Me.CMNuevosBindingSource.Filter = "Contratos ='" & ComboBox1.Text & "'"
        Me.ODSBindingSource.Filter = "Identificador ='" & number & "'"
        If textdescripcion.Text = "" Then
            btndistribuir.Enabled = False
            avanceods.Enabled = False
            MsgBox("La ODS # " & number & " No existe")
        Else
            Id.Text = number
        End If

        vigencia()
        valida()
    End Sub
    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        ecreado.Text = txtcreado1.Text & "@pacificrubiales.com.co"
        cname.Text = txtcreado1.Text
        eadmin.Text = cmbadmin1.Text & "@pacificrubiales.com.co"
        eplanner = TextBox2.Text & "@pacificrubiales.com.co"
        textdescripcion.Enabled = False
    End Sub
    Private Sub Id_TextChanged(sender As Object, e As EventArgs) Handles Id.TextChanged
        cmbmodificacion.SelectedIndex = 0
        CheckBox5.Checked = False
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class