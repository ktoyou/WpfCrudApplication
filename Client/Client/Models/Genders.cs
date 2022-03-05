using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    enum Genders
    {
        [LocalizedDescription("male", typeof(Properties.Resources))] male,
        [LocalizedDescription("female", typeof(Properties.Resources))] female
    }
}
