﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation.DataTables
{
    [Serializable]
    class Remainder : AbstractTable
    {
        public List<String> Models { set; get; }
        public List<String> Names { set; get; }
        public List<String> Counts { set; get; }
        public List<String> Prices { set; get; }
        public List<String> Sums { set; get; }
        public double TotalSum { set; get; }

        public Remainder()
        {
            Photos = new List<Bitmap>();
            Models = new List<string>();
            Names = new List<string>();
            Counts = new List<string>();
            Prices = new List<string>();
            Sums = new List<string>();
        }

        public override System.Windows.Forms.DataGridView DataGrid
        {
            set
            {
                for (int i = 0; i < value.RowCount; i++)
                {
                    DataGridViewCellCollection row = value.Rows[i].Cells;
                    Photos.Add((Bitmap)row["Фото"].Value);
                    Names.Add((String)row["Название"].Value);
                    Prices.Add((String)row["Цена"].Value);
                    Models.Add((string)row["Модель"].Value);
                    Counts.Add((string)row["Количество"].Value);
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
                    row["Модель"].Value = Models[i];
                    row["Количество"].Value = Counts[i];
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
                column.Name = "Модель";
                dataGrid.Columns.Add(column);
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
                column.Name = "Сумма";
                dataGrid.Columns.Add(column);
                dataGrid.Rows.Add(2);

                return dataGrid;
            }
        }
    }
}
