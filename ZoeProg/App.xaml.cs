namespace ZoeProg
{
    using System;
    using System.Windows;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        

            var bootstrapper = new AppBootstrapper();

         

            bootstrapper.Run();

           



        }
    }
}