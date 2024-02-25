using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallpaper
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        public Form1()
        {
            while (!File.Exists("video.mp4"))
            {
                if (MessageBox.Show("Please put the animation to the program folder with name \"video.mp4\", then click OK.", "BackgroundMove", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
            }
            InitializeComponent();
            webView21.GotFocus += MyGotFocus;
            webView21.Source = new Uri(Path.Combine(Directory.GetCurrentDirectory(), "html.html"));
        }

        private void MyGotFocus(object sender, EventArgs e)
        {
            SendKeys.Send("^{ESC}");
        }
    }
}
