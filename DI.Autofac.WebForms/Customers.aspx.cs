using System;
using System.Web.UI;
using DI.Autofac.WebForms.Services;

namespace DI.Autofac.WebForms
{
    public partial class Customers : Page
    {
        public ICustomerRepository _CustomerRepository { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            grdCustomers.DataSource = _CustomerRepository.GetAll();
            grdCustomers.DataBind();
        }
    }
}