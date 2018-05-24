using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ZoeProg
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppBootstrapper bootstrapper = new AppBootstrapper();
            bootstrapper.Run();
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
    }
}