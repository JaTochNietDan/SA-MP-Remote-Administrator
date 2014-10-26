<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomBan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomBan))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBanID = New System.Windows.Forms.TextBox()
        Me.txtBanName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.clnDateUntil = New System.Windows.Forms.DateTimePicker()
        Me.btnBan = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbBanMinutes = New System.Windows.Forms.ComboBox()
        Me.cmbBanHours = New System.Windows.Forms.ComboBox()
        Me.txtBanReason = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        '
        'txtBanID
        '
        Me.txtBanID.Location = New System.Drawing.Point(39, 6)
        Me.txtBanID.Name = "txtBanID"
        Me.txtBanID.ReadOnly = True
        Me.txtBanID.Size = New System.Drawing.Size(51, 20)
        Me.txtBanID.TabIndex = 1
        '
        'txtBanName
        '
        Me.txtBanName.Location = New System.Drawing.Point(140, 6)
        Me.txtBanName.Name = "txtBanName"
        Me.txtBanName.ReadOnly = True
        Me.txtBanName.Size = New System.Drawing.Size(172, 20)
        Me.txtBanName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name:"
        '
        'clnDateUntil
        '
        Me.clnDateUntil.Location = New System.Drawing.Point(71, 31)
        Me.clnDateUntil.Name = "clnDateUntil"
        Me.clnDateUntil.Size = New System.Drawing.Size(135, 20)
        Me.clnDateUntil.TabIndex = 4
        '
        'btnBan
        '
        Me.btnBan.Location = New System.Drawing.Point(185, 84)
        Me.btnBan.Name = "btnBan"
        Me.btnBan.Size = New System.Drawing.Size(75, 23)
        Me.btnBan.TabIndex = 5
        Me.btnBan.Text = "Ban"
        Me.btnBan.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(59, 84)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Ban Until:"
        '
        'cmbBanMinutes
        '
        Me.cmbBanMinutes.FormattingEnabled = True
        Me.cmbBanMinutes.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbBanMinutes.Location = New System.Drawing.Point(266, 31)
        Me.cmbBanMinutes.MaxLength = 2
        Me.cmbBanMinutes.Name = "cmbBanMinutes"
        Me.cmbBanMinutes.Size = New System.Drawing.Size(48, 21)
        Me.cmbBanMinutes.TabIndex = 18
        '
        'cmbBanHours
        '
        Me.cmbBanHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanHours.FormattingEnabled = True
        Me.cmbBanHours.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbBanHours.Location = New System.Drawing.Point(212, 31)
        Me.cmbBanHours.Name = "cmbBanHours"
        Me.cmbBanHours.Size = New System.Drawing.Size(48, 21)
        Me.cmbBanHours.TabIndex = 17
        '
        'txtBanReason
        '
        Me.txtBanReason.Location = New System.Drawing.Point(71, 58)
        Me.txtBanReason.Name = "txtBanReason"
        Me.txtBanReason.Size = New System.Drawing.Size(241, 20)
        Me.txtBanReason.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Reason:"
        '
        'frmCustomBan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 115)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBanReason)
        Me.Controls.Add(Me.cmbBanMinutes)
        Me.Controls.Add(Me.cmbBanHours)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBan)
        Me.Controls.Add(Me.clnDateUntil)
        Me.Controls.Add(Me.txtBanName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBanID)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCustomBan"
        Me.Text = "Ban"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBanID As System.Windows.Forms.TextBox
    Friend WithEvents txtBanName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents clnDateUntil As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBan As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBanMinutes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBanHours As System.Windows.Forms.ComboBox
    Friend WithEvents txtBanReason As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
