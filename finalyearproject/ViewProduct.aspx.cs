using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace finalyearproject
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductID"] != null)
            {
                if (!IsPostBack)
                {
                    BindViewProduct();
                    BindProductDetails();
                }
            }
            else
            {
                Response.Redirect("~/Products.aspx");
            }
        }



        private void BindProductDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;
            Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT A.*, B.* FROM tblproducts A JOIN tblbrands B ON A.ProductBrandID = B.BrandID WHERE A.ProductID ='" + ProductID + "'", connection))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        RepeaterProductDetails.DataSource = dt;
                        RepeaterProductDetails.DataBind();
                    }
                }
            }
        }

        private void BindViewProduct()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;
            Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("select * from tblProductsImages where ProductID='" + ProductID + "'", connection))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        RepeaterViewProduct.DataSource = dt;
                        RepeaterViewProduct.DataBind();
                    }
                }
            }
        }

        //protected void BtnAddToCart_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);
        //        if (Request.QueryString["ProductID"] != null)
        //        {


        //            string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                string query = "INSERT INTO tblCart (ProductID) VALUES (@ProductID)";

        //                using (SqlCommand command = new SqlCommand(query, connection))
        //                {
        //                    command.Parameters.AddWithValue("@ProductID", ProductID);

        //                    connection.Open();
        //                    command.ExecuteNonQuery();
        //                }
        //            }
        //        }
        //        else
        //        {

        //            Response.Write("<script>alert('ProductID not found in the query string');</script>");
        //        }
        //        Response.Redirect("~/ViewProduct.aspx?ProductID=" + ProductID);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions
        //        Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");

        //    }


        //}






        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {

                Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);

                string userEmail = Request.Cookies["UEMAIL"]?.Value;
                string userPassword = Request.Cookies["UPASSWORD"]?.Value;

                if (Request.QueryString["ProductID"] != null && !string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(userPassword))
                {   
                        int userID = int.Parse(Request.Cookies["UserID"].Value);
                        if (userID != -1)
                        {

                            InsertProductIntoCart(ProductID, userID);

                            UpdateCartDetails();



                            Response.Redirect("~/ViewProduct.aspx?ProductID=" + ProductID);
                        }
                        else
                        {

                            Response.Write("<script>alert('User not login.');</script>");
                        }
                    //}
                    //else
                    //{

                    //    Response.Write("<script>alert('Email or password not found in cookies.');</script>");
                    //}
                }
                else
                {

                    Response.Write("<script>alert('First you have to login');</script>");
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }


        }

        private void UpdateCartDetails()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update other product details
                    string updateProductDetailsQuery = @"
                UPDATE tblCart
                SET tblCart.ProductName = tblProducts.ProductName,
                    tblCart.ProductDetails = tblProducts.ProductDetails,
                    tblCart.ProductSellPrice = tblProducts.ProductSellPrice,
                    tblCart.ProductDescription = tblProducts.ProductDescription,
                    tblCart.ProductBrandID = tblProducts.ProductBrandID
                FROM tblProducts
                WHERE tblCart.ProductID = tblProducts.ProductID;
            ";

                    using (SqlCommand command = new SqlCommand(updateProductDetailsQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Update BrandName
                    string updateBrandNameQuery = @"
                UPDATE tblCart
                SET tblCart.BrandName = tblBrands.Name
                FROM tblBrands
                WHERE tblCart.ProductBrandID = tblBrands.BrandID;
            ";

                    using (SqlCommand command = new SqlCommand(updateBrandNameQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while updating cart details: " + ex.Message + "');</script>");
            }
        }




        //private int GetUserID()
        //{
        //    string userEmail = Request.Cookies["UEMAIL"]?.Value;
        //    string userPassword = Request.Cookies["UPASSWORD"]?.Value;
        //    int userID = -1;

        //    try
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string query = "SELECT uid FROM new_users WHERE email = @Email AND password = @Password";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@Email", userEmail);
        //                command.Parameters.AddWithValue("@Password", userPassword);

        //                connection.Open();
        //                object result = command.ExecuteScalar();

        //                if (result != null && result != DBNull.Value)
        //                {
        //                    userID = Convert.ToInt32(result);
        //                    HttpCookie userIDCookie = new HttpCookie("UserID");
        //                    userIDCookie.Value = userID.ToString();
        //                    Response.Cookies.Add(userIDCookie);
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


        private void InsertProductIntoCart(Int64 ProductID, int userID)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO tblCart (uid, ProductID) VALUES (@UserID, @ProductID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@ProductID", ProductID);



                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('An error occurred while inserting product into cart: " + ex.Message + "');</script>");
            }
        }


    }


}