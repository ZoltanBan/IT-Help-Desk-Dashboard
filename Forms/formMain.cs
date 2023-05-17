using desktopDashboard___Y_Lee.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            hideSubMenu();

            string passwordExpiredFilter = lbDashboardPasswordExpired.Text;
            string mvwPasswordExpired = lbDashboardPasswordExpiredMVW.Text;
            lbDashboardPasswordExpiredMVWNumber.Text = Functions.userCount(mvwPasswordExpired, passwordExpiredFilter).ToString();
            string bmcPasswordExpired = lbDashboardPasswordExpiredBMC.Text;
            lbDashboardPasswordExpiredBMCNumber.Text = Functions.userCount(bmcPasswordExpired, passwordExpiredFilter).ToString();
            string choPasswordExpired = lbDashboardPasswordExpiredCHO.Text;
            lbDashboardPasswordExpiredCHONumber.Text = Functions.userCount(choPasswordExpired, passwordExpiredFilter).ToString();
            string larPasswordExpired = lbDashboardPasswordExpiredLAR.Text;
            lbDashboardPasswordExpiredLARNumber.Text = Functions.userCount(larPasswordExpired, passwordExpiredFilter).ToString();
            string hdcPasswordExpired = lbDashboardPasswordExpiredHDC.Text;
            lbDashboardPasswordExpiredHDCNumber.Text = Functions.userCount(hdcPasswordExpired, passwordExpiredFilter).ToString();

            string accountLockedFilter = lbDashboardAccountLocked.Text;
            string mvwAccountLocked = lbDashboardAccountLockedMVW.Text;
            lbDashboardAccountLockedMVWNumber.Text = Functions.userCount(mvwAccountLocked, accountLockedFilter).ToString();
            string bmcAccountLocked = lbDashboardAccountLockedBMC.Text;
            lbDashboardAccountLockedBMCNumber.Text = Functions.userCount(bmcAccountLocked, accountLockedFilter).ToString();
            string choAccountLocked = lbDashboardAccountLockedCHO.Text;
            lbDashboardAccountLockedCHONumber.Text = Functions.userCount(choAccountLocked, accountLockedFilter).ToString();
            string larAccountLocked = lbDashboardAccountLockedLAR.Text;
            lbDashboardAccountLockedLARNumber.Text = Functions.userCount(larAccountLocked, accountLockedFilter).ToString();
            string hdcAccountLocked = lbDashboardAccountLockedHDC.Text;
            lbDashboardAccountLockedHDCNumber.Text = Functions.userCount(hdcAccountLocked, accountLockedFilter).ToString();

            string accountExpiredFilter = lbDashboardAccountExpired.Text;
            string mvwAccountExpired = lbDashboardAccountExpiredMVW.Text;
            lbDashboardAccountExpiredMVWNumber.Text = Functions.userCount(mvwAccountExpired, accountExpiredFilter).ToString();
            string bmcAccountExpired = lbDashboardAccountExpiredBMC.Text;
            lbDashboardAccountExpiredBMCNumber.Text = Functions.userCount(bmcAccountExpired, accountExpiredFilter).ToString();
            string choAccountExpired = lbDashboardAccountExpiredCHO.Text;
            lbDashboardAccountExpiredCHONumber.Text = Functions.userCount(choAccountExpired, accountExpiredFilter).ToString();
            string larAccountExpired = lbDashboardAccountExpiredLAR.Text;
            lbDashboardAccountExpiredLARNumber.Text = Functions.userCount(larAccountExpired, accountExpiredFilter).ToString();
            string hdcAccountExpired = lbDashboardAccountExpiredHDC.Text;
            lbDashboardAccountExpiredHDCNumber.Text = Functions.userCount(hdcAccountExpired, accountExpiredFilter).ToString();

            string AccountDeactivatedFilter = lbDashboardAccountDeactivated.Text;
            string mvwAccountDeactivatedSite = lbDashboardAccountDeactivatedMVW.Text;
            lbDashboardAccountDeactivatedMVWNumber.Text = Functions.userCount(mvwAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string bmcAccountDeactivatedSite = lbDashboardAccountDeactivatedBMC.Text;
            lbDashboardAccountDeactivatedBMCNumber.Text = Functions.userCount(bmcAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string choAccountDeactivatedSite = lbDashboardAccountDeactivatedCHO.Text;
            lbDashboardAccountDeactivatedCHONumber.Text = Functions.userCount(choAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string larAccountDeactivatedSite = lbDashboardAccountDeactivatedLAR.Text;
            lbDashboardAccountDeactivatedLARNumber.Text = Functions.userCount(larAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string hdcAccountDeactivatedSite = lbDashboardAccountDeactivatedHDC.Text;
            lbDashboardAccountDeactivatedHDCNumber.Text = Functions.userCount(hdcAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
        }

        void hideSubMenu()
        {
            foreach (var pn in pnMenu.Controls.OfType<Panel>())
                pn.Height = 50;
        }

        void showSubMenu(Panel pn)
        {
            pn.Height = pn.Controls.OfType<Button>().Count() * 25 + 25;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Form currentForm = Form.ActiveForm;
            currentForm.Controls.Clear();
            InitializeComponent();
            hideSubMenu();
            string passwordExpiredFilter = lbDashboardPasswordExpired.Text;
            string mvwPasswordExpired = lbDashboardPasswordExpiredMVW.Text;
            lbDashboardPasswordExpiredMVWNumber.Text = Functions.userCount(mvwPasswordExpired, passwordExpiredFilter).ToString();
            string bmcPasswordExpired = lbDashboardPasswordExpiredBMC.Text;
            lbDashboardPasswordExpiredBMCNumber.Text = Functions.userCount(bmcPasswordExpired, passwordExpiredFilter).ToString();
            string choPasswordExpired = lbDashboardPasswordExpiredCHO.Text;
            lbDashboardPasswordExpiredCHONumber.Text = Functions.userCount(choPasswordExpired, passwordExpiredFilter).ToString();
            string larPasswordExpired = lbDashboardPasswordExpiredLAR.Text;
            lbDashboardPasswordExpiredLARNumber.Text = Functions.userCount(larPasswordExpired, passwordExpiredFilter).ToString();
            string hdcPasswordExpired = lbDashboardPasswordExpiredHDC.Text;
            lbDashboardPasswordExpiredHDCNumber.Text = Functions.userCount(hdcPasswordExpired, passwordExpiredFilter).ToString();

            string accountLockedFilter = lbDashboardAccountLocked.Text;
            string mvwAccountLocked = lbDashboardAccountLockedMVW.Text;
            lbDashboardAccountLockedMVWNumber.Text = Functions.userCount(mvwAccountLocked, accountLockedFilter).ToString();
            string bmcAccountLocked = lbDashboardAccountLockedBMC.Text;
            lbDashboardAccountLockedBMCNumber.Text = Functions.userCount(bmcAccountLocked, accountLockedFilter).ToString();
            string choAccountLocked = lbDashboardAccountLockedCHO.Text;
            lbDashboardAccountLockedCHONumber.Text = Functions.userCount(choAccountLocked, accountLockedFilter).ToString();
            string larAccountLocked = lbDashboardAccountLockedLAR.Text;
            lbDashboardAccountLockedLARNumber.Text = Functions.userCount(larAccountLocked, accountLockedFilter).ToString();
            string hdcAccountLocked = lbDashboardAccountLockedHDC.Text;
            lbDashboardAccountLockedHDCNumber.Text = Functions.userCount(hdcAccountLocked, accountLockedFilter).ToString();

            string accountExpiredFilter = lbDashboardAccountExpired.Text;
            string mvwAccountExpired = lbDashboardAccountExpiredMVW.Text;
            lbDashboardAccountExpiredMVWNumber.Text = Functions.userCount(mvwAccountExpired, accountExpiredFilter).ToString();
            string bmcAccountExpired = lbDashboardAccountExpiredBMC.Text;
            lbDashboardAccountExpiredBMCNumber.Text = Functions.userCount(bmcAccountExpired, accountExpiredFilter).ToString();
            string choAccountExpired = lbDashboardAccountExpiredCHO.Text;
            lbDashboardAccountExpiredCHONumber.Text = Functions.userCount(choAccountExpired, accountExpiredFilter).ToString();
            string larAccountExpired = lbDashboardAccountExpiredLAR.Text;
            lbDashboardAccountExpiredLARNumber.Text = Functions.userCount(larAccountExpired, accountExpiredFilter).ToString();
            string hdcAccountExpired = lbDashboardAccountExpiredHDC.Text;
            lbDashboardAccountExpiredHDCNumber.Text = Functions.userCount(hdcAccountExpired, accountExpiredFilter).ToString();

            string AccountDeactivatedFilter = lbDashboardAccountDeactivated.Text;
            string mvwAccountDeactivatedSite = lbDashboardAccountDeactivatedMVW.Text;
            lbDashboardAccountDeactivatedMVWNumber.Text = Functions.userCount(mvwAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string bmcAccountDeactivatedSite = lbDashboardAccountDeactivatedBMC.Text;
            lbDashboardAccountDeactivatedBMCNumber.Text = Functions.userCount(bmcAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string choAccountDeactivatedSite = lbDashboardAccountDeactivatedCHO.Text;
            lbDashboardAccountDeactivatedCHONumber.Text = Functions.userCount(choAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string larAccountDeactivatedSite = lbDashboardAccountDeactivatedLAR.Text;
            lbDashboardAccountDeactivatedLARNumber.Text = Functions.userCount(larAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
            string hdcAccountDeactivatedSite = lbDashboardAccountDeactivatedHDC.Text;
            lbDashboardAccountDeactivatedHDCNumber.Text = Functions.userCount(hdcAccountDeactivatedSite, AccountDeactivatedFilter).ToString();
        }

        private void btnUtilitytools_Click(object sender, EventArgs e)
        {
            hideSubMenu(); 
            showSubMenu(pnDrUtilitytools);
        }

        private void btnTroubleshootingtools_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(pnDrTroubleshootingtools);
        }

        private void btnActivedirectory_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(pnDrActivedirectory);
        }
        private void btnLookupUser_Click(object sender, EventArgs e)
        {
            var myForm = new lookupUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnRemoteRegistryEdit_Click(object sender, EventArgs e)
        {
            var myForm = new remoteRegistry();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnResetpassword_Click(object sender, EventArgs e)
        {
            var myForm = new resetPassword();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            var myForm = new createUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var myForm = new deleteUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnPingPc_Click(object sender, EventArgs e)
        {
            var myForm = new pingPc();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnDatamigration_Click(object sender, EventArgs e)
        {
            var myForm = new dataMigration();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnDeactivatedUser_Click(object sender, EventArgs e)
        {
            var myForm = new deactivatedUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnPasswordExpiredUser_Click(object sender, EventArgs e)
        {
            var myForm = new passwordExpiredUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnAccountLocked_Click(object sender, EventArgs e)
        {
            var myForm = new accountLockedUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }

        private void btnAccountExpiredUser_Click(object sender, EventArgs e)
        {
            var myForm = new accountExpiredUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            this.pnMain.Controls.Add(myForm);
            myForm.BringToFront();
            myForm.Show();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void pbMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}