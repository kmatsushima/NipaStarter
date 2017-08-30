using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace NipaStarter
{
    class FrontApplication
    {
        static Process _Process;

        public delegate void AppStartHandler();
     //   public static event AppStartHandler OnAppStart;

        public static void Startup(string appPath, int screenWidth, int screenHeight, string logDirectryPath = "")
        {
            FileInfo appFile = new FileInfo(appPath);

            // ------------------------------ 動いているプロセスがあればすべて強制終了

            try
            {
                if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(appFile.Name)).Count() > 0)
                {
                    foreach (var item in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(appFile.Name)))
                    {
                        if (item != null && !item.HasExited)
                            item.Kill();
                    }
                }
            }
            catch (Exception e)
            {
          
            }


            if (_Process != null && !_Process.HasExited)
            {
                Process[] pname = Process.GetProcessesByName(_Process.ProcessName);

                if (pname != null && pname.Length != 0)
                    _Process.Kill();
            }

            //---------------------------------- Unityのログファイルの管理

            //DirectoryInfo unityLogDir = new DirectoryInfo(Path.Combine(logDirectryPath, "Unity_AppLog"));
            //if (unityLogDir.Exists == false)
            //    unityLogDir.Create();


            var logFileName = "UnityLog_" + System.DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";

            //----------------------------------  アプリ起動時のイベント発行

            //// ----- 。OSC経由で起動すると別スレッドになりxaml.cs呼び出しが失敗するので例外処理
            //try
            //{
            //    if (OnAppStart != null)
            //        OnAppStart();
            //}
            //catch (Exception)
            //{

            //}

            //---------------------------------- コマンドライン引数を渡して起動

            ProcessStartInfo startInfo = new ProcessStartInfo(appPath);

            if(logDirectryPath!="" && Directory.Exists(logDirectryPath))
                startInfo.Arguments = string.Format("-popupwindow -screen-width {0} -screen-height {1} -logFile {2}",
                                                    screenWidth,
                                                    screenHeight,
                                                    Path.Combine(logDirectryPath, logFileName)
                                                    );
            else
                startInfo.Arguments = string.Format("-popupwindow -screen-width {0} -screen-height {1}",
                                    screenWidth,
                                    screenHeight
                                    );

            _Process = Process.Start(startInfo);
        }
    }
}
