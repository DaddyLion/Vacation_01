
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;


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
		
		void Button1Click(object sender, System.EventArgs e)
		{
			String fish = "chef";
			String tank = "bozz1";
		
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			Planer openForm = new Planer();	
			UserManager u_man = new UserManager();
			
			if (textBox1.Text == fish && textBox2.Text == tank)
				u_man.ShowDialog();
			else
				
			this.Hide();
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
