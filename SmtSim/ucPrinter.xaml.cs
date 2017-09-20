using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SmtSim
{
    /// <summary>
    /// ucScreenPrinter.xaml 的交互逻辑
    /// </summary>
    public partial class ucPrinter : UserControl
    {
        #region Singleton
        private static ucPrinter instance;
        public static ucPrinter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ucPrinter();
                }
                return instance;
            }
        }

        private ucPrinter()
        {
            InitializeComponent();
        }
        #endregion

        //波峰焊文档
        private void btnDoc_Click(object sender, RoutedEventArgs e)
        {
            string dir = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\Printer\\PrinterDocs");
            ucDocs doc = new ucDocs(dir);
            doc.labelTitle.Content = "印刷机基础知识文档";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(doc);
            MainWindow.instance.AddToReturnControl(this);
        }
    }
}
