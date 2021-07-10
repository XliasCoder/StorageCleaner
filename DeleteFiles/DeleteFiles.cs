using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFiles
{
    public partial class DeleteFiles : ServiceBase
    {
        private System.Timers.Timer timer;
        public int timerTick;
        public DeleteFiles()
        {
            InitializeComponent();
            double defaultTimerDelay = Convert.ToDouble(System.Configuration.ConfigurationManager.
                                AppSettings["defaultTimerDelay"]);
            timer = new System.Timers.Timer(defaultTimerDelay);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(WorkProcess);
            //WorkProcess(null, null);
        }
        public void WorkProcess(object sender, System.Timers.ElapsedEventArgs e)
        {
            string errorMsg = "";
            try
            {
                
                timer.Enabled = true;
                timerTick++;
                //timer.Interval = 60000;
                string path = Path.Combine("C:\\Users\\Elias Shamoun\\source\\repos\\DeleteFiles\\DeleteFiles", "test");
                DirectoryInfo di = new DirectoryInfo(path);
                foreach(FileInfo fi in di.GetFiles())
                {
                    fi.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                string LogPath = "C:\\Users\\Elias Shamoun\\source\\repos\\DeleteFiles\\DeleteFiles\\Log.txt";
                using (StreamWriter writer = new StreamWriter(LogPath, true))
                {
                    writer.WriteLine(string.Format("Windows Service Called on " + DateTime.Now.ToString("dd /MM/yyyy hh:mm:ss tt") + " " + timer + " " + timerTick));
                    writer.Close();
                }             
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                string LogPath = "C:\\Users\\Elias Shamoun\\source\\repos\\DeleteFiles\\DeleteFiles\\Log.txt";
                using (StreamWriter writer = new StreamWriter(LogPath, true))
                {
                    writer.WriteLine(string.Format("Windows Service Exception: " + errorMsg + " "+ DateTime.Now.ToString("dd /MM/yyyy hh:mm:ss tt") ));
                    writer.Close();
                }
                timer.Enabled = true;
            }

        }
        protected override void OnStart(string[] args)
        {
            timer.Enabled = true;
        }
        protected override void OnStop()
        {
            timer.Enabled = false;
        }
    }
}
