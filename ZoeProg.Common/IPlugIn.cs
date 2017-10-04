namespace ZoeProg.Common
{
    using MaterialDesignThemes.Wpf;
    using System.ComponentModel;

    public interface IPlugIn
    {
        string Code { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        bool IsSelected { get; set; }
        string NavigatePath { get; set; }
        string Title { get; set; }
    }
}