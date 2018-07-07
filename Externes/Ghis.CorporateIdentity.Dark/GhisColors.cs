using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Ghis.CorporateIdentity.Dark
{
    /// <summary>
    ///
    /// </summary> <remarks>
    /// Syntax: <ControlName><Property><Action> --> e.g. SystemButtonBackgroundOnMoseOver </remarks>
    public static class GhisColors
    {
        static GhisColors()
        {
            GrayColor3e3e42 = (Color)ColorConverter.ConvertFromString("#3e3e42");
            GrayBrush3e3e42 = new SolidColorBrush(GrayColor3e3e42);

            GrayColor333333 = (Color)ColorConverter.ConvertFromString("#333333");
            GrayBrush333333 = new SolidColorBrush(GrayColor333333);

            GrayColord51400 = (Color)ColorConverter.ConvertFromString("#e51400");
            GrayBrush51400 = new SolidColorBrush(GrayColord51400);

            GrayColor717171 = (Color)ColorConverter.ConvertFromString("#717171");
            GrayBrush717171 = new SolidColorBrush(GrayColor717171);

            GrayColorc1c1c1 = (Color)ColorConverter.ConvertFromString("#c1c1c1");
            GrayBrushc1c1c1 = new SolidColorBrush(GrayColorc1c1c1);

            GrayColord1d1d1 = (Color)ColorConverter.ConvertFromString("#d1d1d1");
            GrayBrushd1d1d1 = new SolidColorBrush(GrayColord1d1d1);
        }

        public static SolidColorBrush BackgroundButtonBaseBrush { get; }
        public static Color BackgroundButtonBaseColor { get; }

        /// <summary>
        /// Gets the ResourceKey for the Color of the normal ButtonBase's Background.
        /// </summary>
        public static ResourceKey BackgroundButtonBaseKey { get; }

        public static SolidColorBrush GrayBrush333333 { get; }
        public static SolidColorBrush GrayBrush3e3e42 { get; }
        public static SolidColorBrush GrayBrush51400 { get; }
        public static SolidColorBrush GrayBrush717171 { get; }
        public static SolidColorBrush GrayBrushc1c1c1 { get; }
        public static SolidColorBrush GrayBrushd1d1d1 { get; }
        public static Color GrayColor333333 { get; }
        public static Color GrayColor3e3e42 { get; }

        public static Color GrayColor717171 { get; }
        public static Color GrayColorc1c1c1 { get; }
        public static Color GrayColord1d1d1 { get; }
        public static Color GrayColord51400 { get; }
        // public static ResourceKey SystemButtonBackgroundOnMoseOverKey { get; }
    }
}