using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.DataTables
{
    [Serializable]
    class Expenses : AbstractTable
    {
        public List<String> Names { set; get; }
        public List<double> Prices { set; get; }
        public List<int> Counts { set; get; }
        public List<double> Expenses1 { set; get; }
        public List<double> Expenses2 { set; get; }
        public List<double> Sums { set; get; }  
    }
}
