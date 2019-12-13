using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModelLibrary
{
    public class PaymentModel
    {
        string id, username, testmodel, teststatus, testdate, result;
        string testid;
        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Testmodel { get => testmodel; set => testmodel = value; }
        public string Teststatus { get => teststatus; set => teststatus = value; }
        public string Testdate { get => testdate; set => testdate = value; }
        public string Result { get => result; set => result = value; }
        public string Testid { get => testid; set => testid = value; }
    }
}
