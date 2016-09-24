using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation.DataTables
{
    [Serializable]
    abstract class AbstractTable
    {
        protected AbstractTable() { }
        public List<Bitmap> Photos { set; get; }
        public int CountRows { get { return Photos.Count; } }
        public abstract DataGridView DataGrid { set; get; }
    }
}
