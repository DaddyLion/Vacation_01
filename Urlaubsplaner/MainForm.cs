
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
			String fish = "chef";
			String tank = "bozz1";
		
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			string sql = "select Hash from user;";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);			
			DataTable dt = new DataTable();
			dt.Load(command.ExecuteReader());
			
			//this.label4.Text = dt.Rows[23]["Hash"].ToString();
			//this.label4 = dt;
			//this.label4.Text = dt;
			
			
			string validation = sha256(textBox1.Text + textBox2.Text);
			
		    
			//this.label4.Text = validation;
			
			
			Planer openForm = new Planer();	
			UserManager u_man = new UserManager();
			
			if (textBox1.Text == fish && textBox2.Text == tank)
				u_man.ShowDialog();
			else
				
			//this.Hide();
			openForm.ShowDialog();
			this.Close();
			
			
			
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
		}
	}
	
}
