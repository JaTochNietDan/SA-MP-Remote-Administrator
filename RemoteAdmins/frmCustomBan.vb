Public Class frmCustomBan
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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

    Private Sub frmCustomBan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clnDateUntil.Value = Now()
        cmbBanHours.SelectedIndex = Now().Hour
        cmbBanMinutes.Text = Str(Now().Minute)
    End Sub

    Private Sub btnBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBan.Click
        Dim today As DateTime = Now()
        Dim banneduntil As DateTime = New DateTime(clnDateUntil.Value.Year, clnDateUntil.Value.Month, clnDateUntil.Value.Day, cmbBanHours.SelectedIndex, Convert.ToInt16(cmbBanMinutes.Text), 0, 0)
        Dim minutes As TimeSpan = banneduntil.Subtract(today)

        If minutes.TotalMinutes < 0 Then
            MsgBox("You need to enter a time after right now!", MsgBoxStyle.Information, "Invalid time")
        Else
            frmConnect.BanUser(Convert.ToInt16(Trim(txtBanID.Text)), txtBanReason.Text, Convert.ToInt32(minutes.TotalMinutes))
            Me.Close()
        End If
    End Sub
End Class