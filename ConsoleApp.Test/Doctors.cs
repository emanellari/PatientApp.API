using ConsoleApp.Test.Interfaces;

namespace ConsoleApp.Test
{
    public class Doctors:IDataService
    {
        public string Name { get; set; }
        public int ExperienceYears { get; set; }
        public string LastName { get; set; }
        public string SpecializationField { get; set; }
        public int PhoneNumber { get; set; }

        public string GetDataFromDatabase()
        {
            //throw new NotImplementedException();

            //SQL

            return "";
        }
    }
}
