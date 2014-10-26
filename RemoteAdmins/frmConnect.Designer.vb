<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnect
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnect))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.lstPlayer = New System.Windows.Forms.ListView()
        Me.clmID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rtbChat = New System.Windows.Forms.RichTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtSendtext = New System.Windows.Forms.TextBox()
        Me.tabBanManage = New System.Windows.Forms.TabPage()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btnFilterBans = New System.Windows.Forms.Button()
        Me.btnPreviousPage = New System.Windows.Forms.Button()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteBan = New System.Windows.Forms.Button()
        Me.btnSaveBan = New System.Windows.Forms.Button()
        Me.cmbBanUntilMinutes = New System.Windows.Forms.ComboBox()
        Me.cmbBanUntilHours = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.clnBannedUntil = New System.Windows.Forms.DateTimePicker()
        Me.cmbBanMinutes = New System.Windows.Forms.ComboBox()
        Me.cmbBanHours = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBanReason = New System.Windows.Forms.TextBox()
        Me.txtBanAdmin = New System.Windows.Forms.TextBox()
        Me.txtBanIP = New System.Windows.Forms.TextBox()
        Me.txtBanName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.clnBanned = New System.Windows.Forms.DateTimePicker()
        Me.txtBanID = New System.Windows.Forms.TextBox()
        Me.lstBans = New System.Windows.Forms.ListView()
        Me.clmBanName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmBanReason = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabAdminManage = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.txtNewAdminPassword = New System.Windows.Forms.TextBox()
        Me.txtNewAdminName = New System.Windows.Forms.TextBox()
        Me.cmbNewAdminLevel = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteAccount = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbLevel = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAdminID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAdminName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSavePassword = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lstAdmins = New System.Windows.Forms.ListView()
        Me.clmAdminID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmAdminName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmAdminLevel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsPlayerMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPlayerView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KickWithReasonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpammingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlamingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeathmatchingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CustomReasonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinutesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinutesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WeekToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PermanentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CustomReasonToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.KillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrUpdateInfo = New System.Windows.Forms.Timer(Me.components)
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAMPForumsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAMPWikiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.JaTochNietDanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactAuthorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabBanManage.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabAdminManage.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.cmsPlayerMenu.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabMain)
        Me.TabControl1.Controls.Add(Me.tabBanManage)
        Me.TabControl1.Controls.Add(Me.tabAdminManage)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(677, 392)
        Me.TabControl1.TabIndex = 5
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.lstPlayer)
        Me.tabMain.Controls.Add(Me.rtbChat)
        Me.tabMain.Controls.Add(Me.lblName)
        Me.tabMain.Controls.Add(Me.txtSendtext)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(669, 366)
        Me.tabMain.TabIndex = 1
        Me.tabMain.Text = "Chat & Players"
        Me.tabMain.ToolTipText = "This is where the chat and players are displayed, the main area for administratio" & _
            "n of in-game details"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'lstPlayer
        '
        Me.lstPlayer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmID, Me.clmName})
        Me.lstPlayer.FullRowSelect = True
        Me.lstPlayer.GridLines = True
        Me.lstPlayer.HideSelection = False
        Me.lstPlayer.Location = New System.Drawing.Point(468, 6)
        Me.lstPlayer.MultiSelect = False
        Me.lstPlayer.Name = "lstPlayer"
        Me.lstPlayer.Size = New System.Drawing.Size(194, 352)
        Me.lstPlayer.TabIndex = 6
        Me.lstPlayer.UseCompatibleStateImageBehavior = False
        Me.lstPlayer.View = System.Windows.Forms.View.Details
        '
        'clmID
        '
        Me.clmID.Text = "ID"
        Me.clmID.Width = 31
        '
        'clmName
        '
        Me.clmName.Text = "Names"
        Me.clmName.Width = 159
        '
        'rtbChat
        '
        Me.rtbChat.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rtbChat.Cursor = System.Windows.Forms.Cursors.Default
        Me.rtbChat.Enabled = False
        Me.rtbChat.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.rtbChat.HideSelection = False
        Me.rtbChat.Location = New System.Drawing.Point(8, 6)
        Me.rtbChat.Name = "rtbChat"
        Me.rtbChat.ReadOnly = True
        Me.rtbChat.Size = New System.Drawing.Size(454, 326)
        Me.rtbChat.TabIndex = 5
        Me.rtbChat.Text = ""
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 341)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(53, 13)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Message:"
        '
        'txtSendtext
        '
        Me.txtSendtext.AcceptsTab = True
        Me.txtSendtext.Enabled = False
        Me.txtSendtext.Location = New System.Drawing.Point(61, 338)
        Me.txtSendtext.Name = "txtSendtext"
        Me.txtSendtext.Size = New System.Drawing.Size(401, 20)
        Me.txtSendtext.TabIndex = 0
        '
        'tabBanManage
        '
        Me.tabBanManage.Controls.Add(Me.btnReload)
        Me.tabBanManage.Controls.Add(Me.GroupBox6)
        Me.tabBanManage.Controls.Add(Me.btnPreviousPage)
        Me.tabBanManage.Controls.Add(Me.btnNextPage)
        Me.tabBanManage.Controls.Add(Me.GroupBox5)
        Me.tabBanManage.Controls.Add(Me.lstBans)
        Me.tabBanManage.Location = New System.Drawing.Point(4, 22)
        Me.tabBanManage.Name = "tabBanManage"
        Me.tabBanManage.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBanManage.Size = New System.Drawing.Size(669, 366)
        Me.tabBanManage.TabIndex = 3
        Me.tabBanManage.Text = "Ban Management"
        Me.tabBanManage.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(100, 335)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(75, 23)
        Me.btnReload.TabIndex = 8
        Me.btnReload.Text = "Reload"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtFilter)
        Me.GroupBox6.Controls.Add(Me.btnFilterBans)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(259, 49)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Filter Bans"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(6, 19)
        Me.txtFilter.MaxLength = 24
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(161, 20)
        Me.txtFilter.TabIndex = 0
        '
        'btnFilterBans
        '
        Me.btnFilterBans.Location = New System.Drawing.Point(173, 17)
        Me.btnFilterBans.Name = "btnFilterBans"
        Me.btnFilterBans.Size = New System.Drawing.Size(75, 23)
        Me.btnFilterBans.TabIndex = 0
        Me.btnFilterBans.Text = "Filter"
        Me.btnFilterBans.UseVisualStyleBackColor = True
        '
        'btnPreviousPage
        '
        Me.btnPreviousPage.Location = New System.Drawing.Point(3, 335)
        Me.btnPreviousPage.Name = "btnPreviousPage"
        Me.btnPreviousPage.Size = New System.Drawing.Size(75, 23)
        Me.btnPreviousPage.TabIndex = 6
        Me.btnPreviousPage.Text = "<< Previous"
        Me.btnPreviousPage.UseVisualStyleBackColor = True
        '
        'btnNextPage
        '
        Me.btnNextPage.Location = New System.Drawing.Point(192, 335)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.Size = New System.Drawing.Size(75, 23)
        Me.btnNextPage.TabIndex = 5
        Me.btnNextPage.Text = "Next >>"
        Me.btnNextPage.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnDeleteBan)
        Me.GroupBox5.Controls.Add(Me.btnSaveBan)
        Me.GroupBox5.Controls.Add(Me.cmbBanUntilMinutes)
        Me.GroupBox5.Controls.Add(Me.cmbBanUntilHours)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.clnBannedUntil)
        Me.GroupBox5.Controls.Add(Me.cmbBanMinutes)
        Me.GroupBox5.Controls.Add(Me.cmbBanHours)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.txtBanReason)
        Me.GroupBox5.Controls.Add(Me.txtBanAdmin)
        Me.GroupBox5.Controls.Add(Me.txtBanIP)
        Me.GroupBox5.Controls.Add(Me.txtBanName)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.clnBanned)
        Me.GroupBox5.Controls.Add(Me.txtBanID)
        Me.GroupBox5.Location = New System.Drawing.Point(277, 173)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(386, 185)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Selected Ban"
        '
        'btnDeleteBan
        '
        Me.btnDeleteBan.Location = New System.Drawing.Point(9, 156)
        Me.btnDeleteBan.Name = "btnDeleteBan"
        Me.btnDeleteBan.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteBan.TabIndex = 22
        Me.btnDeleteBan.Text = "Delete Ban"
        Me.btnDeleteBan.UseVisualStyleBackColor = True
        '
        'btnSaveBan
        '
        Me.btnSaveBan.Location = New System.Drawing.Point(305, 156)
        Me.btnSaveBan.Name = "btnSaveBan"
        Me.btnSaveBan.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveBan.TabIndex = 21
        Me.btnSaveBan.Text = "Save Ban"
        Me.btnSaveBan.UseVisualStyleBackColor = True
        '
        'cmbBanUntilMinutes
        '
        Me.cmbBanUntilMinutes.FormattingEnabled = True
        Me.cmbBanUntilMinutes.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbBanUntilMinutes.Location = New System.Drawing.Point(332, 126)
        Me.cmbBanUntilMinutes.MaxLength = 2
        Me.cmbBanUntilMinutes.Name = "cmbBanUntilMinutes"
        Me.cmbBanUntilMinutes.Size = New System.Drawing.Size(48, 21)
        Me.cmbBanUntilMinutes.TabIndex = 20
        '
        'cmbBanUntilHours
        '
        Me.cmbBanUntilHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanUntilHours.FormattingEnabled = True
        Me.cmbBanUntilHours.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbBanUntilHours.Location = New System.Drawing.Point(278, 126)
        Me.cmbBanUntilHours.Name = "cmbBanUntilHours"
        Me.cmbBanUntilHours.Size = New System.Drawing.Size(48, 21)
        Me.cmbBanUntilHours.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Banned until:"
        '
        'clnBannedUntil
        '
        Me.clnBannedUntil.Checked = False
        Me.clnBannedUntil.Location = New System.Drawing.Point(76, 126)
        Me.clnBannedUntil.Name = "clnBannedUntil"
        Me.clnBannedUntil.ShowCheckBox = True
        Me.clnBannedUntil.Size = New System.Drawing.Size(196, 20)
        Me.clnBannedUntil.TabIndex = 17
        '
        'cmbBanMinutes
        '
        Me.cmbBanMinutes.FormattingEnabled = True
        Me.cmbBanMinutes.Items.AddRange(New Object() {"00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbBanMinutes.Location = New System.Drawing.Point(332, 100)
        Me.cmbBanMinutes.MaxLength = 2
        Me.cmbBanMinutes.Name = "cmbBanMinutes"
        Me.cmbBanMinutes.Size = New System.Drawing.Size(48, 21)
        Me.cmbBanMinutes.TabIndex = 16
        '
        'cmbBanHours
        '
        Me.cmbBanHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanHours.FormattingEnabled = True
        Me.cmbBanHours.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cmbBanHours.Location = New System.Drawing.Point(278, 100)
        Me.cmbBanHours.Name = "cmbBanHours"
        Me.cmbBanHours.Size = New System.Drawing.Size(48, 21)
        Me.cmbBanHours.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Banned from:"
        '
        'txtBanReason
        '
        Me.txtBanReason.Location = New System.Drawing.Point(76, 73)
        Me.txtBanReason.MaxLength = 40
        Me.txtBanReason.Name = "txtBanReason"
        Me.txtBanReason.Size = New System.Drawing.Size(304, 20)
        Me.txtBanReason.TabIndex = 12
        '
        'txtBanAdmin
        '
        Me.txtBanAdmin.Location = New System.Drawing.Point(204, 45)
        Me.txtBanAdmin.MaxLength = 24
        Me.txtBanAdmin.Name = "txtBanAdmin"
        Me.txtBanAdmin.Size = New System.Drawing.Size(177, 20)
        Me.txtBanAdmin.TabIndex = 11
        '
        'txtBanIP
        '
        Me.txtBanIP.Location = New System.Drawing.Point(33, 47)
        Me.txtBanIP.MaxLength = 16
        Me.txtBanIP.Name = "txtBanIP"
        Me.txtBanIP.Size = New System.Drawing.Size(120, 20)
        Me.txtBanIP.TabIndex = 10
        '
        'txtBanName
        '
        Me.txtBanName.Location = New System.Drawing.Point(204, 19)
        Me.txtBanName.MaxLength = 24
        Me.txtBanName.Name = "txtBanName"
        Me.txtBanName.Size = New System.Drawing.Size(176, 20)
        Me.txtBanName.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(159, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Admin:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "IP:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Reason:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(159, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Name:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "ID:"
        '
        'clnBanned
        '
        Me.clnBanned.Location = New System.Drawing.Point(76, 100)
        Me.clnBanned.Name = "clnBanned"
        Me.clnBanned.Size = New System.Drawing.Size(196, 20)
        Me.clnBanned.TabIndex = 2
        '
        'txtBanID
        '
        Me.txtBanID.Location = New System.Drawing.Point(33, 19)
        Me.txtBanID.Name = "txtBanID"
        Me.txtBanID.ReadOnly = True
        Me.txtBanID.Size = New System.Drawing.Size(120, 20)
        Me.txtBanID.TabIndex = 3
        '
        'lstBans
        '
        Me.lstBans.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmBanName, Me.clmBanReason})
        Me.lstBans.FullRowSelect = True
        Me.lstBans.GridLines = True
        Me.lstBans.Location = New System.Drawing.Point(6, 61)
        Me.lstBans.MultiSelect = False
        Me.lstBans.Name = "lstBans"
        Me.lstBans.Size = New System.Drawing.Size(261, 268)
        Me.lstBans.TabIndex = 0
        Me.lstBans.UseCompatibleStateImageBehavior = False
        Me.lstBans.View = System.Windows.Forms.View.Details
        '
        'clmBanName
        '
        Me.clmBanName.Text = "Player Name"
        Me.clmBanName.Width = 90
        '
        'clmBanReason
        '
        Me.clmBanReason.Text = "Reason"
        Me.clmBanReason.Width = 167
        '
        'tabAdminManage
        '
        Me.tabAdminManage.Controls.Add(Me.GroupBox4)
        Me.tabAdminManage.Controls.Add(Me.GroupBox3)
        Me.tabAdminManage.Controls.Add(Me.lstAdmins)
        Me.tabAdminManage.Location = New System.Drawing.Point(4, 22)
        Me.tabAdminManage.Name = "tabAdminManage"
        Me.tabAdminManage.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdminManage.Size = New System.Drawing.Size(669, 366)
        Me.tabAdminManage.TabIndex = 2
        Me.tabAdminManage.Text = "Admin Management"
        Me.tabAdminManage.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.btnCreateAccount)
        Me.GroupBox4.Controls.Add(Me.txtNewAdminPassword)
        Me.GroupBox4.Controls.Add(Me.txtNewAdminName)
        Me.GroupBox4.Controls.Add(Me.cmbNewAdminLevel)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(191, 147)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(423, 132)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Create Account"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Password:"
        '
        'btnCreateAccount
        '
        Me.btnCreateAccount.Location = New System.Drawing.Point(71, 98)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Size = New System.Drawing.Size(138, 23)
        Me.btnCreateAccount.TabIndex = 12
        Me.btnCreateAccount.Text = "Create New Account"
        Me.btnCreateAccount.UseVisualStyleBackColor = True
        '
        'txtNewAdminPassword
        '
        Me.txtNewAdminPassword.Location = New System.Drawing.Point(71, 72)
        Me.txtNewAdminPassword.Name = "txtNewAdminPassword"
        Me.txtNewAdminPassword.Size = New System.Drawing.Size(138, 20)
        Me.txtNewAdminPassword.TabIndex = 10
        '
        'txtNewAdminName
        '
        Me.txtNewAdminName.Location = New System.Drawing.Point(71, 19)
        Me.txtNewAdminName.Name = "txtNewAdminName"
        Me.txtNewAdminName.Size = New System.Drawing.Size(138, 20)
        Me.txtNewAdminName.TabIndex = 8
        '
        'cmbNewAdminLevel
        '
        Me.cmbNewAdminLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNewAdminLevel.FormattingEnabled = True
        Me.cmbNewAdminLevel.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5"})
        Me.cmbNewAdminLevel.Location = New System.Drawing.Point(71, 45)
        Me.cmbNewAdminLevel.Name = "cmbNewAdminLevel"
        Me.cmbNewAdminLevel.Size = New System.Drawing.Size(57, 21)
        Me.cmbNewAdminLevel.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Level:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnDeleteAccount)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Location = New System.Drawing.Point(191, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(423, 135)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Selected Administrator"
        '
        'btnDeleteAccount
        '
        Me.btnDeleteAccount.Enabled = False
        Me.btnDeleteAccount.Location = New System.Drawing.Point(215, 103)
        Me.btnDeleteAccount.Name = "btnDeleteAccount"
        Me.btnDeleteAccount.Size = New System.Drawing.Size(201, 23)
        Me.btnDeleteAccount.TabIndex = 7
        Me.btnDeleteAccount.Text = "Delete Account"
        Me.btnDeleteAccount.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.cmbLevel)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtAdminID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAdminName)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 107)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Administrator Information"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(112, 71)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbLevel
        '
        Me.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLevel.Enabled = False
        Me.cmbLevel.FormattingEnabled = True
        Me.cmbLevel.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5"})
        Me.cmbLevel.Location = New System.Drawing.Point(49, 73)
        Me.cmbLevel.Name = "cmbLevel"
        Me.cmbLevel.Size = New System.Drawing.Size(57, 21)
        Me.cmbLevel.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ID:"
        '
        'txtAdminID
        '
        Me.txtAdminID.Location = New System.Drawing.Point(49, 19)
        Me.txtAdminID.Name = "txtAdminID"
        Me.txtAdminID.ReadOnly = True
        Me.txtAdminID.Size = New System.Drawing.Size(57, 20)
        Me.txtAdminID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Level:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'txtAdminName
        '
        Me.txtAdminName.Enabled = False
        Me.txtAdminName.Location = New System.Drawing.Point(49, 47)
        Me.txtAdminName.Name = "txtAdminName"
        Me.txtAdminName.Size = New System.Drawing.Size(138, 20)
        Me.txtAdminName.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSavePassword)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtPassword)
        Me.GroupBox2.Location = New System.Drawing.Point(215, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 78)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Password"
        '
        'btnSavePassword
        '
        Me.btnSavePassword.Enabled = False
        Me.btnSavePassword.Location = New System.Drawing.Point(6, 45)
        Me.btnSavePassword.Name = "btnSavePassword"
        Me.btnSavePassword.Size = New System.Drawing.Size(189, 23)
        Me.btnSavePassword.TabIndex = 6
        Me.btnSavePassword.Text = "Save"
        Me.btnSavePassword.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(69, 19)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(126, 20)
        Me.txtPassword.TabIndex = 4
        '
        'lstAdmins
        '
        Me.lstAdmins.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmAdminID, Me.clmAdminName, Me.clmAdminLevel})
        Me.lstAdmins.FullRowSelect = True
        Me.lstAdmins.GridLines = True
        Me.lstAdmins.Location = New System.Drawing.Point(8, 6)
        Me.lstAdmins.MultiSelect = False
        Me.lstAdmins.Name = "lstAdmins"
        Me.lstAdmins.Size = New System.Drawing.Size(177, 352)
        Me.lstAdmins.TabIndex = 0
        Me.lstAdmins.UseCompatibleStateImageBehavior = False
        Me.lstAdmins.View = System.Windows.Forms.View.Details
        '
        'clmAdminID
        '
        Me.clmAdminID.Text = "ID"
        Me.clmAdminID.Width = 32
        '
        'clmAdminName
        '
        Me.clmAdminName.Text = "Name"
        Me.clmAdminName.Width = 101
        '
        'clmAdminLevel
        '
        Me.clmAdminLevel.Text = "Level"
        Me.clmAdminLevel.Width = 40
        '
        'cmsPlayerMenu
        '
        Me.cmsPlayerMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsPlayerView, Me.ToolStripSeparator6, Me.BanToolStripMenuItem, Me.ToolStripSeparator7, Me.KillToolStripMenuItem})
        Me.cmsPlayerMenu.Name = "ContextMenuStrip1"
        Me.cmsPlayerMenu.Size = New System.Drawing.Size(124, 82)
        '
        'cmsPlayerView
        '
        Me.cmsPlayerView.Name = "cmsPlayerView"
        Me.cmsPlayerView.Size = New System.Drawing.Size(123, 22)
        Me.cmsPlayerView.Text = "View Info"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(120, 6)
        '
        'BanToolStripMenuItem
        '
        Me.BanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KickToolStripMenuItem, Me.KickWithReasonToolStripMenuItem, Me.ToolStripSeparator1, Me.BanToolStripMenuItem1})
        Me.BanToolStripMenuItem.Name = "BanToolStripMenuItem"
        Me.BanToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.BanToolStripMenuItem.Text = "Kick/Ban"
        '
        'KickToolStripMenuItem
        '
        Me.KickToolStripMenuItem.Name = "KickToolStripMenuItem"
        Me.KickToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.KickToolStripMenuItem.Text = "Kick"
        '
        'KickWithReasonToolStripMenuItem
        '
        Me.KickWithReasonToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpammingToolStripMenuItem, Me.FlamingToolStripMenuItem, Me.DeathmatchingToolStripMenuItem, Me.HackingToolStripMenuItem, Me.ModificationsToolStripMenuItem, Me.ToolStripSeparator2, Me.CustomReasonToolStripMenuItem})
        Me.KickWithReasonToolStripMenuItem.Name = "KickWithReasonToolStripMenuItem"
        Me.KickWithReasonToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.KickWithReasonToolStripMenuItem.Text = "Kick with reason"
        '
        'SpammingToolStripMenuItem
        '
        Me.SpammingToolStripMenuItem.Name = "SpammingToolStripMenuItem"
        Me.SpammingToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SpammingToolStripMenuItem.Text = "Spamming"
        '
        'FlamingToolStripMenuItem
        '
        Me.FlamingToolStripMenuItem.Name = "FlamingToolStripMenuItem"
        Me.FlamingToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.FlamingToolStripMenuItem.Text = "Flaming"
        '
        'DeathmatchingToolStripMenuItem
        '
        Me.DeathmatchingToolStripMenuItem.Name = "DeathmatchingToolStripMenuItem"
        Me.DeathmatchingToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.DeathmatchingToolStripMenuItem.Text = "Deathmatching"
        '
        'HackingToolStripMenuItem
        '
        Me.HackingToolStripMenuItem.Name = "HackingToolStripMenuItem"
        Me.HackingToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.HackingToolStripMenuItem.Text = "Cheating"
        '
        'ModificationsToolStripMenuItem
        '
        Me.ModificationsToolStripMenuItem.Name = "ModificationsToolStripMenuItem"
        Me.ModificationsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ModificationsToolStripMenuItem.Text = "Modifications"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(153, 6)
        '
        'CustomReasonToolStripMenuItem
        '
        Me.CustomReasonToolStripMenuItem.Name = "CustomReasonToolStripMenuItem"
        Me.CustomReasonToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CustomReasonToolStripMenuItem.Text = "Custom reason"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'BanToolStripMenuItem1
        '
        Me.BanToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MinutesToolStripMenuItem, Me.MinutesToolStripMenuItem1, Me.HourToolStripMenuItem, Me.DayToolStripMenuItem, Me.WeekToolStripMenuItem, Me.PermanentToolStripMenuItem, Me.ToolStripSeparator3, Me.CustomReasonToolStripMenuItem1})
        Me.BanToolStripMenuItem1.Name = "BanToolStripMenuItem1"
        Me.BanToolStripMenuItem1.Size = New System.Drawing.Size(160, 22)
        Me.BanToolStripMenuItem1.Text = "Ban"
        '
        'MinutesToolStripMenuItem
        '
        Me.MinutesToolStripMenuItem.Name = "MinutesToolStripMenuItem"
        Me.MinutesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.MinutesToolStripMenuItem.Text = "15 minutes"
        '
        'MinutesToolStripMenuItem1
        '
        Me.MinutesToolStripMenuItem1.Name = "MinutesToolStripMenuItem1"
        Me.MinutesToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.MinutesToolStripMenuItem1.Text = "30 minutes"
        '
        'HourToolStripMenuItem
        '
        Me.HourToolStripMenuItem.Name = "HourToolStripMenuItem"
        Me.HourToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.HourToolStripMenuItem.Text = "1 hour"
        '
        'DayToolStripMenuItem
        '
        Me.DayToolStripMenuItem.Name = "DayToolStripMenuItem"
        Me.DayToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.DayToolStripMenuItem.Text = "1 day"
        '
        'WeekToolStripMenuItem
        '
        Me.WeekToolStripMenuItem.Name = "WeekToolStripMenuItem"
        Me.WeekToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.WeekToolStripMenuItem.Text = "1 week"
        '
        'PermanentToolStripMenuItem
        '
        Me.PermanentToolStripMenuItem.Name = "PermanentToolStripMenuItem"
        Me.PermanentToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PermanentToolStripMenuItem.Text = "Permanent"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(140, 6)
        '
        'CustomReasonToolStripMenuItem1
        '
        Me.CustomReasonToolStripMenuItem1.Name = "CustomReasonToolStripMenuItem1"
        Me.CustomReasonToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.CustomReasonToolStripMenuItem1.Text = "Custom time"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(120, 6)
        '
        'KillToolStripMenuItem
        '
        Me.KillToolStripMenuItem.Name = "KillToolStripMenuItem"
        Me.KillToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.KillToolStripMenuItem.Text = "Kill"
        '
        'tmrUpdateInfo
        '
        Me.tmrUpdateInfo.Interval = 600
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(677, 24)
        Me.mnuMain.TabIndex = 6
        Me.mnuMain.Text = "MenuStrip1"
        '
        'ConnectionToolStripMenuItem
        '
        Me.ConnectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisconnectToolStripMenuItem})
        Me.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem"
        Me.ConnectionToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.ConnectionToolStripMenuItem.Text = "Connection"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DisconnectToolStripMenuItem.Text = "Disconnect"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SAMPForumsToolStripMenuItem, Me.SAMPWikiToolStripMenuItem, Me.ToolStripSeparator4, Me.JaTochNietDanToolStripMenuItem, Me.ContactAuthorToolStripMenuItem, Me.ToolStripSeparator5, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'SAMPForumsToolStripMenuItem
        '
        Me.SAMPForumsToolStripMenuItem.Name = "SAMPForumsToolStripMenuItem"
        Me.SAMPForumsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SAMPForumsToolStripMenuItem.Text = "SA-MP Forums"
        '
        'SAMPWikiToolStripMenuItem
        '
        Me.SAMPWikiToolStripMenuItem.Name = "SAMPWikiToolStripMenuItem"
        Me.SAMPWikiToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SAMPWikiToolStripMenuItem.Text = "SA-MP Wiki"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(153, 6)
        '
        'JaTochNietDanToolStripMenuItem
        '
        Me.JaTochNietDanToolStripMenuItem.Name = "JaTochNietDanToolStripMenuItem"
        Me.JaTochNietDanToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.JaTochNietDanToolStripMenuItem.Text = "JaTochNietDan"
        '
        'ContactAuthorToolStripMenuItem
        '
        Me.ContactAuthorToolStripMenuItem.Name = "ContactAuthorToolStripMenuItem"
        Me.ContactAuthorToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ContactAuthorToolStripMenuItem.Text = "Contact Author"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(153, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'frmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 420)
        Me.Controls.Add(Me.mnuMain)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConnect"
        Me.Opacity = 0.0R
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Remote Administrator"
        Me.TabControl1.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabBanManage.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tabAdminManage.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.cmsPlayerMenu.ResumeLayout(False)
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtSendtext As System.Windows.Forms.TextBox
    Friend WithEvents cmsPlayerMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPlayerView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rtbChat As System.Windows.Forms.RichTextBox
    Friend WithEvents KickToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KickWithReasonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpammingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlamingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeathmatchingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HackingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CustomReasonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinutesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinutesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HourToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeekToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CustomReasonToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrUpdateInfo As System.Windows.Forms.Timer
    Friend WithEvents lstPlayer As System.Windows.Forms.ListView
    Friend WithEvents clmID As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmName As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SAMPForumsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SAMPWikiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents JaTochNietDanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContactAuthorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PermanentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisconnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabAdminManage As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCreateAccount As System.Windows.Forms.Button
    Friend WithEvents txtNewAdminName As System.Windows.Forms.TextBox
    Friend WithEvents cmbNewAdminLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteAccount As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAdminID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAdminName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSavePassword As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lstAdmins As System.Windows.Forms.ListView
    Friend WithEvents clmAdminName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNewAdminPassword As System.Windows.Forms.TextBox
    Friend WithEvents clmAdminID As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmAdminLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabBanManage As System.Windows.Forms.TabPage
    Friend WithEvents lstBans As System.Windows.Forms.ListView
    Friend WithEvents clmBanName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmBanReason As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBanAdmin As System.Windows.Forms.TextBox
    Friend WithEvents txtBanIP As System.Windows.Forms.TextBox
    Friend WithEvents txtBanName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents clnBanned As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBanID As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveBan As System.Windows.Forms.Button
    Friend WithEvents cmbBanUntilMinutes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBanUntilHours As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents clnBannedUntil As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbBanMinutes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBanHours As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBanReason As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteBan As System.Windows.Forms.Button
    Friend WithEvents btnPreviousPage As System.Windows.Forms.Button
    Friend WithEvents btnNextPage As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents btnFilterBans As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReload As System.Windows.Forms.Button

End Class
