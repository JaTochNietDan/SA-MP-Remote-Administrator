Public Class frmPlayerInfo
    Public g_VehicleModelNames() As String = {"Landstalker", "Bravura", "Buffalo", "Linerunner", "Perenniel", "Sentinel", "Dumper", "Firetruck", "Trashmaster", "Stretch", "Manana", "Infernus", "Voodoo", "Pony", "Mule", "Cheetah", "Ambulance", "Leviathan", "Moonbeam", "Esperanto", "Taxi", "Washington", "Bobcat", "Mr Whoopee", "BF Injection", "Hunter", "Premier", "Enforcer", "Securicar", "Banshee", "Predator", "Bus", "Rhino", "Barracks", "Hotknife", "Article Trailer", "Previon", "Coach", "Cabbie", "Stallion", "Rumpo", "RC Bandit", "Romero", "Packer", "Monster", "Admiral", "Squallo", "Seasparrow", "Pizzaboy", "Tram", "Article Trailer 2", "Turismo", "Speeder", "Reefer", "Tropic", "Flatbed", "Yankee", "Caddy", "Solair", "Berkley's RC Van", "Skimmer", "PCJ-600", "Faggio", "Freeway", "RC Baron", "RC Raider", "Glendale", "Oceanic", "Sanchez", "Sparrow", "Patriot", "Quad", "Coastguard", "Dinghy", "Hermes", "Sabre", "Rustler", "ZR-350", "Walton", "Regina", "Comet", "BMX", "Burrito", "Camper", "Marquis", "Baggage", "Dozer", "Maverick", "SAN News Maverick", "Rancher", "FBI Rancher", "Virgo", "Greenwood", "Jetmax", "Hotring Racer", "Sandking", "Blista Compact", "Police Maverick", "Boxville", "Benson", "Mesa", "RC Goblin", "Hotring Racer", "Hotring Racer", "Bloodring Banger", "Rancher", "Super GT", "Elegant", "Journey", "Bike", "Mountain Bike", "Beagle", "Cropduster", "Stuntplane", "Tanker", "Roadtrain", "Nebula", "Majestic", "Buccaneer", "Shamal", "Hydra", "FCR-900", "NRG-500", "Cop Bike (HPV-1000)", "Cement Truck", "Towtruck", "Fortune", "Cadrona", "FBI Truck", "Willard", "Forklift", "Tractor", "Combine Harvester", "Feltzer", "Remington", "Slamvan", "Blade", "Freight (Train)", "Brownstreak (Train)", "Vortex", "Vincent", "Bullet", "Clover", "Sadler", "Firetruck LA", "Hustler", "Intruder", "Primo", "Cargobob", "Tampa", "Sunrise", "Merit", "Utility Van", "Nevada", "Yosemite", "Windsor", "Monster ""A""", "Monster ""B""", "Uranus", "Jester", "Sultan", "Stratum", "Elegy", "Raindance", "RC Tiger", "Flash", "Tahoma", "Savanna", "Bandito", "Freight Flat Trailer (Train)", "Streak Trailer (Train)", "Kart", "Mower", "Dune", "Sweeper", "Broadway", "Tornado", "AT-400", "DFT-30", "Huntley", "Stafford", "BF-400", "Newsvan", "Tug", "Petrol Tanker", "Emperor", "Wayfarer", "Euros", "Hotdog", "Club", "Freight Box Trailer (Train)", "Article Trailer 3", "Andromada", "Dodo", "RC Cam", "Launch", "Police Car (LSPD)", "Police Car (SFPD)", "Police Car (LVPD)", "Police Ranger", "Picador", "S.W.A.T.", "Alpha", "Phoenix", "Glendale Shit", "Sadler Shit", "Baggage Trailer ""A""", "Baggage Trailer ""B""", "Tug Stairs Trailer", "Boxburg", "Farm Trailer", "Utility Trailer"}
    
    Private Sub frmPlayerInfo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GC.Collect()

        frmConnect.tmrUpdateInfo.Enabled = False
        frmConnect.cmsPlayerView.Enabled = True
        frmConnect.blnInfoEnabled = False

        frmConnect.mapForm.Close()

        frmConnect.infoID = -1

        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMap.Click
        frmConnect.mapForm.Show()
    End Sub

    Private Sub cmbSpeed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSpeed.SelectedIndexChanged
        My.Settings.Speedpref = Convert.ToUInt16(cmbSpeed.SelectedIndex)

        My.Settings.Save()
    End Sub

    Private Sub chkTracking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTracking.CheckedChanged
        If chkTracking.Checked Then
            picMap.Width = My.Resources.gtasa_aerial_map.Width
            picMap.Height = My.Resources.gtasa_aerial_map.Height
            panInfo.VerticalScroll.Maximum = My.Resources.gtasa_aerial_map.Height
            panInfo.HorizontalScroll.Maximum = My.Resources.gtasa_aerial_map.Width
            picMap.Image = New Bitmap(My.Resources.gtasa_aerial_map, New Size(My.Resources.gtasa_aerial_map.Width, My.Resources.gtasa_aerial_map.Height))
        Else
            picMap.Width = My.Resources.gtasa_aerial_map_small.Width
            picMap.Height = My.Resources.gtasa_aerial_map_small.Height
            panInfo.VerticalScroll.Value = 0
            panInfo.HorizontalScroll.Value = 0
            panInfo.VerticalScroll.Maximum = My.Resources.gtasa_aerial_map_small.Height
            panInfo.HorizontalScroll.Maximum = My.Resources.gtasa_aerial_map_small.Width
            picMap.Image = New Bitmap(My.Resources.gtasa_aerial_map_small, New Size(My.Resources.gtasa_aerial_map_small.Width, My.Resources.gtasa_aerial_map_small.Height))
        End If

        GC.Collect()
    End Sub

    Private Sub btnSetSkin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsNumeric(txtSkin.Text) Then
            setSendMode()
            frmConnect.SendDataToServer("skin:" + Convert.ToString(frmConnect.infoID) + ":" + txtSkin.Text)
        End If
    End Sub

    Private Sub txtSkin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSkin.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            btnSetSkin_Click(sender, e)
        End If
    End Sub

    Private Sub txtHealth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHealth.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            If IsNumeric(txtHealth.Text) Then
                setSendMode()
                frmConnect.SendDataToServer("health:" + Convert.ToString(frmConnect.infoID) + ":" + txtHealth.Text + ":")
            End If
        End If
    End Sub

    Private Sub txtArmour_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArmour.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            If IsNumeric(txtHealth.Text) Then
                setSendMode()
                frmConnect.SendDataToServer("armour:" + Convert.ToString(frmConnect.infoID) + ":" + txtArmour.Text)
            End If
        End If
    End Sub

    Private Sub txtInterior_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInterior.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            If IsNumeric(txtHealth.Text) Then
                setSendMode()
                frmConnect.SendDataToServer("interior:" + Convert.ToString(frmConnect.infoID) + ":" + txtInterior.Text)
            End If
        End If
    End Sub

    Private Sub txtWorld_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWorld.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            If IsNumeric(txtHealth.Text) Then
                setSendMode()
                frmConnect.SendDataToServer("world:" + Convert.ToString(frmConnect.infoID) + ":" + txtWorld.Text)
            End If
        End If
    End Sub

    Private Sub txtScore_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScore.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            If IsNumeric(txtHealth.Text) Then
                setSendMode()
                frmConnect.SendDataToServer("score:" + Convert.ToString(frmConnect.infoID) + ":" + txtScore.Text)
            End If
        End If
    End Sub

    Private Sub frmPlayerInfo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        chkTracking.Focus()
    End Sub

    Private Sub txtVHealth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVHealth.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            If IsNumeric(txtHealth.Text) Then
                setSendMode()
                frmConnect.SendDataToServer("vhealth:" + Convert.ToString(frmConnect.infoID) + ":" + txtVHealth.Text)
            End If
        End If
    End Sub

    Private Sub setSendMode()
        frmConnect.tmrUpdateInfo.Enabled = False

        frmConnect.blnInfoEnabled = False
        frmConnect.setInfoFormsEnabled(False)
    End Sub

    Private Sub frmPlayerInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmbWeaponID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWeaponID.SelectedIndexChanged
        If cmbWeaponID.Focused Then
            setSendMode()
            frmConnect.SendDataToServer("weapon:" + Convert.ToString(frmConnect.infoID) + ":" + cmbWeaponID.SelectedIndex.ToString)
        End If
    End Sub
End Class