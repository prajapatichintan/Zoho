using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoSubscription
{
    public class SubscriptionApi : Api
    {
        public SubscriptionResponse Get(string subscriptionid)
        {
            try
            {
                var request = new RestRequest("/subscriptions/" + subscriptionid + "/");
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<SubscriptionResponse>(request);
                var result = SimpleJson.DeserializeObject<SubscriptionResponse>(response.Content);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SubscriptionResponse Cancel(string subscriptionid, bool can_at_end)
        {
            try
            {
                var request = new RestRequest("/subscriptions/" + subscriptionid + "/cancel?cancel_at_end=" + can_at_end + "");
                request.Method = Method.POST;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<SubscriptionResponse>(request);
                var result = SimpleJson.DeserializeObject<SubscriptionResponse>(response.Content);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SubscriptionResponse Update(string subscriptionid, RequestSubscription RequestSubscription)
        {
            try
            {
                var request = new RestRequest("/subscriptions/" + subscriptionid + "/");
                request.Method = Method.PUT;
                request.RequestFormat = DataFormat.Json;
                request.AddBody(RequestSubscription);
                IRestResponse response = null;
                response = Execute<SubscriptionResponse>(request);
                var result = SimpleJson.DeserializeObject<SubscriptionResponse>(response.Content);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string UpdateCard(RequestUpdateCard RequestUpdateCard)
        {
            try
            {
                var request = new RestRequest("hostedpages/updatecard/");
                request.Method = Method.POST;
                request.RequestFormat = DataFormat.Json;
                request.AddBody(RequestUpdateCard);
                IRestResponse response = null;
                response = Execute<ResponseUpdateCard>(request);
                var result = SimpleJson.DeserializeObject<ResponseUpdateCard>(response.Content);
                return result.hostedpage.hostedpage_id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public class RequestUpdateCard
        {
            public string subscription_id { get; set; }
        }

        public class Hostedpage
        {
            public string hostedpage_id { get; set; }
            public string status { get; set; }
            public string url { get; set; }
            public string action { get; set; }
            public string expiring_time { get; set; }
            public string created_time { get; set; }
        }

        public class ResponseUpdateCard
        {
            public int code { get; set; }
            public string message { get; set; }
            public Hostedpage hostedpage { get; set; }
        }

        public SubscriptionResponse ReActivate(string subscriptionid)
        {
            try
            {
                var request = new RestRequest("/subscriptions/" + subscriptionid + "/reactivate/");
                request.Method = Method.POST;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<SubscriptionResponse>(request);
                var result = SimpleJson.DeserializeObject<SubscriptionResponse>(response.Content);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public class BillingAddress
        {
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
            public string country { get; set; }
        }

        public class Customer
        {
            public string customer_id { get; set; }
            public string display_name { get; set; }
            public string company_name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string fax { get; set; }
            public string currency_code { get; set; }
            public string currency_symbol { get; set; }
            public BillingAddress billing_address { get; set; }
            public string zcrm_account_id { get; set; }
            public string zcrm_contact_id { get; set; }
        }

        public class Contactperson
        {
            public string contactperson_id { get; set; }
            public string email { get; set; }
        }

        public class Plan
        {
            public string plan_code { get; set; }
        }

        public class RequestSubscription
        {
            public Plan plan { get; set; }
        }

        public class Addon
        {
            public string addon_code { get; set; }
            public string name { get; set; }
            public int price { get; set; }
            public int quantity { get; set; }
        }

        public class Coupon
        {
            public string coupon_code { get; set; }
            public string discount_amount { get; set; }
        }

        public class CustomField
        {
            public int index { get; set; }
            public string value { get; set; }
            public string label { get; set; }
        }

        public class Card
        {
            public string payment_gateway { get; set; }
            public string card_id { get; set; }
            public string last_four_digits { get; set; }
            public int expiry_month { get; set; }
            public int expiry_year { get; set; }
        }

        public class Note
        {
            public string note_id { get; set; }
            public string description { get; set; }
            public string commented_by { get; set; }
            public string commented_time { get; set; }
        }

        public class Subscription
        {
            public string subscription_id { get; set; }
            public string name { get; set; }
            public Customer customer { get; set; }
            public List<Contactperson> contactpersons { get; set; }
            public int amount { get; set; }
            public string product_id { get; set; }
            public Plan plan { get; set; }
            public List<Addon> addons { get; set; }
            public Coupon coupon { get; set; }
            public List<CustomField> custom_fields { get; set; }
            public string activated_at { get; set; }
            public string reference_id { get; set; }
            public string currency_code { get; set; }
            public string currency_symbol { get; set; }
            public int exchange_rate { get; set; }
            public string starts_at { get; set; }
            public string status { get; set; }
            public bool auto_collect { get; set; }
            public Card card { get; set; }
            public string child_invoice_id { get; set; }
            public string interval { get; set; }
            public string interval_unit { get; set; }
            public string current_term_starts_at { get; set; }
            public string current_term_ends_at { get; set; }
            public string expires_at { get; set; }
            public string last_billing_at { get; set; }
            public string next_billing_at { get; set; }
            public List<Note> notes { get; set; }
            public string created_time { get; set; }
            public string updated_time { get; set; }
        }

        public class SubscriptionResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public Subscription subscription { get; set; }
        }
    }
}
