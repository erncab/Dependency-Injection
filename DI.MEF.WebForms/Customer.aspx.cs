using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using DI.MEF.WebForms.Models;
using DI.MEF.WebForms.Services;

namespace DI.MEF.WebForms
{
    public partial class Customer1 : System.Web.UI.Page
    {
        [Import]
        ICustomerRepository _customerRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            string value = Request.QueryString["id"];

            if (string.IsNullOrWhiteSpace(value))
                value = "1";

            detailsViewCustomer.DataSource = new List<Customer>() { _customerRepository.GetById(Convert.ToInt32(value)) };
            detailsViewCustomer.DataBind();
        }
    }
}