Imports System.Text.RegularExpressions
Imports System.Windows.Forms.ErrorProvider
Public Class form6
    Public Property ValidateEmptyText As Boolean
    Public valornet As Double ' traer el valor del contrato
    Public impservicio1 As String 'trae el nombre del servicio
    Public imptext1 As Double 'trae el codigo del servicio
    Public ident As Double 'ubica de donde se realizo el click
    Private Sub frmservicios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        txtvalorcontcart.Text = valornet
    End Sub
    Private Sub ComboBox7_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles numberservice.SelectedIndexChanged
        servicios()
    End Sub
    Private Sub servicios()
        grbservicios.Enabled = True
        Select Case numberservice.Text
            Case 1
                nivel1.Enabled = True
                nivel2.Enabled = False
                nivel3.Enabled = False
                nivel4.Enabled = False
                nivel5.Enabled = False
                nivel6.Enabled = False
                nivel7.Enabled = False
                nivel8.Enabled = False
            Case 2
                nivel1.Enabled = True
                nivel2.Enabled = True
                nivel3.Enabled = False
                nivel4.Enabled = False
                nivel5.Enabled = False
                nivel6.Enabled = False
                nivel7.Enabled = False
                nivel8.Enabled = False
            Case 3
                nivel1.Enabled = True
                nivel2.Enabled = True
                nivel3.Enabled = True
                nivel4.Enabled = False
                nivel5.Enabled = False
                nivel6.Enabled = False
                nivel7.Enabled = False
                nivel8.Enabled = False
            Case 4
                nivel1.Enabled = True
                nivel2.Enabled = True
                nivel3.Enabled = True
                nivel4.Enabled = True
                nivel5.Enabled = False
                nivel6.Enabled = False
                nivel7.Enabled = False
                nivel8.Enabled = False
            Case 5
                nivel1.Enabled = True
                nivel2.Enabled = True
                nivel3.Enabled = True
                nivel4.Enabled = True
                nivel5.Enabled = True
                nivel6.Enabled = False
                nivel7.Enabled = False
                nivel8.Enabled = False
            Case 6
                nivel1.Enabled = True
                nivel2.Enabled = True
                nivel3.Enabled = True
                nivel4.Enabled = True
                nivel5.Enabled = True
                nivel6.Enabled = True
                nivel7.Enabled = False
                nivel8.Enabled = False
            Case 7
                nivel1.Enabled = True
                nivel2.Enabled = True
                nivel3.Enabled = True
                nivel4.Enabled = True
                nivel5.Enabled = True
                nivel6.Enabled = True
                nivel7.Enabled = True
                nivel8.Enabled = False
            Case 8
                nivel1.Enabled = True
                nivel2.Enabled = True
                nivel3.Enabled = True
                nivel4.Enabled = True
                nivel5.Enabled = True
                nivel6.Enabled = True
                nivel7.Enabled = True
                nivel8.Enabled = True
        End Select
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnaceptar.Click
        guardar()
        frmformulario.modo = 4
        frmformulario.nuevoproceso()
        Me.Close()
    End Sub
    Friend Sub importacion()
        If ident = 1 Then
            nservicio1.Text = impservicio1
        End If
        If ident = 2 Then
            nservicio2.Text = impservicio1
        End If
        If ident = 3 Then
            nservicio3.Text = impservicio1
        End If
        If ident = 4 Then
            nservicio4.Text = impservicio1
        End If
        If ident = 5 Then
            nservicio5.Text = impservicio1
        End If
        If ident = 6 Then
            nservicio6.Text = impservicio1
        End If
        If ident = 7 Then
            nservicio7.Text = impservicio1
        End If
        If ident = 8 Then
            nservicio8.Text = impservicio1
        End If
    End Sub
    Private Sub calculo1()

        If servicio1.Text = "" Then servicio1.Text = 0 ' Verifica que no este vacio

        If servicio1.Text = 1 Then ' Verifica el tipo de servicio, 1 2 o 3
            a1.Enabled = True
            i1.Enabled = True
            u1.Enabled = True
            If a1.Text <> "" Then ' Administracion 
                If a1.Text = 0 Then
                    Admin1.Text = 0
                Else
                    Admin1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(a1.Text) / 100)
                End If
            Else
                a1.Text = 0
                Admin1.Text = 0
            End If

            If i1.Text <> "" Then ' Imprevistos
                If i1.Text = 0 Then
                    impre1.Text = 0
                Else

                    impre1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(i1.Text) / 100)
                End If
            Else
                i1.Text = 0
                impre1.Text = 0
            End If

            If u1.Text <> "" Then ' Utilidad
                If u1.Text = 0 Then
                    util1.Text = 0
                Else
                    util1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(u1.Text) / 100)
                End If
            Else
                u1.Text = 0
                util1.Text = 0
            End If

            subt1.Text = FormatNumber(CDbl(costod1.Text) + CDbl(Admin1.Text) + CDbl(impre1.Text) + CDbl(util1.Text))
            iva1.Text = FormatNumber(CDbl(util1.Text) * 0.16) ' Multiplica la utilidad x el 16%
            total1.Text = FormatNumber(CDbl(iva1.Text) + CDbl(subt1.Text)) ' suma el iva + el subtotal
        End If

        If servicio1.Text = 2 Then ' Caso 2
            a1.Enabled = True
            u1.Enabled = False ' Desabilita Utilidad
            i1.Enabled = False
            u1.Enabled = False ' Desabilita Utilidad
            u1.Text = 0
            i1.Text = 0
            util1.Text = 0
            impre1.Text = 0
            If a1.Text <> "" Then ' Administracion 
                If a1.Text = 0 Then
                    Admin1.Text = 0
                Else
                    Admin1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(a1.Text) / 100)
                End If

            Else
                a1.Text = 0
                Admin1.Text = 0
            End If
            subt1.Text = FormatNumber(CDbl(costod1.Text) + CDbl(Admin1.Text) + CDbl(util1.Text))
            iva1.Text = FormatNumber(CDbl(Admin1.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 16%
            total1.Text = FormatNumber(CDbl(iva1.Text) + CDbl(subt1.Text))
        End If

        If servicio1.Text = 3 Then 'Opcion 3
            i1.Enabled = False
            u1.Enabled = False ' Desabilita Utilidad
            a1.Enabled = False
            u1.Text = 0
            i1.Text = 0
            util1.Text = 0
            impre1.Text = 0
            Admin1.Text = 0
            subt1.Text = FormatNumber(CDbl(costod1.Text))
            iva1.Text = FormatNumber(CDbl(subt1.Text) * 0.16)
            total1.Text = FormatNumber(CDbl(iva1.Text) + CDbl(subt1.Text))
        End If

        If servicio1.Text = 0 Then
            nservicio1.Text = "Seleccione Opcion"
            costod1.Text = 0
            a1.Text = 0
            i1.Text = 0
            u1.Text = 0
            Admin1.Text = 0
            impre1.Text = 0
            util1.Text = 0
            subt1.Text = 0
            iva1.Text = 0
            total1.Text = 0
            REM nivel1.Enabled = False
        End If
    End Sub
    Private Sub calculo2()

        If servicio2.Text = "" Then servicio2.Text = 0 ' Verifica que no este vacio

        If servicio2.Text = 1 Then ' Verifica el tipo de servicio, 2 2 o 3
            a2.Enabled = True
            i2.Enabled = True
            u2.Enabled = True
            If a2.Text <> "" Then ' Administracion 
                If a2.Text = 0 Then
                    admin2.Text = 0
                Else
                    admin2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(a2.Text) / 100)
                End If
            Else
                a2.Text = 0
                admin2.Text = 0
            End If

            If i2.Text <> "" Then ' Imprevistos
                If i2.Text = 0 Then
                    impre2.Text = 0
                Else

                    impre2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(i2.Text) / 100)
                End If
            Else
                i2.Text = 0
                impre2.Text = 0
            End If

            If u2.Text <> "" Then ' Utilidad
                If u2.Text = 0 Then
                    util2.Text = 0
                Else
                    util2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(u2.Text) / 100)
                End If
            Else
                u2.Text = 0
                util2.Text = 0
            End If

            subt2.Text = FormatNumber(CDbl(costod2.Text) + CDbl(admin2.Text) + CDbl(impre2.Text) + CDbl(util2.Text))
            iva2.Text = FormatNumber(CDbl(util2.Text) * 0.16) ' Multiplica la utilidad x el 26%
            total2.Text = FormatNumber(CDbl(iva2.Text) + CDbl(subt2.Text)) ' suma el iva + el subtotal
        End If

        If servicio2.Text = 2 Then ' Caso 2
            a2.Enabled = True
            u2.Enabled = False ' Desabilita Utilidad
            i2.Enabled = False
            u2.Enabled = False ' Desabilita Utilidad
            u2.Text = 0
            i2.Text = 0
            util2.Text = 0
            impre2.Text = 0
            If a2.Text <> "" Then ' Administracion 
                If a2.Text = 0 Then
                    Admin2.Text = 0
                Else
                    Admin2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(a2.Text) / 100)
                End If

            Else
                a2.Text = 0
                Admin2.Text = 0
            End If
            subt2.Text = FormatNumber(CDbl(costod2.Text) + CDbl(Admin2.Text) + CDbl(util2.Text))
            iva2.Text = FormatNumber(CDbl(admin2.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 26%
            total2.Text = FormatNumber(CDbl(iva2.Text) + CDbl(subt2.Text))
        End If

        If servicio2.Text = 3 Then 'Opcion 3
            i2.Enabled = False
            u2.Enabled = False ' Desabilita Utilidad
            a2.Enabled = False
            u2.Text = 0
            i2.Text = 0
            util2.Text = 0
            impre2.Text = 0
            Admin2.Text = 0
            subt2.Text = FormatNumber(CDbl(costod2.Text))
            iva2.Text = FormatNumber(CDbl(subt2.Text) * 0.16)
            total2.Text = FormatNumber(CDbl(iva2.Text) + CDbl(subt2.Text))
        End If

        If servicio2.Text = 0 Then
            nservicio2.Text = "Seleccione Opcion"
            costod2.Text = 0
            a2.Text = 0
            i2.Text = 0
            u2.Text = 0
            admin2.Text = 0
            impre2.Text = 0
            util2.Text = 0
            subt2.Text = 0
            iva2.Text = 0
            total2.Text = 0
            REM  nivel2.Enabled = False
        End If
    End Sub

    Private Sub calculo3()

        If servicio3.Text = "" Then servicio3.Text = 0 ' Verifica que no este vacio

        If servicio3.Text = 1 Then ' Verifica el tipo de servicio, 3 3 o 3
            a3.Enabled = True
            i3.Enabled = True
            u3.Enabled = True
            If a3.Text <> "" Then ' Administracion 
                If a3.Text = 0 Then
                    admin3.Text = 0
                Else
                    admin3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(a3.Text) / 100)
                End If
            Else
                a3.Text = 0
                admin3.Text = 0
            End If

            If i3.Text <> "" Then ' Imprevistos
                If i3.Text = 0 Then
                    impre3.Text = 0
                Else

                    impre3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(i3.Text) / 100)
                End If
            Else
                i3.Text = 0
                impre3.Text = 0
            End If

            If u3.Text <> "" Then ' Utilidad
                If u3.Text = 0 Then
                    util3.Text = 0
                Else
                    util3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(u3.Text) / 100)
                End If
            Else
                u3.Text = 0
                util3.Text = 0
            End If

            subt3.Text = FormatNumber(CDbl(costod3.Text) + CDbl(admin3.Text) + CDbl(impre3.Text) + CDbl(util3.Text))
            iva3.Text = FormatNumber(CDbl(util3.Text) * 0.16) ' Multiplica la utilidad x el 36%
            total3.Text = FormatNumber(CDbl(iva3.Text) + CDbl(subt3.Text)) ' suma el iva + el subtotal
        End If

        If servicio3.Text = 2 Then ' Caso 3
            a3.Enabled = True
            u3.Enabled = False ' Desabilita Utilidad
            i3.Enabled = False
            u3.Enabled = False ' Desabilita Utilidad
            u3.Text = 0
            i3.Text = 0
            util3.Text = 0
            impre3.Text = 0
            If a3.Text <> "" Then ' Administracion 
                If a3.Text = 0 Then
                    admin3.Text = 0
                Else
                    admin3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(a3.Text) / 100)
                End If

            Else
                a3.Text = 0
                admin3.Text = 0
            End If
            subt3.Text = FormatNumber(CDbl(costod3.Text) + CDbl(admin3.Text) + CDbl(util3.Text))
            iva3.Text = FormatNumber(CDbl(admin3.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 36%
            total3.Text = FormatNumber(CDbl(iva3.Text) + CDbl(subt3.Text))
        End If

        If servicio3.Text = 3 Then 'Opcion 3
            i3.Enabled = False
            u3.Enabled = False ' Desabilita Utilidad
            a3.Enabled = False
            u3.Text = 0
            i3.Text = 0
            util3.Text = 0
            impre3.Text = 0
            Admin3.Text = 0
            subt3.Text = FormatNumber(CDbl(costod3.Text))
            iva3.Text = FormatNumber(CDbl(subt3.Text) * 0.16)
            total3.Text = FormatNumber(CDbl(iva3.Text) + CDbl(subt3.Text))
        End If

        If servicio3.Text = 0 Then
            nservicio3.Text = "Seleccione Opcion"
            costod3.Text = 0
            a3.Text = 0
            i3.Text = 0
            u3.Text = 0
            admin3.Text = 0
            impre3.Text = 0
            util3.Text = 0
            subt3.Text = 0
            iva3.Text = 0
            total3.Text = 0
            REM nivel3.Enabled = False
        End If
    End Sub

    Private Sub calculo4()

        If servicio4.Text = "" Then servicio4.Text = 0 ' Verifica que no este vacio

        If servicio4.Text = 1 Then ' Verifica el tipo de servicio, 4 4 o 4
            a4.Enabled = True
            i4.Enabled = True
            u4.Enabled = True
            If a4.Text <> "" Then ' Administracion 
                If a4.Text = 0 Then
                    Admin4.Text = 0
                Else
                    Admin4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(a4.Text) / 100)
                End If
            Else
                a4.Text = 0
                Admin4.Text = 0
            End If

            If i4.Text <> "" Then ' Imprevistos
                If i4.Text = 0 Then
                    impre4.Text = 0
                Else

                    impre4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(i4.Text) / 100)
                End If
            Else
                i4.Text = 0
                impre4.Text = 0
            End If

            If u4.Text <> "" Then ' Utilidad
                If u4.Text = 0 Then
                    util4.Text = 0
                Else
                    util4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(u4.Text) / 100)
                End If
            Else
                u4.Text = 0
                util4.Text = 0
            End If

            subt4.Text = FormatNumber(CDbl(costod4.Text) + CDbl(Admin4.Text) + CDbl(impre4.Text) + CDbl(util4.Text))
            iva4.Text = FormatNumber(CDbl(util4.Text) * 0.16) ' Multiplica la utilidad x el 46%
            total4.Text = FormatNumber(CDbl(iva4.Text) + CDbl(subt4.Text)) ' suma el iva + el subtotal
        End If

        If servicio4.Text = 2 Then ' Caso 4
            a4.Enabled = True
            u4.Enabled = False ' Desabilita Utilidad
            i4.Enabled = False
            u4.Enabled = False ' Desabilita Utilidad
            u4.Text = 0
            i4.Text = 0
            util4.Text = 0
            impre4.Text = 0
            If a4.Text <> "" Then ' Administracion 
                If a4.Text = 0 Then
                    Admin4.Text = 0
                Else
                    Admin4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(a4.Text) / 100)
                End If

            Else
                a4.Text = 0
                Admin4.Text = 0
            End If
            subt4.Text = FormatNumber(CDbl(costod4.Text) + CDbl(Admin4.Text) + CDbl(util4.Text))
            iva4.Text = FormatNumber(CDbl(admin4.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 46%
            total4.Text = FormatNumber(CDbl(iva4.Text) + CDbl(subt4.Text))
        End If

        If servicio4.Text = 3 Then 'Opcion 4
            i4.Enabled = False
            u4.Enabled = False ' Desabilita Utilidad
            a4.Enabled = False
            u4.Text = 0
            i4.Text = 0
            util4.Text = 0
            impre4.Text = 0
            Admin4.Text = 0
            subt4.Text = FormatNumber(CDbl(costod4.Text))
            iva4.Text = FormatNumber(CDbl(subt4.Text) * 0.16)
            total4.Text = FormatNumber(CDbl(iva4.Text) + CDbl(subt4.Text))
        End If
        If servicio4.Text = 0 Then
            nservicio4.Text = "Seleccione Opcion"
            costod4.Text = 0
            a4.Text = 0
            i4.Text = 0
            u4.Text = 0
            admin4.Text = 0
            impre4.Text = 0
            util4.Text = 0
            subt4.Text = 0
            iva4.Text = 0
            total4.Text = 0
            REM nivel4.Enabled = False
        End If
    End Sub

    Private Sub calculo5()

        If servicio5.Text = "" Then servicio5.Text = 0 ' Verifica que no este vacio

        If servicio5.Text = 1 Then ' Verifica el tipo de servicio, 5 5 o 5
            a5.Enabled = True
            i5.Enabled = True
            u5.Enabled = True
            If a5.Text <> "" Then ' Administracion 
                If a5.Text = 0 Then
                    Admin5.Text = 0
                Else
                    Admin5.Text = FormatNumber(CDbl(costod5.Text) * CDbl(a5.Text) / 100)
                End If
            Else
                a5.Text = 0
                Admin5.Text = 0
            End If

            If i5.Text <> "" Then ' Imprevistos
                If i5.Text = 0 Then
                    impre5.Text = 0
                Else

                    impre5.Text = FormatNumber(CDbl(costod5.Text) * CDbl(i5.Text) / 100)
                End If
            Else
                i5.Text = 0
                impre5.Text = 0
            End If

            If u5.Text <> "" Then ' Utilidad
                If u5.Text = 0 Then
                    util5.Text = 0
                Else
                    util5.Text = FormatNumber(CDbl(costod5.Text) * CDbl(u5.Text) / 100)
                End If
            Else
                u5.Text = 0
                util5.Text = 0
            End If

            subt5.Text = FormatNumber(CDbl(costod5.Text) + CDbl(Admin5.Text) + CDbl(impre5.Text) + CDbl(util5.Text))
            iva5.Text = FormatNumber(CDbl(util5.Text) * 0.16) ' Multiplica la utilidad x el 56%
            total5.Text = FormatNumber(CDbl(iva5.Text) + CDbl(subt5.Text)) ' suma el iva + el subtotal
        End If

        If servicio5.Text = 2 Then ' Caso 5
            a5.Enabled = True
            u5.Enabled = False ' Desabilita Utilidad
            i5.Enabled = False
            u5.Enabled = False ' Desabilita Utilidad
            u5.Text = 0
            i5.Text = 0
            util5.Text = 0
            impre5.Text = 0
            If a5.Text <> "" Then ' Administracion 
                If a5.Text = 0 Then
                    Admin5.Text = 0
                Else
                    Admin5.Text = FormatNumber(CDbl(costod5.Text) * CDbl(a5.Text) / 100)
                End If

            Else
                a5.Text = 0
                Admin5.Text = 0
            End If
            subt5.Text = FormatNumber(CDbl(costod5.Text) + CDbl(Admin5.Text) + CDbl(util5.Text))
            iva5.Text = FormatNumber(CDbl(admin5.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 56%
            total5.Text = FormatNumber(CDbl(iva5.Text) + CDbl(subt5.Text))
        End If

        If servicio5.Text = 3 Then 'Opcion 5
            i5.Enabled = False
            u5.Enabled = False ' Desabilita Utilidad
            a5.Enabled = False
            u5.Text = 0
            i5.Text = 0
            util5.Text = 0
            impre5.Text = 0
            Admin5.Text = 0
            subt5.Text = FormatNumber(CDbl(costod5.Text))
            iva5.Text = FormatNumber(CDbl(subt5.Text) * 0.16)
            total5.Text = FormatNumber(CDbl(iva5.Text) + CDbl(subt5.Text))
        End If
        If servicio5.Text = 0 Then
            nservicio5.Text = "Seleccione Opcion"
            costod5.Text = 0
            a5.Text = 0
            i5.Text = 0
            u5.Text = 0
            admin5.Text = 0
            impre5.Text = 0
            util5.Text = 0
            subt5.Text = 0
            iva5.Text = 0
            total5.Text = 0
            REM nivel5.Enabled = False
        End If
    End Sub

    Private Sub calculo6()

        If servicio6.Text = "" Then servicio6.Text = 0 ' Verifica que no este vacio

        If servicio6.Text = 1 Then ' Verifica el tipo de servicio, 6 6 o 6
            a6.Enabled = True
            i6.Enabled = True
            u6.Enabled = True
            If a6.Text <> "" Then ' Administracion 
                If a6.Text = 0 Then
                    Admin6.Text = 0
                Else
                    Admin6.Text = FormatNumber(CDbl(costod6.Text) * CDbl(a6.Text) / 100)
                End If
            Else
                a6.Text = 0
                Admin6.Text = 0
            End If

            If i6.Text <> "" Then ' Imprevistos
                If i6.Text = 0 Then
                    impre6.Text = 0
                Else

                    impre6.Text = FormatNumber(CDbl(costod6.Text) * CDbl(i6.Text) / 100)
                End If
            Else
                i6.Text = 0
                impre6.Text = 0
            End If

            If u6.Text <> "" Then ' Utilidad
                If u6.Text = 0 Then
                    util6.Text = 0
                Else
                    util6.Text = FormatNumber(CDbl(costod6.Text) * CDbl(u6.Text) / 100)
                End If
            Else
                u6.Text = 0
                util6.Text = 0
            End If

            subt6.Text = FormatNumber(CDbl(costod6.Text) + CDbl(Admin6.Text) + CDbl(impre6.Text) + CDbl(util6.Text))
            iva6.Text = FormatNumber(CDbl(util6.Text) * 0.16) ' Multiplica la utilidad x el 66%
            total6.Text = FormatNumber(CDbl(iva6.Text) + CDbl(subt6.Text)) ' suma el iva + el subtotal
        End If

        If servicio6.Text = 2 Then ' Caso 6
            a6.Enabled = True
            u6.Enabled = False ' Desabilita Utilidad
            i6.Enabled = False
            u6.Enabled = False ' Desabilita Utilidad
            u6.Text = 0
            i6.Text = 0
            util6.Text = 0
            impre6.Text = 0
            If a6.Text <> "" Then ' Administracion 
                If a6.Text = 0 Then
                    Admin6.Text = 0
                Else
                    Admin6.Text = FormatNumber(CDbl(costod6.Text) * CDbl(a6.Text) / 100)
                End If

            Else
                a6.Text = 0
                Admin6.Text = 0
            End If
            subt6.Text = FormatNumber(CDbl(costod6.Text) + CDbl(Admin6.Text) + CDbl(util6.Text))
            iva6.Text = FormatNumber(CDbl(admin6.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 66%
            total6.Text = FormatNumber(CDbl(iva6.Text) + CDbl(subt6.Text))
        End If

        If servicio6.Text = 3 Then 'Opcion 6
            i6.Enabled = False
            u6.Enabled = False ' Desabilita Utilidad
            a6.Enabled = False
            u6.Text = 0
            i6.Text = 0
            util6.Text = 0
            impre6.Text = 0
            Admin6.Text = 0
            subt6.Text = FormatNumber(CDbl(costod6.Text))
            iva6.Text = FormatNumber(CDbl(subt6.Text) * 0.16)
            total6.Text = FormatNumber(CDbl(iva6.Text) + CDbl(subt6.Text))
        End If
        If servicio6.Text = 0 Then
            nservicio6.Text = "Seleccione Opcion"
            costod6.Text = 0
            a6.Text = 0
            i6.Text = 0
            u6.Text = 0
            admin6.Text = 0
            impre6.Text = 0
            util6.Text = 0
            subt6.Text = 0
            iva6.Text = 0
            total6.Text = 0
            REM   nivel6.Enabled = False
        End If
    End Sub
    Private Sub calculo7()
        If servicio7.Text = "" Then servicio7.Text = 0 ' Verifica que no este vacio
        If servicio7.Text = 1 Then ' Verifica el tipo de servicio, 7 7 o 7
            a7.Enabled = True
            i7.Enabled = True
            u7.Enabled = True
            If a7.Text <> "" Then ' Administracion 
                If a7.Text = 0 Then
                    admin7.Text = 0
                Else
                    admin7.Text = FormatNumber(CDbl(costod7.Text) * CDbl(a7.Text) / 100)
                End If
            Else
                a7.Text = 0
                admin7.Text = 0
            End If

            If i7.Text <> "" Then ' Imprevistos
                If i7.Text = 0 Then
                    impre7.Text = 0
                Else

                    impre7.Text = FormatNumber(CDbl(costod7.Text) * CDbl(i7.Text) / 100)
                End If
            Else
                i7.Text = 0
                impre7.Text = 0
            End If

            If u7.Text <> "" Then ' Utilidad
                If u7.Text = 0 Then
                    util7.Text = 0
                Else
                    util7.Text = FormatNumber(CDbl(costod7.Text) * CDbl(u7.Text) / 100)
                End If
            Else
                u7.Text = 0
                util7.Text = 0
            End If

            subt7.Text = FormatNumber(CDbl(costod7.Text) + CDbl(admin7.Text) + CDbl(impre7.Text) + CDbl(util7.Text))
            iva7.Text = FormatNumber(CDbl(util7.Text) * 0.16) ' Multiplica la utilidad x el 77%
            total7.Text = FormatNumber(CDbl(iva7.Text) + CDbl(subt7.Text)) ' suma el iva + el subtotal
        End If

        If servicio7.Text = 2 Then ' Caso 7
            a7.Enabled = True
            u7.Enabled = False ' Desabilita Utilidad
            i7.Enabled = False
            u7.Enabled = False ' Desabilita Utilidad
            u7.Text = 0
            i7.Text = 0
            util7.Text = 0
            impre7.Text = 0
            If a7.Text <> "" Then ' Administracion 
                If a7.Text = 0 Then
                    admin7.Text = 0
                Else
                    admin7.Text = FormatNumber(CDbl(costod7.Text) * CDbl(a7.Text) / 100)
                End If

            Else
                a7.Text = 0
                admin7.Text = 0
            End If
            subt7.Text = FormatNumber(CDbl(costod7.Text) + CDbl(admin7.Text) + CDbl(util7.Text))
            iva7.Text = FormatNumber(CDbl(admin7.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 77%
            total7.Text = FormatNumber(CDbl(iva7.Text) + CDbl(subt7.Text))
        End If

        If servicio7.Text = 3 Then 'Opcion 7
            i7.Enabled = False
            u7.Enabled = False ' Desabilita Utilidad
            a7.Enabled = False
            u7.Text = 0
            i7.Text = 0
            util7.Text = 0
            impre7.Text = 0
            admin7.Text = 0
            subt7.Text = FormatNumber(CDbl(costod7.Text))
            iva7.Text = FormatNumber(CDbl(subt7.Text) * 0.16)
            total7.Text = FormatNumber(CDbl(iva7.Text) + CDbl(subt7.Text))
        End If
        If servicio7.Text = 0 Then
            nservicio7.Text = "Seleccione Opcion"
            costod7.Text = 0
            a7.Text = 0
            i7.Text = 0
            u7.Text = 0
            admin7.Text = 0
            impre7.Text = 0
            util7.Text = 0
            subt7.Text = 0
            iva7.Text = 0
            total7.Text = 0
            REM   nivel7.Enabled = False
        End If
    End Sub

    Private Sub calculo8()

        If servicio8.Text = "" Then servicio8.Text = 0 ' Verifica que no este vacio

        If servicio8.Text = 1 Then ' Verifica el tipo de servicio, 8 8 o 8
            a8.Enabled = True
            i8.Enabled = True
            u8.Enabled = True
            If a8.Text <> "" Then ' Administracion 
                If a8.Text = 0 Then
                    Admin8.Text = 0
                Else
                    Admin8.Text = FormatNumber(CDbl(costod8.Text) * CDbl(a8.Text) / 100)
                End If
            Else
                a8.Text = 0
                Admin8.Text = 0
            End If

            If i8.Text <> "" Then ' Imprevistos
                If i8.Text = 0 Then
                    impre8.Text = 0
                Else

                    impre8.Text = FormatNumber(CDbl(costod8.Text) * CDbl(i8.Text) / 100)
                End If
            Else
                i8.Text = 0
                impre8.Text = 0
            End If

            If u8.Text <> "" Then ' Utilidad
                If u8.Text = 0 Then
                    util8.Text = 0
                Else
                    util8.Text = FormatNumber(CDbl(costod8.Text) * CDbl(u8.Text) / 100)
                End If
            Else
                u8.Text = 0
                util8.Text = 0
            End If

            subt8.Text = FormatNumber(CDbl(costod8.Text) + CDbl(Admin8.Text) + CDbl(impre8.Text) + CDbl(util8.Text))
            iva8.Text = FormatNumber(CDbl(util8.Text) * 0.16) ' Multiplica la utilidad x el 88%
            total8.Text = FormatNumber(CDbl(iva8.Text) + CDbl(subt8.Text)) ' suma el iva + el subtotal
        End If

        If servicio8.Text = 2 Then ' Caso 8
            a8.Enabled = True
            u8.Enabled = False ' Desabilita Utilidad
            i8.Enabled = False
            u8.Enabled = False ' Desabilita Utilidad
            u8.Text = 0
            i8.Text = 0
            util8.Text = 0
            impre8.Text = 0
            If a8.Text <> "" Then ' Administracion 
                If a8.Text = 0 Then
                    Admin8.Text = 0
                Else
                    Admin8.Text = FormatNumber(CDbl(costod8.Text) * CDbl(a8.Text) / 100)
                End If

            Else
                a8.Text = 0
                Admin8.Text = 0
            End If
            subt8.Text = FormatNumber(CDbl(costod8.Text) + CDbl(Admin8.Text) + CDbl(util8.Text))
            iva8.Text = FormatNumber(CDbl(admin8.Text) * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 88%
            total8.Text = FormatNumber(CDbl(iva8.Text) + CDbl(subt8.Text))
        End If

        If servicio8.Text = 3 Then 'Opcion 8
            i8.Enabled = False
            u8.Enabled = False ' Desabilita Utilidad
            a8.Enabled = False
            u8.Text = 0
            i8.Text = 0
            util8.Text = 0
            impre8.Text = 0
            Admin8.Text = 0
            subt8.Text = FormatNumber(CDbl(costod8.Text))
            iva8.Text = FormatNumber(CDbl(subt8.Text) * 0.16)
            total8.Text = FormatNumber(CDbl(iva8.Text) + CDbl(subt8.Text))
        End If
        If servicio8.Text = 0 Then
            nservicio8.Text = "Seleccione Opcion"
            costod8.Text = 0
            a8.Text = 0
            i8.Text = 0
            u8.Text = 0
            admin8.Text = 0
            impre8.Text = 0
            util8.Text = 0
            subt8.Text = 0
            iva8.Text = 0
            total8.Text = 0
            REM nivel8.Enabled = False
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            constante()
            desviacion.Text = FormatNumber(CDbl(txtvalorcontcart.Text) - CDbl(vrgtotal.Text))
            If txtvalorcontcart.Text <> vrgtotal.Text Then
                Label85.Text = ("Verifique la estructura del contrato" & " " & desviacion.Text)
                CheckBox1.Checked = False
            Else
                Label85.Text = ("Contrato Ok.")
                btnaceptar.Enabled = True
                nivel1.Enabled = False
                nivel2.Enabled = False
                nivel3.Enabled = False
                nivel4.Enabled = False
                nivel5.Enabled = False
                nivel6.Enabled = False
                nivel7.Enabled = False
                nivel8.Enabled = False
                formateo()
            End If
        End If
        If CheckBox1.Checked = False Then
            btnaceptar.Enabled = False
            Label85.Text = ""
            servicios()
        End If
    End Sub
    Friend Sub guardar()
        frmformulario.servicio(0) = servicio1.Text
        frmformulario.servicio(1) = servicio2.Text
        frmformulario.servicio(2) = servicio3.Text
        frmformulario.servicio(3) = servicio4.Text
        frmformulario.servicio(4) = servicio5.Text
        frmformulario.servicio(5) = servicio6.Text
        frmformulario.servicio(6) = servicio7.Text
        frmformulario.servicio(7) = servicio8.Text
        frmformulario.nservicio(0) = nservicio1.Text
        frmformulario.nservicio(1) = nservicio2.Text
        frmformulario.nservicio(2) = nservicio3.Text
        frmformulario.nservicio(3) = nservicio4.Text
        frmformulario.nservicio(4) = nservicio5.Text
        frmformulario.nservicio(5) = nservicio6.Text
        frmformulario.nservicio(6) = nservicio7.Text
        frmformulario.nservicio(7) = nservicio8.Text
        frmformulario.costod(0) = FormatNumber(CDbl(costod1.Text))
        frmformulario.costod(1) = FormatNumber(CDbl(costod2.Text))
        frmformulario.costod(2) = FormatNumber(CDbl(costod3.Text))
        frmformulario.costod(3) = FormatNumber(CDbl(costod4.Text))
        frmformulario.costod(4) = FormatNumber(CDbl(costod5.Text))
        frmformulario.costod(5) = FormatNumber(CDbl(costod6.Text))
        frmformulario.costod(6) = FormatNumber(CDbl(costod7.Text))
        frmformulario.costod(7) = FormatNumber(CDbl(costod8.Text))
        frmformulario.admin(0) = FormatNumber(CDbl(Admin1.Text))
        frmformulario.admin(1) = FormatNumber(CDbl(admin2.Text))
        frmformulario.admin(2) = FormatNumber(CDbl(admin3.Text))
        frmformulario.admin(3) = FormatNumber(CDbl(admin4.Text))
        frmformulario.admin(4) = FormatNumber(CDbl(admin5.Text))
        frmformulario.admin(5) = FormatNumber(CDbl(admin6.Text))
        frmformulario.admin(6) = FormatNumber(CDbl(admin7.Text))
        frmformulario.admin(7) = FormatNumber(CDbl(admin8.Text))
        frmformulario.impre(0) = FormatNumber(CDbl(impre1.Text))
        frmformulario.impre(1) = FormatNumber(CDbl(impre2.Text))
        frmformulario.impre(2) = FormatNumber(CDbl(impre3.Text))
        frmformulario.impre(3) = FormatNumber(CDbl(impre4.Text))
        frmformulario.impre(4) = FormatNumber(CDbl(impre5.Text))
        frmformulario.impre(5) = FormatNumber(CDbl(impre6.Text))
        frmformulario.impre(6) = FormatNumber(CDbl(impre7.Text))
        frmformulario.impre(7) = FormatNumber(CDbl(impre8.Text))
        frmformulario.util(0) = FormatNumber(CDbl(util1.Text))
        frmformulario.util(1) = FormatNumber(CDbl(util2.Text))
        frmformulario.util(2) = FormatNumber(CDbl(util3.Text))
        frmformulario.util(3) = FormatNumber(CDbl(util4.Text))
        frmformulario.util(4) = FormatNumber(CDbl(util5.Text))
        frmformulario.util(5) = FormatNumber(CDbl(util6.Text))
        frmformulario.util(6) = FormatNumber(CDbl(util7.Text))
        frmformulario.util(7) = FormatNumber(CDbl(util8.Text))
        frmformulario.subt(0) = FormatNumber(CDbl(subt1.Text))
        frmformulario.subt(1) = FormatNumber(CDbl(subt2.Text))
        frmformulario.subt(2) = FormatNumber(CDbl(subt3.Text))
        frmformulario.subt(3) = FormatNumber(CDbl(subt4.Text))
        frmformulario.subt(4) = FormatNumber(CDbl(subt5.Text))
        frmformulario.subt(5) = FormatNumber(CDbl(subt6.Text))
        frmformulario.subt(6) = FormatNumber(CDbl(subt7.Text))
        frmformulario.subt(7) = FormatNumber(CDbl(subt8.Text))
        frmformulario.iva(0) = FormatNumber(CDbl(iva1.Text))
        frmformulario.iva(1) = FormatNumber(CDbl(iva2.Text))
        frmformulario.iva(2) = FormatNumber(CDbl(iva3.Text))
        frmformulario.iva(3) = FormatNumber(CDbl(iva4.Text))
        frmformulario.iva(4) = FormatNumber(CDbl(iva5.Text))
        frmformulario.iva(5) = FormatNumber(CDbl(iva6.Text))
        frmformulario.iva(6) = FormatNumber(CDbl(iva7.Text))
        frmformulario.iva(7) = FormatNumber(CDbl(iva8.Text))
        frmformulario.total(0) = FormatNumber(CDbl(total1.Text))
        frmformulario.total(1) = FormatNumber(CDbl(total2.Text))
        frmformulario.total(2) = FormatNumber(CDbl(total3.Text))
        frmformulario.total(3) = FormatNumber(CDbl(total4.Text))
        frmformulario.total(4) = FormatNumber(CDbl(total5.Text))
        frmformulario.total(5) = FormatNumber(CDbl(total6.Text))
        frmformulario.total(6) = FormatNumber(CDbl(total7.Text))
        frmformulario.total(7) = FormatNumber(CDbl(total8.Text))
        frmformulario.a(0) = FormatNumber(CDbl(a1.Text))
        frmformulario.a(1) = FormatNumber(CDbl(a2.Text))
        frmformulario.a(2) = FormatNumber(CDbl(a3.Text))
        frmformulario.a(3) = FormatNumber(CDbl(a4.Text))
        frmformulario.a(4) = FormatNumber(CDbl(a5.Text))
        frmformulario.a(5) = FormatNumber(CDbl(a6.Text))
        frmformulario.a(6) = FormatNumber(CDbl(a7.Text))
        frmformulario.a(7) = FormatNumber(CDbl(a8.Text))
        frmformulario.i(0) = FormatNumber(CDbl(i1.Text))
        frmformulario.i(1) = FormatNumber(CDbl(i2.Text))
        frmformulario.i(2) = FormatNumber(CDbl(i3.Text))
        frmformulario.i(3) = FormatNumber(CDbl(i4.Text))
        frmformulario.i(4) = FormatNumber(CDbl(i5.Text))
        frmformulario.i(5) = FormatNumber(CDbl(i6.Text))
        frmformulario.i(6) = FormatNumber(CDbl(i7.Text))
        frmformulario.i(7) = FormatNumber(CDbl(i8.Text))
        frmformulario.u(0) = FormatNumber(CDbl(u1.Text))
        frmformulario.u(1) = FormatNumber(CDbl(u2.Text))
        frmformulario.u(2) = FormatNumber(CDbl(u3.Text))
        frmformulario.u(3) = FormatNumber(CDbl(u4.Text))
        frmformulario.u(4) = FormatNumber(CDbl(u5.Text))
        frmformulario.u(5) = FormatNumber(CDbl(u6.Text))
        frmformulario.u(6) = FormatNumber(CDbl(u7.Text))
        frmformulario.u(7) = FormatNumber(CDbl(u8.Text))
        frmformulario.cosdirecto = FormatNumber(CDbl(txtcostdglobal.Text))
        frmformulario.imptxtcostadminglobal = FormatNumber(CDbl(txtcostadminglobal.Text))
        frmformulario.imptxtcostimpglobal = FormatNumber(CDbl(txtcostimpglobal.Text))
        frmformulario.imptxtcostutilglobal = FormatNumber(CDbl(txtcostutilglobal.Text))
        frmformulario.imptxtcostsubglobal = FormatNumber(CDbl(txtcostsubglobal.Text))
        frmformulario.imptxtcostivaglobal = FormatNumber(CDbl(txtcostivaglobal.Text))
        frmformulario.impvrgtotal = FormatNumber(CDbl(vrgtotal.Text))
    End Sub
    Private Sub formateo()
        a1.Text = FormatNumber(CDbl(a1.Text), 2)
        i1.Text = FormatNumber(CDbl(i1.Text), 2)
        u1.Text = FormatNumber(CDbl(u1.Text), 2)
        a2.Text = FormatNumber(CDbl(a2.Text), 2)
        i2.Text = FormatNumber(CDbl(i2.Text), 2)
        u2.Text = FormatNumber(CDbl(u2.Text), 2)
        a3.Text = FormatNumber(CDbl(a3.Text), 2)
        i3.Text = FormatNumber(CDbl(i3.Text), 2)
        u3.Text = FormatNumber(CDbl(u3.Text), 2)
        a4.Text = FormatNumber(CDbl(a4.Text), 2)
        i4.Text = FormatNumber(CDbl(i4.Text), 2)
        u4.Text = FormatNumber(CDbl(u4.Text), 2)
        a5.Text = FormatNumber(CDbl(a5.Text), 2)
        i5.Text = FormatNumber(CDbl(i5.Text), 2)
        u5.Text = FormatNumber(CDbl(u5.Text), 2)
        a6.Text = FormatNumber(CDbl(a6.Text), 2)
        i6.Text = FormatNumber(CDbl(i6.Text), 2)
        u6.Text = FormatNumber(CDbl(u6.Text), 2)
        a7.Text = FormatNumber(CDbl(a7.Text), 2)
        i7.Text = FormatNumber(CDbl(i7.Text), 2)
        u7.Text = FormatNumber(CDbl(u7.Text), 2)
        a8.Text = FormatNumber(CDbl(a8.Text), 2)
        i8.Text = FormatNumber(CDbl(i8.Text), 2)
        u8.Text = FormatNumber(CDbl(u8.Text), 2)
    End Sub
    Private Sub nservicio1_Click(sender As Object, e As System.EventArgs) Handles nservicio1.Click
        ident = 1
        Form8.ShowDialog()
        constante()
    End Sub
    Private Sub nservicio2_Click(sender As Object, e As System.EventArgs) Handles nservicio2.Click
        ident = 2
        Form8.ShowDialog()
        constante()
    End Sub
    Private Sub nservicio3_Click(sender As Object, e As System.EventArgs) Handles nservicio3.Click
        ident = 3
        Form8.ShowDialog()
        constante()
    End Sub
    Private Sub nservicio4_Click(sender As Object, e As System.EventArgs) Handles nservicio4.Click
        ident = 4
        Form8.ShowDialog()
        constante()
    End Sub
    Private Sub nservicio5_Click(sender As Object, e As System.EventArgs) Handles nservicio5.Click
        ident = 5
        Form8.ShowDialog()
        constante()
    End Sub
    Private Sub nservicio6_Click(sender As Object, e As System.EventArgs) Handles nservicio6.Click
        ident = 6
        Form8.ShowDialog()
        constante()
    End Sub
    Private Sub nservicio7_Click(sender As Object, e As System.EventArgs) Handles nservicio7.Click
        ident = 7
        Form8.ShowDialog()
        constante()
    End Sub
    Private Sub nservicio8_Click(sender As Object, e As System.EventArgs) Handles nservicio8.Click
        ident = 8
        Form8.ShowDialog()
        constante()
    End Sub

    Private Sub servicio1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio1.SelectedIndexChanged
        nservicio1.Enabled = True
        constante()
    End Sub

    Private Sub servicio2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio2.SelectedIndexChanged
        nservicio2.Enabled = True
        constante()
    End Sub

    Private Sub servicio3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio3.SelectedIndexChanged
        nservicio3.Enabled = True
        constante()
    End Sub
    Private Sub servicio4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio4.SelectedIndexChanged
        nservicio4.Enabled = True
        constante()
    End Sub
    Private Sub servicio5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio5.SelectedIndexChanged
        nservicio5.Enabled = True
        constante()
    End Sub

    Private Sub servicio6_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio6.SelectedIndexChanged
        nservicio6.Enabled = True
        constante()
    End Sub

    Private Sub servicio7_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio7.SelectedIndexChanged
        nservicio7.Enabled = True
        constante()
    End Sub

    Private Sub servicio8_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles servicio8.SelectedIndexChanged
        nservicio8.Enabled = True
        constante()
    End Sub
    Private Sub constante()
        If ErrorProvider1.GetError(costod1) = "" Then
            If ErrorProvider2.GetError(costod2) = "" Then
                If ErrorProvider3.GetError(costod3) = "" Then
                    If ErrorProvider4.GetError(costod4) = "" Then
                        If ErrorProvider5.GetError(costod5) = "" Then
                            If ErrorProvider6.GetError(costod6) = "" Then
                                If ErrorProvider7.GetError(costod7) = "" Then
                                    If ErrorProvider8.GetError(costod8) = "" Then
                                        If numberservice.Text = "" Then
                                        Else

                                            If numberservice.Text = 1 Then
                                                calculo1()
                                            End If
                                            ' caso1
                                            If numberservice.Text = 2 Then
                                                calculo1()
                                                calculo2()
                                            End If
                                            ' caso2
                                            If numberservice.Text = 3 Then
                                                calculo1()
                                                calculo2()
                                                calculo3()
                                            End If
                                            ' caso3
                                            If numberservice.Text = 4 Then
                                                calculo1()
                                                calculo2()
                                                calculo3()
                                                calculo4()
                                            End If
                                            ' caso4
                                            If numberservice.Text = 5 Then
                                                calculo1()
                                                calculo2()
                                                calculo3()
                                                calculo4()
                                                calculo5()
                                            End If
                                            ' caso5
                                            If numberservice.Text = 6 Then
                                                calculo1()
                                                calculo2()
                                                calculo3()
                                                calculo4()
                                                calculo5()
                                                calculo6()
                                            End If
                                            ' caso6
                                            If numberservice.Text = 7 Then
                                                calculo1()
                                                calculo2()
                                                calculo3()
                                                calculo4()
                                                calculo5()
                                                calculo6()
                                                calculo7()
                                            End If
                                            ' caso7
                                            If numberservice.Text = 8 Then
                                                calculo1()
                                                calculo2()
                                                calculo3()
                                                calculo4()
                                                calculo5()
                                                calculo6()
                                                calculo7()
                                                calculo8()
                                            End If
                                            txtcostdglobal.Text = FormatNumber(CDbl(costod1.Text) + CDbl(costod2.Text) + CDbl(costod3.Text) + CDbl(costod4.Text) + CDbl(costod5.Text) + CDbl(costod6.Text) + CDbl(costod7.Text) + CDbl(costod8.Text))
                                            txtcostadminglobal.Text = FormatNumber(CDbl(Admin1.Text) + CDbl(admin2.Text) + CDbl(admin3.Text) + CDbl(admin4.Text) + CDbl(admin5.Text) + CDbl(admin6.Text) + CDbl(admin7.Text) + CDbl(admin8.Text))
                                            txtcostimpglobal.Text = FormatNumber(CDbl(impre1.Text) + CDbl(impre2.Text) + CDbl(impre3.Text) + CDbl(impre4.Text) + CDbl(impre5.Text) + CDbl(impre6.Text) + CDbl(impre7.Text) + CDbl(impre8.Text))
                                            txtcostutilglobal.Text = FormatNumber(CDbl(util1.Text) + CDbl(util2.Text) + CDbl(util3.Text) + CDbl(util4.Text) + CDbl(util5.Text) + CDbl(util6.Text) + CDbl(util7.Text) + CDbl(util8.Text))
                                            txtcostsubglobal.Text = FormatNumber(CDbl(subt1.Text) + CDbl(subt2.Text) + CDbl(subt3.Text) + CDbl(subt4.Text) + CDbl(subt5.Text) + CDbl(subt6.Text) + CDbl(subt7.Text) + CDbl(subt8.Text))
                                            txtcostivaglobal.Text = FormatNumber(CDbl(iva1.Text) + CDbl(iva2.Text) + CDbl(iva3.Text) + CDbl(iva4.Text) + CDbl(iva5.Text) + CDbl(iva6.Text) + CDbl(iva7.Text) + CDbl(iva8.Text))
                                            vrgtotal.Text = FormatNumber(CDbl(total1.Text) + CDbl(total2.Text) + CDbl(total3.Text) + CDbl(total4.Text) + CDbl(total5.Text) + CDbl(total6.Text) + CDbl(total7.Text) + CDbl(total8.Text))
                                        End If
                                    Else
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub nservicio1_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio1.TextChanged
        If nservicio1.Text <> "Seleccione Opcion" Then
            costod1.Enabled = True
        End If
    End Sub

    Private Sub nservicio2_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio2.TextChanged
        If nservicio2.Text <> "Seleccione Opcion" Then
            costod2.Enabled = True
        End If
    End Sub

    Private Sub nservicio3_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio3.TextChanged
        If nservicio3.Text <> "Seleccione Opcion" Then
            costod3.Enabled = True
        End If
    End Sub
    Private Sub nservicio4_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio4.TextChanged
        If nservicio4.Text <> "Seleccione Opcion" Then
            costod4.Enabled = True
        End If
    End Sub
    Private Sub nservicio5_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio5.TextChanged
        If nservicio5.Text <> "Seleccione Opcion" Then
            costod5.Enabled = True
        End If
    End Sub

    Private Sub nservicio6_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio6.TextChanged
        If nservicio6.Text <> "Seleccione Opcion" Then
            costod6.Enabled = True
        End If
    End Sub

    Private Sub nservicio7_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio7.TextChanged
        If nservicio7.Text <> "Seleccione Opcion" Then
            costod7.Enabled = True
        End If
    End Sub

    Private Sub nservicio8_TextChanged(sender As System.Object, e As System.EventArgs) Handles nservicio8.TextChanged
        If nservicio8.Text <> "Seleccione Opcion" Then
            costod8.Enabled = True
        End If
    End Sub
    Private Sub a1_TextChanged(sender As Object, e As System.EventArgs) Handles a1.TextChanged
        a1.Text = Trim(dejarNumerosPuntos2(a1.Text))
        If (String.IsNullOrEmpty(a1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(a1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            constante()
        End If
    End Sub

    Private Sub i1_TextChanged(sender As Object, e As System.EventArgs) Handles i1.TextChanged
        i1.Text = Trim(dejarNumerosPuntos2(i1.Text))
        If (String.IsNullOrEmpty(i1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(i1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            constante()
        End If

    End Sub
    Private Sub u1_TextChanged(sender As Object, e As System.EventArgs) Handles u1.TextChanged
        u1.Text = Trim(dejarNumerosPuntos2(u1.Text))
        If (String.IsNullOrEmpty(u1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(u1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            constante()
        End If

    End Sub

    Private Sub a2_TextChanged(sender As Object, e As System.EventArgs) Handles a2.TextChanged
        a2.Text = Trim(dejarNumerosPuntos2(a2.Text))
        If (String.IsNullOrEmpty(a2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(a2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            constante()
        End If
    End Sub

    Private Sub i2_TextChanged(sender As Object, e As System.EventArgs) Handles i2.TextChanged
        i2.Text = Trim(dejarNumerosPuntos2(i2.Text))
        If (String.IsNullOrEmpty(i2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(i2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            constante()
        End If

    End Sub
    Private Sub u2_TextChanged(sender As Object, e As System.EventArgs) Handles u2.TextChanged
        u2.Text = Trim(dejarNumerosPuntos2(u2.Text))
        If (String.IsNullOrEmpty(u2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(u2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            constante()
        End If

    End Sub
    Private Sub a3_TextChanged(sender As Object, e As System.EventArgs) Handles a3.TextChanged
        a3.Text = Trim(dejarNumerosPuntos2(a3.Text))
        If (String.IsNullOrEmpty(a3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(a3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            constante()
        End If
    End Sub

    Private Sub i3_TextChanged(sender As Object, e As System.EventArgs) Handles i3.TextChanged
        i3.Text = Trim(dejarNumerosPuntos2(i3.Text))
        If (String.IsNullOrEmpty(i3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(i3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            constante()
        End If

    End Sub
    Private Sub u3_TextChanged(sender As Object, e As System.EventArgs) Handles u3.TextChanged
        u3.Text = Trim(dejarNumerosPuntos2(u3.Text))
        If (String.IsNullOrEmpty(u3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(u3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            constante()
        End If

    End Sub

    Private Sub a4_TextChanged(sender As Object, e As System.EventArgs) Handles a4.TextChanged
        a4.Text = Trim(dejarNumerosPuntos2(a4.Text))
        If (String.IsNullOrEmpty(a4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(a4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            constante()
        End If
    End Sub

    Private Sub i4_TextChanged(sender As Object, e As System.EventArgs) Handles i4.TextChanged
        i4.Text = Trim(dejarNumerosPuntos2(i4.Text))
        If (String.IsNullOrEmpty(i4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(i4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            constante()
        End If

    End Sub
    Private Sub u4_TextChanged(sender As Object, e As System.EventArgs) Handles u4.TextChanged
        u4.Text = Trim(dejarNumerosPuntos2(u4.Text))
        If (String.IsNullOrEmpty(u4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(u4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            constante()
        End If

    End Sub
    Private Sub a5_TextChanged(sender As Object, e As System.EventArgs) Handles a5.TextChanged
        a5.Text = Trim(dejarNumerosPuntos2(a5.Text))
        If (String.IsNullOrEmpty(a5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(a5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
            constante()
        End If
    End Sub

    Private Sub i5_TextChanged(sender As Object, e As System.EventArgs) Handles i5.TextChanged
        i5.Text = Trim(dejarNumerosPuntos2(i5.Text))
        If (String.IsNullOrEmpty(i5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(i5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
            constante()
        End If

    End Sub
    Private Sub u5_TextChanged(sender As Object, e As System.EventArgs) Handles u5.TextChanged
        u5.Text = Trim(dejarNumerosPuntos2(u5.Text))
        If (String.IsNullOrEmpty(u5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(u5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
            constante()
        End If

    End Sub

    Private Sub a6_TextChanged(sender As Object, e As System.EventArgs) Handles a6.TextChanged
        a6.Text = Trim(dejarNumerosPuntos2(a6.Text))
        If (String.IsNullOrEmpty(a6.Text.Trim())) Then
            Me.ErrorProvider6.SetError(a6, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider6.Clear()
            constante()
        End If
    End Sub

    Private Sub i6_TextChanged(sender As Object, e As System.EventArgs) Handles i6.TextChanged
        i6.Text = Trim(dejarNumerosPuntos2(i6.Text))
        If (String.IsNullOrEmpty(i6.Text.Trim())) Then
            Me.ErrorProvider6.SetError(i6, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider6.Clear()
            constante()
        End If

    End Sub
    Private Sub u6_TextChanged(sender As Object, e As System.EventArgs) Handles u6.TextChanged
        u6.Text = Trim(dejarNumerosPuntos2(u6.Text))
        If (String.IsNullOrEmpty(u6.Text.Trim())) Then
            Me.ErrorProvider6.SetError(u6, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider6.Clear()
            constante()
        End If

    End Sub

    Private Sub a7_TextChanged(sender As Object, e As System.EventArgs) Handles a7.TextChanged
        a7.Text = Trim(dejarNumerosPuntos2(a7.Text))
        If (String.IsNullOrEmpty(a7.Text.Trim())) Then
            Me.ErrorProvider7.SetError(a7, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider7.Clear()
            constante()
        End If
    End Sub

    Private Sub i7_TextChanged(sender As Object, e As System.EventArgs) Handles i7.TextChanged
        i7.Text = Trim(dejarNumerosPuntos2(i7.Text))
        If (String.IsNullOrEmpty(i7.Text.Trim())) Then
            Me.ErrorProvider7.SetError(i7, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider7.Clear()
            constante()
        End If

    End Sub
    Private Sub u7_TextChanged(sender As Object, e As System.EventArgs) Handles u7.TextChanged
        u7.Text = Trim(dejarNumerosPuntos2(u7.Text))
        If (String.IsNullOrEmpty(u7.Text.Trim())) Then
            Me.ErrorProvider7.SetError(u7, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider7.Clear()
            constante()
        End If

    End Sub

    Private Sub a8_TextChanged(sender As Object, e As System.EventArgs) Handles a8.TextChanged
        a8.Text = Trim(dejarNumerosPuntos2(a8.Text))
        If (String.IsNullOrEmpty(a8.Text.Trim())) Then
            Me.ErrorProvider8.SetError(a8, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider8.Clear()
            constante()
        End If
    End Sub

    Private Sub i8_TextChanged(sender As Object, e As System.EventArgs) Handles i8.TextChanged
        i8.Text = Trim(dejarNumerosPuntos2(i8.Text))
        If (String.IsNullOrEmpty(i8.Text.Trim())) Then
            Me.ErrorProvider8.SetError(i8, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider8.Clear()
            constante()
        End If

    End Sub
    Private Sub u8_TextChanged(sender As Object, e As System.EventArgs) Handles u8.TextChanged
        u8.Text = Trim(dejarNumerosPuntos2(u8.Text))
        If (String.IsNullOrEmpty(u8.Text.Trim())) Then
            Me.ErrorProvider8.SetError(u8, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider8.Clear()
            constante()
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
    Function dejarNumerosPuntos2(cadenaTexto As String) As String
        Const listaNumeros = "0123456789,"
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
        dejarNumerosPuntos2 = cadenaTemporal
    End Function
    Private Sub costod1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod1.Text = FormatNumber(CDbl(costod1.Text), 2)
        End If
    End Sub
    Private Sub costod1_LostFocus(sender As Object, e As System.EventArgs) Handles costod1.LostFocus
        costod1.Text = FormatNumber(CDbl(costod1.Text), 2)
    End Sub
    Private Sub costod1_TextChanged(sender As Object, e As System.EventArgs) Handles costod1.TextChanged
        costod1.Text = Trim(dejarNumerosPuntos(costod1.Text))
        If (String.IsNullOrEmpty(costod1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(costod1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            constante()
        End If
    End Sub
    Private Sub costod2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod2.Text = FormatNumber(CDbl(costod2.Text), 2)
        End If
    End Sub
    Private Sub costod2_LostFocus(sender As Object, e As System.EventArgs) Handles costod2.LostFocus
        costod2.Text = FormatNumber(CDbl(costod2.Text), 2)
    End Sub
    Private Sub costod2_TextChanged(sender As Object, e As System.EventArgs) Handles costod2.TextChanged
        costod2.Text = Trim(dejarNumerosPuntos(costod2.Text))
        If (String.IsNullOrEmpty(costod2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(costod2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            constante()
        End If
    End Sub
    Private Sub costod3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod3.Text = FormatNumber(CDbl(costod3.Text), 2)
        End If
    End Sub
    Private Sub costod3_LostFocus(sender As Object, e As System.EventArgs) Handles costod3.LostFocus
        costod3.Text = FormatNumber(CDbl(costod3.Text), 2)
    End Sub
    Private Sub costod3_TextChanged(sender As Object, e As System.EventArgs) Handles costod3.TextChanged
        costod3.Text = Trim(dejarNumerosPuntos(costod3.Text))
        If (String.IsNullOrEmpty(costod3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(costod3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            constante()
        End If
    End Sub
    Private Sub costod4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod4.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod4.Text = FormatNumber(CDbl(costod4.Text), 2)
        End If
    End Sub
    Private Sub costod4_LostFocus(sender As Object, e As System.EventArgs) Handles costod4.LostFocus
        costod4.Text = FormatNumber(CDbl(costod4.Text), 2)
    End Sub
    Private Sub costod4_TextChanged(sender As Object, e As System.EventArgs) Handles costod4.TextChanged
        costod4.Text = Trim(dejarNumerosPuntos(costod4.Text))
        If (String.IsNullOrEmpty(costod4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(costod4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            constante()
        End If
    End Sub
    Private Sub costod5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod5.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod5.Text = FormatNumber(CDbl(costod5.Text), 2)
        End If
    End Sub
    Private Sub costod5_LostFocus(sender As Object, e As System.EventArgs) Handles costod5.LostFocus
        costod5.Text = FormatNumber(CDbl(costod5.Text), 2)
    End Sub
    Private Sub costod5_TextChanged(sender As Object, e As System.EventArgs) Handles costod5.TextChanged
        costod5.Text = Trim(dejarNumerosPuntos(costod5.Text))
        If (String.IsNullOrEmpty(costod5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(costod5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
            constante()
        End If
    End Sub
    Private Sub costod6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod6.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod6.Text = FormatNumber(CDbl(costod6.Text), 2)
        End If
    End Sub
    Private Sub costod6_LostFocus(sender As Object, e As System.EventArgs) Handles costod6.LostFocus
        costod6.Text = FormatNumber(CDbl(costod6.Text), 2)
    End Sub
    Private Sub costod6_TextChanged(sender As Object, e As System.EventArgs) Handles costod6.TextChanged
        costod6.Text = Trim(dejarNumerosPuntos(costod6.Text))
        If (String.IsNullOrEmpty(costod6.Text.Trim())) Then
            Me.ErrorProvider6.SetError(costod6, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider6.Clear()
            constante()
        End If
    End Sub
    Private Sub costod7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod7.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod7.Text = FormatNumber(CDbl(costod7.Text), 2)
        End If
    End Sub
    Private Sub costod7_LostFocus(sender As Object, e As System.EventArgs) Handles costod7.LostFocus
        costod7.Text = FormatNumber(CDbl(costod7.Text), 2)
    End Sub
    Private Sub costod7_TextChanged(sender As Object, e As System.EventArgs) Handles costod7.TextChanged
        costod7.Text = Trim(dejarNumerosPuntos(costod7.Text))
        If (String.IsNullOrEmpty(costod7.Text.Trim())) Then
            Me.ErrorProvider7.SetError(costod7, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider7.Clear()
            constante()
        End If
    End Sub
    Private Sub costod8_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod8.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod8.Text = FormatNumber(CDbl(costod8.Text), 2)
        End If
    End Sub
    Private Sub costod8_LostFocus(sender As Object, e As System.EventArgs) Handles costod8.LostFocus
        costod8.Text = FormatNumber(CDbl(costod8.Text), 2)
    End Sub
    Private Sub costod8_TextChanged(sender As Object, e As System.EventArgs) Handles costod8.TextChanged
        costod8.Text = Trim(dejarNumerosPuntos(costod8.Text))
        If (String.IsNullOrEmpty(costod8.Text.Trim())) Then
            Me.ErrorProvider8.SetError(costod8, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider8.Clear()
            constante()
        End If
    End Sub
    Private Sub txtvalorcontcart_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtvalorcontcart.TextChanged
        txtvalorcontcart.Text = FormatNumber(CDbl(txtvalorcontcart.Text), 2)
    End Sub

   
End Class