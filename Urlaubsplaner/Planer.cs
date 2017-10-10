
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Globalization;

namespace Urlaubsplaner
{
	
	public partial class Planer : Form
	{
		
			
		public Planer()
		{
		
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
		
		void DataGrid1Navigate(object sender, NavigateEventArgs ne)
		{
			
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
		   
		   //this.label8.Text = (label6.Text + label7.Text).ToString();
			
		   this.label8.Text = Convert.ToString(diff.TotalDays + 1);
		}
		
		
	}
}
