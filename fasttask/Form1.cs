using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fasttask
{
    public partial class Form1 : Form
    {
        private List<string> targets;
        private int threadCount;
        private List<Process> runningProcesses;
        public Form1()
        {
            InitializeComponent();
            runningProcesses = new List<Process>();
        }

        private List<string> ReadTargetsFromFile(string filePath)
        {
            // 从txt文件逐行读取任务目标
            List<string> targets = new List<string>();
            tBoxTask.Text = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    targets.Add(line);
                    tBoxTask.AppendText(line + Environment.NewLine);
                }
            }
            return targets;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                if (tBoxTask.Text == "将文件拖入程序即可导入任务")
                {
                    tBoxTask.Text = "";
                    tBoxTask.ForeColor = Color.Black;
                }
                targets = ReadTargetsFromFile(files[0]);
                taskcount.Text = targets.Count.ToString();

            }
        }

        private void readTaskBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 从txt文件逐行读取任务目标
                targets = ReadTargetsFromFile(openFileDialog.FileName);

                //  显示任务目标数量
                taskcount.Text = targets.Count.ToString();
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            AppendColoredText(appWorkPath.Text, Color.Red);
            AppendColoredText("[INFO]开始任务，本次任务总数:" + threadCount.ToString(), Color.Red);
            threadCount = Convert.ToInt32(threatCount.Text);
            Queue<string> taskQueue = new Queue<string>(targets);
            object taskLock = new object();
            int completedTasks = 0;

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < threadCount; i++)
            {
                tasks.Add(RunTaskAsync(taskQueue, taskLock));
            }

            await Task.WhenAll(tasks);

            outputTextBox.Invoke((MethodInvoker)delegate
            {
                AppendColoredText("[INFO]所有任务已完成。", Color.Red);
            });
        }

        private async Task RunTaskAsync(Queue<string> taskQueue, object taskLock)
        {
            while (true)
            {
                string target;
                lock (taskLock)
                {
                    if (taskQueue.Count == 0)
                    {
                        break;
                    }
                    target = taskQueue.Dequeue();
                }
                string command = textCommand.Text.Replace("*r", target);
                string filename = target.Replace("/", "_").Replace(@"\", "_").Replace(":","_").Replace("*", "_").Replace('"', '_').Replace(">", "_").Replace("<", "_").Replace("|", "_");
                command = command.Replace("*f", filename);
                AppendColoredText("[DEBUG]当前任务:" + command, Color.White);
                
                Process process = new Process();
                
                if (appWorkPath.Text != "常用命令无需配置" && appWorkPath.Text != "")
                {
                    process.StartInfo.WorkingDirectory = appWorkPath.Text;
                }
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c " + command;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                process.Start();
                process.BeginOutputReadLine();
                await WaitForExitAsync(process);
                AppendColoredText2("[INFO]任务完成:" + target, Color.White);
            }
        }

        private Task<int> WaitForExitAsync(Process process)
        {
            var tcs = new TaskCompletionSource<int>();
            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) => tcs.TrySetResult(process.ExitCode);
            if (process.HasExited)
            {
                tcs.TrySetResult(process.ExitCode);
            }
            return tcs.Task;
        }



        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                string output = e.Data;
                // 使用Invoke从后台线程更新UI控件
                outputTextBox.Invoke((MethodInvoker)delegate
                {
                    AppendColoredText("[INFO]"+ output, Color.Green);
                });
            }
        }

        private void AppendColoredText(string text, Color color)
        {
            // 追加消息通知

            outputTextBox.Invoke((MethodInvoker)delegate
            {
                outputTextBox.SelectionStart = outputTextBox.TextLength;
                outputTextBox.SelectionLength = 0;
                outputTextBox.SelectionColor = color;
                outputTextBox.AppendText(text + Environment.NewLine);
                outputTextBox.SelectionColor = outputTextBox.ForeColor;
                // 滚动到插入符号位置
                outputTextBox.ScrollToCaret();
            });
        }

        private void AppendColoredText2(string text, Color color)
        {
            // 追加进度通知

            textBoxjindu.Invoke((MethodInvoker)delegate
            {
                textBoxjindu.SelectionStart = outputTextBox.TextLength;
                textBoxjindu.SelectionLength = 0;
                textBoxjindu.SelectionColor = color;
                textBoxjindu.AppendText(text + Environment.NewLine);
                textBoxjindu.SelectionColor = outputTextBox.ForeColor;
                // 滚动到插入符号位置
                textBoxjindu.ScrollToCaret();
            });
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // 拖入增加任务
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                targets = ReadTargetsFromFile(files[0]);
                taskcount.Text = targets.Count.ToString();
                if (tBoxTask.Text == "将文件拖入程序即可导入任务")
                {
                    tBoxTask.Text = "";
                    tBoxTask.ForeColor = Color.Black;
                }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 窗体关闭时清理线程
            foreach (Process process in runningProcesses)
            {
                process.Kill();
            }
            runningProcesses.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 关闭线程
            foreach (Process process in runningProcesses)
            {
                process.Kill();
            }
            runningProcesses.Clear();
            AppendColoredText("[INFO]任务已清空。", Color.Red);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置线程数量
            threadCount = 10;

            // 初始化任务列表
            targets = new List<string>();

            AppendColoredText("[INFO]欢迎使用本地多任务并发工具\r\n[INFO]将文件拖入程序即可导入任务", Color.Green);
        }

        private void appWorkPath_Enter(object sender, EventArgs e)
        {
            if (appWorkPath.Text == "常用命令无需配置")
            {
                appWorkPath.Text = "";
                appWorkPath.ForeColor = Color.Black;
            }
        }

        private void appWorkPath_Leave(object sender, EventArgs e)
        {
            if (appWorkPath.Text == "")
            {
                appWorkPath.Text = "常用命令无需配置";
                appWorkPath.ForeColor = Color.Gray;
            }
        }

        private void textCommand_Enter(object sender, EventArgs e)
        {
            if (textCommand.Text == "栗子：ping *r > *f.txt")
            {
                textCommand.Text = "";
                textCommand.ForeColor = Color.Black;
            }
        }

        private void textCommand_Leave(object sender, EventArgs e)
        {
            if (textCommand.Text == "")
            {
                textCommand.Text = "栗子：ping *r > *f.txt";
                textCommand.ForeColor = Color.Gray;
            }
        }

        private void tBoxTask_Enter(object sender, EventArgs e)
        {
            if (tBoxTask.Text == "将文件拖入程序即可导入任务")
            {
                tBoxTask.Text = "";
                tBoxTask.ForeColor = Color.Black;
            }
        }

        private void tBoxTask_Leave(object sender, EventArgs e)
        {
            if (tBoxTask.Text == "")
            {
                tBoxTask.Text = "将文件拖入程序即可导入任务";
                tBoxTask.ForeColor = Color.Gray;
            }
        }
    }
}
