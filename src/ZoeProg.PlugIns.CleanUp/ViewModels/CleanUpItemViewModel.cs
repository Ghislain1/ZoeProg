using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;

using ZoeProg.Core.Models;

namespace ZoeProg.PlugIns.ViewModels
{
  public  class CleanUpItemViewModel: BindableBase
    {
       
        public CleanUpItem CleanUpItem { get; }
        public CleanUpItemViewModel(CleanUpItem model)
        {
            this.CleanUpItem = model;
        }
    }
}
