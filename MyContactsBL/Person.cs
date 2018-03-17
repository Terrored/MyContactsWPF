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

        //public string Address { get; set; }

        //public string Nickname { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
