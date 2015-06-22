<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Me.btselect2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblnamec3 = New System.Windows.Forms.Label()
        Me.ServiciosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Adminco_MasterDataSet = New WindowsApplication1.Adminco_MasterDataSet()
        Me.txtumb = New System.Windows.Forms.TextBox()
        Me.ServiciosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.textcontract = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtbuscar5 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ServiciosTableAdapter = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.ServiciosTableAdapter()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ServicioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextoBreveDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UMBDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ServiciosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServiciosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btselect2
        '
        Me.btselect2.Location = New System.Drawing.Point(836, 15)
        Me.btselect2.Name = "btselect2"
        Me.btselect2.Size = New System.Drawing.Size(111, 31)
        Me.btselect2.TabIndex = 25
        Me.btselect2.Text = "Seleccionar"
        Me.btselect2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(713, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "UMB"
        '
        'lblnamec3
        '
        Me.lblnamec3.AutoSize = True
        Me.lblnamec3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnamec3.Location = New System.Drawing.Point(713, 56)
        Me.lblnamec3.Name = "lblnamec3"
        Me.lblnamec3.Size = New System.Drawing.Size(64, 20)
        Me.lblnamec3.TabIndex = 21
        Me.lblnamec3.Text = "Servicio"
        '
        'ServiciosBindingSource
        '
        Me.ServiciosBindingSource.DataMember = "Servicios"
        Me.ServiciosBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'Adminco_MasterDataSet
        '
        Me.Adminco_MasterDataSet.DataSetName = "Adminco_MasterDataSet"
        Me.Adminco_MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtumb
        '
        Me.txtumb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiciosBindingSource1, "UMB", True))
        Me.txtumb.Location = New System.Drawing.Point(717, 195)
        Me.txtumb.Multiline = True
        Me.txtumb.Name = "txtumb"
        Me.txtumb.Size = New System.Drawing.Size(222, 34)
        Me.txtumb.TabIndex = 19
        '
        'ServiciosBindingSource1
        '
        Me.ServiciosBindingSource1.DataMember = "Servicios"
        Me.ServiciosBindingSource1.DataSource = Me.Adminco_MasterDataSet
        '
        'textcontract
        '
        Me.textcontract.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiciosBindingSource1, "Texto breve", True))
        Me.textcontract.Location = New System.Drawing.Point(717, 79)
        Me.textcontract.Multiline = True
        Me.textcontract.Name = "textcontract"
        Me.textcontract.Size = New System.Drawing.Size(222, 32)
        Me.textcontract.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(330, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 20)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Nombre del servicio"
        '
        'txtbuscar5
        '
        Me.txtbuscar5.Location = New System.Drawing.Point(479, 12)
        Me.txtbuscar5.Multiline = True
        Me.txtbuscar5.Name = "txtbuscar5"
        Me.txtbuscar5.Size = New System.Drawing.Size(348, 37)
        Me.txtbuscar5.TabIndex = 26
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(727, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 31)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Salir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 20)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Codigo SAP"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(192, 8)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(132, 37)
        Me.TextBox1.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(713, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 20)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Codigo SAP"
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ServiciosBindingSource1, "Servicio", True))
        Me.TextBox2.Location = New System.Drawing.Point(717, 137)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(222, 32)
        Me.TextBox2.TabIndex = 31
        '
        'ServiciosTableAdapter
        '
        Me.ServiciosTableAdapter.ClearBeforeFill = True
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServicioDataGridViewTextBoxColumn, Me.TextoBreveDataGridViewTextBoxColumn, Me.UMBDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ServiciosBindingSource1
        Me.DataGridView1.Location = New System.Drawing.Point(16, 79)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(691, 211)
        Me.DataGridView1.TabIndex = 33
        '
        'ServicioDataGridViewTextBoxColumn
        '
        Me.ServicioDataGridViewTextBoxColumn.DataPropertyName = "Servicio"
        Me.ServicioDataGridViewTextBoxColumn.HeaderText = "Servicio"
        Me.ServicioDataGridViewTextBoxColumn.Name = "ServicioDataGridViewTextBoxColumn"
        Me.ServicioDataGridViewTextBoxColumn.ReadOnly = True
        Me.ServicioDataGridViewTextBoxColumn.Width = 150
        '
        'TextoBreveDataGridViewTextBoxColumn
        '
        Me.TextoBreveDataGridViewTextBoxColumn.DataPropertyName = "Texto breve"
        Me.TextoBreveDataGridViewTextBoxColumn.HeaderText = "Texto breve"
        Me.TextoBreveDataGridViewTextBoxColumn.Name = "TextoBreveDataGridViewTextBoxColumn"
        Me.TextoBreveDataGridViewTextBoxColumn.ReadOnly = True
        Me.TextoBreveDataGridViewTextBoxColumn.Width = 400
        '
        'UMBDataGridViewTextBoxColumn
        '
        Me.UMBDataGridViewTextBoxColumn.DataPropertyName = "UMB"
        Me.UMBDataGridViewTextBoxColumn.HeaderText = "UMB"
        Me.UMBDataGridViewTextBoxColumn.Name = "UMBDataGridViewTextBoxColumn"
        Me.UMBDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Form8
        '
        Me.AcceptButton = Me.btselect2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(957, 344)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtbuscar5)
        Me.Controls.Add(Me.btselect2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblnamec3)
        Me.Controls.Add(Me.txtumb)
        Me.Controls.Add(Me.textcontract)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form8"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulario de seleccion de servicios "
        CType(Me.ServiciosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServiciosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btselect2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblnamec3 As System.Windows.Forms.Label
    Friend WithEvents txtumb As System.Windows.Forms.TextBox
    Friend WithEvents textcontract As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtbuscar5 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Adminco_MasterDataSet As WindowsApplication1.Adminco_MasterDataSet
    Friend WithEvents ServiciosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServiciosTableAdapter As WindowsApplication1.Adminco_MasterDataSetTableAdapters.ServiciosTableAdapter
    Friend WithEvents CodigoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ServiciosBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ServicioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextoBreveDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UMBDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
