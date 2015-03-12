using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoSubscription
{
    public class CustomerApi : Api
    {
        public string Create(RequestContact model)
        {
            try
            {
                var request = new RestRequest("/customers/");
                request.Method = Method.POST;
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(model);
                IRestResponse response = null;
                response = Execute<ResponseContact>(request);
                var result = SimpleJson.DeserializeObject<ResponseContact>(response.Content);
                return result.customer.customer_id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Update(RequestContact model,string Id)
        {
            try
            {
                var request = new RestRequest("/customers/" + Id);
                request.Method = Method.PUT;
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(model);
                IRestResponse response = null;
                response = Execute<ResponseContact>(request);
                var result = SimpleJson.DeserializeObject<ResponseContact>(response.Content);
                return result.customer.customer_id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<Customer> GetCustomers()
        {
            try
            {
                var request = new RestRequest("/customers/");
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<ResponseCustomerList>(request);
                var result = SimpleJson.DeserializeObject<ResponseCustomerList>(response.Content);
                return result.customers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public bool CustomerExist(string Email)
        {
            try
            {
                var request = new RestRequest("/customers/");
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<ResponseCustomerList>(request);
                var result = SimpleJson.DeserializeObject<ResponseCustomerList>(response.Content);
                var existcustomer = result.customers.Where(s => s.email.Trim() == Email.Trim());
                bool Exist = false;
                if (existcustomer.Count() > 0)
                    Exist = true;
                return Exist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Customer GetCustomers(string Email)
        {
            try
            {
                var request = new RestRequest("/customers/");
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = null;
                response = Execute<ResponseCustomerList>(request);
                var result = SimpleJson.DeserializeObject<ResponseCustomerList>(response.Content);
                var existcustomer = result.customers.Where(s => s.email.Trim() == Email.Trim()).SingleOrDefault();
                return existcustomer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public class RequestContact
        {
            public string display_name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string mobile { get; set; }
            public string phone { get; set; }
            public string currency_code { get; set; }
            public string company_name { get; set; }
            public Address billing_address { get; set; }
            public Address shipping_address { get; set; }

        }

        public class Address
        {
            /// <summary>
            /// Gets or sets the street_address1.
            /// </summary>
            /// <value>The street_address1.</value>
            public string street { get; set; }
            /// <summary>
            /// Gets or sets the street_address2.
            /// </summary>
            /// <value>The street_address2.</value>
            public string city { get; set; }
            /// <summary>
            /// Gets or sets the city.
            /// </summary>
            /// <value>The city.</value>
            public string state { get; set; }
            /// <summary>
            /// Gets or sets the state.
            /// </summary>
            /// <value>The state.</value>
            public string zip { get; set; }
            /// <summary>
            /// Gets or sets the country.
            /// </summary>
            /// <value>The country.</value>
            public string country { get; set; }
        }

        public class ResponseContact
        {
            public int code { get; set; }
            public string message { get; set; }
            public Customer customer { get; set; }
        }

        public class Customer
        {
            public string display_name { get; set; }
            public string customer_id { get; set; }
            public string currency_code { get; set; }
            public string currency_symbol { get; set; }
            public string status { get; set; }
            public string company_name { get; set; }
            public double unused_credits { get; set; }
            public double balance { get; set; }
            public double outstanding { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string mobile { get; set; }
            public string created_time { get; set; }
            public string updated_time { get; set; }
        }

        public class PageContext
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public bool has_more_page { get; set; }
            public string report_name { get; set; }
            public string applied_filter { get; set; }
            public string sort_column { get; set; }
            public string sort_order { get; set; }
        }

        public class ResponseCustomerList
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<Customer> customers { get; set; }
            public PageContext page_context { get; set; }
        }
    }
}
