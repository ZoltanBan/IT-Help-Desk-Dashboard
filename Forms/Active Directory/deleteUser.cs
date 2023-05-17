using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Net.Http;
using Microsoft.VisualBasic;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class deleteUser : Form
    {
        //Global Variables, class, and functions for deleteUser
        bool firstButtonClicked = false;
        bool SecondButtonClicked = false;
        public deleteUser()
        {
            InitializeComponent();
        }
        private void btnDeleteUserDisplayUser_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtDeleteUser.Text;
                string[] results = Functions.GetAD(username);
                if (results == null)
                {
                    rtxtDeleteUser.Text = "Invalid Entry" + "\n'" + username.ToUpper() + "' is Not Correct";
                    return;
                }

                string activeStatus;
                if (results[7] == "512")                //userAccountControll Attribute
                    activeStatus = "True";
                else if (results[7] == "514")
                    activeStatus = "False";
                else
                    activeStatus = "Unknown Status";

                rtxtDeleteUser.Text = "User: " + results[2] + " " + "(" + results[0] + ")"
                    + "\nEmail: " + results[3]
                    + "\nAccount Active: " + activeStatus
                    + "\nipPhone: " + results[8]
                    + "\nextensionAttribute9: " + results[9]
                    + "\nextensionAttribute10: " + results[10]
                    + "\nextensionAttribute13: " + results[11]
                    + "\nmsExchHideFromAddressLists: " + results[13]
                    + "\ndescription: " + results[12];

                txtDeleteUserUpdateDescription.Text = results[12];
                mojoComment = rtxtDeleteUser.Text;
                ntid = results[0];          //sAMAccountName attribute in AD
                firstname = results[14];    //givenName attribute in AD
                lastname = results[15];     //sn attribute in AD
            }
            catch
            {
                rtxtDeleteUser.Text = "Invalid Entry";
            }
            firstButtonClicked = true;  //Prerequiste for 'Display Account'
            SecondButtonClicked = true; //Prerequiste for 'Clear EA13'
        }
        private void btnDeleteUserDisableAccount_Click(object sender, EventArgs e)
        {
            if (firstButtonClicked == false)    //Must click 'Display User' first
            {
                MessageBox.Show("You Must Click 'Display User' First", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string username = txtDeleteUser.Text;
                string[] adSearch = Functions.GetAD(username);
                if (adSearch == null)
                {
                    rtxtDeleteUser.Text = "Invalid Entry" + "\n'" + username.ToUpper() + "' is Not Correct";
                    return;
                }
                string answer = MessageBox.Show("Please Confirm Again "
                                                + "\n\nUser ID: " + adSearch[0]
                                                + "\nUser name: " + adSearch[2]
                                                + "\nE-mail: " + adSearch[3],
                                                "Desktop Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                if (answer == "No")
                    return;
                

                string samAccount = adSearch[0];
                int newUserAccountControlValue = 514; //userAccountControl value 512=Active, 514=Disable

                DirectorySearcher searcher = new DirectorySearcher();
                searcher.Filter = "(sAMAccountName=" + samAccount + ")";
                searcher.PropertiesToLoad.Add("userAccountControl");
                searcher.PropertiesToLoad.Add("description");
                searcher.PropertiesToLoad.Add("msExchHideFromAddressLists");
                searcher.PropertiesToLoad.Add("extensionAttribute13");
                searcher.PropertiesToLoad.Add("ipPhone");
                SearchResult result = searcher.FindOne();
                DirectoryEntry userEntry = result.GetDirectoryEntry();
                int currentFlags = (int)userEntry.Properties["userAccountControl"].Value;
                userEntry.Properties["userAccountControl"].Value = newUserAccountControlValue | currentFlags;       //Disable
                userEntry.Properties["msExchHideFromAddressLists"].Value = "TRUE";                                  //msExchHideFromAddressLists
                if (adSearch[11] == "o365;OKTA")                                                                    //EA13 Remove Okta
                    userEntry.Properties["extensionAttribute13"].Value = "o365";
                else if (adSearch[11] == "OKTA")
                    userEntry.Properties["extensionAttribute13"].Value = null;
                userEntry.Properties["ipPhone"].Value = null;                                                       //Clear ipPhone
                if (txtDeleteUserUpdateDescription.Text != "")                                                      //Update Description
                    userEntry.Properties["description"].Value = txtDeleteUserUpdateDescription.Text;
                userEntry.CommitChanges();

                string[] results = Functions.GetAD(username);       //Query again to reflect the change
                string activeStatus;
                if (results[7] == "512")                            //userAccountControll Attribute
                    activeStatus = "True";
                else if (results[7] == "514")
                    activeStatus = "False";
                else
                    activeStatus = "Unknown Status";

                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyyMMdd");

                rtxtDeleteUser.Text = "User: " + results[2] + " " + "(" + results[0] + ")"
                    + "\nEmail: " + results[3]
                    + "\nAccount Active: " + activeStatus
                    + "\nipPhone: " + results[8]
                    + "\nextensionAttribute9: " + results[9]
                    + "\nextensionAttribute10: " + results[10]
                    + "\nextensionAttribute13: " + results[11]
                    + "\nmsExchHideFromAddressLists: " + results[13]
                    + "\ndescription: " + results[12]
                    + "\n\nIt is necessary to rename the user folder by hand on \\\\IN1\\OPU\\Users "
                    + "\nRename Users Home folder - "
                    + "\nFrom: " + results[0] + " To: " + formattedDate + " " + results[2] + " " + results[0];
                mojoComment = rtxtDeleteUser.Text;
            }
            catch
            {
                rtxtDeleteUser.Text = "Invalid Entry";
            }
            firstButtonClicked = false;
        }
        private void btnDeleteUserClearEA13_Click(object sender, EventArgs e)
        {
            if (SecondButtonClicked == false)   //Must click 'Display User' first
            {
                MessageBox.Show("You Must Click 'Display User' First", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string username = txtDeleteUser.Text;
                string[] adSearch = Functions.GetAD(username);
                if (adSearch == null)
                {
                    rtxtDeleteUser.Text = "Invalid Entry" + "\n'" + username.ToUpper() + "' is Not Correct";
                    return;
                }
                string answer = MessageBox.Show("Please Confirm Again "
                                                + "\n\nUser ID: " + adSearch[0]
                                                + "\nUser name: " + adSearch[2]
                                                + "\nE-mail: " + adSearch[3],
                                                "Desktop Dashboard", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                if (answer == "No")
                    return;
                

                string samAccount = adSearch[0];
                DirectorySearcher searcher = new DirectorySearcher();
                searcher.Filter = "(sAMAccountName=" + samAccount + ")";
                searcher.PropertiesToLoad.Add("extensionAttribute13");
                SearchResult result = searcher.FindOne();
                DirectoryEntry userEntry = result.GetDirectoryEntry();
                userEntry.Properties["extensionAttribute13"].Value = null;
                userEntry.CommitChanges();

                string[] results = Functions.GetAD(username);       //Query again to reflect the change
                string activeStatus;
                if (results[7] == "512")                            //userAccountControll Attribute
                    activeStatus = "True";
                else if (results[7] == "514")
                    activeStatus = "False";
                else
                    activeStatus = "Unknown Status";

                rtxtDeleteUser.Text = "User: " + results[2] + " " + "(" + results[0] + ")"
                    + "\nEmail: " + results[3]
                    + "\nAccount Active: " + activeStatus
                    + "\nipPhone: " + results[8]
                    + "\nextensionAttribute9: " + results[9]
                    + "\nextensionAttribute10: " + results[10]
                    + "\nextensionAttribute13: " + results[11]
                    + "\nmsExchHideFromAddressLists: " + results[13]
                    + "\ndescription: " + results[12];
                mojoComment = rtxtDeleteUser.Text;
            }
            catch
            {
                rtxtDeleteUser.Text = "Invalid Entry";
            }
            SecondButtonClicked = false;
        }
        private void btnDeleteUserNewDescripton_Click(object sender, EventArgs e)
        {
            string username = Environment.UserName;
            string[] adSearch = Functions.GetAdmin(username);
            string firstname = adSearch[14];
            char firstInitial = firstname[0];
            string lastname = adSearch[15];
            char lastInitial = lastname[0];
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MM/dd/yyyy");

            txtDeleteUserUpdateDescription.Text = "Disabled " + formattedDate + " per Authority - " + firstInitial + lastInitial;
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            rtxtDeleteUser.Text = "";
            txtDeleteUserUpdateDescription.Text = "";
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string text = rtxtDeleteUser.Text;
            Clipboard.SetText(text);
            MessageBox.Show("Following text has been copied to the clipboard\n\n" + text, "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Global Variables, class, and functions for Mojo Api
        string mojoTicketNumber { get; set; }
        string mojoComment { get; set; }
        string firstname { get; set; }
        string lastname { get; set; }
        string ntid { get; set; }
        public class Ticket
        {
            public string title { get; set; }
            public string description { get; set; }
            public List<CustomFieldType> custom_field_types { get; set; }
            public List<CustomFieldValue> custom_field_values { get; set; }
        }
        public class CustomFieldType
        {
            public string name { get; set; }
        }
        public class CustomFieldValue
        {
            public string value { get; set; }
        }
        public class RootObjectDelete
        {
            public Ticket ticket { get; set; }
        }
        public static HttpClient deleteApiClient { get; set; }

        private void btnDeleteUserExportToMojo_Click(object sender, EventArgs e)
        {
            if (rtxtDeleteUser.Text == "")
            {
                MessageBox.Show("There is no result to export", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //------------------------------------------------------------------------------
                //Currently, there is no need to import tickets from Mojo. Commenting for now.

                //deleteApiClient = new HttpClient();
                //var newDeleteTicket = await Functions.deleteUserLoadTicket(mojoTicketNumber);
                //if (newDeleteTicket == null)
                //{
                //    MessageBox.Show("Load ticket from Mojo failed", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //int size = newDeleteTicket.ticket.custom_field_values.Count;
                //string[] value = new string[size];
                //for (int i = 0; i < newDeleteTicket.ticket.custom_field_values.Count; i++)
                //{
                //    CustomFieldValue customFieldValue = newDeleteTicket.ticket.custom_field_values[i];
                //    value[i] = customFieldValue.value.ToString();

                //}
                //firstname = value[17];                //Custom Field Value 17: first_name
                //lastname = value[19];                 //Custom Field Value 19: last_name
                //ntid = value[20];                     //Custom Field Value 20: ntid

                mojoTicketNumber = Interaction.InputBox("Please enter ticket number in Mojo:", "Mojo Import");
                if (mojoTicketNumber == "")
                    return;

                Functions.commentTicket(mojoTicketNumber, mojoComment);
                Functions.deleteUserUpdateTicket(mojoTicketNumber, firstname, lastname, ntid);
                MessageBox.Show("Export Ticket to Mojo Completed", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Export Ticket to Mojo failed", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}