using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZohoSubscription
{
    public class HostPageApi : Api
    {
        public string Create(RequestHostedPage model)
        {
            try
            {
                var request = new RestRequest("/hostedpages/newsubscription");
                request.Method = Method.POST;
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(model);
                IRestResponse response = null;
                response = Execute<RootObject>(request);
                var result = SimpleJson.DeserializeObject<RootObject>(response.Content);
                return result.hostedpage.hostedpage_id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public GetHostedPageResponse Get(string hostedpageid)
        {
            try
            {
                var request = new RestRequest("/hostedpages/" + hostedpageid + "/");
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<GetHostedPageResponse>(request);
                var result = SimpleJson.DeserializeObject<GetHostedPageResponse>(response.Content);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public class ShippingAddress
        {
            public string zip { get; set; }
            public string fax { get; set; }
            public string street { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string city { get; set; }
        }



        public class Customer
        {
            public ShippingAddress shipping_address { get; set; }
            public string first_name { get; set; }
            public string display_name { get; set; }
            public int payment_terms { get; set; }
            public string payment_terms_label { get; set; }
            public string email { get; set; }
            public string company_name { get; set; }
            public string zcrm_contact_id { get; set; }
            public string last_name { get; set; }
            public string zcrm_account_id { get; set; }
            public string customer_id { get; set; }
            public BillingAddress billing_address { get; set; }
        }


        public class Contactperson
        {
            public string email { get; set; }
            public string zcrm_contact_id { get; set; }
            public string contactperson_id { get; set; }
        }

        public class Plan
        {
            public string tax_name { get; set; }
            public int setup_fee { get; set; }
            public int price { get; set; }
            public string tax_type { get; set; }
            public string name { get; set; }
            public string tax_id { get; set; }
            public int quantity { get; set; }
            public string tax_percentage { get; set; }
            public string plan_code { get; set; }
        }



        //public class Data
        //{
        //    public Subscription subscription { get; set; }
        //    public string invoice { get; set; }
        //}


        public class Hostedpage
        {
            public string hostedpage_id { get; set; }
            public string status { get; set; }
            public string url { get; set; }
            public string action { get; set; }
            public string expiring_time { get; set; }
            public string created_time { get; set; }
        }

        public class RootObject
        {
            public int code { get; set; }
            public string message { get; set; }
            public Hostedpage hostedpage { get; set; }
        }

        public class plan
        {
            public string plan_code { get; set; }
            public int price { get; set; }
            public int quantity { get; set; }
            public int billing_cycles { get; set; }
        }

        public class contactpersons
        {
            public string contactperson_id { get; set; }
        }

        public class addons
        {
            public string addon_code { get; set; }
            public int price { get; set; }
            public int quantity { get; set; }
        }

        public class custom_fields
        {
            public int index { get; set; }
            public string value { get; set; }
        }

        public class RequestHostedPage
        {
            public string customer_id { get; set; }
            //public List<contactpersons> contactpersons { get; set; }
            public plan plan { get; set; }
            //public addons addons { get; set; }
            //public List<custom_fields> custom_fields { get; set; }
            //public string starts_at { get; set; }
            //public string coupon_code { get; set; }
            //public string reference_id { get; set; }
            //public string redirect_url { get; set; }
            //public string additional_param { get; set; }
        }

        public class BillingAddress
        {
            public string zip { get; set; }
            public string fax { get; set; }
            public string street { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string city { get; set; }
        }



        public class Card
        {
            public string payment_gateway { get; set; }
            public int expiry_year { get; set; }
            public string card_id { get; set; }
            public string last_four_digits { get; set; }
            public int expiry_month { get; set; }
        }


        public class Subscription
        {
            public int trial_remaining_days { get; set; }
            public string subscription_id { get; set; }
            public int payment_terms { get; set; }
            public int interval { get; set; }
            public string product_id { get; set; }
            public string payment_terms_label { get; set; }
            public string next_billing_at { get; set; }
            public string product_name { get; set; }
            public string current_term_starts_at { get; set; }
            public Customer customer { get; set; }
            public string interval_unit { get; set; }
            public string updated_time { get; set; }
            public string current_term_ends_at { get; set; }
            public int amount { get; set; }
            public string salesperson_name { get; set; }
            public string name { get; set; }
            public string trial_ends_at { get; set; }
            public string reference_id { get; set; }
            public Card card { get; set; }
            public string salesperson_id { get; set; }
            public string currency_symbol { get; set; }
            public string activated_at { get; set; }
            public string currency_code { get; set; }
            public List<object> custom_fields { get; set; }
            public string status { get; set; }
            public List<object> addons { get; set; }
            public string trial_starts_at { get; set; }
            public List<Contactperson> contactpersons { get; set; }
            public string expires_at { get; set; }
            public Plan plan { get; set; }
            public string created_time { get; set; }
            public List<object> taxes { get; set; }
            public bool auto_collect { get; set; }
        }
        public class InvoiceItem
        {
            public int price { get; set; }
            public string description { get; set; }
            public string item_id { get; set; }
            public string name { get; set; }
            public string tax_id { get; set; }
            public int quantity { get; set; }
            public string code { get; set; }
            public int discount_amount { get; set; }
            public int item_total { get; set; }
        }

        public class Payment
        {
            public int amount { get; set; }
            public string reference_number { get; set; }
            public int exchange_rate { get; set; }
            public string gateway_transaction_id { get; set; }
            public string invoice_payment_id { get; set; }
            public string description { get; set; }
            public string payment_mode { get; set; }
            public string payment_id { get; set; }
            public string date { get; set; }
        }

        public class Invoice
        {
            public int total { get; set; }
            public List<InvoiceItem> invoice_items { get; set; }
            public string transaction_type { get; set; }
            public string invoice_date { get; set; }
            public string updated_time { get; set; }
            public List<object> coupons { get; set; }
            public int balance { get; set; }
            public string salesperson_name { get; set; }
            public int credits_applied { get; set; }
            public int write_off_amount { get; set; }
            public string currency_symbol { get; set; }
            public string salesperson_id { get; set; }
            public string currency_code { get; set; }
            public List<object> custom_fields { get; set; }
            public string status { get; set; }
            public string customer_name { get; set; }
            public string number { get; set; }
            public string invoice_url { get; set; }
            public string email { get; set; }
            public List<Payment> payments { get; set; }
            public string due_date { get; set; }
            public string invoice_id { get; set; }
            public int payment_made { get; set; }
            public string created_time { get; set; }
            public string customer_id { get; set; }
        }

        public class Data
        {
            public Subscription subscription { get; set; }
            public Invoice invoice { get; set; }
        }

        public class GetHostedPageResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public string hostedpage_id { get; set; }
            public string status { get; set; }
            public string url { get; set; }
            public string action { get; set; }
            public List<object> custom_fields { get; set; }
            public string expiring_time { get; set; }
            public string created_time { get; set; }
            public Data data { get; set; }
        }
    }
}
