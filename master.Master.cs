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
    public partial class master : System.Web.UI.MasterPage
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                string sql = "select * from DanhMucHoa";
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string madm = ((LinkButton)sender).CommandArgument;
            Context.Items["mdm"] = madm;
            Server.Transfer("SanPhamHoa.aspx");
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string tendn = this.Login1.UserName;
            string mk = this.Login1.Password;
            string sql = "select * from KhachHang where TenDn = '" + tendn + "' and MatKhau = '" + mk + "'";
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, strcon);             
                adapter.Fill(table);                
            }
            catch (SqlException err)
            {
                Response.Write("<b>Error</b>" + err.Message + "<p/>");             
            }
            if (table.Rows.Count != 0)
            {
                Response.Cookies["TenDN"].Value = tendn;                    
                Server.Transfer("SanPhamHoa.aspx");
            }
            else
            {
                this.Login1.FailureText = "Sai TenDN hoac Mat Khau";
            }
        }
    }
}