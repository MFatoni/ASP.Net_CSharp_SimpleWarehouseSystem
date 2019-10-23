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
    public partial class barang : System.Web.UI.Page
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
                gvBarang.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                gvBarang.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }

        private void tampilkanData()
        {
            DataTable dt = this.getDataBarang(0);
            gvBarang.DataSource = dt;
            gvBarang.DataBind();
        }

        private DataTable getDataBarang(int id_brg1)
        {
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            koneksi.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = koneksi;
            if (id_brg1 == 0)
            {
                command.CommandText = "select * from barang";
            }
            SqlDataReader reader = null;
            reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            koneksi.Close();
            return dt;
        }

        protected void gvBarang_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string jenisCommand = e.CommandName;
            if (String.Compare(jenisCommand.ToUpper(), "kegiatan", true) == 0)
            {
                string id = (e.CommandArgument.ToString());
                string url = "keterangan.aspx?id=" + id;
                Response.Redirect(url);   
            }
            else if (String.Compare(jenisCommand.ToUpper(), "ubah", true) == 0)
            {
                string id = (e.CommandArgument.ToString());
                string url = "barangubah.aspx?id=" +id;
                Response.Redirect(url);
            }
            else if (String.Compare(jenisCommand.ToUpper(), "hapus", true) == 0)
            {
                string id = (e.CommandArgument.ToString());
                bool isSukses = hapusbarang(id);
                if (isSukses == true)
                {
                    Response.Write("<script> alert('Sukses');window.location='barang.aspx'; </script>");
                }
                else
                {
                    Response.Write("<script> alert('Gagal');window.location='barang.aspx'; </script>");
                }
            }
        }

        protected void info_Click(object sender, EventArgs e)
        {
            Response.Redirect("barangbaru.aspx");
        }

        private bool hapusbarang(string id)
        {
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            koneksi.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = koneksi;
            command.CommandText = "delete from kegiatan where id_brg = @id;delete from barang where id_brg = @id;";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            koneksi.Close();
            return true;
        }
    }
}