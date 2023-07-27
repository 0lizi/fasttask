
namespace fasttask
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.readTaskBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.appWorkPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textCommand = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.threatCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.taskcount = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.tBoxTask = new System.Windows.Forms.RichTextBox();
            this.textBoxjindu = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readTaskBtn
            // 
            this.readTaskBtn.Location = new System.Drawing.Point(200, 31);
            this.readTaskBtn.Name = "readTaskBtn";
            this.readTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.readTaskBtn.TabIndex = 0;
            this.readTaskBtn.Text = "读取任务";
            this.readTaskBtn.UseVisualStyleBackColor = true;
            this.readTaskBtn.Click += new System.EventHandler(this.readTaskBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "任务列表：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "程序目录：";
            // 
            // appWorkPath
            // 
            this.appWorkPath.ForeColor = System.Drawing.Color.Gray;
            this.appWorkPath.Location = new System.Drawing.Point(362, 71);
            this.appWorkPath.Name = "appWorkPath";
            this.appWorkPath.Size = new System.Drawing.Size(291, 21);
            this.appWorkPath.TabIndex = 4;
            this.appWorkPath.Text = "常用命令无需配置";
            this.appWorkPath.Enter += new System.EventHandler(this.appWorkPath_Enter);
            this.appWorkPath.Leave += new System.EventHandler(this.appWorkPath_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "命令参数：";
            // 
            // textCommand
            // 
            this.textCommand.ForeColor = System.Drawing.Color.Gray;
            this.textCommand.Location = new System.Drawing.Point(362, 116);
            this.textCommand.Name = "textCommand";
            this.textCommand.Size = new System.Drawing.Size(291, 21);
            this.textCommand.TabIndex = 6;
            this.textCommand.Text = "栗子：ping *r > *f.txt";
            this.textCommand.Enter += new System.EventHandler(this.textCommand_Enter);
            this.textCommand.Leave += new System.EventHandler(this.textCommand_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "线程数量：";
            // 
            // threatCount
            // 
            this.threatCount.Location = new System.Drawing.Point(362, 157);
            this.threatCount.Name = "threatCount";
            this.threatCount.Size = new System.Drawing.Size(100, 21);
            this.threatCount.TabIndex = 8;
            this.threatCount.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "消息通知：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(293, 235);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "开始任务";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "任务数量：";
            // 
            // taskcount
            // 
            this.taskcount.Location = new System.Drawing.Point(362, 27);
            this.taskcount.Name = "taskcount";
            this.taskcount.Size = new System.Drawing.Size(100, 21);
            this.taskcount.TabIndex = 13;
            this.taskcount.Text = "0";
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.Color.Black;
            this.outputTextBox.Location = new System.Drawing.Point(35, 301);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(333, 170);
            this.outputTextBox.TabIndex = 15;
            this.outputTextBox.Text = "";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(423, 235);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "结束任务";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // tBoxTask
            // 
            this.tBoxTask.ForeColor = System.Drawing.Color.Gray;
            this.tBoxTask.Location = new System.Drawing.Point(35, 60);
            this.tBoxTask.Name = "tBoxTask";
            this.tBoxTask.Size = new System.Drawing.Size(240, 198);
            this.tBoxTask.TabIndex = 17;
            this.tBoxTask.Text = "将文件拖入程序即可导入任务";
            this.tBoxTask.Enter += new System.EventHandler(this.tBoxTask_Enter);
            this.tBoxTask.Leave += new System.EventHandler(this.tBoxTask_Leave);
            // 
            // textBoxjindu
            // 
            this.textBoxjindu.BackColor = System.Drawing.Color.Black;
            this.textBoxjindu.Location = new System.Drawing.Point(423, 301);
            this.textBoxjindu.Name = "textBoxjindu";
            this.textBoxjindu.Size = new System.Drawing.Size(333, 170);
            this.textBoxjindu.TabIndex = 18;
            this.textBoxjindu.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "进度通知：";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxjindu);
            this.Controls.Add(this.tBoxTask);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.taskcount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.threatCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.appWorkPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readTaskBtn);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "本地多任务并发工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readTaskBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox appWorkPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCommand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox threatCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox taskcount;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox tBoxTask;
        private System.Windows.Forms.RichTextBox textBoxjindu;
        private System.Windows.Forms.Label label7;
    }
}

