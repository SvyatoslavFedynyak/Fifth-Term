using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class ThreadWindow : Form
    {
        Random randomiser = new Random();
        int valueToShow = 0;
        Thread generateThread;
        MainWindow windowFather;
        public ThreadWindow()
        {
            InitializeComponent();
        }
        public ThreadWindow(MainWindow father)
        {
            InitializeComponent();
            generateThread = new Thread(new ThreadStart(GenerateAndShow));
            generateThread.Start();
            windowFather = father;
        }
        private void GenerateAndShow()
        {
            do
            {
                valueToShow = randomiser.Next(0, 1000000);
                if (this != null)
                {
                    Invoke((Action)delegate
                {

                    NumbersTestBox.Text = valueToShow.ToString();
                });
                }
                Thread.Sleep(500);
            } while (true);
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            if (generateThread.ThreadState == ThreadState.Suspended)
            {
                generateThread.Resume();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            generateThread.Suspend();
        }

        private void ThreadWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            windowFather.AdditionalWindowClosed();
        }

        private void ThreadWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            generateThread.Suspend();
        }
    }
}
