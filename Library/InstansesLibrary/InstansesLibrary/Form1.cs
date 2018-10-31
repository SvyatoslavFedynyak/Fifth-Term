using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstansesLibrary;

namespace InstansesLibrary
{
    public partial class MatrixShower : Form
    {
        DataGridView matrixDataGrid;
        public MatrixShower()
        {
            matrixDataGrid = new DataGridView();
            matrixDataGrid.AutoSize = true;

        }
        public void ShowMatrix(Matrix target)
        {

            string[] row = new string[target.Coll];

            for (int i = 0; i < target.Coll; i++)
            {
                matrixDataGrid.Columns.Add(i.ToString(), i.ToString());
            }
            for (int i = 0; i < target.Row; i++)
            {
                for (int j = 0; j < target.Coll; j++)
                {
                    row[j] = target[i, j].ToString();
                }
                matrixDataGrid.Rows.Add(row);
            }
            Show();
        }
    }
}
