using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace chandIT
{
    public partial class newsPa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure the page load logic only runs when the page is not being posted back
            if (!IsPostBack)
            {
                // Get the connection string from the configuration
                string connectionString = ConfigurationManager.ConnectionStrings["NewsConnectionString"].ConnectionString;

                // Create and open the SQL connection
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();

                        // Query to select titles
                        string articleId = Request.QueryString["x"];
                        if (!string.IsNullOrEmpty(articleId))
                        {
                            string selectQuery = "SELECT * FROM articles WHERE id = @ArticleId";

                            using (SqlCommand selectCmd = new SqlCommand(selectQuery, cn))
                            {
                                selectCmd.Parameters.AddWithValue("@ArticleId", articleId);

                                using (SqlDataReader dr = selectCmd.ExecuteReader())
                                {
                                    // Read the titles and append them to the string
                                    if (dr.Read())
                                    {
                                        art.InnerHtml += "<b>" + HttpUtility.HtmlEncode(dr["title"].ToString()) + "</b><br>";
                                        art.InnerHtml += HttpUtility.HtmlEncode(dr["details"].ToString()) + "<br>";
                                        art.InnerHtml += "<img src='images/" + HttpUtility.HtmlEncode(dr["photo"].ToString()) + "' height='200' width='200' /><br>";
                                    }
                                    else
                                    {
                                        art.InnerHtml = "Article not found.";
                                    }
                                }
                            }
                        }
                        else
                        {
                            art.InnerHtml = "No article ID provided.";
                        }

                        // Query to select comments
                        if (!string.IsNullOrEmpty(articleId))
                        {
                            string selectCommentsQuery = "SELECT * FROM comments WHERE id = @ArticleId";

                            using (SqlCommand selectCommentsCmd = new SqlCommand(selectCommentsQuery, cn))
                            {
                                selectCommentsCmd.Parameters.AddWithValue("@ArticleId", articleId);

                                using (SqlDataReader dr2 = selectCommentsCmd.ExecuteReader())
                                {
                                    while (dr2.Read())
                                    {
                                        comments.InnerHtml += "<b>" + HttpUtility.HtmlEncode(dr2["name"].ToString()) + ":</b> " + HttpUtility.HtmlEncode(dr2["comment"].ToString()) + "<br>";
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        art.InnerHtml = "An error occurred: " + ex.Message;
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Display the new comment immediately
            comments.InnerHtml += "<b>" + HttpUtility.HtmlEncode(txtName.Text) + ":</b> " + HttpUtility.HtmlEncode(txtComment.Text) + "<br>";

            string connectionString = ConfigurationManager.ConnectionStrings["NewsConnectionString"].ConnectionString;

            // Get the article ID from the query string
            string articleId = Request.QueryString["x"];

            // Ensure the article ID is not null or empty
            if (!string.IsNullOrEmpty(articleId))
            {
                // Create and open the SQL connection
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();

                        string insertQuery = "INSERT INTO comments (name, comment, id) VALUES (@name, @comment, @id)";
                        using (SqlCommand cm = new SqlCommand(insertQuery, cn))
                        {
                            cm.Parameters.AddWithValue("@name", txtName.Text);
                            cm.Parameters.AddWithValue("@comment", txtComment.Text);
                            cm.Parameters.AddWithValue("@id", articleId);

                            cm.ExecuteNonQuery();
                        }

                        // Clear the text fields after successful insertion
                        txtName.Text = "";
                        txtComment.Text = "";
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        art.InnerHtml = "An error occurred: " + ex.Message;
                    }
                }
            }
            else
            {
                art.InnerHtml = "No article ID provided.";
            }
        }
    }
}