using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commercial_Converter
{
    public partial class frmMain : Form
    {

        private string ffmpeg_location = @"C:\ffmpegz\ffmpeg.exe";
        private string temp_folder = @"j:\video\temp";

        private void AddLog(string msg)
        {

            try
            {
                if (!InvokeRequired)
                {
                    txtLog.AppendText(DateTime.Now.ToString() + " " + msg + "\r\n");
                }
                else
                {
                    Invoke(new Action<string>(AddLog), msg);
                }
            }
            catch { }

        }

        private void KillFFmpegProcess()
        {
            // Get all processes named "ffmpeg"
            Process[] processes = Process.GetProcessesByName("ffmpeg");

            foreach (Process process in processes)
            {
                try
                {
                    // Kill the process
                    process.Kill();
                    process.WaitForExit(); // Wait for the process to exit
                    Console.WriteLine("Killed process ID: " + process.Id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error killing process ID: " + process.Id + " - " + ex.Message);
                }
            }

            if (processes.Length == 0)
            {
                Console.WriteLine("No ffmpeg processes found.");
            }
        }

        private string getScreenShot(string file, string pos, bool overright = false)
        {

            string filename = Path.GetFileName(file);
            if (File.Exists(temp_folder + "\\screen_" + filename + pos + ".png"))
            {
                return temp_folder + "\\screen_" + filename + pos + ".png";
            }


            if (!File.Exists(file))
            {
                return null;
            }

            //if (File.Exists(temp_folder + "\\screen_" + pos + ".jpg"))
            //{
            //return temp_folder + "\\screen_" + pos + ".jpg";
            //}
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            //string filename = file;
            //if (File.Exists(temp_folder + "\\screen_" + filename + pos + ".png")) File.Delete(temp_folder + "\\screen_" + pos + ".png");
            //get duration
            //proc.StartInfo.Arguments = "-ss " + pos + " -i " + "\"" + filename + "\" -vframes 1 -q:v 2 \"" + temp_folder + "\\screen_" + TimeSpan.Parse(pos).TotalSeconds.ToString() + ".jpg\"";\
            //            AddLog((overright ? "-y " : "") + "-ss " + TimeSpan.FromSeconds(Double.Parse(pos)).ToString() + " -i " + "\"" + file + "\" -vframes 1 -q:v 2 \"" + temp_folder + "\\screen_" + filename + pos + ".png\"");

            proc.StartInfo.Arguments = (overright ? "-y " : "") + "-ss " + pos + " -i " + "\"" + file + "\" -vframes 1 -q:v 2 \"" + temp_folder + "\\screen_" + filename + TimeSpan.Parse(pos).Ticks.ToString() + ".png\"";
            AddLog(proc.StartInfo.Arguments);
            //proc.StartInfo.RedirectStandardError = true;
            //proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            if (!proc.Start())
            {
                AddLog("Error starting");
            }

            DateTime st = DateTime.Now;
            //StreamReader reader = proc.StandardError;
            //while (!File.Exists(temp_folder + "\\screen_" + filename + pos + ".png"))
            while (processRunning(proc.Id) != -1)
            {

                TimeSpan diff = DateTime.Now - st;
                Debug.WriteLine(diff.TotalSeconds);
                if (diff.TotalSeconds > 5 || File.Exists(temp_folder + "\\screen_" + filename + TimeSpan.Parse(pos).Ticks.ToString() + ".png"))
                {
                    proc.Close();
                    break;
                }

                System.Threading.Thread.Sleep(500);
                //break;
            }

            /*
            string line;
            DateTime start = DateTime.Now;
            while ((line = reader.ReadLine()) != null)
            {
                AddVLog(line.ToString());
                TimeSpan diff = DateTime.Now - start;
                AddVLog(diff.TotalSeconds.ToString());
                if (diff.TotalSeconds>5) break;
                //AddVLog(DateTime.Now.Ticks.ToString() + " - " + start.Ticks.ToString() + " = " + (DateTime.Now.Ticks -  start.Ticks).ToString());
            }
            */
            //Console.ReadKey();
            proc.Close();



            try
            {
                proc.Kill();
            }
            catch { }

            KillFFmpegProcess();

            //return temp_folder + "\\screen_" + TimeSpan.Parse(pos).TotalSeconds.ToString() + ".jpg";
            if (!File.Exists(temp_folder + "\\screen_" + filename + TimeSpan.Parse(pos).Ticks.ToString() + ".png")) return null;
            return temp_folder + "\\screen_" + filename + TimeSpan.Parse(pos).Ticks.ToString() + ".png";


        }

        private string getVideoDuration(string file)
        {
            //ffprobe -v error -show_entries stream=width,height -of csv=p=0:s=x input.m4v
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;

            proc.StartInfo.Arguments = "-i \"" + filename + "\"" + "";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            //proc.StartInfo.CreateNoWindow = true;

            if (!proc.Start())
            {
                AddLog("Error starting");
            }
            StreamReader reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //AddLog(line);
                int a = line.IndexOf("Duration");
                if (a >= 0)
                {
                    string dur = "";
                    int b = line.IndexOf(",", a + 1);
                    dur = line.Substring(a + 10, b - a - 10);
                    return dur;
                }

            }
            proc.Close();
            try
            {
                proc.Kill();
            }
            catch { }

            return null;
        }

        private int processRunning(int procId)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id == procId)
                {
                    return theprocess.Id;
                }
            }
            return -1;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFilePicker_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                foreach (String file in openFileDialog1.FileNames)
                {
                    if (File.Exists(file))
                    {

                        lstFiles.Items.Add(file);
                    }
                }
            }

        }

        static double GetMedian(List<int> numbers)
        {
            if (numbers.Count == 0)
                throw new InvalidOperationException("Cannot compute median for an empty list.");

            var sortedNumbers = numbers.OrderBy(n => n).ToList();
            int count = sortedNumbers.Count;
            int middleIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of elements: average the two middle elements
                return (sortedNumbers[middleIndex - 1] + sortedNumbers[middleIndex]) / 2.0;
            }
            else
            {
                // Odd number of elements: take the middle element
                return sortedNumbers[middleIndex];
            }
        }

        private bool isProcessRunning = false;

        private bool verboseLogging = false;


        void process_Exited(object sender, EventArgs e)
        {
            // Handle exit here
            AddLog("exited!!!!!!!");
            isProcessRunning = false;
        }


        private TimeSpan procTDur = new TimeSpan();

        void ProccesErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            if (isProcessRunning)
            {

                if (picStatus.BackColor == Color.Green && (DateTime.Now.Ticks - (long)picStatus.Tag) > 5000000)
                {
                    //AddLog("A " + DateTime.Now.Ticks.ToString() + ", " + picStatus.Tag.ToString());
                    picStatus.Tag = DateTime.Now.Ticks;
                    picStatus.BackColor = Color.Cyan;
                    picStatusB.BackColor = Color.Green;
                }
                else if (picStatus.BackColor != Color.Green && (DateTime.Now.Ticks - (long)picStatus.Tag) > 5000000)
                {
                    //AddLog("B " + DateTime.Now.Ticks.ToString() + ", " + picStatus.Tag.ToString());
                    picStatus.Tag = DateTime.Now.Ticks;
                    picStatus.BackColor = Color.Green;
                    picStatusB.BackColor = Color.Cyan;
                }
            }
            // Handle error here


        }
        void ProccesOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Handle output here using e.Data
            if (e.Data != null)
            {
                AddLog("Err: " + e.Data.ToString());
            }
        }

        private int runProccess(string args, bool verbose = false)
        {
            if (isProcessRunning)
            {
                AddLog("***** Process running, please try again later ********");
                return -1;
            }

            verboseLogging = verbose;
            AddLog(args);
            isProcessRunning = true;

            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            proc.StartInfo.Arguments = "-y " + args;
            AddLog(proc.StartInfo.Arguments);
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;

            proc.EnableRaisingEvents = true;

            proc.Exited += process_Exited;
            proc.OutputDataReceived += ProccesOutputDataReceived;
            proc.ErrorDataReceived += ProccesErrorDataReceived;

            proc.Start();

            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            int procID = proc.Id;
            while (true)
            {
                Application.DoEvents();
                int info = processRunning(procID);
                if (info == -1)
                {
                    picStatus.BackColor = Color.Red;
                    break;
                }
                else
                {
                    //picStatus.BackColor = Color.Green;
                }
            }

            isProcessRunning = false;

            //proc.Close();

            try
            {
                //proc.Kill();
            }
            catch { }

            verboseLogging = false;
            return proc.Id;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for(int i=0;i<lstFiles.Items.Count;i++)
            {
                lblStatus.Text = "Converting file " + (i+1).ToString() + " of " + lstFiles.Items.Count.ToString();
                Application.DoEvents();
                string curFile = lstFiles.Items[i].ToString();
                //	ffmpeg -ss 00:00:28 -i "%%~dpnxF" -vframes 1 -q:v 2 "%%~dpnF.png"
                string length = getVideoDuration(curFile);
                AddLog("Got video length: " + length);
                TimeSpan ts = TimeSpan.Parse(length);
                TimeSpan dv = TimeSpan.FromTicks(ts.Ticks / 8);

                List<int> x1s = new List<int>();
                List<int> x2s = new List<int>();
                TimeSpan dvs = TimeSpan.FromTicks(0);
                for (int x=0;x<8;x++)
                {
                    dvs += dv;
                    string scrShot = getScreenShot(curFile, dvs.ToString());
                    if (scrShot == null) continue;
                    AddLog("Got screen: " + scrShot);
                    picSnap.Load("file://" + scrShot);

                    int height = picSnap.Height;
                    int width = picSnap.Width;
                    int y = picSnap.Height/2;

                    Bitmap bp = new Bitmap(picSnap.Image);

                    int x1 = 0;
                    int x2 = 0;

                    for (int pos = 0; pos < width; pos++)
                    {
                        Color gp = bp.GetPixel(pos, y);

                        if (gp.R < 30 && gp.G < 30 && gp.B < 30)
                        {
                            //AddLog(pos.ToString() + "," + y.ToString() + " " + gp.ToString());
                        }
                        else
                        {

                            AddLog("x1 pos = " + pos.ToString());
                            x1 = pos;
                            x1s.Add(x1);
                            break;
                        }
                    }

                    for (int pos = width-1; pos > 0; pos--)
                    {
                        Color gp = bp.GetPixel(pos, y);

                        if (gp.R < 30 && gp.G < 30 && gp.B < 30)
                        {
                            //AddLog(pos.ToString() + "," + y.ToString() + " " + gp.ToString());
                        }
                        else
                        {

                            AddLog("x2 pos = " + pos.ToString());
                            x2 = pos;
                            x2s.Add(x2);
                            break;
                        }
                    }





                }

                foreach(int d in x2s)
                {
                    AddLog(d.ToString());
                }

                AddLog("X1 Position: " + GetMedian(x1s).ToString());
                AddLog("X2 Position: " + GetMedian(x2s).ToString());
                
                //ffmpeg -i input.mp4 -vf "crop=100:1000,scale=640:480" output.mp4
                double nwidth = GetMedian(x2s) - GetMedian(x1s);
                double nheight = picSnap.Height;
                runProccess("-i \"" + curFile + "\" -vf \"crop=" + nwidth.ToString() + ":in_h-20:" + GetMedian(x1s).ToString() + ":10,scale=640:480,setsar=1\" -r 30 \"" + curFile + ".mp4\"");

                while(isProcessRunning)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                }
                //runProccess("-i \"" + curFile + "\" -vf \"crop=0:0:100:100, scale=640:480\" -r 30 \"" + curFile + ".mp4\"");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picStatus.Tag = DateTime.Now.Ticks;
            picStatusB.Tag = DateTime.Now.Ticks;
        }

        private void picStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
