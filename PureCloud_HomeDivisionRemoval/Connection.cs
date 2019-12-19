using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Extensions;
using System;
using System.Windows.Forms;

namespace PureCloud_HomeDivisionRemoval
{
    public class Connection
    {
        private string environment;
        private string clientid;
        private string clientsecret;
        bool loggedIn = false;
        private ListBox _lstLog;

        public Connection(ListBox lstLog)
        {
            _lstLog = lstLog;
        }

        public Connection(ListBox lstLog, string env, string id, string secret)
        {
            _lstLog = lstLog;
            environment = env;
            clientid = id;
            clientsecret = secret;

        }


        public Boolean Connect()
        {
            try
            {
                // Connect to PureCloud
                Configuration.Default.ApiClient.RestClient.BaseUrl = new Uri(@"https://api." + environment);
                var accessTokenInfo = Configuration.Default.ApiClient.PostToken(clientid, clientsecret);
                Configuration.Default.AccessToken = accessTokenInfo.AccessToken;
                loggedIn = true;
                AddLog($"Access Token: {accessTokenInfo.AccessToken}");

            }
            catch (Exception ex)
            {
                loggedIn = false;
                AddLog($"Error in btnConnect_Click: {ex.Message}");
            }

            return loggedIn;
        }


        public Boolean Disconnect()
        {
            if (loggedIn)
            {
                var tokensApi = new TokensApi();
                tokensApi.DeleteTokensMe();
                loggedIn = false;
            }

            return false;
        }

        public void GetOrg()
        {
            try
            {
                var api = new OrganizationApi();
                var org = api.GetOrganizationsMe();

                AddLog("Organization Id:       " + org.Id);
                AddLog("Organization Name:     " + org.Name);
                AddLog("Organization Domain:   " + org.Domain);
            }
            catch (Exception ex)
            {
                AddLog("Exception " + ex.Message);
            }
        }


        private void AddLog(string message)
        {
            _lstLog.Items.Add($"{DateTime.Now} {message}");
            _lstLog.SelectedIndex = _lstLog.Items.Count - 1;
            _lstLog.SelectedIndex = -1;
        }
    }
}
