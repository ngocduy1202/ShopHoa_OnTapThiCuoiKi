using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShopHoa_OnTapThiCuoiKi
{
    public partial class GioHang : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        Tool tool = new Tool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.Cookies["TenDN"] != null)
            {                
                try
                {
                    string sql = "select TenDN, DonHang.MaHoa, DonGia, SoLuong, SoLuong * DonGia as ThanhTien" +
                        " from DonHang, Hoa where Hoa.MaHoa = DonHang.MaHoa";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    this.GridView2.DataSource = table;
                    this.GridView2.DataBind();
                    double tong = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        double thanhtien = Convert.ToDouble(row["ThanhTien"]);
                        tong = tong + thanhtien;
                    }
                    this.Label1.Text = tong + "vnd";
                }
                catch (SqlException er)
                {
                    Response.Write(er.Message);
                    throw;
                }
                
            }
            else
            {
                this.docData();
            }
        }

        private void docData()
        {
            DataTable dt = (DataTable)Session["GioHang"];
            GridView1.DataSource = dt;
            GridView1.DataBind();

            double tong = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double thanhtien = Convert.ToDouble(dt.Rows[i]["SoLuong"])
                    * Convert.ToDouble(dt.Rows[i]["DonGia"]);
                tong = tong + thanhtien;
            }

            this.Label1.Text ="Tong tien: "+ tong + " vnd";
        }



        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string mahoa = e.Values["MaHoa"].ToString();
            int kq = tool.UpdateData("delete from DonHang where MaHoa ='" + mahoa + "'");
            if(kq > 0)
            {
                Response.Write("<script>alert('Done'); </script>");
                GridView2.DataSource = tool.GetData("select TenDN, DonHang.MaHoa, DonGia, SoLuong, SoLuong * DonGia as ThanhTien" +
                        " from DonHang, Hoa where Hoa.MaHoa = DonHang.MaHoa");
                GridView2.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Error'); </script>");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable table = (DataTable)Session["GioHang"];
            if (e.CommandName == "btdel")
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
                table.Rows[row.DataItemIndex].Delete();
                Session["GioHang"] = table;
            }            
            this.docData();
        }
    }
}