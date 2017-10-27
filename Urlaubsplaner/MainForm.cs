
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Security.Cryptography;
using System.Text;


namespace Urlaubsplaner
{
	
	
	public partial class MainForm : Form
	{
	
		public MainForm()
		{
			
			InitializeComponent();
			
		}
		
		static string sha256(string randomString)
	    {
	        SHA256Managed crypt = new SHA256Managed();
	        string hash = String.Empty;
	        byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
	        foreach (byte theByte in crypto)
	        {
	            hash += theByte.ToString("x2");
	        }
	        return hash;
	    }
		
		void Button1Click(object sender, System.EventArgs e)
		{
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			DataTable dt = new DataTable();
			string log_user = textBox1.Text;
			string passwd_user = textBox2.Text; 
			string pass_hash = sha256(passwd_user);
			string query = String.Format("Select * From user where Name = '{0}' AND Hash = '{1}';", log_user, pass_hash);
			SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
		
 			
			dt.Load(command.ExecuteReader());
 			
			if(dt.Rows.Count > 0)
 			{
				string user = dt.Rows[0].Field<string>(1);
				string team = dt.Rows[0].Field<string>(2);
				
				
				Planer openForm = new Planer(user,team);
				openForm.ShowDialog();
			}
			else {
				MessageBox.Show("User oder Passwort falsch!");
			}
			
			
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
	}
	
}
