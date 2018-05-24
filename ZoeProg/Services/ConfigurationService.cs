namespace ZoeProg.Services
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Unity;
    using ZoeProg.Common;

    public sealed class ConfigurationService : IConfigurationService
    {
        // private readonly Configuration configuration;
        private readonly IUnityContainer container;

        public ConfigurationService(IUnityContainer container)
        {
            this.container = container;
            // this.configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetAppSetting(string key)
        {
            return "this.configuration.AppSettings.Settings[key].Value";
        }

        public void Save()
        {
            // this.configuration.Save(ConfigurationSaveMode.Modified);
        }

        public void SetAppSetting(string key, string value)
        {
            // this.configuration.AppSettings.Settings[key].Value = value;
        }
    }
}