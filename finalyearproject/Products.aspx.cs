using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace finalyearproject
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
             {
                BindRepeaterProduct();
             }
        }

        private void BindRepeaterProduct()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("BindAllProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        RepeaterProduct.DataSource = dt;
                        RepeaterProduct.DataBind();
                    }
                }
            }
        }
    }
}