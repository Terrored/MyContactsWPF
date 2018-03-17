using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactsBL
{
    public class Company : IContact
    {
        public int ID { get; set; }
        public string Name { get; }

        public string EmailAddress { get; set; }
        public string Number { get; set; }

        //public string Fax { get; set; }

        //public CompanyType CompanyType { get; set; }
          


    }

    public enum CompanyType
    {
        IT,
        Marketing,
        Industry,
        Trading
    }
}
