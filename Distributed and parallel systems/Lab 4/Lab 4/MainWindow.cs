using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class MainWindow : Form
    {
        public delegate void NumOfAdditionalWindowsChange();
        public event NumOfAdditionalWindowsChange PlusOneWindow;
        public event NumOfAdditionalWindowsChange MinusOneWindow;
        int numOfAdditionalwindows = 0;
        List<ThreadWindow> windows;
        ThreadWindow lastWindow;
        public MainWindow()
        {
            InitializeComponent();
            windows = new List<ThreadWindow>();
            NumberOfWindowsTextBox.Text = numOfAdditionalwindows.ToString();
            PlusOneWindow += AddWindow;
            MinusOneWindow += DeleteWindow;
        }
        private void AddWindow()
        {
            numOfAdditionalwindows++;
            NumberOfWindowsTextBox.Text = numOfAdditionalwindows.ToString();
        }
        private void DeleteWindow()
        {
            numOfAdditionalwindows--;
            NumberOfWindowsTextBox.Text = numOfAdditionalwindows.ToString();
        }
        private void AddWindowButton_Click(object sender, EventArgs e)
        {
            lastWindow = new ThreadWindow(this);
            windows.Add(lastWindow);
            lastWindow.Show();
            PlusOneWindow?.Invoke();
        }
        public void AdditionalWindowClosed()
        {
            MinusOneWindow?.Invoke();
        }
    }
}
