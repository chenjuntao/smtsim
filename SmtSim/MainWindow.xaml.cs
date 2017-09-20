using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;

namespace SmtSim
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static MainWindow instance;

        public MainWindow()
        {
            InitializeComponent();

            gridContent.Children.Add(new uc1Login());           
            toReturnCtrls = new List<UserControl>();
            instance = this;
        }

        //返回/后退列表
        private List<UserControl> toReturnCtrls;
        internal void AddToReturnControl(UserControl toReturnCtrl)
        {
            toReturnCtrls.Add(toReturnCtrl);
            gridContent.Children.Add(btnReturn);
            gridMainMenu.Visibility = Visibility.Collapsed;
        }

        #region 一级菜单事件
        private void btnStudy_Click(object sender, RoutedEventArgs e)
        {
            btnStudy.IsEnabled = false;
            btnExam.IsEnabled = true;
            btnMIS.IsEnabled = true;
            
            gridContent.Children.Clear();
            gridContent.Children.Add(uc2Study.Instance);
        }

        private void btnExam_Click(object sender, RoutedEventArgs e)
        {
            btnStudy.IsEnabled = true;
            btnExam.IsEnabled = false;
            btnMIS.IsEnabled = true;

            gridContent.Children.Clear();
            gridContent.Children.Add(uc2Exam.Instance);
        }

        private void btnMIS_Click(object sender, RoutedEventArgs e)
        {
            btnStudy.IsEnabled = true;
            btnExam.IsEnabled = true;
            btnMIS.IsEnabled = false;

            gridContent.Children.Clear();
            gridContent.Children.Add(uc2Mis.Instance);
        }
        #endregion

        //登录
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsrName.Text != "admin")
            {
                MessageBox.Show("该用户名不存在！");
            }
            else
            {
                if (txtPassword.Password != "123")
                {
                    MessageBox.Show("密码输入错误！");
                }
                else
                {
                    gridContent.Children.Clear();
                    gridLogin.Visibility = Visibility.Collapsed;
                    gridMainMenu.Visibility = Visibility.Visible;
                    gridContent.Children.Add(uc2Study.Instance);
                    btnStudy.IsEnabled = false;
                }
            }
        }

        //后退按钮
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (toReturnCtrls.Count > 0)
            {
                UserControl usrCtrl = toReturnCtrls[toReturnCtrls.Count - 1];
                gridContent.Children.Clear();
                gridContent.Children.Add(usrCtrl);
                gridContent.Children.Add(btnReturn);
                toReturnCtrls.Remove(usrCtrl);
                if (toReturnCtrls.Count == 0)
                {
                    gridContent.Children.Remove(btnReturn);
                    gridMainMenu.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
