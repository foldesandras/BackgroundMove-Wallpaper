using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wallpaper
{
    public partial class Form1 : Form
    {
        // Importáljuk a SetWindowPos függvényt a User32.dll-ből
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // Meghatározzuk az állandókat
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOMOVE = 0x0002;
        const uint SWP_NOACTIVATE = 0x0010;
        const uint SWP_SHOWWINDOW = 0x0040;

        static public string html = @"<style>
            body {
                margin: 0px;
            }
            </style>
            <video width = ""{width}""autoplay muted loop>
                <source src = ""video.mp4"" type=""video/mp4"">
                Your browser does not support the video tag.
            </video>
        ";

        public static string htmlpath;

        public Form1()
        {
            htmlpath = Path.Combine(Directory.GetCurrentDirectory(), "html.html");
            while (!File.Exists("video.mp4"))
            {
                if (MessageBox.Show("Please put the animation to the program folder with name \"video.mp4\", then click OK.", "BackgroundMove", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
            }
            InitializeComponent();
            File.WriteAllText(htmlpath, html.Replace(@"{width}", Screen.PrimaryScreen.Bounds.Width.ToString()));
            webView21.Source = new Uri(htmlpath);
            // Beállítjuk az ablak pozícióját
            SetWindowPos(this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
            Console.WriteLine(Screen.PrimaryScreen.Bounds.Width + "x" + Screen.PrimaryScreen.Bounds.Height);
        }

        private void MyGotFocus(object sender, EventArgs e)
        {
            
        }
    }
}
