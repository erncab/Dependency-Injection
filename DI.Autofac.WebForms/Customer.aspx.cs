using System;
using System.Collections.Generic;
using System.Web.UI;
using DI.Autofac.WebForms.Models;
using DI.Autofac.WebForms.Services;

namespace DI.Autofac.WebForms
{
    public partial class Customer1 : Page
    {
        public ICustomerRepository _CustomerRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string value = Request.QueryString["id"];

            if (string.IsNullOrWhiteSpace(value))
                value = "1";

            detCustomer.DataSource = new List<Customer>() { _CustomerRepository.GetById(Convert.ToInt32(value)) };
            detCustomer.DataBind();
        }
    }
}