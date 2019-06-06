
namespace ZoeProg.PlugIns.StyleTemplate.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml;

    public class WpfControlProvider : IWpfControlProvider, IXamlWriteService
    {
        public string GetXamlString(ControlTemplate controlTemplate)
        {
            StringBuilder stringBuilder = new StringBuilder(); // To store Template as string
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineHandling = NewLineHandling.None;
            xmlWriterSettings.NewLineOnAttributes = false;
            xmlWriterSettings.OmitXmlDeclaration = true; // No Xml declaration

            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings);
            XamlWriter.Save(controlTemplate, xmlWriter);
            return stringBuilder.ToString();

        }

        public List<Type> RetrieveControls()
        {
            Type baseType = typeof(Button); //why Button?
            Assembly baseAssemBy = Assembly.GetAssembly(baseType);
            Type[] allTypes = baseAssemBy.GetTypes();
            var ctrList = allTypes.Where(ty => ty.IsSubclassOf(typeof(Control)) && !ty.IsAbstract && ty.IsPublic);
            var list = ctrList.OrderBy(t => t.Name).Select(t => t).ToList();

            return list;
        }
    }
}
