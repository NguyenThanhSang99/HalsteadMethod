using HalsteadMethod.Business;
using HalsteadMethod.Exporter;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HalsteadMethod
{
    public partial class Main_Form : Form
    {
        //Array to save path of cs files
        private String[] files;
        private Dictionary<string, int> list_operand;
        private Dictionary<string, int> list_operator;
        private AnalyseHalsteadMethod analyseHalsteadMethod;

        public Main_Form()
        {
            this.list_operand = new Dictionary<string, int>();
            this.list_operator = new Dictionary<string, int>();
            this.analyseHalsteadMethod = new AnalyseHalsteadMethod(list_operator, list_operand);
            files = null;
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        /// <summary>
        /// When user click choose files, system open dialog to choose files
        /// </summary>
        private void button_choose_files_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog chooseFileDialog = new OpenFileDialog();
                chooseFileDialog.Filter = "All files (*.*)|cs files (*.cs)|*.cs|*.*";
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
            this.Analyse();
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
            this.Analyse();
        }

        private void Analyse()
        {
            this.list_operand = new Dictionary<string, int>();
            this.list_operator = new Dictionary<string, int>();
            try
            {
                if (files != null)
                {
                    foreach (String f in files)
                    {
                        try
                        {
                            CalculateOperator calculateOperator = new CalculateOperator(f, list_operator);
                            CalculateOperand calculateOperand = new CalculateOperand(f, list_operand);

                            this.list_operator = calculateOperator.List_operator;
                            this.list_operand = calculateOperand.List_operand;

                            analyseHalsteadMethod = new AnalyseHalsteadMethod(this.list_operator, this.list_operand);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lỗi. Làm phiền bạn thử lại sau!!!");
                        }
                    }
                    ViewResult();
                }
            }
            catch (Exception err)
            {
                Debug.Print(err.ToString());
            }
        }

        private void ViewResult()
        {
            String results = "";
            results += "+ Number of distinct operators in the program(μ1): " + analyseHalsteadMethod.NumberOfOperators;
            results += "\r\n+ Number of distinct operands in the program(μ1): " + analyseHalsteadMethod.NumberOfOperands;
            results += "\r\n+ Total number of occurrences of operators in the program(N1): " + analyseHalsteadMethod.TotalOperators;
            results += "\r\n+ Total number of occurrences of operands in the program(N2): " + analyseHalsteadMethod.TotalOperands;
            results += "\r\n+ Program vocabulary(μ): " + analyseHalsteadMethod.ProgramVocaburary();
            results += "\r\n+ Program length(N): " + analyseHalsteadMethod.ProgramLength();
            results += "\r\n+ Program volume(V): " + analyseHalsteadMethod.ProgramVolume();
            results += "\r\n+ Program level(L): " + analyseHalsteadMethod.ProgramLevel();
            results += "\r\n+ Program estimate length: " + analyseHalsteadMethod.ProgramEstimatedLength();
            results += "\r\n+ Effort: " + analyseHalsteadMethod.CalculateEffort();
            results += "\r\n+ Time: " + analyseHalsteadMethod.CalculateTime();
            results += "\r\n+ Remaining Bugs: " + analyseHalsteadMethod.CalculateRemainingBugs();

            this.textBox_result.Text = results;
        }

        private void button_view_operands_Click(object sender, EventArgs e)
        {
            try
            {
                Operand_Form operand_Form = new Operand_Form(list_operand, analyseHalsteadMethod.TotalOperands);
                operand_Form.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Không có files để xem!!!");
            }
        }

        private void textBox_result_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    try
                    {
                        this.textBox_path.Text = fileNames[0];
                        this.files = fileNames;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File không đúng định dạng, vui lòng chọn file khác!!!");
                        Debug.Print(ex.ToString());
                    }
                }
            }
            this.Analyse();
        }

        private void textBox_result_DragEnter(object sender, DragEventArgs e)
        {
            // Cho phép thả file vào textbox
            e.Effect = DragDropEffects.Copy;
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            this.textBox_result.AllowDrop = true;
        }

        private void button_operators_Click(object sender, EventArgs e)
        {
            try
            {
                Operator_Form operator_Form = new Operator_Form(list_operator, analyseHalsteadMethod.TotalOperators);
                operator_Form.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Không có files để xem!!!");
            }
        }

        private void ExportToPDF(DataGridView dataGridView1, DataGridView dataGridView2)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            /* Add table operators to pdf */
                            PdfPTable pdfTableOperator = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTableOperator.DefaultCell.Padding = 3;
                            pdfTableOperator.WidthPercentage = 100;
                            pdfTableOperator.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTableOperator.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell != null && cell.Value != null)
                                    {
                                        pdfTableOperator.AddCell(cell.Value.ToString());
                                    }
                                }
                            }
                            /* End create operators table*/

                            /* Add table operands to pdf */
                            PdfPTable pdfTableOperands = new PdfPTable(dataGridView2.Columns.Count);
                            pdfTableOperands.DefaultCell.Padding = 3;
                            pdfTableOperands.WidthPercentage = 100;
                            pdfTableOperands.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTableOperands.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell != null && cell.Value != null) { 
                                        pdfTableOperands.AddCell(cell.Value.ToString());
                                    }
                                }
                            }
                            /* End create operands table*/

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(new Paragraph("HALSTEAD METHOD"));
                                pdfDoc.Add(new Paragraph("I. Count operators: "));
                                pdfDoc.Add(new Paragraph(" "));
                                pdfDoc.Add(pdfTableOperator);
                                pdfDoc.Add(new Paragraph("II. Count operands: "));
                                pdfDoc.Add(new Paragraph(" "));
                                pdfDoc.Add(pdfTableOperands);
                                pdfDoc.Add(new Paragraph("III. Result: \n"));
                                pdfDoc.Add(new Paragraph(this.textBox_result.Text));
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Operand_Form operand_Form = new Operand_Form(list_operand, analyseHalsteadMethod.TotalOperands);
                Operator_Form operator_Form = new Operator_Form(list_operator, analyseHalsteadMethod.TotalOperators);
                ExportToPDF(operator_Form.LoadData(), operand_Form.LoadData());
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi. Vui lòng thử lại sau!!!");
            }
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {

        }
        private void btnHtmlWriter_Click(object sender, EventArgs e)
        {
            HTMLWriter hTMLWriter = new HTMLWriter();
            Operand_Form operand_Form = new Operand_Form(list_operand, analyseHalsteadMethod.TotalOperands);
            Operator_Form operator_Form = new Operator_Form(list_operator, analyseHalsteadMethod.TotalOperators);
            hTMLWriter.Export(operator_Form.LoadData(), operand_Form.LoadData());

        }
    }
}
