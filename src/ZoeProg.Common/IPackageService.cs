{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Core.Data;

public interface IPackageService
{
    Task Install(PackageVersion package);

    Task Install(Package package, Action<string> onDataReceived, CancellationToken cancelToken);

    Task Uninstall(PackageVersion package);

    Task UnInstall(Package package, Action<string> onDataReceived, CancellationToken cancelToken);
}
}