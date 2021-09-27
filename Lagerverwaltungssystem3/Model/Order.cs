using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltungssystem3.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Orderdate { get; set; }
        public EntryExit EntryExit { get; set; }
        public List<Orderposition> Orderpositions { get; set; }
    }
}
