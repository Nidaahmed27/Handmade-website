using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//namespace finalyearproject
//{
//    public partial class WebForm1 : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//         if (Isformvalid())
//            {
//                using (SqlConnection connection = new SqlConnection(ConfigurationManager .ConnectionStrings["NEW_USERS"].ConnectionString)
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand("INSERT INTO new_users(Full_name, username, email, password) VALUES('" + Fullname.Text + "','" + Username.Text + "','" + Email.Text + "','" + Password.Text + "')",connection);

//                command.ExecuteNonQuery();
//                Response.Write("<script>alert('registration succesfully done ');</script>");
//                connection.Close();
//                }
//            }

//        }

//        private bool Isformvalid()
//        {
//           if (Username.Text == "")
//            {
//                Response.Write("<script>alert('username not valid')</script>");
//                return false;
//            }

//           else if (Email.Text == "")
//            {
//                Response.Write("<script>alert('username not valid')</script>");
//                return false;
//            }

//            else if (Fullname.Text == "")
//            {
//                Response.Write("<script>alert('username not valid')</script>");
//                return false;
//            }

//            else if (Password.Text == "")
//            {
//                Response.Write("<script>alert('username not valid')</script>");
//                return false;
//            }

//            return true;

//        }
//    }
namespace finalyearproject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
             
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO new_users(Full_name, username, email, password) VALUES(@FullName, @Username, @Email, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@FullName", Fullname.Text);
                    command.Parameters.AddWithValue("@Username", Username.Text);
                    command.Parameters.AddWithValue("@Email", Email.Text);
                    command.Parameters.AddWithValue("@Password", Password.Text);

                    command.ExecuteNonQuery();
                    Response.Write("<script>alert('Registration successfully done');</script>");
                    Clr();
                    connection.Close();
                    Response.Redirect("~/default.aspx");
                }
            }
        }

        private bool IsFormValid()
        {
            if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Fullname.Text) || string.IsNullOrEmpty(Password.Text))
            {
                Response.Write("<script>alert('All fields are required.')</script>");
                return false;
            }


            return true;
        }

        private void Clr()
        {
            Username.Text = string.Empty;
            Fullname.Text = string.Empty;
            Password.Text = string.Empty;
            Email.Text = string.Empty;
        }
    }
}