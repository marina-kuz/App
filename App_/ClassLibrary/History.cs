using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class History
    {
        public int Id { get; set; }
        public int Amount_money { get;set;}
        public string Operation {get; set;}
        public string Date { get; set; }
        public int Money { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
    }
}
