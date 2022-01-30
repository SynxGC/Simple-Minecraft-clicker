using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Synx_Clicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public int cpsvalue = 10;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static bool ApplicationIsActivated()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            bool result;
            if (foregroundWindow == IntPtr.Zero)
            {
                result = false;
            }
            else
            {
                int id = Process.GetCurrentProcess().Id;
                int num;
                GetWindowThreadProcessId(foregroundWindow, out num);
                result = (num == id);
            }
            return result;
        }

        private string GetCaptionOfActiveWindow()
        {
            var strTitle = string.Empty;
            var handle = GetForegroundWindow();
            var intLength = GetWindowTextLength(handle) + 1;
            var stringBuilder = new StringBuilder(intLength);
            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                strTitle = stringBuilder.ToString();
            }
            return strTitle;
        }

        private void Clicar()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        private void AutoClicker_Tick(object sender, EventArgs e)
        {
            try
            {
                AutoClicker.Interval = 1000 / cpsvalue;
            }
            catch
            {

            }
            if (GetCaptionOfActiveWindow().Contains("Minecraft") || GetCaptionOfActiveWindow().Contains("Badlion") || GetCaptionOfActiveWindow().Contains("Labymod") || GetCaptionOfActiveWindow().Contains("OCMC") || GetCaptionOfActiveWindow().Contains("Cheatbreaker") || GetCaptionOfActiveWindow().Contains("J3Ultimate"))
            {
                if (!ApplicationIsActivated())
                {
                    if (MouseButtons == MouseButtons.Left)
                    {
                        Clicar();
                    }
                }
            }
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            cpsvalue = guna2TrackBar1.Value;
            label2.Text = cpsvalue.ToString() + " cps";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void restarte()
        {
            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    if(process.ProcessName.ToLower()== "explorer")
                    {
                        process.Kill();
                        var novoprocesso = new Process();
                        novoprocesso.StartInfo.FileName = @"C:\Windows\Explorer.exe";
                        novoprocesso.StartInfo.UseShellExecute = true;
                        novoprocesso.Start();
                    }

                }
                catch
                {
                }
            }
        }
        private void Self(string string222)
        {
            var synxzera = Directory.GetFiles(string222);
            foreach (string caminho in synxzera)
            {
                try
                {
                    File.Delete(caminho);
                }
                catch { }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Self(@"C:\Windows\Prefetch");
            Self($@"C:\Users\{Environment.UserName}\AppData\Local\Microsoft\CLR_v4.0_32\UsageLogs");
            restarte();
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

