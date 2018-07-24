using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadGridViewWpfApp
{
  public class Club : BindableBase
  {
    private DateTime established;
    private string name;
    private int stadiumCapacity;

    public Club(string name, DateTime established, int stadiumCapacity)
    {
      this.name = name;
      this.established = established;
      this.stadiumCapacity = stadiumCapacity;
    }

    public DateTime Established
    {
      get { return this.established; }
      set
      {
        if (value != this.established)
        {
          this.established = value;
          this.OnPropertyChanged("Established");
        }
      }
    }

    public string Name
    {
      get { return this.name; }
      set
      {
        if (value != this.name)
        {
          this.name = value;
          this.OnPropertyChanged("Name");
        }
      }
    }

    public int StadiumCapacity
    {
      get { return this.stadiumCapacity; }
      set
      {
        if (value != this.stadiumCapacity)
        {
          this.stadiumCapacity = value;
          this.OnPropertyChanged("StadiumCapacity");
        }
      }
    }
  }
}