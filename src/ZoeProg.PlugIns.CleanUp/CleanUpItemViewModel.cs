using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;

namespace ZoeProg.Core.Models
{
  public  class CleanUpItemViewModel: BindableBase
    {
        public string Date {  get; set; }
        public string Extension {   get; set; }
        public string Group {   get; set; }
        public string Path {   get; set; }
        public string Size {   get; set; }
        public bool IsLockedFile { get; set; }
    }
}
