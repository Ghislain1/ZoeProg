using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Ghis.Controls.Windows
{
  public class GhisWindow : DpiAwareWindow
  {
    /// <summary>
    /// Identifies the BackgroundContent dependency property.
    /// </summary>
    public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register("BackgroundContent", typeof(object), typeof(GhisWindow));

    /// <summary>
    /// Defines the ContentSource dependency property.
    /// </summary>
    public static readonly DependencyProperty ContentSourceProperty = DependencyProperty.Register("ContentSource", typeof(Uri), typeof(GhisWindow));

    /// <summary>
    /// Identifies the IsTitleVisible dependency property.
    /// </summary>
    public static readonly DependencyProperty IsTitleVisibleProperty = DependencyProperty.Register("IsTitleVisible", typeof(bool), typeof(GhisWindow), new PropertyMetadata(false));

    /// <summary>
    /// Identifies the LogoData dependency property.
    /// </summary>
    public static readonly DependencyProperty LogoDataProperty = DependencyProperty.Register("LogoData", typeof(Geometry), typeof(GhisWindow));

    private Storyboard backgroundAnimation;

    /// <summary>
    /// Initializes a new instance of the <see cref="GhisWindow"/> class.
    /// </summary>
    public GhisWindow()
    {
      this.DefaultStyleKey = typeof(GhisWindow);

      // create empty collections
      //SetCurrentValue(MenuLinkGroupsProperty, new LinkGroupCollection());
      //SetCurrentValue(TitleLinksProperty, new LinkCollection());

      // associate window commands with this instance

      this.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
      this.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
      this.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
      this.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));

      // associate navigate link command with this instance
      //this.CommandBindings.Add(new CommandBinding(LinkCommands.NavigateLink, OnNavigateLink, OnCanNavigateLink));

      // listen for theme changes
      //AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
    }

    /// <summary>
    /// Gets or sets the background content of this window instance.
    /// </summary>
    public object BackgroundContent
    {
      get { return GetValue(BackgroundContentProperty); }
      set { SetValue(BackgroundContentProperty, value); }
    }

    /// <summary>
    /// Gets or sets the source uri of the current content.
    /// </summary>
    public Uri ContentSource
    {
      get { return (Uri)GetValue(ContentSourceProperty); }
      set { SetValue(ContentSourceProperty, value); }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the window title is visible in the UI.
    /// </summary>
    public bool IsTitleVisible
    {
      get { return (bool)GetValue(IsTitleVisibleProperty); }
      set { SetValue(IsTitleVisibleProperty, value); }
    }

    /// <summary>
    /// Gets or sets the collection of links that appear in the menu in the title area of the window.
    /// </summary>
    //public LinkCollection TitleLinks
    //{
    //  get { return (LinkCollection)GetValue(TitleLinksProperty); }
    //  set { SetValue(TitleLinksProperty, value); }
    //}
    /// <summary>
    /// Gets or sets the path data for the logo displayed in the title area of the window.
    /// </summary>
    public Geometry LogoData
    {
      get { return (Geometry)GetValue(LogoDataProperty); }
      set { SetValue(LogoDataProperty, value); }
    }

    /// <summary>
    /// When overridden in a derived class, is invoked whenever application code or internal processes call System.Windows.FrameworkElement.ApplyTemplate().
    /// </summary>
    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      // retrieve BackgroundAnimation storyboard
      var border = GetTemplateChild("WindowBorder") as Border;
      if (border != null)
      {
        this.backgroundAnimation = border.Resources["BackgroundAnimation"] as Storyboard;

        if (this.backgroundAnimation != null)
        {
          this.backgroundAnimation.Begin();
        }
      }
    }

    /// <summary>
    /// Raises the System.Windows.Window.Closed event.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);

      // detach event handler
      //AppearanceManager.Current.PropertyChanged -= OnAppearanceManagerPropertyChanged;
    }

    private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      // start background animation if theme has changed
      if (e.PropertyName == "ThemeSource" && this.backgroundAnimation != null)
      {
        this.backgroundAnimation.Begin();
      }
    }

    private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
    }

    private void OnCanNavigateLink(object sender, CanExecuteRoutedEventArgs e)
    {
      // true by default
      e.CanExecute = true;

      //if (this.LinkNavigator != null && this.LinkNavigator.Commands != null)
      //{
      //  // in case of command uri, check if ICommand.CanExecute is true
      //  Uri uri;
      //  string parameter;
      //  string targetName;

      //  // TODO: CanNavigate is invoked a lot, which means a lot of parsing. need improvements??
      //  //if (NavigationHelper.TryParseUriWithParameters(e.Parameter, out uri, out parameter, out targetName))
      //  //{
      //  //  ICommand command;
      //  //  if (this.LinkNavigator.Commands.TryGetValue(uri, out command))
      //  //  {
      //  //    e.CanExecute = command.CanExecute(parameter);
      //  //  }
      //  //}
      //}
    }

    private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
    }

    private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
    {
      SystemCommands.CloseWindow(this);
    }

    private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
    {
      SystemCommands.MaximizeWindow(this);
    }

    private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
    {
      SystemCommands.MinimizeWindow(this);
    }

    private void OnNavigateLink(object sender, ExecutedRoutedEventArgs e)
    {
      //if (this.LinkNavigator != null)
      //{
      //  Uri uri;
      //  string parameter;
      //  string targetName;

      //  //if (NavigationHelper.TryParseUriWithParameters(e.Parameter, out uri, out parameter, out targetName))
      //  //{
      //  //  this.LinkNavigator.Navigate(uri, e.Source as FrameworkElement, parameter);
      //  //}
      //}
    }

    private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
    {
      SystemCommands.RestoreWindow(this);
    }

    /// <summary>
    /// Gets or sets the collection of link groups shown in the window's menu.
    /// </summary>
    //public LinkGroupCollection MenuLinkGroups
    //{
    //  get { return (LinkGroupCollection)GetValue(MenuLinkGroupsProperty); }
    //  set { SetValue(MenuLinkGroupsProperty, value); }
    //}
    /// <summary>
    /// Gets or sets the content loader.
    /// </summary>
    //public IContentLoader ContentLoader
    //{
    //  get { return (IContentLoader)GetValue(ContentLoaderProperty); }
    //  set { SetValue(ContentLoaderProperty, value); }
    //}

    /// <summary>
    /// Gets or sets the link navigator.
    /// </summary>
    /// <value>The link navigator.</value>
    //public ILinkNavigator LinkNavigator
    //{
    //  get { return (ILinkNavigator)GetValue(LinkNavigatorProperty); }
    //  set { SetValue(LinkNavigatorProperty, value); }
    //}
  }
}