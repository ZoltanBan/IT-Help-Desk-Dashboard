using System;
using System.IO;
using System.Windows.Forms;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class dataMigration : Form
    {
        public dataMigration()
        {
            InitializeComponent();
        }
        private void btnDataMigrationOK_Click(object sender, EventArgs e)
        {
            string newPc = txtDataMigrationNewPc.Text;
            string oldPc = txtDataMigrationOldPc.Text;
            string username = txtDataMigrationUserId.Text;
            string item = comboxDataMigration.Text.ToString();

            try
            {
                if (newPc == "")
                {
                    rtxtDataMigration.Text = "Please Enter New Device ID";
                    return;
                }
                if (oldPc == "")
                {
                    rtxtDataMigration.Text = "Please Enter Old Device ID";
                    return;
                }
                string[] usernameAD = Functions.GetAD(username);
                if (usernameAD == null)
                {
                    rtxtDataMigration.Text = "Invalid Username Entry\n" + "\nUsername: '" + username.ToUpper() + "' is Incorrect";
                    return;
                }
                if (item == "")
                {
                    rtxtDataMigration.Text = "Please Select Object\n"
                                            + "\n1. Edge Bookmarks"
                                            + "\n2. Chrome Bookmarks"
                                            + "\n3. Outlook Signatures"
                                            + "\n4. Quick Access";
                    return;
                }
                string answer = MessageBox.Show("Please Confirm Again "
                                                         + "\nNew PC: " + newPc.ToUpper()
                                                         + "\nOld PC: " + oldPc.ToUpper()
                                                         + "\nUser ID: " + username.ToUpper()
                                                         + "\nUser name: " + usernameAD[2],
                               "Desktop Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                if (answer == "No")
                {
                    rtxtDataMigration.Text = item + " Transfer Request Cancelled";
                    return;
                }
                string[] newPcPing = Functions.pingHostname(newPc);
                string[] oldPcPing = Functions.pingHostname(oldPc);
                if (newPcPing == null || oldPcPing == null)
                {
                    string newPcDisplayMessage;
                    string oldPcDisplayMessage;

                    if (newPcPing == null)
                        newPcDisplayMessage = "Offline";
                    else
                        newPcDisplayMessage = "Online";
                    if (oldPcPing == null)
                        oldPcDisplayMessage = "Offline";
                    else
                        oldPcDisplayMessage = "Online";

                    rtxtDataMigration.Text = "PC Status Error - " + item
                                            + "\nNew PC: '" + newPc.ToUpper() + "' Status " + newPcDisplayMessage
                                            + "\nOld PC: '" + oldPc.ToUpper() + "' Status " + oldPcDisplayMessage
                                            + "\n\nIf it fails at Chrome Bookmarks transfer then open Chrome on the new computer";
                    return;
                }
                string[,] pathConfirm = Functions.confirmPath(newPc, oldPc, username);                  //path doesn't exist if user doesn't sign on at least 1 time
                if (!(Directory.Exists(pathConfirm[0, 0])) || !(Directory.Exists(pathConfirm[1, 0])))
                {
                    rtxtDataMigration.Text = "Path is Not existed. Verify Hostnames and Username\n"
                        + "\nNew PC   : " + newPc
                        + "\nOld PC   : " + oldPc
                        + "\nNTID     : " + username
                        + "\nName     : " + usernameAD[0];
                    return;
                }

                // Data Migration Starts Here
                if (item == "Chrome Bookmarks")
                {
                    string[,] result = Functions.copyfiles(newPc, oldPc, username, item);
                    string[] reference = new string[2] { "Bookmarks", "Bookmarks.bak" };

                    rtxtDataMigration.Text = "Transferring 2 files - Chrome";
                    rtxtDataMigration.AppendText(Environment.NewLine + "1. " + reference[0]);
                    rtxtDataMigration.AppendText(Environment.NewLine + "2. " + reference[1]);
                    rtxtDataMigration.AppendText(Environment.NewLine);
                    rtxtDataMigration.AppendText(Environment.NewLine);

                    for (int i = 0; i < 2; i++)
                    {
                        if (result[0, i] == (i + 1).ToString())
                            rtxtDataMigration.AppendText(Environment.NewLine + (i + 1) + ". " + reference[i] + " - is Missing from '" + oldPc + "'");
                        else
                            rtxtDataMigration.AppendText(Environment.NewLine + (i + 1) + ". " + reference[i] + " - Transfer Completed.");
                    }
                }
                else if (item == "Edge Bookmarks")
                {
                    string[,] result = Functions.copyfiles(newPc, oldPc, username, item);
                    string[] reference = new string[3] { "Bookmarks", "Bookmarks.bak", "Bookmarks.msbak" };

                    rtxtDataMigration.Text = "Transferring 3 files - Edge";
                    rtxtDataMigration.AppendText(Environment.NewLine + "1. " + reference[0]);
                    rtxtDataMigration.AppendText(Environment.NewLine + "2. " + reference[1]);
                    rtxtDataMigration.AppendText(Environment.NewLine + "3. " + reference[2]);
                    rtxtDataMigration.AppendText(Environment.NewLine);
                    rtxtDataMigration.AppendText(Environment.NewLine);

                    for (int i = 0; i < 3; i++)
                    {
                        if (result[0, i] == (i + 1).ToString())
                            rtxtDataMigration.AppendText(Environment.NewLine + (i + 1) + ". " + reference[i] + " - is Missing from '" + oldPc + "'");
                        else
                            rtxtDataMigration.AppendText(Environment.NewLine + (i + 1) + ". " + reference[i] + " - Transfer Completed.");
                    }
                }
                else if (item == "Quick Access" || item == "Outlook Signatures")
                {
                    bool result = Functions.copyDirectory(newPc, oldPc, username, item);
                    if (result == false)
                    {
                        rtxtDataMigration.Text = "Old PC '" + oldPc + "' doesn't have Signatures";  //Windows has quick access path as default while outlook signatures not existed
                        return;
                    }
                    rtxtDataMigration.Text = item + " Transfer Done";
                }
            }
            catch
            {
                rtxtDataMigration.Text = "Invalid Entry! Please Verify Username and Hostnames\n"
                                        + "\nNew PC: " + "'" + newPc + "'"
                                        + "\nOld PC: " + "'" + oldPc + "'"
                                        + "\nNTID  : " + "'" + username + "'"
                                        + "\n\nIf it fails at Chrome Bookmarks transfer then open Chrome on the new computer";
            }
        }

        private void btnAccountExpiredUserClearResult_Click(object sender, EventArgs e)
        {
            rtxtDataMigration.Text = "";
        }
    }
}