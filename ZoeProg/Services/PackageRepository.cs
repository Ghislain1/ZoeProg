namespace ZoeProg.Services
{
    using Common.Data;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Common;

    public class PackageRepository : IPackageRepository
    {
        private readonly IPowerShellService powerShellService;

        public PackageRepository(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        public Task<List<Package>> GetListAvailabePackages(string folderName, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InstalledPackage>> GetListInstalledPackages(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            string pattern = @"Name=""(?<name>.+)"",Version=""(?<version>\d.+)""";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            IEnumerable<string> psOutput = null;
            string cmd = Cmds.ListInstalledPackCmd;
            var result = new List<InstalledPackage>();
            try
            {
                psOutput = await this.powerShellService.RunCommand(token, cmd);
            }
            catch (Exception)
            {
                throw;
            }

            foreach (var item in psOutput)
            {
                token.ThrowIfCancellationRequested();

                if (!string.IsNullOrEmpty(item))
                {
                    var package = this.CreateInstalledPackage(item, regex);
                    result.Add(package);
                }
            }
            return result;
        }

        public Task<List<InstalledPackage>> GetListInstalledPackages(CancellationTokenSource cancellationTokenSource)
        {
            throw new NotImplementedException();
        }

        private Package CreateInstalledPackage(string input, Regex regex)
        {
            Package installedPackage = new Package();

            var match = regex.Match(input);

            if (match.Success)
            {
                installedPackage.Title = match.Groups["name"].Value;
                installedPackage.Version = match.Groups["version"].Value;
            }
            else
            {
                throw new Exception("Impossibe");
            }
            return installedPackage;
        }

        public class PackageService : IPackageService
        {
            public Task Install(PackageVersion package)
            {
                throw new NotImplementedException();
            }

            public Task Install(Package package, Action<string> onDataReceived, CancellationToken cancelToken)
            {
                throw new NotImplementedException();
            }

            public Task Uninstall(PackageVersion package)
            {
                throw new NotImplementedException();
            }

            public Task UnInstall(Package package, Action<string> onDataReceived, CancellationToken cancelToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}