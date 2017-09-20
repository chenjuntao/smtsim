using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmtSim
{
    /// <summary>
    /// ucChecker.xaml 的交互逻辑
    /// </summary>
    public partial class ucChecker : UserControl
    {
      #region Singleton
        private static ucChecker instance;
        public static ucChecker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ucChecker();
                }
                return instance;
            }
        }

        private ucChecker()
        {
            InitializeComponent();
        }
        #endregion
    }
}
