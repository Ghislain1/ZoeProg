/*-
 * ---license-start
 * Zoe-App
 * ---
 * Copyright (C) 2021 GhislainOne and all other contributors
 * ---
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ---license-end
 */

namespace ZoeProg.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Media;
    using Prism.Mvvm;

    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class SettingsAppearanceViewModel : BindableBase
    {
        /// <summary>
        /// Defines the FontLarge.
        /// </summary>
        private const string FontLarge = "large";

        /// <summary>
        /// Defines the FontSmall.
        /// </summary>
        private const string FontSmall = "small";

        /// <summary>
        /// Defines the PaletteMetro.
        /// </summary>
        private const string PaletteMetro = "metro";

        /// <summary>
        /// Defines the PaletteWP.
        /// </summary>
        private const string PaletteWP = "windows phone";

        // 9 accent colors from metro design principles
        /// <summary>
        /// Defines the metroAccentColors.
        /// </summary>
        private Color[] metroAccentColors = new Color[]{
            Color.FromRgb(0x33, 0x99, 0xff),   // blue
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x33, 0x99, 0x33),   // green
            Color.FromRgb(0x8c, 0xbf, 0x26),   // lime
            Color.FromRgb(0xf0, 0x96, 0x09),   // orange
            Color.FromRgb(0xff, 0x45, 0x00),   // orange red
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xff, 0x00, 0x97),   // magenta
            Color.FromRgb(0xa2, 0x00, 0xff),   // purple
        };

        /// <summary>
        /// Defines the selectedAccentColor.
        /// </summary>
        private Color selectedAccentColor;

        /// <summary>
        /// Defines the selectedFontSize.
        /// </summary>
        private string selectedFontSize;

        /// <summary>
        /// Defines the selectedPalette.
        /// </summary>
        private string selectedPalette = PaletteWP;

        /// <summary>
        /// Defines the selectedTheme.
        /// </summary>
        private string selectedTheme;

        // 20 accent colors from Windows Phone 8
        /// <summary>
        /// Defines the wpAccentColors.
        /// </summary>
        private Color[] wpAccentColors = new Color[]{
            Color.FromRgb(0xa4, 0xc4, 0x00),   // lime
            Color.FromRgb(0x60, 0xa9, 0x17),   // green
            Color.FromRgb(0x00, 0x8a, 0x00),   // emerald
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x1b, 0xa1, 0xe2),   // cyan
            Color.FromRgb(0x00, 0x50, 0xef),   // cobalt
            Color.FromRgb(0x6a, 0x00, 0xff),   // indigo
            Color.FromRgb(0xaa, 0x00, 0xff),   // violet
            Color.FromRgb(0xf4, 0x72, 0xd0),   // pink
            Color.FromRgb(0xd8, 0x00, 0x73),   // magenta
            Color.FromRgb(0xa2, 0x00, 0x25),   // crimson
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xfa, 0x68, 0x00),   // orange
            Color.FromRgb(0xf0, 0xa3, 0x0a),   // amber
            Color.FromRgb(0xe3, 0xc8, 0x00),   // yellow
            Color.FromRgb(0x82, 0x5a, 0x2c),   // brown
            Color.FromRgb(0x6d, 0x87, 0x64),   // olive
            Color.FromRgb(0x64, 0x76, 0x87),   // steel
            Color.FromRgb(0x76, 0x60, 0x8a),   // mauve
            Color.FromRgb(0x87, 0x79, 0x4e),   // taupe
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsAppearanceViewModel"/> class.
        /// </summary>
        public SettingsAppearanceViewModel()
        {
        }

        /// <summary>
        /// Gets the AccentColors.
        /// </summary>
        public Color[] AccentColors
        {
            get { return this.selectedPalette == PaletteMetro ? this.metroAccentColors : this.wpAccentColors; }
        }

        /// <summary>
        /// Gets the FontSizes.
        /// </summary>
        public string[] FontSizes
        {
            get { return new string[] { FontSmall, FontLarge }; }
        }

        /// <summary>
        /// Gets the Palettes.
        /// </summary>
        public string[] Palettes
        {
            get { return new string[] { PaletteMetro, PaletteWP }; }
        }

        /// <summary>
        /// Gets or sets the SelectedAccentColor.
        /// </summary>
        public Color SelectedAccentColor
        {
            get { return this.selectedAccentColor; }
            set => this.SetProperty(ref this.selectedAccentColor, value);
        }

        /// <summary>
        /// Gets or sets the SelectedFontSize.
        /// </summary>
        public string SelectedFontSize
        {
            get { return this.selectedFontSize; }
            set => this.SetProperty(ref this.selectedFontSize, value);
        }

        /// <summary>
        /// Gets or sets the SelectedPalette.
        /// </summary>
        public string SelectedPalette
        {
            get { return this.selectedPalette; }
            set => this.SetProperty(ref this.selectedPalette, value);
        }

        /// <summary>
        /// Gets or sets the SelectedTheme.
        /// </summary>
        public string SelectedTheme
        {
            get { return this.selectedTheme; }
            set
            {
                if (this.selectedTheme != value)
                {
                    this.selectedTheme = value;
                    RaisePropertyChanged("SelectedTheme");
                }
            }
        }

        /// <summary>
        /// The OnAppearanceManagerPropertyChanged.
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/>.</param>
        /// <param name="e">The e <see cref="PropertyChangedEventArgs"/>.</param>
        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {
                SyncThemeAndColor();
            }
        }

        /// <summary>
        /// The SyncThemeAndColor.
        /// </summary>
        private void SyncThemeAndColor()
        {
        }
    }
}