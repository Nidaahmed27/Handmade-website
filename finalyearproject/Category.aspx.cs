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
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryRepeater();
            }
        }

        private void BindCategoryRepeater()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                string query = "select * from tblCategory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        RepeaterCategory.DataSource = dt;
                        RepeaterCategory.DataBind();
                    }
                }
            }
        }

        protected void BtnAddCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO tblCategory(CategoryName) VALUES( '" + TxtCategoryName.Text + "')";
                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();
                Response.Write("<script>alert('Category added successfully ');</script>");
                TxtCategoryName.Text = string.Empty;
                connection.Close();
                TxtCategoryName.Focus();
            }
            BindCategoryRepeater();
        }

        protected void BtnRemoveCategory_Click(object sender, EventArgs e)
        {
            Button btnRemoveCategory = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnRemoveCategory.NamingContainer;
            HiddenField CategoryIDHiddenField = (HiddenField)item.FindControl("HiddenFieldCategoryID");
            int CategoryID = Convert.ToInt32(CategoryIDHiddenField.Value);
            DeleteCategory(CategoryID);
            BindCategoryRepeater();
        }

        private void DeleteCategory(int CategoryID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();
                string deletesubCategoryQuery = "DELETE FROM tblSubCategory WHERE MainCategoryID = @CategoryID";
                SqlCommand deletesubCategoryCommand = new SqlCommand(deletesubCategoryQuery, connection);
                deletesubCategoryCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
                deletesubCategoryCommand.ExecuteNonQuery();

                string deleteCategoryQuery = "DELETE FROM tblCategory WHERE CategoryID = @CategoryID";
                SqlCommand deleteCategoryCommand = new SqlCommand(deleteCategoryQuery, connection);
                deleteCategoryCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
                deleteCategoryCommand.ExecuteNonQuery();

                
                connection.Close();

            }
        }
    }
    }
