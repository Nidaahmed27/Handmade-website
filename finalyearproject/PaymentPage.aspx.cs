using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace finalyearproject
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        protected void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            DataTable cartItems = GetCartItems();
            if (cartItems != null && cartItems.Rows.Count > 0)
            {
                int orderId = InsertOrderItems(cartItems);
                if (orderId != -1)
                {
                    // Order successfully inserted
                    // Redirect to order details page or show a success message
                    
                    Response.Redirect("OrderDetails.aspx?orderId=" + orderId);
                }
                else
                {
                    // Handle the case where the order insertion failed
                    // Display an appropriate error message to the user
                    // For example: lblMessage.Text = "Failed to place the order. Please try again later.";
                }
               
            }
            else
            {
                // Handle the case where the cart is empty
                // Display a message to the user indicating that the cart is empty
                // For example: lblMessage.Text = "Your cart is empty. Please add items before placing an order.";
            }
            

        }

       

        private DataTable GetCartItems()
        {
            DataTable cartItems = new DataTable();

            try
            {
                int userID = int.Parse(Request.Cookies["UserID"].Value);

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
                {
                    connection.Open();
                    string query1 = "SELECT * FROM tblCart WHERE uid = @UserID";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command1);
                    adapter.Fill(cartItems);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                // For example: log the error, display an error message, etc.
                Response.Write("Error fetching cart items: " + ex.Message);
            }

            return cartItems;
        }


        private int InsertOrderItems(DataTable cartItems)
        {
            int orderId = -1;
            int userId = int.Parse(Request.Cookies["UserID"].Value);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
                {
                    connection.Open();

                    // Insert order details into the order table
                    string insertOrderQuery = "INSERT INTO tblOrders (UserID, UserName, UserEmail, MobileNumber, Address, Pincode) VALUES (@UserId, @UserName, @UserEmail, @MobileNumber, @Address, @Pincode); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertOrderCommand = new SqlCommand(insertOrderQuery, connection);
                    insertOrderCommand.Parameters.AddWithValue("@UserId", userId);
                    insertOrderCommand.Parameters.AddWithValue("@UserName", TxtName.Text);
                    insertOrderCommand.Parameters.AddWithValue("@UserEmail", TxtEmail.Text);
                    insertOrderCommand.Parameters.AddWithValue("@MobileNumber", TxtNumber.Text);
                    insertOrderCommand.Parameters.AddWithValue("@Address", TxtAddress.Text);
                    insertOrderCommand.Parameters.AddWithValue("@Pincode", TxtPincode.Text);
                    orderId = Convert.ToInt32(insertOrderCommand.ExecuteScalar());

                    // Insert cart items into the OrderItems table
                    foreach (DataRow row in cartItems.Rows)
                    {
                        string insertOrderItemQuery = "INSERT INTO OrderItems (OrderID, ProductID, ProductName, Price) VALUES (@OrderId, @ProductId, @ProductName, @Price)";
                        SqlCommand insertOrderItemCommand = new SqlCommand(insertOrderItemQuery, connection);
                        insertOrderItemCommand.Parameters.AddWithValue("@OrderId", orderId);
                        insertOrderItemCommand.Parameters.AddWithValue("@ProductId", Convert.ToInt32(row["ProductID"]));
                        insertOrderItemCommand.Parameters.AddWithValue("@ProductName", row["ProductName"].ToString());
                        insertOrderItemCommand.Parameters.AddWithValue("@Price", Convert.ToDecimal(row["ProductSellPrice"]));
                        insertOrderItemCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                // For example: lblMessage.Text = "Error: " + ex.Message;
                Response.Write("Error : " + ex.Message);
            }

            return orderId;
        }


    }
}
