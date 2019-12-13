using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaymentModelLibrary;
using PaymentBLLibrary;
using System.Web.Http.Cors;


namespace WebApplication.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class PaymentController : ApiController
    {
        // GET: api/Payment
        PaymentBL BL = new PaymentBL();
        static List<PaymentModel> PaymentModellist = new List<PaymentModel>();
        static List<PaymentModel> paylist = new List<PaymentModel>();
        public IEnumerable<PaymentModel> Get()
        {
            PaymentModellist = BL.BLGetAllDetail();
            return PaymentModellist;
        }
        public IEnumerable<PaymentModel> GetuserData(string username)
        {
            paylist = BL.BlGetuserData(username);
            return paylist;
        }

        // GET: api/Payment/5
   
        // POST: api/Payment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Payment/5
        public void Put(string testid)
        {
           BL.Blupdatestatus(testid);
        }

        // DELETE: api/Payment/5
        public void Delete(int id)
        {
        }
    }
}
