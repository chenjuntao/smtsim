using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmtSim
{
    /// <summary>
    /// ucDocs.xaml 的交互逻辑
    /// </summary>
    public partial class ucDocs : UserControl
    {
        private System.Windows.Forms.WebBrowser webBrowser1;

        public ucDocs(string docPathDir)
        {
            InitializeComponent();

            webBrowser1 = new System.Windows.Forms.WebBrowser();
            winFormHost.Child = webBrowser1;
           
            string[] imgFiles = System.IO.Directory.GetFiles(docPathDir);
            for (int i = 0; i < imgFiles.Length; i++)
            {
                try
                {
                    FileInfo file = new FileInfo(imgFiles[i]);
                    RadioButton radioBtn = new RadioButton();
                    radioBtn.Content = file.Name.Replace(file.Extension, "");
                    radioBtn.FontSize = 18;
                    radioBtn.Tag = file.FullName;
                    radioBtn.Checked += new RoutedEventHandler(btnDoc_Checked);
                    docList.Children.Add(radioBtn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDoc_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioBtn = sender as RadioButton;
            if ((bool)radioBtn.IsChecked)
            {
                webBrowser1.Navigate(radioBtn.Tag.ToString());
            }
        }
    }
}
