using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchoolProject
{
    public partial class Member : System.Web.UI.Page
    {
        private DbManager _dbManager = new DbManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Login.aspx");
                }

                // Get the logged-in member's username.
                string username = User.Identity.Name;

                // Display the member's name.
                lblMemberName.Text = GetMemberName(username);

                // Load payment data into the GridView.
                LoadPaymentsData(username);
            }
        }

        private string GetMemberName(string username)
        {
            int  userId= (int)Session["userId"];
            var member = _dbManager.getUserMember(userId);
            return member.MemberFirstName +" "+member.MemberLastName;
        }


        private void LoadPaymentsData(string username)
        {
            DataTable paymentsDataTable = GetPaymentsData(username);

            if (paymentsDataTable.Rows.Count > 0)
            {
                gvPayments.DataSource = paymentsDataTable;
                gvPayments.DataBind();
            }
        }

        private DataTable GetPaymentsData(string username)
        {
            
            DataTable dataTable = new DataTable();
            return dataTable;
        }
    }
}