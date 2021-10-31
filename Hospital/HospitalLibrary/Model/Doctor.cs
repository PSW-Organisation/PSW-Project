using System;
using System.Collections.Generic;

namespace Model
{
    public class Doctor : Employee
    {
        public Speciality Speciality { get; set; }
        public List<WorkingHours> WorkingSchedule { get; set; }
        public int AvailableDaysOff { get; set; }
        public List<VacationDays> VacationDays { get; set; }

        public Doctor(string name, string surname, string jmbg, DateTime date, Sex sex, string phoneNumber, string adress, string email, string idNum, int salary, Speciality speciality, string username, string password)
        {

            this.IsDeleted = false;
            this.Name = name;
            this.Surname = surname;
            this.Jmbg = jmbg;
            this.DateOfBirth = date;
            this.Sex = sex;
            this.PhoneNumber = phoneNumber;
            this.Adress = adress;
            this.Email = email;
            this.IdCard = idNum;
            this.Username = username;
            this.Password = password;
            this.Type = UserType.doctor;
            this.SalaryInRsd = salary;
            this.Speciality = speciality;
            WorkingSchedule = new List<WorkingHours>();
            VacationDays = new List<VacationDays>();
            AvailableDaysOff = 20;

    }

        public Doctor() { }

        public string NameAndSurname
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public string SpecialityName
        {
            get
            {
                return Speciality.Name;
            }
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname;
        }
    }
}
