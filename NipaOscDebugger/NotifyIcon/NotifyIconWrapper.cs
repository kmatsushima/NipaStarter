using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NipaStarter;

namespace NotifyIcon
{
	public partial class NotifyIconWrapper : Component
	{
		public MainWindow mainWindow = new MainWindow();

		public NotifyIconWrapper()
		{
			InitializeComponent();
			toolStripMenuItemShow.Click += toolStripMenuItemShow_Click;
			toolStripMenuItemExit.Click += toolStripMenuItemExit_Click; 

            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
        }

		public NotifyIconWrapper(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		void notifyIcon1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ShowWindow();
		}

		void toolStripMenuItemExit_Click(object sender, EventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}


		void toolStripMenuItemShow_Click(object sender, EventArgs e)
		{
			ShowWindow();
		}

		private void ShowWindow()
		{
			if (mainWindow.WindowState == System.Windows.WindowState.Minimized)
				mainWindow.WindowState = System.Windows.WindowState.Normal;

			mainWindow.Show();
			mainWindow.Activate();

			mainWindow.ShowInTaskbar = true;
		}
	}
}
