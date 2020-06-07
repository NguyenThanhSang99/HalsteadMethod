namespace HalsteadMethod
{
    partial class Operator_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_operators = new System.Windows.Forms.DataGridView();
            this.label_tiltle = new System.Windows.Forms.Label();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operators)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_operators
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_operators.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_operators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_operators.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.value,
            this.amount});
            this.dataGridView_operators.Location = new System.Drawing.Point(43, 85);
            this.dataGridView_operators.Name = "dataGridView_operators";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_operators.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_operators.Size = new System.Drawing.Size(594, 331);
            this.dataGridView_operators.TabIndex = 15;
            // 
            // label_tiltle
            // 
            this.label_tiltle.AutoSize = true;
            this.label_tiltle.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tiltle.ForeColor = System.Drawing.Color.Indigo;
            this.label_tiltle.Location = new System.Drawing.Point(213, 32);
            this.label_tiltle.Name = "label_tiltle";
            this.label_tiltle.Size = new System.Drawing.Size(265, 31);
            this.label_tiltle.TabIndex = 16;
            this.label_tiltle.Text = "THỐNG KÊ TOÁN TỬ";
            // 
            // value
            // 
            this.value.FillWeight = 375F;
            this.value.HeaderText = "Operators";
            this.value.Name = "value";
            this.value.Width = 375;
            // 
            // amount
            // 
            this.amount.FillWeight = 150F;
            this.amount.HeaderText = "Occurrences";
            this.amount.Name = "amount";
            this.amount.Width = 150;
            // 
            // Operator_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.label_tiltle);
            this.Controls.Add(this.dataGridView_operators);
            this.Name = "Operator_Form";
            this.Text = "Operator_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Operator_Form_FormClosing);
            this.Load += new System.EventHandler(this.Operator_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_operators;
        private System.Windows.Forms.Label label_tiltle;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}