namespace HalsteadMethod
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.button_choose_files = new System.Windows.Forms.Button();
            this.button_analyse = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.button_select_folder = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label_tiltle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_choose_files
            // 
            this.button_choose_files.BackColor = System.Drawing.Color.Lime;
            this.button_choose_files.Location = new System.Drawing.Point(445, 101);
            this.button_choose_files.Name = "button_choose_files";
            this.button_choose_files.Size = new System.Drawing.Size(75, 42);
            this.button_choose_files.TabIndex = 17;
            this.button_choose_files.Text = "Chọn files";
            this.button_choose_files.UseVisualStyleBackColor = false;
            this.button_choose_files.Click += new System.EventHandler(this.button_choose_files_Click);
            // 
            // button_analyse
            // 
            this.button_analyse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_analyse.Location = new System.Drawing.Point(299, 149);
            this.button_analyse.Name = "button_analyse";
            this.button_analyse.Size = new System.Drawing.Size(75, 31);
            this.button_analyse.TabIndex = 16;
            this.button_analyse.Text = "Phân tích";
            this.button_analyse.UseVisualStyleBackColor = false;
            this.button_analyse.Click += new System.EventHandler(this.button_analyse_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(60, 186);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(559, 230);
            this.textBox_result.TabIndex = 15;
            // 
            // button_select_folder
            // 
            this.button_select_folder.BackColor = System.Drawing.Color.Aqua;
            this.button_select_folder.Location = new System.Drawing.Point(544, 101);
            this.button_select_folder.Name = "button_select_folder";
            this.button_select_folder.Size = new System.Drawing.Size(75, 42);
            this.button_select_folder.TabIndex = 14;
            this.button_select_folder.Text = "Chọn folder";
            this.button_select_folder.UseVisualStyleBackColor = false;
            this.button_select_folder.Click += new System.EventHandler(this.button_select_folder_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(60, 101);
            this.textBox_path.Multiline = true;
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(364, 42);
            this.textBox_path.TabIndex = 13;
            // 
            // label_tiltle
            // 
            this.label_tiltle.AutoSize = true;
            this.label_tiltle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tiltle.ForeColor = System.Drawing.Color.Lime;
            this.label_tiltle.Location = new System.Drawing.Point(190, 35);
            this.label_tiltle.Name = "label_tiltle";
            this.label_tiltle.Size = new System.Drawing.Size(330, 29);
            this.label_tiltle.TabIndex = 12;
            this.label_tiltle.Text = "PHƯƠNG PHÁP HALSTEAD";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.button_choose_files);
            this.Controls.Add(this.button_analyse);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_select_folder);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.label_tiltle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.Text = "Phương pháp Halstead";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_choose_files;
        private System.Windows.Forms.Button button_analyse;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button button_select_folder;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Label label_tiltle;
    }
}

