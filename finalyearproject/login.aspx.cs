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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.Cookies["UEMAIL"]!=null && Request.Cookies["UPASSWORD"]!=null)
                {
                    Email.Text = Request.Cookies["UEMAIL"].Value;
                    Password.Text = Request.Cookies["UPASSWORD"].Value;
                    CheckBox1.Checked = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();

                string query = "select * from new_users where Email = @Email and Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Email", Email.Text);
                command.Parameters.AddWithValue("@Password", Password.Text);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                if (dt.Rows.Count != 0)
                {
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["UEMAIL"].Value = Email.Text;
                        Response.Cookies["UPASSWORD"].Value = Password.Text;
                        

                        Response.Cookies["UEMAIL"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["UPASSWORD"].Expires = DateTime.Now.AddDays(30);


                    }

                    else
                    {
                        Response.Cookies["UEMAIL"].Value = Email.Text;
                        Response.Cookies["UPASSWORD"].Value = Password.Text;

                        Response.Cookies["UEMAIL"].Expires = DateTime.Now.AddDays(1);
                        Response.Cookies["UPASSWORD"].Expires = DateTime.Now.AddDays(1);
               
                    }

                    string Utype;
                    Utype = dt.Rows[0][5].ToString().Trim();
                    GetUserID();
                    if (Utype == "user")
                    {
                        Session["Email"] = Email.Text;
                        Response.Redirect("~/default.aspx");
                    }

                    if (Utype == "admin")
                    {
                        Session["Email"] = Email.Text;
                        Response.Redirect("~/AddProduct.aspx");
                    }
                    Response.Write("<script>alert('login successfully');</script>");
                }
                else
                {
                    error.Text = "invalid email or password";
                }
                
                 
                Clr();
                connection.Close();
            }
        }
        private void Clr()
        {
            Password.Text = string.Empty;
            Email.Text = string.Empty;
            Email.Focus();

        }
        private int GetUserID()
        {
            string userEmail = Request.Cookies["UEMAIL"]?.Value;
            string userPassword = Request.Cookies["UPASSWORD"]?.Value;
            int userID = -1;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT uid FROM new_users WHERE email = @Email AND password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmail);
                        command.Parameters.AddWithValue("@Password", userPassword);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            userID = Convert.ToInt32(result);
                            HttpCookie userIDCookie = new HttpCookie("UserID");
                            userIDCookie.Value = userID.ToString();
                            userIDCookie.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(userIDCookie);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('An error occurred while retrieving user ID: " + ex.Message + "');</script>");
            }

            return userID;
        }

    }
}