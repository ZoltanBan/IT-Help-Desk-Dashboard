using System;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class deactivatedUser : Form
    {
        public deactivatedUser()
        {
            InitializeComponent();
        }
        private void btnDeactivatedUser_Click(object sender, EventArgs e)
        {
            rtxtDeactivatedUser.Clear();
            string site = comboxDeactivatedUser.Text;
            string filter = lbDeactivatedUserTop.Text;

            var (name, ntid, email) = Functions.queryAD(site, filter);
            int totalCount = name.Length;
            rtxtDeactivatedUser.AppendText(string.Format("{0,-4}{1,-26}{2,-41}{3,-20}", "No.", "Name", "Email", "NTID"));

            for (int i = 0; i < totalCount; i++)
            {
                string rtxtCount = (i + 1).ToString();
                rtxtDeactivatedUser.AppendText(Environment.NewLine);
                rtxtDeactivatedUser.AppendText(string.Format("{0,-4}{1, -26}{2,-41}{3, -20}", rtxtCount, name[i], email[i], ntid[i]));
            }
            rtxtDeactivatedUser.AppendText(Environment.NewLine);
            rtxtDeactivatedUser.AppendText(Environment.NewLine + "Total Count: " + totalCount);
        }

        private void btnAccountDeactivatedUserClearResult_Click(object sender, EventArgs e)
        {
            rtxtDeactivatedUser.Text = "";
        }
    }
}