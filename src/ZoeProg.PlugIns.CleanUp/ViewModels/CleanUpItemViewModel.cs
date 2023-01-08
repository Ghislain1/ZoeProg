

namespace ZoeProg.PlugIns.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Prism.Mvvm;
    using ZoeProg.Core.Models;
    public  class CleanUpItemViewModel: BindableBase
    {
        
        private bool deny;
        //i.e. cannot be deleted
        public bool Deny
        {
            get
            {
                return this.deny;
            }

            set
            {
                if (this.SetProperty<bool>(ref this.deny, value))
                {
                  
                }
               
            }
        }
        private string group;
        public string Group
        {
            get
            {
                return this.group;
            }

            set
            {
                if (this.SetProperty<string>(ref this.group, value))
                {

                }

            }
        }


        public CleanUpItem CleanUpItem { get; }
        public CleanUpItemViewModel(CleanUpItem model, string group)
        {
            this.CleanUpItem = model;
            this.Group = group;
        }
    }
}
