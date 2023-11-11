using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
	public partial class Form1 : Form
	{
		bool visible_controls;
		bool show_date;
		
		public Form1()
		{
			
			InitializeComponent();
			this.Location = new System.Drawing.Point
				(
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Right - this.Width - 50,
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Top + 100
				);
			show_date = false;
			visible_controls = false;
			btnHideControls.Visible = false;
			btnClose.Visible = false;
			this.btnHideControls.Visible = false;
			this.btnClose.Visible = false;
			this.bt_mini.Visible = false;
			this.SizeChanged += Form1_Resize;
		}
		private void SetShowDate(bool show_date)
		{
			this.show_date = show_date;
			cbShowDate.Checked = show_date;
			showDateToolStripMenuItem.Checked = show_date;
		}
		private void SetControlsVisibility(bool visible_controls)
		{
			this.visible_controls = visible_controls;
			this.FormBorderStyle = visible_controls ? FormBorderStyle.Sizable : FormBorderStyle.None;
			this.TransparencyKey = visible_controls ? Color.AliceBlue : SystemColors.Control;

			this.ShowInTaskbar = visible_controls;
			this.cbShowDate.Visible = visible_controls;

			this.btnHideControls.Visible = visible_controls;
			this.btnClose.Visible = visible_controls;
			//this.notifyIcon1.Visible = !visible_controls;
			this.toolStripMenuItem1.Checked = visible_controls;
		}
		private void Form1_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon1.Visible = true;
				notifyIcon1.ShowBalloonTip(1000);
			}
			else if (FormWindowState.Normal == WindowState)
			{
				notifyIcon1.Visible= true;
			}
		}
		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = DateTime.Now.ToString("hh.mm.ss tt");
			if(cbShowDate.Checked )label1.Text+=$"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
			notifyIcon1.Text = DateTime.Now.ToString("hh.mm.ss");
		}

		private void label1_DoubleClick(object sender, EventArgs e)
		{
			/*this.FormBorderStyle = FormBorderStyle.Sizable;
			this.TransparencyKey = Color.AliceBlue;
			this.ShowInTaskbar = true;
			this.cbShowDate.Visible = true;
			this.btnHideControls.Visible = true;
			this.BackColor = Color.White;
			this.btnClose.Visible = true;
			this.bt_mini.Visible = true;
			this.notifyIcon1.Visible = false;*/
			SetControlsVisibility(true);
		}

		private void cbShowDate_CheckedChanged(object sender, EventArgs e)
		{
			SetShowDate(cbShowDate.Checked);
			
		}

		private void hd_button_Click(object sender, EventArgs e) 
		{

			/*this.FormBorderStyle = FormBorderStyle.None;*/
			//this.TransparencyKey = SystemColors.Control;
			/*this.ShowInTaskbar = false;
			this.cbShowDate.Visible = false;
			this.btnHideControls.Visible = false;
			this.BackColor = TransparencyKey;
			this.btnClose.Visible = false;
			this.bt_mini.Visible = false;
			this.notifyIcon1.Visible = true;*/
			SetControlsVisibility(false);

		}

		private void cl_button_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			notifyIcon1.Visible = false;
			notifyIcon1.BalloonTipTitle = "Clock";
			notifyIcon1.BalloonTipText = "SystemTray";
			
		}

		private void showDateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			this.show_date = showDateToolStripMenuItem.Checked;
			SetShowDate(show_date);


			/*this.Show();
			this.WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.ShowInTaskbar = false;
			
			this.btnHideControls.Visible = false;
			this.BackColor = TransparencyKey;
			this.btnClose.Visible = false;
			this.bt_mini.Visible = false;*/

		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			label1_DoubleClick(sender, e);
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			this.Close();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if(toolStripMenuItem1.Checked) label1_DoubleClick(sender, e);
			else hd_button_Click(sender, e);

			/*this.Show();
			notifyIcon1.Visible = true;
			this.FormBorderStyle = FormBorderStyle.None;
			this.BackColor = TransparencyKey;
			this.ShowInTaskbar = true;
			this.cbShowDate.Visible = true;
			this.btnHideControls.Visible = true;
			this.btnClose.Visible = true;
			this.bt_mini.Visible = true;
			this.WindowState = FormWindowState.Normal;*/
		}

		private void bt_mini_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		
	}
}
