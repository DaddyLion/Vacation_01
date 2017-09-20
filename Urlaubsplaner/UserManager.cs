using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Urlaubsplaner
{
	/// <summary>
	/// Description of UserManager.
	/// </summary>
	public partial class UserManager : Form
	{
		public UserManager()
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
		
				
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			 
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
			string bla = sha256(textBox1.Text + textBox2.Text + label3.Text);
			this.label3.Text = bla;
			
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			DataTable dt = new DataTable();
			
			string add_user = textBox1.Text;
			string aBteiLung = textBox2.Text; 
		    string hAsH = label3.Text;
		    
		    
			//string sql = "insert into user (Name, team_id, Hash) Values (add_user,a)";
			
		    SQLiteCommand command = new SQLiteCommand(m_dbConnection);
		    
		    command.CommandText = "Insert Into user (Name,team_id,Hash) Values (@param1,@param2,@param3)";
			command.CommandType = CommandType.Text;
		    command.Parameters.Add(new SQLiteParameter("@param1",add_user));
		    command.Parameters.Add(new SQLiteParameter("@param2",aBteiLung));
		    command.Parameters.Add(new SQLiteParameter("@param3",hAsH));
		    command.ExecuteNonQuery();
		    
		 		
		}
		
		void Label3Click(object sender, EventArgs e)
		{
			
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
	}
}
