namespace ZoeProg.Common
{
  using MaterialDesignThemes.Wpf;

  public interface ITabItem
  {
    string BackgroudImage { get; }
    PackIconKind IconTitle { get; }
    string Title { get; }
  }
}