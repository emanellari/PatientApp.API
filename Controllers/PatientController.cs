using Microsoft.AspNetCore.Mvc;
using PatientApp.API.Data;
using PatientApp.API.Data.DTOs.Patient;
using PatientApp.API.Data.Models;
using PatientApp.API.Data;

namespace PatientApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public PatientController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            var allPatients = _appDbContext.Patients.ToList();
            return Ok(allPatients);
        }

        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetPatientById/{id}")]
        public IActionResult GetPatientById(int id)
        {
            var Patient = _appDbContext.Patients.FirstOrDefault(x => x.Id == id);
            return Ok($"Patienti me id = {id} u kthye me sukses!");
        }

        [HttpPost("AddPatient")]
        public IActionResult AddPatient([FromBody] PostPatientDTO payload)
        {
            //1. Krijo nje objekt Patient me te dhenat e marra nga payload
            Patient newPatient = new Patient()
            {
                PatientNumber = payload.PatientNumber,
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DOB = DateTime.UtcNow.AddYears(-20),
                GPA = payload.GPA,
                DateCreated = DateTime.UtcNow,

                DoctorId = payload.DoctorId
            };

            _appDbContext.Patients.Add(newPatient);
            _appDbContext.SaveChanges();

            return Ok("Patienti u krijua me sukses!");
        }

        [HttpPut("UpdatePatient")]
        public IActionResult UpdatePatient([FromBody] PutPatientDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var Patient = _appDbContext.Patients.FirstOrDefault(x => x.Id == id);
            if (Patient == null)
                return NotFound();

            //2. Perditesojme Patientin e DB me te dhenat e payload-it
            Patient.PatientNumber = payload.PatientNumber;
            Patient.FirstName = payload.FirstName;
            Patient.LastName = payload.LastName;
            Patient.DOB = DateTime.UtcNow.AddYears(-20);
            Patient.GPA = payload.GPA;

            //Add Refrence to Doctor Id
            Patient.DoctorId = payload.DoctorId;

            //3. Ruhen te dhenat ne database
            _appDbContext.Patients.Update(Patient);
            _appDbContext.SaveChanges();

            return Ok("Patienti u modifikua me sukses!");
        }

        [HttpDelete("DeletePatient/{id}")]
        public IActionResult DeletePatient(int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var Patient = _appDbContext.Patients.FirstOrDefault(x => x.Id == id);
            if (Patient == null)
                return NotFound();

            //2. Fshijme Patientin nga DB
            _appDbContext.Patients.Remove(Patient);
            _appDbContext.SaveChanges();

            return Ok($"Patienti me id = {id} u fshi me sukses!");
        }
    }
}


