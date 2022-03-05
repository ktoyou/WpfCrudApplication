using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Client.Models
{
    internal class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type) :
            base(type)
        {

        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(destinationType == typeof(string))
            {
                if(value != null)
                {
                    FieldInfo field = value.GetType().GetField(value.ToString());
                    if(field != null)
                    {
                        var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        return attributes.Length > 0 && !string.IsNullOrEmpty(attributes[0].Description) ? attributes[0].Description : value.ToString();
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}