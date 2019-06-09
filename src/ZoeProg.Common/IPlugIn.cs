namespace ZoeProg.Common
{
    public interface IPlugin: IPluginHeader
    {
        string Code { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        bool IsSelected { get; set; }
        string NavigatePath { get; set; }
        string Title { get; set; }

        /// <summary>
        /// To interact with  Material Design PackIcon 
        /// </summary>
        string Kind { get; set; }

        
    }
}