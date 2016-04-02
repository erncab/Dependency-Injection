using System;
using System.ComponentModel.Composition;
using DI.MEF.WebForms.Services;

namespace DI.MEF.WebForms
{
    public partial class Customers : System.Web.UI.Page
    {
        [Import]
        ICustomerRepository _customerRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            grdCustomers.DataSource = _customerRepository.GetAll();
            grdCustomers.DataBind();
        }
    }
}