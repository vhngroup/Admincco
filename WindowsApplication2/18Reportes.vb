Public Class frmreportes1
    Public numero As Integer = 0
    Public Sub frmreportes1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Panner' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Disciplina' Puede moverla o quitarla según sea necesario.
        Me.CMOriginalesTableAdapter.Fill(Me.Adminco_MasterDataSet.CMOriginales)
        Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
        Me.CierreODSTableAdapter.Fill(Me.Adminco_MasterDataSet.CierreODS)
        Label3.Enabled = False
        ComboBox1.Enabled = False
        Button8.Enabled = False
        Label4.Enabled = False
        ComboBox2.Enabled = False
        Button7.Enabled = False
        Label5.Enabled = False
        ComboBox3.Enabled = False
        Button9.Enabled = False
        REM Label6.Enabled = False
        REM ComboBox4.Enabled = False
        Button11.Enabled = False
        Label7.Enabled = False
        ComboBox5.Enabled = False
        Button12.Enabled = False
        GroupBox2.Enabled = False
        If ComboBox1.SelectedIndex >= 0 Then ComboBox1.SelectedIndex = 0
        If ComboBox2.SelectedIndex >= 0 Then ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        If ComboBox4.SelectedIndex >= 0 Then ComboBox4.SelectedIndex = 0
        ComboBox5.SelectedIndex = 0
        ComboBox6.SelectedIndex = 0
        If ComboBox7.SelectedIndex >= 0 Then ComboBox7.SelectedIndex = 0
        REM rem frmmenu.hide()
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Salir.Click
        ocultar()
        Me.Close()
        frmmenu.Show()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ocultar()
        Label3.Enabled = True
        ComboBox1.Enabled = True
        Button8.Enabled = True
        GroupBox2.Enabled = True
    End Sub
    Private Sub cmmarcos()
        Dim mireporte As frmReportes
        mireporte = New frmReportes
        mireporte.Modelo = ComboBox1.Text
        mireporte.Show()
    End Sub
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        ocultar()
        GroupBox2.Enabled = True
        Label5.Enabled = True
        ComboBox3.Enabled = True
        Button9.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ocultar()
        GroupBox2.Enabled = True
        Label4.Enabled = True
        ComboBox2.Enabled = True
        Button7.Enabled = True
        TextBox1.Enabled = True
        Button19.Enabled = True
    End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        ocultar()
        GroupBox2.Enabled = True
        Label2.Enabled = True
        ComboBox6.Enabled = True
        Button14.Enabled = True
        REM resumenods.Show()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Enabled = True Then
            Dim mireporte As frmReportes
            mireporte = New frmReportes
            Button8.Enabled = False
            numero = 1
            mireporte.Modelo = ComboBox1.Text
            mireporte.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim mireporte As frmreportemarcos
        mireporte = New frmreportemarcos
        mireporte.Show()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Enabled = True Then
            Dim mireporte As frmfiltroods
            mireporte = New frmfiltroods
            numero = 1
            mireporte.Modelo = ComboBox3.Text
            mireporte.Show()
        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Dim mireporte As ods
        mireporte = New ods
        TextBox1.Enabled = False
        Button19.Enabled = False
        numero = 2
        mireporte.Modelo1 = ComboBox2.Text
        mireporte.Show()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        ComboBox1.Enabled = False
        numero = 0
        Dim mireporte As frmReportes
        mireporte = New frmReportes
        mireporte.Show()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        numero = 0
        Dim mireporte As frmfiltroods
        mireporte = New frmfiltroods
        mireporte.Show()
    End Sub
    Private Sub Button5_Click_2(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        ocultar()
        REM  Label6.Enabled = True
        REM ComboBox4.Enabled = True
        Button11.Enabled = True
        GroupBox2.Enabled = True
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        ocultar()
        mostrar()
    End Sub
    Private Sub ocultar()
        Label3.Enabled = False
        ComboBox1.Enabled = False
        Button8.Enabled = False
        Label4.Enabled = False
        ComboBox2.Enabled = False
        Button7.Enabled = False
        Label5.Enabled = False
        ComboBox3.Enabled = False
        Button9.Enabled = False
        REM   Label6.Enabled = False
        REM   ComboBox4.Enabled = False
        Button11.Enabled = False
        Label7.Enabled = False
        ComboBox5.Enabled = False
        Button12.Enabled = False
        GroupBox2.Enabled = False
        GroupBox1.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button6.Enabled = False
        Button5.Enabled = False
        Button10.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Label2.Enabled = False
        ComboBox6.Enabled = False
        Button14.Enabled = False
        ComboBox7.Enabled = False
        Button16.Enabled = False
        Button15.Enabled = False
        Label9.Enabled = False
        ComboBox4.Enabled = False
        Button18.Enabled = False
        Button24.Enabled = False
        Button26.Enabled = False
        ComboBox8.Enabled = False
        TextBox1.Enabled = False
        Button19.Enabled = False
        TextBox2.Enabled = False
        Button20.Enabled = False
    End Sub
    Private Sub mostrar()
        GroupBox1.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = True
        Button6.Enabled = True
        Button5.Enabled = True
        Button10.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button15.Enabled = True
        Button24.Enabled = True
        TextBox1.Enabled = True
        Button19.Enabled = True
        TextBox2.Enabled = True
        Button20.Enabled = True
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        ocultar()
        Label7.Enabled = True
        ComboBox5.Enabled = True
        Button12.Enabled = True
        GroupBox2.Enabled = True
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        REM If ComboBox4.Enabled = True Then
        REM Dim mireporte As reporteporadministrador
        REM  mireporte = New reporteporadministrador
        REM  numero = 1
        REM  mireporte.Modelo = ComboBox4.Text
        REM  mireporte.Show()
        REM  End If
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Dim mireporte As Resolution
        mireporte = New Resolution
        numero = 0
        mireporte.Show()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        If ComboBox5.Enabled = True Then
            Dim mireporte As Form1
            mireporte = New Form1
            numero = 1
            mireporte.Modelo = ComboBox5.Text
            mireporte.Show()
        End If
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Dim mireporte As Form1
        mireporte = New Form1
        numero = 0
        mireporte.Show()
    End Sub
    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        Dim mireporte As odsactivas
        mireporte = New odsactivas
        numero = 0
        mireporte.Show()
    End Sub
    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        ocultar()
        Label9.Enabled = True
        ComboBox7.Enabled = True
        Button16.Enabled = True
        GroupBox2.Enabled = True
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        If ComboBox7.Enabled = True Then
            Dim mireporte As restadoactualcm
            mireporte = New restadoactualcm
            Button8.Enabled = False
            numero = 1
            mireporte.Modelo = ComboBox7.Text
            mireporte.Show()
        End If
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        ComboBox7.Enabled = False
        numero = 0
        Dim mireporte As restadoactualcm
        mireporte = New restadoactualcm
        mireporte.Show()
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        ocultar()
        ComboBox4.Enabled = True
        Button18.Enabled = True
        GroupBox2.Enabled = True
        TextBox2.Enabled = True
        Button20.Enabled = True
    End Sub
    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        ComboBox4.Enabled = False
        numero = 2
        Dim mireporte As Form2
        mireporte = New Form2
        mireporte.Modelo1 = ComboBox4.Text
        mireporte.Show()
        ocultar()
    End Sub

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        ComboBox8.Enabled = False
        numero = 0
        rodsporcontrato.Show()
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        ComboBox8.Enabled = True
        Button26.Enabled = True
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        If ComboBox8.Enabled = True Then
            numero = 1
            Dim mireporte As rodsporcontrato
            mireporte = New rodsporcontrato
            mireporte.Modelo = ComboBox8.Text
            mireporte.Show()
        End If
    End Sub

    Friend Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ComboBox2.Enabled = True Then
                    Dim mireporte As ods
                    mireporte = New ods
                    numero = 1
                    mireporte.Modelo1 = ComboBox2.Text & "-" & TextBox1.Text
                    mireporte.Show()
                End If
        End Select
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Select e.KeyData
            Case Keys.Enter
                If ComboBox4.Enabled = True Then
                    Dim mireporte As Form2
                    mireporte = New Form2
                    Button18.Enabled = False
                    numero = 1
                    mireporte.Modelo1 = ComboBox4.Text & "-" & TextBox2.Text
                    mireporte.Show()
                End If
        End Select
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6.Enabled = True Then
            Dim mireporte As odsactivas
            mireporte = New odsactivas
            Button14.Enabled = False
            numero = 1
            mireporte.Modelo = ComboBox6.Text & "-" & TextBox2.Text
            mireporte.Show()
        End If
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If ComboBox2.Enabled = True Then
            Dim mireporte As ods
            mireporte = New ods
            numero = 1
            mireporte.Modelo1 = ComboBox2.Text & "-" & TextBox1.Text
            mireporte.Show()
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If ComboBox4.Enabled = True Then
            Dim mireporte As Form2
            mireporte = New Form2
            Button18.Enabled = False
            numero = 1
            mireporte.Modelo1 = ComboBox4.Text & "-" & TextBox2.Text
            mireporte.Show()
        End If
    End Sub
End Class