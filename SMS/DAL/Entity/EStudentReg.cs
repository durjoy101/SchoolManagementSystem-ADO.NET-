using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class EStudentReg
    {
        public int Action { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string FathersOccupation { get; set; }
        public string FathersContact { get; set; }
        public string MothersName { get; set; }
        public string MothersOccupation { get; set; }
        public string MothersContact { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int ReligionId { get; set; }
        public string DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string GuardianName { get; set; }
        public string GuardianContact { get; set; }
        public int IsActive { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
