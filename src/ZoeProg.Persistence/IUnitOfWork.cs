namespace ZoeProg.Persistence
{
  public interface IUnitOfWork
  {
    bool SaveChanges();
  }
}