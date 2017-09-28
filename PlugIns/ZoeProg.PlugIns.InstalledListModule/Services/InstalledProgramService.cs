namespace ZoeProg.PlugIns.InstalledList.Services
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Windows.Input;

  public interface IInstalledProgramService
  {
    ICommand DeinstallCommand { get; set; }

    ObservableCollection<string> RetrieveInstalledProgramList();
  }
}