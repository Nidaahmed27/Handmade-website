using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace finalyearproject
{
    public partial class RecievedOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeaterRecievedOrders();
            }

        }

        private void BindRepeaterRecievedOrders()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT A.*, B.OrderItemID, B.ProductID, B.ProductName, B.Price, B.OrderStatus FROM tblOrders A JOIN OrderItems B ON A.OrderID = B.OrderID WHERE  B.OrderStatus = 'Not Delivered'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        RepeaterRecievedOrders.DataSource = dt;
                        RepeaterRecievedOrders.DataBind();
                    }
                }
            }

        }

        protected void BtnOrderDeliverd_Click(object sender, EventArgs e)
        {
            Button btnOrderDelivered = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnOrderDelivered.NamingContainer;

            // Retrieve OrderID and OrderItemID from the current repeater item
            Literal orderIdLiteral = (Literal)item.FindControl("LiteralOrderID");
            Literal orderItemIdLiteral = (Literal)item.FindControl("LiteralOrderItemID");

            if (orderIdLiteral != null && orderItemIdLiteral != null)
            {
                int orderId;
                int orderItemId;

                if (int.TryParse(orderIdLiteral.Text, out orderId) && int.TryParse(orderItemIdLiteral.Text, out orderItemId))
                {
                    // Update order status to 'Delivered' in the database
                    string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE OrderItems SET OrderStatus = 'Delivered' WHERE OrderID = @OrderID AND OrderItemID = @OrderItemID";
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@OrderID", orderId);
                            command.Parameters.AddWithValue("@OrderItemID", orderItemId);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Rebind the repeater to reflect the changes
                    
                    BindRepeaterRecievedOrders();
                    admin masterPage = Page.Master as admin;

                    if (masterPage != null)
                    {

                        masterPage.UpdateOrderCount();
                    }
                    

                }
                else
                {
                    // Handle the case where OrderID or OrderItemID couldn't be parsed
                    Response.Write("<script>alert('Error: Unable to retrieve OrderID or OrderItemID.');</script>");
                }
            }
            else
            {
                // Handle the case where OrderID or OrderItemID controls couldn't be found
                Response.Write("<script>alert('Error: Unable to find OrderID or OrderItemID controls.');</script>");
            }
        }







    }
}