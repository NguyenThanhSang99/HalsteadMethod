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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_operators = new System.Windows.Forms.DataGridView();
            this.label_tiltle = new System.Windows.Forms.Label();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operators)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_operators
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_operators.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_operators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_operators.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.value,
            this.amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_operators.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_operators.Location = new System.Drawing.Point(43, 85);
            this.dataGridView_operators.Name = "dataGridView_operators";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_operators.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_operators.RowHeadersWidth = 51;
            this.dataGridView_operators.Size = new System.Drawing.Size(594, 331);
            this.dataGridView_operators.TabIndex = 15;
            // 
            // label_tiltle
            // 
            this.label_tiltle.AutoSize = true;
            this.label_tiltle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tiltle.ForeColor = System.Drawing.Color.White;
            this.label_tiltle.Location = new System.Drawing.Point(213, 32);
            this.label_tiltle.Name = "label_tiltle";
            this.label_tiltle.Size = new System.Drawing.Size(228, 25);
            this.label_tiltle.TabIndex = 16;
            this.label_tiltle.Text = "THỐNG KÊ TOÁN TỬ";
            // 
            // value
            // 
            this.value.FillWeight = 375F;
            this.value.HeaderText = "Operators";
            this.value.MinimumWidth = 6;
            this.value.Name = "value";
            this.value.Width = 375;
            // 
            // amount
            // 
            this.amount.FillWeight = 150F;
            this.amount.HeaderText = "Occurrences";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.Width = 150;
            // 
            // Operator_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(685, 450);
            this.Controls.Add(this.label_tiltle);
            this.Controls.Add(this.dataGridView_operators);
            this.Name = "Operator_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toán tử";
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