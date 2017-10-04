
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Urlaubsplaner
{
	/// <summary>
	/// Description of Select_Form.
	/// </summary>
	public partial class Select_Form : Form
	{
			Planer openForm = new Planer();
		 	UserManager u_man = new UserManager();
		public Select_Form()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			openForm.ShowDialog();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			u_man.ShowDialog();
		}
	}
}
