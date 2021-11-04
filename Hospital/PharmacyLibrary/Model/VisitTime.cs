using System;
using System.Text;

[Serializable]
public class VisitTime
{
    private string id;
    private DateTime startTime;
    private DateTime endTime;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public DateTime StartTime
    {
        get { return startTime; }
        set { startTime = value; }
    }

    public DateTime EndTime
    {
        get { return endTime; }
        set { endTime = value; }
    }

    public bool Overlaps(DateTime start, DateTime end)
    {
        if (this.StartTime < end && start < this.EndTime)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        StringBuilder dateString = new StringBuilder("", 12);
        dateString.Append(startTime.Day.ToString() + ". ");
        if (startTime.Month == 1) { dateString.Append("Jan"); }
        else if (startTime.Month == 2) { dateString.Append("Feb"); }
        else if (startTime.Month == 3) { dateString.Append("Mart"); }
        else if (startTime.Month == 4) { dateString.Append("Apr"); }
        else if (startTime.Month == 5) { dateString.Append("Maj"); }
        else if (startTime.Month == 6) { dateString.Append("Jun"); }
        else if (startTime.Month == 7) { dateString.Append("Jul"); }
        else if (startTime.Month == 8) { dateString.Append("Avg"); }
        else if (startTime.Month == 9) { dateString.Append("Sep"); }
        else if (startTime.Month == 10) { dateString.Append("Okt"); }
        else if (startTime.Month == 11) { dateString.Append("Nov"); }
        else { dateString.Append("Dec"); }
        dateString.Append("\n");
        dateString.Append(startTime.ToString("HH:mm"));
        if (startTime.Hour > 12)
        {
            dateString.Append(" PM");
        }
        else
        {
            dateString.Append(" AM");
        }
        return dateString.ToString();
    }
    public String ToStringDoctor()
    {
        StringBuilder dateString = new StringBuilder("", 12);
        dateString.Append(startTime.Day.ToString() + ".");
        if (startTime.Month == 1) { dateString.Append("01. - "); }
        else if (startTime.Month == 2) { dateString.Append("02. - "); }
        else if (startTime.Month == 3) { dateString.Append("03. - "); }
        else if (startTime.Month == 4) { dateString.Append("04. - "); }
        else if (startTime.Month == 5) { dateString.Append("05. - "); }
        else if (startTime.Month == 6) { dateString.Append("06. - "); }
        else if (startTime.Month == 7) { dateString.Append("07. - "); }
        else if (startTime.Month == 8) { dateString.Append("08. - "); }
        else if (startTime.Month == 9) { dateString.Append("09. - "); }
        else if (startTime.Month == 10) { dateString.Append("10. - "); }
        else if (startTime.Month == 11) { dateString.Append("11. - "); }
        else { dateString.Append("12. - "); }
        dateString.Append(startTime.ToString("HH:mm"));
        if (startTime.Hour > 12)
        {
            dateString.Append(" PM");
        }
        else
        {
            dateString.Append(" AM");
        }
        return dateString.ToString();
    }
}
