

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Printing;
using PdfSharp.Pdf;
using System.Globalization;
using Word = Microsoft.Office.Interop.Word;

namespace Urlaubsplaner
{
	
	public partial class Planer : Form
	
	{
			
		public Planer(string user, string team)
		{
			InitializeComponent();
			
			DataTable dt_all = new DataTable();
			this.label5.Text = user;
			this.label12.Text = team;
			this.button2.Visible = false;
			this.button3.Visible = false;
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			string applikation = "Ja";                       
			string query_all = String.Format("Select * From Urlaubsübersicht Where Beantragt = '{0}';",applikation);
			SQLiteCommand command = new SQLiteCommand (query_all,m_dbConnection);
			
			dt_all.Load(command.ExecuteReader());
			
			if (team == "0") {
				this.button2.Visible = true;
				this.button3.Visible = true;
				
				this.dataGridView1.DataSource = dt_all;
				
				
			}
				
			
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
			string tId = this.label12.Text;
			string vApplik = "Ja";
			
			DateTime dTime =  DateTime.ParseExact(fDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			DateTime dTime2 =  DateTime.ParseExact(eDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			
			string newTime = dTime.ToString("yyyyMMdd");
			string newTime2 = dTime2.ToString("yyyyMMdd");
			string query2 = String.Format("Insert Into Urlaubsübersicht (User,Von,Bis,Entspricht_Tage,Team_ID,Beantragt) Values ('{0}','{1}','{2}','{3}','{4}','{5}');",player,newTime,newTime2,tDays,tId,vApplik);
			string query3 = String.Format("Select * From Urlaubsübersicht where Von BETWEEN '{0}' AND  '{1}';", newTime,newTime2);
			string gridQuery = String.Format("Select * From Urlaubsübersicht where Team_ID '{0}';", tId);
			
			SQLiteCommand command = new SQLiteCommand(query2, m_dbConnection);
			SQLiteCommand command1 = new SQLiteCommand(query3, m_dbConnection);
			
			
			command.ExecuteNonQuery();
 			dt2.Load(command1.ExecuteReader());
 			
 			this.label9.Text = "Der Urlaub für " + player + " in der Zeit von " + fDay  + " bis " + eDay  +" wurde beantragt";
 			this.label10.Text = "Das entspricht " + tDays + " Urlaubstage";
 			
 			DataGridView dataGridView1 = new DataGridView();
 			
 			this.dataGridView1.DataSource = dt2;
 				
 			Word.ApplicationClass WordApp = new Word.ApplicationClass();
			object fileName = @"C:\\Users\\David\\Documents\\SharpDevelop Projects\\Urlaubsplaner\\Urlaubsantrag.docx";
			object readOnly = false;
			object isVisible = true;
			object missing = Type.Missing;
			object doctype = 0;

					Word.Document myDoc = WordApp.Documents.Add(ref fileName, ref missing, ref doctype, ref isVisible);
                    myDoc.Activate();
     
                    object Name = "Name";
                    object VonBis = "Urlaubszeit";
                    object Gesamttage = "Tage";
      
                    myDoc.Bookmarks.get_Item(ref Name).Range.Text = player;
                    myDoc.Bookmarks.get_Item(ref VonBis).Range.Text = fDay +" " +  eDay;
                    myDoc.Bookmarks.get_Item(ref Gesamttage).Range.Text = tDays;

					WordApp.Visible = true;
            
		}
	
		
		void Button2Click(object sender, EventArgs e)
		{
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			UserManager u_man = new UserManager();
			u_man.ShowDialog();
			
		}
	}
}