Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Text
Imports System.Drawing
Imports System.Data.SqlClient

Public Class rcierreods
    Dim db As IDbConnection
    Dim midataset As DataSet
    Dim mienlazador As New BindingSource
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim comandos2 As New SqlCommand
    Dim comandos3 As New SqlCommand
    Friend chktext
    Friend hoy As Date
    Friend numero2 As String
    Dim eplanner As String
    Friend saldo As Double
    Friend impcostod As Double
    Friend impadmin As Double
    Friend imputil As Double
    Friend impimpre As Double
    Friend impsubtcost As Double
    Friend impiva As Double
    Friend imptotal As Double
    Friend costod2(7) As Double
    Friend admin2(7) As Double
    Friend impre2(7) As Double
    Friend util2(7) As Double
    Friend subt2(7) As Double
    Friend iva2(7) As Double
    Friend total2(7) As Double
    Friend impsuma(3) As String
    Friend resta(6)
    Friend impcostodods(4)
    Dim sumacosd(4)
    Dim sumaadmin(4)
    Dim sumaimpre(4)
    Dim sumautil(4)
    Dim sumasubt(4)
    Dim sumaiva(4)
    Dim sumavrtotal(4)
    Dim number As String
    Dim newvigencia As Double
    Private Sub form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        hoy = System.DateTime.Now.Date
        REM  Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet1.ODS' Puede moverla o quitarla según sea necesario.
        Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        number = cmbcontrato1.Text & "-" & idods.Text
        vigencia()
        REM cmbcontrato1.Items.Add(number.Trim)
        Me.ODSBindingSource.Filter = "Identificador ='" & number & "'"
        Id.Text = number

    End Sub
    Private Sub textdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles textdescripcion.TextChanged
        If bloqueo.Text <> "" Then
            MsgBox("Este contrato se encuentra bloqueado por el usuario " & bloqueo.Text & " Por favor espere unos minutos e ingrese nuevamente")
            grpopccion.Enabled = False
        Else
            valida()
        End If
    End Sub
    Private Sub impods_Click(sender As System.Object, e As System.EventArgs) Handles impods.Click
            numero2 = 1
            Dim mireporte As ods
            mireporte = New ods
        mireporte.Modelo1 = Id.Text
        mireporte.Show()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
        frmmenu.Show()
    End Sub
    Private Sub enviarmail()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = eadmin.Text + ";" + ecreado.Text + ";" + esoporte.Text + ";" + eplanner + ";" + "jugarzon@Pacificrubiales.com.co"
        For Each myprocess In Process.GetProcesses
            'If myprocess.MainWindowTitle.Contains("Microsoft Outlook") Then
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
                objMail.Subject = "La Orden de servicio #" & " " + Id.Text & " " + " ha sido cerrada"
                objMail.Body = "La Orden de servicio #" & " " & Id.Text & " " & "ha sido cerrada por el usuario." & " " + cname.Text & " " & "" & vbCrLf & "Mensaje Automatico Generado por el sistema de control de contratos de Pacific Rubiales Energy, si tiene alguna inquietud, por favor ponerse en contacto con el soporte administrativo:" & " " & cname.Text
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
    Private Sub CheckBox5_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkconfirma.CheckStateChanged
        If chkconfirma.Checked = True Then
            sumar1()
            Me.ErrorProvider2.Clear()
            btguardar.Enabled = True
            chktext = hoy & "" & txtcreado1.Text
            cmbcontrato1.Enabled = False
            idods.Enabled = False
            Button2.Enabled = False
        Else
            btguardar.Enabled = False
            Me.ErrorProvider2.SetError(chkconfirma, "Por favor guarde")
            cmbcontrato1.Enabled = True
            idods.Enabled = True
            Button2.Enabled = True
        End If
    End Sub
    Private Sub txtcreado1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcreado1.TextChanged
        ecreado.Text = txtcreado1.Text & "@pacificrubiales.com.co"
        cname.Text = txtcreado1.Text
    End Sub
    Private Sub cmbadmin1_TextChanged(sender As System.Object, e As System.EventArgs) Handles cmbadmin1.TextChanged
        eadmin.Text = cmbadmin1.Text & "@pacificrubiales.com.co"
        esoporte.Text = spadmin.Text & "@pacificrubiales.com.co"
        eplanner = TextBox2.Text & "@pacificrubiales.com.co"
    End Sub
    Private Sub Id_TextChanged(sender As System.Object, e As System.EventArgs) Handles Id.TextChanged
        Me.CMNuevosBindingSource.Filter = "Contratos = '" & Id.Text & "'"
    End Sub
    Function dejarNumerosPuntos(cadenaTexto As String) As String
        Const listaNumeros = "0123456789,."
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = "0" Then
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
    Private Sub valida()
        If My.Settings.usuario2 = txtcreado1.Text Or My.Settings.usuario2 = spadmin.Text Then
            valorfinal.Enabled = False
            chkconfirma.Enabled = False
            valorfinal.Enabled = False
            valorfinal.Text = "0"
            Estadoods.Enabled = False
            grpopccion.Enabled = True
            grpopccion.Visible = True
            cerrarods.Enabled = False
            candadoods.Enabled = False
            If Estadoods.Text = "Ejecucion" Then
                cerrarods.Enabled = True
                candadoods.Enabled = True
            End If
            If Estadoods.Text.Trim = "Candado".Trim Then
                candadoods.Enabled = True
                cerrarods.Enabled = False
            End If
        Else
            valorfinal.Enabled = False
            grpopccion.Enabled = False
        End If
    End Sub

    Private Sub btndistribuir_Click(sender As System.Object, e As System.EventArgs) Handles btndistribuir.Click
        cierreestructuraods.ods = Id.Text.Trim
        cierreestructuraods.contrato = cmbcontrato1.Text.Trim
        cierreestructuraods.ShowDialog()
        cierreestructuraods.Dispose()
        Me.ErrorProvider2.SetError(chkconfirma, "Por favor guarde.")
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

    Private Sub valorfinal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles valorfinal.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            valorfinal.Text = FormatNumber(CDbl(valorfinal.Text), 2)
        End If
    End Sub

    Private Sub valorfinal_LostFocus(sender As Object, e As System.EventArgs) Handles valorfinal.LostFocus
        If valorfinal.Text = "" Then valorfinal.Text = 0
        valorfinal.Text = FormatNumber(CDbl(valorfinal.Text), 2)
    End Sub

    Private Sub valorfinal_TextChanged(sender As System.Object, e As System.EventArgs) Handles valorfinal.TextChanged
        valorfinal.Text = Trim(dejarNumerosPuntos(valorfinal.Text))
        If (String.IsNullOrEmpty(valorfinal.Text.Trim())) Then
            Me.ErrorProvider1.SetError(valorfinal, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            If CDbl(valorfinal.Text) = FormatNumber(CDbl(costod1.Text)) Then
                btndistribuir.Enabled = False
                chkconfirma.Enabled = True
                chkconfirma.Visible = True
                Estadoods.Text = "Concluida"
            End If
            If CDbl(total1.Text) > CDbl(valorfinal.Text) Then
                saldo = (costod1.Text) - CDbl(valorfinal.Text)
                btndistribuir.Enabled = True
            End If
            If CDbl(valorfinal.Text) > CDbl(costod1.Text) Then
                MsgBox("El valor ingresado no puede ser superior al valor original de la ODS.")
                valorfinal.Text = 0
                btndistribuir.Enabled = False
            End If
        End If

    End Sub
    Private Sub cmbcontrato1_TextChanged(sender As Object, e As System.EventArgs) Handles cmbcontrato1.TextChanged
        valorfinal.Text = "0"
    End Sub
    Friend Sub importar()
        TextBox3.Text = impcostod
        TextBox4.Text = impadmin
        TextBox5.Text = impimpre
        TextBox6.Text = imputil
        TextBox7.Text = impsubtcost
        TextBox8.Text = impiva
        TextBox9.Text = imptotal
        valorfinal.Enabled = False
        btndistribuir.Enabled = False
        chkconfirma.Enabled = True
        chkconfirma.Visible = True
    End Sub
    Friend Sub sumar1()
        TextBox10.Text = FormatNumber(CDbl(TextBox10.Text) + CDbl(TextBox3.Text))
        TextBox11.Text = FormatNumber(CDbl(TextBox11.Text) + CDbl(TextBox4.Text))
        TextBox12.Text = FormatNumber(CDbl(TextBox12.Text) + CDbl(TextBox5.Text))
        TextBox13.Text = FormatNumber(CDbl(TextBox13.Text) + CDbl(TextBox6.Text))
        TextBox14.Text = FormatNumber(CDbl(TextBox14.Text) + CDbl(TextBox7.Text))
        TextBox15.Text = FormatNumber(CDbl(TextBox15.Text) + CDbl(TextBox8.Text))
        nuevototal.Text = FormatNumber(CDbl(nuevototal.Text) + CDbl(TextBox9.Text))
        REM valor de la ODS 
        resta(0) = FormatNumber(CDbl(costod1.Text) - CDbl(TextBox3.Text))
        resta(1) = FormatNumber(CDbl(admin1.Text) - CDbl(TextBox4.Text))
        resta(2) = FormatNumber(CDbl(impre1.Text) - CDbl(TextBox5.Text))
        resta(3) = FormatNumber(CDbl(util1.Text) - CDbl(TextBox6.Text))
        resta(4) = FormatNumber(CDbl(subt1.Text) - CDbl(TextBox7.Text))
        resta(5) = FormatNumber(CDbl(iva1.Text) - CDbl(TextBox8.Text))
        resta(6) = FormatNumber(CDbl(total1.Text) - CDbl(TextBox9.Text))
        acumuladovigencia.Text = FormatNumber(CDbl(acumuladovigencia.Text) - CDbl(TextBox9.Text))
        Saldovigencia.Text = FormatNumber(CDbl(Saldovigencia.Text) + CDbl(valorfinal.Text))
    End Sub
    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox3.Text = FormatNumber(CDbl(TextBox3.Text), 2)
    End Sub
    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox4.Text = FormatNumber(CDbl(TextBox4.Text), 2)
    End Sub
    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged
        TextBox5.Text = FormatNumber(CDbl(TextBox5.Text), 2)
    End Sub
    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox6.TextChanged
        TextBox6.Text = FormatNumber(CDbl(TextBox6.Text), 2)
    End Sub
    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged
        TextBox7.Text = FormatNumber(CDbl(TextBox7.Text), 2)
    End Sub
    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox8.TextChanged
        TextBox8.Text = FormatNumber(CDbl(TextBox8.Text), 2)
    End Sub
    Private Sub TextBox9_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox9.TextChanged
        TextBox9.Text = FormatNumber(CDbl(TextBox9.Text), 2)
    End Sub
    Private Sub TextBox16_TextChanged(sender As System.Object, e As System.EventArgs) Handles nuevototal.TextChanged
        If nuevototal.Text = "" Then nuevototal.Text = 0
        nuevototal.Text = FormatNumber(CDbl(nuevototal.Text), 2)
    End Sub
    Private Sub TextBox10_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox10.TextChanged
        If TextBox10.Text = "" Then TextBox10.Text = 0
        TextBox10.Text = FormatNumber(CDbl(TextBox10.Text), 2)
    End Sub
    Private Sub TextBox11_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox11.TextChanged
        If TextBox11.Text = "" Then TextBox11.Text = 0
        TextBox11.Text = FormatNumber(CDbl(TextBox11.Text), 2)
    End Sub
    Private Sub TextBox12_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox12.TextChanged
        If TextBox12.Text = "" Then TextBox12.Text = 0
        TextBox12.Text = FormatNumber(CDbl(TextBox12.Text), 2)
    End Sub
    Private Sub TextBox13_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text = "" Then TextBox13.Text = 0
        TextBox13.Text = FormatNumber(CDbl(TextBox13.Text), 2)
    End Sub
    Private Sub TextBox14_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text = "" Then TextBox14.Text = 0
        TextBox14.Text = FormatNumber(CDbl(TextBox14.Text), 2)
    End Sub
    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text = "" Then TextBox15.Text = 0
        TextBox15.Text = FormatNumber(CDbl(TextBox15.Text), 2)
    End Sub
    Private Sub txtvigencia_TextChanged(sender As Object, e As System.EventArgs) Handles txtvigencia.TextChanged
        If txtvigencia.Text = "" Then txtvigencia.Text = 0
        txtvigencia.Text = FormatNumber(CDbl(txtvigencia.Text), 2)
    End Sub
    Private Sub mcostot_TextChanged(sender As Object, e As System.EventArgs) Handles mcostot.TextChanged
        If mcostot.Text = "" Then mcostot.Text = 0
        mcostot.Text = FormatNumber(CDbl(mcostot.Text), 2)
    End Sub
    Private Sub restarvalores()
        sumacosd(0) = 0
        sumaadmin(0) = 0
        sumaimpre(0) = 0
        sumautil(0) = 0
        sumasubt(0) = 0
        sumaiva(0) = 0
        sumavrtotal(0) = 0
        sumacosd(1) = 0
        sumaadmin(1) = 0
        sumaimpre(1) = 0
        sumautil(1) = 0
        sumasubt(1) = 0
        sumaiva(1) = 0
        sumavrtotal(1) = 0
        sumacosd(2) = 0
        sumaadmin(2) = 0
        sumaimpre(2) = 0
        sumautil(2) = 0
        sumasubt(2) = 0
        sumaiva(2) = 0
        sumavrtotal(2) = 0
        sumacosd(3) = 0
        sumaadmin(3) = 0
        sumaimpre(3) = 0
        sumautil(3) = 0
        sumasubt(3) = 0
        sumaiva(3) = 0
        sumavrtotal(3) = 0
        sumacosd(4) = 0
        sumaadmin(4) = 0
        sumaimpre(4) = 0
        sumautil(4) = 0
        sumasubt(4) = 0
        sumaiva(4) = 0
        sumavrtotal(4) = 0
    End Sub
    Private Sub btguardar_Click(sender As System.Object, e As System.EventArgs) Handles btguardar.Click
        If chkconfirma.Checked = True Then
            If conexion.State = ConnectionState.Open Then
            Else
                conexion.Open()
            End If
            If Estadoods.Text = "Candado" Then
                Dim str As String
                Try
                    str = "Update CMNuevos SET Costodirecto = '" & TextBox10.Text & "', Administracion = '" & TextBox11.Text & "', Imprevisto = '" & TextBox12.Text & "', Utilidad = '" & TextBox13.Text & "', Subtotal = '" & TextBox14.Text & "',  iva = '" & TextBox15.Text & "',  VrContrato = '" & nuevototal.Text & "', CostoDirecto1 = '" & costod2(0) & "', Administracion1 = '" & admin2(0) & "', Imprevistos1 = '" & impre2(0) & "', Utilidad1 = '" & util2(0) & "', Subtotal1 = '" & subt2(0) & "',  IVA1 = '" & iva2(0) & "',  VrTotal1 = '" & total2(0) & "', CostoDirecto2 = '" & costod2(1) & "', Administracion2 = '" & admin2(1) & "', Imprevistos2 = '" & impre2(1) & "', Utilidad2 = '" & util2(1) & "', Subtotal2 = '" & subt2(1) & "',  IVA2 = '" & iva2(1) & "',  VrTotal2 = '" & total2(1) & "', CostoDirecto3 = '" & costod2(2) & "', Administracion3 = '" & admin2(2) & "', Imprevistos3 = '" & impre2(2) & "', Utilidad3 = '" & util2(2) & "', Subtotal3 = '" & subt2(2) & "',  IVA3 = '" & iva2(2) & "',  VrTotal3 = '" & total2(2) & "', CostoDirecto4 = '" & costod2(3) & "', Administracion4 = '" & admin2(3) & "', Imprevistos4 = '" & impre2(3) & "', Utilidad4 = '" & util2(3) & "', Subtotal4 = '" & subt2(3) & "',  IVA4 = '" & iva2(3) & "',  VrTotal4 = '" & total2(3) & "' Where Contratos = '" & cmbcontrato1.Text & "'"
                    comandos = New SqlCommand(str, conexion)
                    comandos.ExecuteNonQuery()
                    conexion.Close()
                    MsgBox("Se actualizo correctamente el registro")
                    btguardar.Enabled = False
                Catch ex As Exception
                    MessageBox.Show("Notificar error codigo Mod25-fun-01:" & "_" & ex.Message)
                End Try
            End If

            REM buscar la forma de mover la ODS a la tabla CierreODS
            If Estadoods.Text = "Concluida" Then
                Dim str2 As String
                Try
                    If anovigencia.Text.Trim = ano1.Text.Trim Then
                        comandos3.CommandType = CommandType.StoredProcedure
                        comandos3.CommandText = "actualizacmcierreodsvigencia1"
                        comandos3.Connection = conexion
                        comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                        comandos3.Parameters.Add("@CostoDirecto", SqlDbType.Float).Value = TextBox10.Text
                        comandos3.Parameters.Add("@Administracion", SqlDbType.Float).Value = TextBox11.Text
                        comandos3.Parameters.Add("@Imprevistos", SqlDbType.Float).Value = TextBox12.Text
                        comandos3.Parameters.Add("@Utilidad", SqlDbType.Float).Value = TextBox13.Text
                        comandos3.Parameters.Add("@Subtotal", SqlDbType.Float).Value = TextBox14.Text
                        comandos3.Parameters.Add("@IVA", SqlDbType.NVarChar).Value = TextBox15.Text
                        comandos3.Parameters.Add("@VrContrato", SqlDbType.Float).Value = nuevototal.Text
                        comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod2(0)
                        comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin2(0)
                        comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre2(0)
                        comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util2(0)
                        comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt2(0)
                        comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = iva2(0)
                        comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = total2(0)
                        comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod2(1)
                        comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin2(1)
                        comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre2(1)
                        comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util2(1)
                        comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt2(1)
                        comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = iva2(1)
                        comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = total2(1)
                        comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod2(2)
                        comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin2(2)
                        comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre2(2)
                        comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util2(2)
                        comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt2(2)
                        comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = iva2(2)
                        comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = total2(2)
                        comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod2(3)
                        comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin2(3)
                        comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre2(3)
                        comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util2(3)
                        comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt2(3)
                        comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = iva2(3)
                        comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = total2(3)
                        comandos3.Parameters.Add("@VALOR1", SqlDbType.Float).Value = Saldovigencia.Text() REM guarda el valor la vigencia
                        comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = acumuladovigencia.Text()
                        comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = TextBox10.Text()
                        comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = TextBox11.Text()
                        comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = TextBox12.Text()
                        comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = TextBox13.Text()
                        comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = TextBox14.Text()
                        comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = TextBox15.Text()
                        comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = nuevototal.Text()
                    End If

                    If anovigencia.Text.Trim = ano2.Text.Trim Then
                        comandos3.CommandType = CommandType.StoredProcedure
                        comandos3.CommandText = "actualizacmcierreodsvigencia2"
                        comandos3.Connection = conexion
                        comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                        comandos3.Parameters.Add("@CostoDirecto", SqlDbType.Float).Value = TextBox10.Text
                        comandos3.Parameters.Add("@Administracion", SqlDbType.Float).Value = TextBox11.Text
                        comandos3.Parameters.Add("@Imprevistos", SqlDbType.Float).Value = TextBox12.Text
                        comandos3.Parameters.Add("@Utilidad", SqlDbType.Float).Value = TextBox13.Text
                        comandos3.Parameters.Add("@Subtotal", SqlDbType.Float).Value = TextBox14.Text
                        comandos3.Parameters.Add("@IVA", SqlDbType.NVarChar).Value = TextBox15.Text
                        comandos3.Parameters.Add("@VrContrato", SqlDbType.Float).Value = nuevototal.Text
                        comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod2(0)
                        comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin2(0)
                        comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre2(0)
                        comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util2(0)
                        comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt2(0)
                        comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = iva2(0)
                        comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = total2(0)
                        comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod2(1)
                        comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin2(1)
                        comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre2(1)
                        comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util2(1)
                        comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt2(1)
                        comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = iva2(1)
                        comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = total2(1)
                        comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod2(2)
                        comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin2(2)
                        comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre2(2)
                        comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util2(2)
                        comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt2(2)
                        comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = iva2(2)
                        comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = total2(2)
                        comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod2(3)
                        comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin2(3)
                        comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre2(3)
                        comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util2(3)
                        comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt2(3)
                        comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = iva2(3)
                        comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = total2(3)
                        comandos3.Parameters.Add("@VALOR2", SqlDbType.Float).Value = Saldovigencia.Text() REM guarda el valor la vigencia
                        comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = acumuladovigencia.Text()
                        comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = TextBox10.Text()
                        comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = TextBox11.Text()
                        comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = TextBox12.Text()
                        comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = TextBox13.Text()
                        comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = TextBox14.Text()
                        comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = TextBox15.Text()
                        comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = nuevototal.Text()
                    End If

                    If anovigencia.Text.Trim = ano3.Text.Trim Then
                        comandos3.CommandType = CommandType.StoredProcedure
                        comandos3.CommandText = "actualizacmcierreodsvigencia3"
                        comandos3.Connection = conexion
                        comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                        comandos3.Parameters.Add("@CostoDirecto", SqlDbType.Float).Value = TextBox10.Text
                        comandos3.Parameters.Add("@Administracion", SqlDbType.Float).Value = TextBox11.Text
                        comandos3.Parameters.Add("@Imprevistos", SqlDbType.Float).Value = TextBox12.Text
                        comandos3.Parameters.Add("@Utilidad", SqlDbType.Float).Value = TextBox13.Text
                        comandos3.Parameters.Add("@Subtotal", SqlDbType.Float).Value = TextBox14.Text
                        comandos3.Parameters.Add("@IVA", SqlDbType.NVarChar).Value = TextBox15.Text
                        comandos3.Parameters.Add("@VrContrato", SqlDbType.Float).Value = nuevototal.Text
                        comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod2(0)
                        comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin2(0)
                        comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre2(0)
                        comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util2(0)
                        comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt2(0)
                        comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = iva2(0)
                        comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = total2(0)
                        comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod2(1)
                        comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin2(1)
                        comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre2(1)
                        comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util2(1)
                        comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt2(1)
                        comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = iva2(1)
                        comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = total2(1)
                        comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod2(2)
                        comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin2(2)
                        comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre2(2)
                        comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util2(2)
                        comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt2(2)
                        comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = iva2(2)
                        comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = total2(2)
                        comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod2(3)
                        comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin2(3)
                        comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre2(3)
                        comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util2(3)
                        comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt2(3)
                        comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = iva2(3)
                        comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = total2(3)
                        comandos3.Parameters.Add("@VALOR3", SqlDbType.Float).Value = Saldovigencia.Text() REM guarda el valor la vigencia
                        comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = acumuladovigencia.Text()
                        comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = TextBox10.Text()
                        comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = TextBox11.Text()
                        comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = TextBox12.Text()
                        comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = TextBox13.Text()
                        comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = TextBox14.Text()
                        comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = TextBox15.Text()
                        comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = nuevototal.Text()
                    End If

                    If anovigencia.Text.Trim = ano4.Text.Trim Then
                        comandos3.CommandType = CommandType.StoredProcedure
                        comandos3.CommandText = "actualizacmcierreodsvigencia4"
                        comandos3.Connection = conexion
                        comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                        comandos3.Parameters.Add("@CostoDirecto", SqlDbType.Float).Value = TextBox10.Text
                        comandos3.Parameters.Add("@Administracion", SqlDbType.Float).Value = TextBox11.Text
                        comandos3.Parameters.Add("@Imprevistos", SqlDbType.Float).Value = TextBox12.Text
                        comandos3.Parameters.Add("@Utilidad", SqlDbType.Float).Value = TextBox13.Text
                        comandos3.Parameters.Add("@Subtotal", SqlDbType.Float).Value = TextBox14.Text
                        comandos3.Parameters.Add("@IVA", SqlDbType.NVarChar).Value = TextBox15.Text
                        comandos3.Parameters.Add("@VrContrato", SqlDbType.Float).Value = nuevototal.Text
                        comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod2(0)
                        comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin2(0)
                        comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre2(0)
                        comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util2(0)
                        comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt2(0)
                        comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = iva2(0)
                        comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = total2(0)
                        comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod2(1)
                        comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin2(1)
                        comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre2(1)
                        comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util2(1)
                        comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt2(1)
                        comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = iva2(1)
                        comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = total2(1)
                        comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod2(2)
                        comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin2(2)
                        comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre2(2)
                        comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util2(2)
                        comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt2(2)
                        comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = iva2(2)
                        comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = total2(2)
                        comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod2(3)
                        comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin2(3)
                        comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre2(3)
                        comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util2(3)
                        comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt2(3)
                        comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = iva2(3)
                        comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = total2(3)
                        comandos3.Parameters.Add("@VALOR4", SqlDbType.Float).Value = Saldovigencia.Text() REM guarda el valor la vigencia
                        comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = acumuladovigencia.Text()
                        comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = TextBox10.Text()
                        comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = TextBox11.Text()
                        comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = TextBox12.Text()
                        comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = TextBox13.Text()
                        comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = TextBox14.Text()
                        comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = TextBox15.Text()
                        comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = nuevototal.Text()
                    End If

                    If anovigencia.Text.Trim = ano5.Text.Trim Then
                        comandos3.CommandType = CommandType.StoredProcedure
                        comandos3.CommandText = "actualizacmcierreodsvigencia5"
                        comandos3.Connection = conexion
                        comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                        comandos3.Parameters.Add("@CostoDirecto", SqlDbType.Float).Value = TextBox10.Text
                        comandos3.Parameters.Add("@Administracion", SqlDbType.Float).Value = TextBox11.Text
                        comandos3.Parameters.Add("@Imprevistos", SqlDbType.Float).Value = TextBox12.Text
                        comandos3.Parameters.Add("@Utilidad", SqlDbType.Float).Value = TextBox13.Text
                        comandos3.Parameters.Add("@Subtotal", SqlDbType.Float).Value = TextBox14.Text
                        comandos3.Parameters.Add("@IVA", SqlDbType.NVarChar).Value = TextBox15.Text
                        comandos3.Parameters.Add("@VrContrato", SqlDbType.Float).Value = nuevototal.Text
                        comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod2(0)
                        comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin2(0)
                        comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre2(0)
                        comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util2(0)
                        comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt2(0)
                        comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = iva2(0)
                        comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = total2(0)
                        comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod2(1)
                        comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin2(1)
                        comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre2(1)
                        comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util2(1)
                        comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt2(1)
                        comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = iva2(1)
                        comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = total2(1)
                        comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod2(2)
                        comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin2(2)
                        comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre2(2)
                        comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util2(2)
                        comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt2(2)
                        comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = iva2(2)
                        comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = total2(2)
                        comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod2(3)
                        comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin2(3)
                        comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre2(3)
                        comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util2(3)
                        comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt2(3)
                        comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = iva2(3)
                        comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = total2(3)
                        comandos3.Parameters.Add("@VALOR5", SqlDbType.Float).Value = Saldovigencia.Text() REM guarda el valor la vigencia
                        comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = acumuladovigencia.Text()
                        comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = TextBox10.Text()
                        comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = TextBox11.Text()
                        comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = TextBox12.Text()
                        comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = TextBox13.Text()
                        comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = TextBox14.Text()
                        comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = TextBox15.Text()
                        comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = nuevototal.Text()
                    End If
                    comandos3.ExecuteNonQuery()
                    conexion.Close()
                    MsgBox("Se actualizo correctamente el registro")
                    btguardar.Enabled = False
                    chkconfirma.Enabled = False
                    impods.Enabled = True
                    guardar4()
                Catch ex As Exception
                    MessageBox.Show("Notificar error codigo Mod25-fun-02:" & "_" & ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub guardar4()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Dim str3 As String
        Try
            comandos2.CommandType = CommandType.StoredProcedure
            comandos2.CommandText = "guardarcierreods"
            comandos2.Connection = conexion
            comandos2.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
            comandos2.Parameters.Add("@CostoDirecto", SqlDbType.Float).Value = resta(0)
            comandos2.Parameters.Add("@Administracion", SqlDbType.Float).Value = resta(1)
            comandos2.Parameters.Add("@Imprevisto", SqlDbType.Float).Value = resta(2)
            comandos2.Parameters.Add("@Utilidad", SqlDbType.Float).Value = resta(3)
            comandos2.Parameters.Add("@Subtotal", SqlDbType.Float).Value = resta(4)
            comandos2.Parameters.Add("@iva", SqlDbType.Float).Value = resta(5)
            comandos2.Parameters.Add("@valorods", SqlDbType.Float).Value = resta(6)
            comandos2.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod2(4)
            comandos2.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin2(4)
            comandos2.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre2(4)
            comandos2.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util2(4)
            comandos2.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt2(4)
            comandos2.Parameters.Add("@iva1", SqlDbType.Float).Value = iva2(4)
            comandos2.Parameters.Add("@VrTotal1 ", SqlDbType.Float).Value = total2(4)
            comandos2.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod2(5)
            comandos2.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin2(5)
            comandos2.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre2(5)
            comandos2.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util2(5)
            comandos2.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt2(5)
            comandos2.Parameters.Add("@iva2", SqlDbType.Float).Value = iva2(5)
            comandos2.Parameters.Add("@VrTotal2", SqlDbType.Float).Value = total2(5)
            comandos2.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod2(6)
            comandos2.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin2(6)
            comandos2.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre2(6)
            comandos2.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util2(6)
            comandos2.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt2(6)
            comandos2.Parameters.Add("@iva3", SqlDbType.Float).Value = iva2(6)
            comandos2.Parameters.Add("@VrTotal3", SqlDbType.Float).Value = total2(6)
            comandos2.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod2(7)
            comandos2.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin2(7)
            comandos2.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre2(7)
            comandos2.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util2(7)
            comandos2.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt2(7)
            comandos2.Parameters.Add("@iva4", SqlDbType.Float).Value = iva2(7)
            comandos2.Parameters.Add("@VrTotal4", SqlDbType.Float).Value = total2(7)
            comandos2.Parameters.Add("@estado", SqlDbType.NVarChar).Value = Estadoods.Text
            comandos2.Parameters.Add("@valorcierre", SqlDbType.Float).Value = valorfinal.Text
            comandos2.ExecuteNonQuery()
            conexion.Close()
            MsgBox("Se actualizo correctamente el registro")
            enviarmail()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod25-fun-03:" & "_" & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        REM Me.cmbcontrato1.DataSource = Nothing
        REM Me.cmbcontrato1.Items.Clear()
        vigencia()
        number = cmbcontrato1.Text & "-" & idods.Text
        REM cmbcontrato1.Items.Add(number.Trim)
        Me.ODSBindingSource.Filter = "Identificador ='" & number & "'"
        If textdescripcion.Text = "" Then
            MsgBox("La ODS # " & number & " No existe")
            chkconfirma.Enabled = False
            ErrorProvider2.Clear()
            Label55.Text = ""
        Else
            Id.Text = number
        End If
        REM cmbcontrato1.SelectedIndex = 0
    End Sub
    Private Sub TextBox16_KeyDown(sender As Object, e As KeyEventArgs) Handles idods.KeyDown
        If e.KeyCode = Keys.Enter Then
            vigencia()
            REM Me.cmbcontrato1.DataSource = Nothing
            REM Me.cmbcontrato1.Items.Clear()
            number = cmbcontrato1.Text & "-" & idods.Text
            REM cmbcontrato1.Items.Add(number.Trim)
            Me.ODSBindingSource.Filter = "Identificador ='" & number & "'"
            If textdescripcion.Text = "" Then
                MsgBox("La ODS # " & number & " No existe")
                chkconfirma.Enabled = False
                ErrorProvider2.Clear()
                Label55.Text = ""
            Else
                Id.Text = number

            End If
            REM cmbcontrato1.SelectedIndex = 0
        End If
    End Sub

    Private Sub cerrarods_Click(sender As Object, e As EventArgs) Handles cerrarods.Click
        grpopccion.Visible = False
        Me.ErrorProvider1.SetError(valorfinal, "Por favor ingrese el valor de cierre de la ODS.")
        valorfinal.Enabled = True
    End Sub

    Private Sub candadoods_Click(sender As Object, e As EventArgs) Handles candadoods.Click
        grpopccion.Visible = False
        Estadoods.Text = "Candado"
        Label55.Text = "Esta ODS se encuentra bloqueada por " & txtcreado1.Text
        chkconfirma.Enabled = True
        valorfinal.Enabled = False
        valorfinal.Text = 0
        btndistribuir.Enabled = False
        restarvalores()
        Me.ErrorProvider2.SetError(chkconfirma, "Por guarde.")
    End Sub
    Private Sub vigencia()
        anovigencia.Text = Year(hoy)
        If anovigencia.Text = ano1.Text Then
            txtvigencia.Text = vigenciaorg1.Text
            Saldovigencia.Text = Vigencia1.Text

        End If
        If anovigencia.Text = ano2.Text Then
            txtvigencia.Text = vigenciaorg2.Text
            Saldovigencia.Text = Vigencia2.Text
        End If
        If anovigencia.Text = ano3.Text Then
            txtvigencia.Text = vigenciaorg3.Text
            Saldovigencia.Text = Vigencia3.Text
        End If
        If anovigencia.Text = ano4.Text Then
            txtvigencia.Text = vigenciaorg4.Text
            Saldovigencia.Text = Vigencia4.Text
        End If
        If anovigencia.Text = ano5.Text Then
            txtvigencia.Text = vigenciaorg5.Text
            Saldovigencia.Text = Vigencia5.Text
        End If
    End Sub
    Private Sub cmbcontrato1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcontrato1.SelectedIndexChanged
        cerrarods.Enabled = False
        candadoods.Enabled = False
        ErrorProvider1.Clear()
        valorfinal.Text = 0
        grpopccion.Visible = True
    End Sub

    Private Sub mcostot_Click(sender As Object, e As EventArgs) Handles mcostot.Click

    End Sub

    Private Sub TextBox16_TextChanged_1(sender As Object, e As EventArgs) Handles idods.TextChanged

    End Sub

    Private Sub Saldovigencia_TextChanged(sender As Object, e As EventArgs) Handles Saldovigencia.TextChanged
        If Saldovigencia.Text = "" Then Saldovigencia.Text = 0
        Saldovigencia.Text = FormatNumber(CDbl(Saldovigencia.Text), 2)
    End Sub
  Private Sub Estadoods_TextChanged(sender As Object, e As EventArgs) Handles Estadoods.TextChanged
        If Estadoods.Text = "Concluida" Or Estadoods.Text = "Candado" Then
            impods.Enabled = True
        Else
            impods.Enabled = False
        End If
    End Sub
End Class

Module Module1
    Sub Main()
        ' Create an Outlook application.
        Dim oApp As Outlook.Application = New Outlook.Application()

        ' Get NameSpace and Logon.
        Dim oNS As Outlook.NameSpace = oApp.GetNamespace("mapi")
        oNS.Logon("YourValidProfile", Missing.Value, False, True) ' TODO:

        ' Create a new AppointmentItem.
        Dim oAppt As Outlook.AppointmentItem = oApp.CreateItem(Outlook.OlItemType.olAppointmentItem)
        'oAppt.Display(true)  'Modal	

        ' Set some common properties.
        oAppt.Subject = "Created using OOM in C#"
        oAppt.Body = "Hello World"
        oAppt.Location = "Samm E"

        oAppt.Start = Convert.ToDateTime("11/30/2001 9:00:00 AM")
        oAppt.End = Convert.ToDateTime("11/30/2001 1:00:00 PM")

        oAppt.ReminderSet = True
        oAppt.ReminderMinutesBeforeStart = 5
        oAppt.BusyStatus = Outlook.OlBusyStatus.olBusy  '  olBusy
        oAppt.IsOnlineMeeting = False

        ' Save to Calendar.
        oAppt.Save()

        ' Display.
        'oAppt.Display(true)

        ' Logoff.
        oNS.Logoff()

        ' Clean up.
        oApp = Nothing
        oNS = Nothing
        oAppt = Nothing
    End Sub

End Module
