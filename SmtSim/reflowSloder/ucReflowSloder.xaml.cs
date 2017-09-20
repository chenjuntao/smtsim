using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmtSim
{
    /// <summary>
    /// ucReflowSloder.xaml 的交互逻辑
    /// </summary>
    public partial class ucReflowSloder : UserControl
    {
        #region Singleton
        private static ucReflowSloder instance;
        public static ucReflowSloder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ucReflowSloder();
                }
                return instance;
            }
        }

        private ucReflowSloder()
        {
            InitializeComponent();
        }
        #endregion

        //回流焊文档
        private void btnDoc_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\ReflowSolder\\ReflowSolderDocs");
            ucDocs doc = new ucDocs(dir);
            doc.labelTitle.Content = "回流焊基础知识文档";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(doc);
            MainWindow.instance.AddToReturnControl(this);
        }

         //回流焊视频
        private void btnVideo_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\ReflowSolder\\ReflowSolderVideo");
            ucVideos video = new ucVideos(dir);
            video.labelTitle.Content = "回流焊教学视频";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(video);
            MainWindow.instance.AddToReturnControl(this);
        }

        //回流焊温度曲线设计
        private void btnTempDesign_Click(object sender, RoutedEventArgs e)
        {
            ucReflowTempDesign reflowTempDesign = new ucReflowTempDesign();
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(reflowTempDesign);
            MainWindow.instance.AddToReturnControl(this);
        }

        //回流焊编程
        private void btnProgram_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
