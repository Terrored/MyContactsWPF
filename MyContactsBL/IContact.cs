using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactsBL
{
    public interface IContact
    {
        int ID { get; set; }
        string Name { get; }

        string EmailAddress { get; set; }

        string Number { get; set; }




    }
}
