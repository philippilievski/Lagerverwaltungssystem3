using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltungssystem3.Model
{
    public class Orderposition
    {
        public int OrderpositionID { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
