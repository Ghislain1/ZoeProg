namespace ZoeProg.Common
{
    using System.Collections.Generic;

    public interface IConfigurationService
    {
        string GetAppSetting(string key);

        void Save();

        void SetAppSetting(string key, string value);
    }
}