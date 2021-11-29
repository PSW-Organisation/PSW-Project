using ehealthcare.SecretaryApp.Converter;
using System.ComponentModel;

namespace ehealthcare.Model
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum VisitType
    {
        [Description("Examination")]
        examination,
        [Description("Operation")]
        operation
    }
}
