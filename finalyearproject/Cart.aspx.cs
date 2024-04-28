using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace finalyearproject
{
    public partial class Cart : System.Web.UI.Page
    {
        protected HiddenField hiddenCartId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BindCartDetails();
                decimal cartTotal = CalculateCartTotal();
                LblCartTotal.Text += " $" + cartTotal.ToString("0.00");
            }

        }
        
        private void BindCartDetails()
        {
            
            string userEmail = Request.Cookies["UEMAIL"]?.Value;
            string userPassword = Request.Cookies["UPASSWORD"]?.Value;

            if (!string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(userPassword))
            {

                int userID =  int.Parse(Request.Cookies["UserID"].Value);


                if (userID != -1)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;


                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand("SELECT A.*, B.* FROM tblCart A CROSS APPLY (SELECT TOP 1 * FROM tblProductsImages B WHERE B.ProductID = A.ProductID) AS B WHERE A.uid = @userID ", connection))
                            {
                                command.Parameters.AddWithValue("@userID", userID);
                                command.CommandType = CommandType.Text;

                                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                                {
                                    DataTable dt = new DataTable();
                                    sda.Fill(dt);

                                    RepeaterCartItems.DataSource = dt;
                                    RepeaterCartItems.DataBind();
                                }
                            }
                        }

                    }


                    
                }
                else
                {

                    Response.Write("<script>alert('User not found.');</script>");
                }
                LblItemCount.Text = "You have " + RepeaterCartItems.Items.Count.ToString() + " items in your cart.";
                if (RepeaterCartItems.Items.Count == 0)
                {
                    BtnCheckout.Visible = false;
                }
                else
                {
                    BtnCheckout.Visible = true;
                }
            }
            else
            {

                Response.Write("<script>alert('Email or password not found in cookies.');</script>");
            }


        }
        //private int GetUserID(string email, string password)
        //{
        //    int userID = -1;

        //    try
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string query = "SELECT uid FROM new_users WHERE email = @Email AND password = @Password";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@Email", email);
        //                command.Parameters.AddWithValue("@Password", password);

        //                connection.Open();
        //                object result = command.ExecuteScalar();

        //                if (result != null && result != DBNull.Value)
        //                {
        //                    userID = Convert.ToInt32(result);
                            
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Response.Write("<script>alert('An error occurred while retrieving user ID: " + ex.Message + "');</script>");
        //    }

        //    return userID;
        //}

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            Button btnRemove = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnRemove.NamingContainer;
            HiddenField hiddenCartId = (HiddenField)item.FindControl("HiddenCartId");

            
            string cartId = hiddenCartId.Value;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM tblCart WHERE uid = @userID AND CartID = @cartId";

                    
                    string userEmail = Request.Cookies["UEMAIL"]?.Value;
                    string userPassword = Request.Cookies["UPASSWORD"]?.Value;
                    int userID = int.Parse(Request.Cookies["UserID"].Value);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@cartId", cartId);
                        command.ExecuteNonQuery();
                    }
                }

                
                BindCartDetails();
                User masterPage = Page.Master as User;

                if (masterPage != null)
                {
                    
                    masterPage.BindCartNumber();
                }
                decimal cartTotal = CalculateCartTotal();
                LblCartTotal.Text = "Rs " + cartTotal.ToString("0.00");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while removing the product from cart: " + ex.Message + "');</script>");
            }

        }

        private decimal CalculateCartTotal()
        {
            
            int userID = int.Parse(Request.Cookies["UserID"].Value);
            decimal cartTotal = 0;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
   
                    using (SqlCommand command = new SqlCommand("SELECT SUM(tblCart.ProductSellPrice) AS TotalPrice FROM tblCart  WHERE uid = @UserID", connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            cartTotal = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while calculating cart total: " + ex.Message + "');</script>");
            }

            return cartTotal;
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentPage.aspx");
        }
    }
}