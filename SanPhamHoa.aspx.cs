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
    public partial class SanPhamHoa : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string sql;
            if (Context.Items["mdm"] == null)
            {
                sql = "select * from Hoa";
            }
            else
            {
                string madm = Context.Items["mdm"].ToString();
                sql = "select * from Hoa where MaDM ='" + madm + "'";
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
                throw;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
                string mahoa = ((LinkButton)sender).CommandArgument;
                Context.Items["mh"] = mahoa;
                Server.Transfer("ChiTiet.aspx");
            
            
        }
    }
}