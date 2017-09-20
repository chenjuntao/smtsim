using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Input;
using System.Windows.Media;

namespace SmtSim
{
    /// <summary>
    /// ucMounter3d.xaml 的交互逻辑
    /// </summary>
    public partial class ucMounter3d : UserControl
    {
        private Trackball trackball = new Trackball();

        public ucMounter3d()
        {
            InitializeComponent();

            ModelBase modelbaseMounter = new ModelBase("mounter");
            mounterContainer.Children.Add(modelbaseMounter);
            modelbaseMounter.MouseDown += mounter_MouseDown;

            ModelBase modelbaseTV = new ModelBase("tv");
            mounterContainer.Children.Add(modelbaseTV);
            modelbaseTV.MouseDown += front_MouseDown;

            ModelBase modelbaseCard1 = new ModelBase("card1");
            mounterContainer.Children.Add(modelbaseCard1);
            modelbaseCard1.Move(-161.753, 23.0741, 412.552, 0);
            modelbaseCard1.MouseDown += front_MouseDown;

            ModelBase modelbaseCard2 = new ModelBase("card1");
            mounterContainer.Children.Add(modelbaseCard2);
            modelbaseCard2.Move(163.301, 23.0741, 412.552, 0);
            modelbaseCard2.MouseDown += front_MouseDown;

            ModelBase modelbaseCard3 = new ModelBase("card1");
            mounterContainer.Children.Add(modelbaseCard3);
            modelbaseCard3.Move(-161.753, 29.8288, -440.465, 180);
            modelbaseCard3.MouseDown += back_MouseDown;

            ModelBase modelbaseCard4 = new ModelBase("card1");
            mounterContainer.Children.Add(modelbaseCard4);
            modelbaseCard4.Move(163.301, 29.8288, -440.465, 180);
            modelbaseCard4.MouseDown += back_MouseDown;

            ModelBase modelbaseBox1 = new ModelBase("box1");
            mounterContainer.Children.Add(modelbaseBox1);
            modelbaseBox1.Move(-161.753, 23.0741, 412.552, 0);
            modelbaseBox1.MouseDown += front_MouseDown;

            ModelBase modelbaseBox2 = new ModelBase("box1");
            mounterContainer.Children.Add(modelbaseBox2);
            modelbaseBox2.Move(163.301, 23.0741, 412.552, 0);
            modelbaseBox2.MouseDown += front_MouseDown;

            ModelBase modelbaseBox3 = new ModelBase("box1");
            mounterContainer.Children.Add(modelbaseBox3);
            modelbaseBox3.Move(-161.753, 29.8288, -440.465, 0);
            modelbaseBox3.MouseDown += back_MouseDown;

            ModelBase modelbaseBox4 = new ModelBase("box1");
            mounterContainer.Children.Add(modelbaseBox4);
            modelbaseBox4.Move(163.301, 29.8288, -440.465, 0);
            modelbaseBox4.MouseDown += back_MouseDown;

        }

        //开始旋转
        private void rotateView_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Content.ToString() == "开始旋转")
            {
                btn.Content = "停止旋转";
                ((Storyboard)this.Resources["myStoryboard"]).Begin();
            }
            else
            {
                btn.Content = "开始旋转";
                ((Storyboard)this.Resources["myStoryboard"]).Stop();
            }
        }

        //恢复到默认视角
        private void defaultView_Click(object sender, RoutedEventArgs e)
        {
            trackballDecorator1.Reset();
        }

        //鼠标点击显示信息
        private void mounter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released && e.LeftButton == MouseButtonState.Pressed)
            {
                ModelBase model = sender as ModelBase;
                TranslateTransform3D translateTrans = new TranslateTransform3D(0, 0, 0);
                Transform3DGroup transGroup = new Transform3DGroup();
                transGroup.Children.Add(model.Transform);
                transGroup.Children.Add(translateTrans);
                model.Transform = transGroup;

                DoubleAnimation animation = new DoubleAnimation();
                animation.To = 500;
                animation.DecelerationRatio = 1;
                animation.Duration = TimeSpan.FromSeconds(1);
                animation.AutoReverse = true;
                translateTrans.BeginAnimation(TranslateTransform3D.OffsetYProperty, animation);
            }
        }

        //鼠标点击显示信息
        private void front_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released && e.LeftButton == MouseButtonState.Pressed)
            {
                ModelBase model = sender as ModelBase;
                TranslateTransform3D translateTrans = new TranslateTransform3D(0, 0, 0);
                Transform3DGroup transGroup = new Transform3DGroup();
                transGroup.Children.Add(model.Transform);
                transGroup.Children.Add(translateTrans);
                model.Transform = transGroup;

                DoubleAnimation animation = new DoubleAnimation();
                animation.To = 300;
                animation.DecelerationRatio = 1;
                animation.Duration = TimeSpan.FromSeconds(1);
                animation.AutoReverse = true;
                translateTrans.BeginAnimation(TranslateTransform3D.OffsetZProperty, animation);
            }
        }

        //鼠标点击显示信息
        private void back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released && e.LeftButton == MouseButtonState.Pressed)
            {
                ModelBase model = sender as ModelBase;
                TranslateTransform3D translateTrans = new TranslateTransform3D(0, 0, 0);
                Transform3DGroup transGroup = new Transform3DGroup();
                transGroup.Children.Add(model.Transform);
                transGroup.Children.Add(translateTrans);
                model.Transform = transGroup;

                DoubleAnimation animation = new DoubleAnimation();
                animation.To = -300;
                animation.DecelerationRatio = 1;
                animation.Duration = TimeSpan.FromSeconds(1);
                animation.AutoReverse = true;
                translateTrans.BeginAnimation(TranslateTransform3D.OffsetZProperty, animation);
            }
        }
    }
}
