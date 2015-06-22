Option Explicit On
Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Data.SqlClient

Public Class frmactualizarods
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim comandos1 As New SqlCommand
    Dim comandos2 As New SqlCommand
    Dim comandos3 As New SqlCommand
    Dim comandos4 As New SqlCommand
    Dim comandos5 As New SqlCommand
    Friend modo1 As Integer = 0
    Friend impcontratista As String
    Friend impnit As String
    Friend impproyectom As String
    Friend impproyecto As String
    Friend impprogramam As String
    Friend impprograma As String
    Friend subprograma As String
    Friend ident As String
    Friend hoy As Date
    Friend identif As Double
    Friend contractonumber As String
    Friend valorcontracto As String
    Friend servicio2(7) As String
    Friend nservicio2(7) As String
    Friend costod2(7) As Double
    Friend admin2(7) As Double
    Friend impre2(7) As Double
    Friend util2(7) As Double
    Friend subt2(7) As Double
    Friend iva2(7) As Double
    Friend total2(7) As Double
    Friend a2(7) As String
    Friend i2(7) As String
    Friend u2(7) As String
    Friend cosdirecto As String
    Friend imptxtcostadminglobal As String
    Friend imptxtcostimpglobal As String
    Friend imptxtcostutilglobal As String
    Friend imptxtcostsubglobal As String
    Friend imptxtcostivaglobal As String
    Friend impvrgtotal As String
    Friend nv(7) 'almacena los nuevos valores de la ODS.
    Friend chktext As String
    Friend impcostod(7)
    Friend impadmin(7)
    Friend impimpre(7)
    Friend imputil(7)
    Friend impsubtotal(7)
    Friend impiva(7)
    Friend imptotal(7)
    Dim eplanner As String
    Friend afe1 As String
    Friend afe2 As String
    Friend afe3 As String
    Friend afe4 As String
    Friend afe5 As String
    Friend afe6 As String
    Friend afeporc1 As Double
    Friend afeporc2 As Double
    Friend afeporc3 As Double
    Friend afeporc4 As Double
    Friend afeporc5 As Double
    Friend afeporc6 As Double
    Friend valor1 As Double
    Friend valor2 As Double
    Friend valor3 As Double
    Friend valor4 As Double
    Friend valor5 As Double
    Friend valor6 As Double
    Private Sub frmactualizar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Facilidades' Puede moverla o quitarla según sea necesario.
        Me.FacilidadesTableAdapter.Fill(Me.Adminco_MasterDataSet.Facilidades)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMOriginales' Puede moverla o quitarla según sea necesario.
        Me.CMOriginalesTableAdapter.Fill(Me.Adminco_MasterDataSet.CMOriginales)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ODS' Puede moverla o quitarla según sea necesario.
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Panner' Puede moverla o quitarla según sea necesario.
        Me.PannerTableAdapter.Fill(Me.Adminco_MasterDataSet.Panner)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Disciplina' Puede moverla o quitarla según sea necesario.
        Me.DisciplinaTableAdapter.Fill(Me.Adminco_MasterDataSet.Disciplina)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.disciplina2' Puede moverla o quitarla según sea necesario.
        Me.Disciplina2TableAdapter.Fill(Me.Adminco_MasterDataSet.disciplina2)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Admin' Puede moverla o quitarla según sea necesario.
        Me.AdminTableAdapter.Fill(Me.Adminco_MasterDataSet.Admin)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Maestros' Puede moverla o quitarla según sea necesario.
        Me.MaestrosTableAdapter.Fill(Me.Adminco_MasterDataSet.Maestros)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ListaProveedores' Puede moverla o quitarla según sea necesario.
        Me.ListaProveedoresTableAdapter.Fill(Me.Adminco_MasterDataSet.Listaproveedores)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        hoy = System.DateTime.Now.ToShortDateString()
        dtfecha1.Value = hoy
        dtfechai.Value = hoy
        dtfechaf.Value = hoy
        cmbcontrato1.Focus()
        anovigencia.Text = Year(dtfecha1.Value)
        cmbcontrato1.SelectedIndex = 0
        contador()
    End Sub
    Private Sub descripccioncm_TextChanged(sender As System.Object, e As System.EventArgs) Handles descripccioncm.TextChanged
        vigencia()
        contabilidad()
        validafecha()
        alertas()
        enunciaods.Text = ""
        If txtnota.Text = "" Then
            Me.ErrorProvider1.SetError(txtnota, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
        End If
        If porcentiempog.Text >= 100 Or avancedineroglobal.Text >= 100 Or avancedinerovigencia.Text >= 100 Then
            txtnota.Text = ""
            Id.Text = ""
            txtnota.Enabled = False
            txtarea.Enabled = False
            txtconsecutivo.Text = ""
            If txtnota.Text <> "" Then
                Me.ErrorProvider3.SetError(txtvigencia, "Este contrato no tiene saldo en la vigencia, por favor contactar con el administrador")
            End If
        Else
            Me.ErrorProvider3.Clear()
            REM txtarea.Enabled = True
            contador()
        End If
        If TextBox1.Text <> Nothing Then
            txtnota.Enabled = False
            txtarea.Enabled = False
            MsgBox("Este contrato se encuentra bloqueado por el usuario " & TextBox1.Text & " espere unos minutos e ingrese nuevamente")
        Else
            If txtestado.Text.Trim = "Abierto" Then
                If dfaltantes.Text < 0 Then
                    usersolicitante.Text = ""
                    txtnota.Enabled = False
                    txtarea.Enabled = False
                ElseIf porcentiempog.Text >= 100 Or avancedineroglobal.Text >= 100 Or avancedinerovigencia.Text >= 100 Then
                Else
                    usersolicitante.Text = My.Settings.usuario2
                    txtnota.Enabled = True
                    txtarea.Enabled = True
                End If
                Label58.Text = ""
            Else
                Label58.Text = "El contrato se encuentra " & txtestado.Text
                txtnota.Enabled = False
                txtarea.Enabled = False
                txtplanner.Enabled = False
            End If
        End If

    End Sub
    Private Sub vigencia()
        REM calcula vigencias
        anovigencia.Text = Year(dtfecha1.Value)
        If anovigencia.Text = ano1.Text Then
            txtvigencia.Text = vigenciaorg1.Text
            saldovigencia.Text = vigencia1.Text
            gastovigencia.Text = FormatNumber(CDbl(gastovigencia1.Text) + CDbl(total1.Text))
        End If
        REM calcula el valor original de la vigencia
        If anovigencia.Text = ano2.Text Then
            txtvigencia.Text = vigenciaorg2.Text
            saldovigencia.Text = Vigencia2.Text
            gastovigencia.Text = FormatNumber(CDbl(gastovigencia2.Text) + CDbl(total1.Text))
        End If
        If anovigencia.Text = ano3.Text Then
            txtvigencia.Text = vigenciaorg3.Text
            saldovigencia.Text = Vigencia3.Text
            gastovigencia.Text = FormatNumber(CDbl(gastovigencia3.Text) + CDbl(total1.Text))
        End If
        If anovigencia.Text = ano4.Text Then
            txtvigencia.Text = vigenciaorg4.Text
            saldovigencia.Text = vigencia4.Text
            gastovigencia.Text = FormatNumber(CDbl(gastovigencia4.Text) + CDbl(total1.Text))
        End If
        If anovigencia.Text = ano5.Text Then
            txtvigencia.Text = vigenciaorg5.Text
            saldovigencia.Text = vigencia5.Text
            gastovigencia.Text = FormatNumber(CDbl(gastovigencia5.Text) + CDbl(total1.Text))
        End If
    End Sub

    Private Sub contabilidad()
        vractual.Text = FormatNumber(CDbl(total1.Text))
        If txtvigencia.Text = "" Then
            txtvigencia.Text = 0
        End If
        If gastoglobal.Text = "" Then
            gastoglobal.Text = 0
        End If
        If mcostot.Text = "" Then
            mcostot.Text = 0
        End If
        'Calcula contrato Global

        If vractual.Text > CDbl(0) Then
            gastoglobal.Text = FormatNumber(CDbl(gastoglobal.Text) + CDbl(vractual.Text))
            saldoglobal.Text = FormatNumber(CDbl(mcostot.Text) - CDbl(gastoglobal.Text))
            saldovigencia.Text = FormatNumber(CDbl(saldovigencia.Text) - CDbl(vractual.Text))
            gastovigencia.Text = FormatNumber(CDbl(txtvigencia.Text) - CDbl(saldovigencia.Text))
            avancedinerovigencia.Text = FormatNumber(CDbl(gastovigencia.Text) / CDbl(txtvigencia.Text) * 100)
            restar()
        Else
            gastoglobal.Text = FormatNumber(CDbl(mcostot.Text) - CDbl(saldototal.Text))
            saldoglobal.Text = FormatNumber(CDbl(mcostot.Text) - CDbl(gastoglobal.Text))
            avancedineroglobal.Text = FormatNumber(CDbl(gastoglobal.Text) / CDbl(mcostot.Text) * 100)
            REM saldovigencia, se calcula 
            avancedinerovigencia.Text = FormatNumber(CDbl(gastovigencia.Text) / CDbl(txtvigencia.Text) * 100)
        End If
    End Sub
    Private Sub alertas()
               Me.ErrorProvider3.Clear()
        dfaltantes.Text = DateTimePicker1.Value.Subtract(Date.Today).TotalDays
        dfaltantes.Text = FormatNumber(dfaltantes.Text, "0.0")
        diasejecutados.Text = Val(doriginal.Text) - Val(dfaltantes.Text)
        diasejecutados.Text = FormatNumber(diasejecutados.Text, "0.0")
        porcentiempog.Text = Val(diasejecutados.Text) / Val(doriginal.Text) * 100
        porcentiempog.Text = FormatNumber(porcentiempog.Text, "0.0")
        If avancedineroglobal.Text = "" Then avancedineroglobal.Text = 0
        If avancedineroglobal.Text <= 50 Then
            Label43.BackColor = Color.DarkGreen
            ok2.Visible = True
            alert2.Visible = False
            error2.Visible = False
            estadocm.Text = "Contrato actual sin novedad"
            Me.BackColor = Color.WhiteSmoke
        ElseIf avancedineroglobal.Text > 50 And avancedineroglobal.Text < 70 Then
            Label43.BackColor = Color.Yellow
            ok2.Visible = False
            alert2.Visible = True
            error2.Visible = False
            estadocm.Text = "Se requiere iniciar proceso de licitacion por Dinero"
        Else
            Label43.BackColor = Color.DarkRed
            ok2.Visible = False
            alert2.Visible = False
            error2.Visible = True
            estadocm.Text = "Se requiere solicitar OTROSI inmediatamente por Dinero"
        End If
        If porcentiempog.Text <= 50 Then
            porcentiempo1.BackColor = Color.DarkGreen
            ok1.Visible = True
            alert1.Visible = False
            error1.Visible = False
        ElseIf porcentiempog.Text > 50 And porcentiempog.Text < 70 Then
            porcentiempo1.BackColor = Color.Yellow
            ok1.Visible = False
            alert1.Visible = True
            error1.Visible = False
            estadocm.Text = "Se requiere iniciar proceso de licitacion por Tiempo"
        Else
            porcentiempo1.BackColor = Color.DarkRed
            ok1.Visible = False
            alert1.Visible = False
            error1.Visible = True
            estadocm.Text = "Se requiere solicitar OTROSI inmediatamente por Tiempo"
        End If
        If avancedinerovigencia.Text = "" Then avancedinerovigencia.Text = 0
        If avancedinerovigencia.Text <= 50 Then
            Label29.BackColor = Color.DarkGreen
            ok3.Visible = True
            alert3.Visible = False
            error3.Visible = False
            estadocm2.Text = "Vigencia actual sin novedad en presupuesto"
        ElseIf avancedinerovigencia.Text > 50 And avancedinerovigencia.Text < 70 Then
            Label29.BackColor = Color.Yellow
            ok3.Visible = False
            alert3.Visible = True
            error3.Visible = False
            estadocm2.Text = "Vigencia presupuestal en alerta por presupuesto."
        Else
            Label29.BackColor = Color.DarkRed
            ok3.Visible = False
            alert3.Visible = False
            error3.Visible = True
            Me.ErrorProvider3.SetError(cmbcontrato1, "Este contrato requiere cambio de vigencia presupuestal")
            estadocm2.Text = "Se requiere solicitar cambio de vigencia presupuestal."
        End If
    End Sub
    Private Sub validafecha()
        If DateTimePicker1.Value < System.DateTime.Now Then
            txtnota.Enabled = False
            txtarea.Enabled = False
            txtplanner.Enabled = False
            REM Me.BackColor = Color.Black
            Me.ErrorProvider2.SetError(DateTimePicker1, "No se puede Cargar nada a este contrato, ya que esta vencido")
        Else
            Me.ErrorProvider2.Clear()
        End If
    End Sub
    Public Sub validar()
        If modo1 = 4 Then
            costod1.Text = cosdirecto
            admin1.Text = imptxtcostadminglobal
            impre1.Text = imptxtcostimpglobal
            util1.Text = imptxtcostutilglobal
            subt1.Text = imptxtcostsubglobal
            iva1.Text = imptxtcostivaglobal
            total1.Text = impvrgtotal
            CheckBox4.Enabled = True
            CMNuevosBindingSource.ResetBindings(True)
            Me.Update()
            TextBox1.Text = My.Settings.usuario2
            vigencia()
            contabilidad()
        End If
    End Sub
    Private Sub contador()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Dim read As Data.SqlClient.SqlDataReader
        Dim maximo As Integer = 0
        comandos = conexion.CreateCommand()
        comandos.CommandText = "SELECT count(*) from ODS WHERE Contratos = '" & cmbcontrato1.Text & "'"
        maximo = CType(comandos.ExecuteScalar, Integer)
        REM read = comandos.ExecuteReader()
        txtconsecutivo.Text = ("00000" + maximo.ToString())
        Id.Text = cmbcontrato1.Text.Trim & "-" & Val(txtconsecutivo.Text) + 1
    End Sub
    Private Sub calfecha()
        txtdias.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays
    End Sub
    Private Sub dtfechai_ValueChanged(sender As System.Object, e As System.EventArgs)
        txtdias.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays
    End Sub
    Private Sub dtfechaf_ValueChanged(sender As System.Object, e As System.EventArgs)
        txtdias.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays
    End Sub
    Private Sub dtfechapresf_ValueChanged(sender As System.Object, e As System.EventArgs)
        txtdias.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays
    End Sub
    Private Sub cmbcontratista1_Click(sender As Object, e As System.EventArgs) Handles cmbcontratista1.Click
        frmcontatista.Show()
    End Sub
    Private Sub ComboBox2_Click(sender As Object, e As System.EventArgs)
        Form8.Show()
    End Sub
    Private Sub txtnota_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnota.KeyPress
        Dim Sep As Char
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub
    Private Sub txtnota_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtnota.KeyUp
        If txtnota.Text.Length < 10 Then
            Me.ErrorProvider1.SetError(txtnota, "El codigo del contrato debe tener 10 numeros")
        Else
            Me.ErrorProvider1.Clear()
        End If
    End Sub
    Private Sub txtarea_TextChanged(sender As System.Object, e As System.EventArgs)
        cmbdisciplina.Enabled = True
    End Sub
    Private Sub textdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles textdescripcion.TextChanged
        grpservicios.Enabled = True
        grpfecha.Enabled = True
        dtfechai.Enabled = True
        dtfechaf.Enabled = True
        txtarea.Text = txtarea.Text & " " & APE.Text
        If txtnota.Text <> "" Then
            Me.ErrorProvider1.Clear()
        End If
    End Sub
    Private Sub total1_TextChanged(sender As System.Object, e As System.EventArgs) Handles total1.TextChanged
        If total1.Text = "" Then total1.Text = 0
        total1.Text = FormatNumber(CDbl(total1.Text))
        grpfecha.Enabled = True
    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            If CDbl(vractual.Text) > CDbl(txtvigencia.Text) Then
                MsgBox("El valor de la Orden de Servicio es superior al contrato marco")
                CheckBox4.Checked = False
            Else
                If txtnota.Text = "" Then
                    txtnota.Text = Date.Now
                End If
                btguardar.Enabled = True
                txtnota.Enabled = False
                cmbcontrato1.Enabled = False
                txtarea.Enabled = False
                cmbdisciplina.Enabled = False
                grpcantidades.Enabled = False
                textdescripcion.Enabled = False
                grpfecha.Enabled = False
                btndistribuir.Enabled = False
                Equipo.Enabled = False
                chktext = hoy & "" & getusername.Text
                txtplanner.Enabled = False
                valor1 = FormatNumber(CDbl(afeporc1) * CDbl(total1.Text) / 100)
                valor2 = FormatNumber(CDbl(afeporc2) * CDbl(total1.Text) / 100)
                valor3 = FormatNumber(CDbl(afeporc3) * CDbl(total1.Text) / 100)
                valor4 = FormatNumber(CDbl(afeporc4) * CDbl(total1.Text) / 100)
                valor5 = FormatNumber(CDbl(afeporc5) * CDbl(total1.Text) / 100)
                valor6 = FormatNumber(CDbl(afeporc6) * CDbl(total1.Text) / 100)
                eplanner = txtplanner.Text + "@pacificrubiales.com.co"
                eadmin.Text = cmbadmin1.Text & "@pacificrubiales.com.co"
                ecreado.Text = getusername.Text & "@pacificrubiales.com.co"
                cname.Text = usersolicitante.Text & "@pacificrubiales.com.co"
            End If
        Else
            btguardar.Enabled = False
            txtnota.Enabled = True
            cmbcontrato1.Enabled = True
            txtarea.Enabled = True
            cmbdisciplina.Enabled = True
            grpcantidades.Enabled = True
            textdescripcion.Enabled = True
            grpfecha.Enabled = True
            btndistribuir.Enabled = True
            txtplanner.Enabled = True
            Equipo.Enabled = True
        End If
    End Sub
    Private Sub txtnservicio1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        identif = 1
        Form8.Show()
    End Sub
    Private Sub txtnservicio2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        identif = 2
        Form8.Show()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub cerrar()
        If TextBox1.Text = My.Settings.usuario2 Then
            Try
                If conexion.State = ConnectionState.Open Then
                Else
                    conexion.Open()
                End If
                Dim str5 As String
                str5 = "Update CMNuevos SET lock = '" & "" & "'  Where Contratos = '" & cmbcontrato1.Text & "'"
                comandos1 = New SqlCommand(str5, conexion)
                comandos1.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod5-fun-06:" & "_" & ex.Message)
            End Try
        End If
        conexion.Close()
        frmmenu.retorno = 1
        frmmenu.Show()
    End Sub

    Private Sub frmactualizar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.ApplicationExitCall
                cerrar()
            Case CloseReason.FormOwnerClosing
                cerrar()
            Case CloseReason.MdiFormClosing
                cerrar()
            Case CloseReason.None
                cerrar()
            Case CloseReason.TaskManagerClosing
                cerrar()
            Case CloseReason.UserClosing
                cerrar()
            Case CloseReason.WindowsShutDown
                cerrar()
            Case Else
                cerrar()
        End Select
    End Sub

    Private Sub dtfechai_ValueChanged_1(sender As System.Object, e As System.EventArgs) Handles dtfechai.ValueChanged
        If dtfechai.Enabled = True Then
            contarfecha()
        End If
    End Sub
    Private Sub dtfechaf_ValueChanged_1(sender As System.Object, e As System.EventArgs) Handles dtfechaf.ValueChanged
        If dtfechaf.Enabled = True Then
            contarfecha()
        End If
    End Sub
    Private Sub contarfecha()
        If DateTimePicker2.Value > dtfechai.Value Then
            MsgBox("La duracion de la ODS no puede iniciar antes que el contrato Marco.")
            dtfechai.Text = DateTimePicker2.Value
        End If
        If DateTimePicker1.Value < dtfechaf.Value Then
            MsgBox("La duracion de la ODS no puede finalizar despues que el contrato Marco.")
            dtfechaf.Text = DateTimePicker1.Value
        End If
        txtdias.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays
    End Sub
    Private Sub txtnservicio1_TextChanged(sender As Object, e As System.EventArgs)
        costod1.Enabled = True
    End Sub
    Private Sub usersolicitante_TextChanged(sender As System.Object, e As System.EventArgs) Handles usersolicitante.TextChanged
        getusername.Text = SystemInformation.UserName
        grpinfoods.Enabled = True
    End Sub

    Private Sub DateTimePicker1_TextChanged(sender As Object, e As System.EventArgs) Handles DateTimePicker1.TextChanged
        'dfaltantes.Text = Date.Today.Subtract(DateTimePicker1.Value).TotalDays
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btndistribuir.Click
        contractonumber = cmbcontrato1.Text
        valorcontracto = saldovigencia.Text
        frmvalorods.Show()
    End Sub
    Private Sub txtdias_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdias.TextChanged
        btndistribuir.Enabled = True
    End Sub

    Private Sub btguardar_Click_1(sender As System.Object, e As System.EventArgs) Handles btguardar.Click
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos.CommandType = CommandType.StoredProcedure
            comandos.CommandText = "guardarodsoriginal"
            comandos.Connection = conexion
            comandos.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
            comandos.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
            comandos.Parameters.Add("@PROVEEDOR", SqlDbType.NVarChar).Value = cmbcontratista1.Text()
            comandos.Parameters.Add("@Creado", SqlDbType.NVarChar).Value = txtcreado1.Text()
            comandos.Parameters.Add("@Asociacion", SqlDbType.NVarChar).Value = txtasociacion.Text()
            comandos.Parameters.Add("@Fechacreacion", SqlDbType.DateTime).Value = dtfecha1.Value.Date()
            comandos.Parameters.Add("@FechInicio", SqlDbType.DateTime).Value = dtfechai.Value.Date()
            comandos.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = dtfechaf.Value.Date()
            comandos.Parameters.Add("@Disciplina", SqlDbType.NVarChar).Value = cmbdisciplina.Text()
            comandos.Parameters.Add("@Creadopor", SqlDbType.NVarChar).Value = usersolicitante.Text()
            comandos.Parameters.Add("@Administrador", SqlDbType.NVarChar).Value = cmbadmin1.Text()
            comandos.Parameters.Add("@spadmin", SqlDbType.NVarChar).Value = cmbusuario1.Text()
            comandos.Parameters.Add("@Notaentrega", SqlDbType.NText).Value = txtnota.Text()
            comandos.Parameters.Add("@nombrecontratista", SqlDbType.NVarChar).Value = cmbcontratista1.Text()
            comandos.Parameters.Add("@nitcontratista", SqlDbType.NVarChar).Value = txtnit1.Text()
            comandos.Parameters.Add("@portafolio", SqlDbType.NVarChar).Value = txtportafolio.Text()
            comandos.Parameters.Add("@programam", SqlDbType.NVarChar).Value = txtprogramam.Text()
            comandos.Parameters.Add("@programa", SqlDbType.NVarChar).Value = txtprograma.Text()
            comandos.Parameters.Add("@proyectom", SqlDbType.NVarChar).Value = txtprograma.Text()
            comandos.Parameters.Add("@proyecto", SqlDbType.NVarChar).Value = txtprograma1.Text()
            comandos.Parameters.Add("@subproyecto", SqlDbType.NVarChar).Value = txtarea.Text()
            comandos.Parameters.Add("@horasestimadas", SqlDbType.NVarChar).Value = Label22.Text()
            comandos.Parameters.Add("@tarifas", SqlDbType.NVarChar).Value = Label23.Text()
            comandos.Parameters.Add("@pdt", SqlDbType.NVarChar).Value = Label24.Text()
            comandos.Parameters.Add("@moneda", SqlDbType.NVarChar).Value = cmbmoneda.Text()
            comandos.Parameters.Add("@Costodirecto", SqlDbType.Float).Value = CDbl(costod1.Text)
            comandos.Parameters.Add("@Administracion", SqlDbType.Float).Value = CDbl(admin1.Text)
            comandos.Parameters.Add("@Imprevisto", SqlDbType.Float).Value = CDbl(impre1.Text)
            comandos.Parameters.Add("@Utilidad", SqlDbType.Float).Value = CDbl(util1.Text)
            comandos.Parameters.Add("@Subtotal", SqlDbType.Float).Value = CDbl(subt1.Text)
            comandos.Parameters.Add("@iva", SqlDbType.Float).Value = CDbl(iva1.Text)
            comandos.Parameters.Add("@valorods", SqlDbType.Float).Value = CDbl(vractual.Text)
            comandos.Parameters.Add("@Tiposervicio1", SqlDbType.Float).Value = servicio2(0)
            comandos.Parameters.Add("@SERVICIO1", SqlDbType.NVarChar).Value = nservicio2(0)
            comandos.Parameters.Add("@ADM1", SqlDbType.Float).Value = CDbl(a2(0))
            comandos.Parameters.Add("@IMP1", SqlDbType.Float).Value = CDbl(i2(0))
            comandos.Parameters.Add("@UTIL1", SqlDbType.Float).Value = CDbl(u2(0))
            comandos.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = CDbl(costod2(0))
            comandos.Parameters.Add("@Administracion1", SqlDbType.Float).Value = CDbl(admin2(0))
            comandos.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = CDbl(impre2(0))
            comandos.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = CDbl(util2(0))
            comandos.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = CDbl(subt2(0))
            comandos.Parameters.Add("@IVA1", SqlDbType.Float).Value = CDbl(iva2(0))
            comandos.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = CDbl(total2(0))
            comandos.Parameters.Add("@Tiposervicio2", SqlDbType.Float).Value = servicio2(1)
            comandos.Parameters.Add("@SERVICIO2", SqlDbType.NVarChar).Value = nservicio2(1)
            comandos.Parameters.Add("@ADM2", SqlDbType.Float).Value = CDbl(a2(1))
            comandos.Parameters.Add("@IMP2", SqlDbType.Float).Value = CDbl(i2(1))
            comandos.Parameters.Add("@UTIL2", SqlDbType.Float).Value = CDbl(u2(1))
            comandos.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = CDbl(costod2(1))
            comandos.Parameters.Add("@Administracion2", SqlDbType.Float).Value = CDbl(admin2(1))
            comandos.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = CDbl(impre2(1))
            comandos.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = CDbl(util2(1))
            comandos.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = CDbl(subt2(1))
            comandos.Parameters.Add("@IVA2", SqlDbType.Float).Value = CDbl(iva2(1))
            comandos.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = CDbl(total2(1))
            comandos.Parameters.Add("@Tiposervicio3", SqlDbType.Float).Value = servicio2(2)
            comandos.Parameters.Add("@SERVICIO3", SqlDbType.NVarChar).Value = nservicio2(2)
            comandos.Parameters.Add("@ADM3", SqlDbType.Float).Value = CDbl(a2(2))
            comandos.Parameters.Add("@IMP3", SqlDbType.Float).Value = CDbl(i2(2))
            comandos.Parameters.Add("@UTIL3", SqlDbType.Float).Value = CDbl(u2(2))
            comandos.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = CDbl(costod2(2))
            comandos.Parameters.Add("@Administracion3", SqlDbType.Float).Value = CDbl(admin2(2))
            comandos.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = CDbl(impre2(2))
            comandos.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = CDbl(util2(2))
            comandos.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = CDbl(subt2(2))
            comandos.Parameters.Add("@IVA3", SqlDbType.Float).Value = CDbl(iva2(2))
            comandos.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = CDbl(total2(2))
            comandos.Parameters.Add("@Tiposervicio4", SqlDbType.Float).Value = servicio2(3)
            comandos.Parameters.Add("@SERVICIO4", SqlDbType.NVarChar).Value = nservicio2(3)
            comandos.Parameters.Add("@ADM4", SqlDbType.Float).Value = CDbl(a2(3))
            comandos.Parameters.Add("@IMP4", SqlDbType.Float).Value = CDbl(i2(3))
            comandos.Parameters.Add("@UTIL4", SqlDbType.Float).Value = CDbl(u2(3))
            comandos.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = CDbl(costod2(3))
            comandos.Parameters.Add("@Administracion4", SqlDbType.Float).Value = CDbl(admin2(3))
            comandos.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = CDbl(impre2(3))
            comandos.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = CDbl(util2(3))
            comandos.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = CDbl(subt2(3))
            comandos.Parameters.Add("@IVA4", SqlDbType.Float).Value = CDbl(iva2(3))
            comandos.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = CDbl(total2(3))
            comandos.Parameters.Add("@estado", SqlDbType.NVarChar).Value = Estadoods.Text()
            comandos.Parameters.Add("@FIRMA", SqlDbType.NVarChar).Value = getusername.Text()
            comandos.Parameters.Add("@VALIDAU", SqlDbType.NVarChar).Value = chktext
            comandos.Parameters.Add("@descripccion", SqlDbType.NText).Value = textdescripcion.Text()
            comandos.Parameters.Add("@dias", SqlDbType.Int).Value = txtdias.Text()
            comandos.Parameters.Add("@planner", SqlDbType.NVarChar).Value = txtplanner.Text()
            comandos.Parameters.Add("@valorcierre", SqlDbType.Float).Value = CDbl(vractual.Text)
            comandos.Parameters.Add("@APE", SqlDbType.NVarChar).Value = APE.Text()
            comandos.ExecuteNonQuery()
            conexion.Close()
            guardar2()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod5-fun-01:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub guardar2()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos2.CommandType = CommandType.StoredProcedure
            comandos2.CommandText = "guardarods"
            comandos2.Connection = conexion
            comandos2.Parameters.Add("@Identificador", SqlDbType.NVarChar).Value = Id.Text()
            comandos2.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
            comandos2.Parameters.Add("@PROVEEDOR", SqlDbType.NVarChar).Value = cmbcontratista1.Text()
            comandos2.Parameters.Add("@Creado", SqlDbType.NVarChar).Value = txtcreado1.Text()
            comandos2.Parameters.Add("@Asociacion", SqlDbType.NVarChar).Value = txtasociacion.Text()
            comandos2.Parameters.Add("@Fechacreacion", SqlDbType.DateTime).Value = dtfecha1.Value.Date()
            comandos2.Parameters.Add("@FechInicio", SqlDbType.DateTime).Value = dtfechai.Value.Date()
            comandos2.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = dtfechaf.Value.Date()
            comandos2.Parameters.Add("@Disciplina", SqlDbType.NVarChar).Value = cmbdisciplina.Text()
            comandos2.Parameters.Add("@Creadopor", SqlDbType.NVarChar).Value = usersolicitante.Text()
            comandos2.Parameters.Add("@Administrador", SqlDbType.NVarChar).Value = cmbadmin1.Text()
            comandos2.Parameters.Add("@spadmin", SqlDbType.NVarChar).Value = cmbusuario1.Text()
            comandos2.Parameters.Add("@Notaentrega", SqlDbType.NText).Value = txtnota.Text()
            comandos2.Parameters.Add("@nombrecontratista", SqlDbType.NVarChar).Value = cmbcontratista1.Text()
            comandos2.Parameters.Add("@nitcontratista", SqlDbType.NVarChar).Value = txtnit1.Text()
            comandos2.Parameters.Add("@portafolio", SqlDbType.NVarChar).Value = txtportafolio.Text()
            comandos2.Parameters.Add("@programam", SqlDbType.NVarChar).Value = txtprogramam.Text()
            comandos2.Parameters.Add("@programa", SqlDbType.NVarChar).Value = txtprograma.Text()
            comandos2.Parameters.Add("@proyectom", SqlDbType.NVarChar).Value = txtprograma.Text()
            comandos2.Parameters.Add("@proyecto", SqlDbType.NVarChar).Value = txtprograma1.Text()
            comandos2.Parameters.Add("@subproyecto", SqlDbType.NVarChar).Value = txtarea.Text()
            comandos2.Parameters.Add("@horasestimadas", SqlDbType.NVarChar).Value = Label22.Text()
            comandos2.Parameters.Add("@tarifas", SqlDbType.NVarChar).Value = Label23.Text()
            comandos2.Parameters.Add("@pdt", SqlDbType.NVarChar).Value = Label24.Text()
            comandos2.Parameters.Add("@moneda", SqlDbType.NVarChar).Value = cmbmoneda.Text()
            comandos2.Parameters.Add("@Costodirecto", SqlDbType.Float).Value = CDbl(costod1.Text)
            comandos2.Parameters.Add("@Administracion", SqlDbType.Float).Value = CDbl(admin1.Text)
            comandos2.Parameters.Add("@Imprevisto", SqlDbType.Float).Value = CDbl(impre1.Text)
            comandos2.Parameters.Add("@Utilidad", SqlDbType.Float).Value = CDbl(util1.Text)
            comandos2.Parameters.Add("@Subtotal", SqlDbType.Float).Value = CDbl(subt1.Text)
            comandos2.Parameters.Add("@iva", SqlDbType.Float).Value = CDbl(iva1.Text)
            comandos2.Parameters.Add("@valorods", SqlDbType.Float).Value = CDbl(vractual.Text)
            comandos2.Parameters.Add("@Tiposervicio1", SqlDbType.Float).Value = servicio2(0)
            comandos2.Parameters.Add("@SERVICIO1", SqlDbType.NVarChar).Value = nservicio2(0)
            comandos2.Parameters.Add("@ADM1", SqlDbType.Float).Value = CDbl(a2(0))
            comandos2.Parameters.Add("@IMP1", SqlDbType.Float).Value = CDbl(i2(0))
            comandos2.Parameters.Add("@UTIL1", SqlDbType.Float).Value = CDbl(u2(0))
            comandos2.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = CDbl(costod2(0))
            comandos2.Parameters.Add("@Administracion1", SqlDbType.Float).Value = CDbl(admin2(0))
            comandos2.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = CDbl(impre2(0))
            comandos2.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = CDbl(util2(0))
            comandos2.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = CDbl(subt2(0))
            comandos2.Parameters.Add("@IVA1", SqlDbType.Float).Value = CDbl(iva2(0))
            comandos2.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = CDbl(total2(0))
            comandos2.Parameters.Add("@Tiposervicio2", SqlDbType.Float).Value = servicio2(1)
            comandos2.Parameters.Add("@SERVICIO2", SqlDbType.NVarChar).Value = nservicio2(1)
            comandos2.Parameters.Add("@ADM2", SqlDbType.Float).Value = CDbl(a2(1))
            comandos2.Parameters.Add("@IMP2", SqlDbType.Float).Value = CDbl(i2(1))
            comandos2.Parameters.Add("@UTIL2", SqlDbType.Float).Value = CDbl(u2(1))
            comandos2.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = CDbl(costod2(1))
            comandos2.Parameters.Add("@Administracion2", SqlDbType.Float).Value = CDbl(admin2(1))
            comandos2.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = CDbl(impre2(1))
            comandos2.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = CDbl(util2(1))
            comandos2.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = CDbl(subt2(1))
            comandos2.Parameters.Add("@IVA2", SqlDbType.Float).Value = CDbl(iva2(1))
            comandos2.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = CDbl(total2(1))
            comandos2.Parameters.Add("@Tiposervicio3", SqlDbType.Float).Value = servicio2(2)
            comandos2.Parameters.Add("@SERVICIO3", SqlDbType.NVarChar).Value = nservicio2(2)
            comandos2.Parameters.Add("@ADM3", SqlDbType.Float).Value = CDbl(a2(2))
            comandos2.Parameters.Add("@IMP3", SqlDbType.Float).Value = CDbl(i2(2))
            comandos2.Parameters.Add("@UTIL3", SqlDbType.Float).Value = CDbl(u2(2))
            comandos2.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = CDbl(costod2(2))
            comandos2.Parameters.Add("@Administracion3", SqlDbType.Float).Value = CDbl(admin2(2))
            comandos2.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = CDbl(impre2(2))
            comandos2.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = CDbl(util2(2))
            comandos2.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = CDbl(subt2(2))
            comandos2.Parameters.Add("@IVA3", SqlDbType.Float).Value = CDbl(iva2(2))
            comandos2.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = CDbl(total2(2))
            comandos2.Parameters.Add("@Tiposervicio4", SqlDbType.Float).Value = servicio2(3)
            comandos2.Parameters.Add("@SERVICIO4", SqlDbType.NVarChar).Value = nservicio2(3)
            comandos2.Parameters.Add("@ADM4", SqlDbType.Float).Value = CDbl(a2(3))
            comandos2.Parameters.Add("@IMP4", SqlDbType.Float).Value = CDbl(i2(3))
            comandos2.Parameters.Add("@UTIL4", SqlDbType.Float).Value = CDbl(u2(3))
            comandos2.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = CDbl(costod2(3))
            comandos2.Parameters.Add("@Administracion4", SqlDbType.Float).Value = CDbl(admin2(3))
            comandos2.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = CDbl(impre2(3))
            comandos2.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = CDbl(util2(3))
            comandos2.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = CDbl(subt2(3))
            comandos2.Parameters.Add("@IVA4", SqlDbType.Float).Value = CDbl(iva2(3))
            comandos2.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = CDbl(total2(3))
            comandos2.Parameters.Add("@estado", SqlDbType.NVarChar).Value = Estadoods.Text()
            comandos2.Parameters.Add("@FIRMA", SqlDbType.NVarChar).Value = getusername.Text()
            comandos2.Parameters.Add("@VALIDAU", SqlDbType.NVarChar).Value = chktext
            comandos2.Parameters.Add("@descripccion", SqlDbType.NText).Value = textdescripcion.Text()
            comandos2.Parameters.Add("@dias", SqlDbType.Int).Value = txtdias.Text()
            comandos2.Parameters.Add("@planner", SqlDbType.NVarChar).Value = txtplanner.Text()
            comandos2.Parameters.Add("@valorcierre", SqlDbType.Float).Value = CDbl(vractual.Text)
            comandos2.Parameters.Add("@APE", SqlDbType.NVarChar).Value = APE.Text()
            comandos2.ExecuteNonQuery()
            paso2()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod5-fun-02:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub paso2()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            If anovigencia.Text.Trim = ano1.Text.Trim Then
                comandos3.CommandType = CommandType.StoredProcedure
                comandos3.CommandText = "actualizarvigencia1"
                comandos3.Connection = conexion
                comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = impcostod(0)
                comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = impadmin(0)
                comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impimpre(0)
                comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = imputil(0)
                comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = impsubtotal(0)
                comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = impiva(0)
                comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = imptotal(0)
                comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = impcostod(1)
                comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = impadmin(1)
                comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impimpre(1)
                comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = imputil(1)
                comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = impsubtotal(1)
                comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = impiva(1)
                comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = imptotal(1)
                comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = impcostod(2)
                comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = impadmin(2)
                comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impimpre(2)
                comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = imputil(2)
                comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = impsubtotal(2)
                comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = impiva(2)
                comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = imptotal(2)
                comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = impcostod(3)
                comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = impadmin(3)
                comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impimpre(3)
                comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = imputil(3)
                comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = impsubtotal(3)
                comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = impiva(3)
                comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = imptotal(3)
                comandos3.Parameters.Add("@CostoDirecto5", SqlDbType.Float).Value = impcostod(4)
                comandos3.Parameters.Add("@Administracion5", SqlDbType.Float).Value = impadmin(4)
                comandos3.Parameters.Add("@Imprevistos5", SqlDbType.Float).Value = impimpre(4)
                comandos3.Parameters.Add("@Utilidad5", SqlDbType.Float).Value = imputil(4)
                comandos3.Parameters.Add("@Subtotal5", SqlDbType.Float).Value = impsubtotal(4)
                comandos3.Parameters.Add("@IVA5", SqlDbType.NVarChar).Value = impiva(4)
                comandos3.Parameters.Add("@Vrtotal5", SqlDbType.Float).Value = imptotal(4)
                comandos3.Parameters.Add("@CostoDirecto6", SqlDbType.Float).Value = impcostod(5)
                comandos3.Parameters.Add("@Administracion6", SqlDbType.Float).Value = impadmin(5)
                comandos3.Parameters.Add("@Imprevistos6", SqlDbType.Float).Value = impimpre(5)
                comandos3.Parameters.Add("@Utilidad6", SqlDbType.Float).Value = imputil(5)
                comandos3.Parameters.Add("@Subtotal6", SqlDbType.Float).Value = impsubtotal(5)
                comandos3.Parameters.Add("@IVA6", SqlDbType.NVarChar).Value = impiva(5)
                comandos3.Parameters.Add("@VrTotal6", SqlDbType.Float).Value = imptotal(5)
                comandos3.Parameters.Add("@CostoDirecto7", SqlDbType.Float).Value = impcostod(6)
                comandos3.Parameters.Add("@Administracion7", SqlDbType.Float).Value = impadmin(6)
                comandos3.Parameters.Add("@Imprevistos7", SqlDbType.Float).Value = impimpre(6)
                comandos3.Parameters.Add("@Utilidad7", SqlDbType.Float).Value = imputil(6)
                comandos3.Parameters.Add("@Subtotal7", SqlDbType.Float).Value = impsubtotal(6)
                comandos3.Parameters.Add("@IVA7", SqlDbType.NVarChar).Value = impiva(6)
                comandos3.Parameters.Add("@Vrtotal7", SqlDbType.Float).Value = imptotal(6)
                comandos3.Parameters.Add("@CostoDirecto8", SqlDbType.Float).Value = impcostod(7)
                comandos3.Parameters.Add("@Administracion8", SqlDbType.Float).Value = impadmin(7)
                comandos3.Parameters.Add("@Imprevistos8", SqlDbType.Float).Value = impimpre(7)
                comandos3.Parameters.Add("@Utilidad8", SqlDbType.Float).Value = imputil(7)
                comandos3.Parameters.Add("@Subtotal8", SqlDbType.Float).Value = impsubtotal(7)
                comandos3.Parameters.Add("@IVA8", SqlDbType.NVarChar).Value = impiva(7)
                comandos3.Parameters.Add("@Vrtotal8", SqlDbType.Float).Value = imptotal(7)
                comandos3.Parameters.Add("@VALOR1", SqlDbType.Float).Value = saldovigencia.Text() REM guarda el valor la vigencia
                comandos3.Parameters.Add("@porcentajetiempo", SqlDbType.NVarChar).Value = porcentiempog.Text()
                comandos3.Parameters.Add("@porcentajedinero", SqlDbType.NVarChar).Value = avancedineroglobal.Text()
                comandos3.Parameters.Add("@porcentajedvigencia", SqlDbType.NVarChar).Value = avancedinerovigencia.Text()
                comandos3.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = saldoglobal.Text()
                comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = gastovigencia.Text()
                comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = saldocostdirecto.Text()
                comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = saldoadmin.Text()
                comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = saldoimpre.Text()
                comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = saldoutil.Text()
                comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = saldosubtotal.Text()
                comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = saldoiva.Text()
                comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = saldototal.Text()
            End If

            If anovigencia.Text.Trim = ano2.Text.Trim Then
                comandos3.CommandType = CommandType.StoredProcedure
                comandos3.CommandText = "actualizarvigencia2"
                comandos3.Connection = conexion
                comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = impcostod(0)
                comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = impadmin(0)
                comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impimpre(0)
                comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = imputil(0)
                comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = impsubtotal(0)
                comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = impiva(0)
                comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = imptotal(0)
                comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = impcostod(1)
                comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = impadmin(1)
                comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impimpre(1)
                comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = imputil(1)
                comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = impsubtotal(1)
                comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = impiva(1)
                comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = imptotal(1)
                comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = impcostod(2)
                comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = impadmin(2)
                comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impimpre(2)
                comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = imputil(2)
                comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = impsubtotal(2)
                comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = impiva(2)
                comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = imptotal(2)
                comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = impcostod(3)
                comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = impadmin(3)
                comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impimpre(3)
                comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = imputil(3)
                comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = impsubtotal(3)
                comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = impiva(3)
                comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = imptotal(3)
                comandos3.Parameters.Add("@CostoDirecto5", SqlDbType.Float).Value = impcostod(4)
                comandos3.Parameters.Add("@Administracion5", SqlDbType.Float).Value = impadmin(4)
                comandos3.Parameters.Add("@Imprevistos5", SqlDbType.Float).Value = impimpre(4)
                comandos3.Parameters.Add("@Utilidad5", SqlDbType.Float).Value = imputil(4)
                comandos3.Parameters.Add("@Subtotal5", SqlDbType.Float).Value = impsubtotal(4)
                comandos3.Parameters.Add("@IVA5", SqlDbType.NVarChar).Value = impiva(4)
                comandos3.Parameters.Add("@Vrtotal5", SqlDbType.Float).Value = imptotal(4)
                comandos3.Parameters.Add("@CostoDirecto6", SqlDbType.Float).Value = impcostod(5)
                comandos3.Parameters.Add("@Administracion6", SqlDbType.Float).Value = impadmin(5)
                comandos3.Parameters.Add("@Imprevistos6", SqlDbType.Float).Value = impimpre(5)
                comandos3.Parameters.Add("@Utilidad6", SqlDbType.Float).Value = imputil(5)
                comandos3.Parameters.Add("@Subtotal6", SqlDbType.Float).Value = impsubtotal(5)
                comandos3.Parameters.Add("@IVA6", SqlDbType.NVarChar).Value = impiva(5)
                comandos3.Parameters.Add("@VrTotal6", SqlDbType.Float).Value = imptotal(5)
                comandos3.Parameters.Add("@CostoDirecto7", SqlDbType.Float).Value = impcostod(6)
                comandos3.Parameters.Add("@Administracion7", SqlDbType.Float).Value = impadmin(6)
                comandos3.Parameters.Add("@Imprevistos7", SqlDbType.Float).Value = impimpre(6)
                comandos3.Parameters.Add("@Utilidad7", SqlDbType.Float).Value = imputil(6)
                comandos3.Parameters.Add("@Subtotal7", SqlDbType.Float).Value = impsubtotal(6)
                comandos3.Parameters.Add("@IVA7", SqlDbType.NVarChar).Value = impiva(6)
                comandos3.Parameters.Add("@Vrtotal7", SqlDbType.Float).Value = imptotal(6)
                comandos3.Parameters.Add("@CostoDirecto8", SqlDbType.Float).Value = impcostod(7)
                comandos3.Parameters.Add("@Administracion8", SqlDbType.Float).Value = impadmin(7)
                comandos3.Parameters.Add("@Imprevistos8", SqlDbType.Float).Value = impimpre(7)
                comandos3.Parameters.Add("@Utilidad8", SqlDbType.Float).Value = imputil(7)
                comandos3.Parameters.Add("@Subtotal8", SqlDbType.Float).Value = impsubtotal(7)
                comandos3.Parameters.Add("@IVA8", SqlDbType.NVarChar).Value = impiva(7)
                comandos3.Parameters.Add("@Vrtotal8", SqlDbType.Float).Value = imptotal(7)
                comandos3.Parameters.Add("@VALOR2", SqlDbType.Float).Value = saldovigencia.Text() REM guarda el valor la vigencia
                comandos3.Parameters.Add("@porcentajetiempo", SqlDbType.NVarChar).Value = porcentiempog.Text()
                comandos3.Parameters.Add("@porcentajedinero", SqlDbType.NVarChar).Value = avancedineroglobal.Text()
                comandos3.Parameters.Add("@porcentajedvigencia", SqlDbType.NVarChar).Value = avancedinerovigencia.Text()
                comandos3.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = saldoglobal.Text()
                comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = gastovigencia.Text()
                comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = saldocostdirecto.Text()
                comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = saldoadmin.Text()
                comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = saldoimpre.Text()
                comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = saldoutil.Text()
                comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = saldosubtotal.Text()
                comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = saldoiva.Text()
                comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = saldototal.Text()
            End If

            If anovigencia.Text.Trim = ano3.Text.Trim Then
                comandos3.CommandType = CommandType.StoredProcedure
                comandos3.CommandText = "actualizarvigencia3"
                comandos3.Connection = conexion
                comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = impcostod(0)
                comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = impadmin(0)
                comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impimpre(0)
                comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = imputil(0)
                comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = impsubtotal(0)
                comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = impiva(0)
                comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = imptotal(0)
                comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = impcostod(1)
                comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = impadmin(1)
                comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impimpre(1)
                comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = imputil(1)
                comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = impsubtotal(1)
                comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = impiva(1)
                comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = imptotal(1)
                comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = impcostod(2)
                comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = impadmin(2)
                comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impimpre(2)
                comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = imputil(2)
                comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = impsubtotal(2)
                comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = impiva(2)
                comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = imptotal(2)
                comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = impcostod(3)
                comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = impadmin(3)
                comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impimpre(3)
                comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = imputil(3)
                comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = impsubtotal(3)
                comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = impiva(3)
                comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = imptotal(3)
                comandos3.Parameters.Add("@CostoDirecto5", SqlDbType.Float).Value = impcostod(4)
                comandos3.Parameters.Add("@Administracion5", SqlDbType.Float).Value = impadmin(4)
                comandos3.Parameters.Add("@Imprevistos5", SqlDbType.Float).Value = impimpre(4)
                comandos3.Parameters.Add("@Utilidad5", SqlDbType.Float).Value = imputil(4)
                comandos3.Parameters.Add("@Subtotal5", SqlDbType.Float).Value = impsubtotal(4)
                comandos3.Parameters.Add("@IVA5", SqlDbType.NVarChar).Value = impiva(4)
                comandos3.Parameters.Add("@Vrtotal5", SqlDbType.Float).Value = imptotal(4)
                comandos3.Parameters.Add("@CostoDirecto6", SqlDbType.Float).Value = impcostod(5)
                comandos3.Parameters.Add("@Administracion6", SqlDbType.Float).Value = impadmin(5)
                comandos3.Parameters.Add("@Imprevistos6", SqlDbType.Float).Value = impimpre(5)
                comandos3.Parameters.Add("@Utilidad6", SqlDbType.Float).Value = imputil(5)
                comandos3.Parameters.Add("@Subtotal6", SqlDbType.Float).Value = impsubtotal(5)
                comandos3.Parameters.Add("@IVA6", SqlDbType.NVarChar).Value = impiva(5)
                comandos3.Parameters.Add("@VrTotal6", SqlDbType.Float).Value = imptotal(5)
                comandos3.Parameters.Add("@CostoDirecto7", SqlDbType.Float).Value = impcostod(6)
                comandos3.Parameters.Add("@Administracion7", SqlDbType.Float).Value = impadmin(6)
                comandos3.Parameters.Add("@Imprevistos7", SqlDbType.Float).Value = impimpre(6)
                comandos3.Parameters.Add("@Utilidad7", SqlDbType.Float).Value = imputil(6)
                comandos3.Parameters.Add("@Subtotal7", SqlDbType.Float).Value = impsubtotal(6)
                comandos3.Parameters.Add("@IVA7", SqlDbType.NVarChar).Value = impiva(6)
                comandos3.Parameters.Add("@Vrtotal7", SqlDbType.Float).Value = imptotal(6)
                comandos3.Parameters.Add("@CostoDirecto8", SqlDbType.Float).Value = impcostod(7)
                comandos3.Parameters.Add("@Administracion8", SqlDbType.Float).Value = impadmin(7)
                comandos3.Parameters.Add("@Imprevistos8", SqlDbType.Float).Value = impimpre(7)
                comandos3.Parameters.Add("@Utilidad8", SqlDbType.Float).Value = imputil(7)
                comandos3.Parameters.Add("@Subtotal8", SqlDbType.Float).Value = impsubtotal(7)
                comandos3.Parameters.Add("@IVA8", SqlDbType.NVarChar).Value = impiva(7)
                comandos3.Parameters.Add("@Vrtotal8", SqlDbType.Float).Value = imptotal(7)
                comandos3.Parameters.Add("@VALOR3", SqlDbType.Float).Value = saldovigencia.Text() REM guarda el valor la vigencia
                comandos3.Parameters.Add("@porcentajetiempo", SqlDbType.NVarChar).Value = porcentiempog.Text()
                comandos3.Parameters.Add("@porcentajedinero", SqlDbType.NVarChar).Value = avancedineroglobal.Text()
                comandos3.Parameters.Add("@porcentajedvigencia", SqlDbType.NVarChar).Value = avancedinerovigencia.Text()
                comandos3.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = saldoglobal.Text()
                comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = gastovigencia.Text()
                comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = saldocostdirecto.Text()
                comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = saldoadmin.Text()
                comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = saldoimpre.Text()
                comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = saldoutil.Text()
                comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = saldosubtotal.Text()
                comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = saldoiva.Text()
                comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = saldototal.Text()
            End If
            If anovigencia.Text.Trim = ano4.Text.Trim Then
                comandos3.CommandType = CommandType.StoredProcedure
                comandos3.CommandText = "actualizarvigencia4"
                comandos3.Connection = conexion
                comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = impcostod(0)
                comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = impadmin(0)
                comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impimpre(0)
                comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = imputil(0)
                comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = impsubtotal(0)
                comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = impiva(0)
                comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = imptotal(0)
                comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = impcostod(1)
                comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = impadmin(1)
                comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impimpre(1)
                comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = imputil(1)
                comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = impsubtotal(1)
                comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = impiva(1)
                comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = imptotal(1)
                comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = impcostod(2)
                comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = impadmin(2)
                comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impimpre(2)
                comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = imputil(2)
                comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = impsubtotal(2)
                comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = impiva(2)
                comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = imptotal(2)
                comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = impcostod(3)
                comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = impadmin(3)
                comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impimpre(3)
                comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = imputil(3)
                comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = impsubtotal(3)
                comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = impiva(3)
                comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = imptotal(3)
                comandos3.Parameters.Add("@CostoDirecto5", SqlDbType.Float).Value = impcostod(4)
                comandos3.Parameters.Add("@Administracion5", SqlDbType.Float).Value = impadmin(4)
                comandos3.Parameters.Add("@Imprevistos5", SqlDbType.Float).Value = impimpre(4)
                comandos3.Parameters.Add("@Utilidad5", SqlDbType.Float).Value = imputil(4)
                comandos3.Parameters.Add("@Subtotal5", SqlDbType.Float).Value = impsubtotal(4)
                comandos3.Parameters.Add("@IVA5", SqlDbType.NVarChar).Value = impiva(4)
                comandos3.Parameters.Add("@Vrtotal5", SqlDbType.Float).Value = imptotal(4)
                comandos3.Parameters.Add("@CostoDirecto6", SqlDbType.Float).Value = impcostod(5)
                comandos3.Parameters.Add("@Administracion6", SqlDbType.Float).Value = impadmin(5)
                comandos3.Parameters.Add("@Imprevistos6", SqlDbType.Float).Value = impimpre(5)
                comandos3.Parameters.Add("@Utilidad6", SqlDbType.Float).Value = imputil(5)
                comandos3.Parameters.Add("@Subtotal6", SqlDbType.Float).Value = impsubtotal(5)
                comandos3.Parameters.Add("@IVA6", SqlDbType.NVarChar).Value = impiva(5)
                comandos3.Parameters.Add("@VrTotal6", SqlDbType.Float).Value = imptotal(5)
                comandos3.Parameters.Add("@CostoDirecto7", SqlDbType.Float).Value = impcostod(6)
                comandos3.Parameters.Add("@Administracion7", SqlDbType.Float).Value = impadmin(6)
                comandos3.Parameters.Add("@Imprevistos7", SqlDbType.Float).Value = impimpre(6)
                comandos3.Parameters.Add("@Utilidad7", SqlDbType.Float).Value = imputil(6)
                comandos3.Parameters.Add("@Subtotal7", SqlDbType.Float).Value = impsubtotal(6)
                comandos3.Parameters.Add("@IVA7", SqlDbType.NVarChar).Value = impiva(6)
                comandos3.Parameters.Add("@Vrtotal7", SqlDbType.Float).Value = imptotal(6)
                comandos3.Parameters.Add("@CostoDirecto8", SqlDbType.Float).Value = impcostod(7)
                comandos3.Parameters.Add("@Administracion8", SqlDbType.Float).Value = impadmin(7)
                comandos3.Parameters.Add("@Imprevistos8", SqlDbType.Float).Value = impimpre(7)
                comandos3.Parameters.Add("@Utilidad8", SqlDbType.Float).Value = imputil(7)
                comandos3.Parameters.Add("@Subtotal8", SqlDbType.Float).Value = impsubtotal(7)
                comandos3.Parameters.Add("@IVA8", SqlDbType.NVarChar).Value = impiva(7)
                comandos3.Parameters.Add("@Vrtotal8", SqlDbType.Float).Value = imptotal(7)
                comandos3.Parameters.Add("@VALOR4", SqlDbType.Float).Value = saldovigencia.Text() REM guarda el valor la vigencia
                comandos3.Parameters.Add("@porcentajetiempo", SqlDbType.NVarChar).Value = porcentiempog.Text()
                comandos3.Parameters.Add("@porcentajedinero", SqlDbType.NVarChar).Value = avancedineroglobal.Text()
                comandos3.Parameters.Add("@porcentajedvigencia", SqlDbType.NVarChar).Value = avancedinerovigencia.Text()
                comandos3.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = saldoglobal.Text()
                comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = gastovigencia.Text()
                comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = saldocostdirecto.Text()
                comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = saldoadmin.Text()
                comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = saldoimpre.Text()
                comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = saldoutil.Text()
                comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = saldosubtotal.Text()
                comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = saldoiva.Text()
                comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = saldototal.Text()
            End If

            If anovigencia.Text.Trim = ano5.Text.Trim Then
                comandos3.CommandType = CommandType.StoredProcedure
                comandos3.CommandText = "actualizarvigencia5"
                comandos3.Connection = conexion
                comandos3.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato1.Text()
                comandos3.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = impcostod(0)
                comandos3.Parameters.Add("@Administracion1", SqlDbType.Float).Value = impadmin(0)
                comandos3.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impimpre(0)
                comandos3.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = imputil(0)
                comandos3.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = impsubtotal(0)
                comandos3.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = impiva(0)
                comandos3.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = imptotal(0)

                comandos3.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = impcostod(1)
                comandos3.Parameters.Add("@Administracion2", SqlDbType.Float).Value = impadmin(1)
                comandos3.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impimpre(1)
                comandos3.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = imputil(1)
                comandos3.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = impsubtotal(1)
                comandos3.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = impiva(1)
                comandos3.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = imptotal(1)

                comandos3.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = impcostod(2)
                comandos3.Parameters.Add("@Administracion3", SqlDbType.Float).Value = impadmin(2)
                comandos3.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impimpre(2)
                comandos3.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = imputil(2)
                comandos3.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = impsubtotal(2)
                comandos3.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = impiva(2)
                comandos3.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = imptotal(2)

                comandos3.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = impcostod(3)
                comandos3.Parameters.Add("@Administracion4", SqlDbType.Float).Value = impadmin(3)
                comandos3.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impimpre(3)
                comandos3.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = imputil(3)
                comandos3.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = impsubtotal(3)
                comandos3.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = impiva(3)
                comandos3.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = imptotal(3)

                comandos3.Parameters.Add("@CostoDirecto5", SqlDbType.Float).Value = impcostod(4)
                comandos3.Parameters.Add("@Administracion5", SqlDbType.Float).Value = impadmin(4)
                comandos3.Parameters.Add("@Imprevistos5", SqlDbType.Float).Value = impimpre(4)
                comandos3.Parameters.Add("@Utilidad5", SqlDbType.Float).Value = imputil(4)
                comandos3.Parameters.Add("@Subtotal5", SqlDbType.Float).Value = impsubtotal(4)
                comandos3.Parameters.Add("@IVA5", SqlDbType.NVarChar).Value = impiva(4)
                comandos3.Parameters.Add("@Vrtotal5", SqlDbType.Float).Value = imptotal(4)

                comandos3.Parameters.Add("@CostoDirecto6", SqlDbType.Float).Value = impcostod(5)
                comandos3.Parameters.Add("@Administracion6", SqlDbType.Float).Value = impadmin(5)
                comandos3.Parameters.Add("@Imprevistos6", SqlDbType.Float).Value = impimpre(5)
                comandos3.Parameters.Add("@Utilidad6", SqlDbType.Float).Value = imputil(5)
                comandos3.Parameters.Add("@Subtotal6", SqlDbType.Float).Value = impsubtotal(5)
                comandos3.Parameters.Add("@IVA6", SqlDbType.NVarChar).Value = impiva(5)
                comandos3.Parameters.Add("@VrTotal6", SqlDbType.Float).Value = imptotal(5)

                comandos3.Parameters.Add("@CostoDirecto7", SqlDbType.Float).Value = impcostod(6)
                comandos3.Parameters.Add("@Administracion7", SqlDbType.Float).Value = impadmin(6)
                comandos3.Parameters.Add("@Imprevistos7", SqlDbType.Float).Value = impimpre(6)
                comandos3.Parameters.Add("@Utilidad7", SqlDbType.Float).Value = imputil(6)
                comandos3.Parameters.Add("@Subtotal7", SqlDbType.Float).Value = impsubtotal(6)
                comandos3.Parameters.Add("@IVA7", SqlDbType.NVarChar).Value = impiva(6)
                comandos3.Parameters.Add("@Vrtotal7", SqlDbType.Float).Value = imptotal(6)

                comandos3.Parameters.Add("@CostoDirecto8", SqlDbType.Float).Value = impcostod(7)
                comandos3.Parameters.Add("@Administracion8", SqlDbType.Float).Value = impadmin(7)
                comandos3.Parameters.Add("@Imprevistos8", SqlDbType.Float).Value = impimpre(7)
                comandos3.Parameters.Add("@Utilidad8", SqlDbType.Float).Value = imputil(7)
                comandos3.Parameters.Add("@Subtotal8", SqlDbType.Float).Value = impsubtotal(7)
                comandos3.Parameters.Add("@IVA8", SqlDbType.NVarChar).Value = impiva(7)
                comandos3.Parameters.Add("@Vrtotal8", SqlDbType.Float).Value = imptotal(7)

                comandos3.Parameters.Add("@VALOR5", SqlDbType.Float).Value = saldovigencia.Text() REM guarda el valor la vigencia

                comandos3.Parameters.Add("@porcentajetiempo", SqlDbType.NVarChar).Value = porcentiempog.Text()
                comandos3.Parameters.Add("@porcentajedinero", SqlDbType.NVarChar).Value = avancedineroglobal.Text()
                comandos3.Parameters.Add("@porcentajedvigencia", SqlDbType.NVarChar).Value = avancedinerovigencia.Text()
                comandos3.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = saldoglobal.Text()
                comandos3.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = gastovigencia.Text()
                comandos3.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = saldocostdirecto.Text()
                comandos3.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = saldoadmin.Text()
                comandos3.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = saldoimpre.Text()
                comandos3.Parameters.Add("@saldoutil", SqlDbType.Float).Value = saldoutil.Text()
                comandos3.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = saldosubtotal.Text()
                comandos3.Parameters.Add("@saldoiva", SqlDbType.Float).Value = saldoiva.Text()
                comandos3.Parameters.Add("@saldototal", SqlDbType.Float).Value = saldototal.Text()
            End If
            comandos3.ExecuteNonQuery()
            conexion.Close()
            MsgBox("Guardado Corectamente", vbInformation, ("Guardado"))
            btguardar.Enabled = False
            CheckBox4.Enabled = False
            modo1 = 0
            guardar3()
            enviarmail()
            impprogramam = ""
            subprograma = ""
            impproyectom = ""
            impproyecto = ""
            frmformulario.modo = 0
            frmformulario.impprogramam1 = ""
            frmformulario.subprograma1 = ""
            frmformulario.impproyectom1 = ""
            frmformulario.impproyecto1 = ""
            frmformulario.impcontratista = ""
            frmformulario.impnit = ""
            impcontratista = ""
            impnit = ""
            txtplanner.Enabled = False
            enunciaods.Text = "El codigo de su ODS es " & " " & Id.Text
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod5-fun-03:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub guardar3()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos5.CommandType = CommandType.StoredProcedure
            comandos5.CommandText = "insertarafeods"
            comandos5.Connection = conexion
            comandos5.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = Id.Text()
            comandos5.Parameters.Add("@Ape1", SqlDbType.NVarChar).Value = afe1
            comandos5.Parameters.Add("@costo1", SqlDbType.Float).Value = CDbl(valor1)
            comandos5.Parameters.Add("@Porcentaje1", SqlDbType.NVarChar).Value = CDbl(afeporc1)
            comandos5.Parameters.Add("@Ape2", SqlDbType.NVarChar).Value = afe2
            comandos5.Parameters.Add("@costo2", SqlDbType.Float).Value = CDbl(valor2)
            comandos5.Parameters.Add("@Porcentaje2", SqlDbType.NVarChar).Value = CDbl(afeporc2)
            comandos5.Parameters.Add("@Ape3", SqlDbType.NVarChar).Value = afe3
            comandos5.Parameters.Add("@costo3", SqlDbType.Float).Value = CDbl(valor3)
            comandos5.Parameters.Add("@Porcentaje3", SqlDbType.NVarChar).Value = CDbl(afeporc3)
            comandos5.Parameters.Add("@Ape4", SqlDbType.NVarChar).Value = afe4
            comandos5.Parameters.Add("@costo4", SqlDbType.Float).Value = CDbl(valor4)
            comandos5.Parameters.Add("@Porcentaje4", SqlDbType.NVarChar).Value = CDbl(afeporc4)
            comandos5.Parameters.Add("@Ape5", SqlDbType.NVarChar).Value = afe5
            comandos5.Parameters.Add("@costo5", SqlDbType.Float).Value = CDbl(valor5)
            comandos5.Parameters.Add("@Porcentaje5", SqlDbType.NVarChar).Value = CDbl(afeporc5)
            comandos5.Parameters.Add("@Ape6", SqlDbType.NVarChar).Value = afe6
            comandos5.Parameters.Add("@costo6", SqlDbType.Float).Value = CDbl(valor6)
            comandos5.Parameters.Add("@Porcentaje6", SqlDbType.NVarChar).Value = CDbl(afeporc6)
            comandos5.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod5-fun-04:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub enviarmail()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = eadmin.Text + ";" + ecreado.Text + ";" + eplanner + ";" + spadmin.Text
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
                objMail.Subject = "La Orden de servicio #" & " " + Id.Text & " " + " ha sido creada"
                objMail.Body = "La Orden de servicio #" & " " & Id.Text & " " & "ha sido creado por el usuario." & " " + cmbusuario1.Text & " " & vbCrLf & "Requiere validacion del administrador." & " " & cmbadmin1.Text & vbCrLf & "  Su alcance es:" & " " & textdescripcion.Text & vbCrLf & "Mensaje Automatico Generado por el sistema de control de contratos de Pacific Rubiales Energy, si tiene alguna inquietud, por favor ponerse en contacto con el usuario:" & " " & cmbusuario1.Text
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
    Private Sub restar()
        saldocostdirecto.Text = FormatNumber(CDbl(saldocostdirecto.Text) - CDbl(costod1.Text))
        saldoadmin.Text = FormatNumber(CDbl(saldoadmin.Text) - CDbl(admin1.Text))
        saldoimpre.Text = FormatNumber(CDbl(saldoimpre.Text) - CDbl(impre1.Text))
        saldoutil.Text = FormatNumber(CDbl(saldoutil.Text) - CDbl(util1.Text))
        saldosubtotal.Text = FormatNumber(CDbl(saldosubtotal.Text) - CDbl(subt1.Text))
        saldoiva.Text = FormatNumber(CDbl(saldoiva.Text) - CDbl(iva1.Text))
        saldototal.Text = FormatNumber(CDbl(saldototal.Text) - CDbl(total1.Text))
    End Sub
    Private Sub cmbdisciplina_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbdisciplina.SelectedIndexChanged
        If txtnota.Text = "" Then
        Else
            REM  txtplanner.Enabled = True
        End If
    End Sub
    Private Sub lstdisciplina_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If txtnota.Text = "" Then
        Else
            REM txtplanner.Enabled = True
        End If
    End Sub
    Private Sub grpcantidades_Enter(sender As System.Object, e As System.EventArgs) Handles grpcantidades.Enter
        textdescripcion.Enabled = True
    End Sub
    Private Sub mcostoa_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldoadmin.TextChanged
        If saldoadmin.Text = "" Then saldoadmin.Text = 0
        saldoadmin.Text = FormatNumber(CDbl(saldoadmin.Text), 2)
    End Sub

    Private Sub mcostoi_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldoimpre.TextChanged
        If saldoimpre.Text = "" Then saldoimpre.Text = 0
        saldoimpre.Text = FormatNumber(CDbl(saldoimpre.Text), 2)
    End Sub

    Private Sub mcostou_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldoutil.TextChanged
        If saldoutil.Text = "" Then saldoutil.Text = 0
        saldoutil.Text = FormatNumber(CDbl(saldoutil.Text), 2)
    End Sub

    Private Sub mcostos_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldosubtotal.TextChanged
        If saldosubtotal.Text = "" Then saldosubtotal.Text = 0
        saldosubtotal.Text = FormatNumber(CDbl(saldosubtotal.Text), 2)
    End Sub
    Private Sub mcostoiva_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldoiva.TextChanged
        If saldoiva.Text = "" Then saldoiva.Text = 0
        saldoiva.Text = FormatNumber(CDbl(saldoiva.Text), 2)
    End Sub
    Private Sub mcostot_TextChanged(sender As System.Object, e As System.EventArgs)
        If mcostot.Text = "" Then mcostot.Text = 0
        mcostot.Text = FormatNumber(CDbl(mcostot.Text), 2)
    End Sub
    Private Sub txtvigencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtvigencia.TextChanged
        If txtvigencia.Text = "" Then txtvigencia.Text = 0
        txtvigencia.Text = FormatNumber(CDbl(txtvigencia.Text), 2)
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
    Private Sub txtsaldorest_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldoglobal.TextChanged
        If saldoglobal.Text = "" Then saldoglobal.Text = 0
        saldoglobal.Text = FormatNumber(CDbl(saldoglobal.Text), 2)
    End Sub
    Private Sub textanterior_TextChanged(sender As System.Object, e As System.EventArgs) Handles gastoglobal.TextChanged
        If gastoglobal.Text = "" Then gastoglobal.Text = 0
        gastoglobal.Text = FormatNumber(CDbl(gastoglobal.Text), 2)
    End Sub
    Private Sub vractual_TextChanged(sender As System.Object, e As System.EventArgs) Handles vractual.TextChanged
        If vractual.Text = "" Then vractual.Text = 0
        vractual.Text = FormatNumber(CDbl(vractual.Text), 2)
    End Sub
    Private Sub doriginal_TextChanged(sender As System.Object, e As System.EventArgs) Handles doriginal.TextChanged
        alertas()
    End Sub
    Private Sub presupuestoejecutadov_TextChanged(sender As System.Object, e As System.EventArgs) Handles gastovigencia.TextChanged
        If gastovigencia.Text = "" Then gastovigencia.Text = 0
        gastovigencia.Text = FormatNumber(CDbl(gastovigencia.Text), 2)
    End Sub

    Private Sub presupuestoaejecutarv_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldovigencia.TextChanged
        If saldovigencia.Text = "" Then saldovigencia.Text = 0
        saldovigencia.Text = FormatNumber(CDbl(saldovigencia.Text), 2)
    End Sub
    Private Sub txtprograma1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtprograma1.TextChanged
        REM If txtnota.Enabled = True Then
        Me.txtarea.DataSource = Nothing
        If txtprograma1.Text = "Rubiales" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("01. CPF1")
            txtarea.Items.Add("02. CPF2")
            txtarea.Items.Add("03. CR CLÚSTERES")
            txtarea.Items.Add("04. CR TRONCALES")
            txtarea.Items.Add("05. CR LÍNEAS DE FLUJO")
            txtarea.Items.Add("06. CR RED ELECTRICA")
            txtarea.Items.Add("07. CR PADs")
            txtarea.Items.Add("08. CR LINEAS DE TRANSFERENICA DE AGUA")
            txtarea.Items.Add("09. GENERACIÓN LOCAL")
            txtarea.Items.Add("10. PROYECTOS ADICIONALES")
            txtarea.Items.Add("11. IPP")
            txtarea.Items.Add("12. DAT")
            txtarea.Items.Add("13. CAMPO")
            txtarea.Items.Add("14. SCADA")
            txtarea.SelectedIndex = 0
        End If
        If txtprograma1.Text = "Quifa" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("02. CPF QF SW")
            txtarea.Items.Add("03. CQ CLÚSTERES")
            txtarea.Items.Add("04. CQ TRONCALES")
            txtarea.Items.Add("05. CQ LÍNEAS DE FLUJO")
            txtarea.Items.Add("06. CQ RED ELECTRICA")
            txtarea.Items.Add("07. CQ PADs")
            txtarea.Items.Add("08. CQ LINEAS DE TRANSFERENICA DE AGUA")
            txtarea.Items.Add("09. CQ GENERACIÓN LOCAL")
            txtarea.Items.Add("10. PROYECTOS ADICIONALES")
            txtarea.Items.Add("11. CAMPO")
            txtarea.SelectedIndex = 0
        End If
        If txtprograma1.Text = "Prueba Piloto Star" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("01. STAR")
            txtarea.SelectedIndex = 0
        End If
        If txtprograma1.Text = "Cajua" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("01. CAJUA")
            txtarea.SelectedIndex = 0
        End If
        If txtprograma1.Text = "CPE-6" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("01. CPE-6")
            txtarea.SelectedIndex = 0
        End If
        If txtprograma1.Text = "Sabanero" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("01. Sabanero")
            txtarea.SelectedIndex = 0
        End If
        If txtprograma1.Text = "Agrocascada" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("01. Agrocascada")
            txtarea.SelectedIndex = 0
        End If
        If txtprograma1.Text = "Rio Ariari" Then
            Me.txtarea.DataSource = Nothing
            Me.txtarea.Items.Clear()
            txtarea.Items.Add("Seleccione una opción")
            txtarea.Items.Add("01. EPF")
            txtarea.Items.Add("02. CPF")
            txtarea.Items.Add("03. Campo")
            txtarea.SelectedIndex = 0
        End If
        REM  End If
    End Sub
    Private Sub txtplanner_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtplanner.SelectedIndexChanged
        grpcantidades.Enabled = True
    End Sub
    Private Sub saldocostdirecto_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldocostdirecto.TextChanged
        If saldocostdirecto.Text = "" Then saldocostdirecto.Text = 0
        saldocostdirecto.Text = FormatNumber(CDbl(saldocostdirecto.Text), 2)
    End Sub
    Private Sub saldototal_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldototal.TextChanged
        If saldototal.Text = "" Then saldototal.Text = 0
        saldototal.Text = FormatNumber(CDbl(saldototal.Text), 2)
    End Sub
    Private Sub mcostot_TextChanged1(sender As Object, e As System.EventArgs) Handles mcostot.TextChanged
        If mcostot.Text = "" Then mcostot.Text = 0
        mcostot.Text = FormatNumber(CDbl(mcostot.Text), 2)
    End Sub
    Private Sub txtarea_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtarea.SelectedIndexChanged
        If txtarea.SelectedIndex <> 0 Then
            Equipo.Enabled = True
        Else
            Equipo.Enabled = False
        End If
    End Sub
    Private Sub txtequipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If APE.Text <> "Seleccione Opcion" Then
            txtplanner.Enabled = True
            grpcantidades.Enabled = True
        Else
            txtplanner.Enabled = False
            grpcantidades.Enabled = False
        End If
    End Sub
    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs)
        Form13.ShowDialog()
        Form13.Dispose()
    End Sub

    Private Sub APE_Click(sender As System.Object, e As System.EventArgs) Handles Equipo.Click
        frmafes.ShowDialog()
        frmafes.Dispose()
    End Sub
    Private Sub APE_TextChanged(sender As System.Object, e As System.EventArgs) Handles APE.TextChanged
        If APE.Text <> "" Then
            txtplanner.Enabled = True
            TextBox1.Text = My.Settings.usuario2
            cmbcontrato1.Enabled = False
        End If
        Try
            If conexion.State = ConnectionState.Open Then
            Else
                conexion.Open()
            End If
            Dim str4 As String
            str4 = "Update CMNuevos SET lock = '" & My.Settings.usuario2.Trim & "'  Where Contratos = '" & cmbcontrato1.Text & "'"
            comandos4 = New SqlCommand(str4, conexion)
            comandos4.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod5-fun-05:" & "_" & ex.Message)
        End Try
    End Sub
End Class