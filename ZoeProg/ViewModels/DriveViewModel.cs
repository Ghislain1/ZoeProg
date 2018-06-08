using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoeProg.Common.Models;

namespace ZoeProg.ViewModels
{
    public class DriveViewModel : BindableBase
    {
        private double freeGB;

        private bool isChecked;
        private string name;

        private ProviderType provider;

        private string root;

        public double FreeGB
        {
            get { return freeGB; }
            set { SetProperty(ref freeGB, value); }
        }

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                SetProperty(ref isChecked, value);
            }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public ProviderType Provider
        {
            get { return provider; }
            set { SetProperty(ref provider, value); }
        }

        public string Root
        {
            get { return root; }
            set { SetProperty(ref root, value); }
        }

        public double UsedGB { get; set; }
    }
}