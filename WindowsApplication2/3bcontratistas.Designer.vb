<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcontatista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcontatista))
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombreproveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Teléfono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoAcreedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoAcreedorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoPostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrupoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NITDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrgCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TeléfonoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreproveedorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendedorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaProveedoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Adminco_MasterDataSet = New WindowsApplication1.Adminco_MasterDataSet()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btselect = New System.Windows.Forms.Button()
        Me.ListaProveedoresTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.ListaproveedoresTableAdapter()
        Me.CMNuevosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CMNuevosTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.CMNuevosTableAdapter()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListaProveedoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMNuevosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(210, 15)
        Me.txtbuscar.Multiline = True
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(500, 37)
        Me.txtbuscar.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NIT, Me.Nombreproveedor, Me.Teléfono, Me.CodigoAcreedor, Me.IdDataGridViewTextBoxColumn, Me.CodigoAcreedorDataGridViewTextBoxColumn, Me.CalleDataGridViewTextBoxColumn, Me.CodigoPostalDataGridViewTextBoxColumn, Me.GrupoDataGridViewTextBoxColumn, Me.NITDataGridViewTextBoxColumn, Me.OrgCDataGridViewTextBoxColumn, Me.CPagDataGridViewTextBoxColumn, Me.MonDataGridViewTextBoxColumn, Me.TeléfonoDataGridViewTextBoxColumn, Me.NombreproveedorDataGridViewTextBoxColumn, Me.VendedorDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ListaProveedoresBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(698, 250)
        Me.DataGridView1.TabIndex = 1
        '
        'NIT
        '
        Me.NIT.DataPropertyName = "NIT"
        Me.NIT.HeaderText = "NIT"
        Me.NIT.Name = "NIT"
        Me.NIT.Width = 150
        '
        'Nombreproveedor
        '
        Me.Nombreproveedor.DataPropertyName = "Nombreproveedor"
        Me.Nombreproveedor.HeaderText = "Nombreproveedor"
        Me.Nombreproveedor.Name = "Nombreproveedor"
        Me.Nombreproveedor.Width = 300
        '
        'Teléfono
        '
        Me.Teléfono.DataPropertyName = "Teléfono"
        Me.Teléfono.HeaderText = "Teléfono"
        Me.Teléfono.Name = "Teléfono"
        '
        'CodigoAcreedor
        '
        Me.CodigoAcreedor.DataPropertyName = "CodigoAcreedor"
        Me.CodigoAcreedor.HeaderText = "CodigoAcreedor"
        Me.CodigoAcreedor.Name = "CodigoAcreedor"
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        '
        'CodigoAcreedorDataGridViewTextBoxColumn
        '
        Me.CodigoAcreedorDataGridViewTextBoxColumn.DataPropertyName = "CodigoAcreedor"
        Me.CodigoAcreedorDataGridViewTextBoxColumn.HeaderText = "CodigoAcreedor"
        Me.CodigoAcreedorDataGridViewTextBoxColumn.Name = "CodigoAcreedorDataGridViewTextBoxColumn"
        '
        'CalleDataGridViewTextBoxColumn
        '
        Me.CalleDataGridViewTextBoxColumn.DataPropertyName = "Calle"
        Me.CalleDataGridViewTextBoxColumn.HeaderText = "Calle"
        Me.CalleDataGridViewTextBoxColumn.Name = "CalleDataGridViewTextBoxColumn"
        '
        'CodigoPostalDataGridViewTextBoxColumn
        '
        Me.CodigoPostalDataGridViewTextBoxColumn.DataPropertyName = "CodigoPostal"
        Me.CodigoPostalDataGridViewTextBoxColumn.HeaderText = "CodigoPostal"
        Me.CodigoPostalDataGridViewTextBoxColumn.Name = "CodigoPostalDataGridViewTextBoxColumn"
        '
        'GrupoDataGridViewTextBoxColumn
        '
        Me.GrupoDataGridViewTextBoxColumn.DataPropertyName = "Grupo"
        Me.GrupoDataGridViewTextBoxColumn.HeaderText = "Grupo"
        Me.GrupoDataGridViewTextBoxColumn.Name = "GrupoDataGridViewTextBoxColumn"
        '
        'NITDataGridViewTextBoxColumn
        '
        Me.NITDataGridViewTextBoxColumn.DataPropertyName = "NIT"
        Me.NITDataGridViewTextBoxColumn.HeaderText = "NIT"
        Me.NITDataGridViewTextBoxColumn.Name = "NITDataGridViewTextBoxColumn"
        '
        'OrgCDataGridViewTextBoxColumn
        '
        Me.OrgCDataGridViewTextBoxColumn.DataPropertyName = "OrgC"
        Me.OrgCDataGridViewTextBoxColumn.HeaderText = "OrgC"
        Me.OrgCDataGridViewTextBoxColumn.Name = "OrgCDataGridViewTextBoxColumn"
        '
        'CPagDataGridViewTextBoxColumn
        '
        Me.CPagDataGridViewTextBoxColumn.DataPropertyName = "CPag"
        Me.CPagDataGridViewTextBoxColumn.HeaderText = "CPag"
        Me.CPagDataGridViewTextBoxColumn.Name = "CPagDataGridViewTextBoxColumn"
        '
        'MonDataGridViewTextBoxColumn
        '
        Me.MonDataGridViewTextBoxColumn.DataPropertyName = "Mon"
        Me.MonDataGridViewTextBoxColumn.HeaderText = "Mon"
        Me.MonDataGridViewTextBoxColumn.Name = "MonDataGridViewTextBoxColumn"
        '
        'TeléfonoDataGridViewTextBoxColumn
        '
        Me.TeléfonoDataGridViewTextBoxColumn.DataPropertyName = "Teléfono"
        Me.TeléfonoDataGridViewTextBoxColumn.HeaderText = "Teléfono"
        Me.TeléfonoDataGridViewTextBoxColumn.Name = "TeléfonoDataGridViewTextBoxColumn"
        '
        'NombreproveedorDataGridViewTextBoxColumn
        '
        Me.NombreproveedorDataGridViewTextBoxColumn.DataPropertyName = "Nombreproveedor"
        Me.NombreproveedorDataGridViewTextBoxColumn.HeaderText = "Nombreproveedor"
        Me.NombreproveedorDataGridViewTextBoxColumn.Name = "NombreproveedorDataGridViewTextBoxColumn"
        '
        'VendedorDataGridViewTextBoxColumn
        '
        Me.VendedorDataGridViewTextBoxColumn.DataPropertyName = "Vendedor"
        Me.VendedorDataGridViewTextBoxColumn.HeaderText = "Vendedor"
        Me.VendedorDataGridViewTextBoxColumn.Name = "VendedorDataGridViewTextBoxColumn"
        '
        'ListaProveedoresBindingSource
        '
        Me.ListaProveedoresBindingSource.DataMember = "ListaProveedores"
        Me.ListaProveedoresBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'Adminco_MasterDataSet
        '
        Me.Adminco_MasterDataSet.DataSetName = "Adminco_MasterDataSet"
        Me.Adminco_MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ListaProveedoresBindingSource, "Nombreproveedor", True))
        Me.TextBox2.Location = New System.Drawing.Point(729, 81)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(222, 32)
        Me.TextBox2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ingrese Nombre del"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(79, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Contratista"
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ListaProveedoresBindingSource, "Teléfono", True))
        Me.TextBox5.Location = New System.Drawing.Point(729, 275)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(222, 29)
        Me.TextBox5.TabIndex = 5
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ListaProveedoresBindingSource, "Calle", True))
        Me.TextBox4.Location = New System.Drawing.Point(729, 213)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(222, 34)
        Me.TextBox4.TabIndex = 6
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ListaProveedoresBindingSource, "NIT", True))
        Me.TextBox3.Location = New System.Drawing.Point(729, 144)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(222, 33)
        Me.TextBox3.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(725, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Contratista"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(725, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Numero Nit:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(725, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Direccion:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(725, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Telefono"
        '
        'btselect
        '
        Me.btselect.Location = New System.Drawing.Point(744, 15)
        Me.btselect.Name = "btselect"
        Me.btselect.Size = New System.Drawing.Size(186, 31)
        Me.btselect.TabIndex = 12
        Me.btselect.Text = "Seleccionar"
        Me.btselect.UseVisualStyleBackColor = True
        '
        'ListaProveedoresTableAdapter
        '
        Me.ListaProveedoresTableAdapter.ClearBeforeFill = True
        '
        'CMNuevosBindingSource
        '
        Me.CMNuevosBindingSource.DataMember = "CMNuevos"
        Me.CMNuevosBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'CMNuevosTableAdapter
        '
        Me.CMNuevosTableAdapter.ClearBeforeFill = True
        '
        'frmcontatista
        '
        Me.AcceptButton = Me.btselect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 318)
        Me.Controls.Add(Me.btselect)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtbuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmcontatista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda de contratistas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListaProveedoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMNuevosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents NombreDelProveedorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendedoraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btselect As System.Windows.Forms.Button
    Public WithEvents txtbuscar As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Adminco_MasterDataSet As WindowsApplication1.Adminco_MasterDataSet
    Friend WithEvents ListaProveedoresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListaProveedoresTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.ListaproveedoresTableAdapter
    Friend WithEvents CMNuevosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CMNuevosTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.CMNuevosTableAdapter
    Friend WithEvents NIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombreproveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Teléfono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoAcreedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoAcreedorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAISDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoPostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CIUDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrupoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NITDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrgCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DenominaciónDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TeléfonoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreproveedorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendedorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
