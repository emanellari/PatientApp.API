using PatientApp.API.Data.Base;

namespace PatientApp.API.Data.Models
{
    public class Patient : BaseClass
    {
        public string PatientNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public double GPA { get; set; }

        //Add a reference to Subject table
        public int DoctorId { get; set; }
    }
}

