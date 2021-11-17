using IntegrationLibrary.SecretaryApp.Converter;
using System.ComponentModel;

namespace IntegrationLibrary.Model
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum VisitType
    {
        [Description("Pregled")]
        examination,
        [Description("Operacija")]
        operation
    }
}
