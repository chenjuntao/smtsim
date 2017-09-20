using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace SmtSim
{
    /// <summary>
    /// ucMis.xaml 的交互逻辑
    /// </summary>
    public partial class uc2Mis : UserControl
    {
        #region Singleton
        private static uc2Mis instance;
        public static uc2Mis Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uc2Mis();
                }
                return instance;
            }
        }

        private uc2Mis()
        {
            InitializeComponent();
        }
        #endregion

        #region 鼠标移动文本颜色变化
        private Brush oldBrush;
        private void txt_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock txt = sender as TextBlock;
            oldBrush = txt.Foreground;
            txt.Foreground = Brushes.Red;
            txt.FontWeight = FontWeights.Bold;
            txt.FontStyle = FontStyles.Italic;
        }
        private void txt_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock txt = sender as TextBlock;
            txt.Foreground = oldBrush;
            txt.FontWeight = FontWeights.Normal;
            txt.FontStyle = FontStyles.Normal;
        }
        #endregion

        private void usr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(new uc3mis1());
            MainWindow.instance.AddToReturnControl(this);
        }
    }
}
