using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.DataTables
{
    [Serializable]
    class Goods : AbstractTable
    {
        public List<String> Model { set; get; }
        public List<String> Names { set; get; }
        public List<double> Prices { set; get; }
        public List<double> WorkPrices { set; get; }
        public List<String> Colors { set; get; }
        public List<double> Weights { set; get; }  
    }
}
