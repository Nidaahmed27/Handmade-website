using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace finalyearproject
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrand();
                BindCategory();
                Ddlsubcategory.Enabled = false;
            }
        }


        private void BindCategory()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();

                string query = "select * from tblCategory";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    DdlCategory.DataSource = dt;
                    DdlCategory.DataTextField = "CategoryName";
                    DdlCategory.DataValueField = "CategoryID";
                    DdlCategory.DataBind();
                    DdlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
        private void BindBrand()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();

                string query = "select * from tblBrands";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    DdlBrand.DataSource = dt;
                    DdlBrand.DataTextField = "Name";
                    DdlBrand.DataValueField = "BrandID";
                    DdlBrand.DataBind();
                    DdlBrand.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ddlsubcategory.Enabled = true;

            int MainCategoryID = Convert.ToInt32(DdlCategory.SelectedItem.Value);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();


                SqlCommand command = new SqlCommand("select * from tblSubCategory where MainCategoryID = '" + MainCategoryID + "' ", connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    Ddlsubcategory.DataSource = dt;
                    Ddlsubcategory.DataTextField = "SubCategoryName";
                    Ddlsubcategory.DataValueField = "SubCategoryID";
                    Ddlsubcategory.DataBind();
                    Ddlsubcategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
               

                string query = "sp_InsertProduct";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductName", TxtProductName.Text);
                command.Parameters.AddWithValue("@ProductPrice", TxtPrice.Text);
                command.Parameters.AddWithValue("@ProductSellPrice", TxtSellPrice.Text);
                command.Parameters.AddWithValue("@ProductBrandID", DdlBrand.SelectedItem.Value);
                command.Parameters.AddWithValue("@ProductCategoryID", DdlCategory.SelectedItem.Value);
                command.Parameters.AddWithValue("@ProductSubCategoryID", Ddlsubcategory.SelectedItem.Value);
                command.Parameters.AddWithValue("@ProductDescription", TxtDescription.Text);
                command.Parameters.AddWithValue("@ProductDetails", TxtPdetail.Text);
                
                if (CheckReturnPolicy.Checked == true)
                {
                    command.Parameters.AddWithValue("@30DaysReturn", 1.ToString());
                }
                else
                {
                    command.Parameters.AddWithValue("@30DaysReturn", 0.ToString());
                }
                if (CheckReturnPolicy.Checked == true)
                {
                    command.Parameters.AddWithValue("@CashOnDelivery", 1.ToString());
                }
                else
                {
                    command.Parameters.AddWithValue("@CashOnDelivery", 0.ToString());
                }

                connection.Open();
                Int64 ProductID = Convert.ToInt64(command.ExecuteScalar());
                int Quantity = Convert.ToInt32(TxtProductQuantity.Text);
                SqlCommand command2 = new SqlCommand("insert into ProductQuantity values('" + ProductID + "','" + Quantity + "')", connection);
                command2.ExecuteNonQuery();


                if (FileUploadImg1.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + ProductID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extension = Path.GetExtension(FileUploadImg1.PostedFile.FileName);
                    FileUploadImg1.SaveAs(SavePath + "\\" + TxtProductName.Text.ToString().Trim() + "01" + Extension);

                    SqlCommand command3 = new SqlCommand("insert into tblProductsImages values('" + ProductID + "','" + TxtProductName.Text.ToString().Trim() + "01" + "','" + Extension + "')", connection);
                    command3.ExecuteNonQuery();
                }

                if (FileUploadImg2.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + ProductID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extension = Path.GetExtension(FileUploadImg2.PostedFile.FileName); 
                    FileUploadImg2.SaveAs(SavePath + "\\" + TxtProductName.Text.ToString().Trim() + "02" + Extension); 

                    SqlCommand command4 = new SqlCommand("insert into tblProductsImages values('" + ProductID + "','" + TxtProductName.Text.ToString().Trim() + "02" + "','" + Extension + "')", connection);
                    command4.ExecuteNonQuery();
                }

                if (FileUploadImg3.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + ProductID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extension = Path.GetExtension(FileUploadImg3.PostedFile.FileName); 
                    FileUploadImg3.SaveAs(SavePath + "\\" + TxtProductName.Text.ToString().Trim() + "03" + Extension);

                    SqlCommand command5 = new SqlCommand("insert into tblProductsImages values('" + ProductID + "','" + TxtProductName.Text.ToString().Trim() + "03" + "','" + Extension + "')", connection);
                    command5.ExecuteNonQuery();
                }

                Response.Write("<script>alert('Product added successfully ');</script>");
                TxtProductName.Text = string.Empty;
                TxtPrice.Text = string.Empty;
                TxtPdetail.Text = string.Empty;
                TxtDescription.Text = string.Empty;
                TxtProductQuantity.Text = string.Empty;
                TxtSellPrice.Text = string.Empty;
                connection.Close();
                TxtProductName.Focus();



            }
        }
    }
}