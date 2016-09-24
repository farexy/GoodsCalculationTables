using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculation.DataTables;

namespace Calculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            DataGridViewColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "Фото";
            dataGridView1.Columns.Add(imgColumn);
            column.Name = "Название";
            dataGridView1.Columns.Add(column);
            dataGridView1.Rows.Add(5);

        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewImageCell cell = (DataGridViewImageCell)dataGridView1[e.ColumnIndex, e.RowIndex];
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    cell.Value = new Bitmap(Image.FromFile(dlg.FileName), 60, 30);
                }
            }
            save(); open();
        }

        private void save()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Serializer.WriteToFile(dlg.FileName, new Expenses()); 
                }
            }
        }

        private void open()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.DataSource = Serializer.ReadFromFile(dlg.FileName);
                }
            }
        }

        private void loadDataGridView(AbstractTable table)
        {
            if (table.GetType() == typeof (Expenses))
            {
                
            }
        }
    }
}
