using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace SmtSim
{
    /// <summary>
    /// ucPCB.xaml 的交互逻辑
    /// </summary>
    public partial class ucPCB : UserControl
    {
        #region Singleton
        private static ucPCB instance;
        public static ucPCB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ucPCB();
                }
                return instance;
            }
        }

        private ucPCB()
        {
            InitializeComponent();
        }
        #endregion


        private void btnDoc_Click(object sender, RoutedEventArgs e)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\PCB\\pcbDocs");
            ucDocs doc = new ucDocs(dir);
            doc.labelTitle.Content = "PCB基础知识文档";
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(doc);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnComponent_Click(object sender, RoutedEventArgs e)
        {
            ucPCBComponent pcbComponent = new ucPCBComponent();
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(pcbComponent);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnEDAInput_Click(object sender, RoutedEventArgs e)
        {
            ucImportEDA importEDA = new ucImportEDA();
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(importEDA);
            MainWindow.instance.AddToReturnControl(this);
        }

        private void btnPCBAnalyst_Click(object sender, RoutedEventArgs e)
        {
            ucPCB3d uc3dView = new ucPCB3d();
            MainWindow.instance.gridContent.Children.Clear();
            MainWindow.instance.gridContent.Children.Add(uc3dView);
            MainWindow.instance.AddToReturnControl(this);
        }
    }
}
