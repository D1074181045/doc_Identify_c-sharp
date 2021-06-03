using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace doc_Identify
{
    public partial class Form1 : Form
    {
        static bool loading = false;
        Thread loading_thrd, execute_thrd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.groupBox1.Paint += groupBox1_Paint;

            answers_tb.GotFocus += Tb_GotFocus;
            deducts_tb.GotFocus += Tb_GotFocus;
            answers_tb.LostFocus += Tb_LostFocus;
            deducts_tb.LostFocus += Tb_LostFocus;
        }

        private void Tb_LostFocus(object sender, EventArgs e)
        {
            this.AcceptButton = mark_btn;
        }

        private void Tb_GotFocus(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        // 參考網址 http://www.zendei.com/article/32300.html
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            SizeF vSize = e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font);
            e.Graphics.DrawLine(Pens.Blue, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Blue, vSize.Width + 8, vSize.Height / 2, groupBox1.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Blue, 1, vSize.Height / 2, 1, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, 1, groupBox1.Height - 2, groupBox1.Width - 2, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, groupBox1.Width - 2, vSize.Height / 2, groupBox1.Width - 2, groupBox1.Height - 2);
        }

        void Loading_Show()
        {
            int i = -1;
            
            Console.Clear();

            bool first = true;
            
            while (true)
            {
                if (!loading == true)
                {
                    loading_thrd.Abort();
                    loading_thrd = null;
                    execute_thrd.Abort();
                    execute_thrd = null;
                    return;
                }
                    
                i = (i > 1) ? 0 : i+1;
                string[] s =  {".", "..", "..."};
                
                if (first)
                    first = false;
                else
                    Console.Clear();
                
                Console.WriteLine("Loading" + s[i]);

                Thread.Sleep(1000);
            }
            
        }

        private void Mark_Click(object sender, EventArgs e)
        {
            string err;
            string outResult;

            string file;

            if (Program.read_mode == (int)Program.mode.cmd)
            {
                MLSharpPython("cmd.exe");
                file = "docx_extract.exe";
            }
            else
            {
                MLSharpPython("python.exe");
                file = "Python/docx_extract.py";
            }

            if (loading_thrd != null)
            {
                loading_thrd.Abort();
                loading_thrd = null;
            }

            loading_thrd = new Thread(Loading_Show);
            loading_thrd.Start();

            string color = "";

            foreach (string s in ColorList.CheckedItems)
                color = color + s + ",";

            if (execute_thrd != null)
            {
                execute_thrd.Abort();
                execute_thrd = null;
            }

            execute_thrd = new Thread(() => {
                loading = true;

                outResult = ExecuteScript(
                    string.Format(file + " \"{0}\" \"{1}\" \"{2}\" \"{3}\"",
                    path_tb.Text,
                    color.TrimEnd(','),
                    answers_tb.Text.Replace(" ", "").Replace(Environment.NewLine, " "),
                    deducts_tb.Text.Replace(" ", "").Replace(Environment.NewLine, " ")),
                    out err
                );

                string cut = "score： ";
                score_tb.Text = outResult.Substring(outResult.IndexOf(cut) + cut.Length, 3).TrimEnd(' ');
                Console.WriteLine(outResult);
            });
            execute_thrd.Start();
        }

        // 參考網站 https://jculul.pixnet.net/blog/post/283369420-c%23%E5%91%BC%E5%8F%ABpython%E7%9A%84%E7%A8%8B%E5%BC%8F%E8%AA%9E%E6%B3%95
        public string filePythonExePath;
        /// <summary>
        /// ML Sharp Python class constructor
        /// </summary>
        /// <param name="exePythonPath">Python EXE file path</param>
        public void MLSharpPython(string exePythonPath)
        {
            filePythonExePath = exePythonPath;
        }
        /// <summary>
        /// Execute Python script file
        /// </summary>
        /// <param name="filePythonScript">Python script file and input parameter(s)</param>
        /// <param name="standardError">Output standard error</param>
        /// <returns>Output text result</returns>
        public string ExecuteScript(string filePythonScript, out string standardError)
        {
            string outputText = string.Empty;
            standardError = string.Empty;
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo(filePythonExePath)
                    {
                        Arguments = (filePythonScript),
                        UseShellExecute = false,
                        RedirectStandardInput = true,  // 接受來自呼叫程式的輸入資訊 
                        RedirectStandardOutput = true,  // 由呼叫程式獲取輸出資訊
                        RedirectStandardError = true,  //重定向標準錯誤輸出
                        CreateNoWindow = true
                    };
                    process.Start();

                    if (Program.read_mode == (int)Program.mode.cmd)
                    {
                        process.StandardInput.WriteLine(filePythonScript + "&exit");
                    }

                    outputText = process.StandardOutput.ReadToEnd();
                    standardError = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
            }

            loading = false;

            return outputText;
        }

        private void Select_Click(object sender, EventArgs e)
        {
            if (File_rb.Checked)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "選取docx";
                fileDialog.Filter = "docx files (*.docx)|*.docx|docx files (*.doc)|*.doc";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    path_tb.Text = fileDialog.FileName;
                    mark_btn.Enabled = true;
                }
            }
            else
            {
                FolderBrowserDialog pathDialog = new FolderBrowserDialog();
                if (pathDialog.ShowDialog() == DialogResult.OK)
                {
                    path_tb.Text = pathDialog.SelectedPath;
                    mark_btn.Enabled = true;
                }
            }
        }
    }
}
