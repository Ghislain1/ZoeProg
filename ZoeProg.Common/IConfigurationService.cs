namespace ZoeProg.Common
{
    public interface IConfigurationService
    {
        string GetAppSetting(string key);

        void Save();

        void SetAppSetting(string key, string value);
    }
}