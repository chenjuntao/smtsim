using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Drawing;

namespace SmtSim
{
    /// <summary>
    /// ucSmtLineFlash.xaml 的交互逻辑
    /// </summary>
    public partial class ucSmtLineFlash : UserControl
    {
        public ucSmtLineFlash()
        {
            InitializeComponent(); 
        }

        //开始播放SMT工艺流程仿真动画
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Bitmap image = new Bitmap(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Data\SMT\smtWorkflow\dispens.gif"));
            dianjiao.LoadSmile(image);
            dianjiao.GifStopEvent += new SmtSim.AnimatedImage.GifStopHandler(dianjiao_GifStopEvent);
        }

        private void dianjiao_GifStopEvent()
        {
            Bitmap image = new Bitmap(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Data\SMT\smtWorkflow\mount.gif"));
            tiepian.LoadSmile(image);
            tiepian.GifStopEvent += new SmtSim.AnimatedImage.GifStopHandler(tiepian_GifStopEvent);
        }

        private void tiepian_GifStopEvent()
        {
            Bitmap image = new Bitmap(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Data\SMT\smtWorkflow\reflow.gif"));
            huiliuhan.LoadSmile(image);
            huiliuhan.GifStopEvent += new SmtSim.AnimatedImage.GifStopHandler(huiliuhan_GifStopEvent);
        }

        private void huiliuhan_GifStopEvent()
        {
            Bitmap image = new Bitmap(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Data\SMT\smtWorkflow\wash.gif"));
            qingxi.LoadSmile(image);
            qingxi.GifStopEvent += new SmtSim.AnimatedImage.GifStopHandler(qingxi_GifStopEvent);
        }

        private void qingxi_GifStopEvent()
        {
            Bitmap image = new Bitmap(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Data\SMT\smtWorkflow\AOI.gif"));
            aoijiance.LoadSmile(image);
            aoijiance.GifStopEvent += new SmtSim.AnimatedImage.GifStopHandler(aoijiance_GifStopEvent);
        }

        private void aoijiance_GifStopEvent()
        {
            Bitmap image = new Bitmap(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Data\SMT\smtWorkflow\funTest.gif"));
            gongnengceshi.LoadSmile(image);
            gongnengceshi.GifStopEvent += new SmtSim.AnimatedImage.GifStopHandler(gongnengceshi_GifStopEvent);
        }

        private void gongnengceshi_GifStopEvent()
        {
            Bitmap image = new Bitmap(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Data\SMT\smtWorkflow\repair.gif"));
            fanxiu.LoadSmile(image);
        }
    }
}
