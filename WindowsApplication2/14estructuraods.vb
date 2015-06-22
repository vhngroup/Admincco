Imports System.Windows.Forms.ErrorProvider
Imports System.Text.RegularExpressions
Public Class frmvalorods
    Public valornet As Double = 0 ' traer el valor del contrato
    Public impservicio1 As String 'trae el nombre del servicio
    Public imptext1 As Double 'trae el codigo del servicio
    Public ident As Double = 0 'ubica de donde se realizo el click
    Private Sub frmservicios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        txtvalorcontcart.Text = frmactualizarods.valorcontracto
        contratonumero.Text = frmactualizarods.contractonumber
        vrmacro.Enabled = False
        btnaceptar.Enabled = False
        btncancelar.Enabled = True
        WindowState = FormWindowState.Normal
        If servicio1.Text = 0 Then
            costod1.Enabled = False
        End If
        If servicio2.Text = 0 Then
            costod2.Enabled = False
        End If
        If servicio3.Text = 0 Then
            costod3.Enabled = False

        End If
        If servicio4.Text = 0 Then
            costod4.Enabled = False

        End If
        If servicio5.Text = 0 Then
            costod5.Enabled = False

        End If
        If servicio6.Text = 0 Then
            costod6.Enabled = False

        End If
        If servicio7.Text = 0 Then
            costod7.Enabled = False

        End If
        If servicio8.Text = 0 Then
            costod8.Enabled = False

        End If

    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnaceptar.Click
        guardar()
        frmactualizarods.modo1 = 4
        frmactualizarods.validar()
        Me.Close()
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
            iva1.Text = FormatNumber(Admin1.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 16%
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
            iva2.Text = FormatNumber(Admin2.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 26%
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
            iva3.Text = FormatNumber(admin3.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 36%
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
            iva4.Text = FormatNumber(Admin4.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 46%
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
            iva5.Text = FormatNumber(Admin5.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 56%
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
            iva6.Text = FormatNumber(Admin6.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 66%
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
    End Sub


    Private Sub calculo7()

        If servicio7.Text = "" Then servicio7.Text = 0 ' Verifica que no este vacio

        If servicio7.Text = 1 Then ' Verifica el tipo de servicio, 7 7 o 7
            a7.Enabled = True
            i7.Enabled = True
            u7.Enabled = True
            If a7.Text <> "" Then ' Administracion 
                If a7.Text = 0 Then
                    Admin7.Text = 0
                Else
                    Admin7.Text = FormatNumber(CDbl(costod7.Text) * CDbl(a7.Text) / 100)
                End If
            Else
                a7.Text = 0
                Admin7.Text = 0
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

            subt7.Text = FormatNumber(CDbl(costod7.Text) + CDbl(Admin7.Text) + CDbl(impre7.Text) + CDbl(util7.Text))
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
                    Admin7.Text = 0
                Else
                    Admin7.Text = FormatNumber(CDbl(costod7.Text) * CDbl(a7.Text) / 100)
                End If

            Else
                a7.Text = 0
                Admin7.Text = 0
            End If
            subt7.Text = FormatNumber(CDbl(costod7.Text) + CDbl(Admin7.Text) + CDbl(util7.Text))
            iva7.Text = FormatNumber(Admin7.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 77%
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
            Admin7.Text = 0
            subt7.Text = FormatNumber(CDbl(costod7.Text))
            iva7.Text = FormatNumber(CDbl(subt7.Text) * 0.16)
            total7.Text = FormatNumber(CDbl(iva7.Text) + CDbl(subt7.Text))
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
            iva8.Text = FormatNumber(Admin8.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 88%
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
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            q1.Text = FormatNumber(CDbl(TextBox1.Text) - CDbl(total1.Text))
            q2.Text = FormatNumber(CDbl(TextBox2.Text) - CDbl(total2.Text))
            q3.Text = FormatNumber(CDbl(TextBox3.Text) - CDbl(total3.Text))
            q4.Text = FormatNumber(CDbl(TextBox4.Text) - CDbl(total4.Text))
            q5.Text = FormatNumber(CDbl(TextBox5.Text) - CDbl(total5.Text))
            q6.Text = FormatNumber(CDbl(TextBox6.Text) - CDbl(total6.Text))
            q7.Text = FormatNumber(CDbl(TextBox7.Text) - CDbl(total7.Text))
            q8.Text = FormatNumber(CDbl(TextBox8.Text) - CDbl(total8.Text))
            constante()
            desviacion.Text = FormatNumber(CDbl(txtvalorcontcart.Text) - CDbl(vrgtotal.Text))
            If CDbl(vrgtotal.Text) > CDbl(txtvalorcontcart.Text) Then
                Label85.Text = ("Verifique la estructura del contrato" & " " & desviacion.Text)
                CheckBox1.Checked = False
            ElseIf q1.Text < CDbl(0) Or q2.Text < CDbl(0) Or q3.Text < CDbl(0) Or q4.Text < CDbl(0) Then
                Label85.Text = ("Usted tiene alertas activas, verifiquelas.")
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
            End If
        End If
        If CheckBox1.Checked = False Then
            btnaceptar.Enabled = False
            Label85.Text = ""
            nivel1.Enabled = True
            nivel2.Enabled = True
            nivel3.Enabled = True
            nivel4.Enabled = True
            nivel5.Enabled = True
            nivel6.Enabled = True
            nivel7.Enabled = True
            nivel8.Enabled = True
        End If
    End Sub
    Friend Sub guardar()
        calcular()
        frmactualizarods.servicio2(0) = servicio1.Text
        frmactualizarods.servicio2(1) = servicio2.Text
        frmactualizarods.servicio2(2) = servicio3.Text
        frmactualizarods.servicio2(3) = servicio4.Text
        frmactualizarods.servicio2(4) = servicio5.Text
        frmactualizarods.servicio2(5) = servicio6.Text
        frmactualizarods.servicio2(6) = servicio7.Text
        frmactualizarods.servicio2(7) = servicio8.Text
        frmactualizarods.nservicio2(0) = nservicio1.Text
        frmactualizarods.nservicio2(1) = nservicio2.Text
        frmactualizarods.nservicio2(2) = nservicio3.Text
        frmactualizarods.nservicio2(3) = nservicio4.Text
        frmactualizarods.nservicio2(4) = nservicio5.Text
        frmactualizarods.nservicio2(5) = nservicio6.Text
        frmactualizarods.nservicio2(6) = nservicio7.Text
        frmactualizarods.nservicio2(7) = nservicio8.Text
        frmactualizarods.costod2(0) = FormatNumber(CDbl(costod1.Text))
        frmactualizarods.costod2(1) = FormatNumber(CDbl(costod2.Text))
        frmactualizarods.costod2(2) = FormatNumber(CDbl(costod3.Text))
        frmactualizarods.costod2(3) = FormatNumber(CDbl(costod4.Text))
        frmactualizarods.costod2(4) = FormatNumber(CDbl(costod5.Text))
        frmactualizarods.costod2(5) = FormatNumber(CDbl(costod6.Text))
        frmactualizarods.costod2(6) = FormatNumber(CDbl(costod7.Text))
        frmactualizarods.costod2(7) = FormatNumber(CDbl(costod8.Text))
        frmactualizarods.admin2(0) = FormatNumber(CDbl(Admin1.Text))
        frmactualizarods.admin2(1) = FormatNumber(CDbl(admin2.Text))
        frmactualizarods.admin2(2) = FormatNumber(CDbl(admin3.Text))
        frmactualizarods.admin2(3) = FormatNumber(CDbl(admin4.Text))
        frmactualizarods.admin2(4) = FormatNumber(CDbl(admin5.Text))
        frmactualizarods.admin2(5) = FormatNumber(CDbl(admin6.Text))
        frmactualizarods.admin2(6) = FormatNumber(CDbl(admin7.Text))
        frmactualizarods.admin2(7) = FormatNumber(CDbl(admin8.Text))
        frmactualizarods.impre2(0) = FormatNumber(CDbl(impre1.Text))
        frmactualizarods.impre2(1) = FormatNumber(CDbl(impre2.Text))
        frmactualizarods.impre2(2) = FormatNumber(CDbl(impre3.Text))
        frmactualizarods.impre2(3) = FormatNumber(CDbl(impre4.Text))
        frmactualizarods.impre2(4) = FormatNumber(CDbl(impre5.Text))
        frmactualizarods.impre2(5) = FormatNumber(CDbl(impre6.Text))
        frmactualizarods.impre2(6) = FormatNumber(CDbl(impre7.Text))
        frmactualizarods.impre2(7) = FormatNumber(CDbl(impre8.Text))
        frmactualizarods.util2(0) = FormatNumber(CDbl(util1.Text))
        frmactualizarods.util2(1) = FormatNumber(CDbl(util2.Text))
        frmactualizarods.util2(2) = FormatNumber(CDbl(util3.Text))
        frmactualizarods.util2(3) = FormatNumber(CDbl(util4.Text))
        frmactualizarods.util2(4) = FormatNumber(CDbl(util5.Text))
        frmactualizarods.util2(5) = FormatNumber(CDbl(util6.Text))
        frmactualizarods.util2(6) = FormatNumber(CDbl(util7.Text))
        frmactualizarods.util2(7) = FormatNumber(CDbl(util8.Text))
        frmactualizarods.subt2(0) = FormatNumber(CDbl(subt1.Text))
        frmactualizarods.subt2(1) = FormatNumber(CDbl(subt2.Text))
        frmactualizarods.subt2(2) = FormatNumber(CDbl(subt3.Text))
        frmactualizarods.subt2(3) = FormatNumber(CDbl(subt4.Text))
        frmactualizarods.subt2(4) = FormatNumber(CDbl(subt5.Text))
        frmactualizarods.subt2(5) = FormatNumber(CDbl(subt6.Text))
        frmactualizarods.subt2(6) = FormatNumber(CDbl(subt7.Text))
        frmactualizarods.subt2(7) = FormatNumber(CDbl(subt8.Text))
        frmactualizarods.iva2(0) = FormatNumber(CDbl(iva1.Text))
        frmactualizarods.iva2(1) = FormatNumber(CDbl(iva2.Text))
        frmactualizarods.iva2(2) = FormatNumber(CDbl(iva3.Text))
        frmactualizarods.iva2(3) = FormatNumber(CDbl(iva4.Text))
        frmactualizarods.iva2(4) = FormatNumber(CDbl(iva5.Text))
        frmactualizarods.iva2(5) = FormatNumber(CDbl(iva6.Text))
        frmactualizarods.iva2(6) = FormatNumber(CDbl(iva7.Text))
        frmactualizarods.iva2(7) = FormatNumber(CDbl(iva8.Text))
        frmactualizarods.total2(0) = FormatNumber(CDbl(total1.Text))
        frmactualizarods.total2(1) = FormatNumber(CDbl(total2.Text))
        frmactualizarods.total2(2) = FormatNumber(CDbl(total3.Text))
        frmactualizarods.total2(3) = FormatNumber(CDbl(total4.Text))
        frmactualizarods.total2(4) = FormatNumber(CDbl(total5.Text))
        frmactualizarods.total2(5) = FormatNumber(CDbl(total6.Text))
        frmactualizarods.total2(6) = FormatNumber(CDbl(total7.Text))
        frmactualizarods.total2(7) = FormatNumber(CDbl(total8.Text))
        frmactualizarods.a2(0) = FormatNumber(CDbl(a1.Text))
        frmactualizarods.a2(1) = FormatNumber(CDbl(a2.Text))
        frmactualizarods.a2(2) = FormatNumber(CDbl(a3.Text))
        frmactualizarods.a2(3) = FormatNumber(CDbl(a4.Text))
        frmactualizarods.a2(4) = FormatNumber(CDbl(a5.Text))
        frmactualizarods.a2(5) = FormatNumber(CDbl(a6.Text))
        frmactualizarods.a2(6) = FormatNumber(CDbl(a7.Text))
        frmactualizarods.a2(7) = FormatNumber(CDbl(a8.Text))
        frmactualizarods.i2(0) = FormatNumber(CDbl(i1.Text))
        frmactualizarods.i2(1) = FormatNumber(CDbl(i2.Text))
        frmactualizarods.i2(2) = FormatNumber(CDbl(i3.Text))
        frmactualizarods.i2(3) = FormatNumber(CDbl(i4.Text))
        frmactualizarods.i2(4) = FormatNumber(CDbl(i5.Text))
        frmactualizarods.i2(5) = FormatNumber(CDbl(i6.Text))
        frmactualizarods.i2(6) = FormatNumber(CDbl(i7.Text))
        frmactualizarods.i2(7) = FormatNumber(CDbl(i8.Text))
        frmactualizarods.u2(0) = FormatNumber(CDbl(u1.Text))
        frmactualizarods.u2(1) = FormatNumber(CDbl(u2.Text))
        frmactualizarods.u2(2) = FormatNumber(CDbl(u3.Text))
        frmactualizarods.u2(3) = FormatNumber(CDbl(u4.Text))
        frmactualizarods.u2(4) = FormatNumber(CDbl(u5.Text))
        frmactualizarods.u2(5) = FormatNumber(CDbl(u6.Text))
        frmactualizarods.u2(6) = FormatNumber(CDbl(u7.Text))
        frmactualizarods.u2(7) = FormatNumber(CDbl(u8.Text))
        frmactualizarods.cosdirecto = FormatNumber(CDbl(txtcostdglobal.Text))
        frmactualizarods.imptxtcostadminglobal = FormatNumber(CDbl(txtcostadminglobal.Text))
        frmactualizarods.imptxtcostimpglobal = FormatNumber(CDbl(txtcostimpglobal.Text))
        frmactualizarods.imptxtcostutilglobal = FormatNumber(CDbl(txtcostutilglobal.Text))
        frmactualizarods.imptxtcostsubglobal = FormatNumber(CDbl(txtcostsubglobal.Text))
        frmactualizarods.imptxtcostivaglobal = FormatNumber(CDbl(txtcostivaglobal.Text))
        frmactualizarods.impvrgtotal = FormatNumber(CDbl(vrgtotal.Text))
        frmactualizarods.nv(0) = FormatNumber(CDbl(q1.Text))
        frmactualizarods.nv(1) = FormatNumber(CDbl(q2.Text))
        frmactualizarods.nv(2) = FormatNumber(CDbl(q3.Text))
        frmactualizarods.nv(3) = FormatNumber(CDbl(q4.Text))
        frmactualizarods.nv(4) = FormatNumber(CDbl(q5.Text))
        frmactualizarods.nv(5) = FormatNumber(CDbl(q6.Text))
        frmactualizarods.nv(6) = FormatNumber(CDbl(q7.Text))
        frmactualizarods.nv(7) = FormatNumber(CDbl(q8.Text))
        Me.Close()
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
                                        If txtvalorcontcart.Text = "" Then
                                        Else
                                            calculo1()
                                            calculo2()
                                            calculo3()
                                            calculo4()
                                            calculo5()
                                            calculo6()
                                            calculo7()
                                            calculo8()
                                            txtcostdglobal.Text = FormatNumber(CDbl(costod1.Text) + CDbl(costod2.Text) + CDbl(costod3.Text) + CDbl(costod4.Text) + CDbl(costod5.Text) + CDbl(costod6.Text) + CDbl(costod7.Text) + CDbl(costod8.Text))
                                            txtcostadminglobal.Text = FormatNumber(CDbl(Admin1.Text) + CDbl(admin2.Text) + CDbl(admin3.Text) + CDbl(admin4.Text) + CDbl(admin5.Text) + CDbl(admin6.Text) + CDbl(admin7.Text) + CDbl(admin8.Text))
                                            txtcostimpglobal.Text = FormatNumber(CDbl(impre1.Text) + CDbl(impre2.Text) + CDbl(impre3.Text) + CDbl(impre4.Text) + CDbl(impre5.Text) + CDbl(impre6.Text) + CDbl(impre7.Text) + CDbl(impre8.Text))
                                            txtcostutilglobal.Text = FormatNumber(CDbl(util1.Text) + CDbl(util2.Text) + CDbl(util3.Text) + CDbl(util4.Text) + CDbl(util5.Text) + CDbl(util6.Text) + CDbl(util7.Text) + CDbl(util8.Text))
                                            txtcostsubglobal.Text = FormatNumber(CDbl(subt1.Text) + CDbl(subt2.Text) + CDbl(subt3.Text) + CDbl(subt4.Text) + CDbl(subt5.Text) + CDbl(subt6.Text) + CDbl(subt7.Text) + CDbl(subt8.Text))
                                            txtcostivaglobal.Text = FormatNumber(CDbl(iva1.Text) + CDbl(iva2.Text) + CDbl(iva3.Text) + CDbl(iva4.Text) + CDbl(iva5.Text) + CDbl(iva6.Text) + CDbl(iva7.Text) + CDbl(iva8.Text))
                                            vrgtotal.Text = FormatNumber(CDbl(total1.Text) + CDbl(total2.Text) + CDbl(total3.Text) + CDbl(total4.Text) + CDbl(total5.Text) + CDbl(total6.Text) + CDbl(total7.Text) + CDbl(total8.Text))
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
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

    Private Sub txtcostdglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostdglobal.TextChanged
        If txtcostdglobal.Text = "" Then txtcostdglobal.Text = 0
        txtcostdglobal.Text = FormatNumber(CDbl(txtcostdglobal.Text), 2)
    End Sub

    Private Sub txtcostadminglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostadminglobal.TextChanged
        If txtcostadminglobal.Text = "" Then txtcostadminglobal.Text = 0
        txtcostadminglobal.Text = FormatNumber(CDbl(txtcostadminglobal.Text), 2)
    End Sub

    Private Sub txtcostimpglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostimpglobal.TextChanged
        If txtcostimpglobal.Text = "" Then txtcostimpglobal.Text = 0
        txtcostimpglobal.Text = FormatNumber(CDbl(txtcostimpglobal.Text), 2)
    End Sub

    Private Sub txtcostutilglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostutilglobal.TextChanged
        If txtcostutilglobal.Text = "" Then txtcostutilglobal.Text = 0
        txtcostutilglobal.Text = FormatNumber(CDbl(txtcostutilglobal.Text), 2)
    End Sub

    Private Sub txtcostsubglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostsubglobal.TextChanged
        If txtcostsubglobal.Text = "" Then txtcostsubglobal.Text = 0
        txtcostsubglobal.Text = FormatNumber(CDbl(txtcostsubglobal.Text), 2)
    End Sub

    Private Sub txtcostivaglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostivaglobal.TextChanged
        If txtcostivaglobal.Text = "" Then txtcostivaglobal.Text = 0
        txtcostivaglobal.Text = FormatNumber(CDbl(txtcostivaglobal.Text), 2)
    End Sub

    Private Sub vrgtotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles vrgtotal.TextChanged
        If vrgtotal.Text = "" Then vrgtotal.Text = 0
        vrgtotal.Text = FormatNumber(CDbl(vrgtotal.Text), 2)
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then TextBox1.Text = 0
        TextBox1.Text = FormatNumber(CDbl(TextBox1.Text), 2)
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then TextBox2.Text = 0
        TextBox2.Text = FormatNumber(CDbl(TextBox2.Text), 2)
    End Sub
    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then TextBox3.Text = 0
        TextBox3.Text = FormatNumber(CDbl(TextBox3.Text), 2)
    End Sub
    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text = "" Then TextBox4.Text = 0
        TextBox4.Text = FormatNumber(CDbl(TextBox4.Text), 2)
    End Sub
    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = "" Then TextBox5.Text = 0
        TextBox5.Text = FormatNumber(CDbl(TextBox5.Text), 2)
        
    End Sub
    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then TextBox6.Text = 0
        TextBox6.Text = FormatNumber(CDbl(TextBox6.Text), 2)
        
    End Sub
    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text = "" Then TextBox7.Text = 0
        TextBox7.Text = FormatNumber(CDbl(TextBox7.Text), 2)
        
    End Sub
    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "" Then TextBox8.Text = 0
        TextBox8.Text = FormatNumber(CDbl(TextBox8.Text), 2)
    End Sub

    Private Sub q1_TextChanged(sender As System.Object, e As System.EventArgs) Handles q1.TextChanged
        If q1.Text = "" Then q1.Text = 0
        q1.Text = FormatNumber(CDbl(q1.Text), 2)
        If q1.Text < 0 Then
            Me.ErrorProvider1.SetError(q1, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub q2_TextChanged(sender As System.Object, e As System.EventArgs) Handles q2.TextChanged
        If q2.Text = "" Then q2.Text = 0
        q2.Text = FormatNumber(CDbl(q2.Text), 2)
        If q2.Text < 0 Then
            Me.ErrorProvider2.SetError(q2, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider2.Clear()
        End If
    End Sub

    Private Sub q3_TextChanged(sender As System.Object, e As System.EventArgs) Handles q3.TextChanged
        If q3.Text = "" Then q3.Text = 0
        q3.Text = FormatNumber(CDbl(q3.Text), 2)
        If q3.Text < 0 Then
            Me.ErrorProvider3.SetError(q3, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider3.Clear()
        End If
    End Sub

    Private Sub q4_TextChanged(sender As System.Object, e As System.EventArgs) Handles q4.TextChanged
        If q4.Text = "" Then q4.Text = 0
        q4.Text = FormatNumber(CDbl(q4.Text), 2)
        If q4.Text < 0 Then
            Me.ErrorProvider4.SetError(q4, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider4.Clear()
        End If
    End Sub

    Private Sub q5_TextChanged(sender As System.Object, e As System.EventArgs) Handles q5.TextChanged
        If q5.Text = "" Then q5.Text = 0
        q5.Text = FormatNumber(CDbl(q5.Text), 2)
        If q5.Text < 0 Then
            Me.ErrorProvider5.SetError(q5, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider5.Clear()
        End If
    End Sub

    Private Sub q6_TextChanged(sender As System.Object, e As System.EventArgs) Handles q6.TextChanged
        If q6.Text = "" Then q6.Text = 0
        q6.Text = FormatNumber(CDbl(q6.Text), 2)
        If q6.Text < 0 Then
            Me.ErrorProvider6.SetError(q6, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider6.Clear()
        End If
    End Sub

    Private Sub q7_TextChanged(sender As System.Object, e As System.EventArgs) Handles q7.TextChanged
        If q7.Text = "" Then q7.Text = 0
        q7.Text = FormatNumber(CDbl(q7.Text), 2)
        If q7.Text < 0 Then
            Me.ErrorProvider7.SetError(q7, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider7.Clear()
        End If
    End Sub

    Private Sub q8_TextChanged(sender As System.Object, e As System.EventArgs) Handles q8.TextChanged
        If q8.Text = "" Then q8.Text = 0
        q8.Text = FormatNumber(CDbl(q8.Text), 2)
        If q8.Text < 0 Then
            Me.ErrorProvider8.SetError(q8, "no tiene saldo para realizar esta operación")
        Else
            Me.ErrorProvider8.Clear()
        End If
    End Sub

    Private Sub desviacion_TextChanged(sender As System.Object, e As System.EventArgs) Handles desviacion.TextChanged
        If desviacion.Text = "" Then desviacion.Text = 0
        desviacion.Text = FormatNumber(CDbl(desviacion.Text), 2)
    End Sub
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
    Private Sub txtvalorcontcart_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtvalorcontcart.TextChanged
        If txtvalorcontcart.Text = "" Then txtvalorcontcart.Text = 0
    End Sub

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
    Private Sub calcular()
        REM graba grupo 1
        frmactualizarods.impcostod(0) = FormatNumber(CDbl(Label106.Text) - CDbl(costod1.Text))
        frmactualizarods.impadmin(0) = FormatNumber(CDbl(Label107.Text) - CDbl(Admin1.Text))
        frmactualizarods.impimpre(0) = FormatNumber(CDbl(Label108.Text) - CDbl(impre1.Text))
        frmactualizarods.imputil(0) = FormatNumber(CDbl(Label109.Text) - CDbl(util1.Text))
        frmactualizarods.impsubtotal(0) = FormatNumber(CDbl(Label110.Text) - CDbl(subt1.Text))
        frmactualizarods.impiva(0) = FormatNumber(CDbl(Label111.Text) - CDbl(iva1.Text))
        frmactualizarods.imptotal(0) = FormatNumber(CDbl(Label112.Text) - CDbl(total1.Text))
        REM graba grupo 2
        frmactualizarods.impcostod(1) = FormatNumber(CDbl(Label113.Text) - CDbl(costod2.Text))
        frmactualizarods.impadmin(1) = FormatNumber(CDbl(Label114.Text) - CDbl(admin2.Text))
        frmactualizarods.impimpre(1) = FormatNumber(CDbl(Label115.Text) - CDbl(impre2.Text))
        frmactualizarods.imputil(1) = FormatNumber(CDbl(Label116.Text) - CDbl(util2.Text))
        frmactualizarods.impsubtotal(1) = FormatNumber(CDbl(Label117.Text) - CDbl(subt2.Text))
        frmactualizarods.impiva(1) = FormatNumber(CDbl(Label118.Text) - CDbl(iva2.Text))
        frmactualizarods.imptotal(1) = FormatNumber(CDbl(Label119.Text) - CDbl(total2.Text))
        REM graba grupo 3
        frmactualizarods.impcostod(2) = FormatNumber(CDbl(Label120.Text) - CDbl(costod3.Text))
        frmactualizarods.impadmin(2) = FormatNumber(CDbl(Label121.Text) - CDbl(admin3.Text))
        frmactualizarods.impimpre(2) = FormatNumber(CDbl(Label122.Text) - CDbl(impre3.Text))
        frmactualizarods.imputil(2) = FormatNumber(CDbl(Label123.Text) - CDbl(util3.Text))
        frmactualizarods.impsubtotal(2) = FormatNumber(CDbl(Label124.Text) - CDbl(subt3.Text))
        frmactualizarods.impiva(2) = FormatNumber(CDbl(Label125.Text) - CDbl(iva3.Text))
        frmactualizarods.imptotal(2) = FormatNumber(CDbl(Label126.Text) - CDbl(total3.Text))
        REM graba grupo 4
        frmactualizarods.impcostod(3) = FormatNumber(CDbl(Label127.Text) - CDbl(costod4.Text))
        frmactualizarods.impadmin(3) = FormatNumber(CDbl(Label128.Text) - CDbl(admin4.Text))
        frmactualizarods.impimpre(3) = FormatNumber(CDbl(Label129.Text) - CDbl(impre4.Text))
        frmactualizarods.imputil(3) = FormatNumber(CDbl(Label130.Text) - CDbl(util4.Text))
        frmactualizarods.impsubtotal(3) = FormatNumber(CDbl(Label131.Text) - CDbl(subt4.Text))
        frmactualizarods.impiva(3) = FormatNumber(CDbl(Label132.Text) - CDbl(iva4.Text))
        frmactualizarods.imptotal(3) = FormatNumber(CDbl(Label133.Text) - CDbl(total4.Text))
        REM graba grupo 5
        frmactualizarods.impcostod(4) = FormatNumber(CDbl(Label134.Text) - CDbl(costod5.Text))
        frmactualizarods.impadmin(4) = FormatNumber(CDbl(Label135.Text) - CDbl(admin5.Text))
        frmactualizarods.impimpre(4) = FormatNumber(CDbl(Label136.Text) - CDbl(impre5.Text))
        frmactualizarods.imputil(4) = FormatNumber(CDbl(Label137.Text) - CDbl(util5.Text))
        frmactualizarods.impsubtotal(4) = FormatNumber(CDbl(Label138.Text) - CDbl(subt5.Text))
        frmactualizarods.impiva(4) = FormatNumber(CDbl(Label139.Text) - CDbl(iva5.Text))
        frmactualizarods.imptotal(4) = FormatNumber(CDbl(Label140.Text) - CDbl(total5.Text))
        REM graba grupo 6
        frmactualizarods.impcostod(5) = FormatNumber(CDbl(Label141.Text) - CDbl(costod6.Text))
        frmactualizarods.impadmin(5) = FormatNumber(CDbl(Label142.Text) - CDbl(admin6.Text))
        frmactualizarods.impimpre(5) = FormatNumber(CDbl(Label143.Text) - CDbl(impre6.Text))
        frmactualizarods.imputil(5) = FormatNumber(CDbl(Label144.Text) - CDbl(util6.Text))
        frmactualizarods.impsubtotal(5) = FormatNumber(CDbl(Label145.Text) - CDbl(subt6.Text))
        frmactualizarods.impiva(5) = FormatNumber(CDbl(Label146.Text) - CDbl(iva6.Text))
        frmactualizarods.imptotal(5) = FormatNumber(CDbl(Label147.Text) - CDbl(total6.Text))
        REM graba grupo 7
        frmactualizarods.impcostod(6) = FormatNumber(CDbl(Label148.Text) - CDbl(costod7.Text))
        frmactualizarods.impadmin(6) = FormatNumber(CDbl(Label149.Text) - CDbl(admin7.Text))
        frmactualizarods.impimpre(6) = FormatNumber(CDbl(Label150.Text) - CDbl(impre7.Text))
        frmactualizarods.imputil(6) = FormatNumber(CDbl(Label151.Text) - CDbl(util7.Text))
        frmactualizarods.impsubtotal(6) = FormatNumber(CDbl(Label152.Text) - CDbl(subt7.Text))
        frmactualizarods.impiva(6) = FormatNumber(CDbl(Label153.Text) - CDbl(iva7.Text))
        frmactualizarods.imptotal(6) = FormatNumber(CDbl(Label154.Text) - CDbl(total7.Text))
        REM graba grupo 8
        frmactualizarods.impcostod(7) = FormatNumber(CDbl(Label155.Text) - CDbl(costod8.Text))
        frmactualizarods.impadmin(7) = FormatNumber(CDbl(Label156.Text) - CDbl(admin8.Text))
        frmactualizarods.impimpre(7) = FormatNumber(CDbl(Label157.Text) - CDbl(impre8.Text))
        frmactualizarods.imputil(7) = FormatNumber(CDbl(Label158.Text) - CDbl(util8.Text))
        frmactualizarods.impsubtotal(7) = FormatNumber(CDbl(Label159.Text) - CDbl(subt8.Text))
        frmactualizarods.impiva(7) = FormatNumber(CDbl(Label160.Text) - CDbl(iva8.Text))
        frmactualizarods.imptotal(7) = FormatNumber(CDbl(Label161.Text) - CDbl(total8.Text))
    End Sub

    Private Sub grbservicios_Enter(sender As System.Object, e As System.EventArgs) Handles grbservicios.Enter

    End Sub
End Class