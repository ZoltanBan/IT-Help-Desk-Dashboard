using System;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class pingPc : Form
    {
        public pingPc()
        {
            InitializeComponent();
        }
        private void btnPingPcOK_Click(object sender, EventArgs e)
        {
            string hostname = txtPingPc.Text;
            if (hostname == "")
            {
                rtxtPingPc.Text = "Please Enter Device ID";
                return;
            }
            try
            {
                string[] result = Functions.pingHostname(hostname);
                if (result != null && result[0] != "TimeOut")
                {
                    rtxtPingPc.Text = "Status   : Online"
                                    + "\nHostname : " + hostname.ToUpper()
                                    + "\nIP       : " + result[0];
                }
                else if (result == null)
                    rtxtPingPc.Text = "'" + hostname.ToUpper() + "' is Offline";
                else if (result[0] == "TimeOut")
                    rtxtPingPc.Text = "'" + hostname +  "'" + " is Invalid Entry";
                else
                    rtxtPingPc.Text = "Invalid Entry";
            }
            catch
            {
                rtxtPingPc.Text = "Invalid Entry";
            }
        }

        private void btnPingPcClearResult_Click(object sender, EventArgs e)
        {
            rtxtPingPc.Text = "";
        }
    }
}
