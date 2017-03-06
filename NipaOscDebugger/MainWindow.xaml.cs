using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rug.Osc;
using System.IO;
using System.ComponentModel;
using System.Net;
using Slack.Webhooks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace NipaStarter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const string StartCode = "STARTAPP";

        // DLL インポートの宣言
        [DllImport("kernel32.dll")]
        private extern static int TerminateProcess(IntPtr hProcess, UInt32 uExitCode);


        public MainWindow()
        {
            InitializeComponent();
            UpdateSettings();
            InitializeOSC();

            if (Properties.Settings.Default.AutoStart)
                StartApp();
        }

        #region ===================================================================  OSC


        private void InitializeOSC()
        {
            OscManager.Instance.AddressManager.Attach("/nipa/starter", StartApp);
        }

        void StartApp(OscMessage oscMsg)
        {
            Console.WriteLine("got osc " + oscMsg[0].ToString());
            if (oscMsg[0].ToString() == StartCode)
                StartApp();
        }

        #endregion
        #region ===================================================================  button actions

        private void Button_start_Click(object sender, RoutedEventArgs e)
        {
            StartApp();
        }

        private void button_apply_Click(object sender, RoutedEventArgs e)
        {
            UpdateSettings();
        }


        #endregion
        #region ===================================================================  Settings


        void UpdateSettings()
        {
            if (textBox_appPath.Text != "")
                Properties.Settings.Default.AppPath = textBox_appPath.Text;

            if (textBox_width.Text != "")
            {
                int result;
                if (int.TryParse(textBox_width.Text, out result))
                      Properties.Settings.Default.AppWidth = result;
            }

            if (textBox_height.Text != "")
            {
                int result;
                if (int.TryParse(textBox_height.Text, out result))
                    Properties.Settings.Default.AppHeight = result;
            }

            if (textBox_unityLogPath.Text != "")
                Properties.Settings.Default.UnityLogPath = textBox_unityLogPath.Text;

            Properties.Settings.Default.AutoStart = checkBox_awakeStart.IsChecked ?? true;
            Properties.Settings.Default.KillExp = checkBox_killExplorer.IsChecked ?? true;

            Properties.Settings.Default.Save();
        }

        #endregion
        #region ===================================================================  Others

        void StartApp()
        {
            FrontApplication.Startup(Properties.Settings.Default.AppPath, Properties.Settings.Default.AppWidth, Properties.Settings.Default.AppHeight, Properties.Settings.Default.UnityLogPath);

            if(Properties.Settings.Default.KillExp)
            {
                foreach (Process oProcess in Process.GetProcessesByName("EXPLORER"))
                {
                    TerminateProcess(oProcess.Handle, 1);
                }
            }
        }

        public void OnExitApp()
        {
            OscManager.Instance.AddressManager.Attach("/nipa/starter", StartApp);
            OscManager.Instance.Dispose();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = System.Windows.WindowState.Minimized;
            this.ShowInTaskbar = false;
        }


        #endregion


    }
}
