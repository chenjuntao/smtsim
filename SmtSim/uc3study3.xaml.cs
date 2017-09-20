using System.Windows.Controls;
using System.Windows.Input;

namespace SmtSim
{
    /// <summary>
    /// ucStudy.xaml 的交互逻辑
    /// </summary>
    public partial class uc3study3 : UserControl
    {
        #region Singleton
        private static uc3study3 instance;
        public static uc3study3 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uc3study3();
                }
                return instance;
            }
        }

        private uc3study3()
        {
            InitializeComponent();
        }
        #endregion

        #region 按钮事件
        private void btnSmt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(ucSmt.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnPCB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(ucPCB.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnScreenPrinter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(ucPrinter.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnMounter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(ucMounter.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnReflowSloder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(ucReflowSloder.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnWaveSloder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(ucWaveSloder.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnChecker_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(ucChecker.Instance);
            MainWindow.instance.AddToReturnControl(this);
        }

        #endregion
    }
}
