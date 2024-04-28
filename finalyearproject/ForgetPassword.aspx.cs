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
    public partial class ForgetPassword : System.Web.UI.Page
    {

        protected void ResetPassword_Click(object sender, EventArgs e)

        {
            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string email = TextBoxEmail.Text.Trim();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM new_users WHERE Email = @Email", connection);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // User exists, redirect to password recovery page
                    Response.Redirect($"RecoverPassword.aspx?Email={email}");
                }
                else
                {
                    ResetPassMsg.Text = "Invalid email address.";
                }
            }
        }
    }
}
