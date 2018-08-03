using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace RadGridViewWpfApp
{
  public class MainWindowViewModel : BindableBase
  {
    private ObservableCollection<Club> clubs;

    private int number;
    private string numberOfTotal;
    private object searchText;

    private int total;

    public MainWindowViewModel()
    {
      this.CreateClubs();
    }

    public ObservableCollection<Club> Clubs
    {
      get
      {
        if (this.clubs == null)
        {
          this.clubs = this.CreateClubs();
        }

        return this.clubs;
      }
    }

    public int Number
    {
      get
      {
        return this.number;
      }

      set
      {
        if (this.SetProperty(ref this.number, value))
        {
          this.NumberOfTotal = $"{number} of {Total}";
        }
      }
    }

    public string NumberOfTotal
    {
      get
      {
        return this.numberOfTotal;
      }

      set
      {
        if (this.SetProperty(ref this.numberOfTotal, value))
        {
          this.NumberOfTotal = $"{number} of {Total}";
        }
      }
    }

    public object SearchText
    {
      get
      {
        return this.searchText;
      }

      set
      {
        if (this.SetProperty(ref this.searchText, value))
        {
          RadGridViewCommands.SearchByText.Execute(null);
        }
      }
    }

    public int Total
    {
      get
      {
        return this.total;
      }

      set
      {
        if (this.SetProperty(ref this.total, value))
        {
        }
      }
    }

    private ObservableCollection<Club> CreateClubs()
    {
      ObservableCollection<Club> clubs = new ObservableCollection<Club>();
      Club club;

      club = new Club("Liverpool", new DateTime(1892, 1, 1), 45362);
      club.Index = "2";
      clubs.Add(club);

      club = new Club("Manchester Utd.", new DateTime(1878, 1, 1), 76212);
      club.Index = "1";
      clubs.Add(club);

      club = new Club("Manchester20.", new DateTime(1878, 10, 1), 1212);
      club.Index = "20";
      clubs.Add(club);

      club = new Club("Chelsea", new DateTime(1905, 1, 1), 42055);
      club.Index = "3";
      clubs.Add(club);

      this.Total = clubs.Count;
      this.Number = clubs.Count;
      return clubs;
    }
  }
}