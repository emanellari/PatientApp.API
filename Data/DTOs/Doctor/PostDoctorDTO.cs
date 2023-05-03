namespace PatientApp.API.Data.DTOs.Doctor
{
    public class PostDoctorDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SpecializationField { get; set; }
        public int ExperienceYears { get; set; }
        public int PhoneNumber { get; set; }
    }
}
