using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTemplateHacker
{
    public class Theme
    {
        public string DisplayString { get; set; }
        public string PackURI { get; set; }

        public static IEnumerable<Theme> GetThemes()
        {
            yield return new Theme() { DisplayString = "Aero2", PackURI = "/PresentationFramework.Aero2;v4.0.0.0;31bf3856ad364e35;component/themes/aero2.normalcolor.xaml" };
            yield return new Theme() { DisplayString = "Aero", PackURI = "/PresentationFramework.Aero;v4.0.0.0;31bf3856ad364e35;component/themes/aero.normalcolor.xaml" };
            yield return new Theme() { DisplayString = "Luna", PackURI = "/PresentationFramework.Luna;v4.0.0.0;31bf3856ad364e35;component/themes/luna.normalcolor.xaml" };
            yield return new Theme() { DisplayString = "Luna Metallic", PackURI = "/PresentationFramework.Luna;v4.0.0.0;31bf3856ad364e35;component/themes/luna.metallic.xaml" };
            yield return new Theme() { DisplayString = "Luna Homestead", PackURI = "/PresentationFramework.Luna;v4.0.0.0;31bf3856ad364e35;component/themes/luna.homestead.xaml" };
            yield return new Theme() { DisplayString = "Classic", PackURI = "/PresentationFramework.Classic;v4.0.0.0;31bf3856ad364e35;component/themes/classic.xaml" };
            yield return new Theme() { DisplayString = "Royale", PackURI = "/PresentationFramework.Royale;v4.0.0.0;31bf3856ad364e35;component/themes/royale.normalcolor.xaml" };
        }
    }
}