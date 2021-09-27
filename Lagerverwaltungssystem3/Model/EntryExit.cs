using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltungssystem3.Model
{
    public class EntryExit
    {
        public int EntryExitID { get; set; }
        public string Title { get; set; }
        public List<Order> Orders { get; set; }
    }
}