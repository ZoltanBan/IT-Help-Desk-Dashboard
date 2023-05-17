using System;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class resetPassword : Form
    {
        public resetPassword()
        {
            InitializeComponent();
        }
        private void btnResetPasswordOK_Click(object sender, EventArgs e)
        {
            string username = txtResetPassword.Text;
            try
            {
                string[] usernameAD = Functions.GetAD(username);
                if (usernameAD == null)
                {
                    rtxtResetPassword.Text = "Invalid Username Entry\n" + "\nUsername: '" + username.ToUpper() + "' is Incorrect";
                    return;
                }
                string answer = MessageBox.Show("Please Confirm Again "
                                                + "\nUser ID: " + usernameAD[0]
                                                + "\nUser name: " + usernameAD[2]
                                                + "\nE-mail: " + usernameAD[3],
                                                "Desktop Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                if(answer == "No")
                {
                    rtxtResetPassword.Text = "Password Reset Cancelled";
                    return;
                }
                Functions.resetPassword(usernameAD[0]);
                rtxtResetPassword.Text = "Passowrd Reset Completed\n"
                                    + "\nUser ID      : " + usernameAD[0]   //usernameAD[0] is sAMAccountName attribute in Active Directory
                                    + "\nUser name    : " + usernameAD[2]   //usernameAD[2] is displayName attribute in Active Directory
                                    + "\nE-mail       : " + usernameAD[3]   //usernameAD[3] is email attribute in Active Directory
                                    + "\nNew Password : 'Ineos2023'"
                                    + "\n\nUser must change password at next logon.";
            }
            catch
            {
                rtxtResetPassword.Text = "Invalid Entry";
            }
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            rtxtResetPassword.Text = "";
        }
    }
}