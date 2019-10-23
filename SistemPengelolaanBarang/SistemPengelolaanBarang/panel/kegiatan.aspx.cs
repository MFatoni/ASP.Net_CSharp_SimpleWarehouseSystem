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
    public partial class kegiatan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["username"] != "Administrator")
            {
                Response.Redirect("../index.aspx");
            }
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }

        protected void btnInput_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            String param_brg = Request.QueryString["id"];
            String user = "Administrator";
            String data = "";
            int jumlah1 = 0;
            int jumlah2 = 0;
            int jumlah_terbaru = 0;
            if (TextKeg.Text == "Pengambilan")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Select jumlah from barang where id_brg=@id", con);
                command.Parameters.AddWithValue("@id", param_brg);
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        data = String.Format("{0}", reader["jumlah"]);
                        jumlah1 = Int32.Parse(data);
                        jumlah2 = Int32.Parse(txtJumlah.Text);
                        jumlah_terbaru = jumlah1 - jumlah2;
                    }
                }
                con.Close();
            }
            if (TextKeg.Text == "Penambahan")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Select jumlah from barang where id_brg=@id", con);
                command.Parameters.AddWithValue("@id", param_brg);
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        data = String.Format("{0}", reader["jumlah"]);
                        jumlah1 = Int32.Parse(data);
                        jumlah2 = Int32.Parse(txtJumlah.Text);
                        jumlah_terbaru = jumlah1 + jumlah2;
                    }
                }
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into kegiatan(id_brg, jkegiatan, pj, jumlah, tanggal) values (@id_brg, @jkegiatan, @pj, @jumlah, @tanggal);update barang set jumlah=@jumlah_terbaru where id_brg=@id_brg;", con);
            cmd.Parameters.AddWithValue("id_brg", param_brg);
            cmd.Parameters.AddWithValue("jkegiatan", TextKeg.Text);
            cmd.Parameters.AddWithValue("pj", user);
            cmd.Parameters.AddWithValue("jumlah", txtJumlah.Text);
            cmd.Parameters.AddWithValue("tanggal", TextTanggal.Text);
            cmd.Parameters.AddWithValue("jumlah_terbaru", jumlah_terbaru);
            cmd.ExecuteNonQuery();
            con.Close();
            String url1 = "<script> alert('Input Berhasil');window.location='keterangan.aspx?id=" + param_brg + "'; </script>";
            Response.Write(url1);
        }
    }
}