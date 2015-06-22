Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form4
    Inherits System.Windows.Forms.Form

    Friend WithEvents BtnGetScreenInfo As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form4())
    End Sub 'Main

    Public Sub New()
        MyBase.New()

        Me.BtnGetScreenInfo = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox

        ' Get System Information Button
        Me.BtnGetScreenInfo.Location = New System.Drawing.Point(16, 16)
        Me.BtnGetScreenInfo.Size = New System.Drawing.Size(256, 48)
        Me.BtnGetScreenInfo.TabIndex = 0
        Me.BtnGetScreenInfo.Text = "Get System Information"

        ' System Information ListBox
        Me.ListBox1.Location = New System.Drawing.Point(16, 72)
        Me.ListBox1.Size = New System.Drawing.Size(256, 186)
        Me.ListBox1.TabIndex = 1

        ' Form4
        Me.ClientSize = New System.Drawing.Size(392, 317)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.BtnGetScreenInfo})
        Me.Text = "System Information Example"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetScreenInfo.Click
        ' Get System Information for the current machine.
        ListBox1.Items.Add("ComputerName : " + SystemInformation.ComputerName)
        ListBox1.Items.Add("Network  : " + SystemInformation.Network.ToString())
        ListBox1.Items.Add("UserDomainName  : " + SystemInformation.UserDomainName)
        ListBox1.Items.Add("UserName   : " + SystemInformation.UserName)
        ListBox1.Items.Add("BootMode : " + SystemInformation.BootMode.ToString())
        ListBox1.Items.Add("MenuFont : " + SystemInformation.MenuFont.ToString())
        ListBox1.Items.Add("MonitorCount : " + SystemInformation.MonitorCount.ToString())
        ListBox1.Items.Add("MonitorsSameDisplayFormat : " + SystemInformation.MonitorsSameDisplayFormat.ToString())
        ListBox1.Items.Add("ArrangeDirection: " + SystemInformation.ArrangeDirection.ToString())
        ListBox1.Items.Add("MousePresent : " + SystemInformation.MousePresent.ToString())
        ListBox1.Items.Add("MouseButtonsSwapped    : " + SystemInformation.MouseButtonsSwapped.ToString())
        ListBox1.Items.Add("UserInteractive    : " + SystemInformation.UserInteractive.ToString())
        ListBox1.Items.Add("VirtualScreen: " + SystemInformation.VirtualScreen.ToString())
    End Sub
End Class




