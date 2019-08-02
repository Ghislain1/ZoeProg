using System;
using System.Windows.Input;

namespace ZoeProg.Common
{
    public interface IPlugin : IPluginHeader
    {
        string Code { get; set; }
        ICommand Command { get; set; }
        Type CommandParameter { get; set; }
        string Description { get; set; }
        string Glyph { get; set; }
        string Id { get; set; }
        bool IsSelected { get; set; }

        /// <summary>
        /// To interact with Material Design PackIcon
        /// </summary>
        string Kind { get; set; }

        string Label { get; set; }
        string NavigatePath { get; set; }
        string Tag { get; set; }
        string Title { get; set; }
    }
}