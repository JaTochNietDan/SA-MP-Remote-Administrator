'Turning this off specifically for ArrayLists so they don't throw up warnings about not having a type set for them.
'Might work on this at a later time, not for now.
Option Strict Off

Imports System.Net.Sockets
Imports System.Security.Cryptography
Imports System.Text
Imports System.DateTime

Public Class frmConnect
    Public Delegate Sub DataReceived(ByVal result As String)

    'Declaring form instances to be loaded and unloaded later, form instances
    'are actually always existant, they are only hidden
    Dim infoForm As New frmPlayerInfo
    Public mapForm As New frmPlayerMap
    Dim frmDebug As New Debugger
    Dim WithEvents frmLog As New frmLogin

    'Declaring the global TcpClient and StateObject variables for handling
    'the TCP client stuff.
    Dim Client As TcpClient
    Dim state As New StateObject

    'Declaring the player colours and player states so they are identifyable by ID
    Dim playercolours() As String = {"FF8C13", "C715FF", "20B2AA", "DC143C", "6495ED", "f0e68c", "778899", "FF1493", "F4A460", "EE82EE", "FFD720", "8b4513", "4949A0", "148b8b", "14ff7f", "556b2f", "0FD9FA", "10DC29", "534081", "0495CD", "EF6CE8", "BD34DA", "247C1B", "0C8E5D", "635B03", "CB7ED3", "65ADEB", "5C1ACC", "F2F853", "11F891", "7B39AA", "53EB10", "54137D", "275222", "F09F5B", "3D0A4F", "22F767", "D63034", "9A6980", "DFB935", "3793FA", "90239D", "E9AB2F", "AF2FF3", "057F94", "B98519", "388EEA", "028151", "A55043", "0DE018", "93AB1C", "95BAF0", "369976", "18F71F", "4B8987", "491B9E", "829DC7", "BCE635", "CEA6DF", "20D4AD", "2D74FD", "3C1C0D", "12D6D4", "48C000", "2A51E2", "E3AC12", "FC42A8", "2FC827", "1A30BF", "B740C2", "42ACF5", "2FD9DE", "FAFB71", "05D1CD", "C471BD", "94436E", "C1F7EC", "CE79EE", "BD1EF2", "93B7E4", "3214AA", "184D3B", "AE4B99", "7E49D7", "4C436E", "FA24CC", "CE76BE", "A04E0A", "9F945C", "DCDE3D", "10C9C5", "70524D", "0BE472", "8A2CD7", "6152C2", "CF72A9", "E59338", "EEDC2D", "D8C762", "D8C762", "FF8C13", "C715FF", "20B2AA", "DC143C", "6495ED", "f0e68c", "778899", "FF1493", "F4A460", "EE82EE", "FFD720", "8b4513", "4949A0", "148b8b", "14ff7f", "556b2f", "0FD9FA", "10DC29", "534081", "0495CD", "EF6CE8", "BD34DA", "247C1B", "0C8E5D", "635B03", "CB7ED3", "65ADEB", "5C1ACC", "F2F853", "11F891", "7B39AA", "53EB10", "54137D", "275222", "F09F5B", "3D0A4F", "22F767", "D63034", "9A6980", "DFB935", "3793FA", "90239D", "E9AB2F", "AF2FF3", "057F94", "B98519", "388EEA", "028151", "A55043", "0DE018", "93AB1C", "95BAF0", "369976", "18F71F", "4B8987", "491B9E", "829DC7", "BCE635", "CEA6DF", "20D4AD", "2D74FD", "3C1C0D", "12D6D4", "48C000", "2A51E2", "E3AC12", "FC42A8", "2FC827", "1A30BF", "B740C2", "42ACF5", "2FD9DE", "FAFB71", "05D1CD", "C471BD", "94436E", "C1F7EC", "CE79EE", "BD1EF2", "93B7E4", "3214AA", "184D3B", "AE4B99", "7E49D7", "4C436E", "FA24CC", "CE76BE", "A04E0A", "9F945C", "DCDE3D", "10C9C5", "70524D", "0BE472", "8A2CD7", "6152C2", "CF72A9", "E59338", "EEDC2D", "D8C762", "D8C762FF"}
    Dim playerstates() As String = {"NONE", "On foot", "Driving", "Passenger", "Exiting vehicle", "Entering vehicle (driver)", "Entering vehicle (passenger)", "Wasted", "Spawned", "Spectating"}

    'These variables are used to store the previous messages typed into the chatbox and to get which one they are currently viewing.
    Dim prevMessages As New ArrayList(9)
    Dim prevView As Integer = -1
    Dim prevCount As Integer = 0

    'This variable is used to hold information regarding the current tab name index
    Dim tabNameIndex As Integer = 0
    Dim tabNameSearch As String
    Dim tabStartIndex As Integer = 0
    Dim tabEndIndex As Integer = 0

    'Declaring infoPermissions which will store the permissions of the administrator
    'so we can use them to enable/disable some GUI aspects (totally asthethic, the final check is done server sided)
    Dim infoPermissions(7) As Boolean

    'Declaring a couple of variables, nothing too special or important
    Dim infoname As String
    Public blnInfoEnabled As Boolean = False
    Dim blnAuthed As Boolean = False
    Dim intLevel As Integer = 0
    Dim strLogName As String
    Dim blnInitialBanLoad As Boolean = False

    'A few specific permission variables for allowing access to certain forms/tabs based on level
    Dim permissionViewInfo As Boolean = False
    Dim permissionAdminManage As Boolean = False
    Dim permissionBanManage As Boolean = False

    'This variable will be used to keep track of the ban page you are viewing
    Dim currentBanIndex As Integer = 0

    'These ArrayLists will hold crucial information about each ban so it doesn't
    'have to keep asking the server whenever you highlight a new ban
    Dim banID As New ArrayList()
    Dim banIP As New ArrayList()
    Dim banAdmin As New ArrayList()
    Dim banStamp As New ArrayList()
    Dim banTime As New ArrayList()
    Dim banMinutes As New ArrayList()

    'This is to keep track of the ID that you are currently viewing the info of
    Public infoID As Integer = -1

    'This function is called whenever data is received by the TCPClient, we use it
    'to handle all of the main live data represented in the GUI.
    Public Sub UpdateText(ByVal result As String)
        'This will start printing lines to the debug form if it is no longer hidden
        If frmDebug.Visible Then
            frmDebug.TextBox1.Text += result + vbNewLine
        End If

        'Split the initial string by colon for later analysis
        Dim str() As String = result.Split(":"c)

        'This is the procedure for when the client is viewing live player information 
        If str(0) = "info" Then
            'If this boolean is false, then don't continue the data request loop
            If blnInfoEnabled = False Then Return

            'Check if the VehicleID is 0, if it is, the player is not in a vehicle.
            'Otherwise display the vehicle information
            If Convert.ToInt16(str(1)) = 0 Then
                infoForm.picCurrentVehicle.Image = My.Resources.no_vehicle
                infoForm.lblCurrentVehicle.Text = "Current Vehicle: None"

                infoForm.txtVHealth.Enabled = False
                infoForm.pbarVehicleHealth.Value = 0
            Else
                infoForm.picCurrentVehicle.Image = CType(My.Resources.ResourceManager.GetObject("Vehicle_" + str(1)), Image)

                infoForm.lblCurrentVehicle.Text = "Current Vehicle: " + infoForm.g_VehicleModelNames(Convert.ToInt16(str(1)) - 400) + " (" + str(1) + ")"

                UpdateTextbox(infoForm.txtVHealth, str(9))
                infoForm.pbarVehicleHealth.Value = If(Convert.ToInt32(str(9)) > 1000, 1000, Convert.ToInt32(str(9)))

                infoForm.txtVHealth.Enabled = True
                infoForm.pbarVehicleHealth.Enabled = True
            End If

            infoForm.picSkin.Image = CType(My.Resources.ResourceManager.GetObject("Skin_" + str(2)), Image)

            UpdateTextbox(infoForm.txtSkin, str(2))
            UpdateTextbox(infoForm.txtWorld, str(3))
            UpdateTextbox(infoForm.txtInterior, str(4))
            If Not infoForm.cmbWeaponID.Focused Then
                infoForm.cmbWeaponID.SelectedIndex = Convert.ToInt16(Trim(str(5)))
            End If
            UpdateTextbox(infoForm.txtScore, str(6))
            UpdateTextbox(infoForm.txtHealth, str(7))
            UpdateTextbox(infoForm.txtArmour, str(8))
            UpdateTextbox(infoForm.txtPX, str(10))
            UpdateTextbox(infoForm.txtPY, str(11))
            UpdateTextbox(infoForm.txtPZ, str(12))
            UpdateTextbox(infoForm.txtPA, str(13))
            UpdateTextbox(infoForm.txtVelocityX, str(14))
            UpdateTextbox(infoForm.txtVelocityY, str(15))
            UpdateTextbox(infoForm.txtVelocityZ, str(16))

            infoForm.pbarHealth.Value = If(Convert.ToInt32(str(7)) > 100, 100, Convert.ToInt32(str(7)))
            infoForm.pbarArmour.Value = If(Convert.ToInt32(str(8)) > 100, 100, Convert.ToInt32(str(8)))

            CalculateSpeed(Convert.ToDouble(str(14)), Convert.ToDouble(str(15)), Convert.ToDouble(str(16)))

            If Convert.ToInt32(str(17)) = -1 Then infoForm.lblState.Text = "State: Game Paused" Else infoForm.lblState.Text = "State: " + playerstates(Convert.ToInt32(str(17)))

            Dim x As Double
            Dim y As Double

            If mapForm.Visible Then
                x = (((Convert.ToDouble(str(10)) + (6000 / 2)) / 6000) * mapForm.picMap.Width) - (10 / 2)
                y = ((((Convert.ToDouble(str(11)) * -1) + (6000 / 2)) / 6000) * mapForm.picMap.Height) - (10 / 2)

                mapForm.picMarker.Location = New Point(x, y)
            Else
                If infoForm.chkTracking.Checked Then
                    x = (((Convert.ToDouble(str(10)) + (6000 / 2)) / 6000) * 2000) - (6 / 2)
                    y = ((((Convert.ToDouble(str(11)) * -1) + (6000 / 2)) / 6000) * 2000) - (6 / 2)

                    infoForm.picMarker.Location = New Point(If(Convert.ToDecimal(x) - 175 < 0, x, 173), If(Convert.ToDecimal(y) - 175 < 0, y, 173))

                    infoForm.panInfo.HorizontalScroll.Value = If(Convert.ToDecimal(x) - 175 < 0, 0, Convert.ToDecimal(x) - 175)
                    infoForm.panInfo.VerticalScroll.Value = If(Convert.ToDecimal(y) - 175 < 0, 0, Convert.ToDecimal(y) - 175)
                Else
                    x = (((Convert.ToDouble(str(10)) + (6000 / 2)) / 6000) * infoForm.picMap.Width) - (10 / 2)
                    y = ((((Convert.ToDouble(str(11)) * -1) + (6000 / 2)) / 6000) * infoForm.picMap.Height) - (10 / 2)

                    infoForm.picMarker.Location = New Point(x, y)
                End If
            End If

            If blnInfoEnabled Then
                tmrUpdateInfo.Enabled = True

                'Will work on a possible "turbo mode" later to communicate with the server as fast as possible
                'SendDataToServer("i:" + Convert.ToString(infoID))
            End If
        ElseIf str(0) = "alist" Then
            If str(1) <> String.Empty Then
                For i As Integer = 1 To str.Length - 1 Step 3
                    AddNewAdmin(Convert.ToInt16(Trim(str(i))), Trim(str(i + 1)), Convert.ToInt16(Trim(str(i + 2))))
                Next
            End If
        ElseIf str(0) = "blist" Then
            lstBans.Items.Clear()
            If str(1) <> String.Empty Then
                Dim count As Integer = 0
                For i As Integer = 1 To str.Length - 1 Step 7
                    AddNewBan(Trim(str(i + 1)), Trim(str(i + 4)))
                    banID.Add(Convert.ToInt32(str(i)))
                    banIP.Add(str(i + 2))
                    banAdmin.Add(str(i + 3))

                    Dim datbanTime As New DateTime(1970, 1, 1, 0, 0, 0, 0)
                    Dim datbanUntilTime As New DateTime(1970, 1, 1, 0, 0, 0, 0)

                    datbanTime = datbanTime.AddSeconds(Convert.ToInt32(Trim(str(i + 6))))
                    datbanUntilTime = datbanUntilTime.AddSeconds(Convert.ToInt32(Trim(str(i + 6))))

                    datbanUntilTime = datbanUntilTime.AddMinutes(Convert.ToInt32(Trim(str(i + 5))))

                    banStamp.Add(datbanTime)

                    banTime.Add(datbanUntilTime)

                    banMinutes.Add(Trim(str(i + 5)))

                    count += 1
                Next

                If count = 10 Then btnNextPage.Enabled = True Else btnNextPage.Enabled = False
                If currentBanIndex > 0 Then btnPreviousPage.Enabled = True Else btnPreviousPage.Enabled = False
            End If
        ElseIf str(0) = "anew" Then
            AddNewAdmin(Convert.ToInt16(Trim(str(1))), Trim(str(3)), Convert.ToInt16(Trim(str(2))))

            txtNewAdminName.Clear()
            txtNewAdminPassword.Clear()
            cmbNewAdminLevel.SelectedIndex = 0

            createAccountAllowed(True)
        ElseIf str(0) = "perm" Then
            intLevel = Convert.ToInt16(str(1))

            If Convert.ToInt16(str(2)) > intLevel Then
                KickToolStripMenuItem.Enabled = False
                KickWithReasonToolStripMenuItem.Enabled = False
            Else
                KickToolStripMenuItem.Enabled = True
                KickWithReasonToolStripMenuItem.Enabled = True
            End If

            If Convert.ToInt16(str(3)) > intLevel Then
                BanToolStripMenuItem1.Enabled = False
            Else
                BanToolStripMenuItem1.Enabled = True
            End If

            If Convert.ToInt16(str(4)) > intLevel Then
                permissionViewInfo = False
                cmsPlayerView.Enabled = False
            Else
                permissionViewInfo = True
                cmsPlayerView.Enabled = True
            End If

            For i As Integer = 0 To 7 Step 1
                If intLevel >= Convert.ToInt16(str(i + 5)) Then infoPermissions(i) = True Else infoPermissions(i) = False
            Next

            If Convert.ToInt16(str(13)) > intLevel Then permissionAdminManage = False Else permissionAdminManage = True
            If Convert.ToInt16(str(14)) > intLevel Then permissionBanManage = False Else permissionBanManage = True

            setInfoFormsEnabled(True)
        ElseIf str(0) = "log" Then
            If str(1) = "fail" Then
                MsgBox("Invalid login details provided", MsgBoxStyle.Critical, "Invalid login")
                LoggedOut()
            Else
                If str(1) <> String.Empty Then
                    For i As Integer = 1 To str.Length - 2 Step 2
                        AddNewPlayer(Convert.ToInt16(str(i)), str(i + 1))
                    Next
                End If

                strLogName = frmLog.txtUsername.Text
                LoggedIn()
            End If
        ElseIf str(0) = "con" Then
            AddNewPlayer(Convert.ToInt16(str(1)), str(2))

            PrintMessage("[" + str(1) + "] " + str(2), " connected to the server.", ReturnColor(Convert.ToInt16(str(1))), Color.Coral)
        ElseIf str(0) = "dcon" Then
            Dim reason As String

            reason = "Timed out"

            Select Case Convert.ToInt16(str(3))
                Case 1
                    reason = "Quit"
                Case 2
                    reason = "Kicked"
            End Select

            PrintMessage("[" + str(1) + "] " + str(2), " disconnected from the server. (" + reason + ")", ReturnColor(Convert.ToInt16(str(1))), Color.Coral)

            For i As Integer = 0 To lstPlayer.Items.Count - 1
                If lstPlayer.Items(i).SubItems(0).Text.Trim = str(1) Then
                    lstPlayer.Items.RemoveAt(i)
                    Exit For
                End If
            Next

            If infoID = Convert.ToInt16(str(1)) Then
                infoForm.Hide()
                infoID = -1
                tmrUpdateInfo.Enabled = False
                cmsPlayerView.Enabled = True
            End If
        ElseIf str(0) = "msg" Then
            PrintPlayerMessage("[" + str(1) + "] " + str(2), ": " + result.Substring(str(1).Length + str(2).Length + 6), ReturnColor(Convert.ToInt16(str(1))), Color.Black)
        ElseIf str(0) = "amsg" Then
            PrintCommandMessage(str(1), Color.Red)
        ElseIf str(0) = "xmsg" Then
            PrintPlayerMessage(str(1), ": " + result.Substring(str(0).Length + str(1).Length + 2), Color.Red, Color.Black)
        ElseIf str(0) = "apop" Then
            If str(1) = "Modified user successfully" Then
                For i As Integer = 0 To lstAdmins.Items.Count - 1
                    If Trim(lstAdmins.Items(i).SubItems(0).Text) = str(2) Then
                        lstAdmins.Items(i).SubItems(1).Text = txtAdminName.Text
                        lstAdmins.Items(i).SubItems(2).Text = " " + Convert.ToString(cmbLevel.SelectedIndex)

                        txtAdminID.Clear()
                        txtAdminName.Clear()
                        Exit For
                    End If
                Next
            ElseIf str(1) = "Sorry, no results found!" And blnInitialBanLoad Then
                blnInitialBanLoad = False
                Return
            ElseIf str(1) = "Set password successfully!" Then
                txtPassword.Clear()

                MessageBox.Show("Password was set successfully", "Password set", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return
            ElseIf str(1) = "Administrator deleted successfully!" Then
                For i As Integer = 0 To lstAdmins.Items.Count - 1
                    If Trim(lstAdmins.Items(i).SubItems(0).Text) = txtAdminID.Text Then
                        lstAdmins.Items.RemoveAt(i)
                        Exit For
                    End If
                Next

                txtAdminID.Clear()
                txtAdminName.Clear()
                cmbLevel.SelectedIndex = 0
                Return
            ElseIf str(1) = "Ban deleted successfully!" Then
                For i As Integer = 0 To banID.Count - 1
                    If Convert.ToInt32(str(2)) = Convert.ToInt32(banID(i)) Then
                        lstBans.Items.RemoveAt(i)
                        banID.RemoveAt(i)
                        banIP.RemoveAt(i)
                        banAdmin.RemoveAt(i)
                        banTime.RemoveAt(i)
                        banStamp.RemoveAt(i)
                        Exit For
                    End If
                Next
                BanManageControlsEnabled(False)
                Return
            ElseIf str(1) = "Ban updated successfully!" Then
                For i As Integer = 0 To banID.Count - 1
                    If Convert.ToInt32(str(2)) = Convert.ToInt32(banID(i)) Then
                        lstBans.Items(i).Text = txtBanName.Text
                        lstBans.Items(i).SubItems(1).Text = txtBanReason.Text


                        banIP(i) = txtBanIP.Text
                        banAdmin(i) = txtBanAdmin.Text
                        banTime(i) = clnBannedUntil.Value
                        banStamp(i) = clnBanned.Value
                        Exit For
                    End If
                Next

                BanManageControlsEnabled(True, False)
                MsgBox("The ban was updated successfully!", MsgBoxStyle.Information, "Update success")
                Return
            End If
            MsgBox(str(1), MsgBoxStyle.Exclamation, "Message from server")
        ElseIf str(0) = "spop" Then
            MsgBox(str(1), MsgBoxStyle.Information, "Response")

            If infoForm.Visible Then
                tmrUpdateInfo.Enabled = True
                blnInfoEnabled = True
                setInfoFormsEnabled(True)
            End If
        ElseIf result = "-- Server is full" Then
            MsgBox("The server has reached maximum number of connections!", MsgBoxStyle.Information, "Connection issue")
            Client.Close()
            Client = Nothing
            frmLog.btnConnect.Enabled = True
        End If
    End Sub

    Public Sub setInfoFormsEnabled(ByVal bool As Boolean)
        If bool = False Then
            infoForm.txtSkin.ReadOnly = True
            infoForm.txtHealth.ReadOnly = True
            infoForm.txtArmour.ReadOnly = True
            infoForm.cmbWeaponID.Enabled = False
            infoForm.txtScore.ReadOnly = True
            infoForm.txtInterior.ReadOnly = True
            infoForm.txtWorld.ReadOnly = True
            infoForm.txtVHealth.ReadOnly = True
        Else
            If infoPermissions(0) Then infoForm.txtSkin.ReadOnly = False
            If infoPermissions(1) Then infoForm.txtHealth.ReadOnly = False
            If infoPermissions(2) Then infoForm.txtArmour.ReadOnly = False
            If infoPermissions(3) Then infoForm.cmbWeaponID.Enabled = True
            If infoPermissions(4) Then infoForm.txtScore.ReadOnly = False
            If infoPermissions(5) Then infoForm.txtInterior.ReadOnly = False
            If infoPermissions(6) Then infoForm.txtWorld.ReadOnly = False
            If infoPermissions(7) Then infoForm.txtVHealth.ReadOnly = False
        End If

    End Sub

    Function ReturnColor(ByVal id As Integer) As Color
        If id >= 200 And id < 400 Then
            id -= 200
        ElseIf id >= 400 Then
            id -= 200
        End If

        Return ColorTranslator.FromHtml("#" + playercolours(id))
    End Function

    Private Sub AddNewPlayer(ByVal id As Integer, ByVal name As String)
        Dim tlvi As New ListViewItem

        tlvi.Text = Str(id)

        tlvi.ForeColor = ReturnColor(id)

        tlvi.SubItems.Add(name)

        lstPlayer.Items.Add(tlvi)
    End Sub

    Private Sub AddNewAdmin(ByVal id As Integer, ByVal name As String, ByVal level As Integer)
        Dim tlvi As New ListViewItem

        tlvi.Text = Str(id)

        tlvi.SubItems.Add(name)

        tlvi.SubItems.Add(Str(level))

        lstAdmins.Items.Add(tlvi)
    End Sub

    Private Sub AddNewBan(ByVal name As String, ByVal reason As String)
        Dim tlvi As New ListViewItem

        tlvi.Text = name

        If reason = String.Empty Then
            reason = "None"
        End If

        tlvi.SubItems.Add(reason)

        lstBans.Items.Add(tlvi)
    End Sub

    Private Sub UpdateTextbox(ByVal textbox As TextBox, ByVal message As String)
        If Not textbox.Focused Then
            textbox.Text = message
        End If
    End Sub

    Private Sub CalculateSpeed(ByVal x As Double, ByVal y As Double, ByVal z As Double)
        If infoForm.cmbSpeed.SelectedIndex = 0 Then
            infoForm.txtSpeed.Text = Convert.ToString(Math.Round(((x ^ 2) + (y ^ 2) + (z ^ 2)) * 100))
        ElseIf infoForm.cmbSpeed.SelectedIndex = 1 Then
            infoForm.txtSpeed.Text = Convert.ToString(Math.Round((((x ^ 2) + (y ^ 2) + (z ^ 2)) * 100) * 1.6))
        End If
    End Sub

    Private Sub PrintMessage(ByVal Message As String, ByVal Message2 As String, ByVal color1 As Color, ByVal color2 As Color)
        AppendText(rtbChat, color1, vbNewLine + Message)
        AppendText(rtbChat, color2, Message2)
    End Sub

    Private Sub PrintPlayerMessage(ByVal Message As String, ByVal Message2 As String, ByVal color1 As Color, ByVal color2 As Color)
        AppendText(rtbChat, color1, vbNewLine + Message)
        AppendText(rtbChat, color2, Message2, False)
    End Sub

    Private Sub LoggedOut()
        txtSendtext.Enabled = False
        lstPlayer.Enabled = False
        rtbChat.Enabled = False

        frmLog.btnConnect.Enabled = True

        blnAuthed = False

        rtbChat.Clear()
        lstPlayer.Items.Clear()

        frmLog.Show()
        frmAbout.Hide()
        frmCustomBan.Close()
        frmPlayerInfo.Hide()
        frmPlayerMap.Hide()

        Me.Hide()
    End Sub

    Private Sub LoggedIn()
        txtSendtext.Enabled = True
        lstPlayer.Enabled = True
        rtbChat.Enabled = True

        blnAuthed = True

        rtbChat.AppendText("Logged in as " + strLogName)

        frmLog.Hide()

        Me.Enabled = True

        Me.Opacity = 100
        Me.Show()

        txtSendtext.Focus()
    End Sub

    Public Sub SendDataToServer(ByVal data As String)
        Dim byteData As Byte() = Encoding.ASCII.GetBytes(data)

        If frmDebug.Visible Then
            frmDebug.TextBox1.Text += vbNewLine + "Data: " + data
        End If

        Try
            If frmDebug.Visible Then
                frmDebug.TextBox1.Text += vbNewLine + "SendData: " + Encoding.ASCII.GetString(byteData) + vbNewLine
            End If

            Client.Client.BeginSend(byteData, 0, byteData.Length, 0, AddressOf SendCallback, Client)
        Catch ex As Exception
            LoggedOut()
        End Try
    End Sub

    Private Sub SendCallback(ByVal ar As IAsyncResult)
        Client.Client.EndSend(ar)
    End Sub

    Private Sub Receive(ByVal rClient As TcpClient)
        Dim state As New StateObject
        Try
            state.workClient = rClient
            rClient.Client.BeginReceive(state.buffer, 0, state.BufferSize, 0, AddressOf ReceiveCallBack, state)
        Catch ex As Exception
            MsgBox("Receive Error " & ex.Message, MsgBoxStyle.Exclamation, "Socket issue")
            LoggedOut()
        End Try
    End Sub

    Private Sub ReceiveCallBack(ByVal ar As IAsyncResult)
        Try
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            state.sb.Length = 0
            Dim rClient As TcpClient = state.workClient
            Dim bytesRead As Integer = rClient.Client.EndReceive(ar)
            If bytesRead > 0 Then
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))
                BeginInvoke(New DataReceived(AddressOf UpdateText), state.sb.ToString)
                rClient.Client.BeginReceive(state.buffer, 0, state.BufferSize, 0, AddressOf ReceiveCallBack, state)
            End If
        Catch ex As SocketException
            If Not frmLog.Visible Then
                MsgBox("Connection to the server was lost", MsgBoxStyle.Exclamation, "Connection issue")
                LoggedOut()
            End If
        Catch ex As Exception
            'MsgBox("Connection was lost to the server.", MsgBoxStyle.Exclamation, "Connection problem")
        End Try
    End Sub

    Private Sub frmConnect_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If Client.Connected Then
                Client.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmConnect_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Client.Connected Then
                Client.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmConnect_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If blnAuthed = False Then
            Me.Hide()

            frmLog.Show()

            infoForm.cmbSpeed.SelectedIndex = My.Settings.Speedpref
        End If
        TabControl1.SelectedTab = tabMain
    End Sub

    Public Sub frmLog_frmLoginClosing() Handles frmLog.frmLoginClosing
        If blnAuthed = False Then
            Me.Close()
        End If
    End Sub

    Public Sub frmLog_btnConnectClick() Handles frmLog.btnConnectClick
        My.Settings.IP = frmLog.txtIP.Text

        If Client Is Nothing Then
            Client = New TcpClient
        End If

        Try
            My.Settings.Port = Convert.ToInt16(frmLog.txtPort.Text)
        Catch ex As Exception
            MsgBox("Port can only be an integer value!", MsgBoxStyle.Exclamation, "Error")
            Return
        End Try

        My.Settings.Username = frmLog.txtUsername.Text
        My.Settings.Password = frmLog.txtPassword.Text

        My.Settings.Save()

        Try
            frmLog.btnConnect.Enabled = False
            If Not Client.Connected Then
                Dim Err As Boolean = False
                state.workClient = Client
                Dim Error_Message As String = "Error: "

                If frmLog.txtIP.Text = "" Then
                    Error_Message = Error_Message & "Host not Specified" & vbNewLine
                    Err = True
                End If

                If frmLog.txtPort.Text = "" Then
                    Error_Message = Error_Message & "Port not Specified" & vbNewLine
                    Err = True
                End If
                If Not Err Then
                    Client.Connect(frmLog.txtIP.Text, CInt(frmLog.txtPort.Text))

                    Call Receive(Client)
                Else
                    MsgBox(Error_Message, MsgBoxStyle.Information, "Connection issue")
                    frmLog.btnConnect.Enabled = True
                    Return
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Connection error")
            frmLog.btnConnect.Enabled = True
        End Try

        If Client.Connected Then
            Dim hash As String

            Using md5Hash As MD5 = MD5.Create()
                hash = GetMD5Hash(md5Hash, frmLog.txtPassword.Text)
            End Using

            Dim byteData As Byte() = Encoding.ASCII.GetBytes("login:" + frmLog.txtUsername.Text + ":" + hash.ToUpper())
            Try
                Client.Client.BeginSend(byteData, 0, byteData.Length, 0, AddressOf SendCallback, Client)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProcessAdminMessage(txtSendtext.Text)
    End Sub

    Private Sub txtSendtext_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSendtext.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If prevView < prevCount - 1 Then
                    prevView += 1
                    txtSendtext.Text = prevMessages(prevView)
                    txtSendtext.Select(txtSendtext.TextLength, txtSendtext.TextLength)
                End If
                e.Handled = True
            Case Keys.Down
                If prevView > 0 Then
                    prevView -= 1
                    txtSendtext.Text = prevMessages(prevView)
                    txtSendtext.Select(txtSendtext.TextLength, txtSendtext.TextLength)
                ElseIf prevView = 0 Then
                    prevView = -1
                    txtSendtext.Text = ""
                End If
                e.Handled = True
        End Select
        tabNameIndex = 0
        tabNameSearch = ""
    End Sub

    Private Sub txtSendtext_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSendtext.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            ProcessAdminMessage(txtSendtext.Text)
        End If
    End Sub

    Private Sub ProcessAdminMessage(ByVal message As String)
        If message = String.Empty Then
            MsgBox("You need to enter a message!", MsgBoxStyle.Information, "Hey!")
        Else
            If message(0) = "/" Then
                If message.Contains(":"c) Then
                    MsgBox("Your command cannot contain the """":"""" character.", MsgBoxStyle.Information, "Invalid character")
                    Return
                End If

                Dim params() As String = message.Split(" "c)
                Dim reason As String

                If params(0) = "/kick" Then
                    If params.Length = 1 Then
                        PrintCommandMessage("Usage: /kick <id/name> <reason(optional)>" + vbNewLine + "Effect: Kicks a player with an optionally given reason.", Color.DarkOrange)
                    Else
                        If params.Length < 3 Then reason = "" Else reason = message.Substring(params(0).Length + params(1).Length + 2)
                        SendDataToServer("kick:" + params(1) + ":" + reason)
                    End If
                ElseIf params(0) = "/ban" Then
                    If params.Length = 1 Then
                        PrintCommandMessage("Usage: /ban <id/name> <reason(optional)>" + vbNewLine + "Effect: Bans a player with an optionally given reason.", Color.DarkOrange)
                    Else
                        If params.Length < 3 Then reason = "" Else reason = message.Substring(params(0).Length + params(1).Length + 2)
                        SendDataToServer("ban:" + params(1) + ":0:" + reason)
                    End If
                ElseIf params(0) = "/setpvar" Then
                    If params.Length < 3 Then
                        PrintCommandMessage("Usage: /setpvar <id/name> <pvar name> <value>" + vbNewLine + "Effect: Sets a PVar for a player, will automatically determine string from integer.", Color.DarkOrange)
                    Else
                        SendDataToServer("spvar:" + params(1) + ":" + params(2) + ":" + params(3))
                    End If
                ElseIf params(0) = "/cmds" Or params(0) = "/help" Or params(0) = "/commands" Then
                    PrintCommandMessage("Commands: /kick, /ban, /setpvar", Color.DarkOrange)
                    PrintCommandMessage("Info: To get more info about a command, simply type it!", Color.DarkOrange)
                ElseIf params(0) = "/sdbug" Then
                    frmDebug.Show()
                Else
                    PrintCommandMessage("Unknown Command: " + params(0), Color.Red)
                    PrintCommandMessage("Type /help for a list of commands", Color.Red)
                End If
            Else
                If message.Length > 128 Then
                    MsgBox("The message cannot be longer than 128 characters!", MsgBoxStyle.Information, "Message cannot be that long!")
                Else
                    SendDataToServer("msg:" + strLogName + ":" + message)
                    PrintPlayerMessage(strLogName, ": " + message, Color.Red, Color.Black)
                End If
            End If
            prevMessages.Insert(0, txtSendtext.Text)
            If prevCount < 10 Then prevCount += 1
            prevView = -1
            txtSendtext.Text = ""
            tabNameIndex = 0
            tabNameSearch = ""
        End If
    End Sub

    Private Sub PrintCommandMessage(ByVal message As String, ByVal color As Color)
        AppendText(rtbChat, color, vbNewLine + message)
    End Sub

    Private Sub AppendText(ByVal box As RichTextBox, ByVal color As Color, ByVal text As String, Optional ByVal bold As Boolean = True)
        Dim start As Integer = box.TextLength

        Dim curSelectStart As Integer = box.SelectionStart
        Dim curSelectEnd As Integer = box.SelectedText.Length

        box.SelectionLength = 0

        box.AppendText(text)

        Dim finish As Integer = box.TextLength

        box.Select(start, finish - start)
        box.SelectionColor = color

        Dim currentFont As System.Drawing.Font = rtbChat.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle

        If bold = False Then
            newFontStyle = FontStyle.Regular

            box.SelectionFont = New Font( _
                     currentFont.FontFamily, _
                     currentFont.Size, _
                     newFontStyle _
                     )
        Else
            newFontStyle = FontStyle.Bold

            box.SelectionFont = New Font( _
                     currentFont.FontFamily, _
                     currentFont.Size, _
                     newFontStyle _
                     )
        End If

        box.SelectionLength = 0

        If curSelectEnd <> 0 Then
            box.Select(curSelectStart, curSelectEnd)
        End If
    End Sub

    Private Sub KickToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KickToolStripMenuItem.Click
        KickPlayer(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text))
    End Sub

    Private Sub SpammingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpammingToolStripMenuItem.Click
        KickPlayer(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "Spamming")
    End Sub

    Private Sub FlamingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlamingToolStripMenuItem.Click
        KickPlayer(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "Flaming")
    End Sub

    Private Sub DeathmatchingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeathmatchingToolStripMenuItem.Click
        KickPlayer(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "Deathmatching")
    End Sub

    Private Sub ModificationsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModificationsToolStripMenuItem.Click
        KickPlayer(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "Modifications")
    End Sub

    Private Sub HackingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HackingToolStripMenuItem.Click
        KickPlayer(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "Cheating")
    End Sub

    Private Sub KickPlayer(ByVal id As Integer, Optional ByVal reason As String = "")
        SendDataToServer("kick:" + id.ToString + ":" + reason)
    End Sub

    Private Sub cmsPlayerView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPlayerView.Click
        infoID = Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text)
        infoname = lstPlayer.SelectedItems.Item(0).SubItems(1).Text

        infoForm.Text = "Live stats for " + infoname

        tmrUpdateInfo.Enabled = True
        cmsPlayerView.Enabled = False
        blnInfoEnabled = True

        infoForm.Show()
    End Sub

    Private Sub tmrUpdateInfo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdateInfo.Tick
        If blnInfoEnabled = True Then
            SendDataToServer("i:" + Convert.ToString(infoID) + ":")
        End If
        tmrUpdateInfo.Enabled = False
    End Sub

    Private Sub lstPlayer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstPlayer.DoubleClick
        If lstPlayer.SelectedItems.Count <> 0 And Not infoForm.Visible And permissionViewInfo Then
            infoID = Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text)
            infoname = lstPlayer.SelectedItems.Item(0).SubItems(1).Text

            infoForm.Text = "Live stats for " + infoname

            tmrUpdateInfo.Enabled = True
            cmsPlayerView.Enabled = False
            blnInfoEnabled = True

            infoForm.Show()
        End If
    End Sub

    Private Sub lstPlayer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstPlayer.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right And lstPlayer.SelectedItems.Count <> 0 Then
            cmsPlayerMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub SAMPForumsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAMPForumsToolStripMenuItem.Click
        Process.Start("http://forum.sa-mp.com")
    End Sub

    Private Sub SAMPWikiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAMPWikiToolStripMenuItem.Click
        Process.Start("http://wiki.sa-mp.com")
    End Sub

    Private Sub JaTochNietDanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JaTochNietDanToolStripMenuItem.Click
        Process.Start("http://www.jatochnietdan.com")
    End Sub

    Private Sub ContactAuthorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactAuthorToolStripMenuItem.Click
        Process.Start("http://www.jatochnietdan.com/contact")
    End Sub

    Private Sub DisconnectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisconnectToolStripMenuItem.Click
        Client.Close()
        Client = Nothing
        LoggedOut()
    End Sub

    Private Sub CustomReasonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomReasonToolStripMenuItem.Click
        Dim reason As String = InputBox("Please enter a reason for kicking " + "[" + Trim(lstPlayer.SelectedItems.Item(0).SubItems(0).Text) + "] " + Trim(lstPlayer.SelectedItems.Item(0).SubItems(1).Text))

        If reason.Length > 0 Then
            KickPlayer(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), reason)
        End If
    End Sub

    Private Sub tabAdminManage_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabAdminManage.Enter
        If permissionAdminManage = False Then
            MsgBox("You do not have permission to access this area.", MsgBoxStyle.Exclamation, "Permission needed")
            TabControl1.SelectedTab = tabMain
        Else
            lstAdmins.Items.Clear()

            SendDataToServer("alist:")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtAdminName.Text <> String.Empty Then
            SaveAdminsAllowed(False)

            SendDataToServer("aset:" + txtAdminID.Text + ":" + txtAdminName.Text + ":" + Trim(Str(cmbLevel.SelectedIndex)))
        End If
    End Sub

    Private Sub SaveAdminsAllowed(ByVal bool As Boolean)
        txtAdminName.Enabled = bool
        cmbLevel.Enabled = bool
        btnSave.Enabled = bool
        btnSavePassword.Enabled = bool
        btnDeleteAccount.Enabled = bool
    End Sub

    Private Sub lstAdmins_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAdmins.SelectedIndexChanged
        If lstAdmins.SelectedItems.Count > 0 Then
            txtAdminID.Text = Trim(lstAdmins.SelectedItems.Item(0).SubItems(0).Text)
            txtAdminName.Text = Trim(lstAdmins.SelectedItems.Item(0).SubItems(1).Text)

            cmbLevel.SelectedIndex = Convert.ToInt16(Trim(lstAdmins.SelectedItems.Item(0).SubItems(2).Text))

            SaveAdminsAllowed(True)
        Else
            SaveAdminsAllowed(False)

            txtAdminID.Clear()
            txtAdminName.Clear()
            cmbLevel.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSavePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePassword.Click
        If txtPassword.Text <> String.Empty Then
            SaveAdminsAllowed(False)

            Dim hash As String

            Using md5Hash As MD5 = MD5.Create()
                hash = GetMD5Hash(md5Hash, txtPassword.Text)
            End Using

            SendDataToServer("apass:" + txtAdminID.Text + ":" + hash.ToUpper())
        End If
    End Sub

    Private Function GetMD5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function

    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click
        If txtNewAdminName.Text <> String.Empty And txtNewAdminPassword.Text <> String.Empty And cmbNewAdminLevel.SelectedIndex <> -1 Then
            If txtNewAdminName.Text.Length > 24 Then
                MsgBox("Names can only be 24 characters long!", MsgBoxStyle.Information, "Error")
                Return
            ElseIf txtNewAdminName.Text.Contains(":") Or txtNewAdminName.Text.Contains("'") Then
                MsgBox("The characters ':' or ' is not allowed in names!", MsgBoxStyle.Information, "Error")
                Return
            End If

            createAccountAllowed(False)

            Dim hash As String

            Using md5Hash As MD5 = MD5.Create()
                hash = GetMD5Hash(md5Hash, txtNewAdminPassword.Text)
            End Using

            SendDataToServer("anew:" + hash.ToUpper() + ":" + cmbNewAdminLevel.Text + ":" + txtNewAdminName.Text)
        Else
            MsgBox("You need to fill in all fields!", MsgBoxStyle.Information, "Error")
        End If
    End Sub

    Private Sub createAccountAllowed(ByVal bool As Boolean)
        btnCreateAccount.Enabled = bool
        txtNewAdminName.Enabled = bool
        txtNewAdminPassword.Enabled = bool
        cmbNewAdminLevel.Enabled = bool
    End Sub

    Private Sub txtNewAdminName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewAdminName.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            btnCreateAccount_Click(sender, e)
        End If
    End Sub

    Private Sub txtNewAdminPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewAdminPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            btnCreateAccount_Click(sender, e)
        End If
    End Sub

    Private Sub btnDeleteAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAccount.Click
        If MessageBox.Show("Are you sure you wish to delete " + txtAdminName.Text + "'s account? (There is no going back)", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
            btnDeleteAccount.Enabled = False
            SendDataToServer("adel:" + txtAdminID.Text)
        End If
    End Sub

    Private Sub tabBanManage_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabBanManage.Enter
        If Not permissionBanManage Then
            MsgBox("You do not have permission to view this area!", MsgBoxStyle.Exclamation, "Permission error")
            TabControl1.SelectedTab = tabMain
        Else
            BanManageControlsEnabled(False)

            txtFilter.Clear()
            blnInitialBanLoad = True

            ClearBanData()

            SendDataToServer("blist:" + Str(currentBanIndex))
        End If
    End Sub

    Private Sub ClearBanData()
        banID.Clear()
        banIP.Clear()
        banAdmin.Clear()
        banTime.Clear()
        banStamp.Clear()
        banMinutes.Clear()

        lstBans.Items.Clear()
    End Sub

    Private Sub lstBans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBans.SelectedIndexChanged
        If lstBans.SelectedItems.Count <> 0 Then

            BanManageControlsEnabled(True)

            txtBanID.Text = Str(banID(lstBans.SelectedItems.Item(0).Index))
            txtBanName.Text = lstBans.SelectedItems.Item(0).SubItems(0).Text
            txtBanReason.Text = lstBans.SelectedItems.Item(0).SubItems(1).Text
            txtBanAdmin.Text = banAdmin(lstBans.SelectedItems.Item(0).Index)
            txtBanIP.Text = banIP(lstBans.SelectedItems.Item(0).Index)

            clnBanned.Value = Convert.ToDateTime(banStamp(lstBans.SelectedItems.Item(0).Index))

            cmbBanHours.SelectedIndex = Convert.ToInt32(banStamp(lstBans.SelectedItems.Item(0).Index).Hour)
            cmbBanMinutes.Text = banStamp(lstBans.SelectedItems.Item(0).Index).Minute.ToString

            cmbBanUntilHours.SelectedIndex = Convert.ToInt32(banTime(lstBans.SelectedItems.Item(0).Index).Hour)
            cmbBanUntilMinutes.Text = banTime(lstBans.SelectedItems.Item(0).Index).Minute.ToString

            clnBannedUntil.Value = Convert.ToDateTime(banTime(lstBans.SelectedItems.Item(0).Index))

            If Convert.ToInt32(banMinutes(lstBans.SelectedItems.Item(0).Index)) > 0 Then
                clnBannedUntil.Checked = True

                cmbBanUntilHours.Enabled = True
                cmbBanUntilMinutes.Enabled = True
            Else
                clnBannedUntil.Checked = False

                cmbBanUntilHours.Enabled = False
                cmbBanUntilMinutes.Enabled = False
            End If
        Else
            BanManageControlsEnabled(False)
        End If
    End Sub

    Private Sub BanManageControlsEnabled(ByVal bool As Boolean, Optional ByVal clear As Boolean = True)
        txtBanAdmin.Enabled = bool
        txtBanIP.Enabled = bool
        txtBanName.Enabled = bool
        txtBanReason.Enabled = bool
        cmbBanHours.Enabled = bool
        cmbBanMinutes.Enabled = bool
        cmbBanUntilHours.Enabled = bool
        cmbBanUntilMinutes.Enabled = bool
        clnBanned.Enabled = bool
        clnBannedUntil.Enabled = bool

        btnDeleteBan.Enabled = bool
        btnSaveBan.Enabled = bool
        If clear Then
            txtBanID.Clear()
            txtBanAdmin.Clear()
            txtBanIP.Clear()
            txtBanName.Clear()
            txtBanReason.Clear()
            cmbBanHours.SelectedIndex = 0
            cmbBanMinutes.SelectedIndex = 0
            cmbBanUntilHours.SelectedIndex = 0
            cmbBanUntilMinutes.SelectedIndex = 0

            Dim datbanTime As New DateTime(1970, 1, 1, 0, 0, 0, 0)

            clnBanned.Value = datbanTime
            clnBannedUntil.Value = datbanTime
        End If
    End Sub

    Private Sub clnBannedUntil_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clnBannedUntil.ValueChanged
        If clnBannedUntil.Checked And Not cmbBanUntilHours.Enabled Then
            clnBannedUntil.Value = clnBanned.Value
            cmbBanUntilHours.SelectedIndex = cmbBanHours.SelectedIndex
            cmbBanUntilMinutes.Text = cmbBanMinutes.Text

            cmbBanUntilHours.Enabled = True
            cmbBanUntilMinutes.Enabled = True
        ElseIf Not clnBannedUntil.Checked Then
            cmbBanUntilHours.Enabled = False
            cmbBanUntilMinutes.Enabled = False
        End If
    End Sub

    Private Sub btnNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextPage.Click
        currentBanIndex += 1

        btnFilterBans_Click(sender, e)
    End Sub

    Private Sub btnPreviousPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousPage.Click
        currentBanIndex -= 1

        btnFilterBans_Click(sender, e)
    End Sub

    Private Sub btnDeleteBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBan.Click
        If txtBanID.Text <> String.Empty Then
            SendDataToServer("delb:" + txtBanID.Text)
            BanManageControlsEnabled(False)
        End If
    End Sub

    Private Sub btnSaveBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveBan.Click
        If txtBanName.Text = String.Empty Or txtBanAdmin.Text = String.Empty Or txtBanIP.Text = String.Empty Or txtBanReason.Text = String.Empty Then
            MsgBox("You have to fill in all of the fields!", MsgBoxStyle.Exclamation, "Data error")
        ElseIf txtBanAdmin.Text.Contains(":"c) Or txtBanIP.Text.Contains(":"c) Or txtBanName.Text.Contains(":"c) Then
            MsgBox("Your names or IP addresses cannot contain the ':' character", MsgBoxStyle.Information, "Format error")
        Else
            Dim tminutes As Integer = 0
            Dim tbanStamp As DateTime = New DateTime(clnBanned.Value.Year, clnBanned.Value.Month, clnBanned.Value.Day, cmbBanHours.SelectedIndex, Convert.ToInt16(cmbBanMinutes.Text), 0, 0)
            Dim tbanTime As DateTime = New DateTime(clnBannedUntil.Value.Year, clnBannedUntil.Value.Month, clnBannedUntil.Value.Day, cmbBanUntilHours.SelectedIndex, Convert.ToInt16(cmbBanUntilMinutes.Text), 0, 0)

            Dim unix_stamp As TimeSpan = tbanStamp.Subtract(New DateTime(1970, 1, 1, 0, 0, 0, 0))

            If clnBannedUntil.Checked Then
                If tbanTime > tbanStamp Then
                    Dim bannedUntilMin As TimeSpan = tbanTime.Subtract(tbanStamp)

                    tminutes = Convert.ToInt32(bannedUntilMin.TotalMinutes)
                End If
            End If

            BanManageControlsEnabled(False, False)

            SendDataToServer("setb:" + txtBanID.Text + ":" + txtBanName.Text + ":" + txtBanIP.Text + ":" + txtBanAdmin.Text + ":" + Trim(Str(tminutes)) + ":" + Trim(Str(unix_stamp.TotalSeconds)) + ":" + txtBanReason.Text)
        End If
    End Sub

    Public Function DateTimeToUnixTimestamp(ByVal _DateTime As DateTime) As Long
        Dim _UnixTimeSpan As TimeSpan = (_DateTime.Subtract(New DateTime(1970, 1, 1, 0, 0, 0)))
        Return CLng(Fix(_UnixTimeSpan.TotalSeconds))
    End Function

    Public Sub BanUser(ByVal playerID As Integer, ByVal reason As String, Optional ByVal minutes As Integer = 0)
        If reason = String.Empty Then
            reason = InputBox("Please enter a reason for banning " + "[" + Trim(lstPlayer.SelectedItems.Item(0).SubItems(0).Text) + "] " + Trim(lstPlayer.SelectedItems.Item(0).SubItems(1).Text))
        End If

        SendDataToServer("ban:" + Trim(playerID.ToString) + ":" + Trim(Str(minutes)) + ":" + reason)
    End Sub

    Private Sub MinutesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinutesToolStripMenuItem.Click
        BanUser(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "", 15)
    End Sub

    Private Sub MinutesToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinutesToolStripMenuItem1.Click
        BanUser(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "", 30)
    End Sub

    Private Sub HourToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HourToolStripMenuItem.Click
        BanUser(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "", 60)
    End Sub

    Private Sub DayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayToolStripMenuItem.Click
        BanUser(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "", 1440)
    End Sub

    Private Sub WeekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeekToolStripMenuItem.Click
        BanUser(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "", 10080)
    End Sub

    Private Sub PermanentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PermanentToolStripMenuItem.Click
        BanUser(Convert.ToInt16(lstPlayer.SelectedItems.Item(0).SubItems(0).Text), "", 0)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.Show()
    End Sub

    Private Sub CustomReasonToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomReasonToolStripMenuItem1.Click
        Dim frmBan As New frmCustomBan

        frmBan.Text = "Ban [" + Trim(lstPlayer.SelectedItems.Item(0).SubItems(0).Text) + "] " + lstPlayer.SelectedItems.Item(0).SubItems(1).Text

        frmBan.txtBanID.Text = Trim(lstPlayer.SelectedItems.Item(0).SubItems(0).Text)
        frmBan.txtBanName.Text = lstPlayer.SelectedItems.Item(0).SubItems(1).Text

        frmBan.Show()
    End Sub

    Private Sub btnFilterBans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterBans.Click
        ClearBanData()

        SendDataToServer("blist:" + Str(currentBanIndex) + ":" + txtFilter.Text)
    End Sub

    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
        ClearBanData()
        txtFilter.Clear()

        currentBanIndex = 0

        SendDataToServer("blist:" + Str(currentBanIndex))
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True

            btnFilterBans_Click(sender, e)
        End If
    End Sub

    Private Sub cmbBanMinutes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBanMinutes.TextChanged
        Try
            If Not IsNumeric(cmbBanMinutes.Text) Or Convert.ToInt16(cmbBanMinutes.Text) < 0 Or Convert.ToInt16(cmbBanMinutes.Text) > 60 Then
                cmbBanMinutes.Text = "0"
            End If
        Catch ex As Exception
            cmbBanMinutes.Text = "0"
        End Try
    End Sub

    Private Sub cmbBanUntilMinutes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBanUntilMinutes.TextChanged
        Try
            If Not IsNumeric(cmbBanUntilMinutes.Text) Or Convert.ToInt16(cmbBanUntilMinutes.Text) < 0 Or Convert.ToInt16(cmbBanUntilMinutes.Text) > 60 Then
                cmbBanUntilMinutes.Text = "0"
            End If
        Catch ex As Exception
            cmbBanUntilMinutes.Text = "0"
        End Try
    End Sub

    Private Sub KillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillToolStripMenuItem.Click
        SendDataToServer("health:" + lstPlayer.SelectedItems.Item(0).SubItems(0).Text + ":0")
    End Sub

    'This is probably overly complicated...but it works perfectly, tab name finishing!
    Protected Overrides Function ProcessTabKey(ByVal forward As Boolean) As Boolean
        If txtSendtext.Focused Then
            If txtSendtext.SelectionStart > 0 Then
                If txtSendtext.Text(txtSendtext.SelectionStart - 1) <> String.Empty And txtSendtext.Text(txtSendtext.SelectionStart - 1) <> " "c Then
                    Dim blnFirst As Boolean = True

                    If tabNameSearch = String.Empty Then
                        tabEndIndex = txtSendtext.SelectionStart

                        For i As Integer = tabEndIndex - 1 To 0 Step -1
                            If txtSendtext.Text(i) = " " Then
                                tabStartIndex = i + 1
                                Exit For
                            End If
                        Next

                        tabNameSearch = txtSendtext.Text.Substring(tabStartIndex, tabEndIndex - tabStartIndex).ToLower()
                        blnFirst = False
                    End If

                    For i As Integer = tabNameIndex To lstPlayer.Items.Count - 1
                        If lstPlayer.Items(i).SubItems(1).Text.ToLower.StartsWith(tabNameSearch) Then
                            tabNameIndex = i + 1
                            txtSendtext.Text = txtSendtext.Text.Remove(tabStartIndex, tabEndIndex - tabStartIndex).Insert(tabStartIndex, lstPlayer.Items(i).SubItems(1).Text)
                            tabEndIndex = tabStartIndex + lstPlayer.Items(i).SubItems(1).Text.Length
                            txtSendtext.Select(tabEndIndex, tabEndIndex)
                            Exit For
                        End If

                        If i = lstPlayer.Items.Count - 1 Then
                            If blnFirst Then
                                tabNameIndex = 0
                                i = 0
                            Else
                                tabNameSearch = ""
                            End If      
                        Else
                        End If
                    Next
                End If
            End If
        Else
            MyBase.ProcessTabKey(forward)
        End If
        Return True
    End Function

    Private Sub rtbChat_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbChat.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub
End Class

Public Class StateObject
    Public workClient As TcpClient = Nothing
    Public BufferSize As Integer = 2125
    Public buffer(2125) As Byte
    Public sb As New StringBuilder()
End Class