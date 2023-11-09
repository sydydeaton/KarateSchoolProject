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
                BindData(username);
            }
        }

        private string GetMemberName(string username)
        {
            
            var member = _dbManager.getUserMember(username);
            return member.MemberFirstName +" "+member.MemberLastName;
        }


        private void BindData(string username)
        {
            DataTable data = GetSectionData(username);

            if (data.Rows.Count > 0)
            {
                gvPayments.DataSource = data;
                gvPayments.DataBind();

                decimal sumSectionFee = CalculateTotalFeeSum(data, "SectionFee");

                lblTotalFee.Text = $"${sumSectionFee}";

            }

        }


        private decimal CalculateTotalFeeSum(DataTable dataTable, string columnName)
        {
            decimal sum = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row[columnName] != DBNull.Value)
                {
                    sum += Convert.ToDecimal(row[columnName]);
                }
            }

            return sum;
        }

        private DataTable GetSectionData(string username)
        {

            DataTable dataTable = _dbManager.GetSectionData(username,true);

            return dataTable;
        }
    }
}