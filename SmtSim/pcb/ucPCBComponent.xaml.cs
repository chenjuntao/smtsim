using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmtSim
{
    /// <summary>
    /// ucPCBComponent.xaml 的交互逻辑
    /// </summary>
    public partial class ucPCBComponent : UserControl
    {
        private System.Windows.Forms.WebBrowser webBrowser1;

        public ucPCBComponent()
        {
            InitializeComponent();

            webBrowser1 = new System.Windows.Forms.WebBrowser();
            winFormHost.Child = webBrowser1;

            Init("FKD");
            Init("SOP14");
            Init("YC122");
            Init("SL_B");
            Init("sot313_2");
            Init("led_red");
            Init("led_blue");
            Init("led_yellow");
            Init("lqpf64");
            Init("C06x18");
            Init("msop_10");
            Init("alu_e");
            Init("do_214aa");
            Init("FUSE_NANO2");
            Init("POWERDI_123");
            Init("res01005");
            Init("sc70_3");
            Init("SMD_Capacitor");
            Init("SOT_23_3");
            Init("SOT_23_5");
            Init("SOT23_5_1");
            Init("tssop14_2");
        }

        private void Init(string componentName)
        {
            string dir = Path.Combine(System.Windows.Forms.Application.StartupPath, "Data\\PCB\\pcbComponents");
            RadioButton radioBtn = new RadioButton();
            radioBtn.Content = componentName;
            radioBtn.FontSize = 18;
            radioBtn.Tag = Path.Combine(dir, componentName + ".mht");
            radioBtn.Checked += new RoutedEventHandler(btnPcbComponent_Checked);
            componentList.Children.Add(radioBtn);
        }

        //恢复到默认视角
        private void defaultView_Click(object sender, RoutedEventArgs e)
        {
            trackballDecorator1.Reset();
        }

        private void btnPcbComponent_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioBtn = sender as RadioButton;
            if ((bool)radioBtn.IsChecked)
            {
                if (File.Exists(radioBtn.Tag.ToString()))
                {
                    webBrowser1.Navigate(radioBtn.Tag.ToString());
                }
                pcbComponents.Children.Clear();
                ModelBase model = new ModelBase(radioBtn.Content.ToString());
                pcbComponents.Children.Add(model);
            }
        }
    }
}
