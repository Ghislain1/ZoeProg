using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfTemplateHacker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCopyTemplate_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.txtTemplate.Text, TextDataFormat.Text);
        }

        private void FillDependencyObject(DependencyObject o)
        {
            if (o is MenuBase)
                (o as MenuBase).Items.Add("Menüpunkt");
            if (o is HeaderedContentControl)
                (o as HeaderedContentControl).Header = "Einfacher Header";
            if (o is ContentControl)
                (o as ContentControl).Content = "Templates rocken";
            if (o is HeaderedItemsControl)
                (o as HeaderedItemsControl).Header = "Einfacher Header";
            if (o is ItemsControl)
            {
                (o as ItemsControl).Items.Add("Templates rocken");
                (o as ItemsControl).Items.Add("Templates rocken");
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = e.Source as ListView;
            if (lv.SelectedItem == null)
                return;

            TemplateType tt = lv.SelectedItem as TemplateType;
            cboProperties.ItemsSource = tt.TemplateProperties;
            cboProperties.SelectedIndex = 0;

            TryWriteTempalteToTextBox();
        }

        private void PropertiesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TryWriteTempalteToTextBox();
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (content == null)
                return;

            ComboBox themes = sender as ComboBox;
            Theme theme = themes.SelectedItem as Theme;
            if (theme != null)
            {
                content.Resources = (ResourceDictionary)Application.LoadComponent(new Uri(theme.PackURI, UriKind.Relative));
                TryWriteTempalteToTextBox();
            }
        }

        private void TryShowDependencyObject(DependencyObject o)
        {
            content.Content = null;
            content.ContextMenu = null;

            if (o is ContextMenu)
                content.ContextMenu = o as ContextMenu;
            else if (o is NavigationWindow)
            {
                (o as NavigationWindow).WindowState = WindowState.Minimized;
                (o as NavigationWindow).ShowInTaskbar = false;
                (o as NavigationWindow).Show();
                (o as NavigationWindow).Hide();
            }
            else if (o is Page)
            {
                Frame f = new Frame();
                f.Content = o;
                content.Content = f;
            }
            else if (o is ToolTip)
                ;
            else if (o is Window)
                ;
            else
                content.Content = o;
        }

        private void TryWriteTempalteToTextBox()
        {
            TemplateType tt = listView.SelectedItem as TemplateType;
            if (tt == null)
                return;

            PropertyInfo pi = cboProperties.SelectedItem as PropertyInfo;
            if (pi == null)
                return;

            DependencyObject depObj = Activator.CreateInstance(tt.Type) as DependencyObject;
            if (depObj == null)
                return;
            FillDependencyObject(depObj);
            TryShowDependencyObject(depObj);

            object o = pi.GetValue(depObj, null);
            if (o == null)
                txtTemplate.Text = "ist null.";
            else
            {
                XmlWriterSettings set = new XmlWriterSettings();
                set.Indent = true;
                set.IndentChars = "  ";
                set.OmitXmlDeclaration = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter w = XmlWriter.Create(sb, set);
                XamlWriter.Save(o, w);
                w.Close();

                txtTemplate.Text = sb.ToString();
            }
        }
    }
}