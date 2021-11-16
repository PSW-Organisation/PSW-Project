using System;
using IntegrationLibrary.Proxies;
using IntegrationLibrary.Model;
using static IntegrationLibrary.SecretaryApp.Constants;

[Serializable]
public class Holiday : Entity
{
    private DateTime startDate;
    private DateTime endDate;
    private IDoctor lazyDoctor;
    private Doctor doctor;

    public Holiday() : base("undefinedNumberKey") 
    {
        lazyDoctor = new DoctorProxyImpl();
    }

    public DateTime StartDate 
    {
        get
        {
            return startDate;
        }
        set
        {
            startDate = value;
        }
    }
    public DateTime EndDate
    {
        get
        {
            return endDate;
        }
        set
        {
            endDate = value;
        }
    }

    [System.Xml.Serialization.XmlIgnore]
    public Doctor Doctor
    {
        get
        {
            if (doctor == null)
            {
                doctor = lazyDoctor.GetDoctor(DoctorId);
            }
            return doctor;
        }
        set
        {
            doctor = value;
            DoctorId = value.Id;
        }
    }

    public String DoctorId { get; set; }

    public bool CanUseHoliday()
    {
        int definedHoliday = (EndDate - StartDate).Days;
        int availableOffDays = MaxOffDays - Doctor.UsedOffDays;

        if (definedHoliday <= availableOffDays)
        {
            return true;
        }

        return false;
    }

    public bool Overlaps(Holiday holiday)
    {
        if (this.StartDate < holiday.EndDate && holiday.StartDate < this.EndDate)
        {
            return true;
        }

        return false;
    }
}