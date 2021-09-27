using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltungssystem3.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Avaliableamount { get; set; }
    }
}
