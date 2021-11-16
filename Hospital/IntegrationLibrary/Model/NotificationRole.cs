using IntegrationLibrary.SecretaryApp.Converter;
using System.ComponentModel;

namespace IntegrationLibrary.Model
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum NotificationRole
    {
        [Description("Pacijente")]
        patient,
        [Description("Sekretare")]
        secretary,
        [Description("Menadžere")]
        manager,
        [Description("Doktore")]
        doctor,
        [Description("Sve")]
        all,
        [Description("Zaposlene")]
        workers,
        [Description("Specifične pacijente")]
        specificPatients
    }
}
