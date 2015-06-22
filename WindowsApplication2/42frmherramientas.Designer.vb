<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.AdminBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Adminco_MasterDataSet = New WindowsApplication1.Adminco_MasterDataSet()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Seguridad2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.correo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.roll = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Usuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Seguridad4BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Seguridad4TableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad4TableAdapter()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Seguridad2TableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad2TableAdapter()
        Me.AdminTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.AdminTableAdapter()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PannerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PannerTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.PannerTableAdapter()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AdminBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Seguridad2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Seguridad4BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PannerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(597, 361)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(123, 39)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Salir"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.correo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.roll)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Usuario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Nombre)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1009, 140)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdminBindingSource, "Listauser", True))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(833, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 30
        '
        'AdminBindingSource
        '
        Me.AdminBindingSource.DataMember = "Admin"
        Me.AdminBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'Adminco_MasterDataSet
        '
        Me.Adminco_MasterDataSet.DataSetName = "Adminco_MasterDataSet"
        Me.Adminco_MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Seguridad2BindingSource, "Usuario", True))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(833, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 29
        '
        'Seguridad2BindingSource
        '
        Me.Seguridad2BindingSource.DataMember = "Seguridad2"
        Me.Seguridad2BindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(5, 98)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(123, 39)
        Me.Button6.TabIndex = 28
        Me.Button6.Text = "Guardar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(143, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Escoja Base de datos"
        '
        'ComboBox2
        '
        Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Seleccione Accion", "Usuario Login", "Administrador", "Planner"})
        Me.ComboBox2.Location = New System.Drawing.Point(140, 31)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(190, 21)
        Me.ComboBox2.TabIndex = 26
        '
        'correo
        '
        Me.correo.Enabled = False
        Me.correo.Location = New System.Drawing.Point(715, 77)
        Me.correo.Name = "correo"
        Me.correo.Size = New System.Drawing.Size(288, 20)
        Me.correo.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(712, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Correo"
        '
        'roll
        '
        Me.roll.Enabled = False
        Me.roll.FormattingEnabled = True
        Me.roll.Items.AddRange(New Object() {"Seleccione Opccion", "Administrador", "Admin", "Consultor", "Solicitante", "Spadmin", "Spfinanzas"})
        Me.roll.Location = New System.Drawing.Point(521, 76)
        Me.roll.Name = "roll"
        Me.roll.Size = New System.Drawing.Size(188, 21)
        Me.roll.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(518, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Roll"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Usuario Red"
        '
        'Usuario
        '
        Me.Usuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Usuario.Enabled = False
        Me.Usuario.Location = New System.Drawing.Point(302, 76)
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Size = New System.Drawing.Size(213, 20)
        Me.Usuario.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nombre Competo"
        '
        'Nombre
        '
        Me.Nombre.Enabled = False
        Me.Nombre.Location = New System.Drawing.Point(5, 76)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(291, 20)
        Me.Nombre.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(5, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(123, 39)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Agregar Usuario"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 91)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(123, 39)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Aplicar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Seguridad4BindingSource, "Ubicacion", True))
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Lock", "Unlock"})
        Me.ComboBox1.Location = New System.Drawing.Point(8, 64)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(122, 21)
        Me.ComboBox1.TabIndex = 19
        '
        'Seguridad4BindingSource
        '
        Me.Seguridad4BindingSource.DataMember = "Seguridad4"
        Me.Seguridad4BindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 341)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 39)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Eliminar Contrato y ODS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Seguridad4TableAdapter
        '
        Me.Seguridad4TableAdapter.ClearBeforeFill = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(6, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(123, 39)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "Modo Mantenimiento"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 169)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 140)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Modo Mantenimiento"
        '
        'Seguridad2TableAdapter
        '
        Me.Seguridad2TableAdapter.ClearBeforeFill = True
        '
        'AdminTableAdapter
        '
        Me.AdminTableAdapter.ClearBeforeFill = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PannerBindingSource, "Nombre", True))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(833, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 31
        '
        'PannerBindingSource
        '
        Me.PannerBindingSource.DataMember = "Panner"
        Me.PannerBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'PannerTableAdapter
        '
        Me.PannerTableAdapter.ClearBeforeFill = True
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 408)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modulo de Herramientas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AdminBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Seguridad2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Seguridad4BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PannerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Adminco_MasterDataSet As WindowsApplication1.Adminco_MasterDataSet
    Friend WithEvents Seguridad4BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Seguridad4TableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad4TableAdapter
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents correo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents roll As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Seguridad2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Seguridad2TableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.Seguridad2TableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents AdminBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdminTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.AdminTableAdapter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PannerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PannerTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.PannerTableAdapter
End Class
