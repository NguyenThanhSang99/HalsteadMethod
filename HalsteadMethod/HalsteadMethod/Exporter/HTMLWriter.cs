using HalsteadMethod.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Math;
using iTextSharp.text.pdf.codec;

namespace HalsteadMethod.Exporter
{
	class HTMLWriter
	{
		private AnalyseHalsteadMethod analyseHalsteadMethod;

		public string RoundTo2Decimals(double val)
		{
			return val.ToString("0.#####");
		}

		public HTMLWriter()
		{

		}

		public bool Export(DataGridView dgvListOperators, DataGridView dgvListOperands)
		{
			if (dgvListOperators.Rows.Count < 0 || dgvListOperands.Rows.Count < 0)
			{
				return false;
			}
			else
			{
				StringBuilder builder = new StringBuilder();

				builder.Append("<!DOCTYPE HTML>" + "<html>" + " <head>" + " <title>Halstead Metrics</title>"
								+ "<style type=\"text/css\">" + "#header{" + "border:2px solid #a1a1a1;" + "padding:10px 40px;"
								+ "background:#dddddd;" + "width:800px;" + "margin-left: 250px;" + "border-radius:25px;" + "}"
								+ "h1{" + "font-family: sans-serif;" + "font-size: 50px;" + "margin-left: 10px;" + "}" + "#body{"
								+ "font-family: sans-serif;" + "border:2px solid #a1a1a1;" + "padding:10px 40px;" + "width:800px;"
								+ "margin-left: 250px;" + "}" + "#footer{" + "border:2px solid #a1a1a1;" + "padding:10px 40px;"
								+ "background:#dddddd;" + "width:800px;" + "margin-left: 250px;" + "border-radius:25px;" + "}"
								+ "#footer-contents{" + "font-family: sans-serif;" + "margin-left: 270px;" + "}" + "table, th, td{"
								+ "border: 2px solid #a1a1a1;" + "}" + "table{" + "border-collapse:collapse;" + "margin-left: 80px;"
								+ "}" + "th,td{" + "text-align: center;" + "padding:5px;" + "}" + "th{" + "background:#dddddd;"
								+ "}" + "</style>" + "</head>");
				builder.Append("<body>" + "<div id=\"layout\">" + "<div id=\"header\">"
						+ "<h1 id=\"heading\">Halstead Metrics Detailed Report</h1>" + "</div>" + "<div id=\"body\">"
						+ "<br /><p><h3>File Name: </h3>" + "metrics_detail_report.html" + "</p>");

				builder.Append("<br /><h4><u>Operators</u></h4>" + "<table border=\"1\">" + "<tr>" + "<th>" + "Toán tử"
						+ "</th>" + "<th>" + "Số lượng" + "</th>" + "</tr>");

				foreach (DataGridViewRow row in dgvListOperators.Rows)
				{
					if (row != null && row.Cells.Count > 0 && row.Cells[0].Value != null)
					{
						builder.Append("<tr>" + "<td>" + row.Cells[0].Value.ToString() + "</td>" + "<td>"
						+ row.Cells[1].Value.ToString() + "</td>" + "</tr>");
					}
				}

				builder.Append("</table>");
				builder.Append("<br /><h4><u>Operands</u></h4>" + "<table border=\"1\">" + "<tr>" + "<th>" + "Name" + "</th>"
						+ "<th>" + "Count" + "</th>" + "</tr>");

				foreach (DataGridViewRow row in dgvListOperands.Rows)
				{
					if (row != null && row.Cells.Count >0 && row.Cells[0].Value!=null)
					{
						builder.Append("<tr>" + "<td>" + row.Cells[0].Value.ToString() + "</td>" + "<td>"
								+ row.Cells[1].Value.ToString() + "</td>" + "</tr>");
					}
			}
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "PDF (*.html)|*.html";
				sfd.FileName = "Output.pdf";

				builder.Append("</table>");

				//Some content will update later

				//builder.Append("<br><h4><u>Values</u></h4>" + "<table border=\"1\">" + "<tr>"
				//		+ "<th>No of Distinct Operators(n1)</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.NumberOfOperators) + "</td>" + "</tr>"
				//		+ "<tr>" + "<th>No of Distinct Operands(n2)</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.NumberOfOperands) + "</td>"
				//		+ "</tr>" + "<tr>" + "<th>Total No of Operators(N1)</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.TotalOperators)
				//		+ "</td>" + "</tr>" + "<tr>" + "<th>Toatl No of Operands(N2)</th>" + "<td>"
				//		+ RoundTo2Decimals(analyseHalsteadMethod.TotalOperands) + "</td>" + "</tr>" + "<tr>" + "<th>Program Length</th>" + "<td>"
				//		+ RoundTo2Decimals(analyseHalsteadMethod.ProgramVocaburary()) + "</td>" + "</tr>" + "<tr>" + "<th>Program Vocabulary</th>"
				//		+ "<td>" + RoundTo2Decimals(analyseHalsteadMethod.ProgramLength()) + "</td>" + "</tr>" + "<tr>"
				//		+ "<th>Estimated Length</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.ProgramVolume()) + "</td>" + "</tr>"
				//		+ "<tr>" + "<th>Purity Ratio</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.ProgramLevel()) + "</td>" + "</tr>"
				//		+ "<tr>" + "<th>Volume</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.ProgramEstimatedLength()) + "</td>" + "</tr>" + "<tr>"
				//		+ "<th>Difficulty</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.CalculateEffort()) + "</td>" + "</tr>" + "<tr>"
				//		+ "<th>Program Effort</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.CalculateTime()) + "</td>" + "</tr>"
				//		+ "<tr>" + "<th>Programming Time</th>" + "<td>" + RoundTo2Decimals(analyseHalsteadMethod.CalculateRemainingBugs()) + "</td>"
				//		+ "</tr>" + "</table>");

				builder.Append("</div>" + "<div id=\"footer\">"
						+ "<p id=\"footer-contents\">Copyright &copy; Software Measurements 2020. <strong>Halstead Measurements </strong></p>"
						+ "</div>" + "</div>" + "</body>" + "</html>");


				StreamWriter streamWriter;
				streamWriter = File.CreateText("metrics_detail_report.html");
				streamWriter.WriteLine(builder);
				streamWriter.Close();

				MessageBox.Show("Data Exported Successfully !!!", "Info");

				return true;
			}

		}
	}

}