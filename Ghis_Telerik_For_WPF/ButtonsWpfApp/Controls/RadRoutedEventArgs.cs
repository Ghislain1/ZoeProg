using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ButtonsWpfApp.Controls
{/// <summary>
 /// Contains state information and event data associated with a routed event.
 /// </summary>
  // Token: 0x02000073 RID: 115
  public class RadRoutedEventArgs : RoutedEventArgs
  {
    /// <summary>
    /// Initializes a new instance of the RadRoutedEventArgs class.
    /// </summary>
    // Token: 0x06000626 RID: 1574 RVA: 0x00015412 File Offset: 0x00013612
    public RadRoutedEventArgs()
    {
    }

    /// <summary>
    /// Initializes a new instance of the RadRoutedEventArgs class,
    /// using the supplied routed event identifier.
    /// </summary>
    /// <param name="routedEvent">
    /// The routed event identifier for this instance of the RoutedEventArgs class.
    /// </param>
    // Token: 0x06000627 RID: 1575 RVA: 0x0001541A File Offset: 0x0001361A
    public RadRoutedEventArgs(RoutedEvent routedEvent) : this(routedEvent, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the RadRoutedEventArgs class, using
    /// the supplied routed event identifier, and providing the opportunity
    /// to declare a different source for the event.
    /// </summary>
    /// <param name="routedEvent">
    /// The routed event identifier for this instance of the RoutedEventArgs class.
    /// </param>
    /// <param name="source">
    /// An alternate source that will be reported when the event is handled.
    /// This pre-populates the Source property.
    /// </param>
    // Token: 0x06000628 RID: 1576 RVA: 0x00015424 File Offset: 0x00013624
    public RadRoutedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
    {
    }

    /// <summary>
    /// Initializes a new instance of the RadRoutedEventArgs class, using
    /// the supplied routed event identifier, and providing the opportunity
    /// to declare a different source for the event.
    /// </summary>
    /// <param name="source">
    /// An alternate source that will be reported when the event is handled.
    /// This pre-populates the Source property.
    /// </param>
    // Token: 0x06000629 RID: 1577 RVA: 0x0001542E File Offset: 0x0001362E
    public RadRoutedEventArgs(object source) : base(null, source)
    {
    }
  }
}