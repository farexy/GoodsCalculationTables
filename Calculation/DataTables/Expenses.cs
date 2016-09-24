using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation.DataTables
{
    [Serializable]
    class Expenses : AbstractTable
    {
        public List<String> Names { set; get; }
        public List<string> Prices { set; get; }
        public List<string> Counts { set; get; }
        public List<string> Expenses1 { set; get; }
        public List<string> Expenses2 { set; get; }
        public List<string > Sums { set; get; }

        public Expenses()
        {
            Photos = new List<Bitmap>();
            Names = new List<string>();
            Prices = new List<string>();
            Counts = new List<string>();
            Expenses1 = new List<string>();
            Expenses2 = new List<string>();
            Sums = new List<string>();
        }

        public override DataGridView DataGrid
        {
            set
            {
                for (int i = 0; i < value.RowCount; i++)
                {
                    DataGridViewCellCollection row = value.Rows[i].Cells;
                    Photos.Add((Bitmap)row["Фото"].Value);
                    Names.Add((String)row["Название"].Value);
                    Prices.Add((String)row["Цена"].Value);
                    Counts.Add((string)row["Количество"].Value);
                    Expenses1.Add((string)row["Расход1"].Value);
                    Expenses2.Add((string)row["Расход2"].Value);
                    Sums.Add((string)row["Сумма"].Value);
                }
            }
            get
            {
                DataGridView dataGrid = EmptyDataGrid;
                dataGrid.Rows.RemoveAt(1);
                dataGrid.Rows.Add(CountRows - 1);
                for (int i = 0; i < CountRows; i++)
                {
                    DataGridViewCellCollection row = dataGrid.Rows[i].Cells;
                    row["Фото"].Value = Photos[i];
                    row["Название"].Value = Names[i];
                    row["Цена"].Value = Prices[i];
                    row["Количество"].Value = Counts[i];
                    row["Расход1"].Value = Expenses1[i];
                    row["Расход2"].Value = Expenses2[i];
                    row["Сумма"].Value = Sums[i];
                }
                return dataGrid;
            }
        }

        public static DataGridView EmptyDataGrid
        {
            get
            {
                DataGridView dataGrid = new DataGridView();
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                DataGridViewColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "Фото";
                dataGrid.Columns.Add(imgColumn);
                column = new DataGridViewTextBoxColumn();
                column.Name = "Название";
                dataGrid.Columns.Add(column);
                column = new DataGridViewTextBoxColumn();
                column.Name = "Цена";
                dataGrid.Columns.Add(column);
                column = new DataGridViewTextBoxColumn();
                column.Name = "Количество";
                dataGrid.Columns.Add(column);
                column = new DataGridViewTextBoxColumn();
                column.Name = "Расход1";
                dataGrid.Columns.Add(column);
                column = new DataGridViewTextBoxColumn();
                column.Name = "Расход2";
                dataGrid.Columns.Add(column);
                column = new DataGridViewTextBoxColumn();
                column.Name = "Сумма";
                dataGrid.Columns.Add(column);
                dataGrid.Rows.Add(2);
               
                return dataGrid;
            }
        }
    }
}
