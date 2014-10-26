Public Class frmLogin
    Public Event btnConnectClick()
    Public Event frmLoginClosing()

    Public Sub btnConnect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        RaiseEvent btnConnectClick()
    End Sub

    Private Sub frmLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RaiseEvent frmLoginClosing()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtIP.Text = My.Settings.IP
        txtPort.Text = Trim(Str(My.Settings.Port))
        txtUsername.Text = My.Settings.Username
        txtPassword.Text = My.Settings.Password

        btnConnect.Focus()
    End Sub

    Private Sub txtIP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIP.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            RaiseEvent btnConnectClick()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            RaiseEvent btnConnectClick()
        End If
    End Sub

    Private Sub txtPort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPort.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            RaiseEvent btnConnectClick()
        End If
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            RaiseEvent btnConnectClick()
        End If
    End Sub
End Class