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
	public partial class keterangan : System.Web.UI.Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["username"] != "Administrator")
            {
                Response.Redirect("../index.aspx");
            } else
            {
                tampilkanData();
                gvKegiatan.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                gvKegiatan.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                //gvKegiatan.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void btnlogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }
        private void tampilkanData()
        {
            DataTable dt = this.getDataKegiatan(0);
            gvKegiatan.DataSource = dt;
            gvKegiatan.DataBind();
        }

        private DataTable getDataKegiatan(int id_brg1)
        {
            String param_brg = Request.QueryString["id"];
            String query1 = "select * from kegiatan where id_brg=" + param_brg;
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            koneksi.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = koneksi;
            if (id_brg1 == 0)
            {
                command.CommandText = query1;
            }
            SqlDataReader reader = null;
            reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            koneksi.Close();
            return dt;
        }

        //protected void gvKegiatan_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    string jenisCommand = e.CommandName;
        //    if (String.Compare(jenisCommand.ToUpper(), "hapus", true) == 0)
        //    {
        //        string id = (e.CommandArgument.ToString());
        //        bool isSukses = hapusKegiatan(id);
        //        if (isSukses == true)
        //        {
        //            Response.Write("<script> alert('Sukses');window.location='barang.aspx'; </script>");
        //        }
        //        else
        //        {
        //            Response.Write("<script> alert('Gagal');window.location='barang.aspx'; </script>");
        //        }
        //    }
        //}

        //private bool hapusKegiatan(string id)
        //{
        //    SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        //    koneksi.Open();
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = koneksi;
        //    command.CommandText = "delete from kegiatan where id_keg = @id;";
        //    command.Parameters.AddWithValue("@id", id);
        //    command.ExecuteNonQuery();
        //    koneksi.Close();
        //    return true;
        //}

        protected void info_Click(object sender, EventArgs e)
        {
            String param_brg = Request.QueryString["id"];
            string url = "kegiatan.aspx?id=" + param_brg;
            Response.Redirect(url);
        }
    }
}