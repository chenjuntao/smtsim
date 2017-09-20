using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmtSim
{
    /// <summary>
    /// ucVideos.xaml 的交互逻辑
    /// </summary>
    public partial class ucVideos : UserControl
    {
        public ucVideos(string videoPathDir)
        {
            InitializeComponent();

            string[] imgFiles = System.IO.Directory.GetFiles(videoPathDir);
            for (int i = 0; i < imgFiles.Length; i++)
            {
                try
                {
                    FileInfo file = new FileInfo(imgFiles[i]);
                    RadioButton radioBtn = new RadioButton();
                    radioBtn.Content = file.Name.Replace(file.Extension, "");
                    radioBtn.FontSize = 18;
                    radioBtn.Tag = file.FullName;
                    radioBtn.Checked += new RoutedEventHandler(radioBtn_Click);
                    videoList.Children.Add(radioBtn);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radioBtn_Click(object sender, EventArgs e)
        {
            RadioButton radioBtn = sender as RadioButton;
            if ((bool)radioBtn.IsChecked)
            {
                ucVideoPlayer1.VideoName = radioBtn.Tag.ToString();
            }
        }
    }
}
