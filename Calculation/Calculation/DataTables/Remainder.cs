using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.DataTables
{
    [Serializable]
    class Remainder : AbstractTable
    {
        public List<String> Models { set; get; }
        public List<String> Names { set; get; }
        public List<int> Counts { set; get; }
        public List<double> Prices { set; get; }
        public List<double> Sums { set; get; }
        public double TotalSum { set; get; } 
    }
}
