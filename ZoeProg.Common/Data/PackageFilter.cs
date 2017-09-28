namespace ZoeProg.Common.Data
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public enum PackageFilter
  {
    [Description("Stable Only")]
    StableOnly,

    [Description("Include Prerelease")]
    IncludePrerelease,

    [Description("Installed Only")]
    InstalledOnly
  }
}