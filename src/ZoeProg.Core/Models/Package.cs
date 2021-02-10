/*-
 * ---license-start
 * Zoe-App
 * ---
 * Copyright (C) 2021 GhislainOne and all other contributors
 * ---
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ---license-end
 */

namespace ZoeProg.Core.Data
{
    /// <summary>
    /// Defines the <see cref="Package"/>.
    /// </summary>
    public class Package : InstalledPackage
    {
        /// <summary>
        /// Gets or sets the Authors.
        /// </summary>
        public string Authors { get; set; }

        /// <summary>
        /// Gets or sets the Copyright.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the Dependencies.
        /// </summary>
        public string[] Dependencies { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the GalleryDetailsUrl.
        /// </summary>
        public string GalleryDetailsUrl { get; set; }

        /// <summary>
        /// Gets a value indicating whether HasIconUrl.
        /// </summary>
        public bool HasIconUrl
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.IconUrl);
            }
        }

        /// <summary>
        /// Gets or sets the IconUrl.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsLatestVersion.
        /// </summary>
        public bool IsLatestVersion { get; set; }

        /// <summary>
        /// Gets or sets the LicenseUrl.
        /// </summary>
        public string LicenseUrl { get; set; }

        /// <summary>
        /// Gets or sets the PackageSize.
        /// </summary>
        public long PackageSize { get; set; }

        /// <summary>
        /// Gets or sets the ProjectUrl.
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// Gets or sets the ReleaseNotes.
        /// </summary>
        public string ReleaseNotes { get; set; }

        /// <summary>
        /// Gets or sets the ReportAbuseUrl.
        /// </summary>
        public string ReportAbuseUrl { get; set; }

        /// <summary>
        /// Gets or sets the Tags.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the VersionDownloadCount.
        /// </summary>
        public int VersionDownloadCount { get; set; }
    }
}