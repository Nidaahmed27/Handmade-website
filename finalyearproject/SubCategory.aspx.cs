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
    public partial class SubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategory();
                BindSubCategoryRepeater();
            }
        }

        private void BindSubCategoryRepeater()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                string query = "select A.*,B.* from tblSubCategory A inner join tblCategory B on B.CategoryID = A.MainCategoryID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                                                                RepeaterSubCategory.DataSource = dt;
                                                                 RepeaterSubCategory.DataBind();
                    }
                }
            }
        }

        protected void BtnAddSubCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO tblSubCategory(SubCategoryName, MainCategoryID) VALUES(@SubCategoryName, @MainCategoryID)";
                SqlCommand command = new SqlCommand(query, connection);

                // Use parameters to prevent SQL injection
                command.Parameters.AddWithValue("@SubCategoryName", TxtSubCategoryName.Text);
                command.Parameters.AddWithValue("@MainCategoryID", DdlMainCategoryID.SelectedValue);

                command.ExecuteNonQuery();
                Response.Write("<script>alert('Sub Category added successfully ');</script>");
                TxtSubCategoryName.Text = string.Empty;
                connection.Close();
                DdlMainCategoryID.ClearSelection();
                DdlMainCategoryID.Items.FindByValue("0").Selected = true;

            }
            BindSubCategoryRepeater();
        }

        private void BindMainCategory()
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
                    DdlMainCategoryID.DataSource = dt;
                    DdlMainCategoryID.DataTextField = "CategoryName";
                    DdlMainCategoryID.DataValueField = "CategoryID";
                    DdlMainCategoryID.DataBind();
                    DdlMainCategoryID.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void BtnRemoveSubCategory_Click(object sender, EventArgs e)
        {
            Button btnRemoveSubCategory = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnRemoveSubCategory.NamingContainer;
            HiddenField SubCategoryIDHiddenField = (HiddenField)item.FindControl("HiddenFieldSubCategoryID");
            int SubCategoryID = Convert.ToInt32(SubCategoryIDHiddenField.Value);
            DeleteSubCategory(SubCategoryID);
            BindSubCategoryRepeater();
        }

        private void DeleteSubCategory(int SubCategoryID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();
                string deletesubCategoryQuery = "DELETE FROM tblSubCategory WHERE SubCategoryID = @SubCategoryID";
                SqlCommand deletesubCategoryCommand = new SqlCommand(deletesubCategoryQuery, connection);
                deletesubCategoryCommand.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                deletesubCategoryCommand.ExecuteNonQuery();
                connection.Close();

            }
        }




    }
}