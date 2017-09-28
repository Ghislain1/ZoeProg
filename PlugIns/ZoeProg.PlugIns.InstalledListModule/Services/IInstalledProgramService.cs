namespace ZoeProg.PlugIns.InstalledList.Services
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Windows.Input;

  public class InstalledProgramService : IInstalledProgramService
  {
    public InstalledProgramService()
    {
    }

    public ICommand DeinstallCommand
    {
      get
      {
        throw new NotImplementedException();
      }

      set
      {
        throw new NotImplementedException();
      }
    }

    public ObservableCollection<string> RetrieveInstalledProgramList()
    {
      throw new NotImplementedException();
    }
  }
}