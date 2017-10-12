namespace Zoe.UI.Navigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;

    public class ZoeButton : Button
    {
        /// <summary>
        /// Identifies the EllipseDiameter property.
        /// </summary>
        public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register("EllipseDiameter", typeof(double), typeof(ZoeButton), new PropertyMetadata(22D));

        /// <summary>
        /// Identifies the EllipseStrokeThickness property.
        /// </summary>
        public static readonly DependencyProperty EllipseStrokeThicknessProperty = DependencyProperty.Register("EllipseStrokeThickness", typeof(double), typeof(ZoeButton), new PropertyMetadata(1D));

        /// <summary>
        /// Identifies the IconData property.
        /// </summary>
        public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register("IconData", typeof(Geometry), typeof(ZoeButton));

        /// <summary>
        /// Identifies the IconHeight property.
        /// </summary>
        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register("IconHeight", typeof(double), typeof(ZoeButton), new PropertyMetadata(12D));

        /// <summary>
        /// Identifies the IconWidth property.
        /// </summary>
        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(double), typeof(ZoeButton), new PropertyMetadata(12D));

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernButton"/> class.
        /// </summary>
       // public ZoeButton() => this.DefaultStyleKey = typeof(ZoeButton);

        /// <summary>
        /// Gets or sets the ellipse diameter.
        /// </summary>
        public double EllipseDiameter
        {
            get => (double)GetValue(EllipseDiameterProperty);
            set => SetValue(EllipseDiameterProperty, value);
        }

        /// <summary>
        /// Gets or sets the ellipse stroke thickness.
        /// </summary>
        public double EllipseStrokeThickness
        {
            get => (double)GetValue(EllipseStrokeThicknessProperty);
            set => SetValue(EllipseStrokeThicknessProperty, value);
        }

        /// <summary>
        /// Gets or sets the icon path data.
        /// </summary>
        /// <value>The icon path data.</value>
        public Geometry IconData
        {
            get => (Geometry)GetValue(IconDataProperty);
            set => SetValue(IconDataProperty, value);
        }

        /// <summary>
        /// Gets or sets the icon height.
        /// </summary>
        /// <value>The icon height.</value>
        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        /// <summary>
        /// Gets or sets the icon width.
        /// </summary>
        /// <value>The icon width.</value>
        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }
    }
}