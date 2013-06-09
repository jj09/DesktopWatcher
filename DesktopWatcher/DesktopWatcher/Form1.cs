using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DesktopWatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MouseMoveMessageFilter mouseMessageFilter;
        public Point mousePosition;

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.RemoveMessageFilter(this.mouseMessageFilter);
        }

        public void CloseForm()
        {
            this.Close();
        }

        public class MouseMoveMessageFilter : IMessageFilter
        {
            public dynamic TargetForm { get; set; }

            public bool PreFilterMessage(ref Message m)
            {
                int numMsg = m.Msg;
                if (numMsg == 0x0200 /*WM_MOUSEMOVE*/ || numMsg == 0x0100 /*WM_KEYDOWN*/ || numMsg == 0x0104  /*WM_SYSKEYDOWN*/)
                {
                    this.TargetForm.Text = string.Format("X:{0}, Y:{1}", Control.MousePosition.X, Control.MousePosition.Y);
                    
                    if (this.TargetForm.mousePosition.X != Cursor.Position.X || numMsg == 0x0100 /*WM_KEYDOWN*/ || numMsg == 0x0104  /*WM_SYSKEYDOWN*/)
                    {
                        this.TargetForm.axWindowsMediaPlayer1.Ctlcontrols.play();
                        LockWorkStation();
                    }
                }
                return false;
            }

            [DllImport("user32.dll")]
            public static extern void LockWorkStation();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }        

        private void play_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
            System.Threading.Thread.Sleep(5000);    // 5 seconds for leave the machine
            mousePosition.X = Cursor.Position.X;
            mousePosition.Y = Control.MousePosition.Y;

            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);

            this.mouseMessageFilter = new MouseMoveMessageFilter();
            this.mouseMessageFilter.TargetForm = this;
            Application.AddMessageFilter(this.mouseMessageFilter);
        }
    }
}
