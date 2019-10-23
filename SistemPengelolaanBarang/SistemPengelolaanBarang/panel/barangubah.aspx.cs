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
    public partial class ubahbarang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["username"] != "Administrator")
            {
                Response.Redirect("../index.aspx");
            }
        }

        protected void btnInput_Click(object sender, EventArgs e)
        {
            String param_brg = Request.QueryString["id"];
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update barang set nama=@Nama, keterangan = @Keterangan where id_brg=@id", con);
            cmd.Parameters.AddWithValue("Nama", txtNama.Text);
            cmd.Parameters.AddWithValue("Keterangan", txtKet.Text);
            cmd.Parameters.AddWithValue("id", param_brg);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script> alert('Pengubahan Data Berhasil');window.location='barang.aspx'; </script>");
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }
    }
}