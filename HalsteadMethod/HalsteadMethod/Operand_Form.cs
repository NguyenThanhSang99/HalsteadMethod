using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace HalsteadMethod
{
    public partial class Operand_Form : Form
    {
        private Dictionary<string, int> operand_dictionary;
        public Operand_Form(Dictionary<string, int> operands)
        {
            this.operand_dictionary = operands;
            InitializeComponent();
        }

        private void Operand_Form_Load(object sender, System.EventArgs e)
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
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }

        private void Operand_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
