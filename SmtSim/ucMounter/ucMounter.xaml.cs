using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmtSim
{
    /// <summary>
    /// ucMounter.xaml 的交互逻辑
    /// </summary>
    public partial class ucMounter : UserControl
    {
        #region Singleton
        private static ucMounter instance;
        public static ucMounter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ucMounter();
                }
                return instance;
            }
        }

        private ucMounter()
        {
            InitializeComponent();
        }
        #endregion

        //贴片机文档
        private void btnDoc_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\Mounter\\MounterDocs");
            ucDocs doc = new ucDocs(dir);
            doc.labelTitle.Content = "贴片机基础知识文档";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(doc);
            MainWindow.instance.AddToReturnControl(this);
        }

        //贴片机视频
        private void btnVideo_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\Mounter\\MounterVideo");
            ucVideos video = new ucVideos(dir);
            video.labelTitle.Content = "贴片机教学视频";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(video);
            MainWindow.instance.AddToReturnControl(this);
        }

        //贴片机编程教学
        private void btnProgram_Click(object sender, RoutedEventArgs e)
        {

        }

        //贴片机3d仿真
        private void btn3d_Click(object sender, RoutedEventArgs e)
        {
            ucMounter3d mounter3dView = new ucMounter3d();
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(mounter3dView);
            MainWindow.instance.AddToReturnControl(this);
        }
    }
}
