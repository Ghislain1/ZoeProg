namespace ZoeProg.Common.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class FunctionItem : IPlugIn, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Code { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public bool IsSelected { get; set; }
        public string NavigatePath => throw new NotImplementedException();
        string IPlugIn.NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get; set; }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            Type type = this.GetType();

            var member = propertyExpression.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyExpression.ToString()));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyExpression.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyExpression.ToString(),
                    type));

            this.OnPropertyChanged(propInfo.Name);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}