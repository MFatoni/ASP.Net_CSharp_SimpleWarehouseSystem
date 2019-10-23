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
	public partial class user : System.Web.UI.Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["username"] != "Administrator")
            {
                Response.Redirect("../index.aspx");
            } 
            else
            {
                tampilkanData();
                gvUser.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                gvUser.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }
        private void tampilkanData()
        {
            DataTable dt = this.getDataUser(0);
            gvUser.DataSource = dt;
            gvUser.DataBind();
        }

        private DataTable getDataUser(int id_brg1)
        {
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            koneksi.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = koneksi;
            if (id_brg1 == 0)
            {
                command.CommandText = "select * from users";
            }
            SqlDataReader reader = null;
            reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            koneksi.Close();
            return dt;
        }
        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string jenisCommand = e.CommandName;
            if (String.Compare(jenisCommand.ToUpper(), "profil", true) == 0)
            {
                string id = (e.CommandArgument.ToString());
                string url = "profil.aspx?id=" + id;
                Response.Redirect(url);
            }
        }
    }
}