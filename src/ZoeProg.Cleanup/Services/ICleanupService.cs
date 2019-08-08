using Prism.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZoeProg.Common;

namespace ZoeProg.Cleanup.Services
{
  public interface ICleanupService
  {
    List<string> GetAll();

    Task CleanTempFilesAsync();
  }

  public class TempFileEvent : PubSubEvent
  {
  }

  public class CleanupService : ICleanupService
  {
    private readonly IPowerShellService powerShellService;

    private readonly IEventAggregator eventAggregator;
    private List<string> tempFiles;

    public CleanupService(IPowerShellService powerShellService, IEventAggregator eventAggregator)
    {
      this.powerShellService = powerShellService ?? throw new ArgumentNullException(nameof(powerShellService));
      this.eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

      this.DoAsync().GetAwaiter();
    }

    public async Task CleanTempFilesAsync()
    {
      var cmd = "Get-ChildItem $env:TEMP | foreach { Remove-Item $_}";
      var sd = await this.powerShellService.RunCommand<string>(cmd, "List");
      await DoAsync();
    }

    public List<string> GetAll()
    {
      return this.tempFiles;
    }

    private async Task DoAsync()
    {
      await Task.Delay(1000);
      var cmd = "Get-ChildItem $env:TEMP";
      var sd = await this.powerShellService.RunCommand<string>(cmd, "List");
      this.tempFiles = new List<string>(sd);
      this.eventAggregator.GetEvent<TempFileEvent>().Publish();
    }
  }
}