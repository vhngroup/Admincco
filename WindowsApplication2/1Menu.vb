Option Explicit On
Imports System.DirectoryServices
Imports System.Data.OleDb
Imports System.Text
Imports System.Runtime.InteropServices
Imports IWshRuntimeLibrary
Imports System.Data.Sql
Imports System.ComponentModel
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Data.SqlClient
REM GRANT Execute ON [dbo].odsmodificadinero TO [PRE\adminco_users]

Public Class frmmenu
    Event ListChanged As ListChangedEventHandler
    Dim op As String
    Public retorno As String = 0
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim adaptador As New OleDbDataAdapter
    Dim lector As OleDbDataReader
    Dim hoy As Date
    Private Sub frmmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Seguridad4' Puede moverla o quitarla según sea necesario.
        Me.Seguridad4TableAdapter.Fill(Me.Adminco_MasterDataSet.Seguridad4)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.estados' Puede moverla o quitarla según sea necesario.
        Me.EstadosTableAdapter.Fill(Me.Adminco_MasterDataSet.estados)
        Try
            'TODO: esta línea de código carga datos en la tabla 'Stadistic_AdminccoDataSet.Personas' Puede moverla o quitarla según sea necesario.
            Me.PersonasTableAdapter1.Fill(Me.Stadistic_AdminccoDataSet.Personas)
            If My.Computer.Network.IsAvailable() = True Then
                Try
                    If My.Computer.Network.Ping("10.204.1.100", 1000) Then
                        Me.Seguridad2TableAdapter1.Fill(Me.Adminco_MasterDataSet.Seguridad2)
                        Dim classResize As New clsResizeForm
                        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-Es")
                        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
                        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "," '.
                        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "." ',
                        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "," '.
                        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "." ',
                        If cmbadmin.Text <> "" Then
                            hoy = Now
                            fecha.Text = hoy
                            si()
                        Else
                            MsgBox("DB Error, si su red no es ( WL SOE PRE ) por favor conecte VPN ", MsgBoxStyle.Critical, "Error")
                            Application.Exit()
                        End If

                    Else
                        MsgBox("DB Error, si su red no es ( WL SOE PRE ) por favor conecte VPN ", MsgBoxStyle.Critical, "Error")
                        Application.Exit()
                    End If
                Catch ex As PingException
                    MsgBox("DB Error, si su red no es ( WL SOE PRE ) por favor conecte VPN 1", MsgBoxStyle.Critical, "Error")
                    Application.Exit()
                End Try
            Else
                MsgBox("No esta conectado a ninguna red", MsgBoxStyle.Critical, "Error")
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox("No esta conectado a ninguna red", MsgBoxStyle.Critical, "Error")
            Application.Exit()
        End Try

    End Sub
    Private Sub si()
        cmbadmin.Focus()
        If My.Settings.Usuario <> "" Then
            cmbadmin.Text = My.Settings.Usuario
            chkrecord.Checked = True
        End If
        If My.Settings.Contrasena <> "" Then
            txtpassword.Text = My.Settings.Contrasena
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcrregistro.Click
        frmformulario.ShowDialog()
        frmformulario.Dispose()
    End Sub
    Friend Sub btingresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btingresar.Click
        If txtpassword.Text = "" Then
            MsgBox("Por favor digite contraseña")
        Else
            If ValidateActiveDirectoryLogin("10.204.1.100", cmbadmin.Text.Trim, txtpassword.Text) Then
                comprobar()
                Me.BindingSource6.Filter = "Fecha ='" & fecha.Text & "'"
            Else

                MsgBox("Error de contraseña, por favor verificarla", vbInformation, "Error")
                txtpassword.Text = ""
            End If
        End If
    End Sub
    Private Function ValidateActiveDirectoryLogin(ByVal Domain As String, ByVal Username As String, ByVal Password As String) As Boolean
        Dim Success As Boolean = False
        Dim Entry As New System.DirectoryServices.DirectoryEntry("LDAP://" & Domain, Username, Password)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.OneLevel
        Try
            Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
            Success = Not (Results Is Nothing)
        Catch
            Success = False
        End Try
        Return Success
    End Function
    Private Sub comprobar()
        If chkrecord.Checked = True Then
            My.Settings.Usuario = cmbadmin.Text
            My.Settings.Contrasena = txtpassword.Text
            My.Settings.Save()
        End If
        My.Settings.usuario2 = cmbadmin.Text
        My.Settings.Save()
        grplogin.Visible = False
        grplogin.Enabled = False
        grpadmin.Visible = True
        grpuser.Visible = True
        If lblroll.Text = "Spadmin" Then 'ok
            op = 1
            validator()
        End If
        If lblroll.Text = "Administrador" Then 'ok
            op = 3
            validator()
        End If
        If lblroll.Text = "Solicitante" Then 'ok
            op = 2
            validator()
        End If
        If lblroll.Text = "Spfinanzas" Then 'ok
            op = 5
            validator()
        End If
        If lblroll.Text = "Consultor" Then
            op = 6
            validator()
        End If
        If lblroll.Text = "Admin" Then 'ok
            op = 1
            herramientas.Enabled = True
            validator()
        End If

    End Sub
    Private Sub validator()
        Select Case op
            Case 1 'nivel admin
                grpadmin.Visible = True
                grpadmin.Enabled = True
                grpuser.Visible = True
                grpuser.Enabled = True
                gpreports.Visible = True
                gpreports.Enabled = True
                btncierreods.Enabled = True
                btncierrecont.Enabled = True
                Button3.Enabled = True
            Case 2 'nivel Solicitante
                grpadmin.Visible = False
                grpuser.Visible = True
                grpuser.Enabled = True
                btnautorizacion.Enabled = True
                gpreports.Visible = True
                gpreports.Enabled = True
                btncierrecont.Enabled = False
                btncierreods.Enabled = True
                Button3.Enabled = True
            Case 3 'nivel Administrador
                grpadmin.Visible = True
                grpadmin.Enabled = True
                grpuser.Visible = True
                grpuser.Enabled = True
                btcrregistro.Visible = True
                btcrregistro.Enabled = False
                PictureBox2.Visible = True
                btcactualizar.Enabled = False
                PictureBox4.Visible = True
                btnmodifcont.Enabled = True
                gpreports.Visible = True
                gpreports.Enabled = True
                btncierrecont.Enabled = True
                Button3.Enabled = True
            Case 4
                grpadmin.Visible = True
                grpadmin.Enabled = True
                grpuser.Visible = True
                grpuser.Enabled = True
                gpreports.Visible = True
                gpreports.Enabled = True
                btcactualizar.Enabled = True
                btnautorizacion.Enabled = False
                btncierreods.Enabled = True
            Case 5
                grpadmin.Visible = True
                grpadmin.Enabled = True
                grpuser.Visible = False
                btnautorizacion.Enabled = False
                btcactualizar.Enabled = False
                btcrregistro.Enabled = False
                gpreports.Visible = True
                gpreports.Enabled = True
            Case 6
                grpadmin.Visible = False
                grpuser.Visible = False
                gpreports.Visible = True
                gpreports.Enabled = True
            Case Else
                grpadmin.Visible = False
                grpuser.Visible = False
                gpreports.Visible = False
                gpreports.Enabled = False
        End Select
    End Sub
    Private Sub btingresar_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btingresar.MouseHover
        btingresar.ForeColor = Color.Red
    End Sub
    Private Sub btingresar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btingresar.MouseLeave
        btingresar.ForeColor = Color.Black
    End Sub
    Private Sub btsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conexion.Close()
        Me.Close()
        Application.Exit()
    End Sub
    Private Sub txtpassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            btingresar.PerformClick()
        End If
    End Sub
    Private Sub cmbadmin_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbadmin.SelectedIndexChanged
        txtpassword.Text = ""
        chkrecord.Checked = False
    End Sub
    Private Sub btnmodifcont_Click(sender As System.Object, e As System.EventArgs) Handles btnmodifcont.Click
        frmaprobarcontrato.ShowDialog()
        frmaprobarcontrato.Dispose()
    End Sub
    Private Sub btcactualizar_Click(sender As System.Object, e As System.EventArgs) Handles btcactualizar.Click
        frmactualizarods.ShowDialog()
        frmactualizarods.Dispose()
    End Sub
    Private Sub btninformes_Click(sender As System.Object, e As System.EventArgs) Handles btninformes.Click
        frmreportes1.ShowDialog()
        frmreportes1.Dispose()
    End Sub
    Private Sub btnautorizacion_Click(sender As System.Object, e As System.EventArgs) Handles btnautorizacion.Click
        REM MsgBox("Modulo bloqueado por: User VNOGUERA")
        fmrmodificarods.ShowDialog()
        fmrmodificarods.Dispose()
    End Sub
    Public Class Centered_Msgbox
        Implements IDisposable
        Private mTries As Integer = 0
        Private mOwner As Form

        Public Sub New(ByVal owner As Form)
            mOwner = owner
            owner.BeginInvoke(New MethodInvoker(AddressOf findDialog))
        End Sub
        Private Sub findDialog()
            ' Enumerate windows to find the message box
            If mTries < 0 Then
                Return
            End If
            Dim callback As New EnumThreadWndProc(AddressOf checkWindow)
            If EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero) Then
                If System.Threading.Interlocked.Increment(mTries) < 10 Then
                    mOwner.BeginInvoke(New MethodInvoker(AddressOf findDialog))
                End If
            End If
        End Sub
        Private Function checkWindow(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
            ' Checks if <hWnd> is a dialog
            Dim sb As New StringBuilder(260)
            GetClassName(hWnd, sb, sb.Capacity)
            If sb.ToString() <> "#32770" Then
                Return True
            End If
            ' Got it
            Dim frmRect As New Rectangle(mOwner.Location, mOwner.Size)
            Dim dlgRect As RECT
            GetWindowRect(hWnd, dlgRect)
            MoveWindow(hWnd, frmRect.Left + (frmRect.Width - dlgRect.Right + dlgRect.Left) \ 2, frmRect.Top + (frmRect.Height - dlgRect.Bottom + dlgRect.Top) \ 2, dlgRect.Right - dlgRect.Left, dlgRect.Bottom - dlgRect.Top, True)
            Return False
        End Function
        Public Sub Dispose() Implements IDisposable.Dispose
            mTries = -1
        End Sub
        ' P/Invoke declarations
        Private Delegate Function EnumThreadWndProc(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
        <DllImport("user32.dll")> _
        Private Shared Function EnumThreadWindows(ByVal tid As Integer, ByVal callback As EnumThreadWndProc, ByVal lp As IntPtr) As Boolean
        End Function
        <DllImport("kernel32.dll")> _
        Private Shared Function GetCurrentThreadId() As Integer
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function GetClassName(ByVal hWnd As IntPtr, ByVal buffer As StringBuilder, ByVal buflen As Integer) As Integer
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef rc As RECT) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal repaint As Boolean) As Boolean
        End Function
        Private Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure
    End Class

    Private Sub PictureBox10_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox10.Click
        AboutBox1.ShowDialog()
        AboutBox1.Dispose()
    End Sub

    Private Sub btncierreods_Click(sender As System.Object, e As System.EventArgs) Handles btncierreods.Click
        REM MsgBox("Modulo bloqueado por: User VNOGUERA")
        rcierreods.ShowDialog()
        rcierreods.Dispose()
    End Sub
    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs)
        Form3.ShowDialog()
        Form3.Dispose()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        REM Form11.ShowDialog()
        REM Form11.Dispose()
        MsgBox("Modulo bloqueado por: User VNOGUERA")
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles herramientas.Click
        conexion.Close()
        Form7.ShowDialog()
        Form7.Dispose()
    End Sub
    Private Sub btncierrecont_Click(sender As Object, e As EventArgs) Handles btncierrecont.Click
        MsgBox("Modulo bloqueado por: User VNOGUERA")
    End Sub
    Friend Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
    Protected Friend Sub cerrar()
        Dim conexioncontador = ADONETUtil.cn2
        Dim comandoscontador As New SqlCommand
        If grplogin.Visible = False Then
            If conexioncontador.State = ConnectionState.Open Then
            Else
                conexioncontador.Open()
            End If
            Try
                Dim str2 As String
                If Contador.Text <> "" Then
                    Contador.Text = Contador.Text + 1
                    str2 = "Update  Personas SET Contar = '" & Contador.Text & "', nombre = '" & My.Settings.usuario2 & "' Where Fecha = '" & fecha.Text & "'"
                    comandoscontador = New SqlCommand(str2, conexioncontador)
                Else
                    Contador.Text = 1
                    comandoscontador.CommandText = "INSERT INTO Personas (Fecha, Contar, nombre) VALUES (@Fecha, @Contar, @nombre)"
                    comandoscontador.CommandType = CommandType.Text
                    comandoscontador.Connection = conexioncontador
                    comandoscontador.Parameters.AddWithValue("@Fecha", fecha.Text)
                    comandoscontador.Parameters.AddWithValue("@Contar", Contador.Text)
                    comandoscontador.Parameters.AddWithValue("@nombre", My.Settings.usuario2)
                End If
                comandoscontador.ExecuteNonQuery()
                conexion.Close()
                conexioncontador.Close()
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod1-fun-02:" & "_" & ex.Message)
            End Try
        End If
    End Sub
    Private Sub frmmenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If My.Computer.Network.IsAvailable() = True Then
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
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        frmcontratos.ShowDialog()
        frmcontratos.Dispose()
    End Sub
 Private Sub Label4_TextChanged(sender As Object, e As EventArgs) Handles Label4.TextChanged
        cmbadmin.Enabled = True
        lblroll.Enabled = True
        txtpassword.Enabled = True
        btingresar.Enabled = True
        chkrecord.Enabled = True
    End Sub

  
    Private Sub Label7_TextChanged(sender As Object, e As EventArgs) Handles Label7.TextChanged
        If Label7.Text = "Unlock" Then
            GroupBox1.Visible = False
            grplogin.Visible = True
        Else
            GroupBox1.Visible = True
            grplogin.Visible = False
        End If
    End Sub
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        conexion.Close()
        Form7.ShowDialog()
        Form7.Dispose()
    End Sub
End Class
Public Class clsResizeForm
    Dim f_HeightRatio As Single = New Single
    Dim f_WidthRatio As Single = New Single
    Public Sub ResizeForm(ObjForm As Form, DesignerWidth As Integer, DesignerHeight As Integer)
        Dim i_StandardHeight As Integer = DesignerHeight
        Dim i_StandardWidth As Integer = DesignerWidth
        Dim i_PresentHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim i_PresentWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        f_HeightRatio = (CSng(i_PresentHeight) / CSng(i_StandardHeight))
        f_WidthRatio = (CSng(i_PresentWidth) / CSng(i_StandardWidth))
        ObjForm.AutoScaleMode = AutoScaleMode.None
        ObjForm.Scale(New SizeF(f_WidthRatio, f_HeightRatio))
        For Each c As Control In ObjForm.Controls
            If c.HasChildren Then
                ResizeControlStore(c)
            Else
                c.Font = New Font(c.Font.FontFamily, c.Font.Size * f_HeightRatio, c.Font.Style, c.Font.Unit, (CByte(0)))
            End If
        Next
        ObjForm.Font = New Font(ObjForm.Font.FontFamily, ObjForm.Font.Size * f_HeightRatio, ObjForm.Font.Style, ObjForm.Font.Unit, (CByte(0)))
    End Sub
    Private Sub ResizeControlStore(objCtl As Control)
        If objCtl.HasChildren Then
            For Each cChildren As Control In objCtl.Controls
                If cChildren.HasChildren Then
                    ResizeControlStore(cChildren)
                Else
                    cChildren.Font = New Font(cChildren.Font.FontFamily, cChildren.Font.Size * f_HeightRatio, cChildren.Font.Style, cChildren.Font.Unit, (CByte(0)))
                End If
            Next
            objCtl.Font = New Font(objCtl.Font.FontFamily, objCtl.Font.Size * f_HeightRatio, objCtl.Font.Style, objCtl.Font.Unit, (CByte(0)))
        Else
            objCtl.Font = New Font(objCtl.Font.FontFamily, objCtl.Font.Size * f_HeightRatio, objCtl.Font.Style, objCtl.Font.Unit, (CByte(0)))
        End If
    End Sub

End Class






