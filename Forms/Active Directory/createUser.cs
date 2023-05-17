using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Microsoft.VisualBasic;

namespace desktopDashboard___Y_Lee.Forms
{
    public partial class createUser : Form
    {
        public createUser()
        {
            InitializeComponent();
            txtCreateUserNewUserAccount.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserEmailAddress.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserIPPhone.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserContractorCompany.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserContractorEmail.BackColor = Color.FromArgb(220, 220, 220);

            //List AD memberships below, excluding the default memberships
            disposeMemberships = new string[1];
            disposeMemberships[0] = "G CHO Ineos Rec Club"; // This is a paid membership
        }
        //Global Variables, class, and functions for createUser
        bool firstButtonClicked = false;
        bool displayMembershipClicked = false;
        bool accountCreated = false;
        string addDispose { get; set; }
        string[] disposeMemberships { get; set; }
        string[] copyMemberships { get; set; }
        string firstname { get; set; }
        string firstInitial { get; set; }
        string lastname { get; set; }
        string lastInitial { get; set; }
        string middleName { get; set; }
        string middleInitial { get; set; }
        string displayName { get; set; }
        string email { get; set; }
        string ntid { get; set; }
        string contractorCompanyName { get; set; }
        string contractorEmail { get; set; }
        string officeNumber { get; set; }
        string telephoneNumber { get; set; }
        string ipPhone { get; set; }
        string jobTitle { get; set; }
        string department { get; set; }
        string managerNTID { get; set; }
        string managerName { get; set; }
        string o365License { get; set; }
        string extensionAttribute1 { get; set; }
        string extensionAttribute2 { get; set; }
        string extensionAttribute9 { get; set; }
        string extensionAttribute10 { get; set; }
        string extensionAttribute11 { get; set; }
        string extensionAttribute12 { get; set; }
        string extensionAttribute13 { get; set; }
        private void comboBoxCreateUserUserType_SelectedIndexChanged(object sender, EventArgs e)        //Disable contractor fields as default
        {
            if (comboBoxCreateUserUserType.Text == "Contractor")
            {
                txtCreateUserContractorCompany.Enabled = true;
                txtCreateUserContractorCompany.BackColor = Color.FromArgb(32, 33, 36);
                txtCreateUserContractorEmail.Enabled = true;
                txtCreateUserContractorEmail.BackColor = Color.FromArgb(32, 33, 36);
            }
            else if (comboBoxCreateUserUserType.Text == "External")
            {
                txtCreateUserContractorCompany.Enabled = true;
                txtCreateUserContractorCompany.BackColor = Color.FromArgb(32, 33, 36);
                txtCreateUserContractorEmail.Enabled = true;
                txtCreateUserContractorEmail.BackColor = Color.FromArgb(32, 33, 36);
            }
            else if (comboBoxCreateUserUserType.Text == "Employee")
            {
                txtCreateUserContractorCompany.Enabled = false;
                txtCreateUserContractorCompany.Text = "";
                txtCreateUserContractorCompany.BackColor = Color.FromArgb(220, 220, 220);
                txtCreateUserContractorEmail.Enabled = false;
                txtCreateUserContractorEmail.Text = "";
                txtCreateUserContractorEmail.BackColor = Color.FromArgb(220, 220, 220);
            }

            if (checkBoxCreateUserO365MailEnabled.CheckState == CheckState.Checked)
            {
                if (comboBoxCreateUserUserType.Text == "Contractor" || comboBoxCreateUserUserType.Text == "External")
                {
                    txtCreateUserContractorCompany.Enabled = true;
                    txtCreateUserContractorCompany.BackColor = Color.FromArgb(32, 33, 36);
                    txtCreateUserContractorEmail.Enabled = false;
                    txtCreateUserContractorEmail.BackColor = Color.FromArgb(220, 220, 220);
                }
            }
            else
            {
                if (comboBoxCreateUserUserType.Text == "Contractor" || comboBoxCreateUserUserType.Text == "External")
                {
                    txtCreateUserContractorCompany.Enabled = true;
                    txtCreateUserContractorCompany.BackColor = Color.FromArgb(32, 33, 36);
                    txtCreateUserContractorEmail.Enabled = true;
                    txtCreateUserContractorEmail.BackColor = Color.FromArgb(32, 33, 36);
                }
            }
        }
        private void checkBoxO365MailEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCreateUserO365MailEnabled.CheckState == CheckState.Unchecked)
            {
                comboBoxCreateUserO365License.Enabled = false;
                comboBoxCreateUserO365License.Text = "";
                comboBoxCreateUserO365License.BackColor = Color.FromArgb(220, 220, 220);
                if (comboBoxCreateUserUserType.Text == "Contractor" || comboBoxCreateUserUserType.Text == "External")
                {
                    txtCreateUserContractorEmail.Enabled = true;
                    txtCreateUserContractorEmail.BackColor = Color.FromArgb(32, 33, 36);
                }
            }
            else
            {
                comboBoxCreateUserO365License.Enabled = true;
                comboBoxCreateUserO365License.BackColor = Color.FromArgb(32, 33, 36);
                if (comboBoxCreateUserUserType.Text == "Contractor" || comboBoxCreateUserUserType.Text == "External")
                {
                    txtCreateUserContractorEmail.Enabled = false;
                    txtCreateUserContractorEmail.BackColor = Color.FromArgb(220, 220, 220);
                }
            }
        }
        private void checkBoxCreateUserIPPhone_CheckedChanged(object sender, EventArgs e)               //ipPhone field is optional
        {
            if (checkBoxCreateUserIPPhone.CheckState == CheckState.Unchecked)
            {
                txtCreateUserIPPhone.Enabled = false;
                txtCreateUserIPPhone.Text = "";
                txtCreateUserIPPhone.BackColor = Color.FromArgb(220, 220, 220);
            }
            else
            {
                txtCreateUserIPPhone.Enabled = true;
                txtCreateUserIPPhone.BackColor = Color.FromArgb(32, 33, 36);
            }
        }
        private void btnCreateUserGenerateNTID_Click(object sender, EventArgs e) //Store user inputs as global variables and create variables to hold NTID and email values as strings
        {
            //EA 1, 2, 9, 10, 11, 12, 13 Need to be assigned
            //EA 1, 9, 10 combobox values
            extensionAttribute1 = comboBoxCreateUserSiteCode.Text;                              //EA 1
            if (checkBoxCreateUserO365MailEnabled.Checked)                                      //EA 9
                if(comboBoxCreateUserO365License.Text == "")
                {
                    MessageBox.Show("Please Select o365 License", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    extensionAttribute9 = "IN1_IN1_" + comboBoxCreateUserO365License.Text;
                    o365License = comboBoxCreateUserO365License.Text;
                }    
            else
                extensionAttribute9 = "";
            extensionAttribute10 = comboBoxCreateUserUserType.Text;                             //EA 10
            //EA 2, 11, 12 hardcoded values
            extensionAttribute2 = "OP USA";                                                     //EA 2
            extensionAttribute11 = "GMAIL_SUB";                                                 //EA 11 *Exceptional IN1_SUB(MVW Treasury)
            extensionAttribute12 = "OPUSA_O365";                                                //EA 12 *Exceptional OPUSA_G_O365(Mailbox Account), RAM_O365(MVW Treasury)
            //EA 13 is checkbox values
            string oktaAnswer = "";     //used for MessageBox variable
            string emailAnswer = "";    //used for MessageBox variable
            if (checkBoxCreateUserO365MailEnabled.Checked)
            {
                extensionAttribute13 = "o365";
                emailAnswer = "Yes";
            }
            else
            {
                extensionAttribute13 = "";
                emailAnswer = "No";
            }
            if (checkBoxCreateUserEnableOkta.Checked)
            {
                if (checkBoxCreateUserO365MailEnabled.Checked)
                {
                    extensionAttribute13 = "o365;OKTA";
                    oktaAnswer = "Yes";
                }
                else
                {
                    extensionAttribute13 = "OKTA";
                    oktaAnswer = "Yes";
                }
            }
            else
                oktaAnswer = "No";
            //Firstname
            if(txtCreateUserFirstname.Text == "")
            {
                MessageBox.Show("1. Firstname"
                                + "\n2. Lastname"
                                + "\n3. Site Code"
                                + "\n4. User Type"
                                + "\n\nCannot be empty. Please enter missing fields",
                                "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            firstname = txtCreateUserFirstname.Text;
            firstname = firstname.ToLower();
            firstname = char.ToUpper(firstname[0]) + firstname.Substring(1);
            firstInitial = firstname.Substring(0, 1);
            //Lastname
            if (txtCreateUserLastname.Text == "")
            {
                MessageBox.Show("1. Firstname"
                                + "\n2. Lastname"
                                + "\n3. Site Code"
                                + "\n4. User Type"
                                + "\n\nCannot be empty. Please enter missing fields",
                                "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lastname = txtCreateUserLastname.Text;
            lastname = lastname.ToLower();
            lastname = char.ToUpper(lastname[0]) + lastname.Substring(1);
            lastInitial = lastname.Substring(0, 1);
            //Middle Initial
            if (txtCreatUserMiddleInitial.Text == "")
                middleInitial = "X";
            else
            {
                middleName = txtCreatUserMiddleInitial.Text;
                middleName = middleName.ToUpper();
                middleInitial = middleName.Substring(0, 1);
            }
            //The following fields are mandatory for creating a user: Firstname, Lastname, EA1 (Site Code), and EA10 (User Type)
            if (firstname == "" || lastname == "" || extensionAttribute1 == "" || extensionAttribute10 == "")
            {
                MessageBox.Show("1. Firstname"
                                + "\n2. Lastname"
                                + "\n3. Site Code"
                                + "\n4. User Type"
                                + "\n\nCannot be empty. Please enter missing fields",
                                "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Confirm in Active Directory that a user with the same first name, last name, and middle initial does not already exist
            DirectoryEntry entry = new DirectoryEntry("LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com", null, null, AuthenticationTypes.Secure | AuthenticationTypes.Sealing | AuthenticationTypes.Signing);
            DirectorySearcher searcher = new DirectorySearcher(entry);
            searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(givenName={0})(sn={1})(initials={2}))", firstname, lastname, middleInitial); //Search field values
            searcher.SearchScope = SearchScope.Subtree;
            SearchResult result = searcher.FindOne();
            if (result != null)
            {
                MessageBox.Show("There is an existing user that has same Firstname and Lastname", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //NTID
            ntid = Functions.createNTID(firstInitial, middleInitial, lastInitial);
            //Email
            if (((comboBoxCreateUserUserType.Text == "Contractor") && !(checkBoxCreateUserO365MailEnabled.Checked))
                || ((comboBoxCreateUserUserType.Text == "External") && !(checkBoxCreateUserO365MailEnabled.Checked)))
                email = txtCreateUserContractorEmail.Text;
            else
                email = Functions.createEmailAddress(firstname, lastname, extensionAttribute10);
            //Supervisor
            if (txtCreateUserSupervisor.Text == "")
            {
                managerNTID = "";
                managerName = "";
            }
            else
            {
                managerNTID = txtCreateUserSupervisor.Text;
                string[] managerQuery = Functions.GetAD(managerNTID);
                if (managerQuery == null)
                {
                    MessageBox.Show("Invalid Supervisor Input Entry. Please Verify", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                managerName = managerQuery[2];  //displayName value in Attributes
            }
            //Department
            if (txtCreateUserDepartment.Text == "")
                department = "";
            else
                department = txtCreateUserDepartment.Text;
            //Position
            if (txtlbCreateUserPosition.Text == "")
                jobTitle = "";
            else
                jobTitle = txtlbCreateUserPosition.Text;
            //Phone - input must be numbers only without any special characters
            int phoneCount = txtCreateUserPhone.Text.Length;
            if (txtCreateUserPhone.Text == "")
                telephoneNumber = "";           
            else if (phoneCount == 10 && txtCreateUserPhone.Text != "")
            {
                telephoneNumber = txtCreateUserPhone.Text;
                var areaCode = telephoneNumber.Substring(0, 3);
                var middleNumbers = telephoneNumber.Substring(3, 3);
                var lastNumbers = telephoneNumber.Substring(6, 4);
                telephoneNumber = areaCode + "-" + middleNumbers + "-" + lastNumbers;
            }
            else
            {
                MessageBox.Show("Phone Number is Not Entered Correctly. \nType Numbers Only", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //IP Phone
            if (txtCreateUserIPPhone.Text == "")
                ipPhone = "";
            else
                ipPhone = txtCreateUserIPPhone.Text;
            //Office
            if (txtCreateUserOffice.Text == "")
                officeNumber = "";
            else
                officeNumber = txtCreateUserOffice.Text;
            //Contractor Company Name and Email
            if (txtCreateUserContractorCompany.Text != "")
            {
                contractorCompanyName = txtCreateUserContractorCompany.Text;
                contractorEmail = email;
            }
            else
            {
                contractorCompanyName = "";
                contractorEmail = "";
            }
            //Display name
            if (middleInitial != "X")
            {
                if ((extensionAttribute10 == "External" && contractorCompanyName != "") || (extensionAttribute10 == "Contractor" && contractorCompanyName != ""))
                    displayName = lastname + ", " + firstname + " " + middleInitial + " (" + contractorCompanyName + ")";
                else
                    displayName = lastname + ", " + firstname + " " + middleInitial;
            }
            else
            {
                if ((extensionAttribute10 == "External" && contractorCompanyName != "") || (extensionAttribute10 == "Contractor" && contractorCompanyName != ""))
                    displayName = lastname + ", " + firstname + " (" + contractorCompanyName + ")";
                else
                    displayName = lastname + ", " + firstname;
            }
            //Confirm
            string answer = MessageBox.Show("Please Confirm Again\n"
                                                             + "\nFirstname:                      " + firstname
                                                             + "\nLastname:                       " + lastname
                                                             + "\nMiddle name Initial:      " + middleInitial
                                                             + "\nUser type:                       " + extensionAttribute10
                                                             + "\nSite code:                       " + extensionAttribute1
                                                             + "\nEnable Okta?:                " + oktaAnswer
                                                             + "\nEnable Email?:               " + emailAnswer
                                                             + "\nO365 License:                " + comboBoxCreateUserO365License.Text
                                                             + "\nSupervisor:                    " + managerName
                                                             + "\nDepartment:                  " + department
                                                             + "\nPosition:                        " + jobTitle
                                                             + "\nPhone:                           " + telephoneNumber
                                                             + "\nOffice:                            " + officeNumber
                                                             + "\n\n*Contractor Informaton if applicable"
                                                             + "\nContract Company Name:     " + contractorCompanyName
                                                             + "\nContract Company email:    " + contractorEmail,
                                   "Create User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
            if (answer == "No")
                return;

            txtCreateUserNewUserAccount.Text = ntid;
            txtCreateUserNewUserAccount.Enabled = true;
            txtCreateUserNewUserAccount.BackColor = Color.FromArgb(32, 33, 36);
            txtCreateUserEmailAddress.Text = email;
            txtCreateUserEmailAddress.Enabled = true;
            txtCreateUserEmailAddress.BackColor = Color.FromArgb(32, 33, 36);

            firstButtonClicked = true; //The 'Generate NTID' button is a prerequisite for account creation
        }
        private void btnCreateUserCreateAccount_Click(object sender, EventArgs e)
        {
            if (firstButtonClicked == false) //The 'Generate NTID' button is a prerequisite for account creation
            {
                MessageBox.Show("You Must Generate NTID / Email First", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ntid == null)
            {
                MessageBox.Show("You Must Generate NTID / Email First", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DirectoryEntry ldapConnection = new DirectoryEntry("");
            if (extensionAttribute1 == "MVW")
                ldapConnection.Path = "LDAP://OU=Users,OU=MVW,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (extensionAttribute1 == "BMC")
                ldapConnection.Path = "LDAP://OU=Users,OU=BMC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (extensionAttribute1 == "CHO")
                ldapConnection.Path = "LDAP://OU=Users,OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (extensionAttribute1 == "LAR")
                ldapConnection.Path = "LDAP://OU=Users,OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (extensionAttribute1 == "HDC")
                ldapConnection.Path = "LDAP://OU=Users,OU=HDC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            //Creation Start
            DirectoryEntry childEntry = ldapConnection.Children.Add("CN=" + lastname + "\\" + ", " + firstname + " " + middleInitial, "user");
            if (middleInitial == "X")
                childEntry = ldapConnection.Children.Add("CN=" + lastname + "\\" + ", " + firstname, "user");
            //General Tab
            childEntry.Properties["givenName"].Value = firstname;                                                                      //First name
            childEntry.Invoke("Put", new object[] { "Initials", middleInitial });                                                      //Initials
            childEntry.Properties["sn"].Value = lastname;                                                                              //Last name
            childEntry.Properties["displayName"].Value = displayName;                                                                  //Display name
            if (extensionAttribute1 == "MVW")                                                                                          //Description
                childEntry.Invoke("Put", new object[] { "Description", "rAM - " + extensionAttribute1 + " - League City, Texas" });
            else if (extensionAttribute1 == "BMC")
                childEntry.Invoke("Put", new object[] { "Description", "rAM - " + extensionAttribute1 + " - LaPorte, Texas" });
            else if (extensionAttribute1 == "CHO")
                childEntry.Invoke("Put", new object[] { "Description", "rAM - " + extensionAttribute1 + " - Alvin, Texas" });
            else if (extensionAttribute1 == "LAR")
                childEntry.Invoke("Put", new object[] { "Description", "rAM - " + extensionAttribute1 + " - Carson, CA" });
            else if (extensionAttribute1 == "HDC")
                childEntry.Invoke("Put", new object[] { "Description", "rAM - " + extensionAttribute1 + " - Houston, Texas" });
            if (officeNumber != "")
                childEntry.Properties["physicalDeliveryOfficeName"].Value = officeNumber;                                              //Office
            if (telephoneNumber != "")
                childEntry.Properties["telephoneNumber"].Value = telephoneNumber;                                                      //Telephone number
            if ((comboBoxCreateUserUserType.Text == "Contractor" && !(checkBoxCreateUserO365MailEnabled.Checked))
                || (comboBoxCreateUserUserType.Text == "External" && !(checkBoxCreateUserO365MailEnabled.Checked)))                    //Email
            {
                if (contractorEmail != "")  // Contractor that email field is not empty
                {
                    childEntry.Properties["mail"].Value = email;
                }
            }
            else
                childEntry.Properties["mail"].Value = email;
            //Address Tab
            if (extensionAttribute1 == "MVW")
            {                                                                                                                          //MVW Address
                childEntry.Properties["streetAddress"].Value = "2600 South Shore Blvd";                                                //Street
                childEntry.Properties["l"].Value = "League City";                                                                      //City
                childEntry.Properties["st"].Value = "Texas";                                                                           //State/province
                childEntry.Properties["postalCode"].Value = "77573";                                                                   //Zip/postal code
                childEntry.Properties["c"].Value = "US";                                                                               //Country/region
                childEntry.Properties["co"].Value = "United States";                                                                   //Country/region
            }
            else if (extensionAttribute1 == "BMC")                                                                                     //BMC Address
            {
                childEntry.Properties["streetAddress"].Value = "1230 Independence Pkwy";
                childEntry.Properties["l"].Value = "La Porte";
                childEntry.Properties["st"].Value = "Texas";
                childEntry.Properties["postalCode"].Value = "77571";
                childEntry.Properties["c"].Value = "US";
                childEntry.Properties["co"].Value = "United States";
            }
            else if (extensionAttribute1 == "CHO")                                                                                     //CHO Address
            {
                childEntry.Properties["streetAddress"].Value = "2 Miles SO of FM2917 on FM2004";
                childEntry.Properties["l"].Value = "Alvin";
                childEntry.Properties["st"].Value = "Texas";
                childEntry.Properties["postalCode"].Value = "77511";
                childEntry.Properties["c"].Value = "US";
                childEntry.Properties["co"].Value = "United States";
            }
            else if (extensionAttribute1 == "LAR")                                                                                     //LAR Address
            {
                childEntry.Properties["streetAddress"].Value = "2384 East 223rd St";
                childEntry.Properties["l"].Value = "Carson";
                childEntry.Properties["st"].Value = "CA";
                childEntry.Properties["postalCode"].Value = "90745";
                childEntry.Properties["c"].Value = "US";
                childEntry.Properties["co"].Value = "United States";
            }
            else if (extensionAttribute1 == "HDC")                                                                                     //HDC Address
            {
                childEntry.Properties["st"].Value = "Texas";
                childEntry.Properties["c"].Value = "US";
                childEntry.Properties["co"].Value = "United States";
            }
            //Account Tab
            if (((comboBoxCreateUserUserType.Text == "Contractor") && !(checkBoxCreateUserO365MailEnabled.Checked))                    //User logon name
            || ((comboBoxCreateUserUserType.Text == "External") && !(checkBoxCreateUserO365MailEnabled.Checked)))                                                                                                           //User logon name
                childEntry.Properties["userPrincipalName"].Value = ntid + "@in1.ad.innovene.com";
            else
                childEntry.Properties["userPrincipalName"].Value = email;
            childEntry.Properties["samAccountName"].Value = ntid;                                                                      //User logon name (pre-Windows 2000):
                                                                                                                                       //Profille
            if (extensionAttribute10 == "Employee" || extensionAttribute10 == "Contractor")
            {
                childEntry.Properties["homeDirectory"].Value = "\\\\in1\\opu\\users\\" + ntid;                                         //Home folder
                childEntry.Properties["homeDrive"].Value = "H:";                                                                       //Connect
            }
            //Telephones Tab
            if (ipPhone != "")                                                                                                         //IP phone
                childEntry.Properties["ipPhone"].Value = ipPhone;
            //Organization Tab                                                                                                         
            if (jobTitle != "")                                                                                                        //Job title
                childEntry.Properties["title"].Value = jobTitle;
            if (department != "")                                                                                                      //Department
                childEntry.Properties["department"].Value = department;
            if (contractorCompanyName == "")                                                                                           //Company
            {
                if (extensionAttribute1 == "MVW")
                    childEntry.Properties["company"].Value = "INEOS O&P USA";
                else if (extensionAttribute1 == "BMC")
                    childEntry.Properties["company"].Value = "INEOS Olefins & Polymers USA - BMC";
                else if (extensionAttribute1 == "CHO")
                    childEntry.Properties["company"].Value = "INEOS O&P";
                else if (extensionAttribute1 == "LAR")
                    childEntry.Properties["company"].Value = "INEOS Olefins & Polymers USA - LAR";
            }
            else
                childEntry.Properties["company"].Value = contractorCompanyName;
            if (txtCreateUserSupervisor.Text != "")                                                                                    //Manager
            {
                string[] manager = Functions.GetAD(txtCreateUserSupervisor.Text);
                if (manager != null)
                {
                    string displayName = manager[2].Replace(",", "\\,");
                    string site = manager[1]; //EA1
                    childEntry.Properties["manager"].Value = "CN=" + displayName + ",OU=Users,OU=" + site + ",OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
                }
            }
            //Attributes Tab
            childEntry.Properties["extensionAttribute1"].Value = extensionAttribute1;
            childEntry.Properties["extensionAttribute2"].Value = extensionAttribute2;
            if (extensionAttribute9 != "")
                childEntry.Properties["extensionAttribute9"].Value = extensionAttribute9;
            childEntry.Properties["extensionAttribute10"].Value = extensionAttribute10;
            childEntry.Properties["extensionAttribute11"].Value = extensionAttribute11;
            childEntry.Properties["extensionAttribute12"].Value = extensionAttribute12;
            if (extensionAttribute13 != "")
                childEntry.Properties["extensionAttribute13"].Value = extensionAttribute13;
            childEntry.Properties["mailNickname"].Value = firstname.ToLower() + "." + lastname.ToLower();
            childEntry.CommitChanges();
            ldapConnection.CommitChanges();
            childEntry.Invoke("SetPassword", new object[] { "Ineos2023" });     //Default Password "Ineos2023"
            childEntry.Properties["userAccountControl"].Value = "512";          //Enable Account
            childEntry.CommitChanges();

            var failedToCopyMemberships = Functions.copyMembership(disposeMemberships, displayMembershipClicked, txtCreateUserCopyMembership.Text, txtCreateUserNewUserAccount.Text);
            StringBuilder messages = new StringBuilder();
            if (failedToCopyMemberships.Count > 1)  //This is number of membershils that excludes to copy. Currently, Ineos Rec Club is default to exclude.
            {
                foreach (string failedToCopyMembership in failedToCopyMemberships)
                {
                    messages.Append(failedToCopyMembership);
                    messages.Append(Environment.NewLine);
                }
                MessageBox.Show("Account Creation Complete"
                                + "\nDefault Password is 'Ineos2023'"
                                + "\n\nFollowing Membership Copy Fail!"
                                + "\nYou do not have sufficient right to assign below\n\n"
                                + messages.ToString(), "Create User", MessageBoxButtons.OK, MessageBoxIcon.Information).ToString();
            }
            else
                MessageBox.Show("Account Creation Complete"
                                + "\nDefault Password is 'Ineos2023'", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Information).ToString();

            //Account Creation Result Display
            DirectorySearcher search = new DirectorySearcher(ldapConnection);
            search.Filter = "("
                               + "(sAMAccountName=" + ntid + ")"
                               + ")";
            string[] requiredProperties = new string[] { "extensionAttribute13",                                  
                                                                  "description",
                                                                         "mail",
                                                            "userPrincipalName",
                                                               "sAMAccountName",
                                                   "physicalDeliveryOfficeName",
                                                              "telephoneNumber",
                                                                     "ipPhone"};
            foreach (String property in requiredProperties)
                search.PropertiesToLoad.Add(property);
            SearchResult result = search.FindOne();
            if (result != null)
            {
                string[] results = new string[8] { "", "", "", "", "", "", "", ""};
                int i = 0;
                foreach (String property in requiredProperties)
                    foreach (Object myCollection in result.Properties[property])
                    {
                        if (results[i] != "")
                            i++;
                        results[i] = myCollection.ToString();
                        if (property == "userPrincipalName")
                            rtxtCreateUserOutputDisplay.AppendText("Logon Name: ");
                        else if (property == "physicalDeliveryOfficeName")
                            rtxtCreateUserOutputDisplay.AppendText("Office: ");
                        else
                            rtxtCreateUserOutputDisplay.AppendText(property + ": ");
                        rtxtCreateUserOutputDisplay.AppendText(results[i]);
                        rtxtCreateUserOutputDisplay.AppendText(Environment.NewLine);
                    }
                rtxtCreateUserOutputDisplay.AppendText("Password: " + "Ineos2023");
                mojoComment = rtxtCreateUserOutputDisplay.Text; //Export to Mojo Comment
            }
            firstButtonClicked = false;
            accountCreated = true;
        }
        private void btnCreateUserMembershipsDisplay_Click(object sender, EventArgs e)
        {
            if (firstButtonClicked == false) //The 'Generate NTID' button is a prerequisite for account creation
            {
                MessageBox.Show("You Must Generate NTID / Email First", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] source = Functions.GetAD(txtCreateUserCopyMembership.Text);
            if (source == null)
            {
                MessageBox.Show("Invalid Source User Entry", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            copyMemberships = Functions.displayMembership(source[0], disposeMemberships); //source[0] is sAMAccountName attribute in Active Directory
            rtxtCreateUserMemberships.Clear();
            rtxtCreateUserMemberships.Focus();

            rtxtCreateUserMemberships.AppendText("Current Memberships");
            for (int i = 0; i < copyMemberships.Length; i++)
            {
                if (i >= 99)
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + (i + 1) + ". " + copyMemberships[i]);
                else if (i >= 9)
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + "0" + (i + 1) + ". " + copyMemberships[i]);
                else
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + "00" + (i + 1) + ". " + copyMemberships[i]);
            }
            displayMembershipClicked = true; //Must display first before remove membersip
        }
        private void btnCreateUserMembershipsRemoveNumber_Click(object sender, EventArgs e)
        {
            if (displayMembershipClicked == false)
            {
                MessageBox.Show("Display Memberships must be clicked first!", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedMembership = txtCreateUserMembershipsRemoveNumber.Text;
            int count;
            bool isParsable = Int32.TryParse(selectedMembership, out count);

            if (isParsable == false)
            {
                MessageBox.Show("Enter correct numeric value!", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string answer = MessageBox.Show("Please Confirm Again\n" +
                                        "\nRemove" + "'" + copyMemberships[count - 1] + "'",
                                       "Create User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
            if (answer == "No")
                return;

            count--;
            addDispose = copyMemberships[count];

            copyMemberships = Functions.removeMembership(copyMemberships, addDispose);
            disposeMemberships = Functions.disposeMemberships(disposeMemberships, addDispose);

            rtxtCreateUserMemberships.Clear();
            rtxtCreateUserMemberships.Focus();

            rtxtCreateUserMemberships.AppendText("Copied Memberships");
            for (int i = 0; i < copyMemberships.Length; i++)
            {
                if (i >= 99)
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + (i + 1) + ". " + copyMemberships[i]);
                else if (i >= 9)
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + "0" + (i + 1) + ". " + copyMemberships[i]);
                else
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + "00" + (i + 1) + ". " + copyMemberships[i]);
            }

            rtxtCreateUserMemberships.AppendText(Environment.NewLine);
            rtxtCreateUserMemberships.AppendText(Environment.NewLine);
            rtxtCreateUserMemberships.SelectionColor = Color.FromArgb(255, 255, 128);
            rtxtCreateUserMemberships.AppendText("Removed Memberships");
            for (int i = 1; i < disposeMemberships.Length; i++) // disposeMemberships[0] is G CHO Ineos Rec Club
            {
                if (i >= 99)
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + (i) + ". " + disposeMemberships[i]);
                else if (i >= 9)
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + "0" + (i) + ". " + disposeMemberships[i]);
                else
                    rtxtCreateUserMemberships.AppendText(Environment.NewLine + "00" + (i) + ". " + disposeMemberships[i]);
            }
        }
        private void btnCreateUserClearMemberships_Click(object sender, EventArgs e)
        {
            //List AD memberships below, excluding the default memberships
            disposeMemberships = new string[1];
            disposeMemberships[0] = "G CHO Ineos Rec Club"; //This is a paid membership
            rtxtCreateUserMemberships.Clear();
            rtxtCreateUserMemberships.Focus();
            displayMembershipClicked = false;
        }
        private void btnCreateUserClearForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Controls.Clear();
            InitializeComponent();
            txtCreateUserNewUserAccount.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserEmailAddress.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserIPPhone.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserContractorCompany.BackColor = Color.FromArgb(220, 220, 220);
            txtCreateUserContractorEmail.BackColor = Color.FromArgb(220, 220, 220);
            //List AD memberships below, excluding the default memberships
            disposeMemberships = new string[1];
            disposeMemberships[0] = "G CHO Ineos Rec Club"; //This is a paid membership
            this.Show();
        }
        //Global Variables, class, and functions for Mojo Api
        string mojoTicketNumber { get; set; }
        string mojoComment { get; set; }
        bool importMojoClicked = false;
        public class Ticket
        {
            public string title { get; set; }
            public string description { get; set; }
            public int ticket_queue_id { get; set; }
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
        public class RootObject
        {
            public Ticket ticket { get; set; }
        }
        public static HttpClient ApiClient { get; set; }
        private void btnCreateUserExportToMojo_Click(object sender, EventArgs e)
        {
            if (accountCreated == false)
            {
                MessageBox.Show("Create Account First", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (importMojoClicked == false)
                {
                    mojoTicketNumber = Interaction.InputBox("Please enter ticket number in Mojo:", "Mojo Import");
                    if (mojoTicketNumber == "")
                        return;
                }
                Functions.updateTicket(mojoTicketNumber, firstname, lastname, ntid, email, o365License);
                Functions.commentTicket(mojoTicketNumber, mojoComment);
                MessageBox.Show("Export Ticket to Mojo Completed", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Export Ticket to Mojo failed", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private async void btnCreateUserImportFromMojo_Click(object sender, EventArgs e)
        {
            mojoTicketNumber = Interaction.InputBox("Please enter ticket number in Mojo:", "Mojo Import");
            if (mojoTicketNumber == "")
                return;
            try
            {
                ApiClient = new HttpClient();
                var newTicket = await Functions.LoadTicket(mojoTicketNumber);
                if (newTicket == null)
                {
                    MessageBox.Show("Load ticket from Mojo failed", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ticketQueueId = newTicket.ticket.ticket_queue_id;
                int size = newTicket.ticket.custom_field_values.Count;
                string title = newTicket.ticket.title;
                string description = newTicket.ticket.description;
                string[] value = new string[size];
                //string[] type = new string[size];
                for (int i = 0; i < newTicket.ticket.custom_field_values.Count; i++)
                {
                    CustomFieldValue customFieldValue = newTicket.ticket.custom_field_values[i];
                    value[i] = customFieldValue.value.ToString();
                    //CustomFieldType customFieldType = newTicket.ticket.custom_field_types[i]; //custom_field_types e.g. type13: first_name
                    //type[i] = customFieldType.name.ToString();                                //Not neeeded in this code
                }
                //Pre Creation
                txtCreateUserFirstname.Text = value[13];                //Custom Field Value 13: first_name
                txtCreateUserLastname.Text = value[19];                 //Custom Field Value 19: last_name
                txtCreatUserMiddleInitial.Text = value[21];             //Custom Field Value 21: middle_initial
                if (value[4] == "Ineos")                                //Custom Field Value 4:  contractor_or_ineos_employee
                    comboBoxCreateUserUserType.Text = "Employee";
                else
                    comboBoxCreateUserUserType.Text = value[4];
                if (ticketQueueId == 81232)                             //Ticket Queue ID:81232(MVW), 29288(BMC), 83109(CHO)
                    comboBoxCreateUserSiteCode.Text = "MVW";
                else if (ticketQueueId == 29288)
                    comboBoxCreateUserSiteCode.Text = "BMC";
                else if (ticketQueueId == 83109)
                    comboBoxCreateUserSiteCode.Text = "CHO";
                if (value[7] == "yes")                                  //Custom Field Value 7:  email
                    checkBoxCreateUserO365MailEnabled.Checked = true;
                else
                    checkBoxCreateUserO365MailEnabled.Checked = false;
                if (value[17] == "yes")                                 //Custom Field Value 17: inras
                    checkBoxCreateUserEnableOkta.Checked = true;
                else
                    checkBoxCreateUserEnableOkta.Checked = false;
                txtCreateUserDepartment.Text = value[6];                //Custom Field Value 6:  department
                txtlbCreateUserPosition.Text = value[29];               //Custom Field Value 29: position
                txtCreateUserOffice.Text = value[20];                   //Custom Field Value 20: location
                txtCreateUserContractorCompany.Text = value[3];         //Custom Field Value 3:  contractor_company 
                importMojoClicked = true;
            }
            catch
            {
                MessageBox.Show("Error while importing ticket information from Mojo", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}