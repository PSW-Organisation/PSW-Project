using System;

namespace ehealthcare.Model
{
    public class Secretary : Employee
    {
        public string DeskPhoneNumber { get; set; }

        public Secretary(string id) : base(id)
        {
                
        }

        public override void SetWorkHours(DateTime startTime, DateTime endTime)
        {
            int shift = (endTime - startTime).Hours;
            if (shift > 6)
            {
                return;
            }
            base.SetWorkHours(startTime, endTime);
        }

        public override bool CheckHealthInsurance()
        {
            throw new NotSupportedException();
        }
    }

    public interface IContractor
    {
        public Workday Workday { get; set; }
        public void SetWorkHours(DateTime startTime, DateTime endTime);
    }
}
