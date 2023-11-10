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
		
		public Form1()
		{
			
			InitializeComponent();
			this.hd_button.Visible = false;
			this.cl_button.Visible = false;
			this.bt_mini.Visible = false;
			this.SizeChanged += Form1_Resize;
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
				notifyIcon1.Visible= false;
			}
		}
		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = DateTime.Now.ToString("hh.mm.ss tt");
			if(cbShowDate.Checked )label1.Text+=$"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
		}

		private void label1_DoubleClick(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.Sizable;
			this.TransparencyKey = Color.AliceBlue;
			this.ShowInTaskbar = true;
			this.cbShowDate.Visible = true;
			this.hd_button.Visible = true;
			this.BackColor = Color.White;
			this.cl_button.Visible = true;
			this.bt_mini.Visible = true;
		}

		private void cbShowDate_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void hd_button_Click(object sender, EventArgs e) 
		{
			
			this.FormBorderStyle = FormBorderStyle.None;
			this.ShowInTaskbar = false;
			this.cbShowDate.Visible = false;
			this.hd_button.Visible = false;
			this.BackColor = TransparencyKey;
			this.cl_button.Visible = false;
			this.bt_mini.Visible = false;
			
		}

		private void cl_button_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			notifyIcon1.Visible = false;
			notifyIcon1.BalloonTipTitle = "Clock";
			notifyIcon1.BalloonTipText = "SystemTray";
			notifyIcon1.Text = "Clock";
		}

		private void showDateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.ShowInTaskbar = false;
			this.cbShowDate.Visible = false;
			this.hd_button.Visible = false;
			this.BackColor = TransparencyKey;
			this.cl_button.Visible = false;
			this.bt_mini.Visible = false;
			label1.Text = DateTime.Now.ToString("hh.mm.ss tt");
			if (cbShowDate.Checked) label1.Text += $"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			notifyIcon1.Visible=false;
			this.WindowState = FormWindowState.Normal;
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notifyIcon1.Visible=false;
			notifyIcon1.ContextMenuStrip.Visible=false;
			notifyIcon1.ContextMenuStrip.Close();	
			this.Close();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Show();
			notifyIcon1.Visible = false;
			this.FormBorderStyle = FormBorderStyle.Sizable;
			this.TransparencyKey = Color.AliceBlue;
			this.ShowInTaskbar = true;
			this.cbShowDate.Visible = true;
			this.hd_button.Visible = true;
			this.BackColor = Color.White;
			this.cl_button.Visible = true;
			this.bt_mini.Visible = true;
			this.WindowState = FormWindowState.Normal;
		}

		private void bt_mini_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
	}
}
