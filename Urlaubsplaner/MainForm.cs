
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
		 	//UserManager u_man = new UserManager();
		 	//Select_Form s_Form = new Select_Form();
		 	
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
				
				//MessageBox.Show("1 " + user);
				Planer openForm = new Planer(user,team);
				openForm.ShowDialog();
			}
			else {
				MessageBox.Show("User oder Passwort falsch!");
			}
			
			/*	//int permission_add_u = Convert.ToInt32(dt.Rows[0]["add_user"]);
				//int permission_app_vac = Convert.ToInt32(dt.Rows[0]["approve_vacation"]);
				string user = dt.Rows[0].Field<string>(1);
				string team = dt.Rows[0].Field<string>(2);
				
				if (permission_add_u == 1 && permission_app_vac == 1)
				{
					//MessageBox.Show("1 " + user);
					
					//MessageBox.Show("1 " + team);
					Select_Form s_Form = new Select_Form(user,team);
					s_Form.ShowDialog();
					
				}
				else
				{
					//MessageBox.Show("2 " + user);
					Planer openForm = new Planer(user,team);
					openForm.ShowDialog();
				}
	
 			}
 			else 
 			{
 				MessageBox.Show("User oder Passwort falsch!");
 				
			}
 			*/
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
