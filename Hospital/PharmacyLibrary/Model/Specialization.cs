using ehealthcare.SecretaryApp.Converter;
using System.ComponentModel;

namespace ehealthcare.Model
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum Specialization
    {
        [Description("Kardiologija")]
        cardiologist,
        [Description("Dermatologija")]
        dermatologist,
        [Description("Interna medicina")]
        internist,
        [Description("Opšta praksa")]
        none
    }
}
