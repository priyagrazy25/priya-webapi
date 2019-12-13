using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentModelLibrary;
using PaymentDALLibrary;

namespace PaymentBLLibrary
{
    public class PaymentBL
    {
        PaymentDAL dal;

        public PaymentBL()
        {
            dal = new PaymentDAL();
        }
        public List<PaymentModel> BLGetAllDetail()
        {
            return dal.GetAllDetail();
        }
        public List<PaymentModel> BlGetuserData(string username)
        {
            return dal.GetUserDetail(username);
        }
        public string Blupdatestatus(string testid)
        {
            return dal.updatestatus(testid);
        }
    }
}
