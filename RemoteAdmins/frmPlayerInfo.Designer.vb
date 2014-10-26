<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayerInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayerInfo))
        Me.txtSkin = New System.Windows.Forms.TextBox()
        Me.txtWorld = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInterior = New System.Windows.Forms.TextBox()
        Me.txtScore = New System.Windows.Forms.TextBox()
        Me.lblCurrentVehicle = New System.Windows.Forms.Label()
        Me.pbarVehicleHealth = New System.Windows.Forms.ProgressBar()
        Me.txtVHealth = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbWeaponID = New System.Windows.Forms.ComboBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pbarArmour = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pbarHealth = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtArmour = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHealth = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPX = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPY = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPZ = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPA = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbSpeed = New System.Windows.Forms.ComboBox()
        Me.txtVelocityY = New System.Windows.Forms.TextBox()
        Me.txtVelocityX = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtVelocityZ = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkTracking = New System.Windows.Forms.CheckBox()
        Me.panInfo = New System.Windows.Forms.Panel()
        Me.panHideHorizontal = New System.Windows.Forms.Panel()
        Me.picMarker = New System.Windows.Forms.PictureBox()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.picCurrentVehicle = New System.Windows.Forms.PictureBox()
        Me.picSkin = New System.Windows.Forms.PictureBox()
        Me.panHideVertical = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.panInfo.SuspendLayout()
        CType(Me.picMarker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCurrentVehicle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSkin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSkin
        '
        Me.txtSkin.Location = New System.Drawing.Point(11, 136)
        Me.txtSkin.Name = "txtSkin"
        Me.txtSkin.Size = New System.Drawing.Size(56, 20)
        Me.txtSkin.TabIndex = 0
        '
        'txtWorld
        '
        Me.txtWorld.Location = New System.Drawing.Point(149, 26)
        Me.txtWorld.Name = "txtWorld"
        Me.txtWorld.Size = New System.Drawing.Size(165, 20)
        Me.txtWorld.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Virtual World:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Interior:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Weapon:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(105, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Score:"
        '
        'txtInterior
        '
        Me.txtInterior.Location = New System.Drawing.Point(149, 52)
        Me.txtInterior.Name = "txtInterior"
        Me.txtInterior.Size = New System.Drawing.Size(165, 20)
        Me.txtInterior.TabIndex = 2
        '
        'txtScore
        '
        Me.txtScore.Location = New System.Drawing.Point(149, 104)
        Me.txtScore.Name = "txtScore"
        Me.txtScore.Size = New System.Drawing.Size(165, 20)
        Me.txtScore.TabIndex = 4
        '
        'lblCurrentVehicle
        '
        Me.lblCurrentVehicle.AutoSize = True
        Me.lblCurrentVehicle.Location = New System.Drawing.Point(13, 21)
        Me.lblCurrentVehicle.Name = "lblCurrentVehicle"
        Me.lblCurrentVehicle.Size = New System.Drawing.Size(82, 13)
        Me.lblCurrentVehicle.TabIndex = 18
        Me.lblCurrentVehicle.Text = "Current Vehicle:"
        '
        'pbarVehicleHealth
        '
        Me.pbarVehicleHealth.Location = New System.Drawing.Point(16, 166)
        Me.pbarVehicleHealth.Maximum = 1000
        Me.pbarVehicleHealth.Name = "pbarVehicleHealth"
        Me.pbarVehicleHealth.Size = New System.Drawing.Size(202, 23)
        Me.pbarVehicleHealth.TabIndex = 19
        '
        'txtVHealth
        '
        Me.txtVHealth.Location = New System.Drawing.Point(98, 197)
        Me.txtVHealth.Name = "txtVHealth"
        Me.txtVHealth.Size = New System.Drawing.Size(120, 20)
        Me.txtVHealth.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Vehicle Health:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbWeaponID)
        Me.GroupBox1.Controls.Add(Me.lblState)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.pbarArmour)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.pbarHealth)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtArmour)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtHealth)
        Me.GroupBox1.Controls.Add(Me.picSkin)
        Me.GroupBox1.Controls.Add(Me.txtSkin)
        Me.GroupBox1.Controls.Add(Me.txtWorld)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtInterior)
        Me.GroupBox1.Controls.Add(Me.txtScore)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 227)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Player Data"
        '
        'cmbWeaponID
        '
        Me.cmbWeaponID.FormattingEnabled = True
        Me.cmbWeaponID.Items.AddRange(New Object() {"Fists", "Brass Knuckles", "Golf Club", "Nightstick", "Knife", "Baseball Bat", "Shovel", "Pool Cue", "Katana", "Chainsaw", "Large Dildo", "Small Dildo", "Vibrator", "Silver Vibrator", "Flowers", "Cane", "Grenade", "Tear Gas", "Molotov Cocktail", "Invalid", "Invalid", "Invalid", "9mm", "Silenced 9mm", "Desert Eagle", "Shotgun", "Sawnoff Shotgun", "Combat Shotgun", "Micro SMG/Uzi", "MP5", "AK-47", "M4", "Tec-9", "Country Rifle", "Sniper Rifle", "RPG", "HS Rocket", "Flamethrower", "Minigun", "Satchel Charge", "Detonator", "Spraycan", "Fire Extinguisher", "Camera", "Night Vis Goggles", "Thermal Goggles", "Parachute"})
        Me.cmbWeaponID.Location = New System.Drawing.Point(149, 78)
        Me.cmbWeaponID.Name = "cmbWeaponID"
        Me.cmbWeaponID.Size = New System.Drawing.Size(165, 21)
        Me.cmbWeaponID.TabIndex = 27
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(146, 10)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(73, 13)
        Me.lblState.TabIndex = 26
        Me.lblState.Text = "State: On foot"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Armour:"
        '
        'pbarArmour
        '
        Me.pbarArmour.ForeColor = System.Drawing.Color.Red
        Me.pbarArmour.Location = New System.Drawing.Point(57, 205)
        Me.pbarArmour.Name = "pbarArmour"
        Me.pbarArmour.Size = New System.Drawing.Size(257, 13)
        Me.pbarArmour.TabIndex = 24
        Me.pbarArmour.Value = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 185)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Health:"
        '
        'pbarHealth
        '
        Me.pbarHealth.ForeColor = System.Drawing.Color.Red
        Me.pbarHealth.Location = New System.Drawing.Point(57, 185)
        Me.pbarHealth.Name = "pbarHealth"
        Me.pbarHealth.Size = New System.Drawing.Size(257, 13)
        Me.pbarHealth.TabIndex = 17
        Me.pbarHealth.Value = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(100, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Armour:"
        '
        'txtArmour
        '
        Me.txtArmour.Location = New System.Drawing.Point(149, 156)
        Me.txtArmour.Name = "txtArmour"
        Me.txtArmour.Size = New System.Drawing.Size(165, 20)
        Me.txtArmour.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(102, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Health:"
        '
        'txtHealth
        '
        Me.txtHealth.Location = New System.Drawing.Point(149, 130)
        Me.txtHealth.Name = "txtHealth"
        Me.txtHealth.Size = New System.Drawing.Size(165, 20)
        Me.txtHealth.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.picCurrentVehicle)
        Me.GroupBox2.Controls.Add(Me.lblCurrentVehicle)
        Me.GroupBox2.Controls.Add(Me.pbarVehicleHealth)
        Me.GroupBox2.Controls.Add(Me.txtVHealth)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(338, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(230, 226)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vehicle Data"
        '
        'txtPX
        '
        Me.txtPX.Location = New System.Drawing.Point(29, 20)
        Me.txtPX.Name = "txtPX"
        Me.txtPX.Size = New System.Drawing.Size(165, 20)
        Me.txtPX.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "X:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Y:"
        '
        'txtPY
        '
        Me.txtPY.Location = New System.Drawing.Point(29, 46)
        Me.txtPY.Name = "txtPY"
        Me.txtPY.Size = New System.Drawing.Size(165, 20)
        Me.txtPY.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Z:"
        '
        'txtPZ
        '
        Me.txtPZ.Location = New System.Drawing.Point(29, 72)
        Me.txtPZ.Name = "txtPZ"
        Me.txtPZ.Size = New System.Drawing.Size(165, 20)
        Me.txtPZ.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "A:"
        '
        'txtPA
        '
        Me.txtPA.Location = New System.Drawing.Point(29, 98)
        Me.txtPA.Name = "txtPA"
        Me.txtPA.Size = New System.Drawing.Size(165, 20)
        Me.txtPA.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPY)
        Me.GroupBox3.Controls.Add(Me.txtPX)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtPA)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtPZ)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 304)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 128)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Player Coordinates"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.cmbSpeed)
        Me.GroupBox4.Controls.Add(Me.txtVelocityY)
        Me.GroupBox4.Controls.Add(Me.txtVelocityX)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.txtSpeed)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.txtVelocityZ)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 438)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 151)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Velocity"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 127)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 13)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Speed Measurement:"
        '
        'cmbSpeed
        '
        Me.cmbSpeed.FormattingEnabled = True
        Me.cmbSpeed.Items.AddRange(New Object() {"mph", "kph"})
        Me.cmbSpeed.Location = New System.Drawing.Point(120, 124)
        Me.cmbSpeed.Name = "cmbSpeed"
        Me.cmbSpeed.Size = New System.Drawing.Size(74, 21)
        Me.cmbSpeed.TabIndex = 16
        '
        'txtVelocityY
        '
        Me.txtVelocityY.Location = New System.Drawing.Point(29, 46)
        Me.txtVelocityY.Name = "txtVelocityY"
        Me.txtVelocityY.Size = New System.Drawing.Size(165, 20)
        Me.txtVelocityY.TabIndex = 13
        '
        'txtVelocityX
        '
        Me.txtVelocityX.Location = New System.Drawing.Point(29, 20)
        Me.txtVelocityX.Name = "txtVelocityX"
        Me.txtVelocityX.Size = New System.Drawing.Size(165, 20)
        Me.txtVelocityX.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Speed:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "X:"
        '
        'txtSpeed
        '
        Me.txtSpeed.Location = New System.Drawing.Point(53, 98)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(141, 20)
        Me.txtSpeed.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(17, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Y:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(17, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Z:"
        '
        'txtVelocityZ
        '
        Me.txtVelocityZ.Location = New System.Drawing.Point(29, 72)
        Me.txtVelocityZ.Name = "txtVelocityZ"
        Me.txtVelocityZ.Size = New System.Drawing.Size(165, 20)
        Me.txtVelocityZ.TabIndex = 14
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkTracking)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 245)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 53)
        Me.GroupBox5.TabIndex = 39
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Tracking settings"
        '
        'chkTracking
        '
        Me.chkTracking.AutoSize = True
        Me.chkTracking.Location = New System.Drawing.Point(32, 23)
        Me.chkTracking.Name = "chkTracking"
        Me.chkTracking.Size = New System.Drawing.Size(134, 17)
        Me.chkTracking.TabIndex = 0
        Me.chkTracking.Text = "Enable Tracking Mode"
        Me.chkTracking.UseVisualStyleBackColor = True
        '
        'panInfo
        '
        Me.panInfo.AutoScroll = True
        Me.panInfo.Controls.Add(Me.picMarker)
        Me.panInfo.Controls.Add(Me.picMap)
        Me.panInfo.Location = New System.Drawing.Point(218, 245)
        Me.panInfo.Name = "panInfo"
        Me.panInfo.Size = New System.Drawing.Size(374, 366)
        Me.panInfo.TabIndex = 40
        '
        'panHideHorizontal
        '
        Me.panHideHorizontal.Location = New System.Drawing.Point(218, 587)
        Me.panHideHorizontal.Name = "panHideHorizontal"
        Me.panHideHorizontal.Size = New System.Drawing.Size(364, 52)
        Me.panHideHorizontal.TabIndex = 28
        '
        'picMarker
        '
        Me.picMarker.Image = Global.RemoteAdmins.My.Resources.Resources.mapMarker
        Me.picMarker.Location = New System.Drawing.Point(12, 59)
        Me.picMarker.Name = "picMarker"
        Me.picMarker.Size = New System.Drawing.Size(10, 10)
        Me.picMarker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMarker.TabIndex = 28
        Me.picMarker.TabStop = False
        '
        'picMap
        '
        Me.picMap.Image = Global.RemoteAdmins.My.Resources.Resources.gtasa_aerial_map_small
        Me.picMap.Location = New System.Drawing.Point(0, 0)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(350, 350)
        Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMap.TabIndex = 27
        Me.picMap.TabStop = False
        '
        'picCurrentVehicle
        '
        Me.picCurrentVehicle.Image = Global.RemoteAdmins.My.Resources.Resources.no_vehicle
        Me.picCurrentVehicle.Location = New System.Drawing.Point(16, 37)
        Me.picCurrentVehicle.Name = "picCurrentVehicle"
        Me.picCurrentVehicle.Size = New System.Drawing.Size(202, 123)
        Me.picCurrentVehicle.TabIndex = 17
        Me.picCurrentVehicle.TabStop = False
        '
        'picSkin
        '
        Me.picSkin.Image = Global.RemoteAdmins.My.Resources.Resources.Skin_1
        Me.picSkin.Location = New System.Drawing.Point(11, 29)
        Me.picSkin.Name = "picSkin"
        Me.picSkin.Size = New System.Drawing.Size(59, 101)
        Me.picSkin.TabIndex = 1
        Me.picSkin.TabStop = False
        '
        'panHideVertical
        '
        Me.panHideVertical.Location = New System.Drawing.Point(568, 244)
        Me.panHideVertical.Name = "panHideVertical"
        Me.panHideVertical.Size = New System.Drawing.Size(17, 345)
        Me.panHideVertical.TabIndex = 28
        '
        'frmPlayerInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 601)
        Me.Controls.Add(Me.panHideHorizontal)
        Me.Controls.Add(Me.panHideVertical)
        Me.Controls.Add(Me.panInfo)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPlayerInfo"
        Me.Text = "Viewing info for"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.panInfo.ResumeLayout(False)
        Me.panInfo.PerformLayout()
        CType(Me.picMarker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCurrentVehicle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSkin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picSkin As System.Windows.Forms.PictureBox
    Friend WithEvents txtSkin As System.Windows.Forms.TextBox
    Friend WithEvents txtWorld As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInterior As System.Windows.Forms.TextBox
    Friend WithEvents txtScore As System.Windows.Forms.TextBox
    Friend WithEvents picCurrentVehicle As System.Windows.Forms.PictureBox
    Friend WithEvents lblCurrentVehicle As System.Windows.Forms.Label
    Friend WithEvents pbarVehicleHealth As System.Windows.Forms.ProgressBar
    Friend WithEvents txtVHealth As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pbarHealth As System.Windows.Forms.ProgressBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pbarArmour As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtArmour As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHealth As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents txtPX As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPY As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPZ As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPA As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVelocityY As System.Windows.Forms.TextBox
    Friend WithEvents txtVelocityX As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtVelocityZ As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTracking As System.Windows.Forms.CheckBox
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents cmbWeaponID As System.Windows.Forms.ComboBox
    Friend WithEvents panInfo As System.Windows.Forms.Panel
    Friend WithEvents panHideHorizontal As System.Windows.Forms.Panel
    Friend WithEvents picMarker As System.Windows.Forms.PictureBox
    Friend WithEvents panHideVertical As System.Windows.Forms.Panel
End Class
