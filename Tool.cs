using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopHoa_OnTapThiCuoiKi
{
    public class Tool
    {
       
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ConnectionString;
            SqlConnection connect;

            private void GetConnect()
            {
                connect = new SqlConnection(strcon);
                connect.Open();
            }

            private void CloseConnect()
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }

            public DataTable GetData(string sql)
            {
                DataTable table = new DataTable();
                try
                {
                    GetConnect();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
                    adapter.Fill(table);
                }
                catch
                {
                    table = null;
                }
                finally
                {
                    CloseConnect();
                }
                return table;
            }

            public int UpdateData(string sql)
            {
                int kq = 0;
                try
                {
                    GetConnect();
                    SqlCommand command = new SqlCommand(sql, connect);
                    kq = command.ExecuteNonQuery();
                }
                catch
                {
                    kq = 0;
                }
                finally { CloseConnect(); }
                return kq;
            }

            public int Action(string sql)
            {
                int kq = 0;
                try
                {
                    GetConnect();
                    SqlCommand command = new SqlCommand(sql, connect);
                    kq = command.ExecuteNonQuery();
                }
                catch
                {
                    kq = 0;
                }
                finally { CloseConnect(); }
                return kq;
            }
        }
    
}