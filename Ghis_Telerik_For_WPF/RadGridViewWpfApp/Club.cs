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
    private string index;
    private string name;

    private int sortIndex;
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

    public string Index
    {
      get { return this.index; }
      set
      {
        if (value != this.index)
        {
          this.index = value;
          this.OnPropertyChanged("Index");
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

    public int SortIndex
    {
      get
      {
        if (this.index != null)
        {
          this.sortIndex = int.Parse(this.index);
        }
        return this.sortIndex;
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