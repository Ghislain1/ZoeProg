using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ButtonsWpfApp.Controls
{/// <summary>
 /// This class supports the infrastructure of the controls. It has an AnalyticsMonitor property which receives trace events from certain features of the controls.
 /// </summary>
  // Token: 0x02000006 RID: 6
  public static class TraceMonitor
  {
    /// <summary>
    /// Gets or sets the monitor, which the controls report to.
    /// </summary>
    // Token: 0x17000002 RID: 2
    // (get) Token: 0x06000016 RID: 22 RVA: 0x0000225F File Offset: 0x0000045F
    // (set) Token: 0x06000017 RID: 23 RVA: 0x00002266 File Offset: 0x00000466
    public static ITraceMonitor AnalyticsMonitor { get; set; }

    // Token: 0x06000018 RID: 24 RVA: 0x00002270 File Offset: 0x00000470
    internal static void TrackAtomicFeature(DependencyObject control, string traceEvent, object value)
    {
      string text = TraceMonitor.GetFeatureName(control, traceEvent);
      if (text != null)
      {
        string text2 = (value == null) ? null : Convert.ToString(value);
        if (string.IsNullOrWhiteSpace(text2))
        {
          text = string.Format("{0}.NULL", text);
        }
        else
        {
          text = string.Format("{0}.{1}", text, text2);
        }
        TraceMonitor.AnalyticsMonitor.TrackAtomicFeature(text);
      }
    }

    // Token: 0x06000019 RID: 25 RVA: 0x000022C4 File Offset: 0x000004C4
    internal static void TrackAtomicFeature(DependencyObject control, string traceEvent)
    {
      string featureName = TraceMonitor.GetFeatureName(control, traceEvent);
      if (featureName != null)
      {
        TraceMonitor.AnalyticsMonitor.TrackAtomicFeature(featureName);
      }
    }

    // Token: 0x0600001C RID: 28 RVA: 0x00002330 File Offset: 0x00000530
    internal static void TrackErrorCore(DependencyObject control, string traceEvent, Exception exception)
    {
      string featureName;
      if (exception != null && (featureName = TraceMonitor.GetFeatureName(control, traceEvent)) != null)
      {
        TraceMonitor.AnalyticsMonitor.TrackError(featureName, exception);
      }
    }

    // Token: 0x0600001A RID: 26 RVA: 0x000022E8 File Offset: 0x000004E8
    internal static void TrackFeatureStart(DependencyObject control, string traceEvent)
    {
      string featureName = TraceMonitor.GetFeatureName(control, traceEvent);
      if (featureName != null)
      {
        TraceMonitor.AnalyticsMonitor.TrackFeatureStart(featureName);
      }
    }

    // Token: 0x0600001B RID: 27 RVA: 0x0000230C File Offset: 0x0000050C
    internal static void TrackFeatureStop(DependencyObject control, string traceEvent)
    {
      string featureName = TraceMonitor.GetFeatureName(control, traceEvent);
      if (featureName != null)
      {
        TraceMonitor.AnalyticsMonitor.TrackFeatureEnd(featureName);
      }
    }

    // Token: 0x0600001D RID: 29 RVA: 0x0000235C File Offset: 0x0000055C
    internal static void TrackValueCore(DependencyObject control, string traceEvent, long value)
    {
      string featureName = TraceMonitor.GetFeatureName(control, traceEvent);
      if (featureName != null)
      {
        TraceMonitor.AnalyticsMonitor.TrackValue(featureName, value);
      }
    }

    // Token: 0x0600001E RID: 30 RVA: 0x00002380 File Offset: 0x00000580
    private static string GetFeatureName(DependencyObject control, string traceEvent)
    {
      string name;
      if (TraceMonitor.AnalyticsMonitor == null || string.IsNullOrWhiteSpace(traceEvent) || string.IsNullOrWhiteSpace(name = Analytics.GetName(control)))
      {
        return null;
      }
      return string.Format("{0}.{1}", name, traceEvent);
    }
  }
}