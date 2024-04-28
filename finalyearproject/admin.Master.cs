using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using finalyearproject;

namespace finalyearproject
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateOrderCount();
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("~/login.aspx");
        }

        public void UpdateOrderCount()
        {
            int undeliveredCount = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM OrderItems WHERE OrderStatus = 'Not Delivered'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    undeliveredCount = (int)command.ExecuteScalar();
                }
            }

            // Display the order count somewhere on your page
            OrderCount.InnerText = undeliveredCount.ToString();
        }
    }
}