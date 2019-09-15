﻿namespace ZoeProg.Core.Data
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;

    public class PackageVersion : INotifyPropertyChanged
    {
        private int downloadCount;
        private string id;
        private bool isInstalled;
        private bool isInstallPending = false;
        private bool isPrerelease;
        private DateTime lastUpdated;
        private string title;
        private string version;

        public event PropertyChangedEventHandler PropertyChanged;

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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}