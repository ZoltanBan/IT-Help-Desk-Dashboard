using System;
using System.Text;
using System.Linq;
using System.Net.NetworkInformation;
using System.IO;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.ServiceProcess;
using System.Management;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Forms;
using static desktopDashboard___Y_Lee.Forms.createUser;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using desktopDashboard___Y_Lee.Forms;
using static desktopDashboard___Y_Lee.Forms.deleteUser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace desktopDashboard___Y_Lee
{
    public class Functions
    {
        public static string getAPIKey()
        {
            //Developer
            //This variable will be used in case the API key has changed. The API key will only be changed when the password has expired. The Ineos Agent uses AzureAD login, so the API key should not be changed
            string yunL = "493bbe62de37882effc72ff1dd97e39050936927";
            //Manager
            string garyG = "56a72ce484f69ddeb95ff14ffc21791a00f7ad3a";
            //Senior
            string laurenP = "372d07927fb1dc68ada8a4faee27c430a2659cfb";
            string robL = "5f834481e4eb0d3ade901b0009cc21a50fb6dd39";
            string rhondaM = "732fe7a5437392ae8c4e335fd7c9ef0b366ed647";
            //Desktop Ananlyst
            //BMC
            string cedrikP = "7589be186b71d062d3c8468248602e39867195b3";
            string samA = "a4e77face004274a7bb7d17a3e3ad8be7d1b3a8f";
            string robertS = "39f434ffd0f509ed2d6cdeb16d55dc5715c0509c";
            //CHO
            string aaronW = "ff0387983a524323f5df6be72bd09a3fd97d6fa4";
            string williamA = "6cbf71086a2de9a66ace3f645039a25f8376d842";
            //LAR
            string homerT = "2af1dd5605f6a5f09a80f40c3d5fe2b72c989b66";
            
            string admName = Environment.UserName;
            string[] firstnameAD = Functions.GetAdmin(admName);
            if (firstnameAD[14] == "Yun")       //givenName attribute in AD
                return yunL;
            else if (firstnameAD[14] == "Gary")
                return garyG;
            else if (firstnameAD[14] == "Lauren")
                return laurenP;
            else if (firstnameAD[14] == "Rob")
                return robL;
            else if (firstnameAD[14] == "Rhonda")
                return rhondaM;
            else if (firstnameAD[14] == "Cedrik")
                return cedrikP;
            else if (firstnameAD[14] == "Sam")
                return samA;
            else if (firstnameAD[14] == "Robert")
                return robertS;
            else if (firstnameAD[14] == "Aaron")
                return aaronW;
            else if (firstnameAD[14] == "William")
                return williamA;
            else if (firstnameAD[14] == "Homer")
                return homerT;
            else
                return yunL;
        }
        static public async void deleteUserUpdateTicket(string ticketNumber, string firstName, string lastName, string ntid)
        {
            var client = new HttpClient();
            var apiKey = Functions.getAPIKey();
            var url = $"https://app.mojohelpdesk.com/api/v2/tickets/{ticketNumber}?access_key={apiKey}";
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MM/dd/yyyy");
            var jsonContent = new StringContent($@"{{
                                                ""title"": ""User Account Termination - {lastName}, {firstName} ({ntid}) {formattedDate} "",
                                                ""custom_field_user_network_id"": ""{ntid}""
                                                }}", Encoding.UTF8, "application/json"); //In case, customer forgot to include NTID in the ticket.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = jsonContent
            };
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            { }
            else
                MessageBox.Show("Updating Custome Field in Mojo failed", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        static public async Task<RootObjectDelete> deleteUserLoadTicket(string ticketNumber)    // Currently, there is no need to import tickets from Mojo
        {
            try
            {
                var apiKey = Functions.getAPIKey();
                string baseUrl = "https://mysupport.mojohelpdesk.com/api/tickets/";
                string url = $"{baseUrl}{ticketNumber}.json?access_key={apiKey}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                request.Headers.TryAddWithoutValidation("Accept", "application/xml");
                using (var response = await deleteUser.deleteApiClient.SendAsync(request))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    RootObjectDelete ro = JsonConvert.DeserializeObject<RootObjectDelete>(json);
                    if (response.IsSuccessStatusCode)
                        return ro;
                    else
                        return null;
                }
            }
            catch { return null; }
        }
        static public async void commentTicket(string ticketNumber, string output)
        {
            var httpClient = new HttpClient();
            var apiKey = Functions.getAPIKey();
            httpClient.BaseAddress = new Uri($"https://app.mojohelpdesk.com/api/v2/tickets/{ticketNumber}/");
            output = output.Replace("\n", "\\n");

            var jsonContentComment = new StringContent("{\"body\":\"" + output + "\"}", Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync($"staff_notes?access_key={apiKey}", jsonContentComment);

            if (httpResponse.IsSuccessStatusCode)
            {}
            else
                MessageBox.Show("Updating Staff Note in Mojo failed", "Mojo Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        static public async void updateTicket(string ticketNumber, string firstName, string lastName, string ntid, string email, string o365License)
        {
            var client = new HttpClient();
            var apiKey = Functions.getAPIKey();
            var url = $"https://app.mojohelpdesk.com/api/v2/tickets/{ticketNumber}?access_key={apiKey}";
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MM/dd/yyyy");
            var jsonContent = new StringContent($@"{{
                                                ""title"": ""New User Account (see fields for details) - {lastName}, {firstName} ({ntid}) {formattedDate} "",
                                                ""custom_field_ice_id"": ""{ntid}"",
                                                ""custom_field_email_address"": ""{email}"",
                                                ""custom_field_email_license"": ""{o365License}""
                                                }}", Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = jsonContent
            };
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {}
            else
                MessageBox.Show("Updating Custome Field in Mojo failed", "Mojo Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        static public async Task<RootObject> LoadTicket(string ticketNumber)
        {
            try
            {
                var apiKey = Functions.getAPIKey();
                string baseUrl = "https://mysupport.mojohelpdesk.com/api/tickets/";
                string url = $"{baseUrl}{ticketNumber}.json?access_key={apiKey}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                request.Headers.TryAddWithoutValidation("Accept", "application/xml");
                using (var response = await createUser.ApiClient.SendAsync(request))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
                    if (response.IsSuccessStatusCode)
                        return ro;
                    else
                        return null;
                }
            }
            catch { return null; }
        }
        public static string createEmailAddress(string firstname, string lastname, string extensionAttribute10)
        {
            string email;
            if (extensionAttribute10 == "Employee")
                email = firstname.ToLower() + "." + lastname.ToLower() + "@ineos.com";
            else if (extensionAttribute10 == "External")
                email = firstname.ToLower() + "." + lastname.ToLower() + "@external.ineos.com";
            else if (extensionAttribute10 == "Contractor")
                email = firstname.ToLower() + "." + lastname.ToLower() + "@external.ineos.com";
            else
                email = "";
            int count = 2;
            SearchResult result = null;
            do
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com", null, null, AuthenticationTypes.Secure | AuthenticationTypes.Sealing | AuthenticationTypes.Signing);
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(mail={0}))", email);
                searcher.SearchScope = SearchScope.Subtree;
                result = searcher.FindOne();
                if (result != null)
                {
                    string stringCount = count.ToString();
                    if (extensionAttribute10 == "Employee")
                        email = firstname.ToLower() + "." + lastname.ToLower() + stringCount + "@ineos.com";
                    else if (extensionAttribute10 == "External")
                        email = firstname.ToLower() + "." + lastname.ToLower() + stringCount + "@external.ineos.com";
                    else if (extensionAttribute10 == "Contractor")
                        email = firstname.ToLower() + "." + lastname.ToLower() + stringCount + "@external.ineos.com";
                    else
                        email = "";
                }
                count++;
            } while (result != null);
            return email;
        }
        public static string createNTID(string firstInitial, string middleInitial, string lastInitial)
        {
            string ntid;
            Random rnd = new Random();
            int num = rnd.Next(10000,100000);
            string ntidNum = num.ToString();
            ntid = firstInitial + middleInitial + lastInitial + ntidNum;
            ntid = ntid.ToLower();

            SearchResult result = null;
            do  //Create again if there is an existing same NTID
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com", null, null, AuthenticationTypes.Secure | AuthenticationTypes.Sealing | AuthenticationTypes.Signing);
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))", ntid);
                searcher.SearchScope = SearchScope.Subtree;
                result = searcher.FindOne();
                if (result != null)
                {
                    rnd = new Random();
                    num = rnd.Next(10000,100000);
                    ntidNum = num.ToString();
                    ntid = firstInitial + middleInitial + lastInitial + ntidNum;
                    ntid = ntid.ToLower();
                }
            } while (result != null);

            return ntid;
        }
        public static List<string> copyMembership(string[] disposeMemberships, bool displayYesNo, string sourceNTID, string destNTID)   //Return memberships that failed to copy
        {
            string[] adResult = Functions.GetAD(sourceNTID);
            sourceNTID = adResult[0];

            List<string> faildToCopyMemberships = new List<string>();
            if (displayYesNo == false)
                return faildToCopyMemberships;
            if (sourceNTID == "")
                return faildToCopyMemberships;

            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "in1.ad.innovene.com", "OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com");
            UserPrincipal sourceUser = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, sourceNTID);
            UserPrincipal destinationUser = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, destNTID);
            
            if (sourceUser != null && destinationUser != null)
            {
                var sourceGroups = sourceUser.GetGroups();
                var destinationGroups = destinationUser.GetGroups();
                foreach (Principal sourceGroup in sourceGroups)
                {
                    if (!destinationGroups.Contains(sourceGroup))                                           //Don't copy duplicated(Domain User is assigned as default)
                    {
                        GroupPrincipal destinationGroup = sourceGroup as GroupPrincipal;
                        destinationGroup.Members.Add(destinationUser);
                        for (int i = 0; i < disposeMemberships.Length; i++)                                 //Filter disposed Memberships
                            if (destinationGroup.Name == disposeMemberships[i])
                                destinationGroup.Members.Remove(destinationUser);
                        if (!(sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Users,OU=MVW,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=RoleGroups,OU=MVW,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Resources,OU=MVW,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=DataGroups,OU=MVW,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Users,OU=BMC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=RoleGroups,OU=BMC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Resources,OU=BMC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=DataGroups,OU=BMC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Users,OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=RoleGroups,OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Resources,OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=DataGroups,OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=NonStandard,OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Users,OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=RoleGroups,OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Resources,OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=DataGroups,OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=NonStandard,OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Users,OU=HDC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=RoleGroups,OU=HDC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=Resources,OU=HDC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com" ||
                              sourceGroup.DistinguishedName == "CN=" + sourceGroup.Name + "," + "OU=DataGroups,OU=HDC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com"))
                        {
                            {
                                faildToCopyMemberships.Add(destinationGroup.Name);
                                destinationGroup.Members.Remove(destinationUser);
                            }
                        }
                        destinationGroup.Save();
                    }
                }
            }
            return faildToCopyMemberships;
        }
        public static string[] disposeMemberships(string[] disposeMemberships, string addDispose)
        {
            Array.Resize(ref disposeMemberships, disposeMemberships.Length + 1);
            disposeMemberships[disposeMemberships.Length - 1] = addDispose;
            return disposeMemberships;
        }
        public static string[] removeMembership(string[] currentMemberships, string disposeMembership)
        {
            currentMemberships = currentMemberships.Where(w => w != disposeMembership).ToArray();
            return currentMemberships;
        }
        public static string[] displayMembership(string user, string[]disposeMemberships)
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "in1.ad.innovene.com", "OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com");
            UserPrincipal sourceUser = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, user);

            if (sourceUser != null)
            {
                var sourceGroups = sourceUser.GetGroups();
                string[] memberships;
                int membershipsSize = 0;
                foreach (Principal sourceGroup in sourceGroups)
                {
                    membershipsSize++;
                }
                memberships = new string[membershipsSize];

                int count = 0;
                foreach (Principal sourceGroup in sourceGroups)
                {
                    memberships[count] = sourceGroup.Name;
                    count++;

                    for (int i = 0; i < disposeMemberships.Length; i++)
                    {
                        if (disposeMemberships[i] == sourceGroup.Name)
                        {
                            memberships = memberships.Where(w => w != disposeMemberships[i]).ToArray();
                            count--;
                        }
                    }
                }
                return memberships;
            }
            else
                return null;
        }
        public static void resetPassword(string username)
        {
            DirectoryEntry account = new DirectoryEntry("LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com", null, null, AuthenticationTypes.Secure | AuthenticationTypes.Sealing | AuthenticationTypes.Signing);
            DirectorySearcher search = new DirectorySearcher(account);
            search.Filter = "(&(objectClass=user)(sAMAccountName=" + username + "))";
            account = search.FindOne().GetDirectoryEntry();

            account.Invoke("SetPassword", "Ineos2023");         //Update Password every year. Increment the year
            account.Properties["LockOutTime"].Value = 0;        //Unlock Account
            account.Properties["pwdLastSet"][0] = 0;            //Prompt User to Reset Password
            account.CommitChanges();
        }
        public static string[] GetAdmin(string username)
        {
            try
            {
                DirectoryEntry ldapConnection = new DirectoryEntry("");
                ldapConnection.Path = "LDAP://DC=in1,DC=ad,DC=innovene,DC=com";                     //For all Ineos sites Including Admin
                ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
                DirectorySearcher search = new DirectorySearcher(ldapConnection);

                search.Filter = "(|"                                                                //Multiple search options
                                   + "(sAMAccountName=" + username + ")"
                                   + "(mail=" + username + ")"
                                   + "(mail=" + username + "@ineos.com" + ")"
                                   + "(cn=" + username + ")"
                                   + ")";

                string[] requiredProperties = new string[] { "sAMAccountName",                                  //Name, mail, NTID, Site, Ofiice, Telephone, Job title
                                                        "extensionAttribute1",
                                                                         "cn",
                                                                       "mail",
                                                 "physicalDeliveryOfficeName",
                                                            "telephoneNumber",
                                                                      "title",
                                                         "userAccountControl",
                                                                    "ipPhone",
                                                        "extensionAttribute9",
                                                       "extensionAttribute10",
                                                       "extensionAttribute13",
                                                                "description",
                                                 "msExchHideFromAddressLists",
                                                                  "givenName",
                                                                         "sn"};

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();

                if (result != null)
                {
                    string[] searchResult = new string[requiredProperties.Length];
                    int lastIndex = -1;
                    foreach (string property in requiredProperties)
                    {
                        if (result.Properties.Contains(property))
                        {
                            searchResult[lastIndex + 1] = result.Properties[property][0].ToString();
                            lastIndex += 1;
                        }
                        else
                        {
                            searchResult[lastIndex + 1] = "";
                            lastIndex += 1;
                        }
                    }
                    return searchResult;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public static string[] GetAD(string username)
        {
            try
            {
                DirectoryEntry ldapConnection = new DirectoryEntry("");
                ldapConnection.Path = "LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";           //For all Ineos sites
                ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
                DirectorySearcher search = new DirectorySearcher(ldapConnection);

                search.Filter = "(|"                                                                //Multiple search options
                                   + "(sAMAccountName=" + username + ")"
                                   + "(mail=" + username + ")"
                                   + "(mail=" + username + "@ineos.com" + ")"
                                   + "(cn=" + username + ")"
                                   + ")";

                string[] requiredProperties = new string[] { "sAMAccountName",                      // AD Attributes
                                                        "extensionAttribute1",
                                                                         "cn",
                                                                       "mail",
                                                 "physicalDeliveryOfficeName",
                                                            "telephoneNumber",
                                                                      "title",
                                                         "userAccountControl",
                                                                    "ipPhone",
                                                        "extensionAttribute9",
                                                       "extensionAttribute10",
                                                       "extensionAttribute13",
                                                                "description",
                                                 "msExchHideFromAddressLists",
                                                                  "givenName",
                                                                         "sn"};

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();

                if (result != null)
                {
                    string[] searchResult = new string[requiredProperties.Length];
                    int lastIndex = -1;
                    foreach (string property in requiredProperties)
                    {
                        if (result.Properties.Contains(property))
                        {
                            searchResult[lastIndex + 1] = result.Properties[property][0].ToString();
                            lastIndex += 1;
                        }
                        else
                        {
                            searchResult[lastIndex + 1] = "";
                            lastIndex += 1;
                        }
                    }
                    return searchResult;
                }
                else
                    return null;
            }
            catch { return null; }
        }
        public static Tuple<string[], string[], string[]> queryAD(string site, string filter)
        {
            DirectoryEntry ldapConnection = new DirectoryEntry("");
            ldapConnection.Path = "LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com"; //Default All Sites
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            DirectorySearcher search = new DirectorySearcher(ldapConnection);
            var expiredTime = DateTime.Now.AddDays(-180).ToFileTime();                //Account expiration date 180days

            if (site.ToUpper() == "BMC")
                ldapConnection.Path = "LDAP://OU=BMC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "MVW")
                ldapConnection.Path = "LDAP://OU=MVW,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "CHO")
                ldapConnection.Path = "LDAP://OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "LAR")
                ldapConnection.Path = "LDAP://OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "HDC")
                ldapConnection.Path = "LDAP://OU=HDC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";

            if (filter == "Account Deactivated Users")
            {
                search.Filter = "(&"
                                    + "(userAccountControl=" + "514" + ")"
                                    + "(extensionAttribute2=" + "OP USA" + ")"
                                    + ")";
            }
            else if (filter == "Password Expired Users")
            {
                search.Filter = "(&"
                                    + "(pwdLastSet<=" + expiredTime + ")"
                                    + "(extensionAttribute2=" + "OP USA" + ")"
                                    + "(userAccountControl=" + "512" + ")"
                                    + ")";
            }
            else if (filter == "Account Locked Users")
            {
                search.Filter = "(&"
                                    + "(lockoutTime>=" + "1" + ")"
                                    + "(extensionAttribute2=" + "OP USA" + ")"
                                    + ")";
            }
            else if (filter == "Account Expired Users")
            {
                search.Filter = "(&"
                                   + "(accountExpires<=" + expiredTime + ")"
                                   + "(userAccountControl=" + "512" + ")"
                                   + "(extensionAttribute2=" + "OP USA" + ")"
                                   + "(!" + "(accountExpires=" + "0" + ")"
                                   + ")"
                                   + ")";
            }

            try
            {
                string[] requiredProperties = new string[] { "cn", "sAMAccountName", "mail" };      //Name, NTID, Email from AD Attributes

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResultCollection result = search.FindAll();

                string[] name;
                string[] ntid;
                string[] email;
                int size = 0;
                foreach (SearchResult userResults in result)
                {
                    size++;
                }
                name = new string[size];
                ntid = new string[size];
                email = new string[size];

                int count = 0;
                foreach (SearchResult userResults in result)
                {
                    if (!userResults.Properties.Contains("cn"))
                        name[count] = "";
                    else
                        name[count] = userResults.Properties["cn"][0].ToString();

                    if (!userResults.Properties.Contains("sAMAccountName"))
                        ntid[count] = "";
                    else
                        ntid[count] = userResults.Properties["sAMAccountName"][0].ToString();

                    if (!userResults.Properties.Contains("mail"))
                        email[count] = "";
                    else
                        email[count] = userResults.Properties["mail"][0].ToString();

                    count++;
                }
                return Tuple.Create(name, ntid, email);
            }
            catch
            {
                throw;
            }
        }
        public static int userCount(string site, string filter)
        {
            DirectoryEntry ldapConnection = new DirectoryEntry("");
            ldapConnection.Path = "LDAP://OU=Client,DC=in1,DC=ad,DC=innovene,DC=com"; //Default All Sites
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            DirectorySearcher search = new DirectorySearcher(ldapConnection);
            var expiredTime = DateTime.Now.AddDays(-180).ToFileTime();                //Account expiration date 180days

            if (site.ToUpper() == "BMC:")
                ldapConnection.Path = "LDAP://OU=BMC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "MVW:")
                ldapConnection.Path = "LDAP://OU=MVW,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "CHO:")
                ldapConnection.Path = "LDAP://OU=CHO,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "LAR:")
                ldapConnection.Path = "LDAP://OU=LAR,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";
            else if (site.ToUpper() == "HDC:")
                ldapConnection.Path = "LDAP://OU=HDC,OU=rAM,OU=Client,DC=in1,DC=ad,DC=innovene,DC=com";

            if (filter == "Account Deactivated Users")
            {
                search.Filter = "(&"
                                    + "(userAccountControl=" + "514" + ")"
                                    + "(extensionAttribute2=" + "OP USA" + ")"
                                    + ")";
            }
            else if (filter == "Password Expired Users")
            {
                search.Filter = "(&"
                                    + "(pwdLastSet<=" + expiredTime + ")"
                                    + "(extensionAttribute2=" + "OP USA" + ")"
                                    + "(userAccountControl=" + "512" + ")"
                                    + ")";
            }
            else if (filter == "Account Locked Users")
            {
                search.Filter = "(&"
                                    + "(lockoutTime>=" + "1" + ")"
                                    + "(extensionAttribute2=" + "OP USA" + ")"
                                    + ")";
            }
            else if (filter == "Account Expired Users")
            {
                search.Filter = "(&"
                                    + "(accountExpires<=" + expiredTime + ")"
                                    + "(userAccountControl=" + "512" + ")"
                                    + "(extensionAttribute2=" + "OP USA" + ")"
                                    + "(!" + "(accountExpires=" + "0" + ")"
                                    + ")"
                                    + ")";
            }

            try
            {
                SearchResultCollection result = search.FindAll();
                return result.Count;
            }
            catch
            {
                throw;
            }
        }
        public static void editRegistry(string hostname)
        {
            var inputRegistry = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, hostname);
            inputRegistry = inputRegistry.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\0001", true); //IPChecksumOffloadIPv4 location
            inputRegistry.SetValue("*IPChecksumOffloadIPv4", "0");
        }
        public static void startupChange(string hostname)
        {
            ManagementBaseObject inParam;
            ManagementBaseObject outParam;
            var serviceController = new ServiceController();
            ManagementObject obj = new ManagementObject(@"\\" + hostname + "\\root\\cimv2:Win32_Service.Name='RemoteRegistry'");
            try
            {
                if (obj["StartMode"].ToString() == "Disabled")
                {
                    inParam = obj.GetMethodParameters("ChangeStartMode");
                    inParam["StartMode"] = "Manual";
                    outParam = obj.InvokeMethod("ChangeStartMode", inParam, null);
                }
                else if (obj["StartMode"].ToString() == "Manual")
                {
                    inParam = obj.GetMethodParameters("ChangeStartMode");
                    inParam["StartMode"] = "Disabled";
                    outParam = obj.InvokeMethod("ChangeStartMode", inParam, null);
                }
            }
            catch
            {
                throw;
            }
        }
        public static void startStopService(string hostname)
        {
            try
            {
                string serviceName = "RemoteRegistry";

                ServiceController serviceController = new ServiceController("Remote Registry", hostname);
                ConnectionOptions connectoptions = new ConnectionOptions();
                ManagementScope scope = new ManagementScope("\\\\" + hostname + "\\root\\CIMV2");
                scope.Options = connectoptions;
                
                SelectQuery query = new SelectQuery("select * from Win32_Service where name = '" + serviceName + "'");          //WMI query to be executed on the remote machine  
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    foreach (ManagementObject service in collection.OfType<ManagementObject>())
                    {
                        if (service["started"].Equals(true))
                        {
                            service.InvokeMethod("StopService", null);
                            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                        }
                        else
                        {
                            service.InvokeMethod("StartService", null);
                            serviceController.WaitForStatus(ServiceControllerStatus.Running);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static string[] pingHostname(string hostname)
        {
            Ping myPing = new Ping();
            string[] pingResults = new string[2] { "", "" };
            string[] failedResult = new string[1] { "TimeOut" };
            try
            {
                PingReply reply = myPing.Send(hostname, 10000);

                if (reply.Status.ToString() == "Success")
                {
                    pingResults[0] = reply.Address.ToString();
                    pingResults[1] = reply.RoundtripTime.ToString();
                    return pingResults;     //Online PC
                }
                else
                    return null;            //Offline PC
            }
            catch
            {
                return failedResult;        //Invalid PC Name
            }
        }
        public static string[,] copyfiles(string newPc, string oldPc, string username, string item)
        {
            
            if (item == "Edge Bookmarks")
            {
                string[,] result = new string[2,3];                     //Edge Bookmark Transfer requires 3 files to copy over
                string[,] edge = copyPath(newPc, oldPc, username, item);
                
                for (int i = 0; i<3; i++)
                {
                    if(!(File.Exists(edge[0, i])))
                    {
                        Array.Clear(edge, i, 1);
                        result[0, i] = (i+1).ToString();                //Transfer fail will return a string number in a string array to indicate which file is failed to transfer
                    }
                    else
                        File.Copy(edge[0, i], edge[1, i], true);        //Transfer success will return a null to a string array
                }
                return result;
            }
            else
            {
                string[,] result = new string[2, 2];                    //Chrome Bookmark transfer requires 2 files to copy over
                string[,] chrome = copyPath(newPc, oldPc, username, item);
                for (int i = 0; i < 2; i++)
                {
                    if (!(File.Exists(chrome[0, i])))
                    {
                        Array.Clear(chrome, i, 1);
                        result[0, i] = (i+1).ToString();                //Transfer fail will return a string number in a string array to indicate which file is failed to transfer
                    }
                    else
                        File.Copy(chrome[0, i], chrome[1, i], true);    //Transfer success will return a null to a string array
                }
                return result;
            }
        }
        public static bool copyDirectory(string newPc, string oldPc, string username, string item)
        {
            if (item == "Quick Access")
            {
                string[,] quickAccess = copyPath(newPc, oldPc, username, item);
                var files = new DirectoryInfo(quickAccess[1, 0]).GetFiles("*.*");

                foreach (FileInfo file in files)
                    file.CopyTo(quickAccess[0, 0] + file.Name, true);

                return true;
            }
            else if (item == "Outlook Signatures")
            {
                string[,] outlookSignatures = copyPath(newPc, oldPc, username, item);

                if (!Directory.Exists(outlookSignatures[0, 0]))            //Copy directory has to overwrite the exsiting folder
                    Directory.CreateDirectory(outlookSignatures[0, 0]);    //If the directory is not existed then create one

                if (!Directory.Exists(outlookSignatures[1, 0]))
                    return false;
                else
                {
                    var files = new DirectoryInfo(outlookSignatures[1, 0]).GetFiles("*.*");
                    foreach (FileInfo file in files)
                        file.CopyTo(outlookSignatures[0, 0] + file.Name, true);

                    return true;
                }
            }
            else
                return false;
        }
        public static string[,] confirmPath(string newPc, string oldPc, string username)    //Only to confirm both paths(New and Old PCs) are existed
        {                                                                                   //If a user have not signed on both PC, then the paths won't be existed
            string[,] path = new string[2, 1]
            {
                { @"\\" + oldPc + @"\c$\users\" + username},
                { @"\\" + newPc + @"\c$\users\" + username}
            };
            return path;
        }
        public static string[,] copyPath(string newPc, string oldPc, string username, string item)
        {
            if (item == "Edge Bookmarks")
            {
                string[,] path = new string[2, 3]
                {
                    { @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks",
                        @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.bak",
                        @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.msbak" },
                    { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks",
                        @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.bak",
                        @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\microsoft\edge\user data\default\bookmarks.msbak" }
                };
                return path;
            }
            else if (item == "Chrome Bookmarks")
            {
                string[,] path = new string[2, 2]
                {
                    { @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks",
                        @"\\" + oldPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks.bak",},
                    { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks",
                        @"\\" + newPc + @"\c$\users\" + username + @"\appdata\local\google\chrome\user data\default\bookmarks.bak",}
                };
                return path;
            }
            else if (item == "Quick Access")
            {
                string[,] path = new string[2, 1]
                {
                    { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Windows\Recent\automaticDestinations\"},
                    {@"\\" + oldPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Windows\Recent\automaticDestinations"}
                };
                return path;
            }
            else if (item == "Outlook Signatures")
            {
                string[,] path = new string[2, 1]
                {
                    { @"\\" + newPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Signatures\"},
                    {@"\\" + oldPc + @"\c$\users\" + username + @"\appdata\roaming\microsoft\Signatures"}
                };
                return path;
            }
            else
                return null;
        }
    }
}