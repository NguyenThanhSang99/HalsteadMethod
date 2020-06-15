using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HalsteadMethod
{
    public partial class Operand_Form : Form
    {
        private Dictionary<string, int> operand_dictionary;
        private int sum_operand;
        public Operand_Form(Dictionary<string, int> operands, int sum)
        {
            this.operand_dictionary = operands;
            this.sum_operand = sum;
            InitializeComponent();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void Operand_Form_Load(object sender, System.EventArgs e)
        {
            this.LoadData();
        }

        public DataGridView LoadData()
        {
            try
            {
                //Xóa hết dữ liệu hiện tại trong datagridview
                this.dataGridView1.Rows.Clear();
                //Lặp đưa dữ liệu vào datagridview
                foreach (KeyValuePair<string, int> item in operand_dictionary)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = item.Key;
                    row.Cells[1].Value = item.Value;
                    dataGridView1.Rows.Add(row);
                }

                DataGridViewRow row_total = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row_total.Cells[0].Value = "Total operands";
                row_total.Cells[1].Value = this.sum_operand;
                dataGridView1.Rows.Add(row_total);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
            return this.dataGridView1;
        }

        private void Operand_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
