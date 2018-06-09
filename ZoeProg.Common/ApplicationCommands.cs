using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.Common
{
    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand saveCommand = new CompositeCommand();

        public CompositeCommand SaveCommand
        {
            get { return this.saveCommand; }
        }
    }
}