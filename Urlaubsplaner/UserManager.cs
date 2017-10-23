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
			
			string bla = sha256(textBox3.Text);
			
			SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=new_DB.sqlite;Version=3;");
			m_dbConnection.Open();
			
			string user_name = textBox1.Text;
			string aBteiLung = textBox2.Text; 
		    string add_user = textBox4.Text;
			string id = textBox5.Text;
		    string approve_vacation = textBox6.Text;
		      	
			

			
		    SQLiteCommand command = new SQLiteCommand(m_dbConnection);
		    
		    command.CommandText = "Insert Into user (Name,team_id,Hash,add_user,ID,approve_vacation) Values (@param1,@param2,@param3,@param4,@param5,@param6)";
			command.CommandType = CommandType.Text;
		    command.Parameters.Add(new SQLiteParameter("@param1",user_name));
		    command.Parameters.Add(new SQLiteParameter("@param2",aBteiLung));
		    command.Parameters.Add(new SQLiteParameter("@param3",bla));
		    command.Parameters.Add(new SQLiteParameter("@param4",add_user));
		    command.Parameters.Add(new SQLiteParameter("@param5",id));
		    command.Parameters.Add(new SQLiteParameter("@param6",approve_vacation));
		    command.ExecuteNonQuery();
		    
		 		
		}
		
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
	}
}
