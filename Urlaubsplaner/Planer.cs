

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Text;
using System.Globalization;

using Word = Microsoft.Office.Interop.Word;
using Outlook = Microsoft.Office.Interop.Outlook;



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
			this.button1.Visible = false;
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
				this.button4.Visible = false;
				this.dataGridView1.DataSource = dt_all;
				
			}
			
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
			
			
			this.label6.Text = 
			monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
			this.label7.Text = 
			monthCalendar1.SelectionRange.End.Date.ToShortDateString();
			
			this.label8.Text = Convert.ToString(diff.TotalDays + 1);
		}
	
		void Button1Click(object sender, EventArgs e)
		{
			
			DataTable dt = new DataTable();
			
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			
			m_dbConnection.Open();
			
			string player = this.label5.Text;
			string fDay = this.label6.Text;
			string eDay = this.label7.Text;
			string tDays = this.label8.Text;
			string vIssues = this.label9.Text;
			string vApplik = "Ja";
			DateTime dTime =  DateTime.ParseExact(fDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			DateTime dTime2 =  DateTime.ParseExact(eDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			string newTime = dTime.ToString("yyyyMMdd");
			string newTime2 = dTime2.ToString("yyyyMMdd");
			
			string tId = this.label12.Text;
			
			string query2 = String.Format("Insert Into Urlaubsübersicht (User,Von,Bis,Entspricht_Tage,Team_ID,Beantragt) Values ('{0}','{1}','{2}','{3}','{4}','{5}');",player,newTime,newTime2,tDays,tId,vApplik);
			
			SQLiteCommand command = new SQLiteCommand(query2, m_dbConnection);
			
			command.ExecuteNonQuery();
 			
 			this.label9.Text = "Der Urlaub für " + player + " in der Zeit von " + fDay  + " bis " + eDay  +" wurde beantragt";
 			this.label10.Text = "Das entspricht " + tDays + " Urlaubstage";
 				
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
			
			DataTable dt3 = new DataTable();
			DataTable dt5 = new DataTable();
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
				string approved = "Ja";
				
				string gridQuery1 = String.Format("UPDATE Urlaubsübersicht SET Genehmigt = '{0}' Where Antrags_ID = '{1}';", 
																			approved,
																			((DataTable)this.dataGridView1.DataSource).Rows[this.dataGridView1.SelectedCells[0].RowIndex]["Antrags_ID"]
																			);
				
				string gridQuery2 = String.Format("SELECT * FROM Urlaubsübersicht;");
				SQLiteCommand command3 = new SQLiteCommand(gridQuery1, m_dbConnection);
				command3.ExecuteNonQuery();
				SQLiteCommand command4 = new SQLiteCommand(gridQuery2, m_dbConnection);
				dt3.Load(command4.ExecuteReader());
				
				string msg = String.Format("Row: {0}, Column: {1}",
				dataGridView1.CurrentCell.Value,
				dataGridView1.CurrentCell.ColumnIndex);
				
				
				
				// Telegram Message:
				WebClient client = new WebClient();
				string who = dataGridView1.CurrentCell.Value.ToString();
				string von = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				string bis = dataGridView1.CurrentRow.Cells[2].Value.ToString();
				
				Stream s = client.OpenRead(String.Format("https://api.telegram.org/bot442786666:AAHPtI0yvYMdiYwkOg6mm9222JSm6AGTPBQ/sendMessage?chat_id=-244911442&text= Hallo Zusammen. Denkt bitte daran das {0} in der Zeit von {1} bis {2} Urlaub hat;",who,von,bis));
				
				//this.dataGridView1.DataSource = dt3;
				
				// Email 
				Microsoft.Office.Interop.Outlook.NameSpace lo_NSpace;
				Microsoft.Office.Interop.Outlook.MAPIFolder lo_Folder;
				Microsoft.Office.Interop.Outlook.Application lo_OutApp;
				Microsoft.Office.Interop.Outlook.MailItem lo_Item;
	
				lo_OutApp = new Microsoft.Office.Interop.Outlook.Application();
				
				lo_NSpace = lo_OutApp.GetNamespace("MAPI");
				
				lo_Folder = lo_NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
				
				lo_Item = (Microsoft.Office.Interop.Outlook.MailItem)lo_Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
				
				lo_Item.To = who;
				
				lo_Item.Subject = "Urlaub";
				lo_Item.Body = "Hallo "+ who + " ich habe deinen Urlaub in der Zeit vom " + von + " bis "+ bis +" genehmigt.";
				//NachrichtenFormat
				lo_Item.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatRichText;
				
				//Anzeigen modal
				lo_Item.Display(true);
				
				//Senden der Mail
				lo_Item.Send();

				
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			UserManager u_man = new UserManager();
			u_man.ShowDialog();
			
		}
		
		void Button4Click(object sender, EventArgs e)
		{
        					
			DataTable dt2 = new DataTable();
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			
			string fDay = this.label6.Text;
			string eDay = this.label7.Text;
			DateTime dTime =  DateTime.ParseExact(fDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			DateTime dTime2 =  DateTime.ParseExact(eDay,"dd'.'MM'.'yyyy",CultureInfo.InvariantCulture);
			string newTime = dTime.ToString("yyyyMMdd");
			string newTime2 = dTime2.ToString("yyyyMMdd");
			string tId = this.label12.Text;
			string gridQuery = String.Format("Select * From Urlaubsübersicht where Von BETWEEN '{0}' AND  '{1}' AND Team_ID = '{2}';", newTime,newTime2,tId);
			
			SQLiteCommand command1 = new SQLiteCommand(gridQuery, m_dbConnection);
			
			dt2.Load(command1.ExecuteReader());	
			
			DataGridView dataGridView1 = new DataGridView();
			
 			this.dataGridView1.DataSource = dt2;
 			this.button1.Visible = true;
		}
	}
}