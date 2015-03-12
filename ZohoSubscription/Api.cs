using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace ZohoSubscription
{
    public class Api
    {
        public static string baseurl = "https://subscriptions.zoho.com/api/v1";
        string ErrorMessage = string.Empty;

        static Api()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }

        protected string authtoken = System.Configuration.ConfigurationSettings.AppSettings["SubscriptionToken"];
        protected string organizationId = System.Configuration.ConfigurationSettings.AppSettings["SubscriptionOrgID"];

        private void setHeaders(RestRequest request)
        {
            if (!string.IsNullOrEmpty(authtoken))
            {
                request.AddHeader("Authorization", "Zoho-authtoken " + authtoken);
                request.AddHeader("X-com-zoho-subscriptions-organizationid", organizationId);
            }
        }

        public IRestResponse<T> Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            Uri convertedUri = new Uri(baseurl);
            client.BaseUrl = convertedUri;
            setHeaders(request);//pass authentication token in header
            request.RequestFormat = DataFormat.Json; // Or DataFormat.Xml, if you prefer

            IRestResponse<T> response = client.Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                response = client.Execute<T>(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response;
                }
            }
            if (response.Content.Contains("errors"))
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            if (response.ErrorException != null)
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            return response;
        }

        public IRestResponse Execute(RestRequest request)
        {
            var client = new RestClient();
            Uri convertedUri = new Uri(baseurl);
            client.BaseUrl = convertedUri;
            setHeaders(request);//pass authentication token in header
            request.RequestFormat = DataFormat.Json; // Or DataFormat.Xml, if you prefer

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }
            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response;
                }
            }
            if (response.Content.Contains("errors"))
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            if (response.ErrorException != null)
            {
                ErrorMessage = response.Content;
                throw new ApplicationException(ErrorMessage, null);
            }
            return response;
        }
    }
}
