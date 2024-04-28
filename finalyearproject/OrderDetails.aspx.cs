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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = int.Parse(Request.Cookies["UserID"].Value);
                BindOrderDetails(userID);
                RemoveProductsFromCart();
            }
        }

        private void BindOrderDetails(int UserID)
        {
            try
            { 
                string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    string query = "SELECT A.OrderID, B.ProductID, B.Price, C.ProductName, C.ProductDetails, D.Name, D.Extension FROM tblOrders A JOIN OrderItems B ON A.OrderID = B.OrderID JOIN tblProducts C ON B.ProductID = C.ProductID CROSS APPLY(SELECT TOP 1 * FROM tblProductsImages WHERE ProductID = C.ProductID ORDER BY ProductImgID ASC) AS D WHERE A.UserID = @UserID AND A.OrderID = (SELECT TOP 1 OrderID FROM tblOrders WHERE UserID = @UserID  ORDER BY OrderID DESC)";



                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@UserID", UserID);

                        
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                           
                            DataTable dt = new DataTable();

                            
                            adapter.Fill(dt);
                            string orderId = dt.Rows[0]["OrderID"].ToString();

                            // Set the text of the label to the Order ID
                            LabelOrderID.Text = "Order ID: " + orderId;

                            if (dt.Rows.Count > 0)
                            {
                                repeaterOrders.DataSource = dt;
                                repeaterOrders.DataBind();

                                
                            }
                            else
                            {
                                Response.Write("order id not available");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions, such as displaying an error message or logging the exception
                Response.Write("Error fetching order details: " + ex.Message);
            }
        }
        private void RemoveProductsFromCart()
        {
            int userID = int.Parse(Request.Cookies["UserID"].Value);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM tblCart WHERE uid = @UserID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.ExecuteNonQuery();


            }
        }

    }
}