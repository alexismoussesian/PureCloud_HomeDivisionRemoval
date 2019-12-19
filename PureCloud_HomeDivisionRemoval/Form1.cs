using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace PureCloud_HomeDivisionRemoval
{
    public partial class MainForm : Form
    {
        Connection connection = null;
        UsersApi usersApi = null;
        AuthorizationApi authorizationApi = null;

        public MainForm()
        {
            InitializeComponent();
            AddLog("Initialisation");
            cmbEnvironment.SelectedIndex = 0;
            usersApi = new UsersApi();
            authorizationApi = new AuthorizationApi();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Log in the GUI
        /// </summary>
        /// <param name="message"></param>
        private void AddLog(string message)
        {
            lstLog.Items.Add($"{DateTime.Now} {message}");
            lstLog.SelectedIndex = lstLog.Items.Count - 1;
            lstLog.SelectedIndex = -1;
        }

        /// <summary>
        /// Connect on PureCloud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            connection = new Connection(lstLog, cmbEnvironment.SelectedItem.ToString(), txtClientId.Text, txtClientSecret.Text);
            var result = connection.Connect();
            AddLog("PureCloud connection activated: " + result);
            connection.GetOrg();
        }

        /// <summary>
        /// Disconnect from PureCloud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                var result = connection.Disconnect();
                AddLog("PureCloud connection activated: " + result);
            }
            catch (Exception ex)
            {
                AddLog($"Error in AddRows: {ex.Message} - Not connected");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Get the org name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnButton2_Click(object sender, EventArgs e)
        {
            connection.GetOrg();
        }

        /// <summary>
        /// Get the user id from the user name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetUserId(string name)
        {
            string id = "";

            try
            {
                UserSearchCriteria userSearchCriteria = new UserSearchCriteria();
                userSearchCriteria.Value = name;

                List<string> listOfString = new List<string>();
                listOfString.Add("name");
                userSearchCriteria.Fields = listOfString;
                userSearchCriteria.Type = UserSearchCriteria.TypeEnum.Exact;

                List<UserSearchCriteria> listOfUserSearchCriteria = new List<UserSearchCriteria>();
                listOfUserSearchCriteria.Add(userSearchCriteria);

                UserSearchRequest userSearchRequest = new UserSearchRequest();
                userSearchRequest.Query = listOfUserSearchCriteria;

                var userEntityListing = usersApi.PostUsersSearch(userSearchRequest);

                if (userEntityListing.Total.Value.Equals(0))
                    return "";

                foreach (var user in userEntityListing.Results)
                {
                    if (user.Name.Equals(name))
                    {
                        //AddLog("GetUserId: " + user.Id);
                        id = user.Id;
                    }
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in SetDefaultStation_fromCsv: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached for GetUserId, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");

                    var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                    AddLog($"resetTimeSeconds, {resetTimeSeconds}");
                    int.TryParse(ratelimitReset, out resetTimeSeconds);
                    if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong

                    AddLog($"Waiting {(resetTimeSeconds + 1)} seconds");
                    Thread.Sleep((resetTimeSeconds + 1) * 1000);

                    AddLog($"Re-calling method {nameof(GetUserId)}");
                    id = GetUserId(name);
                }
            }
            return id;
        }

        /// <summary>
        /// Delete Home division for the list of users by looping every roles
        /// </summary>
        /// <param name="ListOfUser"></param>
        /// <param name="homeDivisionId"></param>
        public void DeleteHomeDivision(List<string> ListOfUser, string homeDivisionId)
        {
            int total = 0;

            try
            {
                foreach (string user in ListOfUser)
                {
                    // récupérer le userid
                    var userId = GetUserId(user);

                    if (userId.Equals(""))
                    {
                        AddLog($"Error in DeleteHomeDivision: {user} does not exist");
                    }

                    // récupérer tous les roles du user
                    var userRoles = usersApi.GetUserRoles(userId);

                    foreach (var userRole in userRoles.Roles)
                    {
                        usersApi.DeleteAuthorizationSubjectDivisionRole(userId, homeDivisionId, userRole.Id);
                    }

                    AddLog($"DeleteHomeDivision succeed for user {user} #{total++}");
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in DeleteHomeDivision: {ex.Message}");
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");

                    var resetTimeSeconds = 60; // default value in case that header parsing will go wrong                
                    AddLog($"resetTimeSeconds, {resetTimeSeconds}");
                    int.TryParse(ratelimitReset, out resetTimeSeconds);
                    if (resetTimeSeconds > 60) throw new Exception("API rate limit reset > 60"); // if resetTimeSeconds is grather than 60 it means that something is wrong

                    AddLog($"Waiting {(resetTimeSeconds + 1)} seconds");
                    Thread.Sleep((resetTimeSeconds + 1) * 1000);

                    AddLog($"Re-calling method DeleteHomeDivision");
                    ListOfUser.RemoveRange(0, total);
                    DeleteHomeDivision(ListOfUser, homeDivisionId);
                }
            }
        }

        /// <summary>
        /// Get the division id from the division name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetDivisionId(string name)
        {
            string id = "";

            try
            {
                var pageNumber = 1;
                var pageSize = 25;

                var divisionEntityListing = authorizationApi.GetAuthorizationDivisions(pageSize, pageNumber, null, null, null, null, null, null, name);

                foreach (var div in divisionEntityListing.Entities)
                {
                    if (div.Name.Equals(name))
                    {
                        AddLog("GetDivisionId: " + div.Id);
                        id = div.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDivisionId: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }

        /// <summary>
        /// Launch the deletion of the home division
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string DeleteHomeDivision_FromCsv_withApiLimit(string filename)
        {
            var usersApi = new UsersApi();

            try
            {
                string[] lines = File.ReadAllLines(filename);
                var homeDivisionId = GetDivisionId("Home");
                List<string> ListOfUser = new List<string>();

                foreach (var user in lines)
                {
                    ListOfUser.Add(user);
                }

                DeleteHomeDivision(ListOfUser, homeDivisionId);

            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode != 429)
                {
                    AddLog($"Error in DeleteHomeDivision: {ex.Message}");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string ratelimitCount;
                    string ratelimitAllowed;
                    string ratelimitReset;
                    ex.Headers.TryGetValue("inin-ratelimit-count", out ratelimitCount);
                    ex.Headers.TryGetValue("inin-ratelimit-allowed", out ratelimitAllowed);
                    ex.Headers.TryGetValue("inin-ratelimit-reset", out ratelimitReset);
                    AddLog($"API rate limit has been reached, {nameof(ratelimitCount)}:{ratelimitCount}, {nameof(ratelimitAllowed)}:{ratelimitAllowed}, {nameof(ratelimitReset)}:{ratelimitReset}");
                }

            }

            return "";
        }

        /// <summary>
        /// Get the filename from the explorer and launch the deletion of the home division
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveHomeDivision_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DeleteHomeDivision_FromCsv_withApiLimit(dialog.FileName);
            }
        }


    }
}
