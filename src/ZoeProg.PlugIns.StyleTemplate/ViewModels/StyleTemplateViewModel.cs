

namespace ZoeProg.PlugIns.StyleTemplate.ViewModels
{
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using ZoeProg.PlugIns.StyleTemplate.Services;

    public class StyleTemplateViewModel : BindableBase
    {
        private readonly IWpfControlProvider wpfControlProvider;
        private readonly IXamlWriteService xamlWriteService;
        private string template;
        private Type selectedType;



        public StyleTemplateViewModel(IWpfControlProvider wpfControlProvider, IXamlWriteService xamlWriteService)
        {
            this.wpfControlProvider = wpfControlProvider ?? throw new ArgumentNullException("wpfControlProvider");
            this.xamlWriteService = xamlWriteService ?? throw new ArgumentNullException("xamlWriteService");


            this.Items = new ObservableCollection<Type>(this.wpfControlProvider.RetrieveControls());
            this.ItemsCount = this.Items.Count;
            
        }
        public string Header { get; } = "Style&Template";
        public ObservableCollection<Type> Items { get; private set; }
        public int ItemsCount { get; private set; }


        public string Template
        {
            get { return template; }
            set { SetProperty(ref template, value); }
        }


        public Type SelectedType
        {
            get { return selectedType; }
            set
            {
                if(SetProperty(ref selectedType, value))
                {
                    try
                    {
                        var control = Activator.CreateInstance(value) as Control;
                        
                        if (control == null)
                        {
                            return;
                        }
                         
                        control.UpdateDefaultStyle();
                        if (control.Template == null)
                        {
                            return;
                        }
                        this.Template = this.xamlWriteService.GetXamlString(control.Template);
                    }
                    catch (Exception  ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
               
                }
            }
        }




    }
}
