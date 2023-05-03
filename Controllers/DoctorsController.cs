using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientApp.API.Data;
using PatientApp.API.Data.DTOs.Doctor;
using PatientApp.API.Data.Models;
using PatientApp.API.Data.DTOs.Doctor;
using PatientApp.API.Data;
using PatientApp.API.Data.DTOs.Doctor;
using PatientApp.API.Data.DTOs.Doctor;

namespace PatientApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public DoctorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors()
        {
            var allDoctors = _appDbContext.Doctors.ToList();

            return Ok(allDoctors);
        }

        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetDoctorById/{id}")]
        public IActionResult GetDoctorById(int id)
        {
            var Doctor = _appDbContext.Doctors.FirstOrDefault(x => x.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }

            return Ok(Doctor);
        }

        [HttpPost("AddDoctor")]
        public IActionResult AddDoctor([FromBody] Data.DTOs.Doctor.PostDoctorDTO payload)
        {
            Doctor newDoctor = new Doctor()
            {
                Name = payload.Name,
                LastName=payload.LastName,
                Code = payload.Code,
                ExperienceYears= payload.ExperienceYears,
                PhoneNumber=payload.PhoneNumber,
                SpecializationField=payload.SpecializationField,
                DateCreated = DateTime.UtcNow
            };

            _appDbContext.Doctors.Add(newDoctor);
            _appDbContext.SaveChanges();

            return Ok("Doctori u krijua me sukses!");
        }

        [HttpPut("UpdateDoctor")]
        public IActionResult UpdateDoctor([FromBody] PutDoctorDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var Doctor = _appDbContext.Doctors.FirstOrDefault(x => x.Id == id);

            //2. Perditesojme Doctorin e DB me te dhenat e payload-it
            if (Doctor == null)
                return NotFound();

            Doctor.Name = payload.Name;
            Doctor.LastName = payload.LastName;
            Doctor.Code = payload.Code;
            Doctor.ExperienceYears = payload.ExperienceYears;
            Doctor.PhoneNumber = payload.PhoneNumber;
            Doctor.SpecializationField = payload.SpecializationField;

            //3. Ruhen te dhenat ne database
            _appDbContext.Doctors.Update(Doctor);
            _appDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteDoctor/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var Doctor = _appDbContext.Doctors.FirstOrDefault(x => x.Id == id);

            if (Doctor == null)
                return NotFound();

            _appDbContext.Doctors.Remove(Doctor);
            _appDbContext.SaveChanges();

            return Ok($"Doctori me id = {id} u fshi me sukses!");
        }
    }
}



