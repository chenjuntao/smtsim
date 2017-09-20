using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace SmtSim
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splash = new SplashScreen("Icons\\ui1Login.jpg");
            splash.Show(true);
            //splash.Close(TimeSpan.FromSeconds(2));
        }
    }
}
