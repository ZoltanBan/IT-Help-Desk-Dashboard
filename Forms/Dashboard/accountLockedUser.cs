using System;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class accountLockedUser : Form
    {
        public accountLockedUser()
        {
            InitializeComponent();
        }
        private void btnAccountLockedUser_Click(object sender, EventArgs e)
        {
            rtxtAccountLockedUser.Clear();
            string site = comboxAccountLockedUser.Text;
            string filter = lbAccountLockedUserTop.Text;

            var (name, ntid, email) = Functions.queryAD(site, filter);
            int totalCount = name.Length;
            rtxtAccountLockedUser.AppendText(string.Format("{0,-4}{1,-26}{2,-41}{3,-20}", "No.", "Name", "Email", "NTID"));

            for (int i = 0; i < totalCount; i++)
            {
                string rtxtCount = (i + 1).ToString();
                rtxtAccountLockedUser.AppendText(Environment.NewLine);
                rtxtAccountLockedUser.AppendText(string.Format("{0,-4}{1, -26}{2,-41}{3, -20}", rtxtCount, name[i], email[i], ntid[i]));
            }
            rtxtAccountLockedUser.AppendText(Environment.NewLine);
            rtxtAccountLockedUser.AppendText(Environment.NewLine + "Total Count: " + totalCount);
        }

        private void btnAccountLockedUserClearResult_Click(object sender, EventArgs e)
        {
            rtxtAccountLockedUser.Text = "";
        }
    }
}