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
    public partial class ChiTiet : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string sql;
            if (Context.Items["mh"]==null)
            {
                sql = "select * from Hoa";
            }
            else
            {
                string mahoa = Context.Items["mh"].ToString();
                sql = "select * from Hoa where MaHoa = '" + mahoa + "'";
            }
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.DataList1.DataSource = table;
                this.DataList1.DataBind();
            }
            catch (SqlException er)
            {
                Response.Write(er.Message);
            }
        }
        private void taoGio()
        {
            dt = new DataTable();
            dt.Rows.Clear();
            dt.Columns.Add("MaHoa");
            dt.Columns.Add("TenHoa");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonGia");
            dt.Columns.Add("ThanhTien");
            Session["GioHang"] = dt;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["TenDN"] == null)
            {
                Button mua = (Button)sender;
                DataListItem item = (DataListItem)mua.Parent;
                string mahoa = mua.CommandArgument.ToString();
                string tenhoa = ((Label)item.FindControl("Label2")).Text;
                string sl = ((DropDownList)item.FindControl("DropDownList1")).SelectedItem.Text;
                string dg = ((Label)item.FindControl("Label4")).Text;
                dt = (DataTable)Session["GioHang"];
                bool check = false;
                if (dt == null) taoGio();
                foreach (DataRow dataRow in dt.Rows)
                {
                    if (dataRow["MaHoa"].Equals(mahoa))
                    {
                        if (dataRow["TenHoa"].Equals(tenhoa))
                        {
                            dataRow["SoLuong"] = Convert.ToInt32(dataRow["SoLuong"])
                            + Convert.ToInt32(sl);
                            check = true; break;
                        }
                    }
                }
                if (!check)
                {
                    DataRow dataRow = dt.NewRow();
                    dataRow["MaHoa"] = mahoa;
                    dataRow["TenHoa"] = tenhoa;
                    dataRow["SoLuong"] = sl;
                    dataRow["DonGia"] = dg;
                    dataRow["ThanhTien"] = Convert.ToDouble(dg) * Convert.ToDouble(sl);
                    dt.Rows.Add(dataRow);
                }
                Session["GioHang"] = dt;
            }
            else
            {                
                Button mua = (Button)sender;
                string mahoa = mua.CommandArgument.ToString();
                DataListItem item = (DataListItem)mua.Parent;
                string sl = ((DropDownList)item.FindControl("DropDownList1")).SelectedItem.Text;
                string ten = Request.Cookies["TenDN"].Value;
                SqlConnection connection = new SqlConnection(strcon);
                connection.Open();
                string sql = "select * from DonHang where MaHoa ='" + mahoa + "' and TenDN = '" + ten + "'";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command = new SqlCommand("update DonHang set SoLuong = SoLuong + " + sl + " where TenDN = '" + ten + "'", connection);
                }
                else
                {
                    reader.Close();
                    command = new SqlCommand("insert into DonHang values('" + ten + "', '" + mahoa + "', " + sl + ")", connection);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("GioHang.aspx");
        }
    }
}