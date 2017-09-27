
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
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public MainForm()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
			//String fish = "chef";
			//String tank = "bozz1";
		 	Planer openForm = new Planer();
		 	
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			DataTable dt = new DataTable();
			string log_user = textBox1.Text;
			string passwd_user = textBox2.Text; 
			string pass_hash = sha256(passwd_user);
			//string query = String.Format("Select Name From user where Name = '{0}' AND Hash = '{1}';", log_user, pass_hash);
			 
			// SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
			// 			dt.Load(command.ExecuteReader());
			// 			
			// 			if(command.ExecuteReader().HasRows)
			// 			{
			// 				MessageBox.Show("Läuft bei dir");
			// 			}
			// 			else 
			// 			{
			// 				MessageBox.Show("NOOOOOOO");
			// 			}
			// 	
			
			string query = String.Format("Select * From user where Name = '{0}' AND Hash = '{1}';", log_user, pass_hash);			
			SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
			 			dt.Load(command.ExecuteReader());
			 			
						if(dt.Rows.Count > 0)
			 			{
						MessageBox.Show("Läuft bei dir");
						DataRow user = dt.Rows[0];
						user["Name"]
						
						
			 			}
			 			else 
			 			{
			 				MessageBox.Show("NOOOOOOO");
						}
			 			
			 			
			
			 	
				
			
				
			
			//dt.Load();
			//this.label5.Text = dt.Rows[0]["Hash"].ToString();
			
			
			//this.label4.Text = dt.Rows[23]["Hash"].ToString();
			//this.label4 = dt;
			//this.label4.Text = dt;
			
				
			//string validation = sha256(textBox1.Text + textBox2.Text);
			
			
		    //string hAsH = label3.Text;
		    
		   /*  SQLiteCommand command = new SQLiteCommand(m_dbConnection);
		    
		     string login = command.CommandText("Select Name From user where name = @param1;");
			command.CommandType = CommandType.Text;
		    command.Parameters.Add(new SQLiteParameter("@param1",log_user));
		    command.Parameters.Add(new SQLiteParameter("@param2",passwd_user));
		    //command.Parameters.Add(new SQLiteParameter("@param3",hAsH));
		    command.ExecuteNonQuery();
		    
		 	
			UserManager u_man = new UserManager();
			
			if (textBox1.Text == fish && textBox2.Text == tank)
				u_man.ShowDialog();
			else
			
			this.Hide();
			openForm.ShowDialog();
			this.Close();
		    
		    
		    
			//this.label4.Text = validation;
			
			
			//Planer openForm = new Planer();	
			*/
			
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
		}
	}
	
}
