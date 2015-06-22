<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcontratos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcontratos))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContratosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROCESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMNuevosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Adminco_MasterDataSet = New WindowsApplication1.Adminco_MasterDataSet()
        Me.txtpcontratista = New System.Windows.Forms.TextBox()
        Me.txtpproceso = New System.Windows.Forms.TextBox()
        Me.txtpcontrato = New System.Windows.Forms.TextBox()
        Me.btnncontratista = New System.Windows.Forms.TextBox()
        Me.btnnit = New System.Windows.Forms.TextBox()
        Me.btnseleccionar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMNuevosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.CMNuevosTableAdapter1 = New WindowsApplication1.Adminco_MasterDataSetTableAdapters.CMNuevosTableAdapter()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMNuevosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMNuevosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.ContratosDataGridViewTextBoxColumn, Me.PROVEEDORDataGridViewTextBoxColumn, Me.PROCESO})
        Me.DataGridView1.DataSource = Me.CMNuevosBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(30, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(753, 234)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Id"
        Me.Column1.HeaderText = "Id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'ContratosDataGridViewTextBoxColumn
        '
        Me.ContratosDataGridViewTextBoxColumn.DataPropertyName = "Contratos"
        Me.ContratosDataGridViewTextBoxColumn.HeaderText = "Contratos"
        Me.ContratosDataGridViewTextBoxColumn.Name = "ContratosDataGridViewTextBoxColumn"
        Me.ContratosDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PROVEEDORDataGridViewTextBoxColumn
        '
        Me.PROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "PROVEEDOR"
        Me.PROVEEDORDataGridViewTextBoxColumn.HeaderText = "PROVEEDOR"
        Me.PROVEEDORDataGridViewTextBoxColumn.Name = "PROVEEDORDataGridViewTextBoxColumn"
        Me.PROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        Me.PROVEEDORDataGridViewTextBoxColumn.Width = 450
        '
        'PROCESO
        '
        Me.PROCESO.DataPropertyName = "PROCESO"
        Me.PROCESO.HeaderText = "PROCESO"
        Me.PROCESO.Name = "PROCESO"
        Me.PROCESO.ReadOnly = True
        '
        'CMNuevosBindingSource
        '
        Me.CMNuevosBindingSource.DataMember = "CMNuevos"
        Me.CMNuevosBindingSource.DataSource = Me.Adminco_MasterDataSet
        '
        'Adminco_MasterDataSet
        '
        Me.Adminco_MasterDataSet.DataSetName = "Adminco_MasterDataSet"
        Me.Adminco_MasterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        '
        'txtpcontratista
        '
        Me.txtpcontratista.Location = New System.Drawing.Point(403, 28)
        Me.txtpcontratista.Name = "txtpcontratista"
        Me.txtpcontratista.Size = New System.Drawing.Size(380, 20)
        Me.txtpcontratista.TabIndex = 1
        '
        'txtpproceso
        '
        Me.txtpproceso.Location = New System.Drawing.Point(213, 28)
        Me.txtpproceso.Name = "txtpproceso"
        Me.txtpproceso.Size = New System.Drawing.Size(165, 20)
        Me.txtpproceso.TabIndex = 2
        '
        'txtpcontrato
        '
        Me.txtpcontrato.Location = New System.Drawing.Point(30, 28)
        Me.txtpcontrato.Name = "txtpcontrato"
        Me.txtpcontrato.Size = New System.Drawing.Size(165, 20)
        Me.txtpcontrato.TabIndex = 3
        '
        'btnncontratista
        '
        Me.btnncontratista.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CMNuevosBindingSource1, "Contratos", True))
        Me.btnncontratista.Location = New System.Drawing.Point(803, 82)
        Me.btnncontratista.Name = "btnncontratista"
        Me.btnncontratista.Size = New System.Drawing.Size(236, 20)
        Me.btnncontratista.TabIndex = 4
        '
        'btnnit
        '
        Me.btnnit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CMNuevosBindingSource1, "PROVEEDOR", True))
        Me.btnnit.Location = New System.Drawing.Point(803, 134)
        Me.btnnit.Name = "btnnit"
        Me.btnnit.Size = New System.Drawing.Size(236, 20)
        Me.btnnit.TabIndex = 5
        '
        'btnseleccionar
        '
        Me.btnseleccionar.Location = New System.Drawing.Point(854, 18)
        Me.btnseleccionar.Name = "btnseleccionar"
        Me.btnseleccionar.Size = New System.Drawing.Size(161, 30)
        Me.btnseleccionar.TabIndex = 7
        Me.btnseleccionar.Text = "Seleccionar"
        Me.btnseleccionar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(854, 184)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(161, 28)
        Me.btncancelar.TabIndex = 8
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Buscar por contrato"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(224, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Buscar por proceso"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(400, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Buscar por contratista"
        '
        'CMNuevosBindingSource1
        '
        Me.CMNuevosBindingSource1.DataMember = "CMNuevos"
        Me.CMNuevosBindingSource1.DataSource = Me.Adminco_MasterDataSet
        '
        'CMNuevosTableAdapter1
        '
        Me.CMNuevosTableAdapter1.ClearBeforeFill = True
        '
        'frmcontratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 314)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnseleccionar)
        Me.Controls.Add(Me.btnnit)
        Me.Controls.Add(Me.btnncontratista)
        Me.Controls.Add(Me.txtpcontrato)
        Me.Controls.Add(Me.txtpproceso)
        Me.Controls.Add(Me.txtpcontratista)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcontratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulario de contratos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMNuevosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Adminco_MasterDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMNuevosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Adminco_MasterDataSet As WindowsApplication1.Adminco_MasterDataSet
    Friend WithEvents CMNuevosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtpcontratista As System.Windows.Forms.TextBox
    Friend WithEvents txtpproceso As System.Windows.Forms.TextBox
    Friend WithEvents txtpcontrato As System.Windows.Forms.TextBox
    Friend WithEvents btnncontratista As System.Windows.Forms.TextBox
    Friend WithEvents btnnit As System.Windows.Forms.TextBox
    Friend WithEvents btnseleccionar As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContratosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMNuevosBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents CMNuevosTableAdapter1 As WindowsApplication1.Adminco_MasterDataSetTableAdapters.CMNuevosTableAdapter
End Class
