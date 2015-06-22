<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmselectasociasion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmselectasociasion))
        Me.Adminco_MasterDataSet = New WindowsApplication1.Adminco_MasterDataSet()
        Me.AreasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AreasTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.AreasTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.TableAdapterManager()
        Me.AreasBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.AreasBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.AreasBindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CAMPODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROYECTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SISTEMADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBSISTEMADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AreasBindingSource4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.txticampo = New System.Windows.Forms.TextBox()
        Me.txtisistema = New System.Windows.Forms.TextBox()
        Me.txtisubsistem = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtiproyecto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtselect = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreasBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreasBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreasBindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreasBindingSource4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Adminco_MasterDataSet
        '
        Me.Adminco_MasterDataSet.DataSetName = "Adminco_MasterDataSet"
        Me.Adminco_MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AreasBindingSource
        '
        Me.AreasBindingSource.DataMember = "Areas"
        Me.AreasBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'AreasTableAdapter
        '
        Me.AreasTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        REM Me.TableAdapterManager.AreasTableAdapter = Me.AreasTableAdapter
        REM Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        REM Me.TableAdapterManager.CMNuevosTableAdapter = Nothing
        REM Me.TableAdapterManager.ListaProveedoresTableAdapter = Nothing
        REM Me.TableAdapterManager.MaestrosTableAdapter = Nothing

        REM        Me.TableAdapterManager.ODSTableAdapter = Nothing

        REM Me.TableAdapterManager.Seguridad2TableAdapter = Nothing
        REM Me.TableAdapterManager.ServiciosTableAdapter = Nothing
        REM Me.TableAdapterManager.UpdateOrder = WindowsApplication1.Adminco_MasterDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AreasBindingSource1
        '
        Me.AreasBindingSource1.DataMember = "Areas"
        Me.AreasBindingSource1.DataSource = Me.Adminco_MasterDataSet
        '
        'AreasBindingSource2
        '
        Me.AreasBindingSource2.DataMember = "Areas"
        Me.AreasBindingSource2.DataSource = Me.Adminco_MasterDataSet
        '
        'AreasBindingSource3
        '
        Me.AreasBindingSource3.DataMember = "Areas"
        Me.AreasBindingSource3.DataSource = Me.Adminco_MasterDataSet
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CAMPODataGridViewTextBoxColumn, Me.PROYECTODataGridViewTextBoxColumn, Me.SISTEMADataGridViewTextBoxColumn, Me.SUBSISTEMADataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.AreasBindingSource4
        Me.DataGridView1.Location = New System.Drawing.Point(12, 75)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(843, 267)
        Me.DataGridView1.TabIndex = 0
        '
        'CAMPODataGridViewTextBoxColumn
        '
        Me.CAMPODataGridViewTextBoxColumn.DataPropertyName = "CAMPO"
        Me.CAMPODataGridViewTextBoxColumn.HeaderText = "CAMPO"
        Me.CAMPODataGridViewTextBoxColumn.Name = "CAMPODataGridViewTextBoxColumn"
        Me.CAMPODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PROYECTODataGridViewTextBoxColumn
        '
        Me.PROYECTODataGridViewTextBoxColumn.DataPropertyName = "PROYECTO"
        Me.PROYECTODataGridViewTextBoxColumn.HeaderText = "PROYECTO"
        Me.PROYECTODataGridViewTextBoxColumn.Name = "PROYECTODataGridViewTextBoxColumn"
        Me.PROYECTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'SISTEMADataGridViewTextBoxColumn
        '
        Me.SISTEMADataGridViewTextBoxColumn.DataPropertyName = "SISTEMA"
        Me.SISTEMADataGridViewTextBoxColumn.HeaderText = "SISTEMA"
        Me.SISTEMADataGridViewTextBoxColumn.Name = "SISTEMADataGridViewTextBoxColumn"
        Me.SISTEMADataGridViewTextBoxColumn.ReadOnly = True
        Me.SISTEMADataGridViewTextBoxColumn.Width = 300
        '
        'SUBSISTEMADataGridViewTextBoxColumn
        '
        Me.SUBSISTEMADataGridViewTextBoxColumn.DataPropertyName = "SUBSISTEMA"
        Me.SUBSISTEMADataGridViewTextBoxColumn.HeaderText = "SUBSISTEMA"
        Me.SUBSISTEMADataGridViewTextBoxColumn.Name = "SUBSISTEMADataGridViewTextBoxColumn"
        Me.SUBSISTEMADataGridViewTextBoxColumn.ReadOnly = True
        Me.SUBSISTEMADataGridViewTextBoxColumn.Width = 300
        '
        'AreasBindingSource4
        '
        Me.AreasBindingSource4.DataMember = "Areas"
        Me.AreasBindingSource4.DataSource = Me.Adminco_MasterDataSet
        '
        'txticampo
        '
        Me.txticampo.Location = New System.Drawing.Point(15, 49)
        Me.txticampo.Name = "txticampo"
        Me.txticampo.Size = New System.Drawing.Size(199, 20)
        Me.txticampo.TabIndex = 1
        '
        'txtisistema
        '
        Me.txtisistema.Location = New System.Drawing.Point(394, 49)
        Me.txtisistema.Name = "txtisistema"
        Me.txtisistema.Size = New System.Drawing.Size(247, 20)
        Me.txtisistema.TabIndex = 3
        '
        'txtisubsistem
        '
        Me.txtisubsistem.Location = New System.Drawing.Point(647, 49)
        Me.txtisubsistem.Name = "txtisubsistem"
        Me.txtisubsistem.Size = New System.Drawing.Size(213, 20)
        Me.txtisubsistem.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ingrese campo"
        '
        'txtiproyecto
        '
        Me.txtiproyecto.Location = New System.Drawing.Point(220, 49)
        Me.txtiproyecto.Name = "txtiproyecto"
        Me.txtiproyecto.Size = New System.Drawing.Size(168, 20)
        Me.txtiproyecto.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(238, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ingrese Proyecto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(422, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Ingrese Sistema"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(686, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ingrese Subsistema"
        '
        'txtselect
        '
        Me.txtselect.Location = New System.Drawing.Point(897, 33)
        Me.txtselect.Name = "txtselect"
        Me.txtselect.Size = New System.Drawing.Size(126, 36)
        Me.txtselect.TabIndex = 9
        Me.txtselect.Text = "Seleccionar"
        Me.txtselect.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AreasBindingSource4, "CAMPO", True))
        Me.TextBox1.Location = New System.Drawing.Point(861, 119)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(228, 20)
        Me.TextBox1.TabIndex = 10
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AreasBindingSource4, "PROYECTO", True))
        Me.TextBox2.Location = New System.Drawing.Point(861, 172)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(228, 20)
        Me.TextBox2.TabIndex = 11
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AreasBindingSource4, "SISTEMA", True))
        Me.TextBox3.Location = New System.Drawing.Point(861, 221)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(228, 20)
        Me.TextBox3.TabIndex = 12
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AreasBindingSource4, "SUBSISTEMA", True))
        Me.TextBox4.Location = New System.Drawing.Point(861, 275)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(228, 20)
        Me.TextBox4.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(861, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Campo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(861, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Proyecto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(861, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Sistema"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(861, 259)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Susbsistema"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(908, 306)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 36)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Salir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmselectasociasion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 382)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtselect)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtisubsistem)
        Me.Controls.Add(Me.txtisistema)
        Me.Controls.Add(Me.txtiproyecto)
        Me.Controls.Add(Me.txticampo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmselectasociasion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion de Asociacion"
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreasBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreasBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreasBindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreasBindingSource4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Adminco_MasterDataSet As WindowsApplication1.Adminco_MasterDataSet
    Friend WithEvents AreasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AreasTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.AreasTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.Adminco_MasterDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AreasBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents AreasBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents AreasBindingSource3 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txticampo As System.Windows.Forms.TextBox
    Friend WithEvents txtisistema As System.Windows.Forms.TextBox
    Friend WithEvents txtisubsistem As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtiproyecto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CAMPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROYECTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SISTEMADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUBSISTEMADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AreasBindingSource4 As System.Windows.Forms.BindingSource
    Friend WithEvents txtselect As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
