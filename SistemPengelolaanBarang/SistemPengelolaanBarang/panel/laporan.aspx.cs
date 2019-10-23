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
    public partial class laporan : System.Web.UI.Page
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
                tampilkanDataKegiatan();
                gvKegiatan.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                gvKegiatan.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                gvBarang.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
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

        private void tampilkanDataKegiatan()
        {
            DataTable dt = this.getDataKegiatan(0);
            gvKegiatan.DataSource = dt;
            gvKegiatan.DataBind();
        }

        private DataTable getDataKegiatan(int id_brg1)
        {
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            koneksi.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = koneksi;
            if (id_brg1 == 0)
            {
                command.CommandText = "select * from kegiatan";
            }
            SqlDataReader reader = null;
            reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            koneksi.Close();
            return dt;
        }
    }
}