using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoSubscription
{
    public class PlanApi : Api
    {
        public ResponsePlan Get(string code)
        {
            try
            {
                var request = new RestRequest("/plans/" + code + "/");
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<ResponsePlan>(request);
                var result = SimpleJson.DeserializeObject<ResponsePlan>(response.Content);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public class Addon
        {
            public string addon_code { get; set; }
            public string name { get; set; }
        }

        public class Plan
        {
            public string plan_code { get; set; }
            public string name { get; set; }
            public int recurring_price { get; set; }
            public int interval { get; set; }
            public string interval_unit { get; set; }
            public int billing_cycles { get; set; }
            public int trial_period { get; set; }
            public int setup_fee { get; set; }
            public List<Addon> addons { get; set; }
            public string product_id { get; set; }
            public string status { get; set; }
            public string created_time { get; set; }
            public string updated_time { get; set; }
        }

        public class ResponsePlan
        {
            public int code { get; set; }
            public string message { get; set; }
            public Plan plan { get; set; }
        }
    }
}
