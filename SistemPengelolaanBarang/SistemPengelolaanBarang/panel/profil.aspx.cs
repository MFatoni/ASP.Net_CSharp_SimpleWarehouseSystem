using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemPengelolaanBarang.panel
{
	public partial class profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["username"] != "Administrator")
            {
                Response.Redirect("../index.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                String param_user = Request.QueryString["id"];
                SqlCommand command = new SqlCommand("Select * from users where email=@id", con);
                command.Parameters.AddWithValue("@id", param_user);
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nama.Text = String.Format("{0}", reader["nama"]);
                        email.Text = String.Format("{0}", reader["email"]);
                        telepon.Text = String.Format("{0}", reader["telepon"]);
                        alamat.Text = String.Format("{0}", reader["alamat"]);
                    }
                }
                con.Close();
            }
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }
    }
}