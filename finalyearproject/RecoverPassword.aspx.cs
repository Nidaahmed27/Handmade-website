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
    public partial class RecoverPassword : System.Web.UI.Page
    {

        protected void Button1_Click(object sender, EventArgs e)

        {
            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string email = Request.QueryString["Email"];
                string newPassword = txtNewPassword.Text.Trim();
                string confirmNewPassword = txtConfirmPassword.Text.Trim();

                if (newPassword == confirmNewPassword)
                {
                    // Update the password in the database
                    SqlCommand cmd = new SqlCommand("UPDATE new_users SET Password = @Password WHERE Email = @Email", connection);
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Password updated successfully.";
                    }
                    else
                    {
                        lblMessage.Text = "Failed to update password.";
                    }
                }
                else
                {
                    lblMessage.Text = "Passwords do not match.";
                }
            }
        }
    }
}