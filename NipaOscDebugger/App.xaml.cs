using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using NotifyIcon;

namespace NipaStarter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NotifyIconWrapper component;

        ////////////////////////////////////////////////////////////////////////////////
        ///<summary>
        ///[ROLE] : 全体の初期化処理
        ///[note] : 
        ///</summary> 
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // ------------------------------ 動いているプロセスがあれば自分以外すべて強制終了

            var prosName = System.AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");
            var processes = Process.GetProcessesByName(prosName);
            processes = processes.OrderBy(v => v.StartTime).ToArray();
            try
            {
                if (Process.GetProcessesByName(prosName).Count() > 1)
                {
                    for (int i = 0; i < processes.Count() - 1; i++)
                    {
                        if (processes[i] != null && !processes[i].HasExited)
                            processes[i].Kill();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            //---------------------------------- 

            component = new NotifyIconWrapper();

        }


        protected override void OnExit(ExitEventArgs e)
        {
            component.mainWindow.OnExitApp();
            base.OnExit(e);
        }

    }
}