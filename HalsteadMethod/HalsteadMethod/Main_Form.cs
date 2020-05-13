using HalsteadMethod.Business;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HalsteadMethod
{
    public partial class Main_Form : Form
    {
        //Array to save path of cs files
        private String[] files;
        public Main_Form()
        {
            files = null;
            InitializeComponent();
        }
        /// <summary>
        /// When user click choose files, system open dialog to choose files
        /// </summary>
        private void button_choose_files_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog chooseFileDialog = new OpenFileDialog();
                chooseFileDialog.Filter = "cs files (*.cs)|*.cs|All files (*.*)|*.*";
                chooseFileDialog.FilterIndex = 1;
                chooseFileDialog.Multiselect = true;

                if (chooseFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sFileName = chooseFileDialog.FileName;
                    string[] arrAllFiles = chooseFileDialog.FileNames; //used when Multiselect = true  
                    this.files = arrAllFiles;
                }
            }
            catch (Exception err)
            {
                //If error show it in output
                Debug.Print(err.ToString());
            }
        }
        /// <summary>
        /// When user click choose folder, system open dialog to choose folder
        /// </summary>
        private void button_select_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowerDialog = new FolderBrowserDialog();
            folderBrowerDialog.Description = "Custom Description";

            if (folderBrowerDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox_path.Text = folderBrowerDialog.SelectedPath;
            }
            String folder = this.textBox_path.Text;
            try
            {
                this.files = Directory.GetFiles(folder, "*.cs", SearchOption.AllDirectories);
            }
            catch (Exception err)
            {
                //If error show it in output
                Debug.Print(err.ToString());
            }
        }

        private void button_analyse_Click(object sender, EventArgs e)
        {
            try
            {
                String allFiles = "";
                foreach (String f in files)
                {
                    allFiles = allFiles + " " + f + "\r\n";
                }
                this.textBox_result.Text = allFiles;
            }
            catch (Exception err)
            {
                Debug.Print(err.ToString());
            }
        }

        private void button_view_operands_Click(object sender, EventArgs e)
        {
            try
            {
                string path = files[0];
                CalculateOperand calculateOperand = new CalculateOperand(path);
                Operand_Form operand_Form = new Operand_Form(calculateOperand.List_operand);
                operand_Form.Show();
            }
            catch
            {
                MessageBox.Show("Không có files để xem!!!");
            }
        }
    }
}
