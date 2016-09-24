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
        private DataGridView dataGridView1;
        private int WIDTH = 1000;
        private int HEIGHT = 500;
        private string currentFileName;
        private Type currentTableType;
        static int DATA_GRID_WIDTH = 800;
        static int DATA_GRID_HEIGHT = 350;

        public Form1()
        {
            InitializeComponent();
            this.Width = WIDTH;
            this.Height = HEIGHT;
            setFileName(null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && dataGridView1.Columns[e.ColumnIndex].Name == "Фото")
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
                //save(); open();
            }
            
        }

        private void save()
        {
            AbstractTable dataTable;
            if (currentTableType == typeof (Expenses))
            {
                dataTable = new Expenses();
            }
            else if (currentTableType == typeof(Goods))
            {
                dataTable = new Goods();
            }
            else if (currentTableType == typeof (Profit))
            {
                dataTable = new Profit();
            }
            else
            {
                dataTable = new Remainder();
            }
            dataTable.DataGrid = dataGridView1;
            if (currentFileName == null)
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Title = "Сохраните ваш файл";
                    dlg.Filter = "Datt files (*.datt)|*.datt";
                    dlg.DefaultExt = ".datt";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        setFileName(dlg.FileName);
                    }
                }
            }
            Serializer.WriteToFile(currentFileName, dataTable); 
        }

        private void open()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open file";
                dlg.Filter = "DATT Files (*.datt*)|*.datt*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    setFileName(dlg.FileName);
                    loadDataGridView(Serializer.ReadFromFile(currentFileName));
                }
            }
        }

        private void loadDataGridView(AbstractTable table)
        {
            if (table.GetType() == typeof (Expenses))
            {
                currentTableType = typeof (Expenses);
                label1.Text = "Расходы";
            }
            if (table.GetType() == typeof (Profit))
            {
                currentTableType = typeof (Profit);
                label1.Text = "Прибыль";
            }
            if (table.GetType() == typeof (Goods))
            {
                currentTableType = typeof (Goods);
                label1.Text = "Товары";
            }
            if (table.GetType() == typeof (Remainder))
            {
                currentTableType = typeof (Remainder);
                label1.Text = "Остаток/склад";
            }
            changeDataGrid(table.DataGrid);
        }

        private void changeDataGrid(DataGridView dataGrid)
        {
            Controls.Remove(dataGridView1);
            dataGridView1 = dataGrid;
            dataGridView1.Location = new Point(100, 100);
            dataGridView1.Width = DATA_GRID_WIDTH;
            dataGridView1.Height = DATA_GRID_HEIGHT;
            dataGridView1.CellClick += dataGridView1_CellClick;
            Controls.Add(dataGridView1);
        }

        private void расходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFileName(null);
            label1.Text = "Расходы";
            currentTableType = typeof (Expenses);
            changeDataGrid(Expenses.EmptyDataGrid);
        }

        private void остатокскладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFileName(null);
            label1.Text = "Остаток/склад";
            currentTableType = typeof(Remainder);
            changeDataGrid(Remainder.EmptyDataGrid);
        }

        private void прибыльToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFileName(null);
            label1.Text = "Прибыль";
            currentTableType = typeof(Profit);
            changeDataGrid(Profit.EmptyDataGrid);
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFileName(null);
            label1.Text = "Товары";
            currentTableType = typeof(Goods);
            changeDataGrid(Goods.EmptyDataGrid);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFileName(null);
            save();
        }

        private void setFileName(string name)
        {
            if (name != null)
            {
                var namemas = name.Split('\\');
                this.Text = namemas[namemas.Length - 1];
            }
            else
            {
                this.Text = String.Empty;
            }
            currentFileName = name;
        }
    }
}
