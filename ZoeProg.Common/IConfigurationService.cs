namespace ZoeProg.Common
{
    using MaterialDesignThemes.Wpf;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZoeProg.Common.Data;

    public interface IConfigurationService
    {
        string GetAppSetting(string key);

        void Save();

        void SetAppSetting(string key, string value);
    }
}