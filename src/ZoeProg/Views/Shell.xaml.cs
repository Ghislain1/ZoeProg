/*----license-start
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

namespace ZoeProg.Views
{
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class Shell : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        public Shell()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The HamburgerMenuControl_ItemClick.
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/>.</param>
        /// <param name="e">The e <see cref="ItemClickEventArgs"/>.</param>
        private void HamburgerMenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            // this.HamburgerMenuControl.Content = (e.ClickedItem as HamburgerMenuGlyphItem).Tag;
            // this.HamburgerMenuControl.IsPaneOpen = false;
            var ds = this.HamburgerMenuControl.SelectedItem;
        }
    }
}