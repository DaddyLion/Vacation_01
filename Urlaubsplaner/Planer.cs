
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Globalization;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Printing;
using PdfSharp.Pdf;

namespace Urlaubsplaner
{
	
	public partial class Planer : Form
	
	{
			
		public Planer(string user)
		{
			
			InitializeComponent();
			
			this.label5.Text = user;
			
			/*DataTable dt = new DataTable();
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			string query = String.Format("Select team_id From user where Name = '{0}';", user);
			SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
		
 			dt.Load(command.ExecuteReader());
 			*/
 			
 			//MessageBox.Show(dt.Rows[0].Field<string>(0));
			
		}
		
		private void button1_Click(object sender, System.EventArgs e)
		{
		   // Create a SelectionRange object and set its Start and End properties.
		   SelectionRange sr = new SelectionRange();
		   sr.Start = DateTime.Parse(this.label6.Text);
		   sr.End = DateTime.Parse(this.label7.Text);
		   /* Assign the SelectionRange object to the 
		      SelectionRange property of the MonthCalendar control. */
		   this.monthCalendar1.SelectionRange = sr;
		}
	     
		void MonthCalendar1DateChanged(object sender, DateRangeEventArgs e)
		{
			DateTime dtOne = monthCalendar1.SelectionRange.Start.Date;
			DateTime dtTwo = monthCalendar1.SelectionRange.End.Date;
			 
			TimeSpan diff = dtTwo - dtOne;
			
				/* Display the Start and End property values of 
		      the SelectionRange object in the text boxes. */
		   this.label6.Text = 
		     monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
		   this.label7.Text = 
		     monthCalendar1.SelectionRange.End.Date.ToShortDateString();
		   
		   this.label8.Text = Convert.ToString(diff.TotalDays + 1);
		}
	
		void Button1Click(object sender, EventArgs e)
		{
			/*PdfDocument antrag = new PdfDocument();
			PdfPage firstPage = antrag.AddPage();
			XGraphics graph = XGraphics.FromPdfPage(firstPage);
			XFont font = new XFont("Chiller",20,XFontStyle.Bold);
			
			graph.DrawString("Urlaubsantrag", font, XBrushes.DeepSkyBlue,
								new XRect(0, 0, firstPage.Width.Point, firstPage.Height.Point), XStringFormats.TopCenter);
			
			antrag.Save("FirstPdf.pdf");
			Process.Start("FirstPdf.pdf");
	
			*/
			DataTable dt = new DataTable();
			DataTable dt2 = new DataTable();
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			string player = this.label5.Text;
			string fDay = this.label6.Text;
			string eDay = this.label7.Text;
			string tDays = this.label8.Text;
			string vIssues = this.label9.Text;
			
			DateTime dTime =  DateTime.ParseExact(fDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			DateTime dTime2 =  DateTime.ParseExact(eDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			string newTime = dTime.ToString("yyyyMMdd");
			string newTime2 = dTime2.ToString("yyyyMMdd");
			
			string query2 = String.Format("Insert Into Urlaubsübersicht (Von,Bis,Entspricht_Tage,User_ID) Values ('{0}','{1}','{2}','{3}');",newTime,newTime2,tDays,player);
			string query3 = String.Format("Select * From Urlaubsübersicht where Von BETWEEN '{0}' AND  '{1}';", newTime,newTime2);
			SQLiteCommand command = new SQLiteCommand(query2, m_dbConnection);
			SQLiteCommand command1 = new SQLiteCommand(query3, m_dbConnection);
			
			command.ExecuteNonQuery();
 			dt2.Load(command1.ExecuteReader());
 			
 			this.label9.Text = "Der Urlaub für " + player + " in der Zeit von " + fDay  + " bis " + eDay  +" wurde beantragt";
 			this.label10.Text = "Das entspricht " + tDays + " Urlaubstage";
 			
 			DataGridView dataGridView1 = new DataGridView();
 			
 			this.dataGridView1.DataSource = dt2;
 			
            
		}
	
	}
}