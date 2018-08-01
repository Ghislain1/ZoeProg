using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ButtonsWpfApp.Controls
{/// <summary>
 /// Contains attached property that enables analytics features for control.
 /// </summary>
  // Token: 0x02000003 RID: 3
  public static class Analytics
  {
    /// <summary>
    /// Identifies the AnalyticsName attached property.
    /// </summary>
    // Token: 0x04000012 RID: 18
    public static readonly DependencyProperty NameProperty = DependencyProperty.RegisterAttached("Name", typeof(string), typeof(Analytics), new PropertyMetadata(null));

    /// <summary>
    /// Gets the value of the <see cref="F:Telerik.Windows.Controls.Analytics.NameProperty" /> attached property for a specified dependency object.
    /// </summary>
    /// <param name="obj">The object from which the property value is read.</param>
    /// <returns>The <see cref="F:Telerik.Windows.Controls.Analytics.NameProperty" /> property value for the object.</returns>
    // Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
    public static string GetName(DependencyObject obj)
    {
      return (string)obj.GetValue(Analytics.NameProperty);
    }

    /// <summary>
    /// Sets the value of the Dock attached property to a specified dependency object.
    /// </summary>
    /// <param name="obj">The object to which the attached property is written.</param>
    /// <param name="value">The needed <see cref="F:Telerik.Windows.Controls.Analytics.NameProperty" />value.</param>
    // Token: 0x06000002 RID: 2 RVA: 0x000020E2 File Offset: 0x000002E2
    public static void SetName(DependencyObject obj, string value)
    {
      obj.SetValue(Analytics.NameProperty, value);
    }
  }
}