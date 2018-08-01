using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonsWpfApp.Controls
{
  /// <summary>
  /// This interface represents a monitor which receives trace events from RadControls. You can implement it if you need to
  /// receive trace events from the controls used in your application.
  /// </summary>
  // Token: 0x02000004 RID: 4
  public interface ITraceMonitor
  {
    /// <summary>
    /// This method is called when an atomic feature is executed.
    /// </summary>
    /// <param name="feature">The feature to be tracked.</param>
    // Token: 0x06000004 RID: 4
    void TrackAtomicFeature(string feature);

    /// <summary>
    /// Traces an error in a specified feature.
    /// </summary>
    /// <param name="feature">The feature in which the error occurred.</param>
    /// <param name="exception">The error that occurred.</param>
    // Token: 0x06000008 RID: 8
    void TrackError(string feature, Exception exception);

    /// <summary>
    /// This method is called when a feature is canceled.
    /// </summary>
    /// <param name="feature">The feature that was canceled.</param>
    // Token: 0x06000007 RID: 7
    void TrackFeatureCancel(string feature);

    /// <summary>
    /// This method is called when a feature finishes execution.
    /// </summary>
    /// <param name="feature">The feature that finished.</param>
    // Token: 0x06000006 RID: 6
    void TrackFeatureEnd(string feature);

    /// <summary>
    /// This method is called when a feature is initiated.
    /// </summary>
    /// <param name="feature">The feature that was initiated.</param>
    // Token: 0x06000005 RID: 5
    void TrackFeatureStart(string feature);

    /// <summary>
    /// This method is called when a value connected with a specific feature is tracked.
    /// </summary>
    /// <param name="feature">The feature that produced the value.</param>
    /// <param name="value">The value that was tracked by the feature.</param>
    // Token: 0x06000009 RID: 9
    void TrackValue(string feature, long value);
  }
}