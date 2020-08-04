using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lsatName;
        private string emailAddress;
        private DateTime creaOn;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LsatName { get => lsatName; set => lsatName = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public DateTime CreaOn { get => creaOn; set => creaOn = value; }
    }
}
