using System.Threading.Tasks;

namespace ZoeProg.Core
{
  public interface IUndoableCommand
  {
    Task ExecuteAsync();

    Task UnExecuteAsync();
  }
}