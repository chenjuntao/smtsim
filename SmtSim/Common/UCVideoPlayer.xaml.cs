using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace SmtSim
{
    /// <summary>
    /// UCVideoPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class UCVideoPlayer : System.Windows.Controls.UserControl
    {
        private DispatcherTimer timer; //进度时间设置1       

        public string VideoName
        {
            set
            {
                if (value == null)
                {
                    mediaElement1.Source = null;
                }
                else
                {
                    mediaElement1.Source = new System.Uri(value);
                    if (mediaElement1.Source != null)
                    {
                        mediaElement1.Play();
                    }
                }
            }
        }

        public UCVideoPlayer()
        {
            InitializeComponent();
            this.timer = new DispatcherTimer();
        }       

        //播放进度，跳转到播放的哪个地方
        private void timelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan span = new TimeSpan(0, 0, (int)(timelineSlider.Value) * 10);
            mediaElement1.Position = span;
        }

        //媒体成功打开时触发的事件
        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            //视频总时长
            double seconds = mediaElement1.NaturalDuration.TimeSpan.TotalSeconds;
            //共分成10等分，每1等分多少秒
            timelineSlider.Maximum = seconds / 10;
            //10分之一
            double baseSecond = seconds / timelineSlider.Maximum;
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timelineSlider.ValueChanged -= new RoutedPropertyChangedEventHandler<double>(timelineSlider_ValueChanged);
            this.timelineSlider.Value = this.mediaElement1.Position.TotalSeconds / 10.0;
            this.timelineSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(timelineSlider_ValueChanged);
            try
            {
                txtTime.Text = string.Format("{0}{1:00}:{2:00}:{3:00}", "",
                               mediaElement1.Position.Hours,
                               mediaElement1.Position.Minutes,
                               mediaElement1.Position.Seconds);
                txtTime.Text += "/";
                txtTime.Text += string.Format("{0}{1:00}:{2:00}:{3:00}", "",
                mediaElement1.NaturalDuration.TimeSpan.Hours,
                mediaElement1.NaturalDuration.TimeSpan.Minutes,
                mediaElement1.NaturalDuration.TimeSpan.Seconds);              
            }
            catch { }
        }
    }
}
