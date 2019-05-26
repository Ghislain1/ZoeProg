namespace ZoeProg.Common.Data
{
    using System.ComponentModel;

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