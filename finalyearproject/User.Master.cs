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
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userEmail = Request.Cookies["UEMAIL"]?.Value;
            string userPassword = Request.Cookies["UPASSWORD"]?.Value;
            if (!IsPostBack)
            {

                BindCartNumber();
            }
            if (!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(userPassword))
            {
                BtnLogin.Visible = false;
                BtnLogin.Enabled = false;
                BtnLogout.Visible = true;
                BtnLogout.Enabled = true;

            }
            else
            {

                BtnLogin.Visible = true;
                BtnLogin.Enabled = true;
                BtnLogout.Visible = false;
                BtnLogout.Enabled = false;
            }

            if (Request.Cookies["UEMAIL"]?.Value == "nidaahmed408@gmail.com")
            {
                Response.Redirect("~/AddProduct.aspx");
            }
        }

      
        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            BtnLogin.Visible = true;
            BtnLogin.Enabled = true;
            BtnLogout.Visible = false;
            BtnLogout.Enabled = false;
            Response.Cookies["UEMAIL"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UPASSWORD"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/login.aspx");

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
            BtnLogin.Visible = false;
            BtnLogin.Enabled = false;
            BtnLogout.Visible = true;
            BtnLogout.Enabled = true;
        }
        //public void BindCartNumber()
        //{
        //    try
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string query = "SELECT COUNT(*) FROM tblCart";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                connection.Open();
        //                object result = command.ExecuteScalar();

        //                if (result != null && result != DBNull.Value)
        //                {
        //                    int cartCount;
        //                    if (int.TryParse(result.ToString(), out cartCount))
        //                    {
        //                        PCount.InnerText = cartCount.ToString();
        //                    }
        //                    else
        //                    {
        //                        // Unable to parse count, display 0
        //                        PCount.InnerText = "0";
        //                    }
        //                }
        //                else
        //                {
        //                    // No result, display 0
        //                    PCount.InnerText = "0";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions
        //        Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
        //    }
        //}


        public void BindCartNumber()
        {


            string userEmail = Request.Cookies["UEMAIL"]?.Value;
            string userPassword = Request.Cookies["UPASSWORD"]?.Value;

            if (!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(userPassword))
            {

                int userID = int.Parse(Request.Cookies["UserID"].Value);

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT COUNT(*) FROM tblCart WHERE uid = @UserID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", userID);

                            connection.Open();
                            object result = command.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                int cartCount;
                                if (int.TryParse(result.ToString(), out cartCount))
                                {
                                    PCount.InnerText = cartCount.ToString();
                                }
                                else
                                {
                                
                                    PCount.InnerText = "0";
                                }
                            }
                            else
                            {
                                
                                PCount.InnerText = "0";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
            }
            else
            {

                //Response.Write("<script>alert('Email or password not found in cookies.');</script>");
                //Response.Redirect("~/Products.aspx");
            }

        }
       

    }
}