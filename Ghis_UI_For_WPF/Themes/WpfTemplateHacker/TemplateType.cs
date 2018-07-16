namespace WpfTemplateHacker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public class TemplateType
    {
        private static Assembly _presentationFramework;
        private List<PropertyInfo> _templateProperties;

        public TemplateType()
        {
            _templateProperties = new List<PropertyInfo>();
        }

        public List<PropertyInfo> TemplateProperties
        {
            get { return _templateProperties; }
        }

        public Type Type { get; set; }

        public static IEnumerable<TemplateType> GetTemplateTypes()
        {
            if (_presentationFramework == null)
            {
                _presentationFramework = Assembly.Load("PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            }
            TemplateType templateType = null;
            foreach (Type t in _presentationFramework.GetTypes())
            {
                if (!t.IsClass || t.IsNotPublic || t.IsAbstract || t.ContainsGenericParameters || t.GetConstructor(Type.EmptyTypes) == null)
                    continue;

                templateType = null;
                foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (typeof(FrameworkTemplate).IsAssignableFrom(pi.PropertyType))
                    {
                        if (templateType == null)
                            templateType = new TemplateType() { Type = t };
                        templateType.TemplateProperties.Add(pi);
                    }
                }
                if (templateType != null)
                    yield return templateType;
            }
        }
    }
}