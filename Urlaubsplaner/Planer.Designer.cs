/*
 * Erstellt mit SharpDevelop.
 * Benutzer: David
 * Datum: 19.09.2017
 * Zeit: 16:56
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace Urlaubsplaner
{
	partial class Planer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 1);
			this.monthCalendar1.Location = new System.Drawing.Point(46, 19);
			this.monthCalendar1.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
			this.monthCalendar1.MaxSelectionCount = 40;
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1DateChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(46, 233);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mitarbeiter";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(416, 233);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Von";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(611, 233);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Bis";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(798, 233);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "AnzahlTage";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(46, 271);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(416, 270);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label7.Location = new System.Drawing.Point(611, 268);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label8.Location = new System.Drawing.Point(798, 268);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 9;
			// 
			// button1
			// 
			this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.button1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.button1.Location = new System.Drawing.Point(782, 113);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(179, 68);
			this.button1.TabIndex = 11;
			this.button1.Text = "Beantragen";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label9.Location = new System.Drawing.Point(46, 305);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(868, 53);
			this.label9.TabIndex = 12;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label10.Location = new System.Drawing.Point(46, 370);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(745, 47);
			this.label10.TabIndex = 13;
			// 
			// dataGridView1
			// 
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(46, 420);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridView1.Size = new System.Drawing.Size(816, 186);
			this.dataGridView1.TabIndex = 15;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label11.Location = new System.Drawing.Point(276, 232);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 16;
			this.label11.Text = "Team ID";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.label12.Location = new System.Drawing.Point(276, 268);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 23);
			this.label12.TabIndex = 17;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.button2.Location = new System.Drawing.Point(783, 113);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(179, 68);
			this.button2.TabIndex = 18;
			this.button2.Text = "Genehmigen";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.button3.Location = new System.Drawing.Point(782, 39);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(179, 68);
			this.button3.TabIndex = 19;
			this.button3.Text = "User Anlegen";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold);
			this.button4.Location = new System.Drawing.Point(783, 39);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(178, 68);
			this.button4.TabIndex = 20;
			this.button4.Text = "Prüfen";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// Planer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(980, 618);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.monthCalendar1);
			this.Font = new System.Drawing.Font("Poor Richard", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Planer";
			this.Text = "Planer";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
	}
}
