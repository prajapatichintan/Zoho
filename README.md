# Zoho-Subscriptions-API-wrapper
A .net Wrapper over Zoho Subscriptions API for Authentication,create subscriptions, plans, hosted pages, customers. 


Following is sample code in asp.net MVC Controller 

                        // Create new customer in zoho subscriptions
                        CustomerApi objcontact = new CustomerApi();
                        CustomerApi.RequestContact contact = new CustomerApi.RequestContact();
                        contact.first_name = details.FirstName;
                        contact.last_name = details.LastName;
                        contact.email = Email;
                        contact.display_name = details.FirstName + " " + details.LastName;
                        contact.mobile = details.Mobile;
                        contact.currency_code = System.Configuration.ConfigurationManager.AppSettings["SubscriptionCurrency"];
                        
                        if (orgdetails != null)
                        {
                            contact.company_name = orgdetails.CompanyName;
                            if (!string.IsNullOrEmpty(orgdetails.Mobile))
                            {
                                contact.phone = orgdetails.Mobile;
                            }
                            if (details != null)
                            {
                                contact.mobile = details.Mobile;
                            }
                        }
                        CustomerApi.Address objshippingAddress = new CustomerApi.Address();
                        if (!string.IsNullOrEmpty(orgdetails.Country))
                        {

                            if (!string.IsNullOrEmpty(orgdetails.Street))
                            {
                                objshippingAddress.street = orgdetails.Street;
                            }
                            if (!string.IsNullOrEmpty(orgdetails.City))
                            {
                                objshippingAddress.city = orgdetails.City;
                            }

                            if (!string.IsNullOrEmpty(orgdetails.ZipCode))
                                objshippingAddress.zip = orgdetails.ZipCode;

                            if (!string.IsNullOrEmpty(orgdetails.State))
                                objshippingAddress.state = orgdetails.State;

                            if (!string.IsNullOrEmpty(orgdetails.Country))
                                objshippingAddress.country = orgdetails.Country;


                        }
                        contact.billing_address = objshippingAddress;
                        contact.shipping_address = objshippingAddress;
                       
                        CustomerApi.Address objBillingAddress = new CustomerApi.Address();
                        
                        contactId = objcontact.Create(contact);


Update Credit card details

        public ActionResult UpdateCard(string id)
        {
            try
            {
                var session = this.Session["SessionInfo"] as UserProfileSessionData;
                if (session != null)
                {
                    SubscriptionApi.RequestUpdateCard card = new SubscriptionApi.RequestUpdateCard();
                    card.subscription_id = id;
                    string hostedpageId = objsubcription.UpdateCard(card);
                    string FrameURL = "https://subscriptions.zoho.com/hostedpage/" + hostedpageId + "/checkout";
                    return RedirectToAction("CardUpdate", "Plan", new { PlanId = FrameURL });
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                ShowMessageViewBag(ex.Message.ToString(), "danger");
                return View("Index");
            }
        }
        
        Currenlty API contains code for most common API calls, other calls needs to be completed. 
        Feel free to make pull request and commit changes after modifications. 
        
    
