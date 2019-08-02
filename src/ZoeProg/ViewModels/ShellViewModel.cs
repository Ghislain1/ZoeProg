namespace ZoeProg.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;

    /// <summary>
    /// Note: we call this triple-slash-comments
    /// </summary>
    public class ShellViewModel : BindableBase, IShellViewModel
    {
        private object activatedItem;
        private bool isPaneOpen;

        private string title = "ZoeProg - Tool";

        public ShellViewModel()
        {
        }

        public object ActivatedItem
        {
            get { return this.activatedItem; }
            set
            {
                this.SetProperty(ref activatedItem, value);
            }
        }

        public bool IsPaneOpen
        {
            get { return this.isPaneOpen; }
            set
            {
                this.SetProperty(ref this.isPaneOpen, value);
            }
        }

        public DelegateCommand<object> NavigateCommand { get; private set; }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}