using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Client.Extensions
{
    class EnumBindingExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingExtension(Type type)
        {
            if (type is null || !type.IsEnum)
                throw new NullReferenceException($"{nameof(type)} must be of type Enum and must be not be null");
            EnumType = type;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
