using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using voter.Controller;
using System.IO;

namespace voter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        VoterController vc;
        public static TextBox _logBox;
        public MainWindow()
        {
            InitializeComponent();
            this.vc = new VoterController();
            MainWindow._logBox = this.logBox;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string response = vc.vote(url.Text);
                MainWindow.logInfo(response);
                using (StreamWriter sw = new StreamWriter(File.Open("response.txt", FileMode.Append)))
                {
                    sw.Write(response);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                MainWindow.logInfo(ex.Message);
            }
            
        }

        public static void logInfo(string Info)
        {
            _logBox.AppendText(DateTime.Now.ToString("HH:mm:ss  ") + Info);
            _logBox.AppendText(Environment.NewLine);
            _logBox.ScrollToLine(_logBox.GetLineIndexFromCharacterIndex(_logBox.SelectionStart));

            System.IO.StreamWriter sw = System.IO.File.AppendText(Directory.GetCurrentDirectory() + "/log.txt");
            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss  ") + Info);
            sw.Close();

        }
    }
}
