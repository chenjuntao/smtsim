using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmtSim
{
    /// <summary>
    /// ucWaveSloder.xaml 的交互逻辑
    /// </summary>
    public partial class ucWaveSloder : UserControl
    {
        #region Singleton
        private static ucWaveSloder instance;
        public static ucWaveSloder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ucWaveSloder();
                }
                return instance;
            }
        }

        private ucWaveSloder()
        {
            InitializeComponent();
        }
        #endregion

        //波峰焊文档
        private void btnDoc_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\WaveSolder\\WaveSolderDocs");
            ucDocs doc = new ucDocs(dir);
            doc.labelTitle.Content = "波峰焊基础知识文档";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(doc);
            MainWindow.instance.AddToReturnControl(this);
        }
    }
}
