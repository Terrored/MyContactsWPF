using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactsBL
{
    public class Person : IContact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

           
        }

        public string EmailAddress { get; set; }
        public string Number { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Company { get; set; }

        public string GetDetails()
        {
            string details = $"Address: {this.Address} \nCity: {this.City} \nCompany: {this.Company} ";

            return details;
        }
        

        public override string ToString()
        {
            return this.Name;
        }
    }
}
