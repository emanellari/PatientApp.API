using PatientApp.API.Data.Base;

namespace PatientApp.API.Data.Models
{
    public class Doctor : BaseClass
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SpecializationField { get; set; }
        public int ExperienceYears { get; set; }
        public int PhoneNumber { get; set; }

        //Define Reference with Patient table
        public List<Patient> Patients { get; set; }
    }

}
