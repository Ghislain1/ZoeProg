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
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="PackageVersion"/>.
    /// </summary>
    public class PackageVersion : INotifyPropertyChanged
    {
        /// <summary>
        /// Defines the downloadCount.
        /// </summary>
        private int downloadCount;

        /// <summary>
        /// Defines the id.
        /// </summary>
        private string id;

        /// <summary>
        /// Defines the isInstalled.
        /// </summary>
        private bool isInstalled;

        /// <summary>
        /// Defines the isInstallPending.
        /// </summary>
        private bool isInstallPending = false;

        /// <summary>
        /// Defines the isPrerelease.
        /// </summary>
        private bool isPrerelease;

        /// <summary>
        /// Defines the lastUpdated.
        /// </summary>
        private DateTime lastUpdated;

        /// <summary>
        /// Defines the title.
        /// </summary>
        private string title;

        /// <summary>
        /// Defines the version.
        /// </summary>
        private string version;

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the DownloadCount.
        /// </summary>
        public int DownloadCount
        {
            get { return this.downloadCount; }
            set
            {
                if (this.downloadCount != value)
                {
                    this.downloadCount = value;
                    this.OnPropertyChanged(() => this.DownloadCount);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.OnPropertyChanged(() => this.Id);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsInstalled.
        /// </summary>
        public bool IsInstalled
        {
            get { return this.isInstalled; }
            set
            {
                if (this.isInstalled != value)
                {
                    this.isInstalled = value;
                    this.OnPropertyChanged(() => this.IsInstalled);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsInstallPending.
        /// </summary>
        public bool IsInstallPending
        {
            get { return this.isInstallPending; }
            set
            {
                if (this.isInstallPending != value)
                {
                    this.isInstallPending = value;
                    this.OnPropertyChanged(() => this.IsInstallPending);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsPrerelease.
        /// </summary>
        public bool IsPrerelease
        {
            get { return this.isPrerelease; }
            set
            {
                if (this.isPrerelease != value)
                {
                    this.isPrerelease = value;
                    this.OnPropertyChanged(() => this.IsPrerelease);
                }
            }
        }

        /// <summary>
        /// Gets or sets the LastUpdated.
        /// </summary>
        public DateTime LastUpdated
        {
            get { return this.lastUpdated; }
            set
            {
                if (this.lastUpdated != value)
                {
                    this.lastUpdated = value;
                    this.OnPropertyChanged(() => this.LastUpdated);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.OnPropertyChanged(() => this.Title);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public string Version
        {
            get { return this.version; }
            set
            {
                if (this.version != value)
                {
                    this.version = value;
                    this.OnPropertyChanged(() => this.Version);
                }
            }
        }

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="propertyExpression">The propertyExpression <see cref="Expression{Func{T}}"/>.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            Type type = this.GetType();

            var member = propertyExpression.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyExpression.ToString()));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyExpression.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyExpression.ToString(),
                    type));

            this.OnPropertyChanged(propInfo.Name);
        }

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName <see cref="string"/>.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}