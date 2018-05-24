namespace ZoeProg.Common.Data
{
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class Package : InstalledPackage
    {
        public string Authors { get; set; }
        public string Copyright { get; set; }
        public string[] Dependencies { get; set; }
        public string Description { get; set; }
        public string GalleryDetailsUrl { get; set; }

        public bool HasIconUrl
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.IconUrl);
            }
        }

        public string IconUrl { get; set; }
        public bool IsLatestVersion { get; set; }
        public string LicenseUrl { get; set; }
        public long PackageSize { get; set; }
        public string ProjectUrl { get; set; }
        public string ReleaseNotes { get; set; }
        public string ReportAbuseUrl { get; set; }
        public string[] Tags { get; set; }
        public int VersionDownloadCount { get; set; }
    }
}