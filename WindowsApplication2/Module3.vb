Imports System.Reflection

''' <summary>
''' Módulo para la compactación de bases de datos
''' Microsoft Access mediante reflexión.
''' </summary>
''' <author>Enrique Martínez Montejo - 2010</author>
''' <remarks></remarks>
Friend Module Module3
    ''' <summary>
    ''' Enumeración para la versión de la base de datos Microsoft Access.
    ''' </summary>
    ''' <remarks></remarks>
    <System.CLSCompliant(True), System.Flags()> _
    Public Enum AccessDatabaseTypeEnum
        ''' <summary>
        ''' Descifra la base de datos mientras se compacta.
        ''' </summary>
        dbDecrypt = 4
        ''' <summary>
        ''' Cifra la base de datos.
        ''' </summary>
        dbEncrypt = 2
        ''' <summary>
        ''' Motor de base de datos Microsoft Jet versión 1.0.
        ''' </summary>
        dbVersion10 = 1
        ''' <summary>
        ''' Motor de base de datos Microsoft Jet versión 1.1.
        ''' </summary>
        dbVersion11 = 8
        ''' <summary>
        ''' Motor de base de datos Microsoft Access 12.0 (Access 2007).
        ''' </summary>
        dbVersion120 = &H80
        ''' <summary>
        ''' Motor de base de datos Microsoft Access 14.0 (Access 2010).
        ''' </summary>
        dbVersion140 = &H100
        ''' <summary>
        ''' Motor de base de datos Microsoft Access 15.0 (Access 2013).
        ''' </summary>
        dbVersion150 = &H200
        ''' <summary>
        ''' Motor de base de datos Microsoft Jet versión 2.0.
        ''' </summary>
        dbVersion20 = &H10
        ''' <summary>
        ''' Motor de base de datos Microsoft Jet versión 3.0 (Access 95-97).
        ''' </summary>
        dbVersion30 = &H20
        ''' <summary>
        ''' Motor de base de datos Microsoft Jet versión 4.0 (Access 2000-2003).
        ''' </summary>
        dbVersion40 = &H40
    End Enum

    ''' <summary>
    ''' Compacta una base de datos Microsoft Accesss.
    ''' </summary>
    ''' <param name="source">Base de datos que se desea compactar.</param>
    ''' <param name="pwdSource">Contraseña de la base de datos de origen.</param>
    ''' <param name="destiny">Base de datos de destino de la compactación.</param>
    ''' <param name="pwdDestiny">Contraseña de la base de datos de destino.</param>
    ''' <param name="version">Versión de la base de datos compactada.</param>
    ''' <remarks></remarks>
    Friend Sub CompactDataBase(source As String, _
                               pwdSource As String, _
                               destiny As String, _
                               pwdDestiny As String, _
                               version As AccessDatabaseTypeEnum)

        ' NOTA: me decido a aplicar la misma técnica que utiliza Access 2007. Si
        ' la base de destino tiene una contraseña, ésta se cifrará (dbEncrypt),
        ' y si no tiene contraseña se descifrará (dbDecrypt).
        '
        ' Si la versión de la base de datos de destino es inferior a Access 2007, hay
        ' que especificar explícitamente los valores dbEncrypt/dbDecrypt para cifrar o
        ' descifrar, respectivamente, la base de datos.
        '
        ' Sólo se puede compactar la base de datos de destino, con una versión
        ' que sea la misma o superior a la de la base de datos original.
        '
        ' NOTA IMPORTANTE: se compactará utilizando la versión actual de la biblioteca
        ' de DAO que actualmente se encuentre instalada en el equipo. Quiere esto decir
        ' que si en el mismo equipo están instalados Access 2007, Access 2010 y
        ' Access 2013, prevalecerá la versión de DAO de la última instalación, o de la
        ' última versión que se haya utilizado de Microsoft Access. 
        '
        ' Si la última versión de Access instalada o utilizada fue la 2010 ó 2013,
        ' la base de datos resultante de la compactación puede que no se
        ' reconozca por Microsoft Access 2007, sobre todo si se le ha
        ' asignado una contraseña a la base de datos de destino.
        '
        Dim dbe As Object = Nothing
        Try
            ' Creo mediante reflexión un objeto DAO.DBEngine mediante su ProgId.
            '
            Dim ty As System.Type = Nothing
            dbe = CreateObject("DAO.DBEngine.120", ty)

            If (dbe Is Nothing) Then _
                Throw New Runtime.InteropServices.COMException( _
                "No se encuentra instalado el motor de bases de datos Microsoft ACE.")

            ' Obtengo un nombre de un archivo temporal que será el
            ' que albergará la base de datos compactada.
            '
            Dim tempFile As String = IO.Path.GetTempFileName()

            ' Elimino el archivo temporal.
            '
            IO.File.Delete(tempFile)

            Dim locale As String = ";LANGID=0x0409;CP=1252;COUNTRY=0"
            Dim encrypt As Boolean

            ' Si procede le asigno a la variable Locale la contraseña de
            ' la base de datos de destino. Si a ésta última base de datos
            ' no se le ha asignado explícitamente una contraseña, al
            ' compactar se le asignará la misma contraseña que tenga la
            ' base de datos de origen, siempre y cuando está última
            ' base de datos tenga establecida alguna.
            '
            If (pwdDestiny <> String.Empty) Then
                locale &= ";pwd=" & pwdDestiny
                encrypt = True
            End If

            ' Compactamos la base de datos.
            '
            Dim args() As Object = {source, tempFile, locale, version}

            If (pwdSource <> String.Empty) Then
                ' La base de origen tiene contraseña.
                '
                ' ¿Es inferior a Access 2007-2013?
                '
                Dim isNotAccess2007 As Boolean = _
                    ((version <> AccessDatabaseTypeEnum.dbVersion120) AndAlso _
                     (version <> AccessDatabaseTypeEnum.dbVersion140) AndAlso _
                     (version <> AccessDatabaseTypeEnum.dbVersion150))

                If ((isNotAccess2007) AndAlso (encrypt)) Then
                    args(3) = version + AccessDatabaseTypeEnum.dbEncrypt

                ElseIf ((isNotAccess2007) AndAlso (Not encrypt)) Then
                    args(3) = version + AccessDatabaseTypeEnum.dbDecrypt

                End If

                ReDim Preserve args(4)
                args(4) = ";pwd=" & pwdSource

            End If

            Dim o As Object = ExecuteMethod(dbe, ty, "CompactDatabase", args)

            ' Si no se ha creado el archivo temporal, es porque
            ' la base de datos no se ha compactado.
            '
            If (Not IO.File.Exists(tempFile)) Then _
                Throw New Runtime.InteropServices.COMException( _
                "No se ha podido compactar la base de datos.")

            ' La base de datos se ha compactado satisfactoriamente.
            '
            ' Cuando se llame a éste método, se comprende que se desea
            ' sobrescribir un archivo existente. Compruebo si existe
            ' la base de datos de destino.
            '
            If (IO.File.Exists(destiny)) Then
                ' Elimino el archivo
                IO.File.Delete(destiny)
            End If

            ' Mueve el archivo temporal a la carpeta de destino.
            '
            IO.File.Move(tempFile, destiny)

        Catch ex As Exception
            Throw

        Finally
            ' Disminuimos el contador de referencias y liberamos
            ' la referencia al objeto.
            Runtime.InteropServices.Marshal.FinalReleaseComObject(dbe)
            dbe = Nothing

        End Try

    End Sub

    ''' <summary>
    ''' Crea y devuelve una referencia al objeto COM especificado.
    ''' </summary>
    ''' <param name="progId">Nombre correspondiente al ProgId del objeto COM que se desea obtener.</param>
    ''' <param name="ty">Se devolverá el tipo asociado al identificador de programa especificado.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateObject(progId As String, ByRef ty As System.Type) As Object

        Try
            ' Obtenemos el tipo asociado al identificador de programa
            ' (ProgID) especificado.
            '
            ty = Type.GetTypeFromProgID(progId)

            If (ty Is Nothing) Then Return Nothing

            ' Creamos la instancia del tipo de objeto especificado.
            '
            Dim o As Object = Activator.CreateInstance(ty)

            Return o

        Catch ex As Exception
            Throw

        End Try

    End Function

    ''' <summary>
    ''' Ejecuta el método del objeto COM especificado.
    ''' </summary>
    ''' <param name="app">Instancia del objeto COM cuya método se desea ejecutar.</param>
    ''' <param name="ty">El tipo asociado al programa especificado.</param>
    ''' <param name="methodName">Nombre del método que se desea ejecutar.</param>
    ''' <param name="args">Matriz que contiene los argumentos que se van
    ''' a pasar al método que se desea ejecutar.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExecuteMethod(app As Object, _
                                   ty As System.Type, _
                                   methodName As String, _
                                   args() As Object) As Object

        If ((app Is Nothing) OrElse _
            (ty Is Nothing)) Then Return Nothing

        Try
            ' Ejecuto el método especificado.
            '
            Dim o As Object = ty.InvokeMember( _
                methodName, _
                BindingFlags.DeclaredOnly Or BindingFlags.Public Or _
                BindingFlags.NonPublic Or BindingFlags.Instance Or _
                BindingFlags.IgnoreCase Or BindingFlags.InvokeMethod, _
                Nothing, _
                app, _
                args)

            Return o

        Catch ex As Exception
            ' Me inclino por devolver la excepción
            Throw

        End Try

    End Function

End Module
