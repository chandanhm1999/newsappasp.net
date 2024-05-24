using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chandIT
{
    public partial class Articles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NewsConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "insert into articles(title,details,photo) values (@title,@details,@photo)";
                SqlCommand cm = new SqlCommand(query, cn);

                // Add parameters to prevent SQL injection
                cm.Parameters.AddWithValue("@title", txtTitle.Text);
                cm.Parameters.AddWithValue("@details", txtDet.Text);

                string strImg = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                cm.Parameters.AddWithValue("@photo", strImg);

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

                // Save the uploaded file to the server
                File1.PostedFile.SaveAs(Server.MapPath("images\\") + strImg);

                // Notify the user of success
                Response.Write("Article added successfully");
            }
        }
    }
}