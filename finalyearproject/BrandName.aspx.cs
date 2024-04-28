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
    public partial class BrandName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }

        private void BindBrandRepeater()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                string query = "select * from tblBrands";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        RepeaterBrand.DataSource = dt;
                        RepeaterBrand.DataBind();
                    }
                }
            }
        }

        protected void BtnAddBrand_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO tblBrands(Name) VALUES( '" + TxtBrandName.Text + "')";
                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();
                Response.Write("<script>alert('Brand added successfully ');</script>");
                TxtBrandName.Text = string.Empty;
                connection.Close();
                TxtBrandName.Focus();
            }
            BindBrandRepeater();
        }

        protected void BtnRemoveBrand_Click(object sender, EventArgs e)
        {
            Button btnRemoveBrand = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnRemoveBrand.NamingContainer;
            HiddenField brandIDHiddenField = (HiddenField)item.FindControl("HiddenFieldBrandID");
            int brandID = Convert.ToInt32(brandIDHiddenField.Value);
            DeleteBrand(brandID);
            BindBrandRepeater();
        }
        private void DeleteBrand(int brandID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NEW_USERS"].ConnectionString))
            {
                connection.Open();
                string deleteBrandQuery = "DELETE FROM tblBrands WHERE BrandID = @BrandID";
                SqlCommand deleteBrandCommand = new SqlCommand(deleteBrandQuery, connection);
                deleteBrandCommand.Parameters.AddWithValue("@BrandID", brandID);
                deleteBrandCommand.ExecuteNonQuery();
                connection.Close();
                
            }
        }
    }
}