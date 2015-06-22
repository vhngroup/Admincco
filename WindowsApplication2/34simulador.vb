Option Explicit On
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Data.SqlClient

Public Class Form11
    Dim db As IDbConnection
    Dim midataset As DataSet
    Dim mienlazador As New BindingSource
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim reader As OleDbDataReader
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
    Private Sub Form11_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            conexion.Open()
        Catch ex As Exception

            MsgBox("La conexion a la base de datos es inestable", MsgBoxStyle.Critical, "Error")
            conexion.Open()
        End Try
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMOriginales' Puede moverla o quitarla según sea necesario.
        REM Me.CMOriginalesTableAdapter.Fill(Me.Adminco_MasterDataSet.CMOriginales)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ODS' Puede moverla o quitarla según sea necesario.
        Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
        Dim classResize As New clsResizeForm
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
        cmbcontrato1.SelectedIndex = 1
    End Sub
    Private Sub TextBox44_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox44.TextChanged
        anovigencia.Text = Year(dtfecha1.Value)
        vigencia()
        contabilidad()
        siguiente()
        validafecha()
        If txtnota.Text = "" Then
            Me.ErrorProvider1.SetError(txtnota, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
        End If
        If porcentiempog.Text >= 100 Or avancedineroglobal.Text >= 100 Or avancedinerovigencia.Text >= 100 = True Then
            txtnota.Enabled = False
            Id.Text = ""
            txtconsecutivo.Text = ""
            If txtnota.Text <> "" Then
                MsgBox("Este contrato no tiene saldo en la vigencia, por favor contactar con el administrador")
            End If
            txtnota.Text = ""
            txtarea.Enabled = False
        Else
            txtarea.Enabled = True
            contador()
            Id.Text = Val(cmbcontrato1.Text) & "-" & Val(txtconsecutivo.Text) + 1
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

        If vractual.Text > 0 Then
            gastoglobal.Text = FormatNumber(CDbl(gastoglobal.Text) + CDbl(vractual.Text))
            avancedineroglobal.Text = FormatNumber(CDbl(gastoglobal.Text) / CDbl(mcostot.Text) * 100)
            saldoglobal.Text = FormatNumber(CDbl(mcostot.Text) - CDbl(gastoglobal.Text))
            saldovigencia.Text = FormatNumber(CDbl(saldovigencia.Text) - CDbl(vractual.Text))
            gastovigencia.Text = FormatNumber(CDbl(txtvigencia.Text) - CDbl(saldovigencia.Text))
            avancedinerovigencia.Text = FormatNumber(CDbl(gastovigencia.Text) / CDbl(txtvigencia.Text) * 100)
            restar()
        Else
            gastoglobal.Text = FormatNumber(CDbl(mcostot.Text) - CDbl(saldototal.Text))
            saldoglobal.Text = FormatNumber(CDbl(mcostot.Text) - CDbl(gastoglobal.Text))
            avancedineroglobal.Text = FormatNumber(CDbl(gastoglobal.Text) / CDbl(mcostot.Text) * 100)

            gastovigencia.Text = FormatNumber(CDbl(txtvigencia.Text) - CDbl(saldovigencia.Text))
            saldovigencia.Text = FormatNumber(CDbl(txtvigencia.Text) - CDbl(gastovigencia.Text))
            avancedinerovigencia.Text = FormatNumber(CDbl(gastovigencia.Text) / CDbl(txtvigencia.Text) * 100)
        End If
        'Calcula vigencia
        alertas()
    End Sub

    Private Sub alertas()
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
            estadocm2.Text = "Se requiere solicitar cambio de vigencia presupuestal."
        End If
    End Sub
    Private Sub vigencia()
        anovigencia.Text = Year(dtfecha1.Value)
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

    Private Sub siguiente()
        If txtestado.Text <> "Abierto" Then
            If txtestado.Text = "" Then
                txtnota.Enabled = False
                txtarea.Enabled = False
                txtplanner.Enabled = False
            Else
                MsgBox("En este contrato no se pueden ejecutar ODS ya que este contrato se encuentra" & " " & txtestado.Text & " " & "Por favor contactar al administrador de contratos")
                txtnota.Enabled = False
                txtarea.Enabled = False
                txtplanner.Enabled = False
            End If
        End If
        If txtestado.Text = "Abierto" Then
            If dfaltantes.Text < 0 Then
                usersolicitante.Text = ""
            Else
                usersolicitante.Text = My.Settings.usuario2
                txtnota.Enabled = True
                txtarea.Enabled = True
                REM txtplanner.Enabled = True
            End If

        End If
    End Sub
    Private Sub validafecha()
        If dfaltantes.Text < 0 Then
            txtnota.Enabled = False
            txtarea.Enabled = False
            txtplanner.Enabled = False
            MsgBox("No se puede Cargar nada a esta ODS, ya que esta vencida.")
        Else
            txtnota.Enabled = True
            txtarea.Enabled = True
            REM txtplanner.Enabled = True
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
            contabilidad()
        End If
    End Sub
    Private Sub contador()

        Dim read As OleDbDataReader
        Dim maximo As Integer = 0
        comandos = conexion.CreateCommand()
        comandos.CommandText = "SELECT count(*) from ODS WHERE Contratos = '" & cmbcontrato1.Text & "'"
        maximo = CType(comandos.ExecuteScalar, Integer)
        REM read = comandos.ExecuteReader()
        txtconsecutivo.Text = ("00000" + maximo.ToString())
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
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        frmmenu.Show()
        frmmenu.retorno = 1
        conexion.Close()
        Me.Close()
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
    Private Sub txtnota_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnota.TextChanged

    End Sub
    Private Sub txtarea_TextChanged(sender As System.Object, e As System.EventArgs)
        cmbdisciplina.Enabled = True
    End Sub
    Private Sub textdescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles textdescripcion.TextChanged
        grpservicios.Enabled = True
        grpfecha.Enabled = True
        dtfechai.Enabled = True
        dtfechaf.Enabled = True
        txtarea.Text = txtarea.Text & " " & txtequipo.Text
        If txtnota.Text <> "" Then
            Me.ErrorProvider1.Clear()
        End If
        eplanner = txtplanner.Text + "@pacificrubiales.com.co"
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
                btguardar.Enabled = True
                txtnota.Enabled = False
                cmbcontrato1.Enabled = False
                txtarea.Enabled = False
                cmbdisciplina.Enabled = False
                grpcantidades.Enabled = False
                textdescripcion.Enabled = False
                grpfecha.Enabled = False
                btndistribuir.Enabled = False
                txtequipo.Enabled = False
                chktext = hoy & "" & getusername.Text
                txtplanner.Enabled = False
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
            txtequipo.Enabled = True
            txtplanner.Enabled = True
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
    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmmenu.Show()
        frmmenu.retorno = 1
        conexion.Close()
        Me.Close()
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
        ecreado.Text = getusername.Text & "@pacificrubiales.com.co"
        cname.Text = usersolicitante.Text & "@pacificrubiales.com.co"

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
            comandos.CommandText = "INSERT INTO ODS (Identificador, Contratos, PROVEEDOR, Creado, Asociacion, Fechacreacion, FechInicio, FechaFinal, Disciplina, Creadopor, Administrador, spadmin, Notaentrega, nombrecontratista, nitcontratista, portafolio, programam, programa, proyectom, proyecto, subproyecto, horasestimadas, tarifas, pdt, moneda, Costodirecto, Administracion, Imprevisto, Utilidad, Subtotal, iva, valorods, Tiposervicio1, SERVICIO1, ADM1, IMP1, UTIL1, CostoDirecto1, Administracion1, Imprevistos1, Utilidad1, Subtotal1, IVA1, Vrtotal1, Tiposervicio2, SERVICIO2, ADM2, IMP2, UTIL2, CostoDirecto2, Administracion2, Imprevistos2, Utilidad2, Subtotal2, IVA2, Vrtotal2, Tiposervicio3, SERVICIO3, ADM3, IMP3, UTIL3, CostoDirecto3, Administracion3, Imprevistos3, Utilidad3, Subtotal3, IVA3, Vrtotal3, Tiposervicio4, SERVICIO4, ADM4, IMP4, UTIL4, CostoDirecto4, Administracion4, Imprevistos4, Utilidad4, Subtotal4, IVA4, Vrtotal4, estado, FIRMA, VALIDAU, descripccion, dias, planner, valorcierre) VALUES (Identificador, Contratos, PROVEEDOR, Creado, Asociacion, Fechacreacion, FechInicio, FechaFinal, Disciplina, Creadopor, Administrador, spadmin, Notaentrega, nombrecontratista, nitcontratista, portafolio, programam, programa, proyectom, proyecto, subproyecto, horasestimadas, tarifas, pdt, moneda, Costodirecto, Administracion, Imprevisto, Utilidad, Subtotal, iva, valorods, Tiposervicio1, SERVICIO1, ADM1, IMP1, UTIL1, CostoDirecto1, Administracion1, Imprevistos1, Utilidad1, Subtotal1, IVA1, Vrtotal1, Tiposervicio2, SERVICIO2, ADM2, IMP2, UTIL2, CostoDirecto2, Administracion2, Imprevistos2, Utilidad2, Subtotal2, IVA2, Vrtotal2, Tiposervicio3, SERVICIO3, ADM3, IMP3, UTIL3, CostoDirecto3, Administracion3, Imprevistos3, Utilidad3, Subtotal3, IVA3, Vrtotal3, Tiposervicio4, SERVICIO4, ADM4, IMP4, UTIL4, CostoDirecto4, Administracion4, Imprevistos4, Utilidad4, Subtotal4, IVA4, Vrtotal4, estado, FIRMA, VALIDAU, descripccion, dias, planner, valorcierre)"
            comandos.CommandType = CommandType.Text
            comandos.Connection = conexion
            comandos.Parameters.AddWithValue("Identificador", Id.Text)
            comandos.Parameters.AddWithValue("Contratos", cmbcontrato1.Text)
            comandos.Parameters.AddWithValue("PROVEEDOR", cmbcontratista1.Text)
            comandos.Parameters.AddWithValue("Creado", txtcreado1.Text)
            comandos.Parameters.AddWithValue("Asociacion", txtasociacion.Text)
            comandos.Parameters.AddWithValue("Fechacreacion", dtfecha1.Value)
            comandos.Parameters.AddWithValue("FechInicio", dtfechai.Value)
            comandos.Parameters.AddWithValue("FechaFinal", dtfechaf.Value)
            comandos.Parameters.AddWithValue("Disciplina", cmbdisciplina.Text)
            comandos.Parameters.AddWithValue("Creadopor", usersolicitante.Text)
            comandos.Parameters.AddWithValue("Administrador", cmbadmin1.Text)
            comandos.Parameters.AddWithValue("spadmin", cmbusuario1.Text)
            comandos.Parameters.AddWithValue("Notaentrega", txtnota.Text)
            comandos.Parameters.AddWithValue("nombrecontratista", cmbcontratista1.Text)
            comandos.Parameters.AddWithValue("nitcontratista", txtnit1.Text)
            comandos.Parameters.AddWithValue("portafolio", txtportafolio.Text)
            comandos.Parameters.AddWithValue("programam", txtprogramam.Text)
            comandos.Parameters.AddWithValue("programa", txtprograma.Text)
            comandos.Parameters.AddWithValue("proyectom", txtprograma.Text)
            comandos.Parameters.AddWithValue("proyecto", txtprograma1.Text)
            comandos.Parameters.AddWithValue("subproyecto", txtarea.Text)
            comandos.Parameters.AddWithValue("horasestimadas", Label22.Text)
            comandos.Parameters.AddWithValue("tarifas", Label23.Text)
            comandos.Parameters.AddWithValue("pdt", Label24.Text)
            comandos.Parameters.AddWithValue("moneda", cmbmoneda.Text)
            comandos.Parameters.AddWithValue("Costodirecto", CDbl(costod1.Text))
            comandos.Parameters.AddWithValue("Administracion", CDbl(admin1.Text))
            comandos.Parameters.AddWithValue("Imprevisto", CDbl(impre1.Text))
            comandos.Parameters.AddWithValue("Utilidad", CDbl(util1.Text))
            comandos.Parameters.AddWithValue("Subtotal", CDbl(subt1.Text))
            comandos.Parameters.AddWithValue("iva", CDbl(iva1.Text))
            comandos.Parameters.AddWithValue("valorods", CDbl(vractual.Text))
            comandos.Parameters.AddWithValue("Tiposervicio1", servicio2(0))
            comandos.Parameters.AddWithValue("SERVICIO1", nservicio2(0))
            comandos.Parameters.AddWithValue("ADM1", CDbl(a2(0)))
            comandos.Parameters.AddWithValue("IMP1", CDbl(i2(0)))
            comandos.Parameters.AddWithValue("UTIL1", CDbl(u2(0)))
            comandos.Parameters.AddWithValue("CostoDirecto1", costod2(0))
            comandos.Parameters.AddWithValue("Administracion1", admin2(0))
            comandos.Parameters.AddWithValue("Imprevistos1", impre2(0))
            comandos.Parameters.AddWithValue("Utilidad1", util2(0))
            comandos.Parameters.AddWithValue("Subtotal1", subt2(0))
            comandos.Parameters.AddWithValue("IVA1", iva2(0))
            comandos.Parameters.AddWithValue("Vrtotal1", total2(0))
            comandos.Parameters.AddWithValue("Tiposervicio2", servicio2(1))
            comandos.Parameters.AddWithValue("SERVICIO2", nservicio2(1))
            comandos.Parameters.AddWithValue("ADM2", CDbl(a2(1)))
            comandos.Parameters.AddWithValue("IMP2", CDbl(i2(1)))
            comandos.Parameters.AddWithValue("UTIL2", CDbl(u2(1)))
            comandos.Parameters.AddWithValue("CostoDirecto2", costod2(1))
            comandos.Parameters.AddWithValue("Administracion2", admin2(1))
            comandos.Parameters.AddWithValue("Imprevistos2", impre2(1))
            comandos.Parameters.AddWithValue("Utilidad2", util2(1))
            comandos.Parameters.AddWithValue("Subtotal2", subt2(1))
            comandos.Parameters.AddWithValue("IVA2", iva2(1))
            comandos.Parameters.AddWithValue("Vrtotal2", total2(1))
            comandos.Parameters.AddWithValue("Tiposervicio3", servicio2(2))
            comandos.Parameters.AddWithValue("SERVICIO3", nservicio2(2))
            comandos.Parameters.AddWithValue("ADM3", CDbl(a2(2)))
            comandos.Parameters.AddWithValue("IMP3", CDbl(i2(2)))
            comandos.Parameters.AddWithValue("UTIL3", CDbl(u2(2)))
            comandos.Parameters.AddWithValue("CostoDirecto3", costod2(2))
            comandos.Parameters.AddWithValue("Administracion3", admin2(2))
            comandos.Parameters.AddWithValue("Imprevistos3", impre2(2))
            comandos.Parameters.AddWithValue("Utilidad3", util2(2))
            comandos.Parameters.AddWithValue("Subtotal3", subt2(2))
            comandos.Parameters.AddWithValue("IVA3", iva2(2))
            comandos.Parameters.AddWithValue("Vrtotal3", total2(2))
            comandos.Parameters.AddWithValue("Tiposervicio4", servicio2(3))
            comandos.Parameters.AddWithValue("SERVICIO4", nservicio2(3))
            comandos.Parameters.AddWithValue("ADM4", CDbl(a2(3)))
            comandos.Parameters.AddWithValue("IMP4", CDbl(i2(3)))
            comandos.Parameters.AddWithValue("UTIL4", CDbl(u2(3)))
            comandos.Parameters.AddWithValue("CostoDirecto4", costod2(3))
            comandos.Parameters.AddWithValue("Administracion4", admin2(3))
            comandos.Parameters.AddWithValue("Imprevistos4", impre2(3))
            comandos.Parameters.AddWithValue("Utilidad4", util2(3))
            comandos.Parameters.AddWithValue("Subtotal4", subt2(3))
            comandos.Parameters.AddWithValue("IVA4", iva2(3))
            comandos.Parameters.AddWithValue("Vrtotal4", total2(3))
            comandos.Parameters.AddWithValue("estado", Estadoods.Text)
            comandos.Parameters.AddWithValue("FIRMA", getusername.Text)
            comandos.Parameters.AddWithValue("VALIDAU", chktext)
            comandos.Parameters.AddWithValue("descripccion", textdescripcion.Text)
            comandos.Parameters.AddWithValue("dias", txtdias.Text)
            comandos.Parameters.AddWithValue("planner", txtplanner.Text)
            comandos.Parameters.AddWithValue("valorcierre", vractual.Text)
            comandos.ExecuteNonQuery()
            conexion.Close()
            If conexion.State = ConnectionState.Open Then
            Else
                conexion.Open()
            End If

            Dim str As String
            If anovigencia.Text.Trim = ano1.Text.Trim Then
                str = "Update CMNuevos SET CostoDirecto1 = '" & CDbl(impcostod(0)) & "', Administracion1 = '" & CDbl(impadmin(0)) & "', Imprevistos1 = '" & CDbl(impimpre(0)) & "', Utilidad1 = '" & CDbl(imputil(0)) & "', Subtotal1 = '" & CDbl(impsubtotal(0)) & "', IVA1 = '" & CDbl(impiva(0)) & "', VrTotal1 = '" & CDbl(imptotal(0)) & "', CostoDirecto2 = '" & CDbl(impcostod(1)) & "', Administracion2 = '" & CDbl(impadmin(1)) & "', Imprevistos2 = '" & CDbl(impimpre(1)) & "', Utilidad2 = '" & CDbl(imputil(1)) & "', Subtotal2 = '" & CDbl(impsubtotal(1)) & "', IVA2 = '" & CDbl(impiva(1)) & "', VrTotal2 = '" & CDbl(imptotal(1)) & "', CostoDirecto3 = '" & CDbl(impcostod(2)) & "', Administracion3 = '" & CDbl(impadmin(2)) & "', Imprevistos3 = '" & CDbl(impimpre(2)) & "', Utilidad3 = '" & CDbl(imputil(2)) & "', Subtotal3 = '" & CDbl(impsubtotal(2)) & "', IVA3 = '" & CDbl(impiva(2)) & "', VrTotal3 = '" & CDbl(imptotal(2)) & "', CostoDirecto4 = '" & CDbl(impcostod(3)) & "', Administracion4 = '" & CDbl(impadmin(3)) & "', Imprevistos4 = '" & CDbl(impimpre(3)) & "', Utilidad4 = '" & CDbl(imputil(3)) & "', Subtotal4 = '" & CDbl(impsubtotal(3)) & "', IVA4 = '" & CDbl(impiva(3)) & "', VrTotal4 = '" & CDbl(imptotal(3)) & "', CostoDirecto5 = '" & CDbl(impcostod(4)) & "', Administracion5 = '" & CDbl(impadmin(4)) & "', Imprevistos5 = '" & CDbl(impimpre(4)) & "', Utilidad5 = '" & CDbl(imputil(4)) & "', Subtotal5 = '" & CDbl(impsubtotal(4)) & "', IVA5 = '" & CDbl(impiva(4)) & "', VrTotal5 = '" & CDbl(imptotal(4)) & "', CostoDirecto6 = '" & CDbl(impcostod(5)) & "', Administracion6 = '" & CDbl(impadmin(5)) & "', Imprevistos6 = '" & CDbl(impimpre(5)) & "', Utilidad6 = '" & CDbl(imputil(5)) & "', Subtotal6 = '" & CDbl(impsubtotal(5)) & "', IVA6 = '" & CDbl(impiva(5)) & "', VrTotal6 = '" & CDbl(imptotal(5)) & "', CostoDirecto7 = '" & CDbl(impcostod(6)) & "', Administracion7 = '" & CDbl(impadmin(6)) & "', Imprevistos7 = '" & CDbl(impimpre(6)) & "', Utilidad7 = '" & CDbl(imputil(6)) & "', Subtotal7 = '" & CDbl(impsubtotal(6)) & "', IVA7 = '" & CDbl(impiva(6)) & "', VrTotal7 = '" & CDbl(imptotal(6)) & "', CostoDirecto8 = '" & CDbl(impcostod(7)) & "', Administracion8 = '" & CDbl(impadmin(7)) & "', Imprevistos8 = '" & CDbl(impimpre(7)) & "', Utilidad8 = '" & CDbl(imputil(7)) & "', Subtotal8 = '" & CDbl(impsubtotal(7)) & "', IVA8 = '" & CDbl(impiva(7)) & "', VrTotal8 = '" & CDbl(imptotal(7)) & "', VALOR1 = '" & CDbl(saldovigencia.Text) & "',  porcentajetiempo = '" & CDbl(porcentiempog.Text) & "',  porcentajedinero = '" & CDbl(avancedineroglobal.Text) & "', porcentajedvigencia = '" & CDbl(avancedinerovigencia.Text) & "', saldoglobal = '" & CDbl(saldoglobal.Text) & "', acumuladovigencia = '" & CDbl(gastovigencia.Text) & "', saldodirecto = '" & CDbl(saldocostdirecto.Text) & "', saldoadmin = '" & CDbl(saldoadmin.Text) & "', saldoimpre = '" & CDbl(saldoimpre.Text) & "', saldoutil = '" & CDbl(saldoutil.Text) & "', saldosubtotal = '" & CDbl(saldosubtotal.Text) & "', saldoiva = '" & CDbl(saldoiva.Text) & "', saldototal = '" & CDbl(saldototal.Text) & "'  Where Contratos = '" & cmbcontrato1.Text & "'"
            End If
            If anovigencia.Text.Trim = ano2.Text.Trim Then
                str = "Update CMNuevos SET CostoDirecto1 = '" & CDbl(impcostod(0)) & "', Administracion1 = '" & CDbl(impadmin(0)) & "', Imprevistos1 = '" & CDbl(impimpre(0)) & "', Utilidad1 = '" & CDbl(imputil(0)) & "', Subtotal1 = '" & CDbl(impsubtotal(0)) & "', IVA1 = '" & CDbl(impiva(0)) & "', VrTotal1 = '" & CDbl(imptotal(0)) & "', CostoDirecto2 = '" & CDbl(impcostod(1)) & "', Administracion2 = '" & CDbl(impadmin(1)) & "', Imprevistos2 = '" & CDbl(impimpre(1)) & "', Utilidad2 = '" & CDbl(imputil(1)) & "', Subtotal2 = '" & CDbl(impsubtotal(1)) & "', IVA2 = '" & CDbl(impiva(1)) & "', VrTotal2 = '" & CDbl(imptotal(1)) & "', CostoDirecto3 = '" & CDbl(impcostod(2)) & "', Administracion3 = '" & CDbl(impadmin(2)) & "', Imprevistos3 = '" & CDbl(impimpre(2)) & "', Utilidad3 = '" & CDbl(imputil(2)) & "', Subtotal3 = '" & CDbl(impsubtotal(2)) & "', IVA3 = '" & CDbl(impiva(2)) & "', VrTotal3 = '" & CDbl(imptotal(2)) & "', CostoDirecto4 = '" & CDbl(impcostod(3)) & "', Administracion4 = '" & CDbl(impadmin(3)) & "', Imprevistos4 = '" & CDbl(impimpre(3)) & "', Utilidad4 = '" & CDbl(imputil(3)) & "', Subtotal4 = '" & CDbl(impsubtotal(3)) & "', IVA4 = '" & CDbl(impiva(3)) & "', VrTotal4 = '" & CDbl(imptotal(3)) & "', CostoDirecto5 = '" & CDbl(impcostod(4)) & "', Administracion5 = '" & CDbl(impadmin(4)) & "', Imprevistos5 = '" & CDbl(impimpre(4)) & "', Utilidad5 = '" & CDbl(imputil(4)) & "', Subtotal5 = '" & CDbl(impsubtotal(4)) & "', IVA5 = '" & CDbl(impiva(4)) & "', VrTotal5 = '" & CDbl(imptotal(4)) & "', CostoDirecto6 = '" & CDbl(impcostod(5)) & "', Administracion6 = '" & CDbl(impadmin(5)) & "', Imprevistos6 = '" & CDbl(impimpre(5)) & "', Utilidad6 = '" & CDbl(imputil(5)) & "', Subtotal6 = '" & CDbl(impsubtotal(5)) & "', IVA6 = '" & CDbl(impiva(5)) & "', VrTotal6 = '" & CDbl(imptotal(5)) & "', CostoDirecto7 = '" & CDbl(impcostod(6)) & "', Administracion7 = '" & CDbl(impadmin(6)) & "', Imprevistos7 = '" & CDbl(impimpre(6)) & "', Utilidad7 = '" & CDbl(imputil(6)) & "', Subtotal7 = '" & CDbl(impsubtotal(6)) & "', IVA7 = '" & CDbl(impiva(6)) & "', VrTotal7 = '" & CDbl(imptotal(6)) & "', CostoDirecto8 = '" & CDbl(impcostod(7)) & "', Administracion8 = '" & CDbl(impadmin(7)) & "', Imprevistos8 = '" & CDbl(impimpre(7)) & "', Utilidad8 = '" & CDbl(imputil(7)) & "', Subtotal8 = '" & CDbl(impsubtotal(7)) & "', IVA8 = '" & CDbl(impiva(7)) & "', VrTotal8 = '" & CDbl(imptotal(7)) & "', VALOR2 = '" & CDbl(saldovigencia.Text) & "',  porcentajetiempo = '" & CDbl(porcentiempog.Text) & "',  porcentajedinero = '" & CDbl(avancedineroglobal.Text) & "', porcentajedvigencia = '" & CDbl(avancedinerovigencia.Text) & "', saldoglobal = '" & CDbl(saldoglobal.Text) & "', acumuladovigencia = '" & CDbl(gastovigencia.Text) & "', saldodirecto = '" & CDbl(saldocostdirecto.Text) & "', saldoadmin = '" & CDbl(saldoadmin.Text) & "', saldoimpre = '" & CDbl(saldoimpre.Text) & "', saldoutil = '" & CDbl(saldoutil.Text) & "', saldosubtotal = '" & CDbl(saldosubtotal.Text) & "', saldoiva = '" & CDbl(saldoiva.Text) & "', saldototal = '" & CDbl(saldototal.Text) & "'  Where Contratos = '" & cmbcontrato1.Text & "'"
            End If
            If anovigencia.Text.Trim = ano3.Text.Trim Then
                str = "Update CMNuevos SET CostoDirecto1 = '" & CDbl(impcostod(0)) & "', Administracion1 = '" & CDbl(impadmin(0)) & "', Imprevistos1 = '" & CDbl(impimpre(0)) & "', Utilidad1 = '" & CDbl(imputil(0)) & "', Subtotal1 = '" & CDbl(impsubtotal(0)) & "', IVA1 = '" & CDbl(impiva(0)) & "', VrTotal1 = '" & CDbl(imptotal(0)) & "', CostoDirecto2 = '" & CDbl(impcostod(1)) & "', Administracion2 = '" & CDbl(impadmin(1)) & "', Imprevistos2 = '" & CDbl(impimpre(1)) & "', Utilidad2 = '" & CDbl(imputil(1)) & "', Subtotal2 = '" & CDbl(impsubtotal(1)) & "', IVA2 = '" & CDbl(impiva(1)) & "', VrTotal2 = '" & CDbl(imptotal(1)) & "', CostoDirecto3 = '" & CDbl(impcostod(2)) & "', Administracion3 = '" & CDbl(impadmin(2)) & "', Imprevistos3 = '" & CDbl(impimpre(2)) & "', Utilidad3 = '" & CDbl(imputil(2)) & "', Subtotal3 = '" & CDbl(impsubtotal(2)) & "', IVA3 = '" & CDbl(impiva(2)) & "', VrTotal3 = '" & CDbl(imptotal(2)) & "', CostoDirecto4 = '" & CDbl(impcostod(3)) & "', Administracion4 = '" & CDbl(impadmin(3)) & "', Imprevistos4 = '" & CDbl(impimpre(3)) & "', Utilidad4 = '" & CDbl(imputil(3)) & "', Subtotal4 = '" & CDbl(impsubtotal(3)) & "', IVA4 = '" & CDbl(impiva(3)) & "', VrTotal4 = '" & CDbl(imptotal(3)) & "', CostoDirecto5 = '" & CDbl(impcostod(4)) & "', Administracion5 = '" & CDbl(impadmin(4)) & "', Imprevistos5 = '" & CDbl(impimpre(4)) & "', Utilidad5 = '" & CDbl(imputil(4)) & "', Subtotal5 = '" & CDbl(impsubtotal(4)) & "', IVA5 = '" & CDbl(impiva(4)) & "', VrTotal5 = '" & CDbl(imptotal(4)) & "', CostoDirecto6 = '" & CDbl(impcostod(5)) & "', Administracion6 = '" & CDbl(impadmin(5)) & "', Imprevistos6 = '" & CDbl(impimpre(5)) & "', Utilidad6 = '" & CDbl(imputil(5)) & "', Subtotal6 = '" & CDbl(impsubtotal(5)) & "', IVA6 = '" & CDbl(impiva(5)) & "', VrTotal6 = '" & CDbl(imptotal(5)) & "', CostoDirecto7 = '" & CDbl(impcostod(6)) & "', Administracion7 = '" & CDbl(impadmin(6)) & "', Imprevistos7 = '" & CDbl(impimpre(6)) & "', Utilidad7 = '" & CDbl(imputil(6)) & "', Subtotal7 = '" & CDbl(impsubtotal(6)) & "', IVA7 = '" & CDbl(impiva(6)) & "', VrTotal7 = '" & CDbl(imptotal(6)) & "', CostoDirecto8 = '" & CDbl(impcostod(7)) & "', Administracion8 = '" & CDbl(impadmin(7)) & "', Imprevistos8 = '" & CDbl(impimpre(7)) & "', Utilidad8 = '" & CDbl(imputil(7)) & "', Subtotal8 = '" & CDbl(impsubtotal(7)) & "', IVA8 = '" & CDbl(impiva(7)) & "', VrTotal8 = '" & CDbl(imptotal(7)) & "', VALOR3 = '" & CDbl(saldovigencia.Text) & "',  porcentajetiempo = '" & CDbl(porcentiempog.Text) & "',  porcentajedinero = '" & CDbl(avancedineroglobal.Text) & "', porcentajedvigencia = '" & CDbl(avancedinerovigencia.Text) & "', saldoglobal = '" & CDbl(saldoglobal.Text) & "', acumuladovigencia = '" & CDbl(gastovigencia.Text) & "', saldodirecto = '" & CDbl(saldocostdirecto.Text) & "', saldoadmin = '" & CDbl(saldoadmin.Text) & "', saldoimpre = '" & CDbl(saldoimpre.Text) & "', saldoutil = '" & CDbl(saldoutil.Text) & "', saldosubtotal = '" & CDbl(saldosubtotal.Text) & "', saldoiva = '" & CDbl(saldoiva.Text) & "', saldototal = '" & CDbl(saldototal.Text) & "'  Where Contratos = '" & cmbcontrato1.Text & "'"
            End If
            If anovigencia.Text.Trim = ano4.Text.Trim Then
                str = "Update CMNuevos SET CostoDirecto1 = '" & CDbl(impcostod(0)) & "', Administracion1 = '" & CDbl(impadmin(0)) & "', Imprevistos1 = '" & CDbl(impimpre(0)) & "', Utilidad1 = '" & CDbl(imputil(0)) & "', Subtotal1 = '" & CDbl(impsubtotal(0)) & "', IVA1 = '" & CDbl(impiva(0)) & "', VrTotal1 = '" & CDbl(imptotal(0)) & "', CostoDirecto2 = '" & CDbl(impcostod(1)) & "', Administracion2 = '" & CDbl(impadmin(1)) & "', Imprevistos2 = '" & CDbl(impimpre(1)) & "', Utilidad2 = '" & CDbl(imputil(1)) & "', Subtotal2 = '" & CDbl(impsubtotal(1)) & "', IVA2 = '" & CDbl(impiva(1)) & "', VrTotal2 = '" & CDbl(imptotal(1)) & "', CostoDirecto3 = '" & CDbl(impcostod(2)) & "', Administracion3 = '" & CDbl(impadmin(2)) & "', Imprevistos3 = '" & CDbl(impimpre(2)) & "', Utilidad3 = '" & CDbl(imputil(2)) & "', Subtotal3 = '" & CDbl(impsubtotal(2)) & "', IVA3 = '" & CDbl(impiva(2)) & "', VrTotal3 = '" & CDbl(imptotal(2)) & "', CostoDirecto4 = '" & CDbl(impcostod(3)) & "', Administracion4 = '" & CDbl(impadmin(3)) & "', Imprevistos4 = '" & CDbl(impimpre(3)) & "', Utilidad4 = '" & CDbl(imputil(3)) & "', Subtotal4 = '" & CDbl(impsubtotal(3)) & "', IVA4 = '" & CDbl(impiva(3)) & "', VrTotal4 = '" & CDbl(imptotal(3)) & "', CostoDirecto5 = '" & CDbl(impcostod(4)) & "', Administracion5 = '" & CDbl(impadmin(4)) & "', Imprevistos5 = '" & CDbl(impimpre(4)) & "', Utilidad5 = '" & CDbl(imputil(4)) & "', Subtotal5 = '" & CDbl(impsubtotal(4)) & "', IVA5 = '" & CDbl(impiva(4)) & "', VrTotal5 = '" & CDbl(imptotal(4)) & "', CostoDirecto6 = '" & CDbl(impcostod(5)) & "', Administracion6 = '" & CDbl(impadmin(5)) & "', Imprevistos6 = '" & CDbl(impimpre(5)) & "', Utilidad6 = '" & CDbl(imputil(5)) & "', Subtotal6 = '" & CDbl(impsubtotal(5)) & "', IVA6 = '" & CDbl(impiva(5)) & "', VrTotal6 = '" & CDbl(imptotal(5)) & "', CostoDirecto7 = '" & CDbl(impcostod(6)) & "', Administracion7 = '" & CDbl(impadmin(6)) & "', Imprevistos7 = '" & CDbl(impimpre(6)) & "', Utilidad7 = '" & CDbl(imputil(6)) & "', Subtotal7 = '" & CDbl(impsubtotal(6)) & "', IVA7 = '" & CDbl(impiva(6)) & "', VrTotal7 = '" & CDbl(imptotal(6)) & "', CostoDirecto8 = '" & CDbl(impcostod(7)) & "', Administracion8 = '" & CDbl(impadmin(7)) & "', Imprevistos8 = '" & CDbl(impimpre(7)) & "', Utilidad8 = '" & CDbl(imputil(7)) & "', Subtotal8 = '" & CDbl(impsubtotal(7)) & "', IVA8 = '" & CDbl(impiva(7)) & "', VrTotal8 = '" & CDbl(imptotal(7)) & "', VALOR4 = '" & CDbl(saldovigencia.Text) & "',  porcentajetiempo = '" & CDbl(porcentiempog.Text) & "',  porcentajedinero = '" & CDbl(avancedineroglobal.Text) & "', porcentajedvigencia = '" & CDbl(avancedinerovigencia.Text) & "', saldoglobal = '" & CDbl(saldoglobal.Text) & "', acumuladovigencia = '" & CDbl(gastovigencia.Text) & "', saldodirecto = '" & CDbl(saldocostdirecto.Text) & "', saldoadmin = '" & CDbl(saldoadmin.Text) & "', saldoimpre = '" & CDbl(saldoimpre.Text) & "', saldoutil = '" & CDbl(saldoutil.Text) & "', saldosubtotal = '" & CDbl(saldosubtotal.Text) & "', saldoiva = '" & CDbl(saldoiva.Text) & "', saldototal = '" & CDbl(saldototal.Text) & "'  Where Contratos = '" & cmbcontrato1.Text & "'"
            End If
            If anovigencia.Text.Trim = ano5.Text.Trim Then
                str = "Update CMNuevos SET CostoDirecto1 = '" & CDbl(impcostod(0)) & "', Administracion1 = '" & CDbl(impadmin(0)) & "', Imprevistos1 = '" & CDbl(impimpre(0)) & "', Utilidad1 = '" & CDbl(imputil(0)) & "', Subtotal1 = '" & CDbl(impsubtotal(0)) & "', IVA1 = '" & CDbl(impiva(0)) & "', VrTotal1 = '" & CDbl(imptotal(0)) & "', CostoDirecto2 = '" & CDbl(impcostod(1)) & "', Administracion2 = '" & CDbl(impadmin(1)) & "', Imprevistos2 = '" & CDbl(impimpre(1)) & "', Utilidad2 = '" & CDbl(imputil(1)) & "', Subtotal2 = '" & CDbl(impsubtotal(1)) & "', IVA2 = '" & CDbl(impiva(1)) & "', VrTotal2 = '" & CDbl(imptotal(1)) & "', CostoDirecto3 = '" & CDbl(impcostod(2)) & "', Administracion3 = '" & CDbl(impadmin(2)) & "', Imprevistos3 = '" & CDbl(impimpre(2)) & "', Utilidad3 = '" & CDbl(imputil(2)) & "', Subtotal3 = '" & CDbl(impsubtotal(2)) & "', IVA3 = '" & CDbl(impiva(2)) & "', VrTotal3 = '" & CDbl(imptotal(2)) & "', CostoDirecto4 = '" & CDbl(impcostod(3)) & "', Administracion4 = '" & CDbl(impadmin(3)) & "', Imprevistos4 = '" & CDbl(impimpre(3)) & "', Utilidad4 = '" & CDbl(imputil(3)) & "', Subtotal4 = '" & CDbl(impsubtotal(3)) & "', IVA4 = '" & CDbl(impiva(3)) & "', VrTotal4 = '" & CDbl(imptotal(3)) & "', CostoDirecto5 = '" & CDbl(impcostod(4)) & "', Administracion5 = '" & CDbl(impadmin(4)) & "', Imprevistos5 = '" & CDbl(impimpre(4)) & "', Utilidad5 = '" & CDbl(imputil(4)) & "', Subtotal5 = '" & CDbl(impsubtotal(4)) & "', IVA5 = '" & CDbl(impiva(4)) & "', VrTotal5 = '" & CDbl(imptotal(4)) & "', CostoDirecto6 = '" & CDbl(impcostod(5)) & "', Administracion6 = '" & CDbl(impadmin(5)) & "', Imprevistos6 = '" & CDbl(impimpre(5)) & "', Utilidad6 = '" & CDbl(imputil(5)) & "', Subtotal6 = '" & CDbl(impsubtotal(5)) & "', IVA6 = '" & CDbl(impiva(5)) & "', VrTotal6 = '" & CDbl(imptotal(5)) & "', CostoDirecto7 = '" & CDbl(impcostod(6)) & "', Administracion7 = '" & CDbl(impadmin(6)) & "', Imprevistos7 = '" & CDbl(impimpre(6)) & "', Utilidad7 = '" & CDbl(imputil(6)) & "', Subtotal7 = '" & CDbl(impsubtotal(6)) & "', IVA7 = '" & CDbl(impiva(6)) & "', VrTotal7 = '" & CDbl(imptotal(6)) & "', CostoDirecto8 = '" & CDbl(impcostod(7)) & "', Administracion8 = '" & CDbl(impadmin(7)) & "', Imprevistos8 = '" & CDbl(impimpre(7)) & "', Utilidad8 = '" & CDbl(imputil(7)) & "', Subtotal8 = '" & CDbl(impsubtotal(7)) & "', IVA8 = '" & CDbl(impiva(7)) & "', VrTotal8 = '" & CDbl(imptotal(7)) & "', VALOR5 = '" & CDbl(saldovigencia.Text) & "',  porcentajetiempo = '" & CDbl(porcentiempog.Text) & "',  porcentajedinero = '" & CDbl(avancedineroglobal.Text) & "', porcentajedvigencia = '" & CDbl(avancedinerovigencia.Text) & "', saldoglobal = '" & CDbl(saldoglobal.Text) & "', acumuladovigencia = '" & CDbl(gastovigencia.Text) & "', saldodirecto = '" & CDbl(saldocostdirecto.Text) & "', saldoadmin = '" & CDbl(saldoadmin.Text) & "', saldoimpre = '" & CDbl(saldoimpre.Text) & "', saldoutil = '" & CDbl(saldoutil.Text) & "', saldosubtotal = '" & CDbl(saldosubtotal.Text) & "', saldoiva = '" & CDbl(saldoiva.Text) & "', saldototal = '" & CDbl(saldototal.Text) & "'  Where Contratos = '" & cmbcontrato1.Text & "'"
            End If
            comandos = New SqlCommand(str, conexion)
            comandos.ExecuteNonQuery()
            conexion.Close()
            guardar2()
            MsgBox("Guardado Corectamente", vbInformation, ("Guardado"))
            btguardar.Enabled = False
            CheckBox4.Enabled = False
            modo1 = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
    End Sub
    Private Sub guardar2()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos.CommandText = "INSERT INTO ODSOriginales (Identificador, Contratos, PROVEEDOR, Creado, Asociacion, Fechacreacion, FechInicio, FechaFinal, Disciplina, Creadopor, Administrador, spadmin, Notaentrega, nombrecontratista, nitcontratista, portafolio, programam, programa, proyectom, proyecto, subproyecto, horasestimadas, tarifas, pdt, moneda, Costodirecto, Administracion, Imprevisto, Utilidad, Subtotal, iva, valorods, Tiposervicio1, SERVICIO1, ADM1, IMP1, UTIL1, CostoDirecto1, Administracion1, Imprevistos1, Utilidad1, Subtotal1, IVA1, Vrtotal1, Tiposervicio2, SERVICIO2, ADM2, IMP2, UTIL2, CostoDirecto2, Administracion2, Imprevistos2, Utilidad2, Subtotal2, IVA2, Vrtotal2, Tiposervicio3, SERVICIO3, ADM3, IMP3, UTIL3, CostoDirecto3, Administracion3, Imprevistos3, Utilidad3, Subtotal3, IVA3, Vrtotal3, Tiposervicio4, SERVICIO4, ADM4, IMP4, UTIL4, CostoDirecto4, Administracion4, Imprevistos4, Utilidad4, Subtotal4, IVA4, Vrtotal4, estado, FIRMA, VALIDAU, descripccion, dias, planner, valorcierre) VALUES (Identificador, Contratos, PROVEEDOR, Creado, Asociacion, Fechacreacion, FechInicio, FechaFinal, Disciplina, Creadopor, Administrador, spadmin, Notaentrega, nombrecontratista, nitcontratista, portafolio, programam, programa, proyectom, proyecto, subproyecto, horasestimadas, tarifas, pdt, moneda, Costodirecto, Administracion, Imprevisto, Utilidad, Subtotal, iva, valorods, Tiposervicio1, SERVICIO1, ADM1, IMP1, UTIL1, CostoDirecto1, Administracion1, Imprevistos1, Utilidad1, Subtotal1, IVA1, Vrtotal1, Tiposervicio2, SERVICIO2, ADM2, IMP2, UTIL2, CostoDirecto2, Administracion2, Imprevistos2, Utilidad2, Subtotal2, IVA2, Vrtotal2, Tiposervicio3, SERVICIO3, ADM3, IMP3, UTIL3, CostoDirecto3, Administracion3, Imprevistos3, Utilidad3, Subtotal3, IVA3, Vrtotal3, Tiposervicio4, SERVICIO4, ADM4, IMP4, UTIL4, CostoDirecto4, Administracion4, Imprevistos4, Utilidad4, Subtotal4, IVA4, Vrtotal4, estado, FIRMA, VALIDAU, descripccion, dias, planner, valorcierre)"
            comandos.CommandType = CommandType.Text
            comandos.Connection = conexion
            comandos.Parameters.AddWithValue("Identificador", Id.Text)
            comandos.Parameters.AddWithValue("Contratos", cmbcontrato1.Text)
            comandos.Parameters.AddWithValue("PROVEEDOR", cmbcontratista1.Text)
            comandos.Parameters.AddWithValue("Creado", txtcreado1.Text)
            comandos.Parameters.AddWithValue("Asociacion", txtasociacion.Text)
            comandos.Parameters.AddWithValue("Fechacreacion", dtfecha1.Value)
            comandos.Parameters.AddWithValue("FechInicio", dtfechai.Value)
            comandos.Parameters.AddWithValue("FechaFinal", dtfechaf.Value)
            comandos.Parameters.AddWithValue("Disciplina", cmbdisciplina.Text)
            comandos.Parameters.AddWithValue("Creadopor", usersolicitante.Text)
            comandos.Parameters.AddWithValue("Administrador", cmbadmin1.Text)
            comandos.Parameters.AddWithValue("spadmin", cmbusuario1.Text)
            comandos.Parameters.AddWithValue("Notaentrega", txtnota.Text)
            comandos.Parameters.AddWithValue("nombrecontratista", cmbcontratista1.Text)
            comandos.Parameters.AddWithValue("nitcontratista", txtnit1.Text)
            comandos.Parameters.AddWithValue("portafolio", txtportafolio.Text)
            comandos.Parameters.AddWithValue("programam", txtprogramam.Text)
            comandos.Parameters.AddWithValue("programa", txtprograma.Text)
            comandos.Parameters.AddWithValue("proyectom", txtprograma.Text)
            comandos.Parameters.AddWithValue("proyecto", txtprograma1.Text)
            comandos.Parameters.AddWithValue("subproyecto", txtarea.Text)
            comandos.Parameters.AddWithValue("horasestimadas", Label22.Text)
            comandos.Parameters.AddWithValue("tarifas", Label23.Text)
            comandos.Parameters.AddWithValue("pdt", Label24.Text)
            comandos.Parameters.AddWithValue("moneda", cmbmoneda.Text)
            comandos.Parameters.AddWithValue("Costodirecto", CDbl(costod1.Text))
            comandos.Parameters.AddWithValue("Administracion", CDbl(admin1.Text))
            comandos.Parameters.AddWithValue("Imprevisto", CDbl(impre1.Text))
            comandos.Parameters.AddWithValue("Utilidad", CDbl(util1.Text))
            comandos.Parameters.AddWithValue("Subtotal", CDbl(subt1.Text))
            comandos.Parameters.AddWithValue("iva", CDbl(iva1.Text))
            comandos.Parameters.AddWithValue("valorods", CDbl(vractual.Text))
            comandos.Parameters.AddWithValue("Tiposervicio1", servicio2(0))
            comandos.Parameters.AddWithValue("SERVICIO1", nservicio2(0))
            comandos.Parameters.AddWithValue("ADM1", CDbl(a2(0)))
            comandos.Parameters.AddWithValue("IMP1", CDbl(i2(0)))
            comandos.Parameters.AddWithValue("UTIL1", CDbl(u2(0)))
            comandos.Parameters.AddWithValue("CostoDirecto1", costod2(0))
            comandos.Parameters.AddWithValue("Administracion1", admin2(0))
            comandos.Parameters.AddWithValue("Imprevistos1", impre2(0))
            comandos.Parameters.AddWithValue("Utilidad1", util2(0))
            comandos.Parameters.AddWithValue("Subtotal1", subt2(0))
            comandos.Parameters.AddWithValue("IVA1", iva2(0))
            comandos.Parameters.AddWithValue("Vrtotal1", total2(0))
            comandos.Parameters.AddWithValue("Tiposervicio2", servicio2(1))
            comandos.Parameters.AddWithValue("SERVICIO2", nservicio2(1))
            comandos.Parameters.AddWithValue("ADM2", CDbl(a2(1)))
            comandos.Parameters.AddWithValue("IMP2", CDbl(i2(1)))
            comandos.Parameters.AddWithValue("UTIL2", CDbl(u2(1)))
            comandos.Parameters.AddWithValue("CostoDirecto2", costod2(1))
            comandos.Parameters.AddWithValue("Administracion2", admin2(1))
            comandos.Parameters.AddWithValue("Imprevistos2", impre2(1))
            comandos.Parameters.AddWithValue("Utilidad2", util2(1))
            comandos.Parameters.AddWithValue("Subtotal2", subt2(1))
            comandos.Parameters.AddWithValue("IVA2", iva2(1))
            comandos.Parameters.AddWithValue("Vrtotal2", total2(1))
            comandos.Parameters.AddWithValue("Tiposervicio3", servicio2(2))
            comandos.Parameters.AddWithValue("SERVICIO3", nservicio2(2))
            comandos.Parameters.AddWithValue("ADM3", CDbl(a2(2)))
            comandos.Parameters.AddWithValue("IMP3", CDbl(i2(2)))
            comandos.Parameters.AddWithValue("UTIL3", CDbl(u2(2)))
            comandos.Parameters.AddWithValue("CostoDirecto3", costod2(2))
            comandos.Parameters.AddWithValue("Administracion3", admin2(2))
            comandos.Parameters.AddWithValue("Imprevistos3", impre2(2))
            comandos.Parameters.AddWithValue("Utilidad3", util2(2))
            comandos.Parameters.AddWithValue("Subtotal3", subt2(2))
            comandos.Parameters.AddWithValue("IVA3", iva2(2))
            comandos.Parameters.AddWithValue("Vrtotal3", total2(2))
            comandos.Parameters.AddWithValue("Tiposervicio4", servicio2(3))
            comandos.Parameters.AddWithValue("SERVICIO4", nservicio2(3))
            comandos.Parameters.AddWithValue("ADM4", CDbl(a2(3)))
            comandos.Parameters.AddWithValue("IMP4", CDbl(i2(3)))
            comandos.Parameters.AddWithValue("UTIL4", CDbl(u2(3)))
            comandos.Parameters.AddWithValue("CostoDirecto4", costod2(3))
            comandos.Parameters.AddWithValue("Administracion4", admin2(3))
            comandos.Parameters.AddWithValue("Imprevistos4", impre2(3))
            comandos.Parameters.AddWithValue("Utilidad4", util2(3))
            comandos.Parameters.AddWithValue("Subtotal4", subt2(3))
            comandos.Parameters.AddWithValue("IVA4", iva2(3))
            comandos.Parameters.AddWithValue("Vrtotal4", total2(3))
            comandos.Parameters.AddWithValue("estado", Estadoods.Text)
            comandos.Parameters.AddWithValue("FIRMA", getusername.Text)
            comandos.Parameters.AddWithValue("VALIDAU", chktext)
            comandos.Parameters.AddWithValue("descripccion", textdescripcion.Text)
            comandos.Parameters.AddWithValue("dias", txtdias.Text)
            comandos.Parameters.AddWithValue("planner", txtplanner.Text)
            comandos.Parameters.AddWithValue("valorcierre", vractual.Text)
            comandos.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub enviarmail()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = eadmin.Text + ";" + ecreado.Text + ";" + esoporte.Text + ";" + eplanner
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
    Private Sub cmbadmin1_TextChanged(sender As Object, e As System.EventArgs) Handles cmbadmin1.TextChanged
        eadmin.Text = cmbadmin1.Text & "@pacificrubiales.com.co"
    End Sub
    Private Sub doriginal_TextChanged(sender As System.Object, e As System.EventArgs) Handles doriginal.TextChanged
        alertas()
    End Sub
    Private Sub presupuestoejecutadov_TextChanged(sender As System.Object, e As System.EventArgs) Handles gastovigencia.TextChanged
        gastovigencia.Text = FormatNumber(CDbl(gastovigencia.Text), 2)
    End Sub

    Private Sub presupuestoaejecutarv_TextChanged(sender As System.Object, e As System.EventArgs) Handles saldovigencia.TextChanged
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
        REM  End If
    End Sub
    Private Sub txtequipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtequipo.TextChanged
        REM txtplanner.Enabled = True
    End Sub
    Private Sub txtplanner_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtplanner.SelectedIndexChanged
        grpcantidades.Enabled = True
    End Sub

    Private Sub cmbcontrato1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbcontrato1.SelectedIndexChanged

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
        If txtarea.Text = "03. CR CLÚSTERES" Then
            grpcantidades.Enabled = False
            txtequipo.Enabled = True
        Else
            txtplanner.Enabled = True
        End If
        If txtarea.Text = "04. CR TRONCALES" Then
            grpcantidades.Enabled = False
            txtequipo.Enabled = True
        Else
            txtplanner.Enabled = True
        End If
        If txtarea.Text = "05. CR LÍNEAS DE FLUJO" Then
            grpcantidades.Enabled = False
            txtequipo.Enabled = True
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "07. CR PADs" Then
            grpcantidades.Enabled = False
            txtequipo.Enabled = True
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "08. CR LINEAS DE TRANSFERENICA DE AGUA" Then
            grpcantidades.Enabled = False
            txtequipo.Enabled = True
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "09. GENERACIÓN LOCAL" Then
            grpcantidades.Enabled = False
            txtequipo.Enabled = True
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "03. CQ CLÚSTERES" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else
            txtplanner.Enabled = True
        End If
        If txtarea.Text = "04. CQ TRONCALES" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "05. CQ LÍNEAS DE FLUJO" Then
            grpcantidades.Enabled = False
            txtequipo.Enabled = True
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "06. CQ RED ELECTRICA" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "07. CQ PADs" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "08. CQ LINEAS DE TRANSFERENICA DE AGUA" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "09. CQ GENERACIÓN LOCAL" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "01. STAR" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "01. CAJUA" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else

            txtplanner.Enabled = True
        End If
        If txtarea.Text = "01. CPE-6" Then
            txtequipo.Enabled = True
            grpcantidades.Enabled = False
        Else
            txtplanner.Enabled = True
        End If
        REM   txtplanner.Enabled = True
    End Sub

    Private Sub avancedinerovigencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles avancedinerovigencia.TextChanged

    End Sub

    Private Sub anovigencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles anovigencia.TextChanged
        vigencia()
    End Sub

    Private Sub grpinfoods_Enter(sender As System.Object, e As System.EventArgs) Handles grpinfoods.Enter

    End Sub

    Private Sub txtprograma_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtprograma.TextChanged

    End Sub
End Class