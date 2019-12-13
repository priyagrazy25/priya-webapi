using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentModelLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PaymentDALLibrary
{
    public class PaymentDAL
    {
        SqlConnection conn;
        SqlCommand cmdgetAllDetail,cmdgetuser,cmdupdatestatus;
        public PaymentDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conUser"].ConnectionString);
        }
        public List<PaymentModel> GetAllDetail()
        {
            cmdgetAllDetail = new SqlCommand("GetPaymentDetails", conn);
            cmdgetAllDetail.CommandType = CommandType.StoredProcedure;

            List<PaymentModel> PaymentModellist = new List<PaymentModel>();
            conn.Open();
            SqlDataReader drUsers = cmdgetAllDetail.ExecuteReader();
            PaymentModel payment = null;
            while (drUsers.Read())
            {
                payment = new PaymentModel();
                payment.Id = drUsers[0].ToString();
                payment.Testid = drUsers[1].ToString();
                payment.Username = drUsers[2].ToString();
                payment.Testmodel = drUsers[3].ToString();
                payment.Teststatus = drUsers[4].ToString();
                payment.Testdate = drUsers[5].ToString();
                payment.Result = drUsers[6].ToString();
                PaymentModellist.Add(payment);
            }
            conn.Close();
            return PaymentModellist;
        }
        public List<PaymentModel> GetUserDetail(string username)
        {
            cmdgetuser = new SqlCommand("proc_GetuserData", conn);
            cmdgetuser.Parameters.AddWithValue("@username", username);
            cmdgetuser.CommandType = CommandType.StoredProcedure;

            List<PaymentModel> Paylist = new List<PaymentModel>();
            conn.Open();
            SqlDataReader drUsers = cmdgetuser.ExecuteReader();
            PaymentModel payment = null;
            while (drUsers.Read())
            {
                payment = new PaymentModel();

                payment.Id = drUsers[0].ToString();
                payment.Testid = drUsers[1].ToString();
                payment.Username = drUsers[2].ToString();
                payment.Testmodel = drUsers[3].ToString();
                payment.Teststatus = drUsers[4].ToString();
                payment.Testdate = drUsers[5].ToString();
                payment.Result = drUsers[6].ToString();
                Paylist.Add(payment);
            }
            conn.Close();
            return Paylist;
        }
        public string updatestatus(string testid)
        {
            cmdupdatestatus = new SqlCommand("proc_updatestatus", conn);
            cmdupdatestatus.CommandType = CommandType.StoredProcedure;

            cmdupdatestatus.Parameters.AddWithValue("@testid", testid);
            conn.Open();
            if(cmdupdatestatus.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return "Updated";
            }
            else
                conn.Close();
            return "Not Updated";
        }

    }
}
