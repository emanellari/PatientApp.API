namespace PatientApp.API.Data.DTOs.Patient
{
    public class PostPatientDTO
    {
        public string PatientNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public double GPA { get; set; }

        //Add a reference to Doctor table
        public int DoctorId { get; set; }
    }
}











