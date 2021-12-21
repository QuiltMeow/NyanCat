using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WMPLib;

namespace Nyan_Cat
{
    public partial class NyanInfo : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private static bool allowExit = true;
        private static readonly Color[] rainbow = { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.DarkBlue, Color.Purple };

        private int nyan, volume, lowerColor;
        private readonly WindowsMediaPlayer wmp;

        public NyanInfo()
        {
            InitializeComponent();
            volume = 50;

            wmp = new WindowsMediaPlayer();
            playBGM();
        }

        private void extractBGM()
        {
            string path = Path.Combine(Path.GetTempPath(), "BGM.mp3");
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(Properties.Resources.BGM, 0, Properties.Resources.BGM.Length);
                fs.Flush();
            }
        }

        public void playBGM()
        {
            try
            {
                extractBGM();
                wmp.URL = Path.Combine(Path.GetTempPath(), "BGM.mp3");
                wmp.settings.volume = volume;
                wmp.settings.setMode("loop", true);
                wmp.controls.play();
            }
            catch
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void NyanInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timerNyan_Tick(object sender, EventArgs e)
        {
            labelNyan.Text = "您已經 NYAN 了 " + (++nyan / 10D) + " 秒";

            if (volume >= 100)
            {
                labelLowerVolume.ForeColor = rainbow[lowerColor++];
                if (lowerColor >= rainbow.Length)
                {
                    lowerColor = 0;
                }
            }
        }

        private void labelLowerVolume_MouseClick(object sender, MouseEventArgs e)
        {
            if (volume >= 100)
            {
                return;
            }
            volume += 20;
            wmp.settings.volume = volume;

            labelLowerVolume.Left -= 3;
            if (volume >= 100)
            {
                labelLowerVolume.Text = "這已經是最小聲了";
            }
            else
            {
                labelLowerVolume.Text += "!!!";
            }
        }

        private void NyanInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (allowExit && e.KeyCode == Keys.Escape)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        public static void setAllowExit(bool allow)
        {
            allowExit = allow;
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
    }
}