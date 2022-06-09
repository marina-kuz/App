using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_
{
    public class History
    {
        public int Id { get; set; }
        public int PersonId {get;set;}
        public Person Person {get; set;}

        public int Type {get; set;}
        public string Date_ { get; set; }
        public int Money { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
    }
}
