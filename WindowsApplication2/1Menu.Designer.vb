<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
   

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmenu))
        Me.grplogin = New System.Windows.Forms.GroupBox()
        Me.lblroll = New System.Windows.Forms.ComboBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Adminco_MasterDataSet = New WindowsApplication1.Adminco_MasterDataSet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbadmin = New System.Windows.Forms.ComboBox()
        Me.chkrecord = New System.Windows.Forms.CheckBox()
        Me.btingresar = New System.Windows.Forms.Button()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MaestrosTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.MaestrosTableAdapter()
        Me.Seguridad2TableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad2TableAdapter()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.grpuser = New System.Windows.Forms.GroupBox()
        Me.btncierreods = New System.Windows.Forms.Button()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.btnautorizacion = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btcactualizar = New System.Windows.Forms.Button()
        Me.btninformes = New System.Windows.Forms.Button()
        Me.grpadmin = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btncierrecont = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btcrregistro = New System.Windows.Forms.Button()
        Me.btnmodifcont = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grrupm = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.gpreports = New System.Windows.Forms.GroupBox()
        Me.herramientas = New System.Windows.Forms.Button()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.Contador = New System.Windows.Forms.Label()
        Me.BindingSource6 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Stadistic_AdminccoDataSet = New WindowsApplication1.Stadistic_AdminccoDataSet()
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Seguridad2TableAdapter1 = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad2TableAdapter()
        Me.PersonasTableAdapter1 = New WindowsApplication1.Stadistic_AdminccoDataSetTableAdapters.PersonasTableAdapter()
        Me.EstadosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EstadosTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.estadosTableAdapter()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Seguridad4BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Seguridad4TableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad4TableAdapter()
        Me.grplogin.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpuser.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpadmin.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grrupm.SuspendLayout()
        Me.gpreports.SuspendLayout()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Stadistic_AdminccoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EstadosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Seguridad4BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grplogin
        '
        Me.grplogin.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.grplogin.BackColor = System.Drawing.SystemColors.Window
        Me.grplogin.Controls.Add(Me.lblroll)
        Me.grplogin.Controls.Add(Me.Label4)
        Me.grplogin.Controls.Add(Me.Label5)
        Me.grplogin.Controls.Add(Me.Label3)
        Me.grplogin.Controls.Add(Me.cmbadmin)
        Me.grplogin.Controls.Add(Me.chkrecord)
        Me.grplogin.Controls.Add(Me.btingresar)
        Me.grplogin.Controls.Add(Me.txtpassword)
        Me.grplogin.Controls.Add(Me.Label2)
        Me.grplogin.Controls.Add(Me.Label1)
        Me.grplogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grplogin.Location = New System.Drawing.Point(338, 19)
        Me.grplogin.Name = "grplogin"
        Me.grplogin.Size = New System.Drawing.Size(430, 196)
        Me.grplogin.TabIndex = 3
        Me.grplogin.TabStop = False
        Me.grplogin.Text = "Login de Usuario"
        '
        'lblroll
        '
        Me.lblroll.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.lblroll.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Roll", True))
        Me.lblroll.Enabled = False
        Me.lblroll.FormattingEnabled = True
        Me.lblroll.Items.AddRange(New Object() {"Administrador", "Solicitante"})
        Me.lblroll.Location = New System.Drawing.Point(139, 45)
        Me.lblroll.Name = "lblroll"
        Me.lblroll.Size = New System.Drawing.Size(168, 21)
        Me.lblroll.TabIndex = 10
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "Seguridad2"
        Me.BindingSource1.DataSource = Me.Adminco_MasterDataSet
        '
        'Adminco_MasterDataSet
        '
        Me.Adminco_MasterDataSet.DataSetName = "Adminco_MasterDataSet"
        Me.Adminco_MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Nombre", True))
        Me.Label4.Location = New System.Drawing.Point(91, 23)
        Me.Label4.MinimumSize = New System.Drawing.Size(1, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1, 13)
        Me.Label4.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Roll"
        '
        'cmbadmin
        '
        Me.cmbadmin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbadmin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbadmin.DataSource = Me.BindingSource1
        Me.cmbadmin.DisplayMember = "Usuario"
        Me.cmbadmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbadmin.Enabled = False
        Me.cmbadmin.FormattingEnabled = True
        Me.cmbadmin.Location = New System.Drawing.Point(139, 73)
        Me.cmbadmin.Name = "cmbadmin"
        Me.cmbadmin.Size = New System.Drawing.Size(164, 21)
        Me.cmbadmin.TabIndex = 1
        '
        'chkrecord
        '
        Me.chkrecord.AutoSize = True
        Me.chkrecord.Enabled = False
        Me.chkrecord.Location = New System.Drawing.Point(21, 136)
        Me.chkrecord.Name = "chkrecord"
        Me.chkrecord.Size = New System.Drawing.Size(126, 17)
        Me.chkrecord.TabIndex = 3
        Me.chkrecord.Text = "Recordar contraseña"
        Me.chkrecord.UseVisualStyleBackColor = True
        '
        'btingresar
        '
        Me.btingresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btingresar.Enabled = False
        Me.btingresar.Location = New System.Drawing.Point(147, 162)
        Me.btingresar.Name = "btingresar"
        Me.btingresar.Size = New System.Drawing.Size(135, 25)
        Me.btingresar.TabIndex = 4
        Me.btingresar.Text = "Ingresar"
        Me.btingresar.UseVisualStyleBackColor = True
        '
        'txtpassword
        '
        Me.txtpassword.Enabled = False
        Me.txtpassword.Location = New System.Drawing.Point(139, 106)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(164, 20)
        Me.txtpassword.TabIndex = 2
        Me.txtpassword.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario"
        '
        'MaestrosTableAdapter
        '
        Me.MaestrosTableAdapter.ClearBeforeFill = True
        '
        'Seguridad2TableAdapter
        '
        Me.Seguridad2TableAdapter.ClearBeforeFill = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "user_batman.png")
        Me.ImageList1.Images.SetKeyName(1, "user_chief_female.png")
        '
        'grpuser
        '
        Me.grpuser.BackColor = System.Drawing.SystemColors.Window
        Me.grpuser.Controls.Add(Me.btncierreods)
        Me.grpuser.Controls.Add(Me.PictureBox9)
        Me.grpuser.Controls.Add(Me.btnautorizacion)
        Me.grpuser.Controls.Add(Me.PictureBox4)
        Me.grpuser.Controls.Add(Me.btcactualizar)
        Me.grpuser.Enabled = False
        Me.grpuser.Location = New System.Drawing.Point(257, 88)
        Me.grpuser.Name = "grpuser"
        Me.grpuser.Size = New System.Drawing.Size(593, 63)
        Me.grpuser.TabIndex = 17
        Me.grpuser.TabStop = False
        Me.grpuser.Text = "Modulo de Ordenes de Servicio"
        Me.grpuser.Visible = False
        '
        'btncierreods
        '
        Me.btncierreods.Enabled = False
        Me.btncierreods.Image = CType(resources.GetObject("btncierreods.Image"), System.Drawing.Image)
        Me.btncierreods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncierreods.Location = New System.Drawing.Point(432, 12)
        Me.btncierreods.Name = "btncierreods"
        Me.btncierreods.Size = New System.Drawing.Size(127, 38)
        Me.btncierreods.TabIndex = 23
        Me.btncierreods.Text = "           Cierre Orden de     trabajo"
        Me.btncierreods.UseVisualStyleBackColor = True
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(394, 14)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox9.TabIndex = 25
        Me.PictureBox9.TabStop = False
        '
        'btnautorizacion
        '
        Me.btnautorizacion.Image = CType(resources.GetObject("btnautorizacion.Image"), System.Drawing.Image)
        Me.btnautorizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnautorizacion.Location = New System.Drawing.Point(223, 15)
        Me.btnautorizacion.Name = "btnautorizacion"
        Me.btnautorizacion.Size = New System.Drawing.Size(165, 32)
        Me.btnautorizacion.TabIndex = 5
        Me.btnautorizacion.Text = "       Autorizacion y Avance"
        Me.btnautorizacion.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(185, 16)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.TabIndex = 23
        Me.PictureBox4.TabStop = False
        '
        'btcactualizar
        '
        Me.btcactualizar.Image = CType(resources.GetObject("btcactualizar.Image"), System.Drawing.Image)
        Me.btcactualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcactualizar.Location = New System.Drawing.Point(36, 16)
        Me.btcactualizar.Name = "btcactualizar"
        Me.btcactualizar.Size = New System.Drawing.Size(143, 32)
        Me.btcactualizar.TabIndex = 4
        Me.btcactualizar.Text = "         Solicitud de Servicio"
        Me.btcactualizar.UseVisualStyleBackColor = True
        '
        'btninformes
        '
        Me.btninformes.Image = CType(resources.GetObject("btninformes.Image"), System.Drawing.Image)
        Me.btninformes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btninformes.Location = New System.Drawing.Point(30, 16)
        Me.btninformes.Name = "btninformes"
        Me.btninformes.Size = New System.Drawing.Size(139, 34)
        Me.btninformes.TabIndex = 6
        Me.btninformes.Text = "Reportes"
        Me.btninformes.UseVisualStyleBackColor = True
        '
        'grpadmin
        '
        Me.grpadmin.BackColor = System.Drawing.SystemColors.Window
        Me.grpadmin.Controls.Add(Me.PictureBox3)
        Me.grpadmin.Controls.Add(Me.btncierrecont)
        Me.grpadmin.Controls.Add(Me.PictureBox2)
        Me.grpadmin.Controls.Add(Me.btcrregistro)
        Me.grpadmin.Controls.Add(Me.btnmodifcont)
        Me.grpadmin.Enabled = False
        Me.grpadmin.Location = New System.Drawing.Point(257, 17)
        Me.grpadmin.Name = "grpadmin"
        Me.grpadmin.Size = New System.Drawing.Size(593, 63)
        Me.grpadmin.TabIndex = 14
        Me.grpadmin.TabStop = False
        Me.grpadmin.Text = "Modulo de Contratos Marco"
        Me.grpadmin.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(394, 14)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.TabIndex = 22
        Me.PictureBox3.TabStop = False
        '
        'btncierrecont
        '
        Me.btncierrecont.Enabled = False
        Me.btncierrecont.Image = CType(resources.GetObject("btncierrecont.Image"), System.Drawing.Image)
        Me.btncierrecont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncierrecont.Location = New System.Drawing.Point(432, 15)
        Me.btncierrecont.Name = "btncierrecont"
        Me.btncierrecont.Size = New System.Drawing.Size(127, 38)
        Me.btncierrecont.TabIndex = 3
        Me.btncierrecont.Text = "           Cierre contrato"
        Me.btncierrecont.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(184, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 21
        Me.PictureBox2.TabStop = False
        '
        'btcrregistro
        '
        Me.btcrregistro.Image = CType(resources.GetObject("btcrregistro.Image"), System.Drawing.Image)
        Me.btcrregistro.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btcrregistro.Location = New System.Drawing.Point(36, 15)
        Me.btcrregistro.Name = "btcrregistro"
        Me.btcrregistro.Size = New System.Drawing.Size(138, 37)
        Me.btcrregistro.TabIndex = 1
        Me.btcrregistro.Text = "         Registrar Contrato"
        Me.btcrregistro.UseVisualStyleBackColor = True
        '
        'btnmodifcont
        '
        Me.btnmodifcont.Image = CType(resources.GetObject("btnmodifcont.Image"), System.Drawing.Image)
        Me.btnmodifcont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmodifcont.Location = New System.Drawing.Point(222, 14)
        Me.btnmodifcont.Name = "btnmodifcont"
        Me.btnmodifcont.Size = New System.Drawing.Size(162, 38)
        Me.btnmodifcont.TabIndex = 2
        Me.btnmodifcont.Text = "  Modificar Contrato"
        Me.btnmodifcont.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(255, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 207)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modo Mantenimiento"
        Me.GroupBox1.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(594, 20)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Disculpa las molestias, estoy en mantenimiento, por favor dialoga con VNOGUERA"
        '
        'grrupm
        '
        Me.grrupm.BackColor = System.Drawing.SystemColors.Window
        Me.grrupm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.grrupm.Controls.Add(Me.GroupBox1)
        Me.grrupm.Controls.Add(Me.Button2)
        Me.grrupm.Controls.Add(Me.grplogin)
        Me.grrupm.Controls.Add(Me.gpreports)
        Me.grrupm.Controls.Add(Me.PictureBox1)
        Me.grrupm.Controls.Add(Me.grpadmin)
        Me.grrupm.Controls.Add(Me.grpuser)
        Me.grrupm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grrupm.Location = New System.Drawing.Point(13, 37)
        Me.grrupm.Name = "grrupm"
        Me.grrupm.Size = New System.Drawing.Size(867, 270)
        Me.grrupm.TabIndex = 18
        Me.grrupm.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(488, 221)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(124, 38)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Salir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'gpreports
        '
        Me.gpreports.Controls.Add(Me.herramientas)
        Me.gpreports.Controls.Add(Me.PictureBox12)
        Me.gpreports.Controls.Add(Me.Button3)
        Me.gpreports.Controls.Add(Me.btninformes)
        Me.gpreports.Enabled = False
        Me.gpreports.Location = New System.Drawing.Point(257, 156)
        Me.gpreports.Name = "gpreports"
        Me.gpreports.Size = New System.Drawing.Size(593, 63)
        Me.gpreports.TabIndex = 21
        Me.gpreports.TabStop = False
        Me.gpreports.Text = "Modulo de Reportes"
        Me.gpreports.Visible = False
        '
        'herramientas
        '
        Me.herramientas.Enabled = False
        Me.herramientas.Image = CType(resources.GetObject("herramientas.Image"), System.Drawing.Image)
        Me.herramientas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.herramientas.Location = New System.Drawing.Point(424, 15)
        Me.herramientas.Name = "herramientas"
        Me.herramientas.Size = New System.Drawing.Size(139, 34)
        Me.herramientas.TabIndex = 27
        Me.herramientas.Text = "Herramientas"
        Me.herramientas.UseVisualStyleBackColor = True
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(184, 18)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox12.TabIndex = 26
        Me.PictureBox12.TabStop = False
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button3.Location = New System.Drawing.Point(223, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(161, 36)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "     Planeador"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(245, 221)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.RichTextBox1.Location = New System.Drawing.Point(240, 2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(446, 36)
        Me.RichTextBox1.TabIndex = 21
        Me.RichTextBox1.TabStop = False
        Me.RichTextBox1.Text = "                    ADMINISTRACIÓN DE CONTRATOS " & Global.Microsoft.VisualBasic.ChrW(10) & "                 PROYECTOS MAYOR" & _
    "ES DE LOS LLANOS fase Beta"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(845, 5)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox10.TabIndex = 22
        Me.PictureBox10.TabStop = False
        '
        'Contador
        '
        Me.Contador.AutoSize = True
        Me.Contador.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource6, "Contar", True))
        Me.Contador.ForeColor = System.Drawing.Color.Maroon
        Me.Contador.Location = New System.Drawing.Point(150, 12)
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(13, 13)
        Me.Contador.TabIndex = 23
        Me.Contador.Text = "0"
        '
        'BindingSource6
        '
        Me.BindingSource6.DataMember = "Personas"
        Me.BindingSource6.DataSource = Me.Stadistic_AdminccoDataSet
        '
        'Stadistic_AdminccoDataSet
        '
        Me.Stadistic_AdminccoDataSet.DataSetName = "Stadistic_AdminccoDataSet"
        Me.Stadistic_AdminccoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 16)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Hoy es:"
        '
        'fecha
        '
        Me.fecha.Enabled = False
        Me.fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha.Location = New System.Drawing.Point(62, 9)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(82, 20)
        Me.fecha.TabIndex = 26
        Me.fecha.Value = New Date(2014, 8, 1, 0, 0, 0, 0)
        '
        'Seguridad2TableAdapter1
        '
        Me.Seguridad2TableAdapter1.ClearBeforeFill = True
        '
        'PersonasTableAdapter1
        '
        Me.PersonasTableAdapter1.ClearBeforeFill = True
        '
        'EstadosBindingSource
        '
        Me.EstadosBindingSource.DataMember = "estados"
        Me.EstadosBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'EstadosTableAdapter
        '
        Me.EstadosTableAdapter.ClearBeforeFill = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Seguridad4BindingSource, "Ubicacion", True))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(7, 309)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 27
        '
        'Seguridad4BindingSource
        '
        Me.Seguridad4BindingSource.DataMember = "Seguridad4"
        Me.Seguridad4BindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'Seguridad4TableAdapter
        '
        Me.Seguridad4TableAdapter.ClearBeforeFill = True
        '
        'frmmenu
        '
        Me.AcceptButton = Me.btingresar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(887, 317)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.PictureBox10)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.grrupm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmmenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Admincco Version Beta"
        Me.grplogin.ResumeLayout(False)
        Me.grplogin.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpuser.ResumeLayout(False)
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpadmin.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grrupm.ResumeLayout(False)
        Me.gpreports.ResumeLayout(False)
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Stadistic_AdminccoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EstadosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Seguridad4BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grplogin As System.Windows.Forms.GroupBox
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Adminco_MasterDataSet As WindowsApplication1.Adminco_MasterDataSet
    Friend WithEvents MatrizCMBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MaestrosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MaestrosTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.MaestrosTableAdapter
    Friend WithEvents MaestrosBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents btingresar As System.Windows.Forms.Button
    Friend WithEvents MaestrosBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents Adminco_MasterDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MaestrosBindingSource3 As System.Windows.Forms.BindingSource
    Friend WithEvents MaestrosBindingSource4 As System.Windows.Forms.BindingSource
    Friend WithEvents MaestrosBindingSource5 As System.Windows.Forms.BindingSource
    Friend WithEvents chkrecord As System.Windows.Forms.CheckBox
    Friend WithEvents Seguridad2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cmbadmin As System.Windows.Forms.ComboBox
    Friend WithEvents Seguridad2TableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad2TableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents grpuser As System.Windows.Forms.GroupBox
    Friend WithEvents btninformes As System.Windows.Forms.Button
    Friend WithEvents btcactualizar As System.Windows.Forms.Button
    Friend WithEvents grpadmin As System.Windows.Forms.GroupBox
    Friend WithEvents btncierrecont As System.Windows.Forms.Button
    Friend WithEvents btcrregistro As System.Windows.Forms.Button
    Friend WithEvents btnmodifcont As System.Windows.Forms.Button
    Friend WithEvents grrupm As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents btnautorizacion As System.Windows.Forms.Button
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents btncierreods As System.Windows.Forms.Button
    Friend WithEvents gpreports As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents AdminTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.AdminTableAdapter
    Friend WithEvents lblroll As System.Windows.Forms.ComboBox
    Friend WithEvents herramientas As System.Windows.Forms.Button
    Friend WithEvents Contador As System.Windows.Forms.Label
    Friend WithEvents Stadistic_AdminccoDataSet As WindowsApplication1.Stadistic_AdminccoDataSet
    Friend WithEvents PersonasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PersonasTableAdapter As WindowsApplication1.Stadistic_AdminccoDataSetTableAdapters.PersonasTableAdapter
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BindingSource3 As System.Windows.Forms.BindingSource
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BindingSource4 As System.Windows.Forms.BindingSource

    Friend WithEvents BindingSource5 As System.Windows.Forms.BindingSource
    Friend WithEvents Seguridad2TableAdapter1 As WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad2TableAdapter
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSource6 As System.Windows.Forms.BindingSource
    Friend WithEvents PersonasTableAdapter1 As WindowsApplication1.Stadistic_AdminccoDataSetTableAdapters.PersonasTableAdapter
    Friend WithEvents EstadosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EstadosTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.estadosTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Seguridad4BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Seguridad4TableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad4TableAdapter
End Class
