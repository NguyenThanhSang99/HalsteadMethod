using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalsteadMethod
{
    public partial class Operator_Form : Form
    {
        private Dictionary<string, int> operator_dictionary;
        private int sum_operator;
        public Operator_Form(Dictionary<string, int> operators, int sum)
        {
            this.operator_dictionary = operators;
            this.sum_operator = sum;
            InitializeComponent();
            this.dataGridView_operators.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Operator_Form_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        public DataGridView LoadData()
        {
            try
            {
                //Xóa hết dữ liệu hiện tại trong datagridview
                this.dataGridView_operators.Rows.Clear();
                //Lặp đưa dữ liệu vào datagridview
                foreach (KeyValuePair<string, int> item in operator_dictionary)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView_operators.Rows[0].Clone();
                    row.Cells[0].Value = item.Key;
                    row.Cells[1].Value = item.Value;
                    dataGridView_operators.Rows.Add(row);
                }

                DataGridViewRow row_total = (DataGridViewRow)dataGridView_operators.Rows[0].Clone();
                row_total.Cells[0].Value = "Total operators";
                row_total.Cells[1].Value = this.sum_operator;
                dataGridView_operators.Rows.Add(row_total);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
            return this.dataGridView_operators;
        }

        private void Operator_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
