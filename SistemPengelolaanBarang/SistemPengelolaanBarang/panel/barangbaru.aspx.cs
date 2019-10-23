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
    public partial class barangbaru : System.Web.UI.Page
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into barang(nama, keterangan, jumlah) values (@Nama, @Keterangan, @Jumlah)", con);
            cmd.Parameters.AddWithValue("Nama", txtNama.Text);
            cmd.Parameters.AddWithValue("Keterangan", txtKet.Text);
            cmd.Parameters.AddWithValue("Jumlah", txtJumlah.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script> alert('Input Berhasil');window.location='barang.aspx'; </script>");
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }
    }
}