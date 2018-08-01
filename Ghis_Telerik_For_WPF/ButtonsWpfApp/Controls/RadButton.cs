using ButtonsWpfApp.Controls;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Telerik.Windows.Controls
{
  /// <summary>
  /// A Button control.
  /// </summary>
  // Token: 0x02000037 RID: 55
  //[LicenseProvider(typeof(TelerikLicenseProvider))]
  public class RadButton : Button
  {
    public static readonly RoutedEvent ActivateEvent;

    /// <summary>
    /// Identifies the CornerRadius property.
    /// </summary>
    // Token: 0x040000A4 RID: 164
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(RadButton), new PropertyMetadata(new PropertyChangedCallback(RadButton.OnCornerRadiusChanged)));

    /// <summary>
    /// Identifies the HoverDelay property.
    /// </summary>
    // Token: 0x040000A3 RID: 163
    public static readonly DependencyProperty HoverDelayProperty = DependencyProperty.Register("HoverDelay", typeof(TimeSpan), typeof(RadButton), new PropertyMetadata(TimeSpan.Zero, new PropertyChangedCallback(RadButton.OnHoverDelayChanged)));

    public static readonly RoutedEvent HoverEvent;

    /// <summary>
    /// Identifies the InnerCornerRadius property.
    /// </summary>
    // Token: 0x040000A5 RID: 165
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static readonly DependencyProperty InnerCornerRadiusProperty = DependencyProperty.Register("InnerCornerRadius", typeof(CornerRadius), typeof(RadButton), new PropertyMetadata());

    /// <summary>
    /// Identifies the IsBackgroundVisible property.
    /// </summary>
    // Token: 0x040000A6 RID: 166
    public static readonly DependencyProperty IsBackgroundVisibleProperty = DependencyProperty.Register("IsBackgroundVisible", typeof(bool), typeof(RadButton), new PropertyMetadata(true, new PropertyChangedCallback(RadButton.OnIsBackgroundVisiblePropertyChanged)));

    // Token: 0x040000A9 RID: 169
    private DispatcherTimer hoverTimer;

    // Token: 0x06000239 RID: 569 RVA: 0x000085A4 File Offset: 0x000067A4
    static RadButton()
    {
      RadButton.ActivateEvent = EventManager.RegisterRoutedEvent("Activate", RoutingStrategy.Bubble, typeof(EventHandler<RadRoutedEventArgs>), typeof(RadButton));
      RadButton.HoverEvent = EventManager.RegisterRoutedEvent("Hover", RoutingStrategy.Bubble, typeof(EventHandler<RadRoutedEventArgs>), typeof(RadButton));
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(RadButton), new FrameworkPropertyMetadata(typeof(RadButton)));
    }

    /// <summary>
    /// Initializes a new instance of the RadButton class.
    /// </summary>
    // Token: 0x0600023A RID: 570 RVA: 0x000086F0 File Offset: 0x000068F0
    public RadButton()
    {
      //TelerikLicense.Verify(this);
    }

    /// <summary>
    /// Occurs when button is clicked.
    /// </summary>
    // Token: 0x14000014 RID: 20
    // (add) Token: 0x0600023D RID: 573 RVA: 0x0000876D File Offset: 0x0000696D
    // (remove) Token: 0x0600023E RID: 574 RVA: 0x0000877B File Offset: 0x0000697B
    public event EventHandler<RadRoutedEventArgs> Activate
    {
      add
      {
        base.AddHandler(RadButton.ActivateEvent, value);
      }
      remove
      {
        base.RemoveHandler(RadButton.ActivateEvent, value);
      }
    }

    /// <summary>
    /// Occurs when button is hovered.
    /// </summary>
    // Token: 0x14000015 RID: 21
    // (add) Token: 0x0600023F RID: 575 RVA: 0x00008789 File Offset: 0x00006989
    // (remove) Token: 0x06000240 RID: 576 RVA: 0x00008797 File Offset: 0x00006997
    [Browsable(false)]
    public event EventHandler<RadRoutedEventArgs> Hover
    {
      add
      {
        base.AddHandler(RadButton.HoverEvent, value);
      }
      remove
      {
        base.RemoveHandler(RadButton.HoverEvent, value);
      }
    }

    /// <summary>
    /// Occurs when IsPressed property changes.
    /// </summary>
    // Token: 0x14000013 RID: 19
    // (add) Token: 0x0600023B RID: 571 RVA: 0x00008700 File Offset: 0x00006900
    // (remove) Token: 0x0600023C RID: 572 RVA: 0x00008738 File Offset: 0x00006938
    internal event EventHandler IsPressedChanged;

    /// <summary>
    /// Gets or sets a value that represents the degree to which the corners of the control are rounded. This is a dependency property.
    /// </summary>
    // Token: 0x17000064 RID: 100
    // (get) Token: 0x06000243 RID: 579 RVA: 0x000087CA File Offset: 0x000069CA
    // (set) Token: 0x06000244 RID: 580 RVA: 0x000087DC File Offset: 0x000069DC
    public CornerRadius CornerRadius
    {
      get
      {
        return (CornerRadius)base.GetValue(RadButton.CornerRadiusProperty);
      }
      set
      {
        base.SetValue(RadButton.CornerRadiusProperty, value);
      }
    }

    /// <summary>
    /// Gets or sets whether the popup opens when mouse hovers for pointed milliseconds
    /// Value of zero means no auto open.
    /// This is a dependency property.
    /// </summary>
    // Token: 0x17000063 RID: 99
    // (get) Token: 0x06000241 RID: 577 RVA: 0x000087A5 File Offset: 0x000069A5
    // (set) Token: 0x06000242 RID: 578 RVA: 0x000087B7 File Offset: 0x000069B7
    [Browsable(false)]
    public TimeSpan HoverDelay
    {
      get
      {
        return (TimeSpan)base.GetValue(RadButton.HoverDelayProperty);
      }
      set
      {
        base.SetValue(RadButton.HoverDelayProperty, value);
      }
    }

    /// <summary>
    /// Gets or sets a value that represents the degree to which the inner corners of the control are rounded. This is a dependency property.
    /// </summary>
    // Token: 0x17000065 RID: 101
    // (get) Token: 0x06000245 RID: 581 RVA: 0x000087EF File Offset: 0x000069EF
    // (set) Token: 0x06000246 RID: 582 RVA: 0x00008801 File Offset: 0x00006A01
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public CornerRadius InnerCornerRadius
    {
      get
      {
        return (CornerRadius)base.GetValue(RadButton.InnerCornerRadiusProperty);
      }
      set
      {
        base.SetValue(RadButton.InnerCornerRadiusProperty, value);
      }
    }

    /// <summary>
    /// Sets the visual appearance of the chrome not to render in Normal mode.
    /// </summary>
    // Token: 0x17000066 RID: 102
    // (get) Token: 0x06000247 RID: 583 RVA: 0x00008814 File Offset: 0x00006A14
    // (set) Token: 0x06000248 RID: 584 RVA: 0x00008826 File Offset: 0x00006A26
    [Browsable(false)]
    public bool IsBackgroundVisible
    {
      get
      {
        return (bool)base.GetValue(RadButton.IsBackgroundVisibleProperty);
      }
      set
      {
        base.SetValue(RadButton.IsBackgroundVisibleProperty, value);
      }
    }

    /// <summary>
    /// Invoked whenever application code or internal processes
    /// (such as a rebuilding layout pass) call.
    /// <see cref="M:System.Windows.Controls.Control.ApplyTemplate" />.
    /// </summary>
    // Token: 0x06000249 RID: 585 RVA: 0x00008839 File Offset: 0x00006A39
    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.UpdateVisualStates(false);
      this.UpdateBackgroundVisibility();
    }

    // Token: 0x0600024B RID: 587 RVA: 0x00008870 File Offset: 0x00006A70
    internal static bool HasChildOf(DependencyObject parent, DependencyObject child, bool skipParent)
    {
      if (parent == null || child == null)
      {
        return false;
      }
      if (!skipParent && parent == child)
      {
        return true;
      }
      FrameworkElement frameworkElement = child as FrameworkElement;
      DependencyObject parent2 = VisualTreeHelper.GetParent(child);
      if (parent2 == null && frameworkElement != null)
      {
        parent2 = frameworkElement.Parent;
      }
      return RadButton.HasChildOf(parent, parent2, false);
    }

    // Token: 0x0600024A RID: 586 RVA: 0x00008850 File Offset: 0x00006A50
    internal static RadRoutedEventArgs RaiseRadRoutedEvent(RoutedEvent routedEvent, UIElement source)
    {
      RadRoutedEventArgs radRoutedEventArgs = new RadRoutedEventArgs(routedEvent, source);
      source.RaiseEvent(radRoutedEventArgs);
      return radRoutedEventArgs;
    }

    // Token: 0x0600024E RID: 590 RVA: 0x000089A4 File Offset: 0x00006BA4
    internal bool GoToState(string stateName, bool useTransitions)
    {
      return VisualStateManager.GoToState(this, stateName, useTransitions);
    }

    // Token: 0x0600024F RID: 591 RVA: 0x000089AE File Offset: 0x00006BAE
    internal void OnClickInternal()
    {
      this.OnClick();
    }

    // Token: 0x0600024D RID: 589 RVA: 0x00008940 File Offset: 0x00006B40
    internal virtual void UpdateBackgroundVisibility()
    {
      if (this.IsBackgroundVisible || base.IsMouseOver || base.IsPressed)
      {
        this.GoToState("BackgroundVisible", false);
      }
      else
      {
        this.GoToState("BackgroundHidden", false);
      }
      if (this.IsBackgroundVisible)
      {
        this.GoToState("BackgroundIsVisible", false);
        return;
      }
      this.GoToState("BackgroundIsHidden", false);
    }

    // Token: 0x0600024C RID: 588 RVA: 0x000088B4 File Offset: 0x00006AB4
    internal virtual void UpdateVisualStates(bool useTransitions)
    {
      if (!base.IsEnabled)
      {
        this.GoToState("Disabled", useTransitions);
      }
      else if (base.IsPressed)
      {
        this.GoToState("Pressed", useTransitions);
      }
      else if (base.IsMouseOver)
      {
        this.GoToState("MouseOver", useTransitions);
      }
      else
      {
        this.GoToState("Normal", useTransitions);
      }
      if (base.IsFocused && base.IsEnabled)
      {
        this.GoToState("Focused", useTransitions);
        return;
      }
      this.GoToState("Unfocused", useTransitions);
    }

    /// <summary>
    /// Raises the <see cref="E:Activate" /> event.
    /// </summary>
    // Token: 0x06000250 RID: 592 RVA: 0x000089B6 File Offset: 0x00006BB6
    protected internal virtual void OnActivate()
    {
      base.RaiseEvent(new RadRoutedEventArgs(RadButton.ActivateEvent, this));
    }

    /// <summary>
    /// Invocated when the hover happens.
    /// </summary>
    // Token: 0x06000251 RID: 593 RVA: 0x000089C9 File Offset: 0x00006BC9
    protected internal virtual void OnHover()
    {
      base.RaiseEvent(new RadRoutedEventArgs(RadButton.HoverEvent, this));
    }

    /// <summary>
    /// Invoke the base OnClick and execute the associated Command.
    /// </summary>
    // Token: 0x06000252 RID: 594 RVA: 0x000089DC File Offset: 0x00006BDC
    protected override void OnClick()
    {
      base.OnClick();
      this.OnActivate();
      TraceMonitor.TrackAtomicFeature(this, "Click");
    }

    /// <summary>
    /// Creates a RadButtonAutomationPeer.
    /// </summary>
    // Token: 0x06000255 RID: 597 RVA: 0x00008A14 File Offset: 0x00006C14
    protected override AutomationPeer OnCreateAutomationPeer()
    {
      switch (AutomationManager.AutomationMode)
      {
        case AutomationMode.Disabled:
          return null;

        case AutomationMode.FrameworkOnly:
          return base.OnCreateAutomationPeer();

        default:
          return new RadButtonAutomationPeer(this);
      }
    }

    /// <summary>
    /// Invoked on got focus.
    /// </summary>
    // Token: 0x06000254 RID: 596 RVA: 0x00008A04 File Offset: 0x00006C04
    protected override void OnGotFocus(RoutedEventArgs e)
    {
      base.OnGotFocus(e);
      this.UpdateBackgroundVisibility();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.FrameworkElement.Initialized" /> event.
    /// This method is invoked whenever <see cref="P:System.Windows.FrameworkElement.IsInitialized" /> is set to true internally.
    /// </summary>
    /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs" /> that contains the event data.</param>
    // Token: 0x06000256 RID: 598 RVA: 0x00008A46 File Offset: 0x00006C46
    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
      //TODO:???
      // StyleManager.SetDefaultStyleKey(this, typeof(RadButton));
    }

    /// <summary>
    /// Called when the IsPressed property changes.
    /// </summary>
    /// <param name="e"></param>
    // Token: 0x0600025B RID: 603 RVA: 0x00008AA1 File Offset: 0x00006CA1
    protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
    {
      base.OnIsPressedChanged(e);
      if (this.IsPressedChanged != null)
      {
        this.IsPressedChanged(this, new EventArgs());
      }
    }

    /// <summary>
    /// Restarts the Hover Timer.
    /// </summary>
    /// <param name="e"></param>
    // Token: 0x0600025A RID: 602 RVA: 0x00008A98 File Offset: 0x00006C98
    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
    }

    /// <summary>
    /// Invoked on focus lost.
    /// </summary>
    // Token: 0x06000253 RID: 595 RVA: 0x000089F5 File Offset: 0x00006BF5
    protected override void OnLostFocus(RoutedEventArgs e)
    {
      base.OnLostFocus(e);
      this.UpdateBackgroundVisibility();
    }

    /// <summary>
    /// Starts the auto open timer.
    /// </summary>
    /// <param name="e"></param>
    // Token: 0x06000257 RID: 599 RVA: 0x00008A5F File Offset: 0x00006C5F
    protected override void OnMouseEnter(MouseEventArgs e)
    {
      base.OnMouseEnter(e);
      this.HoverTimerStart();
      this.UpdateBackgroundVisibility();
    }

    /// <summary>
    /// Stops the auto open timer.
    /// </summary>
    /// <param name="e"></param>
    // Token: 0x06000258 RID: 600 RVA: 0x00008A74 File Offset: 0x00006C74
    protected override void OnMouseLeave(MouseEventArgs e)
    {
      this.HoverTimerStop();
      base.OnMouseLeave(e);
      this.UpdateBackgroundVisibility();
    }

    /// <summary>
    /// Restarts the auto open timer.
    /// </summary>
    /// <param name="e"></param>
    // Token: 0x06000259 RID: 601 RVA: 0x00008A89 File Offset: 0x00006C89
    protected override void OnMouseMove(MouseEventArgs e)
    {
      this.HoverTimerRestart();
      base.OnMouseMove(e);
    }

    // Token: 0x0600025D RID: 605 RVA: 0x00008AE4 File Offset: 0x00006CE4
    private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      RadButton radButton = d as RadButton;
      CornerRadius cornerRadius = (CornerRadius)e.NewValue;
      if (radButton != null)
      {
        radButton.InnerCornerRadius = new CornerRadius(Math.Max(0.0, cornerRadius.TopLeft - 1.0), Math.Max(0.0, cornerRadius.TopRight - 1.0), Math.Max(0.0, cornerRadius.BottomRight - 1.0), Math.Max(0.0, cornerRadius.BottomLeft - 1.0));
      }
    }

    // Token: 0x0600025C RID: 604 RVA: 0x00008AC4 File Offset: 0x00006CC4
    private static void OnHoverDelayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      RadButton radButton = d as RadButton;
      if (radButton != null)
      {
        radButton.HoverTimerApplyState(true);
      }
    }

    // Token: 0x0600025E RID: 606 RVA: 0x00008B94 File Offset: 0x00006D94
    private static void OnIsBackgroundVisiblePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      RadButton radButton = d as RadButton;
      if (radButton != null)
      {
        radButton.UpdateBackgroundVisibility();
      }
    }

    // Token: 0x06000264 RID: 612 RVA: 0x00008C34 File Offset: 0x00006E34
    private bool HoverTimerApplyState(bool applyAction)
    {
      double totalMilliseconds = this.HoverDelay.TotalMilliseconds;
      if (totalMilliseconds > 0.0)
      {
        if (this.hoverTimer == null)
        {
          this.hoverTimer = new DispatcherTimer();
          this.hoverTimer.Tick += this.OnHoverTimerTick;
        }
        if (totalMilliseconds != this.hoverTimer.Interval.TotalMilliseconds)
        {
          this.hoverTimer.Interval = this.HoverDelay;
        }
        if (applyAction)
        {
          if (base.IsMouseOver)
          {
            this.HoverTimerStart();
          }
          else
          {
            this.HoverTimerStop();
          }
        }
      }
      else
      {
        this.HoverTimerDestroy();
      }
      return this.hoverTimer != null;
    }

    // Token: 0x06000260 RID: 608 RVA: 0x00008BBF File Offset: 0x00006DBF
    private void HoverTimerDestroy()
    {
      if (this.hoverTimer != null)
      {
        this.hoverTimer.Stop();
        this.hoverTimer.Tick -= this.OnHoverTimerTick;
        this.hoverTimer = null;
      }
    }

    // Token: 0x06000263 RID: 611 RVA: 0x00008C1E File Offset: 0x00006E1E
    private void HoverTimerRestart()
    {
      if (this.HoverTimerApplyState(false))
      {
        this.hoverTimer.Start();
      }
    }

    // Token: 0x06000261 RID: 609 RVA: 0x00008BF2 File Offset: 0x00006DF2
    private void HoverTimerStart()
    {
      if (this.HoverTimerApplyState(false))
      {
        this.hoverTimer.Start();
      }
    }

    // Token: 0x06000262 RID: 610 RVA: 0x00008C08 File Offset: 0x00006E08
    private void HoverTimerStop()
    {
      if (this.HoverTimerApplyState(false))
      {
        this.hoverTimer.Stop();
      }
    }

    // Token: 0x0600025F RID: 607 RVA: 0x00008BB1 File Offset: 0x00006DB1
    private void OnHoverTimerTick(object sender, EventArgs e)
    {
      this.HoverTimerStop();
      this.OnHover();
    }
  }
}