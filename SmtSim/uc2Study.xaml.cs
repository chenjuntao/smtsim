using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmtSim
{
    /// <summary>
    /// uc2Study.xaml 的交互逻辑
    /// </summary>
    public partial class uc2Study : UserControl
    {
         #region Singleton
        private static uc2Study instance;
        public static uc2Study Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uc2Study();
                }
                return instance;
            }
        }

        private uc2Study()
        {
            InitializeComponent();
        }
        #endregion

        private void txtBasic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(new uc3study1());
            MainWindow.instance.AddToReturnControl(this);
        }

        private void txtCarrer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(new uc3study2());
            MainWindow.instance.AddToReturnControl(this);
        }

        private void txtTechnology_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(uc3study3.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

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
    }
}
