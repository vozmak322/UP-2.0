using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Dbcontext;

namespace UPractice
{
    [Serializable]
    public class ComboTeacher
    {
        public ComboTeacher()
        {

        }

        public ComboTeacher(Teacher tch,  Chair chr, Faculty fcl)
        {
            TeacherId = tch.Id;
            FirstName = tch.FirstName;
            SecondName = tch.SecondName;
            LastName = tch.LastName;

            ChairId = chr.Id;
            NameChair = chr.NameChair;
            ShortNameChair = chr.ShortNameChair;

            FacultyId = fcl.Id;
            NameFaculty = fcl.NameFaculty;
            ShortNameFaculty = fcl.ShortNameFaculty;
        }

        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        public int ChairId { get; set; }
        public string NameChair { get; set; }
        public string ShortNameChair { get; set; }

        public int FacultyId { get; set; }
        public string NameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }

        public override string ToString()
        {
            return FirstName + " " + SecondName + " " + LastName + " " + NameFaculty + " " + NameChair;
        }
    }
}
