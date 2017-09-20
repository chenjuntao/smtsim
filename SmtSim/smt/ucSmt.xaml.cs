using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmtSim
{
    /// <summary>
    /// ucSmt.xaml 的交互逻辑
    /// </summary>
    public partial class ucSmt : UserControl
    {
       #region Singleton
        private static ucSmt instance;
        public static ucSmt Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ucSmt();
                }
                return instance;
            }
        }

        private ucSmt()
        {
            InitializeComponent();
        }
        #endregion

        //SMT文档
        private void btnDoc_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\SMT\\smtDocs");
            ucDocs doc = new ucDocs(dir);
            doc.labelTitle.Content = "SMT基础知识文档";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(doc);
            MainWindow.instance.AddToReturnControl(this);
        }

         //SMT原理视频
        private void btnSmtVideo_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\SMT\\smtVideo");
            ucVideos video = new ucVideos(dir);
            video.labelTitle.Content = "SMT教学视频";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(video);
            MainWindow.instance.AddToReturnControl(this);
        }
        
        //SMT生产线工艺设计
        private void btnSmtDesign_Click(object sender, RoutedEventArgs e)
        {
            ucSmtDesign smtDesign = new ucSmtDesign();
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(smtDesign);
            MainWindow.instance.AddToReturnControl(this);
        }

        //SMT生产线工艺仿真动画
        private void btnSmtFlash_Click(object sender, RoutedEventArgs e)
        {
            ucSmtLineFlash smtFlash = new ucSmtLineFlash();
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(smtFlash);
            MainWindow.instance.AddToReturnControl(this);
        }
    }
}
