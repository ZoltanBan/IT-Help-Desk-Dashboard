using System;
using System.Windows.Forms;


namespace desktopDashboard___Y_Lee.Forms
{
    public partial class lookupUser : Form
    {
        public lookupUser()
        {
            InitializeComponent();
        }

        private void btnLookupUserOK_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtLookupUser.Text;
                if (username == "")
                {
                    rtxtLookupUser.Text = "Please Enter Username";
                    return;
                }
                string[] results = Functions.GetAD(username);
                if (results == null)
                {
                    rtxtLookupUser.Text = "Invalid Entry" + "\n'" + username.ToUpper() + "' is Not Correct";
                    return;
                }
                rtxtLookupUser.Text =
                            "Name             : " + results[2]
                        + "\nEmail            : " + results[3]
                        + "\nNTID             : " + results[0]
                        + "\nSite             : " + results[1]
                        + "\nOffice Location  : " + results[4]
                        + "\nTelephone Number : " + results[5]
                        + "\nJob Title        : " + results[6];
            }
            catch
            {
                rtxtLookupUser.Text = "Invalid Entry";
            }
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            rtxtLookupUser.Text = "";
        }
    }
}
