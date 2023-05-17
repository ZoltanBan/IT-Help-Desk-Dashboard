using System;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class accountExpiredUser : Form
    {
        public accountExpiredUser()
        {
            InitializeComponent();
        }
        private void btnAccountExpiredUser_Click(object sender, EventArgs e)
        {
            rtxtAccountExpiredUser.Clear();
            string site = comboxAccountExpiredUser.Text;
            string filter = lbAccountExpiredUserTop.Text;

            var (name, ntid, email) = Functions.queryAD(site, filter);
            int totalCount = name.Length;
            rtxtAccountExpiredUser.AppendText(string.Format("{0,-4}{1,-26}{2,-41}{3,-20}", "No.", "Name", "Email", "NTID"));

            for (int i = 0; i < totalCount; i++)
            {
                string rtxtCount = (i + 1).ToString();
                rtxtAccountExpiredUser.AppendText(Environment.NewLine);
                rtxtAccountExpiredUser.AppendText(string.Format("{0,-4}{1, -26}{2,-41}{3, -20}", rtxtCount, name[i],email[i], ntid[i]));
            }
            rtxtAccountExpiredUser.AppendText(Environment.NewLine);
            rtxtAccountExpiredUser.AppendText(Environment.NewLine + "Total Count: " + totalCount);
        }

        private void btnAccountExpiredUserClearResult_Click(object sender, EventArgs e)
        {
            rtxtAccountExpiredUser.Text = "";
        }
    }
}